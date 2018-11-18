using System;
namespace Neuron.Neurons
{
    public class LinearNeuron : Core.NeuronCore
    {
        public LinearNeuron()
        {
            base.Activator = (d) => d;
        }
    }
}
