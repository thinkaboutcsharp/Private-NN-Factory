using System;
using System.Threading.Tasks;
using Neuron;
using Neuron.Core;

namespace Layer
{
    public class LinearLayer : ILayer<double[]>
    {
        public int NeuronNumber { get; }

        NeuronCore[] neurons;

        public LinearLayer(int neuronNumber, NeuronType type)
        {
            NeuronNumber = neuronNumber;
            neurons = new NeuronCore[neuronNumber];
            Parallel.For(0, neuronNumber - 1, n => neurons[n] = NeuronFactory.Create(type));
        }

        public double[] Forward(double[] input)
        {
            var output = new double[NeuronNumber];
            Parallel.For(0, NeuronNumber - 1, n => output[n] = neurons[n].GetOutput(input[n]));
            return output;
        }

        public double[] Backword(double[] gradient)
        {
            var output = new double[NeuronNumber];
            Parallel.For(0, NeuronNumber - 1, n => output[n] = neurons[n].GetGradient() * gradient[n]);
            return output;
        }
    }
}
