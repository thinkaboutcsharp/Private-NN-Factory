using System;
namespace Layer
{
    public interface ILinearLayer : ILayer<double[]>
    {
        int UnitNumber { get; }
    }
}
