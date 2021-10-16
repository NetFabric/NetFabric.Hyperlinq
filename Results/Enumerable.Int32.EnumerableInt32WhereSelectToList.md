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
- NetFabric.Hyperlinq: [3.0.0-beta48](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta48)
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)

### Results:
``` ini

BenchmarkDotNet=v0.13.1, OS=macOS Catalina 10.15.7 (19H1419) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-rc.2.21505.57
  [Host]     : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  .NET 6 PGO : .NET 6.0.0 (6.0.21.48005), X64 RyuJIT

Job=.NET 6 PGO  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Count |        Mean |     Error |    StdDev |          Ratio | RatioSD |   Gen 0 | Allocated |
|------------------------- |------ |------------:|----------:|----------:|---------------:|--------:|--------:|----------:|
|              ForeachLoop |   100 |    501.8 ns |   1.21 ns |   0.94 ns |       baseline |         |  0.5846 |   1,224 B |
|                     Linq |   100 |    813.4 ns |   2.90 ns |   2.71 ns |   1.62x slower |   0.01x |  0.6418 |   1,344 B |
|                   LinqAF |   100 |    793.5 ns |  15.50 ns |  13.74 ns |   1.58x slower |   0.03x |  0.5846 |   1,224 B |
|            LinqOptimizer |   100 | 53,033.4 ns | 232.13 ns | 217.14 ns | 105.77x slower |   0.55x | 15.5640 |  32,567 B |
|                  Streams |   100 |  2,117.7 ns |  16.62 ns |  15.55 ns |   4.23x slower |   0.03x |  0.8430 |   1,768 B |
|               StructLinq |   100 |    935.3 ns |   3.69 ns |   3.08 ns |   1.86x slower |   0.01x |  0.2785 |     584 B |
| StructLinq_ValueDelegate |   100 |    609.1 ns |   4.09 ns |   3.63 ns |   1.21x slower |   0.01x |  0.2365 |     496 B |
|                Hyperlinq |   100 |    932.3 ns |   5.82 ns |   5.44 ns |   1.86x slower |   0.01x |  0.2365 |     496 B |
|  Hyperlinq_ValueDelegate |   100 |    659.9 ns |   1.77 ns |   1.48 ns |   1.32x slower |   0.00x |  0.2365 |     496 B |
