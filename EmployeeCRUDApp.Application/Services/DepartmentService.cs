using EmployeeCRUDApp.Application.Interfaces.IRepository;
using EmployeeCRUDApp.Application.Interfaces.IServices;
using EmployeeCRUDApp.Application.ViewModel;

namespace EmployeeCRUDApp.Application.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public async Task<VmResponseMessage> CreateDepartment(VmDepartment vm)
        {
            var response = await _departmentRepository.CreateDepartment(vm);
            return response;
        }
        public async Task<List<VmDepartment>> GetAllDepartment()
        {
            var response = await _departmentRepository.GetAllDepartment();
            return response;
        }
        public async Task<VmDepartment> GetDepartmentById(int id)
        {
            var response = await _departmentRepository.GetDepartmentById(id);
            return response;
        }
        public async Task<VmResponseMessage> UpdateDepartment(VmDepartment vm)
        {
            var response = await _departmentRepository.UpdateDepartment(vm);
            return response;
        }
        public async Task<bool> RemoveDepartment(int id)
        {
            var response = await _departmentRepository.RemoveDepartment(id);
            return response;
        }
    }
}
