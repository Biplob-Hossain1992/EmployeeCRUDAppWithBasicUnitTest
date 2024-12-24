using EmployeeCRUDApp.Application.Interfaces.IServices;
using EmployeeCRUDApp.Application.Services;
using EmployeeCRUDApp.Application.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeCRUDApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [Route("CreateEmployee")]
        [HttpPost]
        public async Task<ActionResult<VmResponseMessage>> CreateEmployee(VmEmployee vm)
        {
            vm.JoinDate = Convert.ToDateTime(vm.FormatedDate);
            return Ok(await _employeeService.CreateEmployee(vm));
        }
        [Route("GetAllEmployee")]
        [HttpPost]
        public async Task<ActionResult<List<VmEmployee>>> GetAllEmployee()
        {
            var draw = Request.Form["draw"].FirstOrDefault();
            var start = Request.Form["start"].FirstOrDefault();
            var length = Request.Form["length"].FirstOrDefault();
            var searchValue = Request.Form["search[value]"].FirstOrDefault();
            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            var name = Request.Form["name"].FirstOrDefault();
            var departmentId = Request.Form["departmentId"].FirstOrDefault();
            var position = Request.Form["position"].FirstOrDefault();
            var score = Request.Form["score"].FirstOrDefault();

            var data = await _employeeService.GetAllEmployee(skip, pageSize);

            if (!string.IsNullOrWhiteSpace(searchValue))
            {
                data = data.Where(x => x.Name.ToLower().Contains(searchValue.ToLower()) 
                            || x.Phone.Contains(searchValue)).ToList();
            }
            if (!string.IsNullOrWhiteSpace(name))
            {
                data = data.Where(x => x.Name.ToLower().Contains(name.ToLower())).ToList();
            }
            if (!string.IsNullOrWhiteSpace(departmentId))
            {
                data = data.Where(x => x.DepartmentId == Convert.ToInt32(departmentId)).ToList();
            }
            if (!string.IsNullOrWhiteSpace(position))
            {
                data = data.Where(x => x.Position.ToLower().Contains(position.ToLower())).ToList();
            }
            if (!string.IsNullOrWhiteSpace(score))
            {
                string[] split = score.Split("-").ToArray();
                data = data.Where(x => x.ReviewScore >= Convert.ToInt32(split[0]) && x.ReviewScore <= Convert.ToInt32(split[1])).ToList();
            }
            data = data.DistinctBy(x => x.Id).ToList();
            int recordsTotal = data.Count;
            return Ok(new { draw, recordsFiltered = recordsTotal, recordsTotal, data });
        }
        [Route("GetDrpEmployees")]
        [HttpGet]
        public async Task<ActionResult<List<VmEmployee>>> GetDrpEmployees()
        {
            return Ok(await _employeeService.GetDrpEmployees());
        }
        [Route("GetEmployeeById")]
        [HttpGet]
        public async Task<ActionResult<VmEmployee>> GetEmployeeById(int id)
        {
            return Ok(await _employeeService.GetEmployeeById(id));
        }
        [Route("UpdateEmployee")]
        [HttpPost]
        public async Task<ActionResult<VmResponseMessage>> UpdateEmployee(VmEmployee vm)
        {
            vm.JoinDate = Convert.ToDateTime(vm.FormatedDate);
            return Ok(await _employeeService.UpdateEmployee(vm));
        }
        [Route("RemoveEmployee")]
        [HttpDelete]
        public async Task<ActionResult<bool>> RemoveEmployee(int id)
        {
            return Ok(await _employeeService.RemoveEmployee(id));
        }
    }
}
