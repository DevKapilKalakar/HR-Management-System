using HRM.Contracts;
using HRM.Domain.Entities;
using HRM.Infrastructure;
using HRM.Models.AssignProject;
using HRM.Models.EmployeeInfo;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace HRM.Services
{
    public class AssignProjectService : IAssignProjectService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AssignProjectService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<AllAssignProject>> GetAllAssignProjectAsync()
        {
            var employees = await (from e in _unitOfWork.Employees.All().AsNoTracking()
                                   join ep in _unitOfWork.EmployeeAssignProjects.All().AsNoTracking() on e.Id equals ep.EmployeeId
                                   select new AllAssignProject
                                   {
                                       EmployeeName = e.Name,
                                       ProjectName = ep.Project.Name,
                                       Id = ep.Id
                                   }).ToListAsync();

            return employees;
        }

        public async Task<AddAssignProject> GetCreateAssignProjectAsync()
        {
            return new AddAssignProject
            {
                EmployeeList = new SelectList(_unitOfWork.Employees.All().OrderBy(s => s.Name).ToList(), "Id", "Name"),
                ProjectList = new SelectList(_unitOfWork.Projects.All().OrderBy(s => s.Name).ToList(), "Id", "Name")
            };

        }
        public async Task CreateAssignProject(AddAssignProject model)
        {
            var assignProjects = new EmployeeAssignProject
            {
                EmployeeId = model.EmployeeId,
                ProjectId = model.ProjectId,

            };
            _unitOfWork.EmployeeAssignProjects.Add(assignProjects);
            await _unitOfWork.SaveAsync();
        }


    }

}

