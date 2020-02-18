using JinnDev.Utilities.Monad;
using JinnDev.Utilities.Setting.Core;
using JinnDev.Utilities.Setting.Models;
using System.Threading.Tasks;

#pragma warning disable CS1998
namespace TestFrameworkWebApp
{
    public class SettingTester : ISettingService
    {
        public const string SECRET_KEY_LABEL = "SecretKey";
        public const string SECRET_KEY_VALUE = "secretKey";

        /// <summary>
        /// Adds an Endpoint Setting.  This is a configuration for Web API RESTful Endpoints
        /// including their routes, descriptions, and authorization requirements.
        /// This is called automatically when a newly found endpoint is hit for the first time.
        /// </summary>
        public async Task<Maybe> AddEndpointSettingAsync(EndpointSettingModel setting)
            => Maybe.Success();

        /// <summary>
        /// Adds an Authenticated Setting which should only be accessible in particular circumstances
        /// PermissionExpression is covered during the Auth addition.
        /// </summary>
        public async Task<Maybe> AddAuthenticatedSettingAsync(AuthenticatedSettingModel setting)
            => Maybe.Success();

        /// <summary>
        /// Sets a setting related to a MicroService in the same Ecosystem.
        /// For example, the Order MicroService would have the ServiceName "Order"
        ///     , the Location would be //Orders.MyWebsite.com
        ///     , and the SecretKey would be the key necessary to connect to it as a Client.
        /// </summary>
        public async Task<Maybe> AddServiceSettingAsync(ServiceSettingModel setting)
            => Maybe.Success();

        /// <summary>
        /// Sets an UNauthenticated Setting.  This is something like styles, designs, etc.
        /// </summary>
        public async Task<Maybe> AddUnauthenticatedSettingAsync(UnauthenticatedSettingModel setting)
            => Maybe.Success();


        /// <summary>
        /// Gets an Endpoint Setting.  This is a configuration for Web API RESTful Endpoints
        /// including their routes, descriptions, and authorization requirements
        /// 
        /// Get is called during every endpoint hit.  The reason the entire Model is sent for this Get
        /// instead of just an ID is because; when you check your DB to get the settings, and it doesn't
        /// exist, you should add it for the first time.  If you add it for the first time, return "true" for
        /// isNewSetting.  Otherwise, return the existing DB setting, and ensure IsNewSetting is set to "false";
        /// </summary>
        public async Task<Maybe<EndpointSettingModel>> GetEndpointSetting(EndpointSettingModel setting)
        {
            if (setting.TimeoutMS == 0) setting.TimeoutMS = 10000; // <-- If TimeoutMS is 0, your endpoint will always return Timeout
            // In Localhost (::1), Timeout is forced in the framework to 60000 for debugging purposes.

            setting.IsNewSetting = true; // <-- Forces the framework to always look up the endpoint details and use "Initial" settings
            
            return setting.ToMaybe(); // <-- Currently returning what was passed to me, slightly altered.  Instead, return what you get from your Database
        }

        /// <summary>
        /// Gets an Authenticated Setting, including the PermissionExpression 
        ///     expected to pass for whoever wants the value
        /// PermissionExpression is covered during the Auth addition.
        /// </summary>
        public async Task<Maybe<AuthenticatedSettingModel>> GetSecureSettingByKey(string settingKey, bool includeChildren = false)
            => new AuthenticatedSettingModel { Key = settingKey }.ToMaybe();

        /// <summary>
        /// Gets the setting related to the specified MicroService in the same Ecosystem.
        /// For example; if Order MicroService needs to call the ItemMicroService, it would look it up here.
        /// </summary>
        public async Task<Maybe<ServiceSettingModel>> GetServiceSetting(string serviceName)
        {
            var setting = new ServiceSettingModel { SecretKey = SECRET_KEY_VALUE };
            return setting.ToMaybe();
        }

        /// <summary>
        /// Gets an UNauthenticated Setting.  This is something like styles, designs, etc.
        /// </summary>
        public async Task<Maybe<UnauthenticatedSettingModel>> GetSettingByKey(string settingKey, bool includeChildren = false)
            => new UnauthenticatedSettingModel { Key = settingKey }.ToMaybe();



        /// <summary>
        /// When an GetEndpointSetting(...) is hit, and if a setting is returned with IsNewSetting == true,
        /// Then the setting is fleshed out with a whole bunch of additional initial settings.
        /// In that case, this method is called as a follow-up with all the additional Initial details.
        /// </summary>
        public async Task<Maybe> UpdateEndpointSetting(EndpointSettingModel fromSetting, EndpointSettingModel toSetting)
            => Maybe.Success();

        /// <summary>
        /// Updates an Authenticated Setting
        /// </summary>
        public async Task<Maybe> UpdateAuthenticatedSetting(AuthenticatedSettingModel setting)
            => Maybe.Success();

        /// <summary>
        /// Updates a Service Setting
        /// </summary>
        public async Task<Maybe> UpdateServiceSetting(string serviceName, string serviceLocation, string secretKey)
            => Maybe.Success();

        /// <summary>
        /// Updates an Unauthenticated Setting
        /// </summary>
        public async Task<Maybe> UpdateUnauthenticatedSetting(UnauthenticatedSettingModel setting)
            => Maybe.Success();
    }
}