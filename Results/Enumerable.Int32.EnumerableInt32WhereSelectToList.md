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
- StructLinq.BCL: [0.27.0](https://www.nuget.org/packages/StructLinq/0.27.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)

### Results:
``` ini

BenchmarkDotNet=v0.13.1, OS=macOS Catalina 10.15.7 (19H1417) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-rc.1.21458.32
  [Host]     : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  .NET 6 PGO : .NET 6.0.0 (6.0.21.45113), X64 RyuJIT

Job=.NET 6 PGO  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Count |        Mean |     Error |    StdDev |          Ratio | RatioSD |   Gen 0 | Allocated |
|------------------------- |------ |------------:|----------:|----------:|---------------:|--------:|--------:|----------:|
|              ForeachLoop |   100 |    501.2 ns |   4.54 ns |   4.02 ns |       baseline |         |  0.5846 |   1,224 B |
|                     Linq |   100 |    887.3 ns |   5.09 ns |   4.25 ns |   1.77x slower |   0.02x |  0.6418 |   1,344 B |
|                   LinqAF |   100 |    843.8 ns |   4.01 ns |   3.55 ns |   1.68x slower |   0.01x |  0.5846 |   1,224 B |
|            LinqOptimizer |   100 | 53,062.7 ns | 239.37 ns | 212.20 ns | 105.88x slower |   0.91x | 15.5640 |  32,565 B |
|                  Streams |   100 |  2,146.5 ns |  13.09 ns |  11.61 ns |   4.28x slower |   0.05x |  0.8430 |   1,768 B |
|               StructLinq |   100 |    937.7 ns |   3.84 ns |   3.41 ns |   1.87x slower |   0.02x |  0.2785 |     584 B |
| StructLinq_ValueDelegate |   100 |    613.0 ns |   5.60 ns |   4.67 ns |   1.22x slower |   0.01x |  0.2365 |     496 B |
|                Hyperlinq |   100 |    905.5 ns |   4.09 ns |   3.82 ns |   1.81x slower |   0.02x |  0.2365 |     496 B |
|  Hyperlinq_ValueDelegate |   100 |    657.2 ns |   4.60 ns |   4.31 ns |   1.31x slower |   0.01x |  0.2365 |     496 B |
