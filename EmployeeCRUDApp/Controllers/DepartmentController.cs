using EmployeeCRUDApp.Application.Interfaces.IServices;
using EmployeeCRUDApp.Application.Services;
using EmployeeCRUDApp.Application.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeCRUDApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        [Route("CreateDepartment")]
        [HttpPost]
        public async Task<ActionResult<VmResponseMessage>> CreateDepartment(VmDepartment vm)
        {
            return Ok(await _departmentService.CreateDepartment(vm));
        }
        [Route("GetAllDepartment")]
        [HttpGet]
        public async Task<ActionResult<List<VmDepartment>>> GetAllDepartment()
        {
            return Ok(await _departmentService.GetAllDepartment());
        }
        [Route("GetAllDepartmentForDataTable")]
        [HttpPost]
        public async Task<ActionResult<List<VmDepartment>>> GetAllDepartmentForDataTable()
        {
            var draw = Request.Form["draw"].FirstOrDefault();
            var start = Request.Form["start"].FirstOrDefault();
            var length = Request.Form["length"].FirstOrDefault();
            var searchValue = Request.Form["search[value]"].FirstOrDefault();
            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;

            var data = await _departmentService.GetAllDepartment();

            if (!string.IsNullOrWhiteSpace(searchValue))
            {
                data = data.Where(x => x.DepartmentName.ToLower().Contains(searchValue.ToLower())).ToList();
            }
            int recordsTotal = data.Count;
            data = data.Skip(skip).Take(pageSize).ToList();
            return Ok(new { draw, recordsFiltered = recordsTotal, recordsTotal, data });
        }
        [Route("GetDepartmentById")]
        [HttpGet]
        public async Task<ActionResult<VmDepartment>> GetDepartmentById(int id)
        {
            return Ok(await _departmentService.GetDepartmentById(id));
        }
        [Route("UpdateDepartment")]
        [HttpPost]
        public async Task<ActionResult<VmResponseMessage>> UpdateDepartment(VmDepartment vm)
        {
            return Ok(await _departmentService.UpdateDepartment(vm));
        }
        [Route("RemoveDepartment")]
        [HttpDelete]
        public async Task<ActionResult<bool>> RemoveDepartment(int id)
        {
            return Ok(await _departmentService.RemoveDepartment(id));
        }
    }
}
