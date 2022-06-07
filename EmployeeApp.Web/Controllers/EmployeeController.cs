using EmployeeApp.Web.Models;
using EmployeeApp.Web.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ILogger<EmployeeController> _logger;
        IWebHostEnvironment _appEnvironment;

        private readonly IEmployeeService _employeeService;
        private readonly IPositionService _positionService;

        public EmployeeController(ILogger<EmployeeController> logger, IWebHostEnvironment appEnvironment, IEmployeeService employeeService,
            IPositionService positionService)
        {
            _logger = logger;
            _appEnvironment = appEnvironment;
            this._employeeService = employeeService;
            this._positionService = positionService;
        }

        public async Task<IActionResult> EmployeeCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddFile(IFormFile uploadedFile)
        {
            if (uploadedFile != null)
            {
                var result = new StringBuilder();
                using (var reader = new StreamReader(uploadedFile.OpenReadStream()))
                {
                    while (reader.Peek() >= 0)
                        result.AppendLine(await reader.ReadLineAsync());
                }
                var r = result;
            }
           
            return RedirectToAction("Home/Index");
        }


        public async Task<IActionResult> EmployeeDelete(int employeeId)
        {
            var response = await _employeeService.DeleteEmployeeAsync<ResponseDto>(employeeId);
            if (response != null && response.IsSuccess)
            {
                EmployeeDto model = JsonConvert.DeserializeObject<EmployeeDto>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }

    }
}
