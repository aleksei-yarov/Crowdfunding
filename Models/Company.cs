using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Crowdfunding.Models
{
    public class Company
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Company name")]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public double TargetMoney { get; set; }
        public double CurrentMoney { get; set; }
        [Required]
        public DateTime? EndDate { get; set; }
        public DateTime? RegDate { get; set; }

        [Required]
        [RegularExpression(@"https://www.youtube.com/watch\?v=.{11}", ErrorMessage = "Invalid url")]
        public string YoutubeSrc { get; set; }
        public double AverageRating { get; set; }
        public string CustomUserId { get; set; }
        public CustomUser CustomUser { get; set; } 
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
        public List<CompanyTag> CompanyTags { get; set; }
        public Company()
        {
            CompanyTags = new List<CompanyTag>();
            RegDate = DateTime.Now;
        } 
        public List<Bonus> Bonuses { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Image> Images { get; set; }
        public List<News> News { get; set; }
        public List<Rating> Ratings { get; set; }

    }
}
