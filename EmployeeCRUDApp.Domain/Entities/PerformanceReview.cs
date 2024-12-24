using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeCRUDApp.Domain.Entities
{
    [Table("PerformanceReview", Schema = "Hr")]
    public class PerformanceReview
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; } = new Employee();
        [Required]
        public DateTime ReviewDate { get; set; }
        [Required]
        [MinLength(1)]
        [MaxLength(10)]
        public int ReviewScore { get; set; }
        [Required]
        public string ReviewNotes { get; set; } = string.Empty;
        public bool Deleted { get; set; }
    }
}
