using System;
using System.Collections.Generic;
using System.Reflection;

namespace Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Question 1: Find Missing Numbers in Array
            Console.WriteLine("Question 1:");
            int[] nums1 = { 4, 3, 2, 7, 8, 2, 3, 1 };
            IList<int> missingNumbers = FindMissingNumbers(nums1);
            Console.WriteLine(string.Join(",", missingNumbers));

            // Question 2: Sort Array by Parity
            Console.WriteLine("Question 2:");
            int[] nums2 = { 0, 1, 2 };
            int[] sortedArray = SortArrayByParity(nums2);
            Console.WriteLine(string.Join(",", sortedArray));

            // Question 3: Two Sum
            Console.WriteLine("Question 3:");
            int[] nums3 = { 2, 7, 11, 15 };
            int target = 9;
            int[] indices = TwoSum(nums3, target);
            Console.WriteLine(string.Join(",", indices));

            // Question 4: Find Maximum Product of Three Numbers
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 2, 3, 4 };
            int maxProduct = MaximumProduct(nums4);
            Console.WriteLine(maxProduct);

            // Question 5: Decimal to Binary Conversion
            Console.WriteLine("Question 5:");
            int decimalNumber = 42;
            string binary = DecimalToBinary(decimalNumber);
            Console.WriteLine(binary);

            // Question 6: Find Minimum in Rotated Sorted Array
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3, 4, 5, 1, 2 };
            int minElement = FindMin(nums5);
            Console.WriteLine(minElement);

            // Question 7: Palindrome Number
            Console.WriteLine("Question 7:");
            int palindromeNumber = 121;
            bool isPalindrome = IsPalindrome(palindromeNumber);
            Console.WriteLine(isPalindrome);

            // Question 8: Fibonacci Number
            Console.WriteLine("Question 8:");
            int n = 4;
            int fibonacciNumber = Fibonacci(n);
            Console.WriteLine(fibonacciNumber);
        }

        // Question 1: Find Missing Numbers in Array
        public static IList<int> FindMissingNumbers(int[] nums)
        {
            try
            {
                // Initializing result list to store missing numbers
                List<int> missingNumbers = new List<int>();

                // Getting length of array
                int n = nums.Length;

                // Step 1: Marking visited elements
                // I will use the array itself to mark visited numbers
                // For each number i, I'll make nums[i-1] negative
                for (int i = 0; i < n; i++)
                {
                    // Getting the absolute value since number might already be negative
                    int num = Math.Abs(nums[i]);
                    // Subtracting 1 because array is 0-based but numbers start from 1
                    int index = num - 1;

                    // Making the number at index negative to mark as visited
                    // Only if it's positive (to avoid marking twice)
                    if (nums[index] > 0)
                    {
                        nums[index] = -nums[index];
                    }
                }

                // Step 2: Finding missing numbers
                // If a number at index i is positive, then i+1 is missing
                for (int i = 0; i < n; i++)
                {
                    if (nums[i] > 0)
                    {
                        // Adding missing number (i+1) to result
                        missingNumbers.Add(i + 1);
                    }
                }

                return missingNumbers;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 2: Sort Array by Parity

        public static int[] SortArrayByParity(int[] nums)
        {
            try
            {

                // Create new array for result
                int[] result = new int[nums.Length];
                int evenIndex = 0;
                int oddIndex = nums.Length - 1;

                // First pass: collect even numbers in order
                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] % 2 == 0)
                    {
                        result[evenIndex++] = nums[i];
                    }
                }

                // Second pass: collect odd numbers in original order
                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] % 2 == 1)
                    {
                        result[oddIndex--] = nums[i];
                    }
                }

                // Copy result back to original array
                for (int i = 0; i < nums.Length; i++)
                {
                    nums[i] = result[i];
                }

                return nums;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 3: Two Sum
        public static int[] TwoSum(int[] nums, int target)
        {
            try
            {
                // Using Dictionary to store complements
                Dictionary<int, int> numMap = new Dictionary<int, int>();

                // Iterating through array once
                for (int i = 0; i < nums.Length; i++)
                {
                    int complement = target - nums[i];

                    // If complement exists in map, we found our pair
                    if (numMap.ContainsKey(complement))
                    {
                        return new int[] { numMap[complement], i };
                    }

                    // Adding current number and its index to map if not already present
                    if (!numMap.ContainsKey(nums[i]))
                    {
                        numMap.Add(nums[i], i);
                    }
                }

                // No solution found
                return new int[0];
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 4: Find Maximum Product of Three Numbers
        public static int MaximumProduct(int[] nums)
        {
            try
            {
                // Sorting array to get largest and smallest numbers
                Array.Sort(nums);
                int n = nums.Length;

                // Return max of:
                // 1. Product of three largest numbers
                // 2. Product of two smallest numbers (could be negative) and largest number
                return Math.Max(
                    nums[n - 1] * nums[n - 2] * nums[n - 3],
                    nums[0] * nums[1] * nums[n - 1]
                );
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 5: Decimal to Binary Conversion
        public static string DecimalToBinary(int decimalNumber)
        {
            try
            {
                if (decimalNumber == 0)
                    return "0";

                // Using StringBuilder for efficient string manipulation
                System.Text.StringBuilder binary = new System.Text.StringBuilder();

                while (decimalNumber > 0)
                {
                    // Adding remainder (0 or 1) to start of string
                    binary.Insert(0, decimalNumber % 2);
                    decimalNumber /= 2;
                }

                return binary.ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 6: Find Minimum in Rotated Sorted Array
        public static int FindMin(int[] nums)
        {
            try
            {
                int left = 0;
                int right = nums.Length - 1;

                // If array is not rotated
                if (nums[left] <= nums[right])
                    return nums[left];

                // Binary search
                while (left < right)
                {
                    int mid = left + (right - left) / 2;

                    // If mid element is greater than next element
                    if (nums[mid] > nums[mid + 1])
                        return nums[mid + 1];

                    // If mid element is less than previous element
                    if (nums[mid - 1] > nums[mid])
                        return nums[mid];

                    // If mid element is greater than left element
                    if (nums[left] <= nums[mid])
                        left = mid + 1;
                    else
                        right = mid - 1;
                }

                return nums[0];
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 7: Palindrome Number
        public static bool IsPalindrome(int x)
        {
            try
            {
                // Write your code here
                return false; // Placeholder
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 8: Fibonacci Number
        public static int Fibonacci(int n)
        {
            try
            {
                // Write your code here
                return 0; // Placeholder
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
