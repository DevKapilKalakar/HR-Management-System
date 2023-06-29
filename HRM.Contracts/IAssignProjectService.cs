using HRM.Models.AssignProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Contracts
{
    public interface IAssignProjectService
    {
        Task<List<AllAssignProject>> GetAllAssignProjectAsync();
        Task<AddAssignProject> GetCreateAssignProjectAsync();
        Task CreateAssignProject(AddAssignProject model);
    }
}
