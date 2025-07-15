using EmployeeLeavesManagement.Dto;
using EmployeeLeavesManagement.Manager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeLeavesManagement.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class employeesController : ControllerBase
    {
        private readonly IEmployeeManager _emloyeeleavesmanager;

        public employeesController (IEmployeeManager emloyeeleavesmanager)
        {
            _emloyeeleavesmanager = emloyeeleavesmanager;
        }

        [Authorize]
        [HttpPost]
        public IActionResult creatEmployees([FromBody] Employee employee)
        {
           _emloyeeleavesmanager.createEmployee(employee);

            return Ok("employee created Successfully");
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult getEmployeesById(int id)
        {
            var employeebyId =_emloyeeleavesmanager.getEmployeeById(id);
            return Ok(employeebyId);
        }
        [Authorize]
        [HttpGet]
        public IActionResult getAllEmployees()
        {
           var allEmployees = _emloyeeleavesmanager.Employee();
            return Ok(allEmployees);
        }
        [Authorize]
        [HttpPut("{id}")]
       public IActionResult updateEmployeeById(int id, Employee employee)
        {
            _emloyeeleavesmanager.updateEmployeeById(id, employee);

            return Ok("Update Empoyee ");
        }
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult deleteEmployeesById(int id)
        {
            _emloyeeleavesmanager.deleteEmployeeById(id);
            return Ok("delete employee ");
        }

    }
}
