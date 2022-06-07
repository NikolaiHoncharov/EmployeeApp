using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeApp.Services.EmployeeAPI.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public int? PersonnelNumber { get; set; }
        [Required]
        public string FIO { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool RegularOrExternal { get; set; }
        public int PositionId { get; set; }
        [ForeignKey("PositionId")]
        public virtual Position Position { get; set; }
    }
}
