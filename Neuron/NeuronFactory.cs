using System;
namespace Neuron
{
    public static class NeuronFactory
    {
        public static Core.NeuronCore Create(NeuronType type)
        {
            switch (type)
            {
                case NeuronType.Linear:
                    return new Neurons.LinearNeuron();
                case NeuronType.Sigmoid:
                    return new Neurons.SigmoidNeuron();
                case NeuronType.Tanh:
                    return new Neurons.TanhNeuron();
                case NeuronType.ReLU:
                    return new Neurons.ReLUNeuron();
            }
            return null;
        }
    }
}
