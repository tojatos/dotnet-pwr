using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Lab9
{
    class Program
    {
        static void zad1()
        {
            // var path = Console.ReadLine();
            var path = "big.txt";
            var words = File.ReadAllText(path).Split();

            var selection =
                from word in words
                let matches = new Regex("^[a-zA-Z]+$").Matches(word)
                where matches.Count > 0
                let w = word.ToLower()
                group w by w into g
                orderby g.Count() descending
                select new {
                    Text = g.Key,
                    Count = g.Count(),
                };

            selection.Take(10).ToList().ForEach(Console.WriteLine);
        }
        static void Main(string[] args)
        {
            zad1();
        }
    }
}
