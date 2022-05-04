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

            return NoContent();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet("Colour")]
        public ActionResult<IEnumerable<string>> GetUniqueColours()
        {
            IEnumerable<string> result = _manager.GetAllUniqueColours();
            if (result.Count() > 0)
            {
                return Ok(result);
            }

            return NoContent();
        }
    }
}
