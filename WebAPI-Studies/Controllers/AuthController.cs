using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_Studies.Application.Services;
using WebAPI_Studies.Domain.Model;

namespace WebAPI_Studies.Controllers
{
    [Route("api/v1/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly TokenService _tokenService;
        private readonly IUserRepository _userRepository;

        public AuthController(TokenService tokenService, IUserRepository userRepository)
        {
            _tokenService = tokenService;
            _userRepository = userRepository;
        }

        [HttpPost]
        public IActionResult Auth(string username, string password)
        {
            //TODO Criar a rota para buscar no banco
            var user = _userRepository.GetByUserNameAndPassWord(username, password);


            if(user != null)
            {
                var token = _tokenService.GenerateToken(user);
                return Ok(token);
            }

            return BadRequest("Username or Passowrd Incorrect");
        }
    }
}
