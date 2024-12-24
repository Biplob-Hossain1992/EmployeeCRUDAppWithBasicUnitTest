using Dapper;
using EmployeeCRUDApp.Application.Interfaces.IRepository;
using EmployeeCRUDApp.Application.ViewModel;
using EmployeeCRUDApp.Infrastructure.Service;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EmployeeCRUDApp.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IDbConnection _dbContext;
        public EmployeeRepository(IDbConnection dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<VmResponseMessage> CreateEmployee(VmEmployee vm)
        {
            var response = new VmResponseMessage();

            var parameter = new DynamicParameters();
            parameter.Add("@Name", vm.Name, DbType.String);
            parameter.Add("@Email", vm.Email, DbType.String);
            parameter.Add("@Phone", vm.Phone, DbType.String);
            parameter.Add("@Position", vm.Position, DbType.String);
            parameter.Add("@JoinDate", vm.JoinDate, DbType.DateTime);
            parameter.Add("@DepartmentId", vm.DepartmentId, DbType.Int32);
            parameter.Add("@Status", vm.Status, DbType.Boolean);

            try
            {
                var data = await _dbContext.ExecuteAsync("[Hr].[USP_CreateEmployee]", parameter, commandType: CommandType.StoredProcedure);
                if (data > 0)
                {
                    response.Type = "Success";
                    response.Message = "Employee Created Successfully..!";
                }
                else if (data < 0)
                {
                    response.Type = "Error";
                    response.Message = "Employee Already Exist..!";
                }
            }
            catch (Exception)
            {
                throw;
            }
            return response;
        }
        public async Task<List<VmEmployee>> GetAllEmployee(int curPage, int takeRows)
        {
            var paramerter = new DynamicParameters();
            paramerter.Add("@SkipRows", curPage, DbType.Int32);
            paramerter.Add("@TakeRows", takeRows, DbType.Int32);
            var data = await _dbContext.QueryAsync<VmEmployee>("[Hr].[USP_GetAllEmployee]", paramerter, commandType: CommandType.StoredProcedure);
            return data.ToList();
        }
        public async Task<List<VmEmployee>> GetDrpEmployees()
        {
            var data = await _dbContext.QueryAsync<VmEmployee>("[Hr].[USP_GetDrpEmployees]", commandType: CommandType.StoredProcedure);
            return data.ToList();
        }
        public async Task<VmEmployee> GetEmployeeById(int id)
        {
            var paramerter = new DynamicParameters();
            paramerter.Add("@Id", id, DbType.Int32);
            var data = await _dbContext.QueryFirstOrDefaultAsync<VmEmployee>("[Hr].[USP_GetEmployeeById]", paramerter, commandType: CommandType.StoredProcedure);
            
            if(data is not null)
            {
                return data;
            }
            return new VmEmployee();
        }
        public async Task<VmResponseMessage> UpdateEmployee(VmEmployee vm)
        {
            var response = new VmResponseMessage();
            var parameter = new DynamicParameters();
            parameter.Add("@Id", vm.Id, DbType.Int32);
            parameter.Add("@Name", vm.Name, DbType.String);
            parameter.Add("@Email", vm.Email, DbType.String);
            parameter.Add("@Phone", vm.Phone, DbType.String);
            parameter.Add("@Position", vm.Position, DbType.String);
            parameter.Add("@JoinDate", vm.JoinDate, DbType.DateTime);
            parameter.Add("@DepartmentId", vm.DepartmentId, DbType.Int32);
            parameter.Add("@Status", vm.Status, DbType.Boolean);

            var data = await _dbContext.ExecuteAsync("[Hr].[USP_UpdateEmployee]", parameter, commandType: CommandType.StoredProcedure);
            if (data > 0)
            {
                response.Type = "Success";
                response.Message = "Employee Updated Successfully..!";
            }
            else if (data < 0)
            {
                response.Type = "Error";
                response.Message = "Employee Doesn't Exist..!";
            }
            return response;
        }
        public async Task<bool> RemoveEmployee(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Id", id, DbType.Int32);
            var data = await _dbContext.ExecuteAsync("[Hr].[USP_RemoveEmployee]", parameter, commandType: CommandType.StoredProcedure);
            if (data > 0)
            {
                return true;
            }
            return false;
        }
    }
}
