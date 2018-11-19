using System;
using System.Collections.Generic;
using System.Linq;

namespace Neuron.Core
{
    /// <summary>
    /// Neuron core architecture.
    /// </summary>
    public abstract class NeuronCore
    {
        public double InputValue { get; set; }
        public double ResultValue { get; set; }

        public Func<double, double> Activator { get; set; }
        public Func<double, double> ActivatorDelta { get; set; }

        public double GetOutput(double input)
        {
            InputValue = input;
            ResultValue = Activator(InputValue);
            return ResultValue;
        }

        public double GetGradient()
        {
            var gradient = ActivatorDelta(ResultValue);
            return gradient;
        }
    }
}
