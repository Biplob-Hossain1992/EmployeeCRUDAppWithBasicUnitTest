using Microsoft.AspNetCore.Mvc;

namespace EmployeeCRUDApp.UI.Controllers
{
    public class PerformanceReviewController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult AverageScore()
        {
            return View();
        }
    }
}
