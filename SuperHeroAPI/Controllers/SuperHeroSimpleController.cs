using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.Models;
using SuperHeroAPI.Services;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHerosimpleController : ControllerBase
    {
        private readonly ISuperHeroSimpleService _heroSimpleService;
        public SuperHerosimpleController(ISuperHeroSimpleService superHeroService)
        {
            _heroSimpleService = superHeroService;
        }
       



        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeros()
        {
            return _heroSimpleService.GetAllHeros();
            
        }
        [HttpGet("{id}")]

        public async Task<ActionResult<SuperHero>> GetSingleHero(int id)
        {
            var result = _heroSimpleService.GetSingleHero(id);
            if (result is null)
            {
                return NotFound("Hero is not Found");
            }
            return Ok(result);

        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> CreateHero(SuperHero superHero)
        {

            var result = _heroSimpleService.CreateHero(superHero);
            if (result is null)
            {
                return NotFound("Hero is not Found");
            }
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<SuperHero>> UpdateHero(int id, SuperHero superHero)
        {
            var result = _heroSimpleService.UpdateHero(id, superHero );
            if (result is null)
            {
                return NotFound("Hero is not Found");
            }
            return Ok(result);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<SuperHero>> DeleteHero(int id)
        {
            var result = _heroSimpleService.DeleteHero(id);
            if (result is null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
