using HRM.Contracts;
using HRM.Domain.Entities;
using HRM.Infrastructure;
using HRM.Models.Project;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Services
{
    public class ProjectService :IProjectService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProjectService(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateNewProjectAsync(AddProject project)
        {
            var p = new Project
            {
                Name = project.Name
            };
            _unitOfWork.Projects.Add(p);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteProjectAsync(int id)
        {
            var project = await _unitOfWork.Projects.All().FirstOrDefaultAsync(p => p.Id == id);
            if (project == null) { return; }

            _unitOfWork.Projects.Delete(project);
            await _unitOfWork.SaveAsync();
        }

        public async Task<ProjectInfo> GetProjectAsync(int id)
        {
            var project = await _unitOfWork.Projects.All().FirstOrDefaultAsync(p => p.Id == id);
            if(project == null) { return new ProjectInfo(); }

            return new ProjectInfo
            { 

                Id = project.Id,
                Name = project.Name
            };
        }

        public async Task<List<ProjectInfo>> GetProjectListAsync()
        {
            return await _unitOfWork.Projects.All().Select(p => new ProjectInfo 
            { 
                Id= p.Id,
                Name = p.Name
            }).ToListAsync();
        }

        public async Task UpdateProjectAsync(ProjectInfo model)
        {
            var project = await _unitOfWork.Projects.All().FirstOrDefaultAsync(p => p.Id == model.Id);
            if (project == null) { return; }

            project.Name = model.Name;

            _unitOfWork.Projects.Update(project);
            await _unitOfWork.SaveAsync();
        }
    }
}
