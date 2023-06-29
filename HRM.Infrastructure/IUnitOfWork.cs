using HRM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Infrastructure
{
    public interface IUnitOfWork:IDisposable
    {
        IBaseRepository<Employee> Employees { get; }
        IBaseRepository<Candidate> Candidates { get; }
        IBaseRepository<Project> Projects { get; }
        IBaseRepository<EmployeeAssignProject> EmployeeAssignProjects{ get; }
        Task<int> SaveAsync();
    }
}
