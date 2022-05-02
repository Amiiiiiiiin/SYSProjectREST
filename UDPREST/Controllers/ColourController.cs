using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UDPLibrary;
using UDPREST.Managers;

namespace UDPREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColourController : ControllerBase
    {
        private ColourManager _manager = new ColourManager();

        [HttpGet]
        public ActionResult<IEnumerable<SensorData>> Get()
        {
            IEnumerable<SensorData> result = _manager.GetAll();
            if (result.Count() > 0)
            {
                return Ok(result);
            }
            else
            {
                return NoContent();
            }
        }
    }
}
