using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        }

        public void InitZero()
        {
            InitWithGenerator(new Zero());
        }

        public void InitRandom(ulong? seed0 = null, ulong? seed1 = null)
        {
            Random generator = GetRandom(seed0, seed1);

            InitWithGenerator(generator);
        }

        public void InitXavier(ulong? seed0 = null, ulong? seed1 = null)
        {
            Random generator = GetRandom(seed0, seed1);

            var sigma = 1.0d / Math.Sqrt(rows); //rows is lower layer number
            generator.Scale = sigma;

            InitWithGenerator(generator);
        }

        public void InitHe(ulong? seed0 = null, ulong? seed1 = null)
        {
            Random generator = GetRandom(seed0, seed1);

            var sigma = Math.Sqrt(2.0d) / Math.Sqrt(rows); //rows is lower layer number
            generator.Scale = sigma;

            InitWithGenerator(generator);
        }

        Random GetRandom(ulong? seed0, ulong? seed1)
        {
            Random generator;
            if (seed0.HasValue && seed1.HasValue) generator = new Random(seed0.Value, seed1.Value);
            else if (seed0.HasValue) generator = new Random(seed0.Value);
            else generator = new Random();

            return generator;
        }

        void InitWithGenerator(IGenerator generator)
        {
            columnVectors = new double[columns][];
            transposedColumnVectors = new double[rows][];

            Parallel.For(0, rows - 1, r =>
            {
                transposedColumnVectors[r] = new double[columns];
            });

            Parallel.For(0, columns - 1, c =>
            {
                columnVectors[c] = new double[rows];
                for (int r = 0; r < rows; r++)
                {
                    columnVectors[c][r] = generator.Next();
                    transposedColumnVectors[r][c] = columnVectors[c][r];
                }
            });
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

            Parallel.For(0, columns - 1, c =>
            {
                var columnVector = columnVectors[c];
                double product = 0.0d;
                for (int e = 0; e < rows; e++)
                {
                    product += vector[e] * columnVector[e];
                }
                result[c] = product;
            });

            return result;
        }

        public double[] DotTransposed(double[] vector)
        {
            var result = new double[rows];

            Parallel.For(0, rows - 1, r =>
            {
                var columnVector = transposedColumnVectors[r];
                double product = 0.0d;
                for (int e = 0; e < columns; e++)
                {
                    product += vector[e] * columnVector[e];
                }
                result[r] = product;
            });

            return result;
        }

        class Zero : IGenerator
        {
            public double Next() => 0.0d;
        }
    }
}
