## List.Int32.ListInt32WhereSelectToList

### Source
[ListInt32WhereSelectToList.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelectToList.cs)

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
|                   Method | Count |        Mean |     Error |    StdDev |          Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |------------:|----------:|----------:|---------------:|--------:|--------:|------:|------:|----------:|
|                  ForLoop |   100 |    298.2 ns |   5.84 ns |   6.49 ns |       baseline |         |  0.3095 |     - |     - |     648 B |
|              ForeachLoop |   100 |    293.5 ns |   3.17 ns |   2.81 ns |   1.01x faster |   0.03x |  0.3095 |     - |     - |     648 B |
|                     Linq |   100 |    578.1 ns |  10.01 ns |   8.87 ns |   1.94x slower |   0.06x |  0.3824 |     - |     - |     800 B |
|               LinqFaster |   100 |    505.9 ns |   8.29 ns |   7.35 ns |   1.70x slower |   0.05x |  0.4396 |     - |     - |     920 B |
|             LinqFasterer |   100 |    500.5 ns |   4.62 ns |   3.86 ns |   1.68x slower |   0.05x |  0.5617 |     - |     - |   1,176 B |
|                   LinqAF |   100 |  1,220.8 ns |  16.05 ns |  15.02 ns |   4.10x slower |   0.11x |  0.3090 |     - |     - |     648 B |
|            LinqOptimizer |   100 | 54,891.4 ns | 547.89 ns | 512.50 ns | 184.42x slower |   5.62x | 15.2588 |     - |     - |  31,924 B |
|                 SpanLinq |   100 |    597.8 ns |   6.03 ns |   5.64 ns |   2.01x slower |   0.06x |  0.3090 |     - |     - |     648 B |
|                  Streams |   100 |  1,478.4 ns |   7.55 ns |   5.89 ns |   4.98x slower |   0.14x |  0.5684 |     - |     - |   1,192 B |
|               StructLinq |   100 |    642.2 ns |   3.71 ns |   3.29 ns |   2.16x slower |   0.06x |  0.1755 |     - |     - |     368 B |
| StructLinq_ValueDelegate |   100 |    367.9 ns |   3.93 ns |   3.68 ns |   1.24x slower |   0.03x |  0.1297 |     - |     - |     272 B |
|                Hyperlinq |   100 |    648.8 ns |   6.12 ns |   5.42 ns |   2.18x slower |   0.06x |  0.1297 |     - |     - |     272 B |
|  Hyperlinq_ValueDelegate |   100 |    362.4 ns |   2.48 ns |   2.20 ns |   1.22x slower |   0.04x |  0.1297 |     - |     - |     272 B |
