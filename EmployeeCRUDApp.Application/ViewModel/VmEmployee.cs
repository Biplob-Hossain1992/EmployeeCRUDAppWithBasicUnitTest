namespace EmployeeCRUDApp.Application.ViewModel
{
    #nullable disable
    public class VmEmployee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Position { get; set; }
        public DateTime JoinDate { get; set; }
        public string FormatedDate { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public bool Status { get; set; }
        public int ReviewScore { get; set; }
        public bool Deleted { get; set; }
    }
}
