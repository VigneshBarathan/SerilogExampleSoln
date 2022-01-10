using Serilog;
using System;

namespace SerilogExampleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Serilogfunc();
        }

        private static void Serilogfunc()
        {
            Log.Logger = new LoggerConfiguration().WriteTo.File(@"C:\Misc\Logs\Serilog\logfile.log").CreateLogger();
            Log.Information("This is a sample information!.");
            try
            {
                int a = 2;
                int b = 0;
                Log.Debug("The values are {0} and {0}", a, b);
                int c = a / b;
            }
            catch (System.Exception ex)
            {
                Log.Error(ex, "Some error occurred");
            }

            Log.CloseAndFlush();
            Console.WriteLine("Completed");
            Console.ReadLine();
        }
    }
}
