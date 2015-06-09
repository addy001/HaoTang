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

                if (!string.IsNullOrEmpty(request.ProjName))
                    ProjectBasedatas = ProjectBasedatas.Where(u => u.ProjName.Contains(request.ProjName));

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
    }
}
