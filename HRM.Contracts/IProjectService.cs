using HRM.Models.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Contracts
{
    public interface IProjectService
    {
        Task<List<ProjectInfo>> GetProjectListAsync();
        Task CreateNewProjectAsync(AddProject project);
        Task<ProjectInfo> GetProjectAsync(int id);
        Task UpdateProjectAsync(ProjectInfo project);
        Task DeleteProjectAsync(int id);
    }
}
