using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XUnitDemo.Repository;

namespace XUnitDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IPeopleRepository _peopleRepository;

        public PeopleController(IPeopleRepository peopleRepository)
        {
            this._peopleRepository = peopleRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var peoples = _peopleRepository.GetAll();

            if (!peoples.Any())
            {
                return NotFound();
            }

            return Ok(peoples);
        }
    }
}
