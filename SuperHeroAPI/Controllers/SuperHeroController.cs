using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.Data;
using SuperHeroAPI.Models;
using SuperHeroAPI.Services.SuperHeroService;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly ISuperHeroService _superHeroService;

        public SuperHeroController(ISuperHeroService superHeroService)
        {
            _superHeroService = superHeroService;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
        {
            var results = await _superHeroService.GetAllHeroes();
            
            return Ok(results);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetSingleHero(int id)
        {

            var result = await _superHeroService.GetSingleHero(id);

            if (result is null)
            {
                return NotFound("Super Hero not found");
            }
            
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero([FromBody]SuperHero hero)
        {
            var result = await _superHeroService.AddHero(hero);

            return Ok(result);
        }

        [HttpPut("id")]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(int id, SuperHero request)
        {
            var result = await _superHeroService.UpdateHero(id, request);

            if (result is null)
            {
                return NotFound("Super hero not found");
            }

            return Ok(result);
        }


        [HttpDelete("id")]
        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
        {
            var result = _superHeroService.DeleteHero(id);
            if (result is null)
            {
                return NotFound("Super hero not found");
            }

            return Ok(result);
        }
    }
}
