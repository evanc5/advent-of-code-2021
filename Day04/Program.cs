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

            var bingoCalls = input[0].Split(',').Select(int.Parse);
            var boards = new List<BingoBoard>();
            var currentLines = new string[5];
            var idx = 0;
            foreach (var line in input.Skip(1))
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    idx = 0;
                    currentLines = new string[5];
                }
                else
                {
                    currentLines[idx] = line;
                    idx++;
                }
            }

            foreach (var call in bingoCalls)
            {
                foreach (var board in boards)
                {
                    var bingo = board.Call(call);
                    if (bingo)
                    {
                        System.Diagnostics.Debugger.Break();
                    }
                }
            }

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
