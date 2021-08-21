## List.ValueType.ListValueTypeWhereSelectToArray

### Source
[ListValueTypeWhereSelectToArray.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelectToArray.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [0.7.0](https://www.nuget.org/packages/LinqOptimizer.CSharp/0.7.0)
- SpanLinq: [0.0.1](https://www.nuget.org/packages/SpanLinq/0.0.1)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.26.0](https://www.nuget.org/packages/StructLinq/0.26.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)

### Results:
``` ini

BenchmarkDotNet=v0.13.0, OS=macOS Catalina 10.15.7 (19H1323) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.7.21379.14
  [Host] : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.37719), X64 RyuJIT

Job=.NET 6  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Count |      Mean |     Error |    StdDev |         Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |----------:|----------:|----------:|--------------:|--------:|--------:|------:|------:|----------:|
|                  ForLoop |   100 |  1.630 μs | 0.0071 μs | 0.0067 μs |      baseline |         |  5.5237 |     - |     - |     11 KB |
|              ForeachLoop |   100 |  1.760 μs | 0.0101 μs | 0.0094 μs |  1.08x slower |   0.01x |  5.5237 |     - |     - |     11 KB |
|                     Linq |   100 |  1.897 μs | 0.0039 μs | 0.0035 μs |  1.16x slower |   0.00x |  4.0016 |     - |     - |      8 KB |
|               LinqFaster |   100 |  2.133 μs | 0.0109 μs | 0.0097 μs |  1.31x slower |   0.01x |  5.5237 |     - |     - |     11 KB |
|             LinqFasterer |   100 |  2.041 μs | 0.0084 μs | 0.0075 μs |  1.25x slower |   0.01x |  6.3934 |     - |     - |     13 KB |
|                   LinqAF |   100 |  3.094 μs | 0.0105 μs | 0.0098 μs |  1.90x slower |   0.01x |  5.5122 |     - |     - |     11 KB |
|            LinqOptimizer |   100 | 62.613 μs | 0.4669 μs | 0.4367 μs | 38.42x slower |   0.31x | 73.9746 |     - |     - |    155 KB |
|                 SpanLinq |   100 |  2.352 μs | 0.0045 μs | 0.0038 μs |  1.44x slower |   0.01x |  5.5237 |     - |     - |     11 KB |
|                  Streams |   100 |  2.835 μs | 0.0071 μs | 0.0059 μs |  1.74x slower |   0.01x |  5.7716 |     - |     - |     12 KB |
|               StructLinq |   100 |  1.523 μs | 0.0029 μs | 0.0027 μs |  1.07x faster |   0.01x |  1.7109 |     - |     - |      4 KB |
| StructLinq_ValueDelegate |   100 |  1.084 μs | 0.0015 μs | 0.0013 μs |  1.50x faster |   0.01x |  1.6575 |     - |     - |      3 KB |
|                Hyperlinq |   100 |  1.846 μs | 0.0041 μs | 0.0032 μs |  1.13x slower |   0.01x |  1.6632 |     - |     - |      3 KB |
|  Hyperlinq_ValueDelegate |   100 |  1.428 μs | 0.0058 μs | 0.0051 μs |  1.14x faster |   0.01x |  1.6632 |     - |     - |      3 KB |
