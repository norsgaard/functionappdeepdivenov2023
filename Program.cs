using Microsoft.Extensions.Hosting;

internal class Program
{
    private static void Main(string[] args)
    {
        // This is the minimum required code to allow the function app to run in Isolated mode. This file is not needed if using the In Process mode.
        var host = new HostBuilder()
            .ConfigureFunctionsWorkerDefaults()
            .Build();

        host.Run();
    }
}