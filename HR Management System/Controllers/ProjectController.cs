using HRM.Contracts;
using HRM.Models.Project;
using Microsoft.AspNetCore.Mvc;

namespace HR_Management_System.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService) 
        {
            _projectService = projectService;
        }

        public async Task<IActionResult> GetProjectList()
        {
            var dto = await _projectService.GetProjectListAsync();
            return View("ProjectList", dto);
        }

        public async Task<IActionResult> CreateNewProject()
        {
            return View("Create");
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewProject(AddProject project)
        {
            await _projectService.CreateNewProjectAsync(project);
            return RedirectToAction("GetProjectList");
        }

        public async Task<IActionResult> GetProject(int id)
        {
            var project = await _projectService.GetProjectAsync(id);
            return View("EditProject", project);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProject(ProjectInfo project)
        {
            await _projectService.UpdateProjectAsync(project);
            return RedirectToAction("GetProjectList");
        }

        public async Task<IActionResult> DeleteProject(int id)
        {
            await _projectService.DeleteProjectAsync(id);
            return RedirectToAction("GetProjectList");
        }
    }
}
