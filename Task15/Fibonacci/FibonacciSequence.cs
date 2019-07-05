﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCaching;

namespace Fibonacci
{
    public class FibonacciSequence
    {
        private readonly ICaching cache;
        private const string FibonacciSequenceKey = "FibonacciSequence";

        public FibonacciSequence(ICaching cache)
        {
            this.cache = cache;
        }

        public List<int> GetFibonacciSequence(int quantity)
        {
            string key = FibonacciSequenceKey + quantity;

            List<int> sequence = cache.GetFromCache(key) as List<int>;

            if (sequence == null)
            {
                sequence = CreateFibonacciSequence(quantity);
                cache.PutToCache(key,sequence);
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
