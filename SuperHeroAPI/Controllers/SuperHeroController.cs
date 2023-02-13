using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.Data;
using SuperHeroAPI.Models;
using SuperHeroAPI.Services;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        
        private readonly ISuperHeroService _heroService;
        public SuperHeroController(ISuperHeroService superHeroService)
        {
           
            _heroService = superHeroService;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeros()
        {


            return await _heroService.GetAllHeros();  //response status 200
        }
        [HttpGet("{id}")]

        public async Task<ActionResult<SuperHero>> GetSingleHero(int id)
        {
            var result = await _heroService.GetSingleHero(id);
            if (result is null)
            {
                return NotFound("Hero is not found");
            }

            return Ok(result);

        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> CreateHero(SuperHero superHero)
        {
            var result = await _heroService.CreateHero(superHero);
            if(result is null)
            
                return NotFound("Hero is not found");
            
            return Ok(result);


           
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<SuperHero>?> UpdateHero(int id ,SuperHero superHero)
        {
            var result = await _heroService.UpdateHero(id, superHero);
            if (result is null)
            {
                return NotFound("Hero not found");
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<SuperHero>?> DeleteHero(int id)
        {
            var result = await _heroService.DeleteHero(id);
            if (result is null)
            {
                return NotFound("Hero not found");
            }
            return Ok(result); //response status 200


           
        }
    }
}
