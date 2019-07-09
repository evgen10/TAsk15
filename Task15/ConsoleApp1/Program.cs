using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fibonacci;
using MyCaching;
using StackExchange.Redis;
using Logging;

namespace FibonacciApp
{
    class Program
    {
        private static ICaching<List<int>> caching;
        static void Main(string[] args)
        {
            Initialize();
            Start();
        }

        private static void Start()
        {
            if (caching != null)
            {
                FibonacciSequence fibonacciSequence = new FibonacciSequence(caching, new ConsoleLogger());

                while (true)
                {
                    Console.WriteLine("Enter count of Fibonacci sequence");
                    if (int.TryParse(Console.ReadLine(),out int result))
                    {
                        fibonacciSequence.GetFibonacciSequence(result).ForEach(i => Console.Write(i + " "));
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("No int value!");
                    }
                    

                   
                }
            }            
        }

        private static void Initialize()
        {
            Console.WriteLine("Press 1 to use InProccessCaching");
            Console.WriteLine("Press 2 to use RedisCaching");

            if (int.TryParse(Console.ReadLine(), out int result))
            {
                switch (result)
                {
                    case 1:
                        {
                            caching = new InProcessCaching<List<int>>();
                            break;
                        }
                    case 2:
                        {
                            caching = new RedisCaching<List<int>>("localhost");
                            break;
                        }               

                    default:
                        break;
                }

            }
            
               



        }
    }
}
