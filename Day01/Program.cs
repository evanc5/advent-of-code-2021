﻿using System;
using System.IO;
using System.Linq;

namespace Day01
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

            var count = 0;
            var depths = input.Select(depth => int.Parse(depth));
            var previousDepth = depths.First();
            foreach (var depth in depths)
            {
                if (depth > previousDepth) count++;
                previousDepth = depth;
            }

            Console.WriteLine($"Part 1: {count}");

            sw.Stop();
            System.Diagnostics.Debug.WriteLine($"Part 1: {sw.Elapsed}");
        }

        static void Part2()
        {
            var input = File.ReadAllLines(@".\input.txt");
            var sw = System.Diagnostics.Stopwatch.StartNew();

            var count = 0;
            var depths = input.Select(depth => int.Parse(depth)).ToArray();
            for (int i = 0; i + 3 < depths.Length; i++)
            {
                if (depths[i + 3] > depths[i]) count++;
            }

            Console.WriteLine($"Part 2: {count}");

            sw.Stop();
            System.Diagnostics.Debug.WriteLine($"Part 2: {sw.Elapsed}");
        }
    }
}
