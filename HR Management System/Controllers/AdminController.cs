using HRM.Contracts;
using HRM.Models.Admin;
using HRM.Models.Admin.Payments;
using HRM.Models.EmployeeInfo;
using HRM.Services;
using Microsoft.AspNetCore.Mvc;

namespace HR_Management_System.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;
        private readonly ILogger<AdminController> _logger;
        public AdminController(ILogger<AdminController> logger , IAdminService adminService)
        {
            _logger = logger;
            _adminService = adminService;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
           if(model.UserName=="Admin" && model.Password == "Admin123")
            {
                return RedirectToAction("CandidateList", "Admin");
            }
            else
            {
                return RedirectToAction("Login","Admin");
            }
        }
        public async Task<IActionResult> CandidateList()
        {
            var Candidate = await _adminService.GetCandidateListsAsync();
            return View(Candidate);
        }
        public async Task<IActionResult> CreateCandidate()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCandidate(AddCandidate model)
        {
            await _adminService.CreateCandidateAsync(model);
            return RedirectToAction("CandidateList");
        }


        public async Task<IActionResult> EditCandidate(int id)
        {
            var dto = await _adminService.EditCandidateAsync(id);
            return View(dto);
        }
        [HttpPost]
        public async Task<IActionResult> EditCandidate(EditCandidate model)
        {
            await _adminService.UpdateCandidateAsync(model);
            return RedirectToAction("CandidateList");
        }
        public async Task<IActionResult> DeleteCandidate(int id)
        {
            await _adminService.DeleteCandidateAsync(id);
            return RedirectToAction("CandidateList");
        }

        public async Task<IActionResult> EmployeePaymentList()
        {
            var payment = await _adminService.GetEmployeePaymentListAsync();
            return View(payment);
        }

        public async Task<IActionResult> EditEmployeePayment(int id)
        {
            var dto = await _adminService.GetEmployeePaymentAsync(id);
            return View("EditPayment",dto);
        }
        [HttpPost]
        public async Task<IActionResult> EditEmployeePayment(EditPayment model)
        {
            await _adminService.UpdateEmployeePaymentAsync(model);
            return RedirectToAction("EmployeePaymentList");
        }

    }
}
