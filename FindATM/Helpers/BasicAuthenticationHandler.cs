namespace FindATM.Helpers
{
    using System;
    using System.Linq;
    using System.Net.Http.Headers;
    using System.Security.Claims;
    using System.Text;
    using System.Text.Encodings.Web;
    using System.Threading.Tasks;
    using FindATM.Models.Authenticate;
    using FindATM.Services.User;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;

    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly IUserService userService;

        public BasicAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            IUserService userService)
            : base(options, logger, encoder, clock)
        {
            this.userService = userService;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            AuthenticateModel authenticate = new AuthenticateModel();  
            try  
            {  
                var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);  
                var credentials = Encoding.UTF8.GetString(Convert.FromBase64String(authHeader.Parameter)).Split(':');
                authenticate.Username = credentials.FirstOrDefault();
                authenticate.Password = credentials.LastOrDefault();  
  
                if (!await this.userService.Authenticate(authenticate))  
                    throw new ArgumentException("Invalid credentials");  
            }  
            catch (Exception ex)  
            {  
                return AuthenticateResult.Fail($"Authentication failed: {ex.Message}");  
            }  
  
            var claims = new[] {  
                new Claim(ClaimTypes.Name, authenticate.Username)  
            };  
            var identity = new ClaimsIdentity(claims, Scheme.Name);  
            var principal = new ClaimsPrincipal(identity);  
            var ticket = new AuthenticationTicket(principal, Scheme.Name);  
  
            return AuthenticateResult.Success(ticket);  
        }

        protected override Task HandleChallengeAsync(AuthenticationProperties properties)
        {
            Response.Headers["WWW-Authenticate"] = "Basic realm=\"\", charset=\"UTF-8\"";
            return base.HandleChallengeAsync(properties);
        }
    }
}