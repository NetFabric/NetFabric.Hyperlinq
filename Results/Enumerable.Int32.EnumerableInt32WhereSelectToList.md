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

BenchmarkDotNet=v0.13.0, OS=macOS Catalina 10.15.7 (19H1323) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.7.21379.14
  [Host] : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.37719), X64 RyuJIT

Job=.NET 6  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Count |        Mean |     Error |    StdDev |          Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |------------:|----------:|----------:|---------------:|--------:|--------:|------:|------:|----------:|
|              ForeachLoop |   100 |    503.8 ns |   0.67 ns |   0.63 ns |       baseline |         |  0.5846 |     - |     - |   1,224 B |
|                     Linq |   100 |    807.2 ns |   1.27 ns |   1.13 ns |   1.60x slower |   0.00x |  0.6418 |     - |     - |   1,344 B |
|                   LinqAF |   100 |    847.0 ns |   1.33 ns |   1.04 ns |   1.68x slower |   0.00x |  0.5846 |     - |     - |   1,224 B |
|            LinqOptimizer |   100 | 52,985.0 ns | 163.26 ns | 144.73 ns | 105.16x slower |   0.28x | 15.5640 |     - |     - |  32,566 B |
|                  Streams |   100 |  2,103.3 ns |  39.83 ns |  31.10 ns |   4.17x slower |   0.06x |  0.8430 |     - |     - |   1,768 B |
|               StructLinq |   100 |    948.8 ns |   2.72 ns |   2.54 ns |   1.88x slower |   0.00x |  0.2785 |     - |     - |     584 B |
| StructLinq_ValueDelegate |   100 |    620.1 ns |   0.75 ns |   0.62 ns |   1.23x slower |   0.00x |  0.2365 |     - |     - |     496 B |
|                Hyperlinq |   100 |    981.5 ns |   1.88 ns |   1.67 ns |   1.95x slower |   0.00x |  0.2365 |     - |     - |     496 B |
|  Hyperlinq_ValueDelegate |   100 |    711.9 ns |   4.53 ns |   4.24 ns |   1.41x slower |   0.01x |  0.2365 |     - |     - |     496 B |
