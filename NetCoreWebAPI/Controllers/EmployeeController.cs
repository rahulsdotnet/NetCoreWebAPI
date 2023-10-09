using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NetCoreWebAPI.Models;
using NetCoreWebAPI.Options;
using NetCoreWebAPI.Services;
using System.Net;

namespace NetCoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly ILogger<EmployeeController> _logger;

        private readonly IConfiguration _configuration;

        private readonly SmtpOptions _smtp;
        private readonly GroupOptions _group;

        public EmployeeController(ILogger<EmployeeController> logger, IEmployeeService employeeService, IConfiguration configuration,
            IOptions<SmtpOptions> smtp,
            IOptions<GroupOptions> group
            )
        {
            _logger = logger;
            _employeeService = employeeService;
            _configuration = configuration;


            //1. Read connectionstring

            var connectionString = _configuration.GetConnectionString("SQLConnection");

            //2. Read the key, value

            var myValue = _configuration["MyKey"];

            //3. Read the object property

            var server = _configuration["Smtp:Server"];

            //4. Read the section using Option pattern
            _smtp = smtp.Value;

            //5. Read the array of object using option pattern
            _group = group.Value;

        }

        [Route("emplyees")]
        [HttpGet]

        public IActionResult GetEmployees()
        {

            return Ok(_employeeService.GetEmployees());

        }

        [Route("{id}")]
        [HttpGet]
        public IActionResult GetEmployeesById(int id)
        {

            return Ok(_employeeService.GetEmployeeById(id));

        }

        [Route("create")]
        [HttpPost]
        public IActionResult CreateEmployee(Employee employee)
        {

            return Ok(_employeeService.CreateEmployee(employee));

        }
        [Route("update")]
        [HttpPost]
        public IActionResult UpdateEmployee(Employee employee)
        {

            return Ok(_employeeService.UpdateEmployee(employee));

        }
    }
}
