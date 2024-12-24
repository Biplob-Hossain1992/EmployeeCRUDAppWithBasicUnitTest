using EmployeeCRUDApp.Application.Interfaces.IRepository;
using EmployeeCRUDApp.Application.Interfaces.IServices;
using EmployeeCRUDApp.Application.ViewModel;

namespace EmployeeCRUDApp.Application.Services
{
    public class PerformanceReviewService : IPerformanceReviewService
    {
        private readonly IPerformanceReviewRepository _performanceReviewRepository;
        public PerformanceReviewService(IPerformanceReviewRepository performanceReviewRepository)
        {
            _performanceReviewRepository = performanceReviewRepository;
        }
        public async Task<VmResponseMessage> CreateReview(VmReview vm)
        {
            var response = await _performanceReviewRepository.CreateReview(vm);
            return response;
        }
        public async Task<List<VmReview>> GetAllReview()
        {
            var response = await _performanceReviewRepository.GetAllReview();
            return response;
        }
        public async Task<VmReview> GetReviewById(int id)
        {
            var response = await _performanceReviewRepository.GetReviewById(id);
            return response;
        }
        public async Task<VmResponseMessage> UpdateReview(VmReview vm)
        {
            var response = await _performanceReviewRepository.UpdateReview(vm);
            return response;
        }
        public async Task<bool> RemoveReview(int id)
        {
            var response = await _performanceReviewRepository.RemoveReview(id);
            return response;
        }
        public async Task<List<VmAverageScore>> GetAverageScore()
        {
            var response = await _performanceReviewRepository.GetAverageScore();
            return response;
        }
    }
}
