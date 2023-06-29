using HRM.Contracts;
using HRM.Models.AssignProject;
using HRM.Models.EmployeeInfo;
using HRM.Services;
using Microsoft.AspNetCore.Mvc;

namespace HR_Management_System.Controllers
{
    public class AssignProjectController : Controller
    {
        private readonly IAssignProjectService _assignProjectService;

        public AssignProjectController(IAssignProjectService assignProjectService)
        {
            _assignProjectService = assignProjectService;
        }


        public async Task<IActionResult> AllAssignProject()
        {
            var Assign = await _assignProjectService.GetAllAssignProjectAsync();
            return View(Assign);
        }

       
        public async Task<IActionResult> CreateAssignProject()
        {
            var model = await _assignProjectService.GetCreateAssignProjectAsync();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAssignProject(AddAssignProject model)
        {
            await _assignProjectService.CreateAssignProject(model);
            return RedirectToAction("AllAssignProject");
        }


    }
}
