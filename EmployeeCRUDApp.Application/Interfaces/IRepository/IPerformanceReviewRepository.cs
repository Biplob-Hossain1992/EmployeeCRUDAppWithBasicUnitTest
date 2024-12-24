using EmployeeCRUDApp.Application.ViewModel;

namespace EmployeeCRUDApp.Application.Interfaces.IRepository
{
    public interface IPerformanceReviewRepository
    {
        Task<VmResponseMessage> CreateReview(VmReview vm);
        Task<List<VmReview>> GetAllReview();
        Task<VmReview> GetReviewById(int id);
        Task<VmResponseMessage> UpdateReview(VmReview vm);
        Task<bool> RemoveReview(int id);
        Task<List<VmAverageScore>> GetAverageScore();
    }
}
