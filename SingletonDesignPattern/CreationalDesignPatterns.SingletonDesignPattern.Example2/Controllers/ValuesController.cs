using CreationalDesignPatterns.SingletonDesignPattern.Example2.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CreationalDesignPatterns.SingletonDesignPattern.Example2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet("[action]")]
        public IActionResult X()
        {
            DatabaseService databaseService = DatabaseService.GetInstance;
            databaseService.Connection();
            databaseService.Disconnect();
            return Ok(databaseService);
        }

        [HttpGet("[action]")]
        public IActionResult Y()
        {
            DatabaseService databaseService = DatabaseService.GetInstance;
            databaseService.Connection();
            databaseService.Disconnect();
            return Ok(databaseService);
        }
    }
}
