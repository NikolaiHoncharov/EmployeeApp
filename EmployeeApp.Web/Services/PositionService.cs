using EmployeeApp.Web.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace EmployeeApp.Web.Services
{
    public class PositionService: BaseService, IPositionService
    {
        private readonly IHttpClientFactory _clientFactory;

        string _url = "https://localhost:7138";

        public PositionService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<T> CreatePositionAsync<T>(PositionDto positionDto)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                Data = positionDto,
                Url = _url + "/api/positions"
            }, HttpMethod.Post);
        }

        public async Task<T> DeletePositionAsync<T>(int id)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                Url = _url + "/api/positions/" + id
            }, HttpMethod.Delete);
        }

        public async Task<T> GetAllPositionAsync<T>()
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                Url = _url + "/api/positions"
            }, HttpMethod.Get);
        }

        public async Task<T> GetPositionByIdAsync<T>(int id)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                Url = _url + "/api/positions/" + id
            }, HttpMethod.Get);
        }

        public async Task<T> UpdatePositionAsync<T>(PositionDto positionDto)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                Data = positionDto,
                Url = _url + "/api/positions"
            }, HttpMethod.Put);
        }
    }
}
