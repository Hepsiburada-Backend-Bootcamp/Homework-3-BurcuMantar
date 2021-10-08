using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Web.Dtos;
using Web.Interfaces;

namespace Web.Controllers
{
    [Route("api/v3/doctor")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly ILogger<DoctorController> _logger;
        private readonly IDoctorService _doctorService;

        public DoctorController(ILogger<DoctorController> logger, IDoctorService doctorService)
        {
            _logger = logger;
            _doctorService = doctorService;
        }

        //You can use the HttpGet request to take all drlist
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("User requested the DoctorController's Get method.");
            var result = await _doctorService.GetAll();
            return Ok(result);

        }

        //You can use this HttpGet request with id  to get just one dr object.
        //https://localhost:44392/api/v3/doctors/4
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            _logger.LogInformation("User requested the DoctorController's GetbyId method.");

            var result = await _doctorService.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        //You can use this HttpPost request to create new dr's object.
        //https://localhost:44392/api/v3/doctors
        [HttpPost]
        public IActionResult Add([FromBody] DoctorPostDto doctorDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data.");
            }
            var Result = _doctorService.Create(doctorDto);
            return CreatedAtAction("Get", new { Id = Result.Id }, doctorDto);

        }

        //You can use this HttpDelete request to delete dr's object already have with using unique id.
        //https://localhost:44392/api/v3/doctors/2
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _doctorService.Delete(id);
            return NoContent();
        }

        //You can use this HttpPut request to update dr's object already have with using unique id.
        //https://localhost:44392/api/v3/doctors/8
        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] DoctorUpdateDto doctorDto)
        {
            if (id != doctorDto.Id)
            {
                return BadRequest("Id information is not confirmed");
            }
            _doctorService.Update(doctorDto);
            return Ok();
        }
    }
}
