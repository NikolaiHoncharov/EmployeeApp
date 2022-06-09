using AutoMapper;
using EmployeeApp.Services.EmployeeAPI.DbContexts;
using EmployeeApp.Services.EmployeeAPI.Models;
using EmployeeApp.Services.EmployeeAPI.Models.Dto;
using EmployeeApp.Services.EmployeeAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApp.Services.EmployeeAPI.Repository
{
    public class PositionRepository : IPositionRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public PositionRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }


        public async Task<PositionDto> CreateUpdatePosition(PositionDto positionDto)
        {
            Position position = _mapper.Map<PositionDto, Position>(positionDto);
            if (position.PositionId > 0)
            {
                _db.Positions.Update(position);
            }
            else
            {
                _db.Positions.Add(position);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<Position, PositionDto>(position);
        }

        public async Task<bool> DeletePosition(int positionId)
        {
            try
            {
                Position position = await _db.Positions.FirstOrDefaultAsync(u => u.PositionId == positionId);
                if (position == null)
                {
                    return false;
                }
                _db.Positions.Remove(position);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<PositionDto> GetPositionById(int positionId)
        {
            Position position = await _db.Positions.Where(x => x.PositionId == positionId).FirstOrDefaultAsync();
            return _mapper.Map<PositionDto>(position);
        }

        public async Task<IEnumerable<PositionDto>> GetPositions()
        {
            List<Position> positionsList = await _db.Positions.ToListAsync();
            return _mapper.Map<List<PositionDto>>(positionsList);
        }
    }
}
