using Microsoft.Owin.Hosting;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdSrv
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo
                .LiterateConsole(outputTemplate: "{Timestamp:HH:MM} [{Level}] ({Name:l}){NewLine} {Message}{NewLine}{Exception}")
                .CreateLogger();

            // hosting identityserver
            using (WebApp.Start<Startup>("https://localhost:44333"))
            {
                Console.WriteLine("server running...");
                Console.ReadLine();
            }
        }
    }
}
