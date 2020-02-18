using JinnDev.Utilities.Logging.Core;
using JinnDev.Utilities.Monad;
using System.Threading.Tasks;

#pragma warning disable CS1998
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
            return Maybe.Success("Friendly Success Message.");
        }

        public async Task<Maybe<string>> GetSomething()
        {
            await _logger.LogAsync("Got Something", null);
            return "Success!".ToMaybe();
        }

        public async Task<Maybe> BreakSomething()
        {
            throw new System.NotImplementedException();
        }
    }
}