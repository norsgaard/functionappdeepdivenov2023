using System;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace teknologisk.functionapp
{
    public class iamalive
    {
        private readonly ILogger _logger;

        public iamalive(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<iamalive>();
        }

        [Function("iamalive")]
        public void Run([TimerTrigger("0 */1 * * * *")] TimerInfo myTimer)
        {
            // This is just a simple example of a function running every minute, that outputs something to the logs.
            _logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            
            if (myTimer.ScheduleStatus is not null)
            {
                _logger.LogInformation($"Next timer schedule at: {myTimer.ScheduleStatus.Next}");
            }
        }
    }
}
