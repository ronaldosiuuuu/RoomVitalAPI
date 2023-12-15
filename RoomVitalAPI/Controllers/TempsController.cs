using Microsoft.AspNetCore.Mvc;
using RoomVitalLib.Model;
using RoomVitalLib.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RoomVitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TempsController : ControllerBase
    {

        //private AdvarselRepository _AdvarselRepo;
        //private LokaleRepository _LokaleRepo;
        private SensorRepository _SensorRepo;

        public TempsController(SensorRepository sensorRepo)
        {
            _SensorRepo = sensorRepo;
        }
        //// GET: api/<RoomsController>
        //[HttpGet]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //public IActionResult Get()
        //{
        //    List<Lokale> _item = _LokaleRepo.GetAll();
        //    if(_item.ToList().Count == 0)
        //    {
        //        return NoContent();
        //    }
        //    return Ok();
        //}

        //// GET api/<RoomsController>/5
        //[HttpGet]
        //[Route("{id}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public IActionResult Get(int id)
        //{
        //    try
        //    {
        //        Lokale lokale = _LokaleRepo.GetById(id);
        //        if(lokale != null)
        //        {
        //            return Ok(lokale);
        //        }
        //        return NotFound();
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(500, "Fejl");
        //    }
        //}

        //// POST api/<RoomsController>
        //[HttpPost]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public IActionResult Post([FromBody] Lokale value)
        //{
        //    try
        //    {
        //        value.Validation();
        //        Lokale lokale = _LokaleRepo.Create(value);
        //        return Created($"api/rooms/{lokale.Id}", lokale);
        //    }
        //    catch(ArgumentOutOfRangeException ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(500, "Fejl");
        //    }
        //}

        //// PUT api/<RoomsController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<RoomsController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}

        [HttpGet("temperatur")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<int> GetCurrentTemperatur()
        {
            return Ok(_SensorRepo.GetCurrentTemperatur());
        }


        [HttpPut("temperatur")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult UpdateTemperaturTest([FromBody] int temperatur)
        {
            try
            {
                _SensorRepo.UpdateTemperatur(temperatur);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, "Fejl");
            }
        }

        [HttpGet("humidity")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<int> GetCurrentHumidity()
        {
            return Ok(_SensorRepo.GetCurrentHumidity());
        }

        [HttpPut("humidity")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult UpdateHumidity([FromBody] int humidity)
        {
            try
            {
                _SensorRepo.UpdateHumidity(humidity);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, "Fejl");
            }
        }



    }
}
