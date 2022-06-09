using EmployeeApp.Services.EmployeeAPI.Models.Dto;
using EmployeeApp.Services.EmployeeAPI.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApp.Services.EmployeeAPI.Controllers
{
    [Route("api/employees")]
    public class EmployeeAPIController : Controller
    {
        private IEmployeeRepository _employeeRepository;

        public EmployeeAPIController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<EmployeeDto>> Get() => await _employeeRepository.GetEmployees();
       
        [HttpGet]
        [Route("{id}")]
        public async Task<EmployeeDto> Get(int id) => await _employeeRepository.GetEmployeeById(id);
       
        [HttpPost]
        public async Task<IEnumerable<EmployeeDto>> Post([FromBody] IEnumerable<EmployeeDto> employeeDtos) =>
            await _employeeRepository.CreateUpdateListEmployee(employeeDtos);

        [HttpPut]
        public async Task<EmployeeDto> Put([FromBody] EmployeeDto employeeDto) => 
            await _employeeRepository.CreateUpdateEmployee(employeeDto);
       
        [HttpDelete]
        [Route("{id}")]
        public async Task<bool> Delete(int id) => await _employeeRepository.DeleteEmployee(id);
        
    }
}
