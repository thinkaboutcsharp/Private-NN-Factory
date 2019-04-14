using System;
using System.Collections.Generic;
using System.Text;

namespace Layer
{
    public interface IChanneledLinearLayer : ILayer<double[,]>
    {
        int UnitNumber { get; }
        int Channels { get; }
    }
}
