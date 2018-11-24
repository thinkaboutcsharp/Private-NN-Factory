using System;
using Xunit;

namespace LightweightUnitTest
{
    public class WeightTest : IDisposable
    {
        Weight.WeightMatrix weight;
        public WeightTest()
        {
            weight = new Weight.WeightMatrix(3, 3);
            weight[0, 0] = 0.1d;
            weight[0, 1] = 0.2d;
            weight[0, 2] = 0.3d;
            weight[1, 0] = 0.4d;
            weight[1, 1] = 0.5d;
            weight[1, 2] = 0.6d;
            weight[2, 0] = 0.7d;
            weight[2, 1] = 0.8d;
            weight[2, 2] = 0.9d;
        }

        public void Dispose() {}

        [Fact]
        public void Test1()
        {
            var input = new[] { 1d, 1d, 1d };

            var output = weight.Forward(input);
            Assert.Equal(1.2d, output[0], 10);
            Assert.Equal(1.5d, output[1], 10);
            Assert.Equal(1.8d, output[2], 10);
        }

        [Fact]
        public void Test2()
        {
            var gradient = new[] { 1d, 1d, 1d };

            var output = weight.Backward(gradient);
            Assert.Equal(0.6d, output[0], 10);
            Assert.Equal(1.5d, output[1], 10);
            Assert.Equal(2.4d, output[2], 10);
        }
    }
}
