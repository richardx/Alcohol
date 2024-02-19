using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Alcohol.Tests
{
    [TestClass()]
    public class BeerTests
    {
        private Beer beer = new Beer { Id = 1, Name = "Tuborg", Abv = 5 };
        private Beer beer2Wrong = new Beer { Id = 2, Name = "Carlsberg", Abv = -1 };
        private Beer beer3Right = new Beer { Id = 3, Name = "Heineken", Abv = 67 };
        private Beer beer4Wrong = new Beer { Id = 4, Name = "Guinness", Abv = 68 };
        private Beer beer5Right = new Beer { Id = 5, Name = "Budweiser", Abv = 0 };
        private Beer beerNull = new Beer { Id = 6, Name = null, Abv = 17 };
        private Beer beerShort = new Beer { Id = 7, Name = "a", Abv = 8 };
        private Beer beerLong = new Beer { Id = 8, Name = "abcdefghijklmnopqrstuvxyz", Abv = 9 };

        [TestMethod()]
        public void ToStringTest()
        {
            string beeroverride = beer.ToString();
            Assert.AreEqual("Id: 1, Name: Tuborg, Abv: 5", beeroverride);
        }

        [TestMethod()]
        public void ValidateAbvTest()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => beer2Wrong.ValidateAbv());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => beer4Wrong.ValidateAbv());

            try
            {
                beer3Right.ValidateAbv();
                beer5Right.ValidateAbv();
            }
            catch (ArgumentOutOfRangeException)
            {
                Assert.Fail("ValidateAbv() should not throw an exception for valid values.");
            }

        }

        [TestMethod()]
        public void ValidateNameTest()
        {
            beer.ValidateName();
            Assert.ThrowsException<ArgumentNullException>(() => beerNull.ValidateName());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => beerShort.ValidateName());

            try
            {
                beerLong.ValidateName();
            }
            catch (ArgumentOutOfRangeException)
            {
                Assert.Fail("ValidateName() should not throw an exception for valid values.");
            }
        }
    }
}