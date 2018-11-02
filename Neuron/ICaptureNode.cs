using System;
namespace Neuron
{
    public interface ICaptureNode
    {
        void SetInput(int index, IEmitNode input);
    }
}
