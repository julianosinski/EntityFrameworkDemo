using EntityFrameworkDemo.Data;
using EntityFrameworkDemo.Entities;
using EntityFrameworkDemo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // insted of checking for nulls in controller shoud I implement generic Service response class witch chacks for it?
    public class SuperHeroController : ControllerBase
    {
        private readonly IHeroService _heroService;

        public SuperHeroController(IHeroService heroService)
        {
            _heroService = heroService;
        }

        [HttpGet]
        //public async Task<IActionResult> GetAllHeroes()
        public async Task<ActionResult<List<SuperHero>>> GetAllHeroes() 
        {
            return Ok(await _heroService.GetAllHeros());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetHero(int id)
        {
            var hero = await _heroService.GetHeroById(id);
            if (hero is null)
            {
                return BadRequest("Hero Not Found");
            }
            return Ok(hero);
        }
        [HttpPost]//DTO would be nice
        public async Task AddHero(SuperHero newHero)
        {
            await _heroService.AddHero(newHero);  
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<SuperHero>> UpdateHero(SuperHero updatedHero, int id)
        {
            var editedHero = await _heroService.EditHeroWithId(id, updatedHero);
            if (editedHero is null)
            {
                return BadRequest("Hero Not Found");
            }
            return Ok(editedHero);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHero(int id)
        {
            var deletedHero = await _heroService.DeleteHeroWithId(id);
            if (deletedHero is null)
            {
                return BadRequest("Hero Not Found");
            }
            return Ok(deletedHero);
        }
    }
}
