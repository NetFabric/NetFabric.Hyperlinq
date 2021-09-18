## List.Int32.ListInt32SelectToList

### Source
[ListInt32SelectToList.cs](../LinqBenchmarks/List/Int32/ListInt32SelectToList.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [0.7.0](https://www.nuget.org/packages/LinqOptimizer.CSharp/0.7.0)
- SpanLinq: [0.0.1](https://www.nuget.org/packages/SpanLinq/0.0.1)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.27.0](https://www.nuget.org/packages/StructLinq/0.27.0)
- NetFabric.Hyperlinq: [3.0.0-beta46](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta46)
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
|                       Method | Count |         Mean |      Error |     StdDev |          Ratio | RatioSD |   Gen 0 | Allocated |
|----------------------------- |------ |-------------:|-----------:|-----------:|---------------:|--------:|--------:|----------:|
|                      ForLoop |   100 |    380.74 ns |   1.798 ns |   1.502 ns |       baseline |         |  0.5660 |   1,184 B |
|                  ForeachLoop |   100 |    385.35 ns |   2.585 ns |   2.418 ns |   1.01x slower |   0.01x |  0.5660 |   1,184 B |
|                         Linq |   100 |    341.53 ns |   4.985 ns |   5.541 ns |   1.11x faster |   0.02x |  0.2522 |     528 B |
|                   LinqFaster |   100 |    368.22 ns |   4.331 ns |   3.839 ns |   1.03x faster |   0.01x |  0.4358 |     912 B |
|                 LinqFasterer |   100 |    386.73 ns |   1.048 ns |   0.929 ns |   1.02x slower |   0.01x |  0.6232 |   1,304 B |
|                       LinqAF |   100 |    699.35 ns |  10.455 ns |   9.780 ns |   1.84x slower |   0.03x |  0.5655 |   1,184 B |
|                LinqOptimizer |   100 | 42,276.87 ns | 245.079 ns | 217.256 ns | 110.99x slower |   0.61x | 13.9771 |  29,359 B |
|                     SpanLinq |   100 |    418.66 ns |   2.455 ns |   2.297 ns |   1.10x slower |   0.01x |  0.2179 |     456 B |
|                      Streams |   100 |  1,588.70 ns |   6.139 ns |   4.793 ns |   4.17x slower |   0.02x |  0.7534 |   1,576 B |
|                   StructLinq |   100 |    282.76 ns |   0.382 ns |   0.299 ns |   1.35x faster |   0.01x |  0.2484 |     520 B |
|     StructLinq_ValueDelegate |   100 |    157.06 ns |   0.678 ns |   0.634 ns |   2.42x faster |   0.02x |  0.2370 |     496 B |
|                    Hyperlinq |   100 |    328.89 ns |   1.334 ns |   1.183 ns |   1.16x faster |   0.01x |  0.2179 |     456 B |
|      Hyperlinq_ValueDelegate |   100 |    143.87 ns |   0.833 ns |   0.696 ns |   2.65x faster |   0.02x |  0.2179 |     456 B |
|               Hyperlinq_SIMD |   100 |    111.84 ns |   1.897 ns |   1.682 ns |   3.41x faster |   0.06x |  0.2180 |     456 B |
| Hyperlinq_ValueDelegate_SIMD |   100 |     74.45 ns |   1.160 ns |   1.085 ns |   5.13x faster |   0.07x |  0.2180 |     456 B |
