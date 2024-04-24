using EntityFrameworkDemo.Entities;
using Microsoft.AspNetCore.Mvc;
using EntityFrameworkDemo.Data;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkDemo.Services
{
    public class HeroService : IHeroService
    {
        private readonly DataContext _context;
        public HeroService(DataContext context)
        {
            _context = context;
        }
        public async Task<ActionResult<SuperHero>> AddHero(SuperHero newSuperHero)
        {
            await _context.SuperHeroes.AddAsync(newSuperHero);
            await _context.SaveChangesAsync();
            return newSuperHero;
        }

        public async Task<ActionResult<SuperHero>?> DeleteHeroWithId(int id)
        {
            SuperHero? heroToDelete = await _context.SuperHeroes.FindAsync(id);
            if (heroToDelete is null) { return null; }

            _context.SuperHeroes.Remove(heroToDelete);
            return heroToDelete;
        }

        public async Task<ActionResult<SuperHero>?> EditHeroWithId(int id,SuperHero newSuperHero)
        {
            SuperHero? heroToEdit = await _context.SuperHeroes.FindAsync(id);
            if(heroToEdit is null) { return null; }
            
            heroToEdit.Name = newSuperHero.Name;
            heroToEdit.FirstName = newSuperHero.FirstName;
            heroToEdit.LastName = newSuperHero.LastName;
            heroToEdit.Place = newSuperHero.Place;

            await _context.SaveChangesAsync();
            return heroToEdit;
        }

        public async Task<ActionResult<List<SuperHero>>?> GetAllHeros(){
            List<SuperHero>? heros = await _context.SuperHeroes.ToListAsync();
            if(heros is null) { return null; }

            return heros;
        }

        public async Task<ActionResult<SuperHero>?> GetHeroById(int id)
        {
            SuperHero? hero = await _context.SuperHeroes.FindAsync(id);
            if (hero is null) { return null; }

            return hero;
        }
    }
}
