namespace FindATM.Services.Atm
{
    using Common.Exceptions;
    using FindATM.Models.Atm;
    using Newtonsoft.Json;
    using System.IO;
    using System.Threading.Tasks;

    public class AtmService : IAtmService
    {
        public async Task<FindAtmResponseModel> FindNearestATM(FindAtmRequestModel requestModel)
        {
            if (!ValidateFindAtmRequestModel(requestModel))
            {
                throw new BadRequestException("The latitude or longitude is not in the valid value range!");
            }

            var atmAdress = await File.ReadAllTextAsync("atmAdresses.json");

            return JsonConvert.DeserializeObject<FindAtmResponseModel>(atmAdress);
        }

        public bool ValidateFindAtmRequestModel(FindAtmRequestModel requestModel)
        {
            if (requestModel is null)
            {
                throw new BadRequestException("This model cannot null!");
            }

            //Must be latitude coordinate is between -90 and 90, longitude coordinate is between -180 and 180.
            if (!(requestModel.Latitude >= -90 && requestModel.Latitude <= 90) || !(requestModel.Longitude >= -180 && requestModel.Longitude <= 180))
            {
                return false;
            }

            return true;
        }
    }
}
