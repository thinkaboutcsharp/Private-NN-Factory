using System;
using System.Collections.Generic;

namespace Neuron.BasicNode
{
    public class BasicNode : INode
    {
        public Core.NeuronCore Neuron { get; private set; }
        public Core.WeightSet Weight { get; private set; }

        Dictionary<int, IEmitNode> inputSet = new Dictionary<int, IEmitNode>();

        public BasicNode()
        {
            Neuron = new Core.NeuronCore();
            Weight = new Core.WeightSet();

            Neuron.InputAggregationFunc = (values) =>
            {
                if (inputSet.Count != Weight.Count) return 0d;
                else
                {
                    int count = Weight.Count;
                    double aggregate = 0.0d;
                    for (int i = 0; i < count; i++) aggregate += inputSet[i].GetOutput() * Weight[i];
                    return aggregate;
                }
            };
            Neuron.OutputFunc = (input) =>
            {
                var result = 1.0d / (1.0d + Math.Exp(-input));
                return result;
            };
        }

        public void SetInput(int index, IEmitNode input)
        {
            Neuron.AddInputNode(input);
            if (inputSet.ContainsKey(index)) inputSet[index] = input;
            else inputSet.Add(index, input);

            if (index >= Weight.Count) Weight[index] = 0d;
        }

        public void InitWeight(double suitInitialValue) => Weight.SuitWeight(suitInitialValue);
        public void InitWeight(double[] initialValues) => Weight.SetRange(initialValues);
        public void InitWeight(Func<double> initializer) => InitWeight((i) => initializer());
        public void InitWeight(Func<int, double> initializer)
        {
            var values = new double[Weight.Count];
            for (int i = 0; i < values.Length; i++) values[i] = initializer(i);
            Weight.SetRange(values);
        }

        public double GetOutput()
        {
            Neuron.Receipt();
            var value = Neuron.Fire();
            return value;
        }
    }
}
