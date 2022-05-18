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

        [Route("profiles")]
        [HttpGet]
        public IEnumerable<string> GetProfiles()
        {
            return _manager.GetAllProfiles();
        }

        [Route("profiles")]
        [HttpPost]
        public void Post([FromQuery]string profileName)
        {
            _manager.AddProfile(profileName);
        }

        [Route("profiles/genres")]
        [HttpGet]
        public IEnumerable<GenreColour> GetGenreColours([FromQuery] string profileName)
        {
            return _manager.GetAllGenreColours(profileName);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("update/profile")]
        [HttpPut]
        public ActionResult<string> PutActiveProfile([FromQuery] string profileName)
        {
            string currentlySetProfile = _manager.SetActualProfile(profileName);
            return Ok(currentlySetProfile);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("update/genre")]
        [HttpPut]
        public ActionResult<string> PutActiveGenre([FromQuery] int id)
        {
            string currentlySetGenre = _manager.SetActualGenre(id);
            return Ok(currentlySetGenre);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut]
        public ActionResult<GenreColour> Put([FromQuery] string updatedGenreColour)
        {
            GenreColour result = _manager.UpdateGenreColour(updatedGenreColour);
            if (result == null) return NotFound("No such item, id:");
            return Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("")]
        [HttpDelete]
        public ActionResult Delete([FromQuery] string profileName)
        {
            bool result = _manager.DeleteProfile(profileName);
            if (result == false) return NotFound("No profile found with that name");
            return Ok((result));
        }

        [Route("profiles/genres/colours")]
        [HttpGet]
        public string GetColour([FromQuery] string profileName, [FromQuery] string genre)
        {
            return _manager.GetGenreColourByGenre(profileName, genre).Colour;
        }

        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[HttpGet]
        //public ActionResult<IEnumerable<GenreColour>> Get([FromQuery] int id, [FromQuery] string genre, [FromQuery] string colour)
        //{
        //    IEnumerable<GenreColour> genreColours = _manager.GetAllGenreColours(id, genre, colour);
        //    if (!genreColours.Any()) return NotFound("No genres found. Please add some");

        //    return Ok(genreColours);
        //}

        //// GET api/<ColourController>/5
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[HttpGet("{id}")]
        //public ActionResult<GenreColour> Get(int id)
        //{
        //    GenreColour result = _manager.GetById(id);
        //    if (result == null) return NotFound("No such item, id: " + id);
        //    return Ok(_manager.GetById(id));
        //}

        //// POST api/<ColourController>
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[HttpPost]
        //public ActionResult<GenreColour> Post([FromBody] GenreColour newGenreColour)
        //{
        //    if (newGenreColour.Genre == null || newGenreColour.Colour == null) return BadRequest(newGenreColour);

        //    GenreColour genreColour = new GenreColour();
        //    genreColour = _manager.Add(newGenreColour);

        //    return Created("api/GenreColours/" + genreColour.Id, genreColour);
        //}

        //// PUT api/<ColourController>/5
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[HttpPut]
        //public ActionResult<GenreColour> Put([FromBody] string updatedGenreColour)
        //{
        //    GenreColour result = _manager.Update(updatedGenreColour);
        //    if (result == null) return NotFound("No such item, id:");
        //    return Ok(result);
        //}

        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[HttpPut("update")]
        //public ActionResult<string> PutActiveGenre([FromBody] int id)
        //{
        //    string currentlySetGenre = _manager.SetActualGenre(id);
        //    return Ok(currentlySetGenre);
        //}
        ////putactivegenre før put

        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[HttpDelete("{id}")]
        //public ActionResult<GenreColour> Delete(int id)
        //{
        //    GenreColour result = _manager.Delete(id);
        //    if (result == null) return NotFound("No such item, id: " + id);
        //    return Ok(result);
        //}
    }
}