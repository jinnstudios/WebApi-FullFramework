using JinnDev.Utilities.Logging.Core;
using JinnDev.Utilities.MicroService;
using JinnDev.Utilities.MicroService.Core.Models;
using JinnDev.Utilities.Monad;
using JinnDev.Utilities.Setting.Core;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

#pragma warning disable CS1998
namespace TestFrameworkWebApp
{
    public class TestAuth : MicroServiceAuth
    {
        public TestAuth(ISettingService setting, ILogService logger) : base(setting, logger) { }

        protected override async Task<Maybe> ClientValidates(ApiControllerBase controller)
        {
            // Just as a Resource Owner has a Token to validate who they are; a Client, such as 
            // another MicroService in the same Ecosystem, has its own token called a secretKey.
            // This can be a short-cached item controlled by the ISettingService implementation.
            // It can be controlled and changed daily, weekly, monthly, or more in the database,
            // and the systems should still be able to talk to each other (after the cache switchover).

            var serviceSetting = await _setting.GetServiceSetting(null); // <-- Current static implementation returns "secretKey"
            if (serviceSetting.Value.SecretKey == controller.SecretKey)
                return Maybe.Success();
            return Maybe.Failure();
        }

        protected override bool HostOriginRefererChecks(ApiControllerBase controller)
        {
            // Here, you can check headers and other information in the controller object, and
            // decide if you want to allow the sender access.
            return true;
        }

        protected override async Task<Maybe<JinnAuthClaim>> ValidateResourceOwner(ApiControllerBase controller)
        {
            // Your Bearer Token and other values are in the headers and other properties of the controller ^^^
            // You can use this information on each request to check if the request has a valid Resource Owner
            // Return the appropriate claims and password expiration date.

            if (string.IsNullOrWhiteSpace(controller.AccessToken))
                return Maybe.Empty<JinnAuthClaim>();

            return new JinnAuthClaim(
                new List<Claim> { new Claim(ClaimTypes.Name, "Test Username")
                                , new Claim("ResourceOwnerID", "1") },
                      DateTime.UtcNow.AddHours(1)
                ).ToMaybe();
        }
    }
}