using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crowdfunding.Models
{
    public class Bonus
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int? CompanyId { get; set; }
        public Company Company { get; set; }

    }
}
