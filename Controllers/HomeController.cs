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
    public class ModelStartPage
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
                .Include(x => x.Category).OrderBy(x => x.RegDate).Take(15).ToList();
            
            var topRate = _context.Companies.Include(x => x.Images).Include(x => x.CompanyTags).ThenInclude(x => x.Tag)
                .Include(x => x.Category).OrderByDescending(x => x.AverageRating).Take(15).ToList();
            var model = new ModelStartPage { topNew = topNew, topRate = topRate };

            ViewBag.Tags = GetNotNullTags();
            
            
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

        public List<string> GetNotNullTags()
        {
            var temp = _context.Tags.Include(x => x.CompanyTags).ToList();
            var tags = new List<string>();
            foreach (var tag in temp)
            {
                foreach (var id in tag.CompanyTags)
                {
                    if (id.CompanyId != null)
                    {
                        tags.Add(tag.Name);
                    }
                }
            }
            return tags.Distinct().ToList();
        }
        
    }
}
