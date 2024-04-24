using EntityFrameworkDemo.Data;
using EntityFrameworkDemo.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkDemo.Services
{
    public interface IHeroService
    {
        public Task<ActionResult<List<SuperHero>>?> GetAllHeros();
        public Task<ActionResult<SuperHero>?> GetHeroById(int id);
        public Task<ActionResult<SuperHero>> AddHero(SuperHero newSuperHero);
        public Task<ActionResult<SuperHero>?> EditHeroWithId(int id, SuperHero newSuperHero);
        public Task<ActionResult<SuperHero>?> DeleteHeroWithId(int id);
    }
}
