using System;
using System.Threading.Tasks;

namespace Layer
{
    public class GridSoftmaxLayer : ILayer<double[,]>
    {
        public int NeuronNumber { get; }
        public int RowNumber { get; }
        public int ColumnNumber { get; }
        public bool IsLearning { get; set; }

        double[,] results;

        public GridSoftmaxLayer(int rows, int columns, bool isLearning = true)
        {
            RowNumber = rows;
            ColumnNumber = columns;
            NeuronNumber = rows * columns;
            IsLearning = isLearning;
            results = new double[rows, columns];
        }

        public double[,] Forward(double[,] input)
        {
            if (IsLearning)
            {
                var inputExp = new double[RowNumber, ColumnNumber];
                var adjustment = Util.MathUtil.Max(input);
                var sum = 1.0e-7;
                for (int r = 0; r < RowNumber; r++)
                    for (int c = 0; c < ColumnNumber; c++)
                    {
                        inputExp[r, c] = Math.Exp(input[r, c] - adjustment);
                        sum += inputExp[r, c];
                    }

                Parallel.For(0, RowNumber - 1, r =>
                {
                    for (int c = 0; c < ColumnNumber; c++)
                    {
                        results[r, c] = inputExp[r, c] / sum;
                    }
                });

                inputExp = null;
            }
            else
            {
                var sum = 1.0e-7;
                for (int r = 0; r < RowNumber; r++)
                    for (int c = 0; c < ColumnNumber; c++)
                        sum += input[r, c];
                Parallel.For(0, RowNumber - 1, r =>
                {
                    for (int c = 0; c < ColumnNumber; c++)
                    {
                        results[r, c] = input[r, c] / sum;
                    }
                });
            }
            return results;
        }

        public double[,] Backword(double[,] teacher)
        {
            var output = new double[RowNumber, ColumnNumber];
            for (int r = 0; r < RowNumber; r++)
                for (int c = 0; c < ColumnNumber; c++)
                    output[r, c] = results[r, c] - teacher[r, c];
            return output;
        }
    }
}
