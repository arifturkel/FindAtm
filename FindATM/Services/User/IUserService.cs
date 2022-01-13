namespace FindATM.Services.User
{
    using FindATM.Models.Authenticate;
    using System.Threading.Tasks;

    public interface IUserService
    {
        Task<bool> Authenticate(AuthenticateModel model);
    }
}
