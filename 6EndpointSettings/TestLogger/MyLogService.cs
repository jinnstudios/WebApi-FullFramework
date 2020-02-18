using JinnDev.Utilities.Logging.Core;
using JinnDev.Utilities.Logging.Models;
using JinnDev.Utilities.Monad;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

#pragma warning disable CS1998
namespace TestLogger
{
    public class MyLogService : ILogService
    {
        public async Task<Maybe<int>> LogAsync(LogModel log)
        {
            System.Diagnostics.Debug.WriteLine(log.Template);
            return 1.ToMaybe();
        }

        public async Task<Maybe<int>> LogAsync(string template, Dictionary<string, string> parameters)
        {
            System.Diagnostics.Debug.WriteLine(template);
            return 1.ToMaybe();
        }

        public async Task<Maybe<int>> LogAsync(Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex.Message);
            return 1.ToMaybe();
        }

        public async Task<Maybe<int>> LogAsync(Exception ex, string template, Dictionary<string, string> parameters)
        {
            System.Diagnostics.Debug.WriteLine(template + "\r\n\r\n" + ex.Message);
            return 1.ToMaybe();
        }

        public async Task<Maybe> UpdateLogTimeAsync(int loggingID, int timeMilliseconds)
        {
            return Maybe.Success();
        }
    }
}