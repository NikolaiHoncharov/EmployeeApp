using EmployeeApp.Services.EmployeeAPI.Models.Dto;
using EmployeeApp.Services.EmployeeAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApp.Services.EmployeeAPI.Controllers
{
    [Route("api/employees")]
    public class EmployeeAPIController : Controller
    {
        protected ResponseDto _response;
        private IEmployeeRepository _employeeRepository;

        public EmployeeAPIController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
            this._response = new ResponseDto();
        }
        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<EmployeeDto> employeeDtos = await _employeeRepository.GetEmployees();
                _response.Result = employeeDtos;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<object> Get(int id)
        {
            try
            {
                EmployeeDto employeeDto = await _employeeRepository.GetEmployeeById(id);
                _response.Result = employeeDto;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }


        [HttpPost]
        public async Task<object> Post([FromBody] EmployeeDto employeeDto)
        {
            try
            {
                EmployeeDto model = await _employeeRepository.CreateUpdateEmployee(employeeDto);
                _response.Result = model;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }


        [HttpPut]
        public async Task<object> Put([FromBody] EmployeeDto employeeDto)
        {
            try
            {
                EmployeeDto model = await _employeeRepository.CreateUpdateEmployee(employeeDto);
                _response.Result = model;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<object> Delete(int id)
        {
            try
            {
                bool isSuccess = await _employeeRepository.DeleteEmployee(id);
                _response.Result = isSuccess;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }
    }
}
