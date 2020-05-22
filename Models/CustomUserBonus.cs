using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Crowdfunding.Models
{
    public class CustomUserBonus
    {
        public string CustomUserId { get; set; }
        public CustomUser CustomUser { get; set; }
        public int? BonusId { get; set; }
        public Bonus Bonus { get; set; }
        public int Count { get; set; }

    }
}
