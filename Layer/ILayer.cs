using System;
namespace Layer
{
    public interface ILayer<T>
    {
        int UnitNumber { get; }

        T Forward(T input);
        T Backword(T gradient);
    }
}
