using Microsoft.AspNetCore.Mvc;
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


        public EmployeeController(ILogger<EmployeeController> logger, IEmployeeService employeeService)
        {
            _logger = logger;
            _employeeService = employeeService;
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
