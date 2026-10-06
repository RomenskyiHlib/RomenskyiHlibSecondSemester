using SecondLab.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondLab.Utility
{
    internal class ListFiller
    {
        public static List<Firm> Filler()
        {

            return new List<Firm>() {new Firm("Nonia", new DateOnly(1999, 12, 10), Focus.it, "Romenskyi Hlib", 200, "London"),
                   new Firm("Pineapple", new DateOnly(1800, 04, 2), Focus.marketing, "Black Jack", 1000, "Kyiv"),
                   new Firm("Samsing", new DateOnly(2010, 04, 30), Focus.it, "Cubera Artem", 20, "Vienna"),
                   new Firm("Leho", new DateOnly(1798, 10, 20), Focus.toys, "Jeremy Jeremy", 200, "Poltava"),
                   new Firm("Food", new DateOnly(2026, 09, 23), Focus.it, "Well Ihor", 90, "Kharkiv"),
                   new Firm("Subanu", new DateOnly(2000, 12, 29), Focus.food, "White Blue", 90, "Kharkiv") };
        }
    }
}
