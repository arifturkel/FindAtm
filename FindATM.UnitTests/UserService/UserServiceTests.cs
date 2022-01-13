namespace FindATM.UnitTests.UserService
{
    using Common.Exceptions;
    using FindATM.Models.Authenticate;
    using FindATM.Services.User;
    using NUnit.Framework;

    public class UserServiceTests
    {
        private IUserService userService;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void UserService_Authanticate_Returns_Exception_When_Model_Is_Null()
        {
            this.userService = new UserService();

            var ex = Assert.Throws<BadRequestException>(() => this.userService.Authenticate(new AuthenticateModel { Username = string.Empty, Password = string.Empty }).GetAwaiter().GetResult());
            Assert.That(ex.Message, Is.EqualTo("Username or password is null!"));
        }

        [Test]
        public void UserService_Authanticate_Returns_Exception_When_User_Is_Null()
        {
            this.userService = new UserService();

            var ex = Assert.Throws<UserNotFoundException>(() => this.userService.Authenticate(new AuthenticateModel { Username = "test", Password = "test" }).GetAwaiter().GetResult());
            Assert.That(ex.Message, Is.EqualTo("This user not found!"));
        }

        [Test]
        public void UserService_Authanticate_True()
        {
            this.userService = new UserService();

            var result = this.userService.Authenticate(new AuthenticateModel { Username = "admin", Password = "password" }).GetAwaiter().GetResult();

            Assert.IsTrue(result);
        }
    }
}
