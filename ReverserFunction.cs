using System.IO;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace teknologisk_functionapp
{
    public class ReverserFunction
    {
        private readonly ILogger<ReverserFunction> _logger;

        public ReverserFunction(ILogger<ReverserFunction> logger)
        {
            _logger = logger;
        }

        [Function("Reverser")]
        [BlobOutput("output/{rand-guid}.txt", Connection = "ArchiveStorageConnectionString")]
        public string Run([BlobTrigger("input/{name}", Connection = "ArchiveStorageConnectionString")] string input)
        {
            // This function reads a Blob (file) placed in the "input" container of the Storage Account, that the connection ArchiveStorageConnectionString is pointed at. 
            // The setup here is that the function app is using Managed Identities to gain access to the Storage Account 
            // See local.settings.json for an example connection, when using this type of binding
            //
            // Note: The standard BlobTrigger template using streams, which does not working when using Output Binding. This is changed to string in this example, i.e. the variable "input"

            char[] reversed = input.ToCharArray();
            Array.Reverse(reversed);    
            string reversedString = new string(reversed);  
        
            return reversedString;
        }
    }
}
