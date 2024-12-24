namespace EmployeeCRUDApp.Application.ViewModel
{
    public class VmDepartment
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; } = string.Empty;
        public int? ManagerId { get; set; }
        public string Manager { get; set; } = string.Empty;
        public decimal Budget { get; set; }
        public bool Deleted { get; set; }
    }
}
