## List.Int32.ListInt32Select

### Source
[ListInt32Select.cs](../LinqBenchmarks/List/Int32/ListInt32Select.cs)

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
|                  ForLoop |   100 |    110.1 ns |     0.31 ns |     0.28 ns |    110.0 ns |   1.00 |    0.00 |       - |     - |     - |         - |
|              ForeachLoop |   100 |    139.0 ns |     0.66 ns |     0.55 ns |    138.9 ns |   1.26 |    0.01 |       - |     - |     - |         - |
|                     Linq |   100 |    663.8 ns |     9.61 ns |     8.99 ns |    661.2 ns |   6.04 |    0.08 |  0.0343 |     - |     - |      72 B |
|               LinqFaster |   100 |    375.4 ns |     7.28 ns |     6.45 ns |    373.2 ns |   3.41 |    0.06 |  0.2179 |     - |     - |     456 B |
|                   LinqAF |   100 |    783.2 ns |     4.24 ns |     3.96 ns |    782.9 ns |   7.12 |    0.04 |       - |     - |     - |         - |
|            LinqOptimizer |   100 | 39,539.4 ns | 1,125.62 ns | 3,318.92 ns | 37,544.8 ns | 375.65 |   30.33 | 13.4277 |     - |     - |  28,183 B |
|                  Streams |   100 |  1,423.9 ns |     7.69 ns |     7.20 ns |  1,425.5 ns |  12.93 |    0.08 |  0.2899 |     - |     - |     608 B |
|               StructLinq |   100 |    211.5 ns |     0.45 ns |     0.40 ns |    211.5 ns |   1.92 |    0.01 |  0.0153 |     - |     - |      32 B |
| StructLinq_ValueDelegate |   100 |    163.3 ns |     0.55 ns |     0.51 ns |    163.3 ns |   1.48 |    0.01 |       - |     - |     - |         - |
|                Hyperlinq |   100 |    237.5 ns |     1.14 ns |     1.01 ns |    237.3 ns |   2.16 |    0.01 |       - |     - |     - |         - |
|  Hyperlinq_ValueDelegate |   100 |    185.7 ns |     0.62 ns |     0.55 ns |    185.7 ns |   1.69 |    0.01 |       - |     - |     - |         - |
