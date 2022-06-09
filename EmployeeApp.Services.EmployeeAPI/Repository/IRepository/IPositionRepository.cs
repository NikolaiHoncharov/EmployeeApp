using EmployeeApp.Services.EmployeeAPI.Models.Dto;

namespace EmployeeApp.Services.EmployeeAPI.Repository.IRepository
{
    public interface IPositionRepository
    {
        Task<IEnumerable<PositionDto>> GetPositions();
        Task<PositionDto> GetPositionById(int positionDtoId);
        Task<PositionDto> CreateUpdatePosition(PositionDto positionDto);
        Task<bool> DeletePosition(int positionDtoId);
    }
}
