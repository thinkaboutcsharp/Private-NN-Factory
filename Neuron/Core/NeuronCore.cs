using System;
using System.Collections.Generic;
using System.Linq;

namespace Neuron.Core
{
    /// <summary>
    /// Neuron core architecture.
    /// Normally this class will not instanciate, because too abstract.
    /// </summary>
    public class NeuronCore
    {
        List<IEmitNode> inputNodes = new List<IEmitNode>();
        List<ICaptureNode> outputNodes = new List<ICaptureNode>();

        public void AddInputNode(IEmitNode newNode) => inputNodes.Add(newNode);
        public void AddOutputNode(ICaptureNode newNode) => outputNodes.Add(newNode);

        public void ClearInputNodes() => inputNodes.Clear();
        public void ClearOutputNodes() => outputNodes.Clear();

        /// <summary>
        /// Funtion for aggregate input values. Normally summation with weight.
        /// </summary>
        /// <value>The input aggregation func.</value>
        /// <remarks>Default: simple summation</remarks>
        public Func<double[], double> InputAggregationFunc
        {
            get => inputAggretation;
            set
            {
                if (value != null) inputAggretation = value;
                else inputAggretation = (v) => v.Sum();
            }
        }
        Func<double[], double> inputAggretation;

        /// <summary>
        /// Function for output neuron's result. For example sigmoid function.
        /// </summary>
        /// <value>The output func.</value>
        /// <remarks>Default: direct value</remarks>
        public Func<double, double> OutputFunc
        {
            get => outputResult;
            set
            {
                if (value != null) outputResult = value;
                else outputResult = (v) => v;
            }
        }
        Func<double, double> outputResult;

        public double InputValue { get; set; }
        public double ResultValue { get; set; }

        /// <summary>
        /// Take input node values into neuron like open its receipter.
        /// If some node not have valid value, ignore them.
        /// </summary>
        public void Receipt()
        {
            double[] inputValues = new double[inputNodes.Count];
            for (int i = 0; i < inputValues.Length; i++) inputValues[i] = inputNodes[i].GetOutput();

            InputValue = InputAggregationFunc(inputValues);
        }

        /// <summary>
        /// Publish output result to output node like fire neuron.
        /// </summary>
        /// <returns>The fire.</returns>
        public double Fire()
        {
            ResultValue = OutputFunc(InputValue);
            return ResultValue;
        }

        public NeuronCore()
        {
            InputAggregationFunc = null;
            OutputFunc = null;
        }
    }
}
