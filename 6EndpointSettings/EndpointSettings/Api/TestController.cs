using System.Web.Http;
using System.Net.Http;
using TestDomain.Core;
using System.Threading.Tasks;
using JinnDev.Utilities.EndpointDocumentation;

#pragma warning disable CS1998
namespace TestFrameworkWebApp
{
    public class TestController : JinnDev.Utilities.MicroService.Core.Models.ApiControllerBase
    {
        private ITestService _svc;

        public TestController(ITestService svc)
        {
            _svc = svc;
        }

        [HttpGet]
        [Route("api/Success")]
        public async Task<HttpResponseMessage> TestSuccess()
        {
            return CreateResponse(await _svc.GetSomething());
        }

        [HttpGet] // Typically would be a Post, but this allows us to test in Browser
        [Route("api/Post")]
        public async Task<HttpResponseMessage> TestPost()
        {
            return CreateResponse(await _svc.DoSomething());
        }

        [HttpGet]
        [Route("api/Exception")]
        public async Task<HttpResponseMessage> TestBreak()
        {
            return CreateResponse(await _svc.BreakSomething());
        }

        [HttpGet]
        [Route("api/Settings")]
        [JinnDocumentation(
            InitialDescription = "Setting Description",
            ReturnType = typeof(string)
        )]
        public async Task<HttpResponseMessage> TestSettings()
        {
            return CreateResponse(EndpointSetting);
        }
    }
}