## Enumerable.Int32.EnumerableInt32WhereSelectToList

### Source
[EnumerableInt32WhereSelectToList.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelectToList.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [0.7.0](https://www.nuget.org/packages/LinqOptimizer.CSharp/0.7.0)
- SpanLinq: [0.0.1](https://www.nuget.org/packages/SpanLinq/0.0.1)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.26.0](https://www.nuget.org/packages/StructLinq/0.26.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)

### Results:
``` ini

BenchmarkDotNet=v0.13.0, OS=Windows 10.0.19043.985 (21H1/May2021Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.4.21227.6
  [Host] : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.22210), X64 RyuJIT

Job=.NET 6  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Count |        Mean |     Error |    StdDev |          Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |------------:|----------:|----------:|---------------:|--------:|--------:|------:|------:|----------:|
|              ForeachLoop |   100 |    522.2 ns |   4.66 ns |   4.13 ns |       baseline |         |  0.5846 |     - |     - |   1,224 B |
|                     Linq |   100 |    815.4 ns |   4.26 ns |   3.32 ns |   1.56x slower |   0.01x |  0.6418 |     - |     - |   1,344 B |
|                   LinqAF |   100 |  1,187.6 ns |   8.61 ns |   7.63 ns |   2.27x slower |   0.02x |  0.5836 |     - |     - |   1,224 B |
|            LinqOptimizer |   100 | 53,942.5 ns | 561.33 ns | 497.61 ns | 103.30x slower |   1.43x | 15.5029 |     - |     - |  32,645 B |
|                  Streams |   100 |  2,078.7 ns |  13.83 ns |  11.55 ns |   3.98x slower |   0.03x |  0.8430 |     - |     - |   1,768 B |
|               StructLinq |   100 |  1,093.6 ns |  10.33 ns |   9.16 ns |   2.09x slower |   0.02x |  0.2785 |     - |     - |     584 B |
| StructLinq_ValueDelegate |   100 |    643.8 ns |   7.12 ns |   6.31 ns |   1.23x slower |   0.02x |  0.2365 |     - |     - |     496 B |
|                Hyperlinq |   100 |  1,018.1 ns |   7.46 ns |   6.61 ns |   1.95x slower |   0.02x |  0.2365 |     - |     - |     496 B |
|  Hyperlinq_ValueDelegate |   100 |    774.4 ns |   6.61 ns |   5.86 ns |   1.48x slower |   0.01x |  0.2365 |     - |     - |     496 B |
