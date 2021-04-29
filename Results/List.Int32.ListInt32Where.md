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
|                  ForLoop |   100 |    132.2 ns |   0.96 ns |   0.80 ns |   1.00 |    0.00 |       - |     - |     - |         - |
|              ForeachLoop |   100 |    168.2 ns |   0.76 ns |   0.64 ns |   1.27 |    0.01 |       - |     - |     - |         - |
|                     Linq |   100 |    569.2 ns |   3.27 ns |   2.90 ns |   4.31 |    0.04 |  0.0343 |     - |     - |      72 B |
|               LinqFaster |   100 |    393.9 ns |   2.39 ns |   2.24 ns |   2.98 |    0.02 |  0.3095 |     - |     - |     648 B |
|                   LinqAF |   100 |    788.0 ns |   3.19 ns |   2.49 ns |   5.96 |    0.05 |       - |     - |     - |         - |
|            LinqOptimizer |   100 | 41,415.4 ns | 299.53 ns | 250.12 ns | 313.29 |    2.88 | 13.7329 |     - |     - |  28,794 B |
|                  Streams |   100 |  1,385.9 ns |  27.43 ns |  25.66 ns |  10.45 |    0.20 |  0.2899 |     - |     - |     608 B |
|               StructLinq |   100 |    378.0 ns |   3.28 ns |   3.07 ns |   2.87 |    0.03 |  0.0153 |     - |     - |      32 B |
| StructLinq_ValueDelegate |   100 |    167.6 ns |   0.38 ns |   0.36 ns |   1.27 |    0.01 |       - |     - |     - |         - |
|                Hyperlinq |   100 |    354.6 ns |   2.98 ns |   2.79 ns |   2.68 |    0.02 |       - |     - |     - |         - |
|  Hyperlinq_ValueDelegate |   100 |    203.3 ns |   0.56 ns |   0.50 ns |   1.54 |    0.01 |       - |     - |     - |         - |
