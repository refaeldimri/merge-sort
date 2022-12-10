using System;
using System.Collections.Generic;
using System.Linq;

namespace Merge_sort
{
    /*
     * this program demonstrate merge sort algorithem which sorts array by complexity O(n * log n) worse case
     * the algorithem seperate array to two arrays equaly, 
     * until there are many arrays which each of them contains one element. (log n) complexity
     * in this point the algorithem comparison each element by size and merge them until get one sorted array.
     * 
     * 
     * the function MergeSort() get one unsorted list and seperate it equaly to 2 lists, 
     * each list contains one half from
     * the original list. each list move recursively to this function until there are arrays with one element. O(n)
     * 
     * the function Merge() merge the arrays to one sorted array.
     */
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * init a list and move it to 
             * MergeSort() function which sort it
             */
            List<int> listOfInteger = new List<int>()
            {45, 21, 87, 5, 78, 12, 54, 1, 0, 10};
            listOfInteger = MergeSort(listOfInteger);
            foreach (int i in listOfInteger)
            {
                Console.Write(i + " ");
            }
            Console.Write("\n");
        }


        private static List<int> MergeSort(List<int> unsorted)
        {
            /*
             * the function check if the list contains one or zero element
             * and return the list if is it.
             */
            if (unsorted.Count <= 1)
                return unsorted;
            /*
             * the function create 2 lists, left and right, 
             * each list contains the half part of the original list
             */
            List<int> left = new List<int>();
            List<int> right = new List<int>();

            // for loop init the left list with the left half of the list
            int middle = unsorted.Count / 2;
            for (int i = 0; i < middle; i++)  
            {
                left.Add(unsorted[i]);
            }
            // for loop init the right list with the right half of the list
            for (int i = middle; i < unsorted.Count; i++)
            {
                right.Add(unsorted[i]);
            }

            // each list move to MergeSort function() recursively
            left = MergeSort(left);
            right = MergeSort(right);
            return Merge(left, right);
        }

        /*
         * this Merge function which get 2 ordered lists and united them to one ordered list
         */
        private static List<int> Merge(List<int> left, List<int> right)
        {
            List<int> result = new List<int>();
            /*
             * while the lists does not empty, the function if there is elements in left or right list
             * and put them in the orderd list 
             */
            while (left.Count > 0 || right.Count > 0)
            {
                if (left.Count > 0 && right.Count > 0)
                {
                    if (left.First() <= right.First())
                    {
                        result.Add(left.First());
                        left.Remove(left.First());      
                    }
                    else
                    {
                        result.Add(right.First());
                        right.Remove(right.First());
                    }
                }
                else if (left.Count > 0)
                {
                    result.Add(left.First());
                    left.Remove(left.First());
                }
                else if (right.Count > 0)
                {
                    result.Add(right.First());

                    right.Remove(right.First());
                }
            }
            return result;
        }
    }
}