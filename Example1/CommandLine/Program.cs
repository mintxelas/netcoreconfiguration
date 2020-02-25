using Microsoft.Extensions.Configuration;
using System;

namespace CommandLine
{
    class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddCommandLine(args)
                .Build();

            Console.WriteLine(configuration["message"]);
            Console.ReadLine();
        }
    }
}
