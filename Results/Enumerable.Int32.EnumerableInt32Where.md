## Enumerable.Int32.EnumerableInt32Where

### Source
[EnumerableInt32Where.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Where.cs)

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
|                     Linq |   100 |    672.3 ns |   3.05 ns |   2.85 ns |  1.00 |    0.00 |  0.0458 |     - |     - |      96 B |
|                   LinqAF |   100 |    579.5 ns |   2.19 ns |   1.94 ns |  0.86 |    0.00 |  0.0191 |     - |     - |      40 B |
|            LinqOptimizer |   100 | 41,869.1 ns | 619.24 ns | 579.23 ns | 62.28 |    0.88 | 13.9160 |     - |     - |  29,235 B |
|                  Streams |   100 |  1,550.4 ns |   5.68 ns |   5.32 ns |  2.31 |    0.01 |  0.2823 |     - |     - |     592 B |
|               StructLinq |   100 |    451.2 ns |   2.37 ns |   1.98 ns |  0.67 |    0.00 |  0.0305 |     - |     - |      64 B |
| StructLinq_ValueDelegate |   100 |    394.6 ns |   1.41 ns |   1.32 ns |  0.59 |    0.00 |  0.0191 |     - |     - |      40 B |
|                Hyperlinq |   100 |    503.0 ns |   2.39 ns |   2.12 ns |  0.75 |    0.00 |  0.0191 |     - |     - |      40 B |
|  Hyperlinq_ValueDelegate |   100 |    425.8 ns |   2.76 ns |   2.44 ns |  0.63 |    0.00 |  0.0191 |     - |     - |      40 B |
