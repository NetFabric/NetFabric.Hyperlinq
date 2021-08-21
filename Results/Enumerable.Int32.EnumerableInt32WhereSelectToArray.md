## Enumerable.Int32.EnumerableInt32WhereSelectToArray

### Source
[EnumerableInt32WhereSelectToArray.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelectToArray.cs)

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
|                   Method | Count |        Mean |     Error |    StdDev |         Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |------------:|----------:|----------:|--------------:|--------:|--------:|------:|------:|----------:|
|              ForeachLoop |   100 |    542.7 ns |   1.42 ns |   1.32 ns |      baseline |         |  0.7877 |     - |     - |   1,648 B |
|                     Linq |   100 |    887.4 ns |   3.43 ns |   3.21 ns |  1.64x slower |   0.01x |  0.6266 |     - |     - |   1,312 B |
|                   LinqAF |   100 |    920.8 ns |   2.79 ns |   2.33 ns |  1.70x slower |   0.01x |  0.7725 |     - |     - |   1,616 B |
|            LinqOptimizer |   100 | 54,071.0 ns | 132.50 ns | 123.94 ns | 99.63x slower |   0.35x | 15.3198 |     - |     - |  32,108 B |
|                  Streams |   100 |  1,560.5 ns |   1.44 ns |   1.28 ns |  2.88x slower |   0.01x |  1.0319 |     - |     - |   2,160 B |
|               StructLinq |   100 |    921.2 ns |   0.69 ns |   0.65 ns |  1.70x slower |   0.00x |  0.2632 |     - |     - |     552 B |
| StructLinq_ValueDelegate |   100 |    619.2 ns |   0.35 ns |   0.31 ns |  1.14x slower |   0.00x |  0.2213 |     - |     - |     464 B |
|                Hyperlinq |   100 |    944.3 ns |   1.68 ns |   1.49 ns |  1.74x slower |   0.00x |  0.2213 |     - |     - |     464 B |
|  Hyperlinq_ValueDelegate |   100 |    724.2 ns |   0.37 ns |   0.31 ns |  1.33x slower |   0.00x |  0.2213 |     - |     - |     464 B |
