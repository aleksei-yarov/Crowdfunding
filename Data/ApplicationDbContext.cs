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
        public DbSet<Category> Categories { get; set; } 
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Bonus> Bonuses { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Image> Images { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // без этого нельзя перезаписывать OnModelCreating
            modelBuilder.Entity<CompanyTag>()
                .HasKey(t => new { t.CompanyId, t.TagId });

            modelBuilder.Entity<CompanyTag>()
                .HasOne(sc => sc.Company)
                .WithMany(s => s.CompanyTags)
                .HasForeignKey(sc => sc.CompanyId);

            modelBuilder.Entity<CompanyTag>()
                .HasOne(sc => sc.Tag)
                .WithMany(c => c.CompanyTags)
                .HasForeignKey(sc => sc.TagId);

            modelBuilder.Entity<CustomUserBonus>()
                .HasKey(t => new { t.CustomUserId, t.BonusId });

            modelBuilder.Entity<CustomUserBonus>()
                .HasOne(sc => sc.CustomUser)
                .WithMany(s => s.CustomUserBonus)
                .HasForeignKey(sc => sc.CustomUserId);

            modelBuilder.Entity<CustomUserBonus>()
                .HasOne(sc => sc.Bonus)
                .WithMany(c => c.CustomUserBonus)
                .HasForeignKey(sc => sc.BonusId);
        }
    }
}
