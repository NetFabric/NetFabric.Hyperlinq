## List.Int32.ListInt32Where

### Source
[ListInt32Where.cs](../LinqBenchmarks/List/Int32/ListInt32Where.cs)

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
|                   Method | Count |        Mean |     Error |    StdDev |  Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |------------:|----------:|----------:|-------:|--------:|--------:|------:|------:|----------:|
|                  ForLoop |   100 |    135.0 ns |   1.40 ns |   1.24 ns |   1.00 |    0.00 |       - |     - |     - |         - |
|              ForeachLoop |   100 |    171.6 ns |   1.08 ns |   0.90 ns |   1.27 |    0.02 |       - |     - |     - |         - |
|                     Linq |   100 |    626.2 ns |   7.10 ns |   6.65 ns |   4.64 |    0.07 |  0.0343 |     - |     - |      72 B |
|               LinqFaster |   100 |    407.5 ns |   3.85 ns |   3.42 ns |   3.02 |    0.03 |  0.3095 |     - |     - |     648 B |
|             LinqFasterer |   100 |    440.6 ns |   7.85 ns |   6.56 ns |   3.27 |    0.06 |  0.3328 |     - |     - |     696 B |
|                   LinqAF |   100 |    851.4 ns |   5.66 ns |   5.29 ns |   6.30 |    0.07 |       - |     - |     - |         - |
|            LinqOptimizer |   100 | 41,859.4 ns | 335.56 ns | 280.21 ns | 310.41 |    4.01 | 13.7329 |     - |     - |  28,794 B |
|                  Streams |   100 |  1,347.4 ns |  21.30 ns |  16.63 ns |  10.00 |    0.17 |  0.2899 |     - |     - |     608 B |
|               StructLinq |   100 |    267.1 ns |   4.47 ns |   4.18 ns |   1.98 |    0.03 |  0.0153 |     - |     - |      32 B |
| StructLinq_ValueDelegate |   100 |    182.0 ns |   0.65 ns |   0.55 ns |   1.35 |    0.01 |       - |     - |     - |         - |
|                Hyperlinq |   100 |    326.4 ns |   6.31 ns |   5.90 ns |   2.42 |    0.05 |       - |     - |     - |         - |
|  Hyperlinq_ValueDelegate |   100 |    213.6 ns |   1.00 ns |   0.93 ns |   1.58 |    0.02 |       - |     - |     - |         - |
