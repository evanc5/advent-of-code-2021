using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day13
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

            var maxX = 0;
            var maxY = 0;
            foreach (var line in input)
            {
                if (string.IsNullOrWhiteSpace(line)) break;
                var split = line.Split(',').Select(int.Parse).ToArray();
                maxX = Math.Max(maxX, split[0]);
                maxY = Math.Max(maxY, split[1]);
            }

            var matrix = new bool[maxX + 2, maxY + 2];
            foreach (var line in input)
            {
                if (string.IsNullOrWhiteSpace(line)) break;
                var split = line.Split(',').Select(int.Parse).ToArray();
                matrix[split[0], split[1]] = true;
            }

            bool[,] newMatrix;
            foreach (var line in input.Where(l => l.Contains("fold")))
            {
                var instruction = line.Replace("fold along ", "").Split('=');
                var direction = instruction[0];
                var amount = int.Parse(instruction[1]);

                if (direction == "x")
                {
                    newMatrix = new bool[matrix.GetLength(0) - amount, matrix.GetLength(1)];
                    for (int distance = 1; distance < newMatrix.GetLength(0); distance++)
                    {
                        var leftX = amount - distance;
                        var rightX = amount + distance;
                        var currentX = newMatrix.GetLength(0) - distance;
                        for (int y = 0; y < newMatrix.GetLength(1); y++)
                        {
                            var leftFilled = false;
                            var rightFilled = false;
                            if (leftX >= 0) leftFilled = matrix[leftX, y];
                            if (rightX < matrix.GetLength(0)) rightFilled = matrix[rightX, y];
                            newMatrix[currentX, y] = leftFilled || rightFilled;
                        }
                    }
                }
                else
                {
                    newMatrix = new bool[matrix.GetLength(0), matrix.GetLength(1) - amount];
                    for (int distance = 1; distance < newMatrix.GetLength(1); distance++)
                    {
                        var topY = amount - distance;
                        var bottomY = amount + distance;
                        var currentY = newMatrix.GetLength(1) - distance;
                        for (int x = 0; x < newMatrix.GetLength(0); x++)
                        {
                            var topFilled = false;
                            var bottomFilled = false;
                            if (topY >= 0) topFilled = matrix[x, topY];
                            if (bottomY < matrix.GetLength(1)) bottomFilled = matrix[x, bottomY];
                            newMatrix[x, currentY] = topFilled || bottomFilled;
                        }
                    }
                }
                matrix = newMatrix;
                break;
            }

            var count = 0;
            foreach (var x in matrix)
            {
                if (x) count++;
            }

            sw.Stop();
            Console.WriteLine($"Part 1: {count}");
            System.Diagnostics.Debug.WriteLine($"Part 1: {sw.Elapsed}");
        }

        static void Part2()
        {
            var input = File.ReadAllLines(@".\input.txt");
            var sw = System.Diagnostics.Stopwatch.StartNew();

            var maxX = 0;
            var maxY = 0;
            foreach (var line in input)
            {
                if (string.IsNullOrWhiteSpace(line)) break;
                var split = line.Split(',').Select(int.Parse).ToArray();
                maxX = Math.Max(maxX, split[0]);
                maxY = Math.Max(maxY, split[1]);
            }

            var matrix = new bool[maxX + 2, maxY + 2];
            foreach (var line in input)
            {
                if (string.IsNullOrWhiteSpace(line)) break;
                var split = line.Split(',').Select(int.Parse).ToArray();
                matrix[split[0], split[1]] = true;
            }

            bool[,] newMatrix;
            foreach (var line in input.Where(l => l.Contains("fold")))
            {
                var instruction = line.Replace("fold along ", "").Split('=');
                var direction = instruction[0];
                var amount = int.Parse(instruction[1]);

                if (direction == "x")
                {
                    newMatrix = new bool[matrix.GetLength(0) - amount, matrix.GetLength(1)];
                    for (int distance = 1; distance < newMatrix.GetLength(0); distance++)
                    {
                        var leftX = amount - distance;
                        var rightX = amount + distance;
                        var currentX = newMatrix.GetLength(0) - distance;
                        for (int y = 0; y < newMatrix.GetLength(1); y++)
                        {
                            var leftFilled = false;
                            var rightFilled = false;
                            if (leftX >= 0) leftFilled = matrix[leftX, y];
                            if (rightX < matrix.GetLength(0)) rightFilled = matrix[rightX, y];
                            newMatrix[currentX, y] = leftFilled || rightFilled;
                        }
                    }
                }
                else
                {
                    newMatrix = new bool[matrix.GetLength(0), matrix.GetLength(1) - amount];
                    for (int distance = 1; distance < newMatrix.GetLength(1); distance++)
                    {
                        var topY = amount - distance;
                        var bottomY = amount + distance;
                        var currentY = newMatrix.GetLength(1) - distance;
                        for (int x = 0; x < newMatrix.GetLength(0); x++)
                        {
                            var topFilled = false;
                            var bottomFilled = false;
                            if (topY >= 0) topFilled = matrix[x, topY];
                            if (bottomY < matrix.GetLength(1)) bottomFilled = matrix[x, bottomY];
                            newMatrix[x, currentY] = topFilled || bottomFilled;
                        }
                    }
                }
                matrix = newMatrix;
            }

            Console.WriteLine("Part 2:");
            for (int y = 0; y < matrix.GetLength(1); y++)
            {
                for (int x = 0; x < matrix.GetLength(0); x++)
                {
                    if (matrix[x, y]) Console.Write("#");
                    else Console.Write(".");
                }
                Console.Write("\n");
            }

            sw.Stop();
            System.Diagnostics.Debug.WriteLine($"Part 2: {sw.Elapsed}");
        }
    }
}
