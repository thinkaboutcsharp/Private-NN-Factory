using System;
using System.Threading.Tasks;

namespace Layer
{
    public class SoftmaxLayer : ILinearLayer
    {
        public int UnitNumber { get; }
        public bool IsLearning { get; set; }

        double[] results;

        public SoftmaxLayer(int neuronNumber, bool isLearning = true)
        {
            UnitNumber = neuronNumber;
            IsLearning = isLearning;
            results = new double[neuronNumber];
        }

        public double[] Forward(double[] input)
        {
            if (IsLearning)
            {
                var inputExp = new double[UnitNumber];
                var adjustment = Util.MathUtil.Max(input);
                var sum = 1.0e-7;
                for (int n = 0; n < UnitNumber; n++)
                {
                    inputExp[n] = Math.Exp(input[n] - adjustment);
                    sum += inputExp[n];
                }

                Parallel.For(0, UnitNumber, n => results[n] = inputExp[n] / sum);
                inputExp = null;
            }
            else
            {
                var sum = 1.0e-7;
                for (int n = 0; n < UnitNumber; n++) sum += input[n];
                Parallel.For(0, UnitNumber, n => results[n] = input[n] / sum);
            }
            return results;
        }

        public double[] Backword(double[] teacher)
        {
            var output = new double[UnitNumber];
            Parallel.For(0, UnitNumber, n => output[n] = results[n] - teacher[n]);
            return output;
        }
    }
}
