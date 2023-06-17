## Enumerable.FatReferenceType.EnumerableFatReferenceTypeFirstOrDefault

### Source
[EnumerableFatReferenceTypeFirstOrDefault.cs](../LinqBenchmarks/Enumerable/FatReferenceType/EnumerableFatReferenceTypeFirstOrDefault.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [0.7.0](https://www.nuget.org/packages/LinqOptimizer.CSharp/0.7.0)
- SpanLinq: [0.0.1](https://www.nuget.org/packages/SpanLinq/0.0.1)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.28.1](https://www.nuget.org/packages/StructLinq/0.28.1)
- NetFabric.Hyperlinq: [3.0.0-beta48](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta48)
- System.Linq.Async: [6.0.1](https://www.nuget.org/packages/System.Linq.Async/6.0.1)
- Faslinq: [1.0.5](https://www.nuget.org/packages/Faslinq/1.0.5)

### Results:
``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 10 (10.0.19045.3086/22H2/2022Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=8.0.100-preview.5.23303.2
  [Host] : .NET 6.0.18 (6.0.1823.26907), X64 RyuJIT AVX2
  .NET 6 : .NET 6.0.18 (6.0.1823.26907), X64 RyuJIT AVX2
  .NET 8 : .NET 8.0.0 (8.0.23.28008), X64 RyuJIT AVX2


```
|                   Method |    Job |  Runtime | Count |      Mean |     Error |    StdDev |    Median |        Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|------------------------- |------- |--------- |------ |----------:|----------:|----------:|----------:|-------------:|--------:|-------:|----------:|------------:|
|              ForeachLoop | .NET 6 | .NET 6.0 |   100 | 14.878 ns | 0.3060 ns | 0.3005 ns | 14.777 ns |     baseline |         | 0.0229 |      48 B |             |
|                     Linq | .NET 6 | .NET 6.0 |   100 | 26.805 ns | 0.2642 ns | 0.2342 ns | 26.753 ns | 1.80x slower |   0.04x | 0.0229 |      48 B |  1.00x more |
|                   LinqAF | .NET 6 | .NET 6.0 |   100 | 38.261 ns | 0.4017 ns | 0.3354 ns | 38.188 ns | 2.56x slower |   0.05x | 0.0229 |      48 B |  1.00x more |
|               StructLinq | .NET 6 | .NET 6.0 |   100 | 19.993 ns | 0.4212 ns | 1.0332 ns | 19.552 ns | 1.35x slower |   0.08x | 0.0344 |      72 B |  1.50x more |
| StructLinq_ValueDelegate | .NET 6 | .NET 6.0 |   100 | 13.755 ns | 0.1519 ns | 0.1347 ns | 13.769 ns | 1.08x faster |   0.02x | 0.0229 |      48 B |  1.00x more |
|                Hyperlinq | .NET 6 | .NET 6.0 |   100 | 37.000 ns | 0.7775 ns | 2.1801 ns | 36.005 ns | 2.53x slower |   0.20x | 0.0344 |      72 B |  1.50x more |
|                          |        |          |       |           |           |           |           |              |         |        |           |             |
|              ForeachLoop | .NET 8 | .NET 8.0 |   100 |  9.272 ns | 0.0609 ns | 0.0540 ns |  9.257 ns |     baseline |         | 0.0229 |      48 B |             |
|                     Linq | .NET 8 | .NET 8.0 |   100 | 20.147 ns | 0.3869 ns | 0.4139 ns | 19.989 ns | 2.18x slower |   0.05x | 0.0229 |      48 B |  1.00x more |
|                   LinqAF | .NET 8 | .NET 8.0 |   100 | 31.235 ns | 0.3653 ns | 0.2852 ns | 31.192 ns | 3.37x slower |   0.04x | 0.0229 |      48 B |  1.00x more |
|               StructLinq | .NET 8 | .NET 8.0 |   100 | 15.171 ns | 0.3150 ns | 0.2947 ns | 15.040 ns | 1.64x slower |   0.03x | 0.0344 |      72 B |  1.50x more |
| StructLinq_ValueDelegate | .NET 8 | .NET 8.0 |   100 | 10.387 ns | 0.1156 ns | 0.0965 ns | 10.372 ns | 1.12x slower |   0.01x | 0.0229 |      48 B |  1.00x more |
|                Hyperlinq | .NET 8 | .NET 8.0 |   100 | 33.449 ns | 0.6909 ns | 0.6463 ns | 33.064 ns | 3.61x slower |   0.08x | 0.0344 |      72 B |  1.50x more |
