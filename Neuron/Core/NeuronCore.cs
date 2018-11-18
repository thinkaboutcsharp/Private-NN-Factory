using System;
using System.Collections.Generic;
using System.Linq;

namespace Neuron.Core
{
    /// <summary>
    /// Neuron core architecture.
    /// </summary>
    public abstract class NeuronCore : ICaptureNode, IEmitNode
    {
        public double InputValue { get; set; }
        public double ResultValue { get; set; }

        public Func<double, double> Activator { get; set; }

        public double GetOutput()
        {
            InputValue = inputNode.GetOutput();
            ResultValue = Activator(InputValue);
            return ResultValue;
        }

        public void SetInput(IEmitNode input)
        {
            inputNode = input;
        }
        IEmitNode inputNode;
    }
}
