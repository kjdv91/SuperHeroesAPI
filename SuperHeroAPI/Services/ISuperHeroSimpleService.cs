using SuperHeroAPI.Models;

namespace SuperHeroAPI.Services
{
    public interface ISuperHeroSimpleService
    {
        List<SuperHero> GetAllHeros();
        SuperHero? GetSingleHero(int id);
        List<SuperHero>? CreateHero(SuperHero superHero);

        List<SuperHero>? UpdateHero(int id, SuperHero superHero);
        List<SuperHero>? DeleteHero(int id);
    }
}
