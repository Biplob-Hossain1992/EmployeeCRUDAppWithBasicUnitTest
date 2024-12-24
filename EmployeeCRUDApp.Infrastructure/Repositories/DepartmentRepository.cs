using Dapper;
using EmployeeCRUDApp.Application.Interfaces.IRepository;
using EmployeeCRUDApp.Application.ViewModel;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EmployeeCRUDApp.Infrastructure.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly IDbConnection _dbContext;
        public DepartmentRepository(IDbConnection dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<VmResponseMessage> CreateDepartment(VmDepartment vm)
        {
            var response = new VmResponseMessage();

            var parameter = new DynamicParameters();
            parameter.Add("@DepartmentName", vm.DepartmentName, DbType.String);
            parameter.Add("@ManagerId", vm.ManagerId, DbType.Int32);
            parameter.Add("@Budget", vm.Budget, DbType.Decimal);
            try
            {
                var data = await _dbContext.ExecuteAsync("[Hr].[USP_CreateDepartment]", parameter, commandType: CommandType.StoredProcedure);
                if (data > 0)
                {
                    response.Type = "Success";
                    response.Message = "Department Created Successfully..!";
                }
                else if (data < 0)
                {
                    response.Type = "Error";
                    response.Message = "Department Already Exist..!";
                }
            }
            catch (Exception)
            {
                throw;
            }            
            return response;
        }
        public async Task<List<VmDepartment>> GetAllDepartment()
        {
            var data = await _dbContext.QueryAsync<VmDepartment>("[Hr].[USP_GetAllDepartment]", commandType: CommandType.StoredProcedure);
            return data.ToList();
        }
        public async Task<VmDepartment> GetDepartmentById(int id)
        {
            var paramerter = new DynamicParameters();
            paramerter.Add("@Id", id, DbType.Int32);
            var data = await _dbContext.QueryFirstOrDefaultAsync<VmDepartment>("[Hr].[USP_GetDepartmentById]", paramerter, commandType: CommandType.StoredProcedure);

            if (data is not null)
            {
                return data;
            }
            return new VmDepartment();
        }
        public async Task<VmResponseMessage> UpdateDepartment(VmDepartment vm)
        {
            var response = new VmResponseMessage();
            var parameter = new DynamicParameters();
            parameter.Add("@Id", vm.Id, DbType.Int32);
            parameter.Add("@DepartmentName", vm.DepartmentName, DbType.String);
            parameter.Add("@ManagerId", vm.ManagerId, DbType.Int32);
            parameter.Add("@Budget", vm.Budget, DbType.Decimal);

            var data = await _dbContext.ExecuteAsync("[Hr].[USP_UpdateDepartment]", parameter, commandType: CommandType.StoredProcedure);
            if (data > 0)
            {
                response.Type = "Success";
                response.Message = "Department Updated Successfully..!";
            }
            else if (data < 0)
            {
                response.Type = "Error";
                response.Message = "Department Doesn't Exist..!";
            }
            return response;
        }
        public async Task<bool> RemoveDepartment(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Id", id, DbType.Int32);
            var data = await _dbContext.ExecuteAsync("[Hr].[USP_RemoveDepartment]", parameter, commandType: CommandType.StoredProcedure);
            if (data > 0)
            {
                return true;
            }
            return false;
        }
    }
}
