using EmployeeCRUDApp.Application.Interfaces.IServices;
using EmployeeCRUDApp.Application.ViewModel;
using EmployeeCRUDApp.Controllers;
using Moq;

namespace TestNinja.UnitTest
{
    [TestClass]
    public class DemoUnitTest
    {
        [TestMethod]
        public async Task GetEmployeeByIdAsync()
        {
            var employee = new VmEmployee
            {
                Id = 1,
                Name = "Test",
                Email = "test@gmail.com",
                Phone = "01703504061",
                Position = "Manager",
                JoinDate = DateTime.Now,
                DepartmentId = 1,
                Status = true,
                DepartmentName = "Demo",
            };
            var employeeService = new Mock<IEmployeeService>();
            employeeService.Setup(x => x.GetEmployeeById(It.IsAny<int>())).Returns(Task.FromResult(employee));

            var controller = new EmployeeController(employeeService.Object);
            var getEmployeeById = await controller.GetEmployeeById(1);
            Assert.IsNotNull(getEmployeeById);
        }
    }
}