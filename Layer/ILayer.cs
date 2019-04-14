using System;
using System.Collections.Generic;
using System.Text;

namespace Layer
{
    public interface ILayer<T>
    {
        T Forward(T input);
        T Backword(T gradient);
    }
}
