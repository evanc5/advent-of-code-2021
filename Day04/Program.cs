using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day04
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

            var bingoCalls = input[0].Split(',');


            sw.Stop();
            System.Diagnostics.Debug.WriteLine($"Part 1: {sw.Elapsed}");
        }

        static void Part2()
        {
            var input = File.ReadAllLines(@".\input.txt");
            var sw = System.Diagnostics.Stopwatch.StartNew();


            sw.Stop();
            System.Diagnostics.Debug.WriteLine($"Part 2: {sw.Elapsed}");
        }
    }

    class BingoBoard
    {
        public int[,] Board { get; private set; }
        public bool[,] CalledBoard { get; private set; }

        public BingoBoard(string[] input)
        {
            Board = new int[5, 5];
            for (int i = 0; i < 5; i++)
            {
                var split = input[i].Split(' ').Where(n => !string.IsNullOrWhiteSpace(n)).Select(n => int.Parse(n)).ToArray();
                for (int j = 0; j < 5; j++)
                {
                    Board[i, j] = split[j];
                }
            }
        }

        public bool Call(int n)
        {
            var indices = IndeciesOf(n);
            foreach (var index in indices)
            {
                CalledBoard[index.Item1, index.Item2] = true;
            }
            return HasBingo();
        }

        public bool HasBingo()
        {

        }

        private Tuple<int, int>[] IndeciesOf(int n)
        {
            var indecies = new List<Tuple<int, int>>();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (Board[i, j] == n) indecies.Add(new(i, j));
                }
            }
            return indecies.ToArray();
        }
    }
}
