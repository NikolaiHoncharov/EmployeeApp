using AutoMapper;
using EmployeeApp.Services.EmployeeAPI.DbContexts;
using EmployeeApp.Services.EmployeeAPI.Models;
using EmployeeApp.Services.EmployeeAPI.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApp.Services.EmployeeAPI.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public EmployeeRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EmployeeDto>> GetEmployees()
        {
            List<Employee> employeesList = await _db.Employees.Include("Position").ToListAsync();
            return _mapper.Map<List<EmployeeDto>>(employeesList);
        }

        public async Task<EmployeeDto> GetEmployeeById(int employeeId)
        {
            Employee employee = await _db.Employees.Where(x => x.EmployeeId == employeeId).Include("Position").FirstOrDefaultAsync();
            return _mapper.Map<EmployeeDto>(employee);
        }

        public async Task<bool> DeleteEmployee(int employeeId)
        {
            try
            {
                Employee employee = await _db.Employees.FirstOrDefaultAsync(u => u.EmployeeId == employeeId);
                if (employee == null)
                {
                    return false;
                }
                _db.Employees.Remove(employee);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        ///в тз есть условие переделай 
        public async Task<EmployeeDto> CreateUpdateEmployee(EmployeeDto employeeDto)
        {
            Employee employee = _mapper.Map<EmployeeDto, Employee>(employeeDto);
            if (employee.EmployeeId > 0)
            {
                _db.Employees.Update(employee);
            }
            else
            {
                _db.Employees.Add(employee);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<Employee, EmployeeDto>(employee);
        }
    }
}
