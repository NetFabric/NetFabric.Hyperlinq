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
- StructLinq.BCL: [0.27.0](https://www.nuget.org/packages/StructLinq/0.27.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)

### Results:
``` ini

BenchmarkDotNet=v0.13.1, OS=macOS Catalina 10.15.7 (19H1417) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-rc.1.21458.32
  [Host]     : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  .NET 6 PGO : .NET 6.0.0 (6.0.21.45113), X64 RyuJIT

Job=.NET 6 PGO  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Count |      Mean |     Error |    StdDev |    Median |         Ratio | RatioSD |   Gen 0 | Allocated |
|------------------------- |------ |----------:|----------:|----------:|----------:|--------------:|--------:|--------:|----------:|
|                  ForLoop |   100 |  1.624 μs | 0.0091 μs | 0.0085 μs |  1.622 μs |      baseline |         |  5.5237 |     11 KB |
|              ForeachLoop |   100 |  1.759 μs | 0.0102 μs | 0.0096 μs |  1.760 μs |  1.08x slower |   0.01x |  5.5237 |     11 KB |
|                     Linq |   100 |  1.902 μs | 0.0111 μs | 0.0098 μs |  1.897 μs |  1.17x slower |   0.01x |  4.0035 |      8 KB |
|               LinqFaster |   100 |  2.115 μs | 0.0141 μs | 0.0132 μs |  2.108 μs |  1.30x slower |   0.01x |  5.5237 |     11 KB |
|             LinqFasterer |   100 |  2.052 μs | 0.0145 μs | 0.0135 μs |  2.052 μs |  1.26x slower |   0.01x |  6.3934 |     13 KB |
|                   LinqAF |   100 |  3.195 μs | 0.0625 μs | 0.1079 μs |  3.146 μs |  2.02x slower |   0.07x |  5.5122 |     11 KB |
|            LinqOptimizer |   100 | 62.684 μs | 0.4771 μs | 0.4462 μs | 62.459 μs | 38.60x slower |   0.32x | 73.9746 |    155 KB |
|                 SpanLinq |   100 |  2.366 μs | 0.0239 μs | 0.0200 μs |  2.362 μs |  1.46x slower |   0.01x |  5.5237 |     11 KB |
|                  Streams |   100 |  2.878 μs | 0.0185 μs | 0.0174 μs |  2.873 μs |  1.77x slower |   0.01x |  5.7716 |     12 KB |
|               StructLinq |   100 |  1.496 μs | 0.0208 μs | 0.0195 μs |  1.488 μs |  1.09x faster |   0.02x |  1.7109 |      4 KB |
| StructLinq_ValueDelegate |   100 |  1.106 μs | 0.0074 μs | 0.0069 μs |  1.103 μs |  1.47x faster |   0.01x |  1.6575 |      3 KB |
|                Hyperlinq |   100 |  1.780 μs | 0.0169 μs | 0.0158 μs |  1.784 μs |  1.10x slower |   0.01x |  1.6632 |      3 KB |
|  Hyperlinq_ValueDelegate |   100 |  1.361 μs | 0.0110 μs | 0.0103 μs |  1.356 μs |  1.19x faster |   0.01x |  1.6632 |      3 KB |
