using System;
using System.Threading.Tasks;
using Neuron;
using Neuron.Core;

namespace Layer
{
    public class ConvolutionLayer : ISquareLayer
    {
        public int UnitNumber { get; }
        public int HeightUnitNumber { get; }
        public int WidthUnitNumber { get; }
        public int Channels { get; }

        ConvolutionFilterSet filterSet;

        public ConvolutionLayer(int rows, int columns, int filterWidth, int filterHeight, int channels, double[] biases, int stride = 1, int padding = 0, double paddingValue = 0d)
        {
            UnitNumber = rows * columns;
            HeightUnitNumber = rows;
            WidthUnitNumber = columns;
            Channels = channels;
            filterSet = new ConvolutionFilterSet(channels, filterWidth, filterHeight, biases, stride, padding, paddingValue);
        }

        public double GetFilter(int channel, int row, int column) => filterSet.Filters[channel].Filter[row, column];
        public void SetFilter(int channel, int row, int column, double value) => filterSet.Filters[channel].Filter[row, column] = value;
        public double GetBias(int channel) => filterSet.Filters[channel].Bias;
        public void SetBias(int channel, double bias) => filterSet.Filters[channel].Bias = bias;

        public double[,,] Forward(double[,,] input)
        {
            throw new NotImplementedException();
        }

        public double[,,] Backword(double[,,] gradient)
        {
            throw new NotImplementedException();
        }
    }

    struct ConvolutionFilterSet
    {
        public int Channels { get; }
        public int Width { get; }
        public int Height { get; }
        public int Stride { get; }
        public int Padding { get; }
        public double PaddingValue { get; }
        public ConvolutionFilter[] Filters { get; }

        public ConvolutionFilterSet(int channels, int width, int height, double[] biases, int stride, int padding, double paddingValue)
        {
            Channels = channels;
            Width = width;
            Height = height;
            Stride = stride;
            Padding = padding;
            PaddingValue = paddingValue;

            var filterBiases = biases;
            if (biases == null) filterBiases = new double[channels]; //implicitly 0

            var tmpFilters = new ConvolutionFilter[channels];
            Parallel.For(0, channels, c =>
            {
                tmpFilters[c] = new ConvolutionFilter(width, height, filterBiases[c]);
            });
            Filters = tmpFilters;
        }
    }

    struct ConvolutionFilter
    {
        public double[,] Filter { get; }
        public double Bias { get; set; }

        public ConvolutionFilter(int width, int height, double bias)
        {
            Filter = new double[width, height];
            Bias = bias;
        }
    }
}
