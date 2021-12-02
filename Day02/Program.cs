using System;
using System.IO;

namespace Day02
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

            var horizontal = 0;
            var depth = 0;
            foreach (var line in input)
            {
                var split = line.Split(' ');
                var instruction = split[0];
                var value = int.Parse(split[1]);
                switch (instruction)
                {
                    case "forward":
                        horizontal += value;
                        break;
                    case "down":
                        depth += value;
                        break;
                    case "up":
                        depth -= value;
                        if (depth < 0) depth = 0;
                        break;
                    default:
                        throw new Exception($"Unhandled case {instruction}");
                }
            }

            sw.Stop();
            Console.WriteLine($"Part 1: {horizontal * depth}");
            System.Diagnostics.Debug.WriteLine($"Part 1: {sw.Elapsed}");
        }

        static void Part2()
        {
            var input = File.ReadAllLines(@".\input.txt");
            var sw = System.Diagnostics.Stopwatch.StartNew();

            var sub = new Submarine();
            foreach (var line in input)
            {
                var split = line.Split(' ');
                var instruction = split[0];
                var value = int.Parse(split[1]);
                switch (instruction)
                {
                    case "forward":
                        sub.Forward(value);
                        break;
                    case "down":
                        sub.Down(value);
                        break;
                    case "up":
                        sub.Up(value);
                        break;
                    default:
                        throw new Exception($"Unhandled case {instruction}");
                }
            }

            sw.Stop();
            Console.WriteLine($"Part 2: {sub.Horizontal * sub.Depth}");
            System.Diagnostics.Debug.WriteLine($"Part 2: {sw.Elapsed}");
        }
    }

    class Submarine
    {
        public int Horizontal { get; private set; }
        public int Depth { get; private set; }
        public int Aim { get; private set; }

        public void Forward(int value)
        {
            Horizontal += value;
            Depth += value * Aim;
            if (Depth < 0) Depth = 0;
        }

        public void Down(int value)
        {
            Aim += value;
        }

        public void Up(int value)
        {
            Aim -= value;
        }
    }
}
