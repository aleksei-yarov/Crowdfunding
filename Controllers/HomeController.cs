using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Crowdfunding.Models;
using Crowdfunding.Data;
using Microsoft.EntityFrameworkCore;

namespace Crowdfunding.Controllers
{
    public class ViewModel
    {
        public List<Company> topNew { get; set; }
        public List<Company> topRate { get; set; }
    }

    public class HomeController : Controller
    {
        public ApplicationDbContext _context { get; }

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {

            var topNew = _context.Companies.Include(x => x.Images).Include(x => x.CompanyTags).ThenInclude(x => x.Tag)
                .OrderBy(x => x.RegDate).Take(2).ToList();
            
            var topRate = _context.Companies.Include(x => x.Images).Include(x => x.CompanyTags).ThenInclude(x => x.Tag)
                .OrderByDescending(x => x.AverageRating).Take(2).ToList();
            var model = new ViewModel { topNew = topNew, topRate = topRate };
            
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
    }
}
