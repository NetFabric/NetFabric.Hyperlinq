using System;
using Xunit;

// ReSharper disable HeapView.ObjectAllocation.Evident

namespace NetFabric.Hyperlinq
{
    public static partial class TestData
    {
        public static TheoryData<double[]> SumDouble
            => new()
            {
                new double[] { },
                new[] { double.NaN },
                new[] { double.PositiveInfinity },
                new[] { 1.0 },
                new[] { 1.0, 2.0 },
                new[] { 1.0, 2.0, 3.0 },
                new[] { 1.0, 2.0, 3.0, 4.0 },
                new[] { 1.0, 2.0, 3.0, 4.0, 5.0 },
                new[] { 1.0, 2.0, 3.0, 4.0, 5.0, 6.0 },
                new[] { 1.0, 2.0, 3.0, 4.0, 5.0, 6.0, 7.0 },
                new[] { 1.0, 2.0, 3.0, 4.0, 5.0, 6.0, 7.0, 8.0 }, 
                new[] { 1.0, 2.0, 3.0, 4.0, 5.0, 6.0, 7.0, 8.0, 9.0 },
                new[] { 1.0, 2.0, 3.0, 4.0, 5.0, 6.0, 7.0, 8.0, 9.0, 10.0, 11.0, 12.0, 13.0, 14.0, 15.0, 16.0, 17.0, 18.0, 19.0, 20.0 },
                new[] { double.NaN, 2.0, 3.0, 4.0, 5.0, 6.0, 7.0, 8.0, 9.0, 10.0, 11.0, 12.0, 13.0, 14.0, 15.0, 16.0, 17.0, 18.0, 19.0, 20.0 },
                new[] { double.PositiveInfinity, 2.0, 3.0, 4.0, 5.0, 6.0, 7.0, 8.0, 9.0, 10.0, 11.0, 12.0, 13.0, 14.0, 15.0, 16.0, 17.0, 18.0, 19.0, 20.0 },
                new[] { double.MaxValue, double.MaxValue },
                new[] { double.PositiveInfinity, double.PositiveInfinity }
            };
        
        public static TheoryData<double?[]> SumNullableDouble
            => new()
            {
                new double?[] { },
                new double?[] { default },
                new double?[] { double.NaN },
                new double?[] { double.PositiveInfinity },
                new double?[] { 1.0 },
                new double?[] { 1.0, 2.0 },
                new double?[] { 1.0, 2.0, 3.0 },
                new double?[] { 1.0, 2.0, 3.0, 4.0 },
                new double?[] { 1.0, 2.0, 3.0, 4.0, 5.0 },
                new double?[] { default, default, default },
                new double?[] { default, 2.0, double.NaN, 4.0, default },
                new double?[] { default, 2.0, 3.0, 4.0, default },
                new double?[] { 1.0, 2.0, default, 4.0, 5.0 },
                new double?[] { double.MaxValue, double.MaxValue },
                new double?[] { double.PositiveInfinity, double.PositiveInfinity }
            };
        
        public static TheoryData<decimal[]> SumDecimal
            => new()
            {
                new decimal[] { },
                new[] { 1.0M },
                new[] { 1.0M, 2.0M },
                new[] { 1.0M, 2.0M, 3.0M },
                new[] { 1.0M, 2.0M, 3.0M, 4.0M },
                new[] { 1.0M, 2.0M, 3.0M, 4.0M, 5.0M },
                new[] { 1.0M, 2.0M, 3.0M, 4.0M, 5.0M, 6.0M },
                new[] { 1.0M, 2.0M, 3.0M, 4.0M, 5.0M, 6.0M, 7.0M },
                new[] { 1.0M, 2.0M, 3.0M, 4.0M, 5.0M, 6.0M, 7.0M, 8.0M }, 
                new[] { 1.0M, 2.0M, 3.0M, 4.0M, 5.0M, 6.0M, 7.0M, 8.0M, 9.0M },
                new[] { 1.0M, 2.0M, 3.0M, 4.0M, 5.0M, 6.0M, 7.0M, 8.0M, 9.0M, 10.0M, 11.0M, 12.0M, 13.0M, 14.0M, 15.0M, 16.0M, 17.0M, 18.0M, 19.0M, 20.0M },
                //new[] { decimal.MaxValue, decimal.MaxValue },
            };
        
         
        public static TheoryData<decimal?[]> SumNullableDecimal
            => new()
            {
                new decimal?[] { },
                new decimal?[] { default },
                new decimal?[] { 1.0M },
                new decimal?[] { 1.0M, 2.0M },
                new decimal?[] { 1.0M, 2.0M, 3.0M },
                new decimal?[] { 1.0M, 2.0M, 3.0M, 4.0M },
                new decimal?[] { 1.0M, 2.0M, 3.0M, 4.0M, 5.0M },
                new decimal?[] { default, default, default },
                new decimal?[] { default, 2.0M, 3.0M, 4.0M, default },
                new decimal?[] { 1.0M, 2.0M, default, 4.0M, 5.0M },
                //new decimal?[] { decimal.MaxValue, decimal.MaxValue },
            };
    }
}