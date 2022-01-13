namespace FindATM.Controllers
{
    using Common.Models;
    using FindATM.Models.Atm;
    using FindATM.Services.Atm;
    using FindATM.Services.User;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class AtmController : ControllerBase
    {

        private readonly ILogger<AtmController> logger;
        private readonly IAtmService atmService;

        public AtmController(ILogger<AtmController> logger, IAtmService atmService, IUserService userService)
        {
            this.logger = logger;
            this.atmService = atmService;
        }

        /// <summary>
        /// Find the nearest ATM.
        /// </summary>
        /// <param name="model">model.</param>
        /// <returns>The nearest ATM result.</returns>
        [Authorize]
        [HttpPost("nearestAtm")]
        [ProducesResponseType(statusCode: 200, type: typeof(FindAtmResponseModel))]
        [ProducesResponseType(statusCode: 400, type: typeof(FailedApiResponse<string>))]
        public async Task<IActionResult> FindAtm([FromBody] FindAtmRequestModel model)
        {
            var nearestAtm = await this.atmService.FindNearestATM(model);
            return Ok(nearestAtm);
        }
    }
}
