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
            return intArray.GroupBy()
        }

        public static University[] Linq2_1(University[] universityArray)
        {
            return universityArray.Where(u => u.Students.All(s => s.Gender.Equals(Gender.Male))).ToArray();
        }

        public static University[] Linq2_2(University[] universityArray)
        {
            throw new NotImplementedException();
        }

        public static Student[] Linq2_3(University[] universityArray)
        {
            throw new NotImplementedException();
        }
        public static Student[] Linq2_4(University[] universityArray)
        {
            throw new NotImplementedException();
        }
        public static Student[] Linq2_5(University[] universityArray)
        {
            throw new NotImplementedException();
        }
    }
}
