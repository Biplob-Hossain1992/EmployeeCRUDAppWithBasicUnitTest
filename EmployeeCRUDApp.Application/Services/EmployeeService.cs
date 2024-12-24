using EmployeeCRUDApp.Application.Interfaces.IRepository;
using EmployeeCRUDApp.Application.Interfaces.IServices;
using EmployeeCRUDApp.Application.ViewModel;

namespace EmployeeCRUDApp.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<VmResponseMessage> CreateEmployee(VmEmployee vm)
        {
            var response = await _employeeRepository.CreateEmployee(vm);
            return response;
        }
        public async Task<List<VmEmployee>> GetAllEmployee(int curPage, int takeRows)
        {
            var response = await _employeeRepository.GetAllEmployee(curPage, takeRows);
            //set if any business logic
            return response;
        }
        public async Task<List<VmEmployee>> GetDrpEmployees()
        {
            var response = await _employeeRepository.GetDrpEmployees();
            return response;
        }
        public async Task<VmEmployee> GetEmployeeById(int id)
        {
            var response = await _employeeRepository.GetEmployeeById(id);
            return response;
        }
        public async Task<VmResponseMessage> UpdateEmployee(VmEmployee vm)
        {
            var response = await _employeeRepository.UpdateEmployee(vm);
            return response;
        }
        public async Task<bool> RemoveEmployee(int id)
        {
            var response = await _employeeRepository.RemoveEmployee(id);
            return response;
        }
    }
}
