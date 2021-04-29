## List.Int32.ListInt32WhereSelect

### Source
[ListInt32WhereSelect.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelect.cs)

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
|                   Method | Count |         Mean |      Error |     StdDev |  Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |-------------:|-----------:|-----------:|-------:|--------:|--------:|------:|------:|----------:|
|                  ForLoop |   100 |    131.19 ns |   1.026 ns |   0.910 ns |   1.00 |    0.00 |       - |     - |     - |         - |
|              ForeachLoop |   100 |     84.20 ns |   0.460 ns |   0.384 ns |   0.64 |    0.01 |       - |     - |     - |         - |
|                     Linq |   100 |    856.01 ns |   4.792 ns |   4.248 ns |   6.53 |    0.05 |  0.0725 |     - |     - |     152 B |
|               LinqFaster |   100 |    513.89 ns |   4.593 ns |   4.297 ns |   3.92 |    0.04 |  0.3090 |     - |     - |     648 B |
|                   LinqAF |   100 |    966.01 ns |   6.097 ns |   5.405 ns |   7.36 |    0.08 |       - |     - |     - |         - |
|            LinqOptimizer |   100 | 49,034.92 ns | 702.718 ns | 586.801 ns | 373.72 |    3.41 | 14.6484 |     - |     - |  30,787 B |
|                  Streams |   100 |  1,529.63 ns |  29.037 ns |  29.819 ns |  11.63 |    0.29 |  0.3624 |     - |     - |     760 B |
|               StructLinq |   100 |    374.66 ns |   3.943 ns |   3.495 ns |   2.86 |    0.03 |  0.0305 |     - |     - |      64 B |
| StructLinq_ValueDelegate |   100 |    184.81 ns |   0.327 ns |   0.290 ns |   1.41 |    0.01 |       - |     - |     - |         - |
|                Hyperlinq |   100 |    378.06 ns |   2.229 ns |   1.976 ns |   2.88 |    0.03 |       - |     - |     - |         - |
|  Hyperlinq_ValueDelegate |   100 |    211.99 ns |   0.694 ns |   0.649 ns |   1.62 |    0.01 |       - |     - |     - |         - |
