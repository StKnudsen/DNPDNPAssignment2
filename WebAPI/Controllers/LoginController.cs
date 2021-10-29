using System.Threading.Tasks;
using FileData.Data;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }
        
        [HttpGet]
        public async Task<ActionResult<User>> ValidateUserAsync(
            [FromQuery] string userName, [FromQuery] string passWord)
        {
            User user = await _userService.ValidateUserAsync(userName, passWord);
            return Ok(user);
        }
    }
}