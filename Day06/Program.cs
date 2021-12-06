using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day06
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
            var input = File.ReadAllText(@".\input.txt");
            var sw = System.Diagnostics.Stopwatch.StartNew();

            var fishList = input.Split(',').Select(int.Parse).ToList();

            for (int day = 0; day < 80; day++)
            {
                var count = fishList.Count;
                for (int i = 0; i < count; i++)
                {
                    if (fishList[i] == 0)
                    {
                        fishList.Add(8);
                        fishList[i] = 6;
                    }
                    else
                    {
                        fishList[i]--;
                    }
                }
            }

            sw.Stop();
            Console.WriteLine($"Part 1: {fishList.Count}");
            System.Diagnostics.Debug.WriteLine($"Part 1: {sw.Elapsed}");
        }

        static void Part2()
        {
            var input = File.ReadAllText(@".\input.txt");
            var sw = System.Diagnostics.Stopwatch.StartNew();

            var fishList = input.Split(',').Select(int.Parse).ToList();

            for (int day = 0; day < 256; day++)
            {
                var count = fishList.Count;
                for (int i = 0; i < count; i++)
                {
                    if (fishList[i] == 0)
                    {
                        fishList.Add(8);
                        fishList[i] = 6;
                    }
                    else
                    {
                        fishList[i]--;
                    }
                }
            }


            sw.Stop();
            System.Diagnostics.Debug.WriteLine($"Part 2: {sw.Elapsed}");
        }
    }
}
