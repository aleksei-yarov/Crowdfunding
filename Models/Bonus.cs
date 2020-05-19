using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Crowdfunding.Models
{
    public class Bonus
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string Description { get; set; }
        public int? CompanyId { get; set; }
        public Company Company { get; set; }
        public List<CustomUserBonus> CustomUserBonus { get; set; }
        public Bonus()
        {
            CustomUserBonus = new List<CustomUserBonus>();
        }


    }
}
