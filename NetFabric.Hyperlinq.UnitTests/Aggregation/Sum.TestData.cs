using System;
using Xunit;

namespace NetFabric.Hyperlinq
{
    public static partial class TestData
    {
        public static TheoryData<double[]> Sum
            => new()
            {
                { new double[] { } },
                { new[] { double.NaN } },
                { new[] { double.PositiveInfinity } },
                { new[] { 1.0 } },
                { new[] { 1.0, 2.0, 3.0, 4.0, 5.0, 6.0, 7.0 } },
                { new[] { 1.0, 2.0, 3.0, 4.0, 5.0, 6.0, 7.0, 8.0 } }, 
                { new[] { 1.0, 2.0, 3.0, 4.0, 5.0, 6.0, 7.0, 8.0, 9.0 } },
                { new[] { 1.0, 2.0, 3.0, 4.0, 5.0, 6.0, 7.0, 8.0, 9.0, 10.0, 11.0, 12.0, 13.0, 14.0, 15.0, 16.0, 17.0, 18.0, 19.0, 20.0 } },
                { new[] { double.NaN, 2.0, 3.0, 4.0, 5.0, 6.0, 7.0, 8.0, 9.0, 10.0, 11.0, 12.0, 13.0, 14.0, 15.0, 16.0, 17.0, 18.0, 19.0, 20.0 } },
                { new[] { double.PositiveInfinity, 2.0, 3.0, 4.0, 5.0, 6.0, 7.0, 8.0, 9.0, 10.0, 11.0, 12.0, 13.0, 14.0, 15.0, 16.0, 17.0, 18.0, 19.0, 20.0 } },
                { new[] { double.MaxValue, double.MaxValue } },
                { new[] { double.PositiveInfinity, double.PositiveInfinity } },
            };
        
        public static TheoryData<double?[]> NullableSum
            => new()
            {
                { new double?[] { } },
                { new double?[] { default } },
                { new double?[] { double.NaN } },
                { new double?[] { double.PositiveInfinity } },
                { new double?[] { 1 } },
                { new double?[] { default, default, default } },
                { new double?[] { default, 2.0, double.NaN, 4.0, default } },
                { new double?[] { default, 2.0, 3.0, 4.0, default } },
                { new double?[] { 1.0, 2.0, default, 4.0, 5.0 } },
                { new double?[] { 1.0, 2.0, 3.0, 4.0, 5.0 } },
                { new double?[] { double.MaxValue, double.MaxValue } },
                { new double?[] { double.PositiveInfinity, double.PositiveInfinity } },
            };
        
    }
}