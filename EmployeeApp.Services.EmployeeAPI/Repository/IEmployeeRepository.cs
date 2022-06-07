using EmployeeApp.Services.EmployeeAPI.Models.Dto;

namespace EmployeeApp.Services.EmployeeAPI.Repository
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<EmployeeDto>> GetEmployees();
        Task<EmployeeDto> GetEmployeeById(int employeeDtoId);
        Task<EmployeeDto> CreateUpdateEmployee(EmployeeDto employeeDto);
        Task<bool> DeleteEmployee(int employeeDtoId);
    }
}
