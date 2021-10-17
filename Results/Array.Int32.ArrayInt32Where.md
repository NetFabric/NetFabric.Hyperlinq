## Array.Int32.ArrayInt32Where

### Source
[ArrayInt32Where.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Where.cs)

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
|                   Method | Count |        Mean |     Error |    StdDev |         Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |------ |------------:|----------:|----------:|--------------:|--------:|-------:|----------:|
|                  ForLoop |   100 |    73.54 ns |  0.308 ns |  0.288 ns |      baseline |         |      - |         - |
|              ForeachLoop |   100 |    73.79 ns |  0.541 ns |  0.506 ns |  1.00x slower |   0.01x |      - |         - |
|                     Linq |   100 |   353.14 ns |  1.567 ns |  1.389 ns |  4.80x slower |   0.03x | 0.0229 |      48 B |
|               LinqFaster |   100 |   333.26 ns |  2.480 ns |  2.319 ns |  4.53x slower |   0.03x | 0.3171 |     664 B |
|             LinqFasterer |   100 |   500.74 ns |  3.379 ns |  3.160 ns |  6.81x slower |   0.03x | 0.2136 |     448 B |
|                   LinqAF |   100 |   495.49 ns |  3.124 ns |  2.769 ns |  6.74x slower |   0.05x |      - |         - |
|            LinqOptimizer |   100 | 1,570.78 ns | 14.811 ns | 13.854 ns | 21.36x slower |   0.19x | 4.1485 |   8,682 B |
|                 SpanLinq |   100 |   246.69 ns |  0.461 ns |  0.360 ns |  3.35x slower |   0.01x |      - |         - |
|                  Streams |   100 | 1,215.80 ns |  5.099 ns |  4.770 ns | 16.53x slower |   0.10x | 0.2785 |     584 B |
|               StructLinq |   100 |   321.59 ns |  5.495 ns |  5.140 ns |  4.37x slower |   0.07x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |   100 |   217.51 ns |  0.517 ns |  0.484 ns |  2.96x slower |   0.01x |      - |         - |
|                Hyperlinq |   100 |   264.94 ns |  2.532 ns |  2.245 ns |  3.60x slower |   0.04x |      - |         - |
|  Hyperlinq_ValueDelegate |   100 |   222.74 ns |  0.570 ns |  0.506 ns |  3.03x slower |   0.01x |      - |         - |
