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
using Microsoft.AspNetCore.Authorization;

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

        public enum SortState
        {
            NameAsc,    
            NameDesc,   
            MoneyAsc,
            MoneyDesc,            
            DateAsc,
            DateDesc,
            CategoryAsc,
            CategoryDesc,
            UserAsc,
            UserDesc
        }

        // GET: Companies
        [Authorize]
        public async Task<IActionResult> Index(SortState sortOrder = SortState.NameAsc)
        {            
            var allCompany = await _context.Companies.Include(c => c.CustomUser).Where(x => x.CustomUser.UserName == User.Identity.Name)
                .Include(c => c.Category).Include(x => x.Bonuses).ToListAsync();   
            
            ViewBag.SortState = GetSortStateDict(sortOrder);                        
            var model = GetSortedModel(allCompany, sortOrder);
            return View(model);

        }

       

        public async Task<IActionResult> AllCompanies(SortState sortOrder = SortState.NameAsc)
        {            
           var allCompany = await _context.Companies.Include(c => c.CustomUser).Include(x => x.Category)
                .Include(x => x.CompanyTags).ThenInclude(x => x.Tag).ToListAsync();

            ViewBag.SortState = GetSortStateDict(sortOrder);
            var model = GetSortedModel(allCompany, sortOrder);
            return View(model); 
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
                .Include(x => x.Comments).ThenInclude(x => x.Votes).Include(x => x.CompanyTags).ThenInclude(x => x.Tag)
                .Include(x => x.News).Include(x => x.Images).FirstOrDefaultAsync(m => m.Id == id);
            if (company == null)
            {
                return NotFound();
            }            
            company.Comments.Reverse();            
            ViewBag.UserRating = GetUserRating(User.Identity.Name, id);            
            return View(company);
        }



        
        [Authorize]
        public IActionResult Create()
        {
            ViewData["CustomUserId"] = new SelectList(_context.Users, "Id", "UserName");
            ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name");
            ViewBag.UserId = _userManager.GetUserId(User);
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Company company, List<string> Tags, string images)
        {          
            var temp = await _context.Companies.AsNoTracking().FirstOrDefaultAsync(x => x.Name == company.Name);
            ChekImages(images, ModelState);
            if (temp != null)
            {
                ModelState.AddModelError(nameof(company.Name), "A company with the same name already exists.");
            }
            if (ModelState.IsValid)
            {
                company.YoutubeSrc = company.YoutubeSrc.Replace("watch?v=", "embed/");
                SaveTags(Tags);
                AddTagsToCompany(Tags, company);                
                _context.Add(company);
                await _context.SaveChangesAsync();
                SaveImages(images, company.Name);
                return RedirectToAction("Index");
            }
            ViewData["CustomUserId"] = new SelectList(_context.Users, "Id", "UserName");
            ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name");
            ViewBag.UserId = _userManager.GetUserId(User);
            return View(company);
        }

        [Authorize]
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
            company.YoutubeSrc = company.YoutubeSrc.Replace("embed/", "watch?v=");
            ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name");
            ViewBag.UserId = (await _userManager.GetUserAsync(User)).Id;
            ViewBag.Tags = GetTags(company);
            return View(company);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Company company, List<string> Tags, string images)
        {
            if (id != company.Id)
            {
                return NotFound();
            }
            var temp = await _context.Companies.AsNoTracking().Include(x => x.CompanyTags)
                .FirstOrDefaultAsync(x => x.Name == company.Name);
            ChekImages(images, ModelState);
            if (temp != null && temp.Id != company.Id)
            {
                ModelState.AddModelError(nameof(company.Name), "A company with the same name already exists.");
            }
            
            if (ModelState.IsValid)
            {
                company.YoutubeSrc = company.YoutubeSrc.Replace("watch?v=", "embed/");
                _context.Update(company);
                await _context.SaveChangesAsync();
                ChangeTag(Tags, id);
                SaveImages(images, company.Name);
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomUserId"] = new SelectList(_context.Users, "Id", "UserName", company.CustomUserId);
            company.YoutubeSrc = company.YoutubeSrc.Replace("embed/", "watch?v=");
            ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name", company.CategoryId);
            ViewBag.UserId = (await _userManager.GetUserAsync(User)).Id;
            ViewBag.Tags = GetTags(company);
            return View(company);
        }

        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            var company = await _context.Companies.Include(x => x.CustomUser).Include(x => x.Bonuses)
                .Include(x => x.Ratings).Include(x => x.News)
                .Include(x =>x.Images).Include(x => x.Comments).FirstOrDefaultAsync(x => x.Id == id);
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
            return RedirectToAction(nameof(AllCompanies));
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
                    var oldImg = _context.Images.Where(x => x.CompanyId == companyId).ToList();
                    foreach (var image in oldImg)
                    {
                        _context.Images.Remove(image);
                    }
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
        public async Task<IActionResult> Autocomplete()
        {
            try
            {
                string term = HttpContext.Request.Query["term"].ToString();
                var names = await _context.Tags.Where(p => p.Name.Contains(term)).Select(p => p.Name).ToListAsync();
                return Ok(names);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public JsonResult PublicationNews([FromBody] News news)
        {
            _context.Add(news);
            _context.SaveChanges();
            return Json(new { newsId = news.Id });
        }

        [HttpPost]
        public void UpdateNews([FromBody] News news)
        {
            _context.Update(news);
            _context.SaveChanges();            
        }

        [HttpPost]
        public void DeleteNews([FromBody] string newsId)
        {
            int number;
            bool isParsable = Int32.TryParse(newsId, out number);
            if (isParsable)
            {
                var news = _context.News.FirstOrDefault(x => x.Id == number);
                _context.Remove(news);
                _context.SaveChanges();
            }
            
        }

        [HttpPost]
        public JsonResult Rate([FromBody] Rating rating)
        {
            var temp = _context.Ratings.AsNoTracking()
                .FirstOrDefault(x => x.CompanyId == rating.CompanyId && x.UserName == rating.UserName);
            var company = _context.Companies.FirstOrDefault(x => x.Id == rating.CompanyId);
            if (temp == null)
            {
                _context.Add(rating);
                _context.SaveChanges();
            }
            else
            {
                rating.Id = temp.Id;
                _context.Update(rating);
                _context.SaveChanges();
            }
            company.AverageRating = GetRating(company.Id);            
            _context.SaveChanges();            
            return Json(new { companyRating = company.AverageRating });
        }

        public double GetRating(int? companyId)
        {
            var allRating = _context.Ratings.Where(x => x.CompanyId == companyId).ToList();
            double average = 0;
            foreach(var rating in allRating)
            {
                average += rating.Value;
            }
            if (allRating.Count == 0)
            {
                return 0;
            }   
            
            return Math.Round(average / allRating.Count, 2);
        }

        public double GetUserRating(string name, int? id)
        {
            var rating = _context.Ratings.FirstOrDefault(x => x.UserName == name && x.CompanyId == id);
            if (rating != null)
            {
                return rating.Value;
            }
            else
            {
                return 0;
            }
        }

        public async Task<IActionResult> GetViewByTag(string tagName)
        {
            var temp = await _context.Tags.Include(x => x.CompanyTags).FirstOrDefaultAsync(x => x.Name == tagName);
            var companies = new List<Company>();
            foreach(var comp in temp.CompanyTags)
            {
                companies.Add(await _context.Companies.Include(x => x.Images).Include(x => x.Category)
                    .FirstOrDefaultAsync(x => x.Id == comp.CompanyId));
            }
            ViewBag.Tag = tagName;
            return View(companies);
        }

        public async Task<IActionResult> GetViewByCategory(string categoryName)
        {
            var companies = await _context.Companies.Include(x => x.Images)
                .Include(x => x.Category).Where(x => x.Category.Name == categoryName).ToListAsync();
            ViewBag.Category = categoryName;
            return View(companies);
        }

        public async Task<IActionResult> Search(string searchTerm)
        {
            
            var companies = await _context.Companies.Include(x => x.Category)
                            .Where(x => x.Name.Contains(searchTerm) ||
                                    x.Description.Contains(searchTerm) ||
                                    x.Category.Name.Contains(searchTerm)).ToListAsync();
            
            var comments = await _context.Comments.Where(x => x.Message.Contains(searchTerm)).Select(x => x.CompanyId).ToListAsync();
            foreach (var id in comments)
            {
                var temp = await _context.Companies.FirstOrDefaultAsync(x => x.Id == id);
                if (temp!= null && companies.FirstOrDefault(x => x.Id == temp.Id) == null)
                {
                    companies.Add(temp);
                }                
            }
            var news = await _context.News.Where(x => x.Content.Contains(searchTerm)).Select(x => x.CompanyId).ToListAsync();
            foreach (var id in news)
            {
                var temp = await _context.Companies.FirstOrDefaultAsync(x => x.Id == id);
                if (temp != null && companies.FirstOrDefault(x => x.Id == temp.Id) == null)
                {
                    companies.Add(temp);
                }                
            }
            ViewBag.Search = searchTerm;
            return View(companies);
        }

        [HttpPost]
        public JsonResult Vote([FromBody] Vote vote)
        {
            var temp = _context.Votes.AsNoTracking().FirstOrDefault(x => x.Username == vote.Username && x.CommentId == vote.CommentId);
            if (temp == null)
            {
                _context.Add(vote);
            }
            else
            {
                vote.Id = temp.Id;
                _context.Update(vote);
            }
            
            _context.SaveChanges();


            return Json(new { result = GetVotes(vote.CommentId) });
        }

        public int GetVotes(int? commentId)
        {
            var comment = _context.Comments.Include(x => x.Votes).FirstOrDefault(x => x.Id == commentId);
            var result = 0;
            if (comment == null)
            {
                return 0;
            }
            else
            {
                foreach (var item in comment.Votes)
                {
                    result += item.Value;
                }
                comment.VoteResult = result;
                _context.SaveChanges();
                return result;
            }
        }

        private object GetSortedModel(List<Company> allCompany, SortState sortOrder)
        {
            var model = sortOrder switch
            {
                SortState.NameAsc => allCompany.OrderBy(x => x.Name),
                SortState.NameDesc => allCompany.OrderByDescending(x => x.Name),
                SortState.MoneyAsc => allCompany.OrderBy(x => x.TargetMoney),
                SortState.MoneyDesc => allCompany.OrderByDescending(x => x.TargetMoney),
                SortState.DateAsc => allCompany.OrderBy(x => x.EndDate),
                SortState.DateDesc => allCompany.OrderByDescending(x => x.EndDate),
                SortState.CategoryAsc => allCompany.OrderBy(x => x.Category.Name),
                SortState.CategoryDesc => allCompany.OrderByDescending(x => x.Category.Name),
                SortState.UserAsc => allCompany.OrderBy(x => x.CustomUser.UserName),
                SortState.UserDesc => allCompany.OrderByDescending(x => x.CustomUser.UserName),

            };
            return model;
        }

        private Dictionary<string, SortState> GetSortStateDict(SortState sortOrder)
        {
            return new Dictionary<string, SortState>
            {
                ["NameSort"] = sortOrder == SortState.NameAsc ? SortState.NameDesc : SortState.NameAsc,
                ["MoneySort"] = sortOrder == SortState.MoneyAsc ? SortState.MoneyDesc : SortState.MoneyAsc,
                ["DateSort"] = sortOrder == SortState.DateAsc ? SortState.DateDesc : SortState.DateAsc,
                ["CategorySort"] = sortOrder == SortState.CategoryAsc ? SortState.CategoryDesc : SortState.CategoryAsc,
                ["UserSort"] = sortOrder == SortState.UserAsc ? SortState.UserDesc : SortState.UserAsc
            };            
        }

    }
}
