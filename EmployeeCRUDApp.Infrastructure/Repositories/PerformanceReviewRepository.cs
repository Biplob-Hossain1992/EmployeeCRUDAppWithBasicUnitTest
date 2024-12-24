using Dapper;
using EmployeeCRUDApp.Application.Interfaces.IRepository;
using EmployeeCRUDApp.Application.ViewModel;
using System.Data;

namespace EmployeeCRUDApp.Infrastructure.Repositories
{
    public class PerformanceReviewRepository : IPerformanceReviewRepository
    {
        private readonly IDbConnection _dbContext;
        public PerformanceReviewRepository(IDbConnection dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<VmResponseMessage> CreateReview(VmReview vm)
        {
            var response = new VmResponseMessage();

            var parameter = new DynamicParameters();
            parameter.Add("@EmployeeId", vm.EmployeeId, DbType.Int32);
            parameter.Add("@ReviewDate", vm.ReviewDate, DbType.DateTime2);
            parameter.Add("@ReviewScore", vm.ReviewScore, DbType.Int32);
            parameter.Add("@ReviewNote", vm.ReviewNote, DbType.String);
            try
            {
                var data = await _dbContext.ExecuteAsync("[Hr].[USP_CreateReview]", parameter, commandType: CommandType.StoredProcedure);
                if (data > 0)
                {
                    response.Type = "Success";
                    response.Message = "Review Created Successfully..!";
                }
                else if (data < 0)
                {
                    response.Type = "Error";
                    response.Message = "Review Already Exist..!";
                }
            }
            catch (Exception)
            {
                throw;
            }
            return response;
        }
        public async Task<List<VmReview>> GetAllReview()
        {
            var data = await _dbContext.QueryAsync<VmReview>("[Hr].[USP_GetAllReview]", commandType: CommandType.StoredProcedure);
            return data.ToList();
        }
        public async Task<VmReview> GetReviewById(int id)
        {
            var paramerter = new DynamicParameters();
            paramerter.Add("@Id", id, DbType.Int32);
            var data = await _dbContext.QueryFirstOrDefaultAsync<VmReview>("[Hr].[USP_GetReviewById]", paramerter, commandType: CommandType.StoredProcedure);

            if (data is not null)
            {
                return data;
            }
            return new VmReview();
        }
        public async Task<VmResponseMessage> UpdateReview(VmReview vm)
        {
            var response = new VmResponseMessage();
            var parameter = new DynamicParameters();
            parameter.Add("@Id", vm.Id, DbType.Int32);
            parameter.Add("@EmployeeId", vm.EmployeeId, DbType.Int32);
            parameter.Add("@ReviewDate", vm.ReviewDate, DbType.DateTime2);
            parameter.Add("@ReviewScore", vm.ReviewScore, DbType.Int32);
            parameter.Add("@ReviewNote", vm.ReviewNote, DbType.String);

            var data = await _dbContext.ExecuteAsync("[Hr].[USP_UpdateReview]", parameter, commandType: CommandType.StoredProcedure);
            if (data > 0)
            {
                response.Type = "Success";
                response.Message = "Review Updated Successfully..!";
            }
            else if (data < 0)
            {
                response.Type = "Error";
                response.Message = "Review Doesn't Exist..!";
            }
            return response;
        }
        public async Task<bool> RemoveReview(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Id", id, DbType.Int32);
            var data = await _dbContext.ExecuteAsync("[Hr].[USP_RemoveReview]", parameter, commandType: CommandType.StoredProcedure);
            if (data > 0)
            {
                return true;
            }
            return false;
        }
        public async Task<List<VmAverageScore>> GetAverageScore()
        {
            var data = await _dbContext.QueryAsync<VmAverageScore>("[Hr].[USP_GetAverageScore]", commandType: CommandType.StoredProcedure);
            return data.ToList();
        }
    }
}
