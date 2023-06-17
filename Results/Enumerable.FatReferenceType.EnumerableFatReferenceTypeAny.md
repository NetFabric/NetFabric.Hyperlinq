## Enumerable.FatReferenceType.EnumerableFatReferenceTypeAny

### Source
[EnumerableFatReferenceTypeAny.cs](../LinqBenchmarks/Enumerable/FatReferenceType/EnumerableFatReferenceTypeAny.cs)

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
|              ForeachLoop | .NET 6 | .NET 6.0 |   100 | 14.072 ns | 0.1100 ns | 0.0975 ns | 14.071 ns |     baseline |         | 0.0229 |      48 B |             |
|                     Linq | .NET 6 | .NET 6.0 |   100 | 23.727 ns | 0.1742 ns | 0.1545 ns | 23.688 ns | 1.69x slower |   0.02x | 0.0229 |      48 B |  1.00x more |
|                   LinqAF | .NET 6 | .NET 6.0 |   100 | 33.699 ns | 0.3296 ns | 0.2752 ns | 33.549 ns | 2.40x slower |   0.03x | 0.0229 |      48 B |  1.00x more |
|               StructLinq | .NET 6 | .NET 6.0 |   100 | 17.490 ns | 0.3403 ns | 0.4303 ns | 17.342 ns | 1.25x slower |   0.04x | 0.0344 |      72 B |  1.50x more |
| StructLinq_ValueDelegate | .NET 6 | .NET 6.0 |   100 | 17.505 ns | 0.2791 ns | 0.2331 ns | 17.475 ns | 1.24x slower |   0.02x | 0.0344 |      72 B |  1.50x more |
|                Hyperlinq | .NET 6 | .NET 6.0 |   100 | 21.975 ns | 0.7361 ns | 2.1588 ns | 20.656 ns | 1.58x slower |   0.18x | 0.0229 |      48 B |  1.00x more |
|                          |        |          |       |           |           |           |           |              |         |        |           |             |
|              ForeachLoop | .NET 8 | .NET 8.0 |   100 |  9.500 ns | 0.2810 ns | 0.7972 ns |  9.114 ns |     baseline |         | 0.0229 |      48 B |             |
|                     Linq | .NET 8 | .NET 8.0 |   100 | 24.209 ns | 0.5938 ns | 1.6845 ns | 23.310 ns | 2.57x slower |   0.28x | 0.0229 |      48 B |  1.00x more |
|                   LinqAF | .NET 8 | .NET 8.0 |   100 | 25.909 ns | 0.2898 ns | 0.2420 ns | 25.868 ns | 2.73x slower |   0.19x | 0.0229 |      48 B |  1.00x more |
|               StructLinq | .NET 8 | .NET 8.0 |   100 | 14.409 ns | 0.1745 ns | 0.1457 ns | 14.405 ns | 1.52x slower |   0.10x | 0.0344 |      72 B |  1.50x more |
| StructLinq_ValueDelegate | .NET 8 | .NET 8.0 |   100 | 14.167 ns | 0.1315 ns | 0.1165 ns | 14.115 ns | 1.50x slower |   0.10x | 0.0344 |      72 B |  1.50x more |
|                Hyperlinq | .NET 8 | .NET 8.0 |   100 | 18.766 ns | 0.2441 ns | 0.2164 ns | 18.747 ns | 1.99x slower |   0.12x | 0.0229 |      48 B |  1.00x more |
