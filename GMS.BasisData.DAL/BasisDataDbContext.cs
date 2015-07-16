using System;
using GMS.Framework.DAL;
using GMS.Core.Config;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using GMS.BasisData.Contract;
using GMS.Core.Log;

namespace GMS.BasisData.DAL
{

    public partial class BasisDataDbContext : DbContextBase
    {
        public BasisDataDbContext()
            : base(CachedConfigContext.Current.DaoConfig.Basedata, new LogDbContext())
        {
        }


        public  DbSet<Classification> Classifications { get; set; }
        public DbSet<Material> Materials { get; set; }
        public  DbSet<Supplier> Suppliers { get; set; }
        public DbSet<MaterialSupplier> MaterialSuppliers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<BasisDataDbContext>(null);
            //modelBuilder.Entity<Classification>()
            //    .HasMany(e => e.Materials)
            //    .WithOptional(e => e.Classification)
            //    .HasForeignKey(e => e.ClassificationID);

            //modelBuilder.Entity<Material>()
            //    .HasMany(e => e.Suppliers)
            //    .WithMany(e => e.Materials)
            //    .Map(m => m.ToTable("MaterialSupplier"));
            base.OnModelCreating(modelBuilder);
        }

    }
}
