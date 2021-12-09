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
            for (int y = 0; y < matrix.GetLength(1); y++)
            {
                for (int x = 0; x < matrix.GetLength(0); x++)
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

            var basinFinder = new BasinFinder(lines);
            var sizes = basinFinder.GetLargest(3);

            var total = 1;
            foreach (var size in sizes)
            {
                total *= size;
            }

            sw.Stop();
            Console.WriteLine($"Part 2: {total}");
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

    public class BasinFinder
    {
        public Point[,] Points { get; }
        private int currentSize;

        public BasinFinder(List<int[]> arrays)
        {
            var width = arrays[0].Length;
            Points = new Point[arrays.Count, width];
            for (int y = 0; y < arrays.Count; y++)
            {
                var array = arrays[y];
                for (int x = 0; x < width; x++)
                {
                    Points[x, y] = new Point(x, y, array[x]);
                }
            }
        }

        public int[] GetLargest(int n)
        {
            var sizes = new int[n];

            for (int y = 0; y < Points.GetLength(1); y++)
            {
                for (int x = 0; x < Points.GetLength(0); x++)
                {
                    if (Points[x, y].Filled) continue;
                    currentSize = 0;
                    FloodFill(x, y);

                    if (currentSize > sizes.Min())
                    {
                        var newSizes = sizes.ToList();
                        newSizes.Add(currentSize);
                        sizes = newSizes.OrderByDescending(i => i).Take(n).ToArray();
                    }
                }
            }

            return sizes;
        }

        private void FloodFill(int x, int y)
        {
            if (x >= Points.GetLength(0) ||
                y >= Points.GetLength(1) ||
                x < 0 || y < 0 ||
                Points[x, y].Filled)
            {
                return;
            }

            Points[x, y].Filled = true;
            currentSize++;

            FloodFill(x + 1, y);
            FloodFill(x - 1, y);
            FloodFill(x, y + 1);
            FloodFill(x, y - 1);
        }
    }

    public struct Point
    {
        public readonly int x;
        public readonly int y;

        public readonly int height;

        public bool Filled { get; set; }

        public Point(int x, int y, int height)
        {
            this.x = x;
            this.y = y;
            this.height = height;
            Filled = height == 9;
        }
    }
}
