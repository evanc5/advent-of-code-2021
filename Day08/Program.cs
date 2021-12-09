using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day08
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
            var parsed = input.Select(line => line.Split(" | "));
            foreach (var outputLine in parsed.Select(line => line[1]))
            {
                foreach (var word in outputLine.Split(' '))
                {
                    switch (word.Length)
                    {
                        case 2: //number is 1
                        case 3: //number is 7
                        case 4: //number is 4
                        case 7: //number is 8
                            count++;
                            break;
                    }
                }
            }

            sw.Stop();
            Console.WriteLine($"Part 1: {count}");
            System.Diagnostics.Debug.WriteLine($"Part 1: {sw.Elapsed}");
        }

        static void Part2()
        {
            var input = File.ReadAllLines(@".\input.txt");
            var sw = System.Diagnostics.Stopwatch.StartNew();

            var parsed = input.Select(line => line.Split(" | "));
            foreach (var line in parsed)
            {
                var inputLine = line[0];
                var outputLine = line[1];
                foreach (var word in inputLine.Split(' '))
                {
                    switch (word.Length)
                    {
                        case 2:
                            //number is 1
                            break;
                        case 3:
                            //number is 7
                            break;
                        case 4:
                            //number is 4
                            break;
                        case 7:
                            //number is 8
                            break;
                        case 6:
                            //number can be 0, 6, 9
                            break;
                        case 5:
                            //number can be 2, 3, 5
                            break;
                    }
                }
            }

            sw.Stop();
            System.Diagnostics.Debug.WriteLine($"Part 2: {sw.Elapsed}");
        }
    }
}
