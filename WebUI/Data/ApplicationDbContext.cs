using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WebUI.Data.Models;

namespace WebUI.Data
{
    public class ApplicationDbContext : DbContext
    {
        #region Constructor
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        #endregion Constructor

        #region Methods
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>().ToTable("Users");
            modelBuilder.Entity<ApplicationUser>().Property(i => i.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<ApplicationUser>().HasMany(u => u.Articles).WithOne(i => i.User);

            modelBuilder.Entity<Articles>().ToTable("Articles");
            modelBuilder.Entity<Articles>().Property(i => i.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Articles>().HasOne(i => i.User).WithMany(u => u.Articles);
            modelBuilder.Entity<Articles>().HasMany(i => i.SubArticles).WithOne(c => c.Articles);

            modelBuilder.Entity<SubArticle>().ToTable("SubArticle");
            modelBuilder.Entity<SubArticle>().Property(i => i.Id).ValueGeneratedOnAdd();
            //modelBuilder.Entity<SubArticle>().HasOne(i => i.Articles).WithOne(c => c.Article);

        }

        #endregion Methods

        #region Properties
        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<Articles> Articles { get; set; }
        public DbSet<SubArticle> SubArticles { get; set; }
        #endregion Properties
    }
}

