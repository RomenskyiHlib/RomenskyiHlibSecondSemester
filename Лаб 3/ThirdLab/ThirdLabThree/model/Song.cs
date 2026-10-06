using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdLabThree.model
{
    internal class Song
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Composer { get; set; }
        public int Year { get; set; }
        public string Lyrics { get; set; }
        public List<string> Performers { get; set; }

        public Song(string title, string author, string composer, int year, string lyrics, List<string> performers)
        {
            Title = title;
            Author = author;
            Composer = composer;
            Year = year;
            Lyrics = lyrics;
            Performers = performers;
        }

        public string ToShortString()
        {
            string PerformersString = (Performers != null && Performers.Count > 0)
                ? string.Join(", ", Performers) : "Unknown Artist";

            return $"\"{Title}\" by {PerformersString} (Author: {Author}, Composer: {Composer}, Year: {Year})";
        }

        public override string ToString()
        {
            string PerformersString = (Performers != null && Performers.Count > 0)
                ? string.Join(", ", Performers): "Unknown Artist";

            return $"\"{Title}\" by {PerformersString} (Author: {Author}, Composer: {Composer}, Year: {Year}) \n - Full Lyrics: \n{Lyrics}";
        }
    }
}
