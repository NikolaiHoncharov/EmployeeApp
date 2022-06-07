using EmployeeApp.Web.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp.Web.Services
{
    public class BaseService
    {
        public ResponseDto responseModel { get; set; }
        public IHttpClientFactory httpClient { get; set; }

        public BaseService(IHttpClientFactory httpClient)
        {
            this.responseModel = new ResponseDto();
            this.httpClient = httpClient;
        }

        public async Task<T> SendAsync<T>(ApiRequest apiRequest, HttpMethod Method)
        {
            try
            {
                var client = httpClient.CreateClient("EmpoyeeApp");
                HttpRequestMessage message = new HttpRequestMessage();
                message.Headers.Add("Accept", "application/json");
                message.RequestUri = new Uri(apiRequest.Url);
                client.DefaultRequestHeaders.Clear();
                if (apiRequest.Data != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data),
                        Encoding.UTF8, "application/json");
                }

                HttpResponseMessage apiResponse = null;

                message.Method = Method;
                
                apiResponse = await client.SendAsync(message);

                var apiContent = await apiResponse.Content.ReadAsStringAsync();
                var apiResponseDto = JsonConvert.DeserializeObject<T>(apiContent);
                return apiResponseDto;

            }
            catch (Exception e)
            {
                var dto = new ResponseDto
                {
                    DisplayMessage = "Error",
                    ErrorMessages = new List<string> { Convert.ToString(e.Message) },
                    IsSuccess = false
                };
                var res = JsonConvert.SerializeObject(dto);
                var apiResponseDto = JsonConvert.DeserializeObject<T>(res);
                return apiResponseDto;
            }
        }

    }
}
