using System.Web.Http;
using System.Net.Http;
using TestDomain.Core;
using System.Threading.Tasks;

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
    }
}