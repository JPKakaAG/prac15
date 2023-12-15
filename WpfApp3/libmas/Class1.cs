using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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

        /// <summary>
        /// Функция сохраняет двумерный массив
        /// </summary>
        /// <param name="array"> массив для сохранения</param>
        /// <param name="filePath">имя файла для сохранения</param>
        public static void Save2ArrayToFile(int[,] array, string filePath)
        {
            // Создаем новый экземпляр класса StreamWriter для записи в файл
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // Получаем размеры массива
                int rows = array.GetLength(0);
                int cols = array.GetLength(1);

                // Записываем размеры массива в первую строку файла
                writer.WriteLine($"{rows},{cols}");

                // Записываем значения элементов массива в оставшиеся строки файла
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        writer.Write($"{array[i, j]} ");
                    }
                    writer.WriteLine();
                }
            }
        }
        /// <summary>
        /// функция открывает массив из файла
        /// </summary>
        /// <param name="filePath">имя файла для открытия</param>
        /// <returns>array - массив</returns>
        public static int[,] Load2ArrayFromFile(string filePath)
        {
            // Создаем новый экземпляр класса StreamReader для чтения из файла
            using (StreamReader reader = new StreamReader(filePath))
            {
                // Читаем первую строку файла, содержащую размеры массива
                string[] size = reader.ReadLine().Split(',');
                int rows = int.Parse(size[0]);
                int cols = int.Parse(size[1]);

                // Создаем новый двумерный массив с заданными размерами
                int[,] array = new int[rows, cols];

                // Читаем оставшиеся строки файла, содержащие значения элементов массива
                for (int i = 0; i < rows; i++)
                {
                    string[] values = reader.ReadLine().Split(' ');
                    for (int j = 0; j < cols; j++)
                    {
                        array[i, j] = int.Parse(values[j]);
                    }
                }

                // Возвращаем загруженный массив
                return array;
            }
            
        }
        /// <summary>
        /// Функция заполянет массив  числами от 0 до 10
        /// </summary>
        /// <param name="array"> имя массива для заполнения</param>
        public static void Fill2Array(int[,] array)
        {
            // Получаем размеры массива
            int rows = array.GetLength(0);
            int cols = array.GetLength(1);
            Random rnd = new Random();

            // Заполняем массив заданным значением
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    array[i, j] = rnd.Next(0,10);
                }
            }
        }
        /// <summary>
        /// функция очищает массив
        /// </summary>
        /// <param name="array">имя массива для очищения</param>
        public static void Clear2Array(int[,] array)
        {
            // Получаем размеры массива
            int rows = array.GetLength(0);
            int cols = array.GetLength(1);

            // Очищаем массив, устанавливая все его элементы в ноль
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    array[i, j] = 0;
                }
            }
        }
        /// <summary>
        /// функция выводит значения двумерного массива в таблицу
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="matrix"> имя массива </param>
        /// <returns> res - результат </returns>
        public static DataTable ToDataTable<T>(this T[,] matrix)
        {
            var res = new DataTable();
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                res.Columns.Add("col" + (i + 1), typeof(T));
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var row = res.NewRow();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    row[j] = matrix[i, j];
                }

                res.Rows.Add(row);
            }

            return res;
        }
    }
}
