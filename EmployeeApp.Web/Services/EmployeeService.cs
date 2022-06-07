using EmployeeApp.Web.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace EmployeeApp.Web.Services
{
    public class EmployeeService : BaseService, IEmployeeService
    {
        private readonly IHttpClientFactory _clientFactory;

        string _url = "https://localhost:7138";

        public EmployeeService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<T> CreateEmployeeAsync<T>(EmployeeDto employeeDto)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                Data = employeeDto,
                Url = _url + "/api/employees"
            }, HttpMethod.Post);
        }

        public async Task<T> DeleteEmployeeAsync<T>(int id)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                Url = _url + "/api/employees/" + id
            }, HttpMethod.Delete);
        }

        public async Task<T> GetAllEmployeeAsync<T>()
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                Url = _url + "/api/employees"
            }, HttpMethod.Get);
        }

        public async Task<T> GetEmployeeByIdAsync<T>(int id)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                Url = _url + "/api/employees/" + id
            }, HttpMethod.Get);
        }

        public async Task<T> UpdateEmployeeAsync<T>(EmployeeDto employeeDto)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                Data = employeeDto,
                Url = _url + "/api/employees"
            }, HttpMethod.Put);
        }
    }
}
