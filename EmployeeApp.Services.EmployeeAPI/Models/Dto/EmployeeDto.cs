namespace EmployeeApp.Services.EmployeeAPI.Models.Dto
{
    public class EmployeeDto
    {
        public int EmployeeId { get; set; }
        public int? PersonnelNumber { get; set; }
        public string FIO { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool RegularOrExternal { get; set; }
        public int PositionId { get; set; }
        public Position Position { get; set; }
    }
}
