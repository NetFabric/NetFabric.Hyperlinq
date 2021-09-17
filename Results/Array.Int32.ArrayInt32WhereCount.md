## Array.Int32.ArrayInt32WhereCount

### Source
[ArrayInt32WhereCount.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereCount.cs)

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
|                   Method | Count |         Mean |      Error |    StdDev |       Median |          Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |------ |-------------:|-----------:|----------:|-------------:|---------------:|--------:|-------:|----------:|
|                  ForLoop |   100 |     72.69 ns |   0.524 ns |  0.491 ns |     72.62 ns |       baseline |         |      - |         - |
|              ForeachLoop |   100 |     73.23 ns |   0.458 ns |  0.428 ns |     73.01 ns |   1.01x slower |   0.01x |      - |         - |
|                     Linq |   100 |    329.61 ns |   2.032 ns |  1.801 ns |    329.21 ns |   4.53x slower |   0.04x | 0.0153 |      32 B |
|               LinqFaster |   100 |    235.70 ns |   0.342 ns |  0.267 ns |    235.62 ns |   3.24x slower |   0.02x |      - |         - |
|             LinqFasterer |   100 |    265.68 ns |   0.561 ns |  0.525 ns |    265.44 ns |   3.66x slower |   0.02x |      - |         - |
|                   LinqAF |   100 |    243.65 ns |   2.220 ns |  2.077 ns |    244.14 ns |   3.35x slower |   0.04x |      - |         - |
|            LinqOptimizer |   100 | 33,102.78 ns | 111.308 ns | 92.947 ns | 33,075.70 ns | 455.13x slower |   3.62x | 9.0942 |  19,066 B |
|                 SpanLinq |   100 |    284.87 ns |   0.679 ns |  0.567 ns |    284.83 ns |   3.92x slower |   0.03x |      - |         - |
|                  Streams |   100 |    544.58 ns |   3.567 ns |  3.337 ns |    543.46 ns |   7.49x slower |   0.07x | 0.1717 |     360 B |
|               StructLinq |   100 |    300.01 ns |   1.383 ns |  1.293 ns |    300.01 ns |   4.13x slower |   0.03x | 0.0305 |      64 B |
| StructLinq_ValueDelegate |   100 |     92.99 ns |   0.379 ns |  0.354 ns |     92.86 ns |   1.28x slower |   0.01x |      - |         - |
|                Hyperlinq |   100 |    213.22 ns |   0.686 ns |  0.608 ns |    212.96 ns |   2.93x slower |   0.02x |      - |         - |
|  Hyperlinq_ValueDelegate |   100 |     83.81 ns |   0.202 ns |  0.375 ns |     83.66 ns |   1.15x slower |   0.01x |      - |         - |
