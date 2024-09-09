using System;
using System.Collections.Generic;

namespace IntroToDictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 2, 4, 9, 6, 5};
            int target = 7;
            Console.WriteLine("Check done using brute force");
            PrintArray(twoSumBrute(nums, target));
            Console.WriteLine("Check done using hash table/dictionary");
            PrintArray(twoSumHash(nums, target));
        }
        private static int[] twoSumBrute(int[] nums, int target)
        {
            //Does a brute force check to see if any number combination matches the target
            //Complexity of O(n^2)
            for(int i = 0; i < nums.Length - 1; i++)
            {
                for(int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                        return new int[] { i, j };
                }
            }
            return new int[] { -1, -1 };
        }
        //You can also sort the array and do a two point approach which has a complexity of O(log(n))
        //but I don't feel like coding that 
        private static int[] twoSumHash(int[] nums, int target)
        {
            //Holds key num and value index
            //Also called a hash table in other languages
            Dictionary<int, int> seen = new Dictionary<int, int>();
            
            for (int i = 0; i < nums.Length; i++)
            {
                //x + y = target
                //so y = target - x
                int diff = target - nums[i];
                if (seen.ContainsKey(diff))
                {
                    //Returns the index of the number previously seen in the list that adds up to the target with the current number
                    return new int[] { seen[diff], i};
                } else
                {
                    //This creates a new entry in the seen dictionary
                    seen[nums[i]] = i;
                }
            }
            //Returns this array when no combination in the array adds up to target
            return new int[] { -1, -1};
            //Assuming worst case scenario this function will have to check every item in the array only once giving it a complexity of O(n)
        }

        private static void PrintArray(int[] array)
        {
            bool first = true;
            Console.Write("[");
            foreach (int i in array)
            {
                if(!first)
                    Console.Write(",");
                Console.Write($" {i}");
                first = false;
            }
            Console.WriteLine(" ]");
        }
    }
}
