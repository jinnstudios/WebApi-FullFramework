﻿using JinnDev.Utilities.Logging.Core;
using JinnDev.Utilities.MicroService;
using JinnDev.Utilities.Setting.Core;
using System;
using System.Threading.Tasks;
using System.Web.Http;
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

        public override ISettingService GetSettingService(Type injectedInto = null)
            => new SettingTester();

        // Interceptor is the entry-point for Settings, so we'll use the Default implementation for now
        public override Interceptor GetInterceptor(Type injectedInto = null)
            => new TestInterceptor(GetService<ISettingService>(), GetService<ILogService>());

        public override AuthorizeAttribute GetAuthService(Type injectedInto = null)
            => new TestAuth(GetService<ISettingService>(), GetService<ILogService>());
    }
}