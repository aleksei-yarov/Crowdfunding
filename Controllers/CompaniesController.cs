using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Crowdfunding.Data;
using Crowdfunding.Models;
using Microsoft.AspNetCore.Identity;
using System.Diagnostics;

namespace Crowdfunding.Controllers
{
    public class CompaniesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public UserManager<CustomUser> _userManager { get; }

        public CompaniesController(ApplicationDbContext context, UserManager<CustomUser> manager)
        {
            _context = context;
            _userManager = manager;
        }

        // GET: Companies
        public async Task<IActionResult> Index()
        {
            if (User.IsInRole("Admin"))
            {
                var applicationDbContextAdmin = _context.Companies.Include(c => c.CustomUser).Include(x => x.Category);
                return View(await applicationDbContextAdmin.ToListAsync());
            }
            var applicationDbContext = _context.Companies.Include(c => c.CustomUser).Where(x => x.CustomUser.UserName == User.Identity.Name)
                .Include(c => c.Category);
            return View(await applicationDbContext.ToListAsync());

        }

        // GET: Companies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }             
            var company = await _context.Companies
                .Include(c => c.CustomUser).Include(x => x.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (company == null)
            {
                return NotFound();
            }
            if (company.YoutubeSrc != null)
            {
                ViewBag.Youtube = company.YoutubeSrc.Replace("watch?v=", "embed/");
            }
            else
            {
                ViewBag.Youtube = "https://www.youtube.com/embed/gsqsulWrhfQ";
            }
                       
            return View(company);
        }

        // GET: Companies/Create
        public IActionResult Create()
        {
            ViewData["CustomUserId"] = new SelectList(_context.Users, "Id", "UserName");
            ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name");
            ViewBag.UserId = _userManager.GetUserId(User);
            return View();
        }

        // POST: Companies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Discription,TargetMoney," +
            "EndDate,CustomUserId,CategoryId,YoutubeSrc")] Company company, List<string> Tags)
        {          
            var temp = await _context.Companies.AsNoTracking().FirstOrDefaultAsync(x => x.Name == company.Name);
            if (temp != null)
            {
                ModelState.AddModelError(nameof(company.Name), "A company with the same name already exists.");
            }
            if (ModelState.IsValid)
            {
                company.Tags = GetAllTags(Tags);
                _context.Add(company);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["CustomUserId"] = new SelectList(_context.Users, "Id", "UserName");
            ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name");
            ViewBag.UserId = _userManager.GetUserId(User);
            return View(company);
        }

        // GET: Companies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _context.Companies.FindAsync(id);
            if (company == null)
            {
                return NotFound();
            }
            ViewData["CustomUserId"] = new SelectList(_context.Users, "Id", "UserName", company.CustomUserId);
            ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name");
            ViewBag.UserId = (await _userManager.GetUserAsync(User)).Id;
            return View(company);
        }

        // POST: Companies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Discription,TargetMoney,EndDate,CustomUserId,CategoryId,YoutubeSrc")] Company company)
        {
            if (id != company.Id)
            {
                return NotFound();
            }

            var temp = await _context.Companies.AsNoTracking().FirstOrDefaultAsync(x => x.Name == company.Name);
            if (temp != null && temp.Id != company.Id)
            {
                ModelState.AddModelError(nameof(company.Name), "A company with the same name already exists.");
            }
            
            if (ModelState.IsValid)
            {
                try
                {
                    
                    _context.Update(company);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyExists(company.Id))
                    {
                        return NotFound();
                    }
                    else
                    {    
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomUserId"] = new SelectList(_context.Users, "Id", "UserName", company.CustomUserId);
            ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name", company.CategoryId);
            ViewBag.UserId = (await _userManager.GetUserAsync(User)).Id;
            return View(company);
        }

        // GET: Companies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _context.Companies
                .Include(c => c.CustomUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        // POST: Companies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var company = await _context.Companies.FindAsync(id);
            _context.Companies.Remove(company);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompanyExists(int id)
        {
            return _context.Companies.Any(e => e.Id == id);
        }

        private string GetAllTags(List<string> TagsList)
        {
            string Tags = "";
            foreach(var elem in TagsList)
            {
                Tag tag = new Tag { Name = elem };
                var temp = _context.Tags.FirstOrDefault(x => x.Name == tag.Name);
                if (temp == null)
                {
                    _context.Add(tag);
                    _context.SaveChanges();
                }                
                Tags += elem + ",";
            }
            return Tags;

        }

        [Produces("application/json")]
        [HttpGet("search")]
        public async Task<IActionResult> Search()
        {
            try
            {
                string term = HttpContext.Request.Query["term"].ToString();
                var names = _context.Tags.Where(p => p.Name.Contains(term)).Select(p => p.Name).ToList();
                return Ok(names);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
