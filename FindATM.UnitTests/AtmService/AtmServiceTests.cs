namespace FindATM.UnitTests
{
    using Common.Exceptions;
    using FindATM.Models.Atm;
    using FindATM.Services.Atm;
    using NUnit.Framework;

    public class AtmServiceTests
    {
        private IAtmService atmService;


        [SetUp]
        public void Setup()
        {
        }


        [TestCase(90.10, 43.32, ExpectedResult = false)]
        [TestCase(35.240, 185.099, ExpectedResult = false)]
        [TestCase(135.37, -185.412, ExpectedResult = false)]
        [TestCase(-89.53, -179.099, ExpectedResult = true)]
        public bool AtmService_ValidateFindAtmRequestModel_Waited_Returns(double latitude, double longitude)
        {
            this.atmService = new AtmService();

            var result = this.atmService.ValidateFindAtmRequestModel(new FindAtmRequestModel { Latitude = latitude, Longitude = longitude });

            return result;
        }

        [Test]
        public void AtmService_When_ValidateFindAtmRequestModel_Is_Null()
        {
            this.atmService = new AtmService();

            var ex = Assert.Throws<BadRequestException>(() => this.atmService.ValidateFindAtmRequestModel(null));
            Assert.That(ex.Message, Is.EqualTo("This model cannot null!"));
        }

        [Test]
        public void AtmService_When_ValidateFindAtmRequestModel_Is_False()
        {
            this.atmService = new AtmService();

            var ex = Assert.Throws<BadRequestException>(() => this.atmService.FindNearestATM(new FindAtmRequestModel { Latitude = 91.00, Longitude = -181.00 }).GetAwaiter().GetResult());
            Assert.That(ex.Message, Is.EqualTo("The latitude or longitude is not in the valid value range!"));
        }

        [Test]
        public void AtmService_FindNearestATM_Returns_If_ValidateFindAtmRequestModel_Is_Valid()
        {
            this.atmService = new AtmService();

            var result = this.atmService.FindNearestATM(new FindAtmRequestModel { Latitude = 81.00, Longitude = -151.00 }).GetAwaiter().GetResult();

            Assert.AreEqual(result.CityName, "ISTANBUL");
        }


    }
}