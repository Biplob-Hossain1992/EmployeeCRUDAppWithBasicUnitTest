using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeCRUDApp.Domain.Entities
{
    #nullable disable
    [Table("Employee", Schema = "Hr")]
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Required]
        [StringLength(100)]
        public string Email { get; set; }
        [Required]
        [StringLength(15)]
        public string Phone { get; set; }
        [Required]
        [StringLength(255)]
        public string Position { get; set; }
        [Required]
        public DateTime JoinDate { get; set; }
        [Required]
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }
        [Required]
        public bool Status { get; set; }
        public bool Deleted { get; set; }

        public ICollection<PerformanceReview> PerformanceReviews { get; set; }
    }
}
