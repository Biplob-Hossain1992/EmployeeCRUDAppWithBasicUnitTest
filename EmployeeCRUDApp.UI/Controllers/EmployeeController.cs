using Microsoft.AspNetCore.Mvc;

namespace EmployeeCRUDApp.UI.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }
    }
}
