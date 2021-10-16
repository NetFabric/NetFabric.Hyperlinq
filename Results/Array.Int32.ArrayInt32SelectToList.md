## Array.Int32.ArrayInt32SelectToList

### Source
[ArrayInt32SelectToList.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SelectToList.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [0.7.0](https://www.nuget.org/packages/LinqOptimizer.CSharp/0.7.0)
- SpanLinq: [0.0.1](https://www.nuget.org/packages/SpanLinq/0.0.1)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.27.0](https://www.nuget.org/packages/StructLinq/0.27.0)
- NetFabric.Hyperlinq: [3.0.0-beta48](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta48)
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)

### Results:
``` ini

BenchmarkDotNet=v0.13.1, OS=macOS Catalina 10.15.7 (19H1419) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-rc.2.21505.57
  [Host]     : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  .NET 6 PGO : .NET 6.0.0 (6.0.21.48005), X64 RyuJIT

Job=.NET 6 PGO  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                       Method | Count |         Mean |      Error |     StdDev |       Median |          Ratio | RatioSD |   Gen 0 | Allocated |
|----------------------------- |------ |-------------:|-----------:|-----------:|-------------:|---------------:|--------:|--------:|----------:|
|                      ForLoop |   100 |    325.78 ns |   1.172 ns |   1.039 ns |    325.46 ns |       baseline |         |  0.5660 |   1,184 B |
|                  ForeachLoop |   100 |    325.43 ns |   0.979 ns |   0.817 ns |    325.62 ns |   1.00x faster |   0.00x |  0.5660 |   1,184 B |
|                         Linq |   100 |    332.43 ns |   0.323 ns |   0.286 ns |    332.39 ns |   1.02x slower |   0.00x |  0.2408 |     504 B |
|                   LinqFaster |   100 |    308.08 ns |   0.917 ns |   0.858 ns |    307.98 ns |   1.06x faster |   0.00x |  0.4206 |     880 B |
|              LinqFaster_SIMD |   100 |    146.78 ns |   0.529 ns |   0.413 ns |    146.62 ns |   2.22x faster |   0.01x |  0.4208 |     880 B |
|                 LinqFasterer |   100 |    309.62 ns |   0.538 ns |   0.477 ns |    309.63 ns |   1.05x faster |   0.00x |  0.4206 |     880 B |
|                       LinqAF |   100 |    585.30 ns |   4.299 ns |   3.590 ns |    584.62 ns |   1.80x slower |   0.01x |  0.5655 |   1,184 B |
|                LinqOptimizer |   100 | 37,166.99 ns | 731.473 ns | 751.169 ns | 37,113.43 ns | 114.52x slower |   2.31x | 13.5498 |  28,341 B |
|                     SpanLinq |   100 |    360.75 ns |   1.875 ns |   1.566 ns |    360.22 ns |   1.11x slower |   0.01x |  0.2179 |     456 B |
|                      Streams |   100 |  1,486.02 ns |   2.214 ns |   1.849 ns |  1,485.64 ns |   4.56x slower |   0.02x |  0.7534 |   1,576 B |
|                   StructLinq |   100 |    275.69 ns |   0.789 ns |   0.699 ns |    275.65 ns |   1.18x faster |   0.00x |  0.2484 |     520 B |
|     StructLinq_ValueDelegate |   100 |    209.20 ns |   4.200 ns |   4.668 ns |    205.99 ns |   1.56x faster |   0.04x |  0.2370 |     496 B |
|                    Hyperlinq |   100 |    266.12 ns |   0.449 ns |   0.398 ns |    266.19 ns |   1.22x faster |   0.00x |  0.2179 |     456 B |
|      Hyperlinq_ValueDelegate |   100 |    124.70 ns |   1.234 ns |   1.094 ns |    124.66 ns |   2.61x faster |   0.02x |  0.2179 |     456 B |
|               Hyperlinq_SIMD |   100 |    106.98 ns |   0.236 ns |   0.221 ns |    106.98 ns |   3.05x faster |   0.01x |  0.2180 |     456 B |
| Hyperlinq_ValueDelegate_SIMD |   100 |     70.79 ns |   0.211 ns |   0.197 ns |     70.72 ns |   4.60x faster |   0.02x |  0.2180 |     456 B |
