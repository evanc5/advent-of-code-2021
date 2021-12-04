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
            var boardId = 0;
            foreach (var line in input.Skip(2))
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    boards.Add(new BingoBoard(currentLines, boardId++));
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
                        var score = board.Score(call);
                        sw.Stop();
                        Console.WriteLine($"Part 1: {score}");
                        System.Diagnostics.Debug.WriteLine($"Part 1: {sw.Elapsed}");
                        return;
                    }
                }
            }
        }

        static void Part2()
        {
            var input = File.ReadAllLines(@".\input.txt");
            var sw = System.Diagnostics.Stopwatch.StartNew();


            sw.Stop();
            System.Diagnostics.Debug.WriteLine($"Part 2: {sw.Elapsed}");
        }
    }
}
