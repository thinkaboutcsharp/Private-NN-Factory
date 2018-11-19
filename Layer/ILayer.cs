using System;
namespace Layer
{
    public interface ILayer<T>
    {
        int NeuronNumber { get; }

        T Forward(T input);
        T Backword(T gradient);
    }
}
