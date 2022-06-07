using EmployeeApp.Services.EmployeeAPI.Models.Dto;
using EmployeeApp.Services.EmployeeAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApp.Services.EmployeeAPI.Controllers
{
    [Route("api/positions")]
    public class PositionAPIController : Controller
    {
        protected ResponseDto _response;
        private IPositionRepository _positionRepository;

        public PositionAPIController(IPositionRepository positionRepository)
        {
            _positionRepository = positionRepository;
            this._response = new ResponseDto();
        }
        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<PositionDto> positionDtos = await _positionRepository.GetPositions();
                _response.Result = positionDtos;
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
                PositionDto positionDto = await _positionRepository.GetPositionById(id);
                _response.Result = positionDto;
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
        public async Task<object> Post([FromBody] PositionDto positionDto)
        {
            try
            {
                PositionDto model = await _positionRepository.CreateUpdatePosition(positionDto);
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
        public async Task<object> Put([FromBody] PositionDto positionDto)
        {
            try
            {
                PositionDto model = await _positionRepository.CreateUpdatePosition(positionDto);
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
                bool isSuccess = await _positionRepository.DeletePosition(id);
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
