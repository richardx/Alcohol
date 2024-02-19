namespace Alcohol
{
    public class BeerRepository
    {
        private List<Beer> beers = new List<Beer>()
        {
            new Beer { Id = 1, Name = "Tuborg", Abv = 0 },
            new Beer { Id = 2, Name = "Carlsberg", Abv = 10 },
            new Beer { Id = 3, Name = "Heineken", Abv = 4 },
            new Beer { Id = 4, Name = "Guinness", Abv = 17 },
            new Beer { Id = 5, Name = "Budweiser", Abv = 14 },
            new Beer { Id = 6, Name = "Corona", Abv = 2 },
            new Beer { Id = 7, Name = "Stella Artois", Abv = 22 }
        };

        public List<Beer> GetBeer(string? nameStart = null, string? sortBy = null, int? abvHigherThan = null, int? abvLowerThan = null)
        {
            List<Beer> filteredBeers = new List<Beer>(beers);

            if (nameStart != null)
            {
                filteredBeers = filteredBeers.FindAll(b => b.Name.StartsWith(nameStart));
            }
            if (abvHigherThan != null)
            {
                filteredBeers = filteredBeers.FindAll(b => b.Abv > abvHigherThan);
            }
            if (abvLowerThan != null)
            {
                filteredBeers = filteredBeers.FindAll(b => b.Abv < abvLowerThan);
            }

            if (sortBy != null)
            {
                switch (sortBy)
                {
                    case "Name":
                        filteredBeers.Sort((b1, b2) => b1.Name.CompareTo(b2.Name));
                        break;
                    case "Abv":
                        filteredBeers.Sort((b1, b2) => b1.Abv.CompareTo(b2.Abv));
                        break;
                }
            }

            return filteredBeers;
        }

        public Beer GetbeerById(int id)
        {
            return beers.FirstOrDefault(b => b.Id == id);
        }

        public Beer AddBEER(Beer beer)
        {
            beer.Id = beers.Count + 1;
            beers.Add(beer);
            return beer;
        }
        public Beer DeleteBeer(int id)
        {
            Beer beerToDelete = beers.FirstOrDefault(b => b.Id == id);
            if (beerToDelete != null)
            {
                beers.Remove(beerToDelete);
            }
            return beerToDelete;
        }
        public Beer UpdateBeer(int id, Beer values)
        {
            Beer beerToUpdate = beers.FirstOrDefault(b => b.Id == id);
            if (beerToUpdate != null)
            {
                beerToUpdate.Name = values.Name;
                beerToUpdate.Abv = values.Abv;
                return beerToUpdate;
            }
            return null;
        }

    }
}
