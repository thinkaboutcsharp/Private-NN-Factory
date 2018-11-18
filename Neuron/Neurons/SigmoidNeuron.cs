using System;
namespace Neuron.Neurons
{
    public class SigmoidNeuron : Core.NeuronCore
    {
        public SigmoidNeuron()
        {
            base.Activator = Util.MathUtil.Sigmoid;
        }
    }
}
