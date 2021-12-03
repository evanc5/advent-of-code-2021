using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Day03
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

            string gammaBinary = "";
            string epsilonBinary = "";
            var lineLength = input[0].Length;
            var bitCounts = new int[lineLength];
            foreach (var line in input)
            {
                for (int i = 0; i < lineLength; i++)
                {
                    if (line[i] == '1') bitCounts[i]++;
                }
            }

            foreach (var count in bitCounts)
            {
                if (count > input.Length / 2)
                {
                    gammaBinary += '1';
                    epsilonBinary += '0';
                }
                else
                {
                    gammaBinary += '0';
                    epsilonBinary += '1';
                }
            }

            var gamma = Convert.ToInt32(gammaBinary, 2);
            var epsilon = Convert.ToInt32(epsilonBinary, 2);

            sw.Stop();
            Console.WriteLine($"Part 1: {gamma * epsilon}");
            System.Diagnostics.Debug.WriteLine($"Part 1: {sw.Elapsed}");
        }

        static void Part2()
        {
            var input = File.ReadAllLines(@".\input.txt");
            var sw = System.Diagnostics.Stopwatch.StartNew();

            string gammaBinary = "";
            string epsilonBinary = "";
            var lineLength = input[0].Length;
            var bitCounts = new int[lineLength];
            foreach (var line in input)
            {
                for (int i = 0; i < lineLength; i++)
                {
                    if (line[i] == '1') bitCounts[i]++;
                }
            }

            foreach (var count in bitCounts)
            {
                if (count > input.Length / 2)
                {
                    gammaBinary += '1';
                    epsilonBinary += '0';
                }
                else
                {
                    gammaBinary += '0';
                    epsilonBinary += '1';
                }
            }

            sw.Stop();
            System.Diagnostics.Debug.WriteLine($"Part 2: {sw.Elapsed}");
        }
    }
}
