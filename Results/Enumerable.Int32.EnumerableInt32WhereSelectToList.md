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
|                   Method | Count |        Mean |     Error |    StdDev |  Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |------------:|----------:|----------:|-------:|--------:|--------:|------:|------:|----------:|
|              ForeachLoop |   100 |    500.0 ns |   2.37 ns |   2.10 ns |   1.00 |    0.00 |  0.5846 |     - |     - |   1,224 B |
|                     Linq |   100 |    827.9 ns |   2.90 ns |   2.42 ns |   1.66 |    0.01 |  0.6418 |     - |     - |   1,344 B |
|                   LinqAF |   100 |  1,020.1 ns |   5.01 ns |   3.91 ns |   2.04 |    0.01 |  0.5836 |     - |     - |   1,224 B |
|            LinqOptimizer |   100 | 50,250.7 ns | 205.00 ns | 191.76 ns | 100.52 |    0.68 | 15.5640 |     - |     - |  32,645 B |
|                  Streams |   100 |  2,069.1 ns |  14.05 ns |  12.46 ns |   4.14 |    0.03 |  0.8430 |     - |     - |   1,768 B |
|               StructLinq |   100 |    970.4 ns |   5.21 ns |   4.88 ns |   1.94 |    0.01 |  0.2785 |     - |     - |     584 B |
| StructLinq_ValueDelegate |   100 |    656.6 ns |   3.64 ns |   3.40 ns |   1.31 |    0.01 |  0.2365 |     - |     - |     496 B |
|                Hyperlinq |   100 |  1,020.2 ns |   3.95 ns |   3.70 ns |   2.04 |    0.01 |  0.2365 |     - |     - |     496 B |
|  Hyperlinq_ValueDelegate |   100 |    684.1 ns |   3.97 ns |   3.71 ns |   1.37 |    0.01 |  0.2365 |     - |     - |     496 B |
