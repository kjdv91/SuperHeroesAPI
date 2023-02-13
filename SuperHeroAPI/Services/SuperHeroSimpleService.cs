using SuperHeroAPI.Models;

namespace SuperHeroAPI.Services
{
    public class SuperHeroSimpleService : ISuperHeroSimpleService
    {
        private static List<SuperHero> superHeros = new List<SuperHero> {
                new SuperHero{
                    SuperHeroId=1,
                    Name="Spiderman",
                    FirstName = "Peter",
                    LastName = "Parker",
                    Place = "New York City"},

            new SuperHero{
                    SuperHeroId=2,
                    Name="Iron Man",
                    FirstName = "Tony",
                    LastName = "Stark",
                    Place = "Malibu"}
};
       

       

        public List<SuperHero> GetAllHeros()
        {
            return superHeros;
            
        }

        public SuperHero? GetSingleHero(int id)
        {
            var hero = superHeros.Find(x => x.SuperHeroId == id);
            if (hero is null)

                return null;
            

            return hero;  //response status 200
        }

        public List<SuperHero> CreateHero(SuperHero superHero)
        {
            superHeros.Add(superHero);
            return superHeros;
        }

        public List<SuperHero>? UpdateHero(int id, SuperHero superHero)
        {
            var hero = superHeros.Find(x => x.SuperHeroId == superHero.SuperHeroId);
            if (hero is null)
            
                return null;
            
            hero.Name = superHero.Name;
            hero.FirstName = superHero.FirstName;
            hero.LastName = superHero.LastName;
            hero.Place = superHero.Place;


            return superHeros;  //response status 200
        }

        public List <SuperHero>? DeleteHero(int id)
        {
            var hero = superHeros.Find(x => x.SuperHeroId == id);
            if (hero is null)
                return null;
            superHeros.Remove(hero);


            return superHeros;  //response status 200
        }
    }
}
