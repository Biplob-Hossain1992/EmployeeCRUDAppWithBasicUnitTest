using EmployeeCRUDApp.Application.ViewModel;

namespace EmployeeCRUDApp.Application.Interfaces.IRepository
{
    public interface IEmployeeRepository
    {
        Task<VmResponseMessage> CreateEmployee(VmEmployee vm);
        Task<List<VmEmployee>> GetAllEmployee(int curPage, int takeRows);
        Task<List<VmEmployee>> GetDrpEmployees();
        Task<VmEmployee> GetEmployeeById(int id);
        Task<VmResponseMessage> UpdateEmployee(VmEmployee vm);
        Task<bool> RemoveEmployee(int id);
    }
}
