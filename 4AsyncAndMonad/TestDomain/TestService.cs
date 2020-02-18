using JinnDev.Utilities.Monad;
using System.Threading.Tasks;

#pragma warning disable CS1998
namespace TestDomain
{
    public class TestService : Core.ITestService
    {
        public async Task<Maybe<string>> GetSomething()
        {
            return "Success!".ToMaybe();
        }

        public async Task<Maybe> DoSomething()
        {
            return Maybe.Success("Friendly Successful Message");
        }
    }
}