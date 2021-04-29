## Enumerable.Int32.EnumerableInt32WhereSelectToList

### Source
[EnumerableInt32WhereSelectToList.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelectToList.cs)

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
|                   Method | Count |        Mean |     Error |    StdDev |      Median |  Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |------------:|----------:|----------:|------------:|-------:|--------:|--------:|------:|------:|----------:|
|              ForeachLoop |   100 |    448.5 ns |   2.09 ns |   3.88 ns |    447.4 ns |   1.00 |    0.00 |  0.5851 |     - |     - |   1,224 B |
|                     Linq |   100 |    822.8 ns |  16.56 ns |  34.92 ns |    798.1 ns |   1.85 |    0.08 |  0.6418 |     - |     - |   1,344 B |
|                   LinqAF |   100 |  1,022.3 ns |   6.97 ns |   6.52 ns |  1,020.2 ns |   2.27 |    0.02 |  0.5836 |     - |     - |   1,224 B |
|            LinqOptimizer |   100 | 50,917.8 ns | 444.98 ns | 416.23 ns | 50,881.4 ns | 112.93 |    1.39 | 15.5640 |     - |     - |  32,645 B |
|                  Streams |   100 |  2,232.4 ns |  13.74 ns |  12.18 ns |  2,231.1 ns |   4.95 |    0.06 |  0.8430 |     - |     - |   1,768 B |
|               StructLinq |   100 |    979.2 ns |   7.33 ns |   6.49 ns |    978.0 ns |   2.17 |    0.03 |  0.2785 |     - |     - |     584 B |
| StructLinq_ValueDelegate |   100 |    698.2 ns |  13.64 ns |  18.20 ns |    707.6 ns |   1.55 |    0.05 |  0.2365 |     - |     - |     496 B |
|                Hyperlinq |   100 |    966.2 ns |   8.31 ns |   6.94 ns |    963.4 ns |   2.15 |    0.02 |  0.2365 |     - |     - |     496 B |
|  Hyperlinq_ValueDelegate |   100 |    733.8 ns |   2.58 ns |   2.41 ns |    733.9 ns |   1.63 |    0.02 |  0.2365 |     - |     - |     496 B |
