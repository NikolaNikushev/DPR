using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern
{
    class RequestGenerator
    {

        private Random random = new Random();
        private int count;
        private int min;
        private int max;

        public RequestGenerator(int p_count,int p_min,int p_max)
        {
            count = p_count;
            min = p_min;
            max = p_max;
        }

        /// <summary>
        /// Generate random unique numbers
        /// </summary>
        /// <returns>An int[]  array with unique random numbers</returns>
        public int[] GenerateRandom()
        {
            if (max <= min || count < 0 || (count > max - min && max - min > 0))
            {
                throw new ArgumentOutOfRangeException("Range " + min + " to " + max +
                        " (" + ((Int64)max - (Int64)min) + " values), or count " + count + " is illegal");
            }
            //All possible candidates that are available to be added and are not already added.
            HashSet<int> candidates = new HashSet<int>();
            for (int top = max - count; top < max; top++)
            {
                if (!candidates.Add(random.Next(min, top + 1)))
                {
                    candidates.Add(top);
                }
            }
            
            int[] result = candidates.ToArray();
            for (int i = result.Length - 1; i > 0; i--)
            {
                int k = random.Next(i + 1);
                int tmp = result[k];
                result[k] = result[i];
                result[i] = tmp;
            }
            return result;
        }

        /// <summary>
        /// Generates a new random number for the list of requests
        /// </summary>
        /// <param name="currentRequests">List of current requests that the system is using.</param>
        /// <returns>Returns a new unique number that can be added to the request list.</returns>
        public int GenerateRandomRequest(List<int> currentRequests)
        {
            int randomNumber = random.Next(0,100);
            while (currentRequests.Contains(randomNumber))
            {
                randomNumber = random.Next(0,100);
            }
           return randomNumber;           
        }
    }
}
