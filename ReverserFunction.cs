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

        //[Function("Reverser")]
        //[BlobOutput("output/{rand-guid}.txt", Connection = "ArchiveStorageConnectionString")]
        public string Run([BlobTrigger("input/{name}", Connection = "ArchiveStorageConnectionString")] string input)
        {
            //using var blobStreamReader = new StreamReader(stream);
            //var content = blobStreamReader.ReadToEnd();
            char[] reversed = input.ToCharArray();
            Array.Reverse(reversed);    
            string reversedString = new string(reversed);  
            //_logger.LogInformation($"C# Blob trigger function Processed blob\n Name: {name} \n Data: {reversedString}");
        
            return reversedString;
        }
    }
}
