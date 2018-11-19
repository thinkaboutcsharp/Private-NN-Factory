using System;
namespace Neuron.Neurons
{
    public class TanhNeuron : Core.NeuronCore
    {
        public TanhNeuron()
        {
            base.Activator = Math.Tanh;
            base.ActivatorDelta = Util.MathUtil.TanhDelta;
        }
    }
}
