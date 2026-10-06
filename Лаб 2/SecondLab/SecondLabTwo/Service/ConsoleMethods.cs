using SecondLabTwo.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecondLabTwo.Service
{
    internal class ConsoleMethods
    {
        public static void Show(string line, IEnumerable<Telephone> telephones)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(line);
            Console.ForegroundColor = ConsoleColor.White;
            if (telephones == null) { Console.WriteLine("- There are no such telephones"); }
            else
            {
                foreach (var tel in telephones)
                {
                    Console.WriteLine($"- {tel}");
                }
            }
        }

        public static void ShowInt(string line, int number)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(line);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"- {number}");
        }

        public static void ShowDecimal(string line, decimal number)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(line);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"- {number}");
        }

        public static void ShowTelephone(string line, Telephone telephones)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(line);
            Console.ForegroundColor = ConsoleColor.White;
            if (telephones == null) { Console.WriteLine("- There are no such telephones"); }
            Console.WriteLine($"- {telephones}");
          
            
        }
        public static void ShowDictionary(string line, Dictionary<string, int> dictionary)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(line);
            Console.ForegroundColor = ConsoleColor.White;
            foreach (var item in dictionary)
            {
               Console.WriteLine($"* {item.Key} - {item.Value}");
            }
            
        }
    }
}
