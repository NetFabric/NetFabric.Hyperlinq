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
|                   Method | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |------------:|----------:|----------:|------:|--------:|--------:|------:|------:|----------:|
|              ForeachLoop |   100 |    529.3 ns |   2.82 ns |   2.50 ns |  1.00 |    0.00 |  0.7877 |     - |     - |   1,648 B |
|                     Linq |   100 |    901.7 ns |   3.67 ns |   3.06 ns |  1.70 |    0.01 |  0.6266 |     - |     - |   1,312 B |
|                   LinqAF |   100 |  1,025.6 ns |   4.85 ns |   4.30 ns |  1.94 |    0.01 |  0.7725 |     - |     - |   1,616 B |
|            LinqOptimizer |   100 | 49,681.1 ns | 222.81 ns | 208.42 ns | 93.89 |    0.51 | 15.3809 |     - |     - |  32,189 B |
|                  Streams |   100 |  1,497.6 ns |  29.47 ns |  28.95 ns |  2.83 |    0.06 |  1.0319 |     - |     - |   2,160 B |
|               StructLinq |   100 |    975.2 ns |   4.11 ns |   3.21 ns |  1.84 |    0.01 |  0.2632 |     - |     - |     552 B |
| StructLinq_ValueDelegate |   100 |    650.1 ns |   4.00 ns |   3.74 ns |  1.23 |    0.01 |  0.2213 |     - |     - |     464 B |
|                Hyperlinq |   100 |    975.6 ns |   3.71 ns |   3.29 ns |  1.84 |    0.01 |  0.2213 |     - |     - |     464 B |
|  Hyperlinq_ValueDelegate |   100 |    672.8 ns |   4.15 ns |   3.88 ns |  1.27 |    0.01 |  0.2213 |     - |     - |     464 B |
