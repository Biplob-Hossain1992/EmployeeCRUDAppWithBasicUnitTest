using EmployeeCRUDApp.Application.ViewModel;

namespace EmployeeCRUDApp.Application.Interfaces.IServices
{
    public interface IDepartmentService
    {
        Task<VmResponseMessage> CreateDepartment(VmDepartment vm);
        Task<List<VmDepartment>> GetAllDepartment();
        Task<VmDepartment> GetDepartmentById(int id);
        Task<VmResponseMessage> UpdateDepartment(VmDepartment vm);
        Task<bool> RemoveDepartment(int id);
    }
}
