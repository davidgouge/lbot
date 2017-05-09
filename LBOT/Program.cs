using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ShellProgressBar;

namespace LBOT
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "LBOT";

            var sleepRand = new Random();
            var processingRand = new Random();
            var processOn = processingRand.Next(0, 100);
            var processingCount = 0;

            while (true)
            {
                if (processingCount == processOn)
                {
                    WriteLine(Guid.NewGuid() + " - Needs processing", ConsoleColor.Red);
                    var maxTicks = 4000;
                    using (var pbar = new ProgressBar(maxTicks, "Starting", new ProgressBarOptions() { ProgressCharacter = '\u2593',ProgressBarOnBottom = true}))
                    {
                        for (var i = 0; i < maxTicks; i++)
                        {
                            pbar.Tick("Currently processing " + i);
                        }
                    }

                    processingCount = 0;
                    processOn = processingRand.Next(0, 100);
                }

                WriteLine(Guid.NewGuid(), ConsoleColor.Green);
                Thread.Sleep(sleepRand.Next(0,300));

                processingCount++;
            }
        }

        static void WriteLine(object line, ConsoleColor colour)
        {
            Console.ForegroundColor = colour;
            Console.WriteLine(line);
            Console.ResetColor();
        }
    }
}
