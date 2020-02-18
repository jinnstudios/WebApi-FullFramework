using JinnDev.Utilities.Logging.Core;
using JinnDev.Utilities.MicroService;
using System;
using System.Threading.Tasks;
using TestDomain.Core;

#pragma warning disable CS1998
namespace TestFrameworkWebApp
{
    public class CompositionRoot : MicroServiceRoot
    {
        public override async Task InitializeCompositionRoot()
        {
            AddTransient<ITestService>(() => new TestDomain.TestService(GetService<ILogService>()));
        }

        public override ILogService GetLogService(Type injectedInto = null)
            => new TestLogger.MyLogService();
    }
}