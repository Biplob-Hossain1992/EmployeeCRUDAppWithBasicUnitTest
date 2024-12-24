namespace EmployeeCRUDApp.Application.ViewModel
{
    public class VmReview
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; } = string.Empty;
        public DateTime ReviewDate { get; set; }
        public string FormatedDate { get; set; } = string.Empty;
        public int ReviewScore { get; set; }
        public string ReviewNote { get; set; } = string.Empty;
        public bool Deleted { get; set;}
    }
}
