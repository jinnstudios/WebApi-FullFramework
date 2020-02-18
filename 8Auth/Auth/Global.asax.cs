using JinnDev.Utilities.MicroService;

namespace TestFrameworkWebApp
{
    public class Global : MicroServiceStartup
    {
        public Global() : base(new CompositionRoot()) { }
    }
}