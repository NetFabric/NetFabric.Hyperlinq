## Array.Int32.ArrayInt32WhereSelectToList

### Source
[ArrayInt32WhereSelectToList.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelectToList.cs)

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

BenchmarkDotNet=v0.13.0, OS=Windows 10.0.19043.985 (21H1/May2021Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.4.21227.6
  [Host] : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.22210), X64 RyuJIT

Job=.NET 6  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Count |        Mean |       Error |    StdDev |      Median |          Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |------------:|------------:|----------:|------------:|---------------:|--------:|--------:|------:|------:|----------:|
|                  ForLoop |   100 |    224.4 ns |     1.39 ns |   1.30 ns |    224.2 ns |       baseline |         |  0.3097 |     - |     - |     648 B |
|              ForeachLoop |   100 |    257.6 ns |     2.60 ns |   2.31 ns |    257.7 ns |   1.15x slower |   0.01x |  0.3095 |     - |     - |     648 B |
|                     Linq |   100 |    488.2 ns |     5.01 ns |   4.44 ns |    488.6 ns |   2.18x slower |   0.02x |  0.3595 |     - |     - |     752 B |
|               LinqFaster |   100 |    384.8 ns |     3.25 ns |   2.71 ns |    384.9 ns |   1.72x slower |   0.02x |  0.4473 |     - |     - |     936 B |
|             LinqFasterer |   100 |    579.9 ns |    11.48 ns |   9.59 ns |    575.3 ns |   2.59x slower |   0.05x |  0.6113 |     - |     - |   1,280 B |
|                   LinqAF |   100 |    690.7 ns |    13.12 ns |  24.64 ns |    678.4 ns |   3.18x slower |   0.13x |  0.3090 |     - |     - |     648 B |
|            LinqOptimizer |   100 | 57,940.9 ns | 1,067.88 ns | 998.90 ns | 57,806.0 ns | 258.24x slower |   4.25x | 14.6484 |     - |     - |  30,760 B |
|                 SpanLinq |   100 |    572.8 ns |     5.40 ns |   4.79 ns |    573.6 ns |   2.55x slower |   0.03x |  0.3090 |     - |     - |     648 B |
|                  Streams |   100 |  1,334.0 ns |    25.52 ns |  41.93 ns |  1,347.0 ns |   5.81x slower |   0.20x |  0.5684 |     - |     - |   1,192 B |
|               StructLinq |   100 |    656.6 ns |     8.85 ns |   7.39 ns |    655.5 ns |   2.93x slower |   0.04x |  0.1755 |     - |     - |     368 B |
| StructLinq_ValueDelegate |   100 |    339.4 ns |     4.23 ns |   3.75 ns |    338.9 ns |   1.51x slower |   0.02x |  0.1297 |     - |     - |     272 B |
|                Hyperlinq |   100 |    638.6 ns |     7.33 ns |   6.12 ns |    638.6 ns |   2.85x slower |   0.03x |  0.1297 |     - |     - |     272 B |
|  Hyperlinq_ValueDelegate |   100 |    384.1 ns |     7.73 ns |  17.45 ns |    377.4 ns |   1.80x slower |   0.08x |  0.1297 |     - |     - |     272 B |
