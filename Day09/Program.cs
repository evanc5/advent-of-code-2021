using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day07
{
    class Program
    {
        static void Main(string[] args)
        {
            Part1();
            Part2();
        }

        static void Part1()
        {
            var input = File.ReadAllLines(@".\input.txt");
            var sw = System.Diagnostics.Stopwatch.StartNew();

            var lines = new List<int[]>();
            foreach (var line in input)
            {
                var currentLine = new List<int>();
                foreach (var num in line)
                {
                    currentLine.Add(int.Parse(num.ToString()));
                }
                lines.Add(currentLine.ToArray());
            }
            var matrix = BuildMatrix(lines);

            var totalRisk = 0;
            for (int x = 0; x < matrix.GetLength(0); x++)
            {
                for (int y = 0; y < matrix.GetLength(1); y++)
                {
                    if (IsLowPoint(matrix, x, y))
                    {
                        totalRisk += matrix[x, y] + 1;
                    }
                }
            }

            sw.Stop();
            Console.WriteLine($"Part 1: {totalRisk}");
            System.Diagnostics.Debug.WriteLine($"Part 1: {sw.Elapsed}");
        }

        static void Part2()
        {
            var input = File.ReadAllLines(@".\input.txt");
            var sw = System.Diagnostics.Stopwatch.StartNew();

            var lines = new List<int[]>();
            foreach (var line in input)
            {
                var currentLine = new List<int>();
                foreach (var num in line)
                {
                    currentLine.Add(int.Parse(num.ToString()));
                }
                lines.Add(currentLine.ToArray());
            }
            var matrix = BuildMatrix(lines);

            sw.Stop();
            Console.WriteLine($"Part 2: ");
            System.Diagnostics.Debug.WriteLine($"Part 2: {sw.Elapsed}");
        }

        public static T[,] BuildMatrix<T>(IList<T[]> arrays)
        {
            var width = arrays[0].Length;
            T[,] matrix = new T[arrays.Count, width];
            for (int i = 0; i < arrays.Count; i++)
            {
                var array = arrays[i];
                if (array.Length != width)
                {
                    throw new ArgumentException("All arrays must be the same length.");
                }
                for (int j = 0; j < width; j++)
                {
                    matrix[i, j] = array[j];
                }
            }
            return matrix;
        }

        public static bool IsLowPoint(int[,] matrix, int x, int y)
        {
            var up = y - 1;
            var down = y + 1;
            var left = x - 1;
            var right = x + 1;

            if (up >= 0 && matrix[x, up] <= matrix[x, y] ||
                down < matrix.GetLength(1) && matrix[x, down] <= matrix[x, y] ||
                left >= 0 && matrix[left, y] <= matrix[x, y] ||
                right < matrix.GetLength(0) && matrix[right, y] <= matrix[x, y])
            {
                return false;
            }
            return true;
        }
    }
}
