using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crowdfunding.Models
{
    public class Image 
    {
        public int Id { get; set; }        
        public string Link { get; set; }
        public int? CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
