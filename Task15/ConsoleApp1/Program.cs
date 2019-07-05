using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fibonacci;
using MyCaching;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            FibonacciSequence fibonacciSequence = new FibonacciSequence(new RedisCaching("localhost"));

            while (true)
            {
                int count = int.Parse(Console.ReadLine());

                fibonacciSequence.GetFibonacciSequence(count).ForEach(i => Console.Write(i+" "));
                Console.WriteLine();
                
            }

        }
    }
}
