using System;
using System.Collections.Generic;
using System.Linq;

namespace HowManyPairsofSocks
{
    class Program
    {
        public static int pairsCounter(List<int> socks) /* This method calculates the number of pairs
                                                         using based on the list of integers. */
        {
            var query = socks.GroupBy(x => x) /* Calculate for each value and how many times they appear. */
                  .Where(g => g.Count() > 1) /* It filters/gets values that appear two times and more .*/
                  .Select(y => new { Element = y.Key, Counter = y.Count() / 2 }) /*Divides by 2 to get the number of pairs. Store values into elements and sorts the number of pairs into Counter. */
                  .ToList(); /* Converts everything into a list. */
            int sum = 0; /* Get the sum of pairs by declaring a sum.*/
            foreach (var item in query) 
            {
                sum += item.Counter;  /*Sum up the pairs.*/          
            }
            return sum; /* Return number of pairs*/


        }
        public static int pairsCounter(string socksString) /*Method calculates the number of pair based on the string of integers. */
        {
            List<int> socks = new List<int>(); /*Creating an empty list. */
            string[] split = socksString.Split(' '); /*Separating the string into single values using space.*/

            foreach (var item in split) /*For each string value*/
            {
                socks.Add(Int16.Parse(item)); /*Convert the value into an integer and storing in the list*/
            }
            return pairsCounter(socks); /*Calling the previous method using the list. */
        }
        static void Main(string[] args)
        {
            List<int> socks = new() { 1, 2, 1, 2, 1, 3, 2}; /*List of integers. */
            Console.WriteLine(pairsCounter(socks)); /*Calculate number of pairs using the first method. */
            Console.WriteLine(pairsCounter("10 20 20 10 10 30 50 10 20")); /* Calculating the number of pairs using string of values.*/
        }
    }
}
