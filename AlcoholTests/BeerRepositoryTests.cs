using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Alcohol.Tests
{
    [TestClass()]
    public class BeerRepositoryTests
    {
        private Beer addBeer = new Beer { Id = 8, Name = "Colabeer", Abv = 9 };

        [TestMethod()]
        public void GetBeerTest()
        {
            BeerRepository repository = new BeerRepository();

            var beers = repository.GetBeer();
            Assert.AreEqual(7, beers.Count);

            var beerWithHeineken = repository.GetBeer("He");
            Assert.AreEqual(1, beerWithHeineken.Count);

            var beerWithHigherAbv = repository.GetBeer(abvHigherThan: 5);
            Assert.AreEqual(4, beerWithHigherAbv.Count);

            var beerWithLowerAbv = repository.GetBeer(abvLowerThan: 5);
            Assert.AreEqual(3, beerWithLowerAbv.Count);

            var beerSortedByName = repository.GetBeer(sortBy: "Name");
            Assert.AreEqual("Budweiser", beerSortedByName[0].Name);

            var beerSortedByAbv = repository.GetBeer(sortBy: "Abv");
            Assert.AreEqual(2, beerSortedByAbv[1].Abv);

            var beerWithHeinekenAndHigherAbv = repository.GetBeer("He", abvHigherThan: 3);
            Assert.AreEqual(1, beerWithHeinekenAndHigherAbv.Count);
        }

        [TestMethod()]
        public void GetByIdTest()
        {
            // Arrange
            BeerRepository repository = new BeerRepository();
            int beerId = 2;

            // Act
            var beer = repository.GetbeerById(beerId);

            // Assert
            Assert.IsNotNull(beer);
            Assert.AreEqual("Carlsberg", beer.Name);
            Assert.AreEqual(5, beer.Abv);
        }

        [TestMethod()]
        public void AddBeerTest()
        {
            List<Beer> beers = new()
            {
                new Beer
                {
                    Id = 1,
                    Name = "Tuborg",
                    Abv = 5
                }
            };
            beers.Add(addBeer);
            Assert.IsTrue(beers.Contains(addBeer));
        }

        [TestMethod()]
        public void DeleteBeerTest()
        {
            List<Beer> beers = new()
            {
                new Beer
                {
                    Id = 1,
                    Name = "Tuborg",
                    Abv = 5
                },
                new Beer
                {
                    Id = 2,
                    Name = "Carlsberg",
                    Abv = 5
                }
            };
            Beer deletedBeer = beers.FirstOrDefault(b => b.Id == 2);
            if (deletedBeer != null)
            {
                beers.Remove(deletedBeer);
            }
            Assert.IsFalse(beers.Contains(deletedBeer));
        }

        [TestMethod()]
        public void UpdateBeerTest()
        {
            List<Beer> beers = new()
            {
                new Beer
                {
                    Id = 1,
                    Name = "Tuborg",
                    Abv = 5
                },
                new Beer
                {
                    Id = 2,
                    Name = "Carlsberg",
                    Abv = 5
                }
            };
            Beer updatedBeer = beers.FirstOrDefault(b => b.Id == 2);
            if (updatedBeer != null)
            {
                updatedBeer.Name = "Carlsberg 1883";
                updatedBeer.Abv = 6;
            }
            Assert.AreEqual("Carlsberg 1883", updatedBeer.Name);
            Assert.AreEqual(6, updatedBeer.Abv);
        }
    }
}