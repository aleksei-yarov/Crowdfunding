using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crowdfunding.Models
{
    public class CompanyTag
    {
        public int? CompanyId { get; set; }
        public Company Company { get; set; }

        public int? TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
