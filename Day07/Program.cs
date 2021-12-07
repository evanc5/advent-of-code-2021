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
            var input = File.ReadAllText(@".\input.txt").Split(',');
            var sw = System.Diagnostics.Stopwatch.StartNew();

            var positions = input.Select(int.Parse);
            var median = positions.GetMedian();
            var fuel = 0;
            foreach (var pos in positions)
            {
                fuel += Math.Abs(pos - median);
            }

            sw.Stop();
            Console.WriteLine($"Part 1: {fuel}");
            System.Diagnostics.Debug.WriteLine($"Part 1: {sw.Elapsed}");
        }

        static void Part2()
        {
            var input = File.ReadAllText(@".\input.txt").Split(',');
            var sw = System.Diagnostics.Stopwatch.StartNew();


            sw.Stop();
            System.Diagnostics.Debug.WriteLine($"Part 2: {sw.Elapsed}");
        }
    }

    public static class CollectionExtensions
    {
        public static T GetMedian<T>(this IEnumerable<T> collection)
        {
            var list = collection.ToList();
            list.Sort();
            return list[list.Count / 2];
        }
    }
}
