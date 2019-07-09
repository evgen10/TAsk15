using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCaching;
using Logging;

namespace Fibonacci
{
    public class FibonacciSequence
    {
        private readonly ICaching<List<int>> cache;
        private const string FibonacciSequenceKey = "FibonacciSequence";
        private readonly ILogger logger;
        public FibonacciSequence(ICaching<List<int>> cache, ILogger logger)
        {
            this.cache = cache;
            this.logger = logger;
        }

        public List<int> GetFibonacciSequence(int quantity)
        {
            string key = FibonacciSequenceKey + quantity;

            List<int> sequence = cache.GetFromCache(key);

            if (sequence == null)
            {
                sequence = CreateFibonacciSequence(quantity);
                cache.PutToCache(key,sequence);
                logger.Log("Sequance is generated.");  
            }
            else
            {
                logger.Log("Sequance is from cache.");
            }

            return sequence;
        }

        private List<int> CreateFibonacciSequence(int quantity)
        {
            List<int> sequence = new List<int>();

            int firstNum = 0;
            int secondNum = 1;
            int count = 1;
         
            sequence.Add(secondNum);

            while (quantity != count)
            {
                int sum = firstNum + secondNum;

                firstNum = secondNum;
                secondNum = sum;

                sequence.Add(secondNum);

                count++;
            }

            return sequence;
        }
    }
}
