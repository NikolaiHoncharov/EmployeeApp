using EmployeeApp.Web.Models;
using EmployeeApp.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IEmployeeService _employeeService;
        private readonly IPositionService _positionService;

        public HomeController(ILogger<HomeController> logger, IEmployeeService employeeService,
            IPositionService positionService)
        {
            _logger = logger;
            this._employeeService = employeeService;
            this._positionService = positionService;
        }

        public async Task<IActionResult> Index()
        {
            List<EmployeeDto> list = new List<EmployeeDto>();
            var response = await _employeeService.GetAllEmployeeAsync<ResponseDto>();
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<EmployeeDto>>(Convert.ToString(response.Result));
            }
            return View(list);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
