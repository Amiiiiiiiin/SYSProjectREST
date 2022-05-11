using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using UDPLibrary;
using UDPREST.Managers;

namespace UDPREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColourController : ControllerBase
    {
        private ColourManager _manager = new ColourManager();
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet ("{id}")]
        public ActionResult<SensorData> Get(int id)
        {
            SensorData result = _manager.GetById(id);
            if (result == null) return NotFound("No such item, id: " + id);
            return Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]
        
        public ActionResult<SensorData> Post([FromBody] SensorData newSensorData)
        {
            SensorData result = _manager.AddSensorData(newSensorData);
            return Created($"/api/Colour/{result.Id}", result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public ActionResult<SensorData> Put(int id, [FromBody] SensorData updatedsensorData)
        {
            SensorData result = _manager.UpdateSensorData(id, updatedsensorData);
            if (result == null) return NotFound("No such item, id: " + id);
            return Ok(result);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //[EnableCors(Startup.AllowOnlyZealandOriginPolicyName)]
        [HttpDelete("{id}")]
        public ActionResult<SensorData> Delete(int id)
        {
            SensorData result = _manager.Delete(id);
            if (result == null) return NotFound("No such item, id: " + id);
            return Ok(result);
        }


    }
}