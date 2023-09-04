using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_Studies.Models;
using WebAPI_Studies.Services;

namespace WebAPI_Studies.Controllers
{
    [Route("api/v1/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly TokenService _tokenService;

        public AuthController(TokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost]
        public IActionResult Auth(string username, string password)
        {
            //TODO Criar a rota para buscar no banco

            if(username == "test" || password == "test")
            {
                var token = _tokenService.GenerateToken(new EmployeeModel(1, "jonas", 25, "Storage\\maxresdefault.png"));
                return Ok(token);
            }

            return BadRequest("Username or Passowrd Incorrect");
        }
    }
}
