using BookingSystemWebAPI.Models.DTOS;
using BookingSystemWebAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookingSystemWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;

        public AuthController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDTO userRegisterDTO)
        {
            var response = await _authRepository.Register(
                new Models.Entities.User { UserName = userRegisterDTO.UserName }, userRegisterDTO.Password
                );

            if (!response.Success)
            {
                return BadRequest(response.ErrorMessage);
            }

            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDTO userLoginDTO)
        {
            var response = _authRepository.Login(userLoginDTO.Username, userLoginDTO.Password);

            if (!response.Success)
            {
                return BadRequest(response.ErrorMessage);
            }

            return Ok(response);
        }
    }
}