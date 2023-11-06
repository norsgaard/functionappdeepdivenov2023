using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace teknologisk_functionapp
{
    public class CrashMe
    {
        private readonly ILogger _logger;

        public CrashMe(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<CrashMe>();
        }

        //[Function("CrashMe")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            throw new Exception($"I crashed the function at {DateTime.UtcNow}");

            
        }
    }
}
