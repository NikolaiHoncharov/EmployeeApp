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
            List<Employee> employeesList = await _db.Employees.ToListAsync();
            return _mapper.Map<List<EmployeeDto>>(employeesList);
        }

        public async Task<EmployeeDto> GetEmployeeById(int employeeId)
        {
            Employee employee = await _db.Employees.Where(x => x.EmployeeId == employeeId).FirstOrDefaultAsync();
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

        
        public async Task<EmployeeDto> CreateUpdateEmployee(EmployeeDto employeeDto)
        {
            Employee employee = _mapper.Map<EmployeeDto, Employee>(employeeDto);
            string status = "";
            string message = "";
            if (employee.RegularOrExternal == true && employee.PersonnelNumber != null)
            {
                status = "no valid";
            }
            else
            {
                try
                {
                    if (employee.EmployeeId > 0)
                    {
                        _db.Employees.Update(employee);
                        status = "update";
                    }
                    else
                    {
                        _db.Employees.Add(employee);
                        status = "add new";
                    }
                    await _db.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    status = "error";
                    message = ex.Message;
                }
            }
            EmployeeDto temp = _mapper.Map<Employee, EmployeeDto>(employee);
            temp.Status = status;
            temp.ErrorMessage = message;
            return temp;
        }

        public async Task<IEnumerable<EmployeeDto>> CreateUpdateListEmployee(IEnumerable<EmployeeDto> employeeDtos)
        {
            List<EmployeeDto> TempemployeeDtos = new List<EmployeeDto>();
            foreach (var employeeDto in employeeDtos)
            {
                EmployeeDto temp = await CreateUpdateEmployee(employeeDto);
                TempemployeeDtos.Add(temp);
            }
            return TempemployeeDtos;
        }

    }
}
