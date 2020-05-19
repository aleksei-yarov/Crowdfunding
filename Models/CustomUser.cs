using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crowdfunding.Models
{
    public class CustomUser : IdentityUser
    {
        public DateTime RegistrDate {get; set;}
        public List<Company> Companies { get; set; }
        public List<CustomUserBonus> CustomUserBonus { get; set; }
        public CustomUser()
        {
            CustomUserBonus = new List<CustomUserBonus>();
        }
       
    }
}
