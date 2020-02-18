using JinnDev.Utilities.Monad;
using System.Threading.Tasks;

namespace TestDomain.Core
{
    public interface ITestService
    {
        Task<Maybe<string>> GetSomething();
        Task<Maybe> DoSomething();
    }
}