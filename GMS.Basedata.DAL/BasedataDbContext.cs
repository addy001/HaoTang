using GMS.Basedata.Contract;
using GMS.Core.Config;
using GMS.Core.Log;
using GMS.Framework.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Data.Entity.Infrastructure;

namespace GMS.Basedata.DAL
{
    public class BasedataDbContext : DbContextBase
    {
        public BasedataDbContext()
            : base(CachedConfigContext.Current.DaoConfig.Basedata, new LogDbContext())
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<BasedataDbContext>(null);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Material> Materials { get; set; }
    }
}
