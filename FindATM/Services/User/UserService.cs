namespace FindATM.Services.User
{
    using Common.Exceptions;
    using FindATM.Models.Authenticate;
    using FindATM.Models.User;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class UserService : IUserService
    {
        private List<UserModel> users = new ()
        {
            new UserModel { Username = "admin", Password = "password" }
        };
        public async Task<bool> Authenticate(AuthenticateModel model)
        {
            if (string.IsNullOrEmpty(model.Username) || string.IsNullOrEmpty(model.Password))
            {
                throw new BadRequestException("Username or password is null!");
            }

            var user = await Task.Run(() => users.SingleOrDefault(x => x.Username == model.Username && x.Password == model.Password));

            // return null if user not found
            if (user == null)
                throw new UserNotFoundException("This user not found!");

            return true;
        }
    }
}
