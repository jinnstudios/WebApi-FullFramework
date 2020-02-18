namespace TestFrameworkWebApp
{
    public class TestController : JinnDev.Utilities.MicroService.Core.Models.ApiControllerBase
    {
        [System.Web.Http.HttpGet] [System.Web.Http.Route("api/Success")]
        public System.Net.Http.HttpResponseMessage TestSuccess()
            => CreateResponse("Success!");
    }
}