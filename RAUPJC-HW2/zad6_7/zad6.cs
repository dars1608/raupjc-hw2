using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad6_7
{
    class zad6 {

        private static async Task<int> FactorialDigitSum(int n)
        {
            int sum = 0;
            for (int i = 1; i <= n; i++)
            {
                int result = await Task.Run(() => Factorial(i));
                sum += result;

            }

            return sum;

        }


        private static int Factorial(int no)
        {
            int result = 1;
            for (int i = 1; i <= no; i++)
            {
                result = result * i;
            }
            return result;
        }
    }
}
