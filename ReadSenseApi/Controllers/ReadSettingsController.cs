using Microsoft.AspNetCore.Mvc;
using ReadSenseApi.Database.Entities;
using ReadSenseApi.Models;
using ReadSenseApi.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReadSenseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadSettingsController : ControllerBase
    {
        private readonly IReadSettingsService _readSettingsService;

        public ReadSettingsController(IReadSettingsService readSettingsService)
        {
            _readSettingsService = readSettingsService;
        }

        // GET: api/<ReadSettingsController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_readSettingsService.GetAll());
        }

        // GET api/<ReadSettingsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return _readSettingsService.GetById(id) == null ? NotFound() : Ok(_readSettingsService.GetById(id));
        }

        // POST api/<ReadSettingsController>
        [HttpPost]
        public IActionResult Post([FromBody] List<ReadSettingsEventRequest> readSettingsEventRequests)
        {
            if (readSettingsEventRequests == null || readSettingsEventRequests.Count == 0)
            {
                return BadRequest(new { message = "ReadSettingsEvent Requests Cannot be Empty" });
            }
                

            HttpContext.Items.TryGetValue("User", out Object? userObj);
            HttpContext.Items.TryGetValue("DeviceId", out Object? deviceId);

            if (userObj == null || deviceId == null)
            {
                return BadRequest(new { message = "User or DeviceId is incorrect" });
            }

            User user = (User)userObj;

            int state =  _readSettingsService.Insert(user.Id, (int)deviceId, readSettingsEventRequests);
            return Ok(state);
        }

        // PUT api/<ReadSettingsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string value)
        {
            return StatusCode(501);
        }

        // DELETE api/<ReadSettingsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return StatusCode(501);
        }
    }
}
