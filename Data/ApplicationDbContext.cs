using System;
using System.Collections.Generic;
using System.Text;
using Crowdfunding.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Crowdfunding.Data
{
    public class ApplicationDbContext : IdentityDbContext<CustomUser>
    {       
        public DbSet<Company> Companies { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
