## List.Int32.ListInt32Where

### Source
[ListInt32Where.cs](../LinqBenchmarks/List/Int32/ListInt32Where.cs)

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
|                   Method | Count |         Mean |      Error |     StdDev |       Median |          Ratio | RatioSD |   Gen 0 | Allocated |
|------------------------- |------ |-------------:|-----------:|-----------:|-------------:|---------------:|--------:|--------:|----------:|
|                  ForLoop |   100 |     78.97 ns |   0.328 ns |   0.306 ns |     78.93 ns |       baseline |         |       - |         - |
|              ForeachLoop |   100 |    124.91 ns |   0.554 ns |   0.491 ns |    124.79 ns |   1.58x slower |   0.01x |       - |         - |
|                     Linq |   100 |    669.09 ns |   7.214 ns |   6.395 ns |    668.82 ns |   8.47x slower |   0.10x |  0.0343 |      72 B |
|               LinqFaster |   100 |    466.12 ns |   2.378 ns |   2.224 ns |    465.54 ns |   5.90x slower |   0.04x |  0.3095 |     648 B |
|             LinqFasterer |   100 |    423.09 ns |   2.032 ns |   1.900 ns |    423.03 ns |   5.36x slower |   0.03x |  0.3328 |     696 B |
|                   LinqAF |   100 |    488.67 ns |   8.959 ns |  19.476 ns |    480.56 ns |   6.19x slower |   0.25x |       - |         - |
|            LinqOptimizer |   100 | 45,771.38 ns | 164.774 ns | 154.130 ns | 45,748.66 ns | 579.64x slower |   2.91x | 13.6719 |  28,651 B |
|                 SpanLinq |   100 |    322.19 ns |   0.391 ns |   0.346 ns |    322.06 ns |   4.08x slower |   0.02x |       - |         - |
|                  Streams |   100 |  1,162.38 ns |   4.656 ns |   4.355 ns |  1,160.65 ns |  14.72x slower |   0.07x |  0.2899 |     608 B |
|               StructLinq |   100 |    356.16 ns |   3.834 ns |   3.586 ns |    355.50 ns |   4.51x slower |   0.05x |  0.0153 |      32 B |
| StructLinq_ValueDelegate |   100 |    181.43 ns |   0.246 ns |   0.218 ns |    181.36 ns |   2.30x slower |   0.01x |       - |         - |
|                Hyperlinq |   100 |    317.92 ns |   6.379 ns |   5.967 ns |    316.04 ns |   4.03x slower |   0.07x |       - |         - |
|  Hyperlinq_ValueDelegate |   100 |    219.50 ns |   0.179 ns |   0.159 ns |    219.49 ns |   2.78x slower |   0.01x |       - |         - |
