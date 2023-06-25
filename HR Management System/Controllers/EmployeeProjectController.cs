using Microsoft.AspNetCore.Mvc;

namespace HR_Management_System.Controllers
{
    public class EmployeeProjectController : Controller
    {
        public IActionResult SearchedDataListing()
        {
            return View();
        }

        public IActionResult AssignProject()
        {
            return View();
        }
    }
}
