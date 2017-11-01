using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zad1;

namespace zad4
{
    public class HomeworkLinqQueries
    {
        public static string[] Linq1(int[] intArray)
        {
            return intArray.GroupBy(i => i).OrderBy(i=>i.First()).Select(i => $"Broj {i.First()} ponavlja se {i.Count()} puta").ToArray();
        }

        public static University[] Linq2_1(University[] universityArray)
        {
            return universityArray.Where(u => u.Students.All(s => s.Gender.Equals(Gender.Male))).ToArray();
        }

        public static University[] Linq2_2(University[] universityArray)
        {
            return universityArray.Where(i => i.Students.Count() < universityArray.Average(j => j.Students.Count())).ToArray();
        }

        public static Student[] Linq2_3(University[] universityArray)
        {
            return universityArray.SelectMany(i => i.Students).Distinct().ToArray();
        }
        public static Student[] Linq2_4(University[] universityArray)
        {
            return universityArray.Where(u => u.Students.All(s => s.Gender.Equals(Gender.Male)) || u.Students.All(s => s.Gender.Equals(Gender.Female)))
                .SelectMany(i => i.Students.Select(j => j)).Distinct().ToArray();
        }
        public static Student[] Linq2_5(University[] universityArray)
        {
            return universityArray.SelectMany(i => i.Students.Where(j => universityArray.Where(k => k.Students.Contains(j)).Count() > 1)).Distinct().ToArray();
        }
    }
}
