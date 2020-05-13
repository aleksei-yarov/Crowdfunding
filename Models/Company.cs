using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public string Discription { get; set; }
        [Required]
        public double TargetMoney { get; set; }
        public DateTime EndDate { get; set; }        
        public string CustomUserId { get; set; }
        public CustomUser CustomUser { get; set; }
    }
}
