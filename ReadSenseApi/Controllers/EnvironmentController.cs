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
    public class EnvironmentController(IEnvironmentService environmentService) : ControllerBase
    {
        public readonly IEnvironmentService _environmentService = environmentService;

        // GET: api/<EnvironmentController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_environmentService.GetAll());
        }

        // GET api/<EnvironmentController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return _environmentService.GetById(id) == null ? NotFound() : Ok(_environmentService.GetById(id));
        }

        // POST api/<EnvironmentController>
        [HttpPost]
        public IActionResult Post([FromBody] EnvironmentRequest environmentRequest)
        {
            if (environmentRequest == null)
                return BadRequest(new { message = "EnvironmentRequest Cannot be Empty" });

            HttpContext.Items.TryGetValue("User", out Object? userObj);
            HttpContext.Items.TryGetValue("DeviceId", out Object? deviceId);

            if (userObj == null || deviceId == null)
                return BadRequest(new { message = "User or DeviceId is incorrect" });
            
            User user = (User)userObj;
            
            var environment = _environmentService.Insert(environmentRequest, user.Id, (int)deviceId);

            return Ok(environment);
        }

        // PUT api/<EnvironmentController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string value)
        {
            return StatusCode(501);
        }

        // DELETE api/<EnvironmentController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return StatusCode(501);
        }
    }
}
