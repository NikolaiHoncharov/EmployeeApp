using EmployeeApp.Web.Models;
using System.Threading.Tasks;

namespace EmployeeApp.Web.Services
{
    public interface IPositionService
    {
        Task<T> GetAllPositionAsync<T>();
        Task<T> GetPositionByIdAsync<T>(int id);
        Task<T> CreatePositionAsync<T>(PositionDto positionDto);
        Task<T> UpdatePositionAsync<T>(PositionDto positionDto);
        Task<T> DeletePositionAsync<T>(int id);
    }
}
