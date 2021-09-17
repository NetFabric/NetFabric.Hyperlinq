## Array.Int32.ArrayInt32WhereSelectToList

### Source
[ArrayInt32WhereSelectToList.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelectToList.cs)

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
|                  ForLoop |   100 |    229.9 ns |   1.58 ns |   1.48 ns |       baseline |         |  0.3095 |     648 B |
|              ForeachLoop |   100 |    228.3 ns |   1.00 ns |   0.89 ns |   1.01x faster |   0.01x |  0.3097 |     648 B |
|                     Linq |   100 |    510.1 ns |   4.05 ns |   3.38 ns |   2.22x slower |   0.02x |  0.3595 |     752 B |
|               LinqFaster |   100 |    422.8 ns |   1.88 ns |   1.75 ns |   1.84x slower |   0.02x |  0.4473 |     936 B |
|             LinqFasterer |   100 |    585.3 ns |   2.82 ns |   2.35 ns |   2.54x slower |   0.02x |  0.6113 |   1,280 B |
|                   LinqAF |   100 |    591.1 ns |   0.98 ns |   0.77 ns |   2.57x slower |   0.02x |  0.3090 |     648 B |
|            LinqOptimizer |   100 | 48,434.5 ns | 487.94 ns | 432.55 ns | 210.65x slower |   2.35x | 14.6484 |  30,760 B |
|                 SpanLinq |   100 |    535.2 ns |   3.60 ns |   3.36 ns |   2.33x slower |   0.02x |  0.3090 |     648 B |
|                  Streams |   100 |  1,387.4 ns |   6.82 ns |   6.38 ns |   6.04x slower |   0.04x |  0.5684 |   1,192 B |
|               StructLinq |   100 |    603.7 ns |   2.97 ns |   2.78 ns |   2.63x slower |   0.02x |  0.1755 |     368 B |
| StructLinq_ValueDelegate |   100 |    372.5 ns |   1.60 ns |   1.50 ns |   1.62x slower |   0.01x |  0.1297 |     272 B |
|                Hyperlinq |   100 |    644.9 ns |   2.86 ns |   2.23 ns |   2.80x slower |   0.02x |  0.1297 |     272 B |
|  Hyperlinq_ValueDelegate |   100 |    390.0 ns |   3.34 ns |   2.96 ns |   1.70x slower |   0.01x |  0.1297 |     272 B |
