using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReadSenseApi.Database;
using ReadSenseApi.Models;
using ReadSenseApi.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReadSenseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DataDownloadsController : ControllerBase
    {
        private readonly IDataDownloadService dataDownloadService;

        public DataDownloadsController(IDataDownloadService dataDownloadService)
        {
            this.dataDownloadService = dataDownloadService;
        }

        // GET: api/<ValuesController>
        [HttpGet("userdata")]
        [ProducesResponseType(typeof(UserDataResponse), StatusCodes.Status200OK)]
        public IActionResult GetUserData()
        {
            var data = dataDownloadService.GetUserData();

            return Ok(data);
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string GetUserData(int id)
        {
            return "value";
        }

        
    }
}
