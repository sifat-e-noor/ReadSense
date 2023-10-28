using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReadSenseApi.Database.Entities;
using ReadSenseApi.Models;
using ReadSenseApi.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReadSenseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            if (string.IsNullOrEmpty(model.Username))
                return BadRequest(new { message = "Username Cannot be Empty" });

            var response = _userService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }

        // GET: api/<UsersController>
        [HttpGet]
        public IActionResult Get()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user = _userService.GetById(id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        // POST api/<UsersController>
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            // return http response with status code 501 Not Implemented
            return StatusCode(501);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User user)
        {
            return StatusCode(501);
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return StatusCode(501);
        }

        // POST api/<UsersController>/agreement
        [HttpPost("agreement")]
        public IActionResult Agreement(AgreementRequest agreementSigned)
        {
            HttpContext.Items.TryGetValue("User", out Object? userObj);

            if (userObj == null)
            {
                return BadRequest(new { message = "User not found" });
            }

            User user = (User)userObj;

            if (!agreementSigned.AgreementSigned && user.AgreementSigned.GetValueOrDefault())
            {
                return BadRequest(new { message = "User are not allowed to change consent" });
            }
            else if ( agreementSigned.AgreementSigned == user.AgreementSigned.GetValueOrDefault())
            {
                return Ok();
            }

            _userService.UpdateAgreementSigned(user, agreementSigned.AgreementSigned);

            return Ok();
        }
    }
}
