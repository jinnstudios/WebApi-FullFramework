# WebApi-FullFramework
1. Recreate a base Web API Solution and Project as you can see in the BaseFrameworkWebApp.sln

2. PM > Install-Package JinnDev.Utilities.MicroService

3. Create a new folder to hold your RESTful Controllers, I name mine "Api".

4. Add your first controller which will be used for up-time checking and testing.  I name mine "TestController.cs"

5. Copy/Paste this code into your class, rename the namespace and class as you see fit.
```csharp
    namespace TestFrameworkWebApp
    {
        public class TestController : JinnDev.Utilities.MicroService.Core.Models.ApiControllerBase
        {
            [System.Web.Http.HttpGet] [System.Web.Http.Route("api/Success")]
            public System.Net.Http.HttpResponseMessage TestSuccess()
                => CreateResponse("Success!");
        }
    }
```

Note: Though I typically follow folder to namespacing rules, I do not in this case.  Controllers are an entry point that are in a subfolder simply for organization.  So because they are the beginning of processing, I like them in the root namespace without .Api in my case.

6. Add a "New Item" to your project.  Search for "global", and add a global.asax

7. Replace the C+ code in your global.asax.cs file with the following; Rename the namespace as you see fit.
```csharp
    namespace TestFrameworkWebApp
    {
        public class Global : JinnDev.Utilities.MicroService.MicroServiceStartup
        {
            public Global() : base(new JinnDev.Utilities.MicroService.Defaults.DefaultRoot()) { }
        }
    }
```

8. Run the application and navigate to http://localhost:\[YourPort]/api/Success