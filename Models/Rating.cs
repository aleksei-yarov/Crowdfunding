using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crowdfunding.Models
{
    public class Rating
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public string UserName { get; set; }
        public int? CompanyId { get; set; }
        public Company Company { get; set; }

    }
}
