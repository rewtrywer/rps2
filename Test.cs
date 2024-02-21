using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace rps2
{
    internal class Test
    {
        public static bool test1()
        {
            int[] array = new int[] { 1, 2, 3, 4, 5 };
            int[] sortArray = new int[] { 4, 2, 3, 1, 5 };
            int[] sortArrayCalc = Sort.SortEvenOdd2(array, sortArray);

            bool areEqual = sortArray.SequenceEqual(sortArrayCalc);
            return areEqual;
        }
    }
}
