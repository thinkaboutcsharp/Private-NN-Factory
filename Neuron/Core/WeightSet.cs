using System;
using System.Collections.Generic;

namespace Neuron.Core
{
    public sealed class WeightSet
    {
        Dictionary<int, double> weights = new Dictionary<int, double>();
        public int Count { get => weights.Count; }
        public bool TryGetValue(int index, out double value)
        {
            if (weights.TryGetValue(index, out value))
            {
                return true;
            }
            else
            {
                value = 0d;
                return false;
            }
        }
        public double this[int index]
        {
            get
            {
                TryGetValue(index, out var value);
                return value;
            }
            set
            {
                if (index >= weights.Count)
                {
                    for (int i = weights.Count; i < index; i++) weights.Add(i, 0d);
                    weights.Add(index, value);
                }
                else
                {
                    weights[index] = value;
                }
            }
        }
        public void SuitWeight(double value)
        {
            foreach (var key in weights.Keys) weights[key] = value;
        }
        public void SetRange(double[] values)
        {
            int count = weights.Count;
            int length = values.Length;
            int index = 0;
            while (index < count && index < length)
            {
                weights[index] = values[index];
                index++;
            }
        }
    }
}
