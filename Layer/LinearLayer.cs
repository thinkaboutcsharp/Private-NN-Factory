using System;
using System.Threading.Tasks;
using Neuron;
using Neuron.Core;

namespace Layer
{
    public class LinearLayer : ILayer<double[]>
    {
        public int UnitNumber { get; }

        NeuronCore[] neurons;

        public LinearLayer(int neuronNumber, NeuronType type)
        {
            UnitNumber = neuronNumber;
            neurons = new NeuronCore[neuronNumber];
            Parallel.For(0, neuronNumber, n => neurons[n] = NeuronFactory.Create(type));
        }

        public double[] Forward(double[] input)
        {
            var output = new double[UnitNumber];
            Parallel.For(0, UnitNumber, n => output[n] = neurons[n].GetOutput(input[n]));
            return output;
        }

        public double[] Backword(double[] gradient)
        {
            var output = new double[UnitNumber];
            Parallel.For(0, UnitNumber, n => output[n] = neurons[n].GetGradient() * gradient[n]);
            return output;
        }
    }
}
