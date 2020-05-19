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
        public DateTime? EndDate { get; set; }
        [RegularExpression(@"https://www.youtube.com/watch\?v=.{11}", ErrorMessage = "Invalid url")]
        public string YoutubeSrc { get; set; }
        public string CustomUserId { get; set; }
        public CustomUser CustomUser { get; set; } 
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
        public List<CompanyTag> CompanyTags { get; set; }
        public Company()
        {
            CompanyTags = new List<CompanyTag>();
        } 
        public List<Bonus> Bonuses { get; set; }

    }
}
