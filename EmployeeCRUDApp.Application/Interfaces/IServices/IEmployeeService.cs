using EmployeeCRUDApp.Application.ViewModel;
using static System.Formats.Asn1.AsnWriter;
using System.Xml.Linq;

namespace EmployeeCRUDApp.Application.Interfaces.IServices
{
    public interface IEmployeeService
    {
        Task<VmResponseMessage> CreateEmployee(VmEmployee vm);
        Task<List<VmEmployee>> GetAllEmployee(int curPage, int takeRows);
        Task<List<VmEmployee>> GetDrpEmployees();
        Task<VmEmployee> GetEmployeeById(int id);
        Task<VmResponseMessage> UpdateEmployee(VmEmployee vm);
        Task<bool> RemoveEmployee(int id);
    }
}
