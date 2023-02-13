using SuperHeroAPI.Models;

namespace SuperHeroAPI.Services
{
    public interface ISuperHeroService
    {
        Task<List<SuperHero>> GetAllHeros();
        Task<SuperHero?> GetSingleHero(int id);
        Task<List<SuperHero>> CreateHero(SuperHero superHero);

        Task<List<SuperHero>?> UpdateHero(int id, SuperHero superHero);
        Task<List<SuperHero>?> DeleteHero(int id);
    }
}
