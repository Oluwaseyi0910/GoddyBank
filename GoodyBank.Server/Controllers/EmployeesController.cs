using GoodyBank.Server.Repository;
using GoodyBank.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GoodyBank.Server.Controllers
{
    //api/Employees
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        //api/Employees/AddEmployee
        [HttpPost]
        [Route("AddEmployee")]
        public async Task<IActionResult> AddEmployee(Employee employee)
        {
            
            var result = await _employeeRepository.AddEmployee(employee);
            return Ok(result);
        }

        [HttpPut]
        [Route("UpdateEmployee")]
        public async Task<IActionResult> UpdateEmployee(Employee employee)
        {
            var result = await _employeeRepository.UpdateEmployee(employee);
            return Ok(result);
        }
        //api/Employees/GetAllEmployees
        [HttpGet]
        [Route("GetAllEmployees")]
        public async Task<IActionResult> GetAllEmployees()
        {
            var result = await _employeeRepository.GetEmployee();
            return Ok(result);
        }

        [HttpGet]
        [Route("GetAllEmployeesByEmail")]
        public async Task<IActionResult> GetAllEmployeesByEmail(string email)
        {
            var result = await _employeeRepository.GetEmployeeByEmail(email);
            return Ok(result);
        }

        [HttpDelete]
        [Route("DeleteEmployee")]
        public async Task<IActionResult> DeleteEmployee(int employeeId)
        {
            await _employeeRepository.DeleteEmployee(employeeId);
            return Ok();
        }

    }




}
