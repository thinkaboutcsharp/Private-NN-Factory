using System;
using System.Linq;

namespace Neuron.Util
{
    static class MathUtil
    {
        public static double Sigmoid(double x) => 1.0d / (1.0d + Math.Exp(-x));
        public static double SigmoidDelta(double y) => y * (1.0d - y);

        public static double ReLU(double x) => x > 0.0d ? x : 0.0d;
        public static double ReLUDelta(double y) => y > 0.0d ? 1.0d : 0.0d;

        public static double TanhDelta(double y)
        {
            var cosh = Math.Cosh(y);
            return 1.0d / (cosh * cosh);
        }
    }
}
