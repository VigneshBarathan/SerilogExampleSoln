using Serilog;
using System;

namespace SerilogExampleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Serilogfunc();
            Seqfunc();
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

        private static void Seqfunc()
        {
            Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.Seq("http://localhost:5341")
            .CreateLogger();

            Log.Information("Hello, {Name}!", Environment.UserName);

            // Important to call at exit so that batched events are flushed.
            Log.CloseAndFlush();

            Console.ReadKey(true);
        }
    }
}
