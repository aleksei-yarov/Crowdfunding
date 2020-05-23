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
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Crowdfunding.Controllers
{
    public class CompaniesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public UserManager<CustomUser> _userManager { get; }
        public IWebHostEnvironment _appEnvironment { get; }

        public CompaniesController(ApplicationDbContext context, UserManager<CustomUser> manager,
            IWebHostEnvironment appEnvironment)
        {
            _context = context;
            _userManager = manager;
            _appEnvironment = appEnvironment;
        }

        // GET: Companies
        public async Task<IActionResult> Index()
        {            
            var applicationDbContext = _context.Companies.Include(c => c.CustomUser).Where(x => x.CustomUser.UserName == User.Identity.Name)
                .Include(c => c.Category).Include(x => x.Bonuses);
            return View(await applicationDbContext.ToListAsync());

        }

        public async Task<IActionResult> AllCompanies()
        {            
           var allCompany = _context.Companies.Include(c => c.CustomUser).Include(x => x.Category);
           return View(await allCompany.ToListAsync()); 
        }

        // GET: Companies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }             
            var company = await _context.Companies
                .Include(c => c.CustomUser).Include(x => x.Category).Include(x => x.Bonuses)
                .Include(x => x.Comments).Include(x => x.CompanyTags).ThenInclude(x => x.Tag)
                .Include(x => x.Images).FirstOrDefaultAsync(m => m.Id == id);
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
            var temp = company.Comments;
            temp.Reverse();
            ViewBag.Comments = temp;          
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
        public async Task<IActionResult> Create(Company company, List<string> Tags, string Images)
        {          
            var temp = await _context.Companies.AsNoTracking().FirstOrDefaultAsync(x => x.Name == company.Name);
            ChekImages(Images, ModelState);
            if (temp != null)
            {
                ModelState.AddModelError(nameof(company.Name), "A company with the same name already exists.");
            }
            if (ModelState.IsValid)
            {
                SaveTags(Tags);
                AddTagsToCompany(Tags, company);                
                _context.Add(company);
                await _context.SaveChangesAsync();
                SaveImages(Images, company.Name);
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
            var company = await _context.Companies.Include(x => x.CustomUser)
                .Include(x => x.CompanyTags).ThenInclude(x => x.Tag).FirstOrDefaultAsync(x => x.Id == id);
            if (company == null)
            {
                return NotFound();
            }
            if (User.Identity.Name != company.CustomUser.UserName && User.IsInRole("Admin") != true)
            {
                return View(nameof(NoPermission));
            }
            ViewData["CustomUserId"] = new SelectList(_context.Users, "Id", "UserName", company.CustomUserId);
            ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name");
            ViewBag.UserId = (await _userManager.GetUserAsync(User)).Id;
            ViewBag.Tags = GetTags(company);
            return View(company);
        }

        // POST: Companies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Company company, List<string> Tags)
        {
            if (id != company.Id)
            {
                return NotFound();
            }

            var temp = await _context.Companies.AsNoTracking().Include(x => x.CompanyTags)
                .FirstOrDefaultAsync(x => x.Name == company.Name);
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
                    ChangeTag(Tags, id);                    
                    
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
            var company = await _context.Companies.Include(x => x.CustomUser).Include(x => x.Bonuses)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (company == null)
            {
                return NotFound();
            }
            if (User.Identity.Name != company.CustomUser.UserName && User.IsInRole("Admin") != true)
            {
                return RedirectToAction(nameof(NoPermission));
            }
            _context.Companies.Remove(company);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        
        public async Task<IActionResult> NoPermission()
        {
            return View();
        }

        private bool CompanyExists(int id)
        {
            return _context.Companies.Any(e => e.Id == id);
        }

        private void SaveTags(List<string> TagList)
        {
            foreach (var elem in TagList)
            {
                if (elem != null && !_context.Tags.Any(e => e.Name == elem))
                {
                    Tag Tag = new Tag { Name = elem };
                    _context.Add(Tag);
                    _context.SaveChanges();
                }
            }
        }

        private void AddTagsToCompany(List<string> TagList, Company company)
        {
            TagList = TagList.Distinct().ToList();
            foreach(var elem in TagList)
            {     
                if (elem != null)
                {
                    var tempId = _context.Tags.AsNoTracking().FirstOrDefault(x => x.Name == elem).Id;  
                    company.CompanyTags.Add(new CompanyTag{CompanyId = company.Id, TagId = tempId});
                    _context.SaveChanges();
                }
            }
        }

        private void ChangeTag(List<string> TagList, int? companyId)
        {
            var company = _context.Companies.Include(x => x.CompanyTags)
                .ThenInclude(x => x.Tag).FirstOrDefault(x => x.Id == companyId);
            var oldTags = new List<string>();
            foreach(var elem in company.CompanyTags)
            {
                oldTags.Add(elem.Tag.Name);
            }
            var newTags = TagList.Except(oldTags).ToList();
            SaveTags(newTags);
            AddTagsToCompany(newTags, company);
            DeleteTagsFromCompany(oldTags.Except(TagList).ToList(), company);      
            
        }

        private void DeleteTagsFromCompany(List<string> TagList, Company company)
        {
            foreach(var tagName in TagList)
            {
                var tag = _context.Tags.FirstOrDefault(x => x.Name == tagName);
                var companyTag = company.CompanyTags.FirstOrDefault(x => x.TagId == tag.Id);
                company.CompanyTags.Remove(companyTag);
                _context.SaveChanges();
            }
        }

        private List<string> GetTags (Company company)
        {
            List<string> Tags = new List<string>();
            foreach(var elem in company.CompanyTags)
            {
                Tags.Add(elem.Tag.Name);
            }
            if (Tags.Count != 2)
            {
                Tags.Add(null);
                Tags.Add(null);
            }
            return Tags;
        }

        private void SaveImages(string Images, string companyName)
        {
            if (Images != null && companyName != null)
            {
                var imagesLink = Images.Split(".....");
                imagesLink = imagesLink.Where(val => !string.IsNullOrEmpty(val)).ToArray();
                var companyId = _context.Companies.FirstOrDefault(x => x.Name == companyName).Id;
                if (companyId != 0)
                {
                    foreach(var link in imagesLink)
                    {
                        var image = new Image { Link = link, CompanyId = companyId };
                        _context.Add(image);
                    }                    
                    _context.SaveChanges();
                }
            }           
        }

        private void ChekImages(string images, ModelStateDictionary modelState)
        {
            if (images == null || images.Split(".....").Length>6)
            {
                modelState.AddModelError("name", "You must upload from one to five images");                
            }  
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
