using System.Web.Http;
using System.Net.Http;
using TestDomain.Core;

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
        public HttpResponseMessage TestSuccess()
        {
            return CreateResponse(_svc.GetSomething());
        }
    }
}