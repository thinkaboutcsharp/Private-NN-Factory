using System;
namespace Weight
{
    public class WeightMatrix
    {
        public int InputSize { get; }
        public int OutputSize { get; }

        Util.Matrix weights;

        public WeightMatrix(int input, int output)
        {
            weights = new Util.Matrix(input, output);
            InputSize = input;
            OutputSize = output;
        }

        public double this[int row, int column]
        {
            get => weights.GetValue(row, column);
            set => weights.SetValue(row, column, value);
        }

        public double[] Forward(double[] input)
        {
            return weights.Dot(input);
        }

        public double[] Back(double[] output)
        {
            return weights.DotTransposed(output);
        }
    }
}
