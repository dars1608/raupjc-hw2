﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TESTConsole
{
    class Program
    {
        private static object _lock = new object();

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

        public async static void TestAsyncAwaitMethods()
        {
            int ret = await FactorialDigitSum(3);
            Console.WriteLine(ret);

        }

        static void Main(string[] args)
        {
            TestAsyncAwaitMethods();

            Console.ReadLine();
        }
    }
}