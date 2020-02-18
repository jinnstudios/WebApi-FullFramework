using JinnDev.Utilities.MicroService;
using System.Threading.Tasks;
using TestDomain.Core;

namespace TestFrameworkWebApp
{
    public class CompositionRoot : MicroServiceRoot
    {
        public override async Task InitializeCompositionRoot()
        {
            AddTransient<ITestService>(() => new TestDomain.TestService());
        }
    }
}