using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace YaContest
{
    /// <summary>
    /// На каждую задачу ограничение по времени 1 сек., ограничение по памяти 10mb
    /// </summary>
    public class Solution
    {
        /// <summary>
        /// Камни и украшения.
        /// Даны две строки строчных латинских символов: строка J и строка S, проверить, какое количество символов из S входит в J.
        /// </summary>
        static void ContainsCharacters()
        {
            string j = Console.ReadLine();
            string s = Console.ReadLine();

            if (string.IsNullOrEmpty(j) ||
                string.IsNullOrEmpty(s))
            {
                Console.WriteLine(0);
                return;
            }

            int result = 0;
            foreach (char ch in s)
            {
                if (j.IndexOf(ch) >= 0)
                {
                    ++result;
                }
            }

            Console.WriteLine(result);
        }

        /// <summary>
        /// Последовательно идущие единицы.
        /// Требуется найти в бинарном векторе самую длинную последовательность единиц и вывести её длину.
        /// </summary>
        static void SubsequentUnits()
        {
            var size = int.Parse(Console.ReadLine());
            var sourceArray = new int[size];
            for (int i = 0; i < size; i++)
            {
                sourceArray[i] = int.Parse(Console.ReadLine());
            }

            int counter = 0;
            int maxValue = 0;
            for (int i = 0; i < sourceArray.Length; i++)
            {
                if (sourceArray[i] == 1)
                {
                    ++counter;
                    maxValue = counter > maxValue ? counter : maxValue;
                    continue;
                }

                counter = 0;
            }

            Console.WriteLine(maxValue);
        }

        /// <summary>
        /// Удаление дубликатов.
        /// Дан упорядоченный по неубыванию массив целых 32-разрядных чисел. Требуется удалить из него все повторения,
        /// используя лишь константный объем памяти в процессе работы.
        /// </summary>
        /// <param name="args"></param>
        static void DuplicateRemoval(string[] args)
        {
            var size = int.Parse(Console.ReadLine());
            var sourceArray = new List<int>();
            var lastItem = 0;
            for (int i = 0; i < size; i++)
            {
                var item = int.Parse(Console.ReadLine());

                if (!sourceArray.Any() || lastItem != item)
                {
                    lastItem = item;
                    sourceArray.Add(item);
                }
            }

            for (int i = 0; i < sourceArray.Count; i++)
            {
                Console.WriteLine(sourceArray[i]);
            }
        }

        /// <summary>
        /// Генерация скобочных последовательностей.
        /// </summary>
        static void Generator()
        {
            var n = int.Parse(Console.ReadLine());
            GenerateStr(string.Empty, 0, 0, n);
        }

        static void GenerateStr(string str, int left, int right, int n)
        {
            if (left == n && right == n)
            {
                Console.WriteLine(str);
                return;
            }

            if (left < n)
            {
                GenerateStr(str + "(", left + 1, right, n);
            }

            if (right < left)
            {
                GenerateStr(str + ")", left, right + 1, n);
            }
        }

        /// <summary>
        /// Анаграммы.
        /// </summary>
        static void CheckAnagrams()
        {
            var firstStr = Console.ReadLine();
            var secondStr = Console.ReadLine();

            if (string.IsNullOrEmpty(firstStr) ||
                string.IsNullOrEmpty(secondStr) ||
                firstStr.Length != secondStr.Length)
            {
                Console.WriteLine(0);
                return;
            }

            var first = String.Concat(firstStr.ToLower().OrderBy(x => x));
            var second = String.Concat(secondStr.ToLower().OrderBy(x => x));

            var result = first == second ? 1 : 0;

            Console.WriteLine(result);
        }

        /// <summary>
        /// Слияние k отсортированных массивов
        /// </summary>
        static void MergerKArrays()
        {
            var countOfArrays = short.Parse(Console.ReadLine());

            var valuesList = new short[101];
            for (int i = 0; i < countOfArrays; i++)
            {
                var selectedArray = Console.ReadLine().Split(' ');
                for (int j = 1; j < selectedArray.Length; j++)
                {
                    valuesList[short.Parse(selectedArray[j])]++;
                }

                GC.Collect();
            }

            using var writer = new StreamWriter("output.txt");
            for (int i = 0; i < valuesList.Length; i++)
            {
                for (int j = 0; j < valuesList[i]; j++)
                {
                    writer.Write($"{i} ");
                }
            }
        }
    }
}
