using System;
using System.Collections.Generic;
using System.Linq;
using MatrixExtensions;

namespace Day04
{
    public class BingoBoard
    {
        public int[,] Board { get; private set; }
        public bool[,] CalledBoard { get; private set; }
        public int BoardID { get; private set; }
        public bool Won { get; private set; }

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
            for (int i = 0; i < 5; i++)
            {
                var row = CalledBoard.GetRow(i);
                var column = CalledBoard.GetColumn(i);
                if (row.All(a => a == true) || column.All(a => a == true))
                {
                    Won = true;
                    return true;
                }
            }

            return false;
        }

        public int Score(int call)
        {
            var sum = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (!CalledBoard[i, j]) sum += Board[i, j];
                }
            }
            return sum * call;
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
