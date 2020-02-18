namespace TestDomain
{
    public class TestService : Core.ITestService
    {
        public string GetSomething()
        {
            return "Success!";
        }
    }
}