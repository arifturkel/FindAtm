namespace FindATM.Services.Atm
{
    using FindATM.Models.Atm;
    using System.Threading.Tasks;

    public interface IAtmService
    {
        Task<FindAtmResponseModel> FindNearestATM(FindAtmRequestModel requestModel);
        bool ValidateFindAtmRequestModel(FindAtmRequestModel requestModel);
    }
}
