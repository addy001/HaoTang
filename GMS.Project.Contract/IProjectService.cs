using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityFramework.Extensions;

namespace GMS.Project.Contract
{
    public interface IProjectService
    {

        ProjectBasedata GetProjectBasedata(int id);
        IEnumerable<ProjectBasedata> GetProjectBasedataList(ProjectRequest request = null);
        void SaveProjectBasedata(ProjectBasedata project);
        void DeleteProjectBasedata(List<int> ids);
    }
}
