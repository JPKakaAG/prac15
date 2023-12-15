using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libmas
{
    public static class ArrayUtils
    {
        // Сохранить массив в файл
        /// <summary>
        ///  Функция сохраняет массив в файл.
        /// </summary>
        /// <param name="filename">имя файла для сохранения</param>
        /// <param name="array">массив для сохранения</param>
        public static void SaveArray(string filename, int[] array)
        {

            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (int element in array)
                {
                    writer.Write(element + ",");
                }
            }
        }

        // Открыть массив из файла
        /// <summary>
        ///   Функция открывает массив из файла.
        /// </summary>
        /// <param name="filename">имя файла для открытия</param>
        /// <returns>int[]: открытый массив</returns>
        public static int[] OpenArray(string filename)
        {

            string[] values = File.ReadAllText(filename).Split(',');
            int[] array = new int[values.Length - 1]; // вычитаем 1, чтобы убрать последнюю пустую строку

            for (int i = 0; i < values.Length - 1; i++)
            {
                array[i] = int.Parse(values[i]);
            }

            return array;
        }

        // Заполнить массив случайными числами
        /// <summary>
        /// Функция заполняет массив случайными числами.
        /// </summary>
        /// <param name="array">массив для заполнения</param>
        /// <param name="size">размер массива</param>
        /// <param name="minVal">минимальное значение случайного числа</param>
        /// <param name="maxVal">максимальное значение случайного числа</param>
        /// <returns>void</returns>
        public static void FillArrayRandom(out int[] array2, int size, int minVal, int maxVal)
        {
            Random random = new Random();

            int[] array = new int[size];

            for (int i = 0; i < size; i++)
            {
                array[i] = random.Next(minVal, maxVal + 1);
            }
            array2 = array;
        }

        // Очистить массив
        /// <summary>
        ///  Функция очищает массив.
        /// </summary>
        /// <param name="array">массив для очистки</param>
        /// <returns>void</returns>
        public static void ClearArray(int[] array)
        {
            Array.Clear(array, 0, array.Length);
        }

        /// <summary>
        /// Функция заполняет таблицу значениями из массива
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr">массив для заполнения</param>
        /// <returns>res</returns>
        public static DataTable ToDataTable<T>(this T[] arr)
        {
            var res = new DataTable();
            for (int i = 0; i < arr.Length; i++)
            {
                res.Columns.Add("col" + (i + 1), typeof(T));
            }
            var row = res.NewRow();
            for (int i = 0; i < arr.Length; i++)
            {
                row[i] = arr[i];
            }
            res.Rows.Add(row);
            return res;
        }
    }
}
