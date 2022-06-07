using System.ComponentModel.DataAnnotations;

namespace EmployeeApp.Services.EmployeeAPI.Models
{
    public class Position
    {
        [Key]
        public int PositionId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double BaseSalary { get; set; }
    }
}
