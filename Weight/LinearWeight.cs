using System;
namespace Weight
{
    public class LinearWeight
    {
        public int InputSize { get; }
        public int OutputSize { get; }

        Util.Matrix weights;

        public LinearWeight(int input, int output)
        {
            weights = new Util.Matrix(input, output);
            weights.InitXavier();
            InputSize = input;
            OutputSize = output;
        }

        public void InitZero() => weights.InitZero();
        public void InitRandom(ulong? seed = null) => weights.InitRandom(seed);
        public void InitXavier(ulong? seed0 = null, ulong? seed1 = null) => weights.InitXavier(seed0, seed1);
        public void InitHe(ulong? seed0 = null, ulong? seed1 = null) => weights.InitHe(seed0, seed1);

        public double this[int row, int column]
        {
            get => weights.GetValue(row, column);
            set => weights.SetValue(row, column, value);
        }

        public double[] Forward(double[] input)
        {
            return weights.Dot(input);
        }

        public double[] Backward(double[] gradient)
        {
            return weights.DotTransposed(gradient);
        }
    }
}
