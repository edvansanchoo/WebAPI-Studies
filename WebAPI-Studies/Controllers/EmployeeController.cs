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
            _employeeRepository = employeeRepository ?? throw new Exception("Fail Injection Employee Repository");
        }

        [HttpPost]
        public IActionResult Add([FromForm] EmployeeViewModel employeeViewModel)
        {
            var filePath = Path.Combine("Storage", employeeViewModel.Photo.FileName);

            using Stream fileStream = new FileStream(filePath, FileMode.Create);
            employeeViewModel.Photo.CopyTo(fileStream);

            var employee = new EmployeeModel(employeeViewModel.Name, employeeViewModel.Age, filePath);
            _employeeRepository.Add(employee);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_employeeRepository.GetAll());
        }

        [HttpPost]
        [Route("{id}/download")]
        public IActionResult DownloadPhoto(int id) 
        {
            var employee = _employeeRepository.GetById(id);
            if(employee == null)
            {
                return this.NotFound($" Could not find User: {id}");
            }

            try
            {
                var dataBytes = System.IO.File.ReadAllBytes(employee.photo);
                return File(dataBytes, "image/png");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }

}
