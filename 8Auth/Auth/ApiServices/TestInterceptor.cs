using JinnDev.Utilities.Logging.Core;
using JinnDev.Utilities.MicroService;
using JinnDev.Utilities.MicroService.Core.Models;
using JinnDev.Utilities.Monad;
using JinnDev.Utilities.Setting.Core;
using System.Threading.Tasks;

#pragma warning disable CS1998
namespace TestFrameworkWebApp
{
    public class TestInterceptor : Interceptor
    {
        public TestInterceptor(ISettingService setting, ILogService logger) : base(setting, logger) { }

        public override async Task<Maybe> SetCacheBasedOnContext(ApiControllerBase controller, object value)
        {
            // Use whatever caching mechanism you need to configure a unique identifier
            // from the information in the controller, and save the value of the response.

            //_cache.SetValue(controller.EndpointSetting.EndpointRoute, value);

            return Maybe.Success();
        }

        public override async Task<Maybe<object>> GetCacheBasedOnContext(ApiControllerBase controller)
        {
            // Use whatever caching mechanism you need to determine the unique identifier
            // from the information in the controller, and get the value for the response.

            //var response = _cache.GetValue(controller.EndpointSetting.EndpointRoute);
            //return response.ToMaybe();

            return Maybe.Empty<object>(); // <-- Represents that no value could be found, so continue as normal
        }
    }
}