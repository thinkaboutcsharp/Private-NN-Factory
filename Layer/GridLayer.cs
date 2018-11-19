using System;
using System.Threading.Tasks;
using Neuron;
using Neuron.Core;

namespace Layer
{
    public class GridLayer : ILayer<double[,]>
    {
        public int NeuronNumber { get; }
        public int RowNumber { get; }
        public int ColumnNumber { get; }

        NeuronCore[,] neurons;

        public GridLayer(int rows, int columns, NeuronType type)
        {
            NeuronNumber = rows * columns;
            RowNumber = rows;
            ColumnNumber = columns;
            neurons = new NeuronCore[rows, columns];
            Parallel.For(0, rows - 1, r =>
            {
                for (int c = 0; c < columns; c++)
                    neurons[r, c] = NeuronFactory.Create(type);
            });
        }

        public double[,] Forward(double[,] input)
        {
            var output = new double[RowNumber, ColumnNumber];
            Parallel.For(0, RowNumber - 1, r =>
            {
                for (int c = 0; c < ColumnNumber; c++)
                    output[r, c] = neurons[r, c].GetOutput(input[r, c]);
            });
            return output;
        }

        public double[,] Backword(double[,] gradient)
        {
            var output = new double[RowNumber, ColumnNumber];
            Parallel.For(0, RowNumber - 1, r =>
            {
                for (int c = 0; c < ColumnNumber; c++)
                    output[r, c] = neurons[r, c].GetGradient() * gradient[r, c];
            });
            return output;
        }
    }
}
