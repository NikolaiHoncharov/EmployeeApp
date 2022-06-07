using EmployeeApp.Web.Models;
using System.Threading.Tasks;

namespace EmployeeApp.Web.Services
{
    public interface IEmployeeService
    {
        Task<T> GetAllEmployeeAsync<T>();
        Task<T> GetEmployeeByIdAsync<T>(int id);
        Task<T> CreateEmployeeAsync<T>(EmployeeDto employeeDto);
        Task<T> UpdateEmployeeAsync<T>(EmployeeDto employeeDto);
        Task<T> DeleteEmployeeAsync<T>(int id);
    }
}
