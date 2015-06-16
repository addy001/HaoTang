using GMS.Core.Config;
using GMS.Core.Log;
using GMS.Framework.DAL;
using GMS.Project.Contract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace GMS.Project.DAL
{
    
    public class ProjectDbContext : DbContextBase
    {
         public ProjectDbContext()
            : base(CachedConfigContext.Current.DaoConfig.Project, new LogDbContext())
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<ProjectDbContext>(null);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<ProjectBasedata> ProjectBasedatas { get; set; }

        public DbSet<Budget> Budget { get; set; } 
    }
}
