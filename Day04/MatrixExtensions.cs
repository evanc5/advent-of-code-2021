using System;
using System.Collections.Generic;
using System.Linq;

namespace MatrixExtensions
{
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
