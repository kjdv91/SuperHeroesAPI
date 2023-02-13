using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperHeroAPI.Data;
using SuperHeroAPI.Models;

namespace SuperHeroAPI.Services
{
    public class SuperHeroService: ISuperHeroService
    {
       
        private readonly AplicationDbContext _context;

        public SuperHeroService(AplicationDbContext context)
        {
            
            _context = context;
        }

       

        public async Task<List<SuperHero>> GetAllHeros()
        {
            var heroes = await _context.SuperHeroes.ToListAsync();
            return heroes;
        }

        public async Task <SuperHero?> GetSingleHero(int id)
        {
            var heroe = await _context.SuperHeroes.FindAsync(id);
            
            if (heroe is null)
                return null;
            
            return heroe;
         
        }

        public async Task <List<SuperHero>> CreateHero(SuperHero superHero)
        {
            _context.SuperHeroes.Add(superHero);
            await _context.SaveChangesAsync();
            return await _context.SuperHeroes.ToListAsync();
        }

       

        public async Task<List<SuperHero>?> UpdateHero(int id, SuperHero superHero)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);
            if (hero is null)

                return null;

            hero.Name = superHero.Name;
            hero.FirstName = superHero.FirstName;
            hero.LastName = superHero.LastName;
            hero.Place = superHero.Place;

            await _context.SaveChangesAsync();
            return await _context.SuperHeroes.ToListAsync();

        }

        public async Task<List<SuperHero>?> DeleteHero(int id)
        {
            var heroe = await _context.SuperHeroes.FindAsync(id);
            if (heroe is null)
                return null;

            _context.SuperHeroes.Remove(heroe);
            await _context.SaveChangesAsync();
            
            return await _context.SuperHeroes.ToListAsync();
        }

       
    }
}
