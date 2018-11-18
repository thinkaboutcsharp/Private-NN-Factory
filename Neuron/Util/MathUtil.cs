using System;
using System.Linq;

namespace Neuron.Util
{
    public static class MathUtil
    {
        public static double Sigmoid(double x) => 1.0d / (1.0d + Math.Exp(-x));
        public static double ReLU(double x) => x >= 0.0 ? x : 0.0;
    }
}
