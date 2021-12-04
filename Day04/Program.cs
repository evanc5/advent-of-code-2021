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
                        sw.Stop();
                        Console.WriteLine($"Part 1 ID: {board.BoardID}");
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

    class BingoBoard
    {
        public int[,] Board { get; private set; }
        public bool[,] CalledBoard { get; private set; }

        public int BoardID { get; private set; }

        public BingoBoard(string[] input, int boardId)
        {
            Board = new int[5, 5];
            CalledBoard = new bool[5, 5];
            BoardID = boardId;
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
            var diagonals = CalledBoard.GetDiagonals();
            if (diagonals.Any(diagonal => diagonal.All(a => a == true))) return true;

            for (int i = 0; i < 5; i++)
            {
                var row = CalledBoard.GetRow(i);
                var column = CalledBoard.GetColumn(i);
                if (row.All(a => a == true) || column.All(a => a == true)) return true;
            }

            return false;
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

    public static class MatrixExtensions
    {
        public static T[] GetRow<T>(this T[,] matrix, int rowNumber)
        {
            return Enumerable.Range(0, matrix.GetLength(0)).Select(y => matrix[rowNumber, y]).ToArray();
        }

        public static T[] GetColumn<T>(this T[,] matrix, int columnNumber)
        {
            return Enumerable.Range(0, matrix.GetLength(0)).Select(x => matrix[x, columnNumber]).ToArray();
        }

        public static List<T[]> GetDiagonals<T>(this T[,] matrix)
        {
            if (matrix.GetLength(0) != matrix.GetLength(1))
            {
                throw new InvalidOperationException($"{nameof(GetDiagonals)} is only supported for square matrices.");
            }
            var list = new List<T[]>();

            list.Add(Enumerable.Range(0, matrix.GetLength(0)).Select(x => matrix[x, x]).ToArray());
            list.Add(Enumerable.Range(0, matrix.GetLength(0)).Select(x => matrix[x, 4 - x]).ToArray());

            return list;
        }
    }
}
