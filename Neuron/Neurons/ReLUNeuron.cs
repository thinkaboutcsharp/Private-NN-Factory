using System;
namespace Neuron.Neurons
{
    public class ReLUNeuron : Core.NeuronCore
    {
        public ReLUNeuron()
        {
            base.Activator = Util.MathUtil.ReLU;
        }
    }
}
