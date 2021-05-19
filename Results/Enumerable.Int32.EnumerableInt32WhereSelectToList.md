## Enumerable.Int32.EnumerableInt32WhereSelectToList

### Source
[EnumerableInt32WhereSelectToList.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelectToList.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [0.7.0](https://www.nuget.org/packages/LinqOptimizer.CSharp/0.7.0)
- SpanLinq: [1.0.0](https://www.nuget.org/packages/SpanLinq/1.0.0)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.26.0](https://www.nuget.org/packages/StructLinq/0.26.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1538-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.4.21227.6
  [Host] : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.22210), X64 RyuJIT

Job=.NET 6  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |------------:|----------:|----------:|------:|--------:|--------:|------:|------:|----------:|
|              ForeachLoop |   100 |    537.1 ns |  10.71 ns |  19.58 ns |  1.00 |    0.00 |  0.5846 |     - |     - |   1,224 B |
|                     Linq |   100 |    817.7 ns |   6.91 ns |   5.77 ns |  1.60 |    0.05 |  0.6418 |     - |     - |   1,344 B |
|                   LinqAF |   100 |  1,125.4 ns |   5.70 ns |   5.33 ns |  2.17 |    0.09 |  0.5836 |     - |     - |   1,224 B |
|            LinqOptimizer |   100 | 51,127.5 ns | 414.56 ns | 387.78 ns | 98.70 |    3.97 | 15.5640 |     - |     - |  32,645 B |
|                  Streams |   100 |  1,979.0 ns |   8.02 ns |   6.70 ns |  3.86 |    0.13 |  0.8430 |     - |     - |   1,768 B |
|               StructLinq |   100 |    975.9 ns |   5.31 ns |   4.97 ns |  1.88 |    0.08 |  0.2785 |     - |     - |     584 B |
| StructLinq_ValueDelegate |   100 |    616.1 ns |   3.15 ns |   2.80 ns |  1.20 |    0.05 |  0.2365 |     - |     - |     496 B |
|                Hyperlinq |   100 |  1,037.9 ns |   5.91 ns |   4.93 ns |  2.03 |    0.07 |  0.2365 |     - |     - |     496 B |
|  Hyperlinq_ValueDelegate |   100 |    721.0 ns |   2.21 ns |   1.85 ns |  1.41 |    0.05 |  0.2365 |     - |     - |     496 B |
