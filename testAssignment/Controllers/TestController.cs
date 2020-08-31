using Microsoft.AspNetCore.Mvc;
using testAssignment.Models;

namespace testAssignment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        private IRepository repository;

        public TestController(IRepository context)
        {
            repository = context;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var owners = repository.GetOwners((int)id);

            if (owners == null)
            {
                return NotFound();
            }

            return Ok(owners);
        }

        [HttpPost]
        public IActionResult Post(Owner owner)
        {

            if (owner.FirstName == null || owner.LastName == null)
            {
                BadRequest();
            }

            var cars = repository.GetCars(owner);

            if (cars == null)
            {
                return NotFound();
            }

            return Ok(cars);
        }
    }
}
