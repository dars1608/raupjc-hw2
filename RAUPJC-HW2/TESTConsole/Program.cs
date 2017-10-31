using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TESTConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] integers = new[] { 1, 3, 3, 4, 2, 2, 2, 3, 3, 4, 5 };
            var a = integers.GroupBy(i => i).OrderBy(i => i.First()).Select(i => $"Broj {i.First()} ponavlja se {i.Count()} puta").ToArray();
            foreach (var i in a)
            {
                Console.WriteLine(i);
            } 
            Console.ReadLine();
        }
    }
}
