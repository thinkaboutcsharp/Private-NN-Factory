using System;
using Xunit;

namespace LightweightUnitTest
{
    public class RandomTest : IDisposable
    {
        Weight.Util.Random random;
        public RandomTest()
        {
            random = new Weight.Util.Random(3298401ul, 890932903ul);
        }

        public void Dispose() {}

        [Fact]
        public void Test1()
        {
            var expected = new[]
            {
                1.49995170885573e-6,
                0.407072295503749e-3,
                0.582899900463881,
                0.22727473706069,
                0.287727729422792,
                0.741862644706129,
                0.805501858110094,
                0.677857123884518e-2,
                0.844802008757283,
                0.123329472601137
            };
            for (int i = 0; i < expected.Length; i++) Assert.Equal(expected[i], random.Next(), 10);
        }

        [Fact]
        public void Test2()
        {
            random.Scale = 0.31622776601683794;  // 1/sqrt(10)
            var expected = new[]
            {
                0.474326378024586e-6,
                0.12872756261449667e-3,
                0.18432913333513026,
                0.07187058237276625,
                0.09098749709646672,
                0.23459756682676233,
                0.254722053112567,
                0.2143572439646001e-2,
                0.2671498519558527,
                0.03900020360469238
            };
            for (int i = 0; i < expected.Length; i++) Assert.Equal(expected[i], random.Next(), 10);
        }

        [Fact]
        public void Test3()
        {
            random.UseNegative = true;

            var expected = new[]
            {
                -0.9999970000965823,
                -0.9991858554089925,
                0.16579980092776192,
                -0.54545052587862,
                -0.424544541154416,
                0.4837252894122579,
                0.611003716220188,
                -0.9864428575223096,
                0.6896040175145659,
                -0.753341054797726
            };
            for (int i = 0; i < expected.Length; i++) Assert.Equal(expected[i], random.Next(), 10);
        }
    }
}
