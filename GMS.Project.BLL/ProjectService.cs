using GMS.Project.Contract;
using GMS.Project.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityFramework.Extensions;
using GMS.Framework.Utility;
using GMS.Framework.Contract;

namespace GMS.Project.BLL
{
    public class ProjectService : IProjectService
    {
        #region ProjectBasedata CURD
        public ProjectBasedata GetProjectBasedata(int id)
        {
            using (var dbContext = new ProjectDbContext())
            {
                return dbContext.Find<ProjectBasedata>(id);
            }
        }

        public IEnumerable<ProjectBasedata> GetProjectBasedataList(ProjectRequest request = null)
        {
            request = request ?? new ProjectRequest();
            using (var dbContext = new ProjectDbContext())
            {
                IQueryable<ProjectBasedata> ProjectBasedatas = dbContext.ProjectBasedatas;

                if (!string.IsNullOrEmpty(request.PName))
                    ProjectBasedatas = ProjectBasedatas.Where(u => u.PName.Contains(request.PName));

                return ProjectBasedatas.OrderByDescending(u => u.ID).ToPagedList(request.PageIndex, request.PageSize);
            }
        }

        public void SaveProjectBasedata(ProjectBasedata project)
        {
            using (var dbContext = new ProjectDbContext())
            {

                if (project.ID>0)
                {
                    dbContext.Update<ProjectBasedata>(project);
                }
                else
                {
                    dbContext.Insert<ProjectBasedata>(project);
                }
            }
        }

        public void DeleteProjectBasedata(List<int> ids)
        {
            using (var dbContext = new ProjectDbContext())
            {
                dbContext.ProjectBasedatas.Where(u => ids.Contains(u.ID)).Delete();
            }
        }
        #endregion

        #region Budget CURD
        public Budget GetBudget(int id)
        {
            using (var dbContext = new ProjectDbContext())
            {
                return dbContext.Find<Budget>(id);
            }
        }

        public IEnumerable<Budget> GetBudgetList(BudgetRequest request = null)
        {
            request = request ?? new BudgetRequest();
            using (var dbContext = new ProjectDbContext())
            {
                IQueryable<Budget> Budget = dbContext.Budget;

                if (!string.IsNullOrEmpty(request.ProjectName))
                    Budget = Budget.Where(u => u.ProjectName.Contains(request.ProjectName));

                return Budget.OrderByDescending(u => u.ID).ToPagedList(request.PageIndex, request.PageSize);
            }
        }

        public void SaveBudget(Budget budget)
        {
            using (var dbContext = new ProjectDbContext())
            {

                if (budget.ID != null)
                {
                    dbContext.Update<Budget>(budget);
                }
                else
                {
                    dbContext.Insert<Budget>(budget);
                }
            }
        }

        public void DeleteBudget(List<int> ids)
        {
            using (var dbContext = new ProjectDbContext())
            {
                dbContext.Budget.Where(u => ids.Contains(u.ID)).Delete();
            }
        }
        #endregion
    }
}
