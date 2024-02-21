using System;

namespace rps2
{
    internal class Sort
    {
        public static int[] SortEvenOdd2(int[] array, int[] sortedList)
        {
            Array.Copy(array, sortedList, array.Length);

            int left = 0;
            int right = sortedList.Length - 1;

            while (left < right)
            {
                while (sortedList[left] % 2 == 0 && left < right)
                {
                    left++;
                }

                while (sortedList[right] % 2 != 0 && left < right)
                {
                    right--;
                }

                if (left < right)
                {
                    int temp = sortedList[left];
                    sortedList[left] = sortedList[right];
                    sortedList[right] = temp;
                    left++;
                    right--;
                }
            }

            return sortedList;
        }
    }
}
