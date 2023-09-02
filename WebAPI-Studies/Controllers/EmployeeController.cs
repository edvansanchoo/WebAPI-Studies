using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_Studies.Models;

namespace WebAPI_Studies.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<EmployeeModel>> GetAllEmployees() 
        {
            return Ok(new List<EmployeeModel>() {new EmployeeModel("jonas", 15, "local/teste.txt"), new EmployeeModel("Marcos", 25, "local/teste1.txt") });
        }
    }
}
