using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CMS.Models
{
    public class CMSDbContext: DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        public DbSet<City> City { get; set; }
        public DbSet<Classification> Classification { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Gender> Gender { get; set; }
        public DbSet<Region> Region { get; set; }
        public DbSet<UserSys> UserSys { get; set; }
        public DbSet<UserRole> UserRole { get; set; }

    }
}