using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day05
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

            var matrix = new int[1000, 1000];

            foreach (var line in input)
            {
                var split = line.Split(" -> ");
                var origin = split[0].Split(',').Select(int.Parse).ToArray();
                var dest = split[1].Split(',').Select(int.Parse).ToArray();

                if (origin[0] == dest[0])
                {
                    var min = Math.Min(origin[1], dest[1]);
                    var max = Math.Max(origin[1], dest[1]);
                    for (int i = min; i <= max; i++)
                    {
                        matrix[origin[0], i]++;
                    }
                }
                else if (origin[1] == dest[1])
                {
                    var min = Math.Min(origin[0], dest[0]);
                    var max = Math.Max(origin[0], dest[0]);
                    for (int i = min; i <= max; i++)
                    {
                        matrix[i, origin[1]]++;
                    }
                }
                else
                {
                }
            }

            sw.Stop();
            var count = 0;
            foreach (var point in matrix)
            {
                if (point >= 2) count++;
            }
            Console.WriteLine($"Part 1: {count}");
            System.Diagnostics.Debug.WriteLine($"Part 1: {sw.Elapsed}");
        }

        static void Part2()
        {
            var input = File.ReadAllLines(@".\input.txt");
            var sw = System.Diagnostics.Stopwatch.StartNew();

            var matrix = new int[1000, 1000];

            foreach (var line in input)
            {
                var split = line.Split(" -> ");
                var origin = split[0].Split(',').Select(int.Parse).ToArray();
                var dest = split[1].Split(',').Select(int.Parse).ToArray();

                if (origin[0] == dest[0])
                {
                    var min = Math.Min(origin[1], dest[1]);
                    var max = Math.Max(origin[1], dest[1]);
                    for (int i = min; i <= max; i++)
                    {
                        matrix[origin[0], i]++;
                    }
                }
                else if (origin[1] == dest[1])
                {
                    var min = Math.Min(origin[0], dest[0]);
                    var max = Math.Max(origin[0], dest[0]);
                    for (int i = min; i <= max; i++)
                    {
                        matrix[i, origin[1]]++;
                    }
                }
                else
                {
                    var length = Math.Abs(origin[0] - dest[0]);
                    var xSlope = (int)Math.CopySign(1, dest[0] - origin[0]);
                    var ySlope = (int)Math.CopySign(1, dest[1] - origin[1]);

                    for (int i = 0; i <= length; i++)
                    {
                        matrix[origin[0], origin[1]]++;
                        origin[0] += xSlope;
                        origin[1] += ySlope;
                    }
                }
            }

            sw.Stop();
            var count = 0;
            foreach (var point in matrix)
            {
                if (point >= 2) count++;
            }
            Console.WriteLine($"Part 2: {count}");
            System.Diagnostics.Debug.WriteLine($"Part 2: {sw.Elapsed}");
        }
    }
}
