## Enumerable.Int32.EnumerableInt32WhereSelectToArray

### Source
[EnumerableInt32WhereSelectToArray.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelectToArray.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [](https://www.nuget.org/packages/LinqOptimizer.CSharp/)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.26.0](https://www.nuget.org/packages/StructLinq/0.26.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1527-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.4.21227.6
  [Host] : .NET 5.0.4 (5.0.421.11614), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.22210), X64 RyuJIT

Job=.NET 6  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Count |        Mean |       Error |      StdDev |      Median |  Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |------------:|------------:|------------:|------------:|-------:|--------:|--------:|------:|------:|----------:|
|              ForeachLoop |   100 |    529.3 ns |     4.34 ns |     3.85 ns |    529.0 ns |   1.00 |    0.00 |  0.7877 |     - |     - |   1,648 B |
|                     Linq |   100 |    962.6 ns |     3.31 ns |     2.93 ns |    962.6 ns |   1.82 |    0.02 |  0.6266 |     - |     - |   1,312 B |
|                   LinqAF |   100 |  1,023.7 ns |     8.48 ns |     7.52 ns |  1,021.8 ns |   1.93 |    0.02 |  0.7725 |     - |     - |   1,616 B |
|            LinqOptimizer |   100 | 53,300.7 ns | 1,557.68 ns | 4,592.87 ns | 49,970.0 ns | 105.69 |    7.97 | 15.3809 |     - |     - |  32,189 B |
|                  Streams |   100 |  1,541.7 ns |     6.90 ns |     5.77 ns |  1,540.7 ns |   2.91 |    0.03 |  1.0319 |     - |     - |   2,160 B |
|               StructLinq |   100 |    966.3 ns |     7.81 ns |     7.31 ns |    963.9 ns |   1.82 |    0.02 |  0.2632 |     - |     - |     552 B |
| StructLinq_ValueDelegate |   100 |    613.5 ns |     8.44 ns |     8.67 ns |    610.9 ns |   1.16 |    0.02 |  0.2213 |     - |     - |     464 B |
|                Hyperlinq |   100 |  1,064.3 ns |    44.75 ns |   131.93 ns |    974.5 ns |   2.09 |    0.20 |  0.2213 |     - |     - |     464 B |
|  Hyperlinq_ValueDelegate |   100 |    713.0 ns |     2.85 ns |     2.52 ns |    712.1 ns |   1.35 |    0.01 |  0.2213 |     - |     - |     464 B |
