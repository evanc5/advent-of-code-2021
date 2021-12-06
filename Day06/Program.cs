using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

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

            var fishList = new ConcurrentDictionary<int, int>(input.Split(',').Select((value, index) => new { index, parsed = int.Parse(value) }).ToDictionary(pair => pair.index, pair => pair.parsed));

            for (int day = 0; day < 80; day++)
            {
                var count = fishList.Count;
                Parallel.For(0, count, (i, state) =>
                  {
                      if (fishList[i] == 0)
                      {
                          fishList.TryAdd(count++, 8);
                          fishList[i] = 6;
                      }
                      else
                      {
                          fishList[i]--;
                      }
                  });
            }

            sw.Stop();
            Console.WriteLine($"Part 1: {fishList.Count}");
            System.Diagnostics.Debug.WriteLine($"Part 1: {sw.Elapsed}");
        }

        static void Part2()
        {
            var input = File.ReadAllText(@".\input.txt");
            var sw = System.Diagnostics.Stopwatch.StartNew();


            sw.Stop();
            System.Diagnostics.Debug.WriteLine($"Part 2: {sw.Elapsed}");
        }
    }
}
