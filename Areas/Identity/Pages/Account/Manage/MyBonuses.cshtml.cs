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
    public class MyBonusesModel : PageModel
    {
        public ApplicationDbContext _context { get; }
        public CustomUser CurrentUser { get; set; }
        public List<CustomUserBonus> CurrentUserBonuses { get; set; }
        public MyBonusesModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            CurrentUser = _context.Users.Include(x => x.CustomUserBonus)
                .ThenInclude(x => x.Bonus).ThenInclude(x => x.Company).FirstOrDefault(x => x.UserName == User.Identity.Name);
            CurrentUserBonuses = CurrentUser.CustomUserBonus;
        }
    }
}
