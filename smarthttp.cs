using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace teknologisk.functionapp
{
    public class smarthttp
    {
        private readonly ILogger _logger;

        public smarthttp(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<smarthttp>();
        }

        [Function("smarthttp")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
        {
            // Simple http trigger which can be called with either GET or POST, using the function key as authorization.
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            response.WriteString("velkommen til azure functions fra devops!");

            return response;
        }
    }
}
