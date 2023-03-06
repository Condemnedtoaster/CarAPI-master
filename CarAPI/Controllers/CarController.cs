using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using CarAPI.Models;
using CarAPI.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarAPI.Controllers
{
    [EnableCors("AllowAll")]
    [Route("api/[controller]")]
    //URI: api/car
    [ApiController]
    public class CarController : ControllerBase
    {
        private ICarRepository _repository;

        public CarController(ICarRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Car?minlevel=1&namefilter=har
        [HttpGet]
        public ActionResult<IEnumerable<Car>> GetAll(
            [FromHeader] int? amount,
            [FromQuery] string? namefilter, 
            [FromQuery] int? minlevel)
        {
            List<Car> result = _repository.GetAll(amount,namefilter);
            if (result.Count < 1)
            {
                return NoContent(); // NotFound er også ok
            }
            Response.Headers.Add("TotalAmount", "" + result.Count());
            return Ok(result);
        }

        // GET api/Car/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public ActionResult<Car> Get(int id)
        {
            Car? foundCar = _repository.GetByID(id);
            if (foundCar == null)
            {
                return NotFound();
            }
            return Ok(foundCar);
        }

        // POST api/<CarController>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult<Car> Post([FromBody] Car newCar)
        {
            try
            {
                Car createdCar = _repository.Add(newCar);
                return Created($"api/Car/{createdCar.Id}", createdCar);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<CarController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public ActionResult<Car> Put(int id, [FromBody] Car updates)
        {
            try
            {
                Car? updatedCar = _repository.Update(id, updates);
                if (updatedCar == null)
                {
                    return NotFound();
                }
                return Ok(updatedCar);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<CarController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public ActionResult<Car> Delete(int id)
        {
            Car? deletedCar = _repository.Delete(id);
            if (deletedCar == null)
            {
                return NotFound();
            }
            return Ok(deletedCar);
        }
    }
}
