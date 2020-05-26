using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crowdfunding.Models
{
    public class News
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int? CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
