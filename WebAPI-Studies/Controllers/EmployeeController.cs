using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_Studies.Model;
using WebAPI_Studies.Models;
using WebAPI_Studies.ViewModel;

namespace WebAPI_Studies.Controllers
{
    [Route("api/v1/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException();
        }

        [HttpPost]
        public IActionResult Add(EmployeeViewModel employeeViewModel)
        {
            var employee = new EmployeeModel(employeeViewModel.Name, employeeViewModel.Age, null);
            _employeeRepository.Add(employee);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_employeeRepository.GetAll());
        }
    }
}
