using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeCRUDApp.Domain.Entities
{
    [Table("Department", Schema = "Hr")]
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string DepartmentName { get; set; } = string.Empty;
        public int? ManagerId { get; set; }
        [ForeignKey("ManagerId")]
        public Employee Manager { get; set; } = new Employee();
        [Required]
        public decimal Budget { get; set; }
        public bool Deleted { get;set; }        
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
