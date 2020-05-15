using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crowdfunding.Data;
using Crowdfunding.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SQLitePCL;

namespace Crowdfunding.Controllers
{    

    public class BonusController : Controller
    {
        private readonly ApplicationDbContext _context;
        public BonusController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? companyId)
        {
            if (companyId == null)
            {
                return NotFound();
            }
            var companyBonuses = await _context.Bonuses.Include(x => x.Company).Where(x => x.CompanyId == companyId).ToListAsync();
            ViewBag.CompanyId = companyId;
            return View(companyBonuses);
        }

        public IActionResult Create(int? companyId, List<string> modelErrors)
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
            ViewBag.CompanyId = companyId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(int? companyId, [Bind("Id, Name, Price, CompanyId")] Bonus bonus)
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
                modelErrors = GetErrors(ModelState);
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
            var bonus = await _context.Bonuses.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            ViewBag.CompanyId = companyId;
            return View(bonus);
        }

        [HttpPost]        
        public async Task<IActionResult> Edit(int? id, int? companyId, [Bind("Id, Name,Price, CompanyId")]Bonus bonus)
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
                modelErrors = GetErrors(ModelState);
            }
            return RedirectToAction(nameof(Edit), new { id = id, companyId = companyId, 
                modelErrors = modelErrors});
        }

        public async Task<IActionResult> Delete(int id, int companyId)
        {
            var bonus = await _context.Bonuses.FindAsync(id);
            _context.Bonuses.Remove(bonus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { companyId = companyId});
        }

        public List<string> GetErrors(ModelStateDictionary modelState)
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
    }
}