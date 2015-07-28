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

            //modelBuilder.Entity<BudgetInfo>()
            //  .HasRequired(b => b.LaborCost)
            //  .WithMany()
            //  .HasForeignKey(b => b.LabourID);
           
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<ProjectBasedata> ProjectBasedatas { get; set; }

        public DbSet<BudgetInfo> Budgets { get; set; }

        public DbSet<LaborCost> LaborCosts { get; set; }

        public DbSet<MaterialCost> MaterialCosts { get; set; }

        public DbSet<MachineryCost> MachineryCosts { get; set; }

        public DbSet<Measure> Measures { get; set; }

        public DbSet<Overhead> Overheads { get; set; }
        //--------------------------财务管理---------------------------------
        public DbSet<Income> Incomes { get; set; }

        public DbSet<Payables> Payables { get; set; }

        public DbSet<Accounting> Accountings { get; set; }

        //-------------------即时管理---------------------------------
        public DbSet<InsBudgetInfo> InsBudgetInfos { get; set; }

        public DbSet<InsLaborCost> InsLaborCosts { get; set; }

        public DbSet<InsMaterialCost> InsMaterialCosts { get; set; }

        public DbSet<InsMachineryCost> InsMachineryCosts { get; set; }

        public DbSet<InsMeasure> InsMeasures { get; set; }

        public DbSet<InsOverhead> InsOverheads { get; set; }

        //-----------------------------资产管理----------------------
        public DbSet<Files> Files { get; set; }

        public DbSet<Oddments> Oddments { get; set; }

        public DbSet<ProjectCtrl> ProjectCtrls { get; set; }

        public DbSet<OfficeCtrl> OfficeCtrls { get; set; }

        public DbSet<Odder> Odders { get; set; }
    }
}
