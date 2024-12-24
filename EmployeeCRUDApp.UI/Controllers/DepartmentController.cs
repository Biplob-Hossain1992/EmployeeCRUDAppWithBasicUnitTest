using Microsoft.AspNetCore.Mvc;

namespace EmployeeCRUDApp.UI.Controllers
{
    public class DepartmentController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }
    }
}
