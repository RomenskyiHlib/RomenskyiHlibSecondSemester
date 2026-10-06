using SecondLab.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondLab.Service
{
    internal class ConsoleMethods
    {
        public static void Show(string line, IEnumerable<Firm> firms)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(line);
            Console.ForegroundColor = ConsoleColor.White;
            if (firms == null) { Console.WriteLine("- There are no such firms"); }
            else
            {
              foreach (var firm in firms)
                {
                    Console.WriteLine($"- {firm}");
                }
            }
        }
    }
}
