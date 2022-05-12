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
        private readonly ColourManager _manager = new ColourManager();
        //GET api/<ColourController>
        [EnableCors(Startup.AllowAllPolicy)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public ActionResult<IEnumerable<GenreColour>> Get([FromQuery] int id, [FromQuery] string genre, [FromQuery] string colour)
        {
            IEnumerable<GenreColour> genreColours = _manager.GetAll(id, genre, colour);
            if (!genreColours.Any()) return NotFound("No genres found. Please add some");

            return Ok(genreColours);
        }

        // GET api/<ColourController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public ActionResult<GenreColour> Get(int id)
        {
            GenreColour result = _manager.GetById(id);
            if (result == null) return NotFound("No such item, id: " + id);
            return Ok(_manager.GetById(id));
        }

        // POST api/<ColourController>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult<GenreColour> Post([FromBody] GenreColour newGenreColour)
        {
            if (/*newGenreColour.Genre == null ||*/ newGenreColour.Colour == null) return BadRequest(newGenreColour);

            GenreColour genreColour = new GenreColour();
            genreColour = _manager.Add(newGenreColour);

            return Created("api/GenreColours/" + genreColour.Id, genreColour);
        }

        // PUT api/<ColourController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public ActionResult<GenreColour> Put(int id, [FromBody] GenreColour updatedGenreColour)
        {
            GenreColour result = _manager.Update(id, updatedGenreColour);
            if (result == null) return NotFound("No such item, id: " + id);
            return Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //[EnableCors(Startup.AllowOnlyZealandOriginPolicyName)]
        [HttpDelete("{id}")]
        public ActionResult<GenreColour> Delete(int id)
        {
            GenreColour result = _manager.Delete(id);
            if (result == null) return NotFound("No such item, id: " + id);
            return Ok(result);
        }
    }
}

// Gammel kode

//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ColourController : ControllerBase
//    {
//        private ColourManager _manager = new ColourManager();
//        [ProducesResponseType(StatusCodes.Status200OK)]
//        [ProducesResponseType(StatusCodes.Status204NoContent)]
//        [HttpGet]   
//        public ActionResult<IEnumerable<SensorData>> Get()
//        {
//            IEnumerable<SensorData> result = _manager.GetAll();
//            if (result.Count() > 0)
//            {
//                return Ok(result);

//            }

//            return NoContent();
//        }

//        [ProducesResponseType(StatusCodes.Status200OK)]
//        [ProducesResponseType(StatusCodes.Status204NoContent)]
//        [HttpGet("Colour")]
//        public ActionResult<IEnumerable<string>> GetUniqueColours()
//        {
//            IEnumerable<string> result = _manager.GetAllUniqueColours();
//            if (result.Count() > 0)
//            {
//                return Ok(result);
//            }

//            return NoContent();

//        }
//        [ProducesResponseType(StatusCodes.Status200OK)]
//        [ProducesResponseType(StatusCodes.Status404NotFound)]
//        [HttpGet ("{id}")]
//        public ActionResult<SensorData> Get(int id)
//        {
//            SensorData result = _manager.GetById(id);
//            if (result == null) return NotFound("No such item, id: " + id);
//            return Ok(result);
//        }

//        [ProducesResponseType(StatusCodes.Status201Created)]
//        [HttpPost]

//        public ActionResult<SensorData> Post([FromBody] SensorData newSensorData)
//        {
//            SensorData result = _manager.AddSensorData(newSensorData);
//            return Created($"/api/Colour/{result.Id}", result);
//        }

//        [ProducesResponseType(StatusCodes.Status200OK)]
//        [ProducesResponseType(StatusCodes.Status404NotFound)]
//        [HttpPut("{id}")]
//        public ActionResult<SensorData> Put(int id, [FromBody] SensorData updatedsensorData)
//        {
//            SensorData result = _manager.UpdateSensorData(id, updatedsensorData);
//            if (result == null) return NotFound("No such item, id: " + id);
//            return Ok(result);
//        }
//        [ProducesResponseType(StatusCodes.Status200OK)]
//        [ProducesResponseType(StatusCodes.Status404NotFound)]
//        //[EnableCors(Startup.AllowOnlyZealandOriginPolicyName)]
//        [HttpDelete("{id}")]
//        public ActionResult<SensorData> Delete(int id)
//        {
//            SensorData result = _manager.Delete(id);
//            if (result == null) return NotFound("No such item, id: " + id);
//            return Ok(result);
//        }


//    }
//}