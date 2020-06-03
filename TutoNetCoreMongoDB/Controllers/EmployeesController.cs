using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TutoMongoDBNetCore.Core.Entities;
using TutoMongoDBNetCore.Core.Services;

namespace TutoMongoDBNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeService _employeeService;

        public EmployeesController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public ActionResult<List<Employee>> Get() =>
            _employeeService.Get();



        [HttpGet("{id:length(24)}", Name = "GetEmployee")]
        public ActionResult<Employee> Get(string id)
        {
            var emp = _employeeService.Get(id);

            if (emp == null)
            {
                return NotFound();
            }

            return emp;
        }
    }
}
