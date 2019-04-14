using System;
using System.Collections.Generic;
using System.Text;

namespace Layer
{
    interface ISquareLayer : ILayer<double[,,]>
    {
        int HeightUnitNumber { get; }
        int WidthUnitNumber { get; }
        int Channels { get; }
    }
}
