using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crowdfunding.Data;
using Crowdfunding.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Crowdfunding.Areas.Identity.Pages.Account.Manage
{
    public class MyCompaniesModel : PageModel
    {
        public ApplicationDbContext _context { get; }

        public List<Company> Companies { get; set; }
        public MyCompaniesModel(ApplicationDbContext context)
        {
            _context = context;
        }
                
        public void OnGet()
        {
            Companies = _context.Companies.Include(c => c.CustomUser).Where(x => x.CustomUser.UserName == User.Identity.Name)
                .Include(c => c.Category).Include(x => x.Bonuses).ToList();
        }
    }
}
