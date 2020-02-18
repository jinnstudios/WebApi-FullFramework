using JinnDev.Utilities.Logging.Core;
using JinnDev.Utilities.Monad;
using System.Threading.Tasks;

namespace TestDomain
{
    public class TestService : Core.ITestService
    {
        private ILogService _logger;

        public TestService(ILogService logger)
        {
            _logger = logger;
        }

        public async Task<Maybe> DoSomething()
        {
            await _logger.LogAsync("Did Something", null);
            return Maybe.Success("Friendly Successful Message");
        }

        public async Task<Maybe<string>> GetSomething()
        {
            await _logger.LogAsync("Got Something", null);
            return "Success!".ToMaybe();
        }
    }
}