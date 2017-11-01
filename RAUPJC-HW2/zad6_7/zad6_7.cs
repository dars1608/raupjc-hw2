using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad6_7
{
    class zad6_7 {

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

        private static async void LetsSayUserClickedAButtonOnGuiMethod()
        {
            var result = await GetTheMagicNumber();
            Console.WriteLine(result);
        }

        private static async Task<int> GetTheMagicNumber()
        {
            return await Task.Run(() => IKnowIGuyWhoKnowsAGuy());
        }

        private static async Task<int> IKnowIGuyWhoKnowsAGuy()
        {
            int ret1 = await Task.Run(() => IKnowWhoKnowsThis(10));
            int ret2 = await Task.Run(() => IKnowWhoKnowsThis(5));
            return ret1 + ret2;
        }

        private static async Task<int> IKnowWhoKnowsThis(int n)
        {
            return await FactorialDigitSum(n);
        }

        // Ignore this part .
        static void Main(string[] args)
        {
            // Main method is the only method that
            // can ’t be marked with async .
            // What we are doing here is just a way for us to simulate
            // async - friendly environment you usually have with
            // other . NET application types ( like web apps , win apps etc .)
            // Ignore main method , you can just focus on
            //LetsSayUserClickedAButtonOnGuiMethod() as a
            // first method in the call hierarchy .
            var t = Task.Run(() => LetsSayUserClickedAButtonOnGuiMethod());
            Console.Read();
        }
    }
}
