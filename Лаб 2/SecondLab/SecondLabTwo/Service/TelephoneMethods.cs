using SecondLabTwo.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecondLabTwo.Service
{
    internal class TelephoneMethods
    {
        private List<Telephone> telephones { get; set; }
        public void AllTelephones()
        {
            int count = telephones.Count();
            ConsoleMethods.ShowInt("Number of Telephones:", count);
        }

        public void MoreThanOneHundPriceTelephones()
        {
            var telephone = from tel in telephones
                            where tel.price > 100
                            select tel;

            int count = telephone.Count();
            ConsoleMethods.ShowInt("Number of Telephones, those with price more than 100 gold:", count);
        }

        public void MoreThanSevenHundButLessThanFourHundPriceTelephones()
        {
            var telephone = from tel in telephones
                            where tel.price > 400 && tel.price < 700
                            select tel;

            int count = telephone.Count();
            ConsoleMethods.ShowInt("Number of Telephones with prices ranging from 400 to 700 gold:", count);
        }

        public void ManufactureTelephones(string Manufacture)
        {
            var telephone = from tel in telephones
                            where tel.manufacturer == Manufacture
                            select tel;
            int count = telephone.Count();
            ConsoleMethods.ShowInt("Number of Telephones from a particular manufacturer:", count);
        }
        public void CheaperTelephones()
        {
            var telephone = from tel in telephones
                            orderby tel.price
                            select tel;
            Telephone phone = telephone.FirstOrDefault();
            ConsoleMethods.ShowTelephone("Cheaper Telephone:", phone);
        }

        public void CostlyTelephones()
        {
            var telephone = from tel in telephones
                            orderby tel.price
                            select tel;
            Telephone phone = telephone.LastOrDefault();
            ConsoleMethods.ShowTelephone("Costly Telephone:", phone);
        }

        public void OldestTelephones()
        {
            var telephone = from tel in telephones
                            orderby tel.data
                            select tel;
            Telephone phone = telephone.FirstOrDefault();
            ConsoleMethods.ShowTelephone("Oldest Telephone:", phone);
        }

        public void NewestTelephones()
        {
            var telephone = from tel in telephones
                            orderby tel.data
                            select tel;
            Telephone phone = telephone.LastOrDefault();
            ConsoleMethods.ShowTelephone("Newest Telephone:", phone);
        }

        public void AverageTelephones()
        {
            var telephone = from tel in telephones
                            orderby tel.price
                            select tel.price;
            decimal average = telephone.Average();
            ConsoleMethods.ShowDecimal("Average Telephone price:", average);
        }

        public void FiveCostlyTelephones()
        {
            var telephone = from tel in telephones
                            orderby tel.price descending
                            select tel;
            var five = telephone.Take(5);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("----Five Costly Telephones:");

            foreach (var tel in five)
            {
                ConsoleMethods.ShowTelephone("Pricy Telephones:", tel);
            }
        }

        public void FiveCheaperTelephones()
        {
            var telephone = from tel in telephones
                            orderby tel.price ascending
                            select tel;
            var five = telephone.Take(5);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("----Five Cheaper Telephones:");
            foreach (var tel in five)
            {
                ConsoleMethods.ShowTelephone("Cheap Telephones:", tel);
            }
        }

        public void ThreeOldestTelephones()
        {
            var telephone = from tel in telephones
                            orderby tel.data
                            select tel;
            var three = telephone.Take(3);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("----Three Oldest Telephones:");
            foreach (var tel in three)
            {
                ConsoleMethods.ShowTelephone("Oldest Telephone:", tel);
            }
        }

        public void ThreeNewestTelephones()
        {
            var telephone = from tel in telephones
                            orderby tel.data descending
                            select tel;
            var three = telephone.Take(3);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("----Three Newest Telephones:");
            foreach (var tel in three)
            {
                ConsoleMethods.ShowTelephone("Newest Telephones:", tel);
            }
        }

        public void StatisticsOnNuMTelephonesForEachManufacturer()
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            string manufacturer;
            foreach (var telephone in telephones)
            {
                manufacturer = telephone.manufacturer.ToLower();
                if (!dictionary.ContainsKey(manufacturer))
                {
                    dictionary.Add(manufacturer, 1);
                }
                else
                {
                    dictionary[manufacturer]++;
                }

            }
            ConsoleMethods.ShowDictionary("Statistics on the number of telephones for each manufacturer:", dictionary);
        }

        public void StatisticsOnNuMTelephonesModel()
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            string name;
            foreach (var telephone in telephones)
            {
                name = telephone.name.ToLower();
                if (!dictionary.ContainsKey(name))
                {
                    dictionary.Add(name, 1);
                }
                else
                {
                    dictionary[name]++;
                }

            }
            ConsoleMethods.ShowDictionary("Statistics on the number of telephone models:", dictionary);
        }
    }
}
