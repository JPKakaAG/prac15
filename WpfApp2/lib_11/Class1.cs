using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_11
{
    public class v11
    {
        /// <summary>
        /// Функция находит разницу между элементами массива
        /// </summary>
        /// <param name="numbers">массив для вычисления</param>
        /// <returns>result</returns>
        public static int CalculateDifference(int[] numbers)
        {
            if (numbers.Length == 0)
                return 0;

            int result = numbers[0];

            for (int i = 1; i < numbers.Length; i++)
            {
                result -= numbers[i];
            }

            return result;
        }



    }
}
