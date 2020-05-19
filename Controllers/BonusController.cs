using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crowdfunding.Data;
using Crowdfunding.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SQLitePCL;

namespace Crowdfunding.Controllers
{    

    public class BonusController : Controller
    {
        public UserManager<CustomUser> _userManager { get; }

        private readonly ApplicationDbContext _context;
        public BonusController(ApplicationDbContext context, UserManager<CustomUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<IActionResult> Index(int? companyId)
        {
            if (companyId == null)
            {
                return NotFound();
            }
            var companyBonuses = await _context.Bonuses.Include(x => x.Company).ThenInclude(x => x.CustomUser)
                .Where(x => x.CompanyId == companyId).ToListAsync();
            var company = await _context.Companies.Include(x => x.CustomUser)
                .FirstOrDefaultAsync(x => x.Id == companyId);
            ViewBag.UserNameCompanyOwner = company.CustomUser.UserName;
            ViewBag.CompanyId = companyId;
            return View(companyBonuses);
        }

        public async Task<IActionResult> Create(int? companyId, List<string> modelErrors)
        {
            if (companyId == null)
            {
                return NotFound();
            }
            foreach (var elem in modelErrors)
            {
                var error = elem.Split("//");
                ModelState.AddModelError(error[0], error[1]);
            }            
            if (PermissionToCreate(companyId) == false)
            {
                return RedirectToAction("NoPermission", "Companies");
            }
            ViewBag.CompanyId = companyId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(int? companyId, Bonus bonus)
        {
            if (companyId == null)
            {
                return NotFound();
            }            
            var temp = await _context.Bonuses.AsNoTracking().FirstOrDefaultAsync(x => x.Name == bonus.Name && bonus.CompanyId == x.CompanyId);
            if (temp != null)
            {
                ModelState.AddModelError(nameof(bonus.Name), $"A bonus with the name \"{bonus.Name}\" already exists.");
            }
            var modelErrors = new List<string>();
            if (ModelState.IsValid)
            {                
                _context.Add(bonus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { companyId = companyId });
            }
            else
            {
                modelErrors = GetModelErrors(ModelState);
            }
            return RedirectToAction(nameof(Create), new { companyId = companyId, modelErrors = modelErrors});
        }

        public async Task<IActionResult> Edit(int? id, int? companyId, List<string> modelErrors)
        {
            if (id == null || companyId == null)
            {
                return NotFound();
            }
            if (modelErrors != null)
            {
                foreach(var elem in modelErrors)
                {
                    var error = elem.Split("//");
                    ModelState.AddModelError(error[0], error[1]);
                }
            }
            var bonus = await _context.Bonuses.AsNoTracking().Include(x => x.Company).ThenInclude(x => x.CustomUser)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (PermissionToCreate(companyId) == false)
            {
                return RedirectToAction("NoPermission", "Companies");
            }
            ViewBag.CompanyId = companyId;
            return View(bonus);
        }

        [HttpPost]        
        public async Task<IActionResult> Edit(int? id, int? companyId, Bonus bonus)
        {            
            if (id == null || companyId == null)
            {
                return NotFound();
            }
            var temp = await _context.Bonuses.AsNoTracking().FirstOrDefaultAsync(x => x.Name == bonus.Name && x.CompanyId == bonus.CompanyId);
            if (temp!=null && temp.Id != bonus.Id)
            {
                ModelState.AddModelError(nameof(bonus.Name), $"A bonus with the name \"{bonus.Name}\" already exists.");                                 
            }
            var modelErrors = new List<string>();
            if (ModelState.IsValid)
            {
                _context.Update(bonus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { companyId = companyId });
            }
            else
            {
                modelErrors = GetModelErrors(ModelState);
            }
            return RedirectToAction(nameof(Edit), new { id = id, companyId = companyId, 
                modelErrors = modelErrors});
        }

        public async Task<IActionResult> Delete(int? id, int? companyId)
        {
            if (id == null || companyId == null)
            {
                return NotFound();
            }
            var bonus = await _context.Bonuses.Include(x => x.Company)
                .ThenInclude(x => x.CustomUser).FirstOrDefaultAsync(x => x.Id == id);
            if (PermissionToCreate(companyId) == false)
            {
                return RedirectToAction("NoPermission", "Companies");
            }
            _context.Bonuses.Remove(bonus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { companyId = companyId});
        }

        public async Task<IActionResult> PaymentCheck(int? id)
        {
            var bonus = await _context.Bonuses.FirstOrDefaultAsync(x => x.Id == id);
            if (bonus == null)
            {
                return NotFound();
            }            
            return View(bonus);
        }
        
        public async Task<IActionResult> Payment(int? bonusId)
        {            
            var bonus = await _context.Bonuses.FirstOrDefaultAsync(x => x.Id == bonusId);
            var company = await _context.Companies.FirstOrDefaultAsync(x => x.Id == bonus.CompanyId);
            if (bonus == null)
            {
                return NotFound();
            }
            bonus.CustomUserBonus.Add(new CustomUserBonus { BonusId = bonus.Id, CustomUserId = _userManager.GetUserId(User) });
            company.CurrentMoney += bonus.Price;
            _context.Update(company);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Companies", new { id = bonus.CompanyId });
        }

        public async Task<IActionResult> MyBonuses()
        {
            var user = await _context.Users.Include(x => x.CustomUserBonus)
                .ThenInclude(x => x.Bonus).ThenInclude(x => x.Company).FirstOrDefaultAsync(x => x.UserName == User.Identity.Name);
            
            return View(user.CustomUserBonus);
        }
        public List<string> GetModelErrors(ModelStateDictionary modelState)
        {
            var result = new List<string>();
            var erroneousFields = modelState.Where(ms => ms.Value.Errors.Any())
                                            .Select(x => new { x.Key, x.Value });
            foreach (var erroneousField in erroneousFields)
            {
                var fieldKey = erroneousField.Key;
                var fieldErrors = erroneousField.Value.Errors;
                foreach (var error in fieldErrors)
                {
                    result.Add(fieldKey + "//" + error.ErrorMessage);
                }                
            }
            return result;
        }

        public bool PermissionToCreate(int? companyId)
        {
            var userId =  _context.Users.FirstOrDefault(x => x.UserName == User.Identity.Name).Id;
            var userCompanies =  _context.Companies.Where(x => x.CustomUserId == userId).Select(x => x.Id).ToList();
            int intCompanyId = companyId.GetValueOrDefault();
            if (userCompanies.IndexOf(intCompanyId) != -1 || User.IsInRole("Admin") == true)
            {
                return (true);
            }
            return (false);
        }

        
    }
}