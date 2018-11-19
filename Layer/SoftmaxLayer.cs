using System;
namespace Layer
{
    public class SoftmaxLayer : ILayer<double[]>
    {
        public int NeuronNumber { get; }
        public bool IsLearning { get; set; }

        double[] results;

        public SoftmaxLayer(int neuronNumber, bool isLearning = true)
        {
            NeuronNumber = neuronNumber;
            IsLearning = isLearning;
            results = new double[neuronNumber];
        }

        public double[] Forward(double[] input)
        {
            if (IsLearning)
            {
                var inputExp = new double[NeuronNumber];
                var adjustment = Util.MathUtil.Max(input);
                var sum = 0.0d;
                for (int n = 0; n < NeuronNumber; n++)
                {
                    inputExp[n] = Math.Exp(input[n] - adjustment);
                    sum += inputExp[n];
                }

                for (int n = 0; n < NeuronNumber; n++)
                {
                    results[n] = inputExp[n] / sum;
                }
                inputExp = null;
            }
            else
            {
                var sum = 0.0d;
                for (int n = 0; n < NeuronNumber; n++) sum += input[n];
                for (int n = 0; n < NeuronNumber; n++)
                    results[n] = input[n] / sum;
            }
            return results;
        }

        public double[] Backword(double[] teacher)
        {
            var output = new double[NeuronNumber];
            for (int n = 0; n < NeuronNumber; n++)
                output[n] = results[n] - teacher[n];
            return output;
        }
    }
}
