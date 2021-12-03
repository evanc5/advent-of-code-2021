﻿using System;
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

            var lineLength = input[0].Length;
            var bitCounts = new int[lineLength];

            var o2List = input.ToArray();
            var co2List = input.ToArray();
            for (int bit = 0; bit < lineLength; bit++)
            {
                var highCount = 0;
                foreach (var line in input)
                {
                    if (line[bit] == '1') highCount++;
                }
                if (highCount >= input.Length / 2)
                {
                    if (o2List.Length > 1) o2List = o2List.Where(line => line[bit] == '1').ToArray();
                    if (co2List.Length > 1) co2List = co2List.Where(line => line[bit] == '0').ToArray();
                }
                else
                {
                    if (o2List.Length > 1) o2List = o2List.Where(line => line[bit] == '0').ToArray();
                    if (co2List.Length > 1) co2List = co2List.Where(line => line[bit] == '1').ToArray();
                }
            }

            var o2Rating = Convert.ToInt32(o2List.First(), 2);
            var co2Rating = Convert.ToInt32(co2List.First(), 2);

            sw.Stop();
            Console.WriteLine($"Part 2: {o2Rating * co2Rating}");
            System.Diagnostics.Debug.WriteLine($"Part 2: {sw.Elapsed}");
        }
    }
}
