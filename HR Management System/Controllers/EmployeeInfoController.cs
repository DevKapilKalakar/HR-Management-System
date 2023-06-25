using HRM.Contracts;
using HRM.Models.EmployeeInfo;
using Microsoft.AspNetCore.Mvc;

namespace HR_Management_System.Controllers
{
    public class EmployeeInfoController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly ILogger<EmployeeInfoController> _logger;
        public EmployeeInfoController(ILogger<EmployeeInfoController> logger , IEmployeeService employeeService)
        {
            _employeeService = employeeService;
            _logger = logger;
        }

        public async Task<IActionResult> EmployeeList()
        {
            var Employee = await _employeeService.GetAllEmployeesAsync();
            return View(Employee);
        }         
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task< IActionResult> CreateEmployee(CreateEmployeeInfo model)
        { 
            await _employeeService.CreateEmployeesAsync(model);
            return RedirectToAction("EmployeeList");
        }
        

        public async Task<IActionResult> Edit( int id)
        {
            var dto = await _employeeService.EditEmployeeAsync(id);
            return View(dto);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditEmployeeInfo model)
        {
            await _employeeService.UpdateEmployeeAsync(model);
            return RedirectToAction("EmployeeList");
        }

        public async Task<IActionResult> Details(int id)
        {
            var dto = await _employeeService.DetailsEmployeeAsync(id);
            return View(dto);
        }
        public async Task<IActionResult> Delete(int id)
        {
            await _employeeService.DeleteEmployeeAsync(id);
            return RedirectToAction("EmployeeList");
        }
    }
}
 