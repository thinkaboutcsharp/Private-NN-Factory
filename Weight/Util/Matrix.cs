using System;
using System.Collections.Generic;
using System.Linq;

namespace Weight.Util
{
    public class Matrix
    {
        int rows;
        int columns;
        double[][] columnVectors;
        double[][] transposedColumnVectors;

        public Matrix(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;

            columnVectors = new double[columns][];
            for (int c = 0; c < columns; c++)
            {
                columnVectors[c] = new double[rows];
                for (int r = 0; r < rows; r++)
                    columnVectors[c][r] = 0.0d;
            }

            transposedColumnVectors = new double[rows][];
            for (int r = 0; r < rows; r++)
            {
                transposedColumnVectors[r] = new double[columns];
                for (int c = 0; c < columns; c++)
                    transposedColumnVectors[r][c] = 0.0d;
            }
        }

        public void SetValue(int row, int column, double value)
        {
            columnVectors[column][row] = value;
            transposedColumnVectors[row][column] = value;
        }

        public double GetValue(int row, int column)
        {
            return columnVectors[column][row];
        }

        public double[] Dot(double[] vector)
        {
            var result = new double[columns];

            for (int c = 0; c < columns; c++)
            {
                var columnVector = columnVectors[c];
                double product = 0.0d;
                for (int e = 0; e < rows; e++)
                {
                    product += vector[e] * columnVector[e];
                }
                result[c] = product;
            }

            return result;
        }

        public double[] DotTransposed(double[] vector)
        {
            var result = new double[rows];

            for (int r = 0; r < rows; r++)
            {
                var columnVector = transposedColumnVectors[r];
                double product = 0.0d;
                for (int e = 0; e < columns; e++)
                {
                    product += vector[e] * columnVector[e];
                }
                result[r] = product;
            }

            return result;
        }
    }
}
