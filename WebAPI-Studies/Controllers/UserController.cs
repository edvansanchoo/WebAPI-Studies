using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_Studies.Model;
using WebAPI_Studies.ViewModel;

namespace WebAPI_Studies.Controllers
{
    [Route("api/v1/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_userRepository.GetAll());
        }

        [Authorize]
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _userRepository.GetById(id);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound($"User {id} Not Found");
        }

        [Authorize]
        [HttpPost]
        public IActionResult Save(UserViewModel userViewModel) {
            if (_userRepository.Add(userViewModel))
            {
                return Ok(userViewModel);

            }
            return BadRequest("Fail in Salving user");
        }

        [Authorize]
        [HttpPut]
        public IActionResult Update(UserViewModel userViewModel)
        {
            if (_userRepository.Edit(userViewModel))
            {
                return Ok(userViewModel);
            }
            return NotFound($"User Not Found");

        }

        [HttpDelete]
        public IActionResult Delete(int id) 
        { 
            if(_userRepository.Delete(id)) 
            {
                return Ok("User Deleted");
            }
            return NotFound($"User {id} Not Found");
        }
    }
}
