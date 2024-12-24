using EmployeeCRUDApp.Application.ViewModel;

namespace EmployeeCRUDApp.Application.Interfaces.IServices
{
    public interface IPerformanceReviewService
    {
        Task<VmResponseMessage> CreateReview(VmReview vm);
        Task<List<VmReview>> GetAllReview();
        Task<VmReview> GetReviewById(int id);
        Task<VmResponseMessage> UpdateReview(VmReview vm);
        Task<bool> RemoveReview(int id);
        Task<List<VmAverageScore>> GetAverageScore();
    }
}
