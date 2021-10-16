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
|                  ForLoop |   100 |    235.9 ns |   4.76 ns |   5.67 ns |       baseline |         |  0.3095 |     648 B |
|              ForeachLoop |   100 |    224.7 ns |   0.55 ns |   0.46 ns |   1.05x faster |   0.02x |  0.3097 |     648 B |
|                     Linq |   100 |    504.6 ns |   0.78 ns |   0.73 ns |   2.14x slower |   0.05x |  0.3595 |     752 B |
|               LinqFaster |   100 |    427.5 ns |   0.99 ns |   0.87 ns |   1.82x slower |   0.04x |  0.4473 |     936 B |
|             LinqFasterer |   100 |    567.6 ns |   1.58 ns |   1.48 ns |   2.41x slower |   0.05x |  0.6113 |   1,280 B |
|                   LinqAF |   100 |    598.2 ns |   1.22 ns |   1.14 ns |   2.54x slower |   0.06x |  0.3090 |     648 B |
|            LinqOptimizer |   100 | 47,826.5 ns | 177.38 ns | 165.92 ns | 202.78x slower |   4.57x | 14.6484 |  30,760 B |
|                 SpanLinq |   100 |    560.2 ns |   1.23 ns |   1.15 ns |   2.38x slower |   0.05x |  0.3090 |     648 B |
|                  Streams |   100 |  1,382.0 ns |   2.72 ns |   2.41 ns |   5.87x slower |   0.12x |  0.5684 |   1,192 B |
|               StructLinq |   100 |    602.6 ns |   1.70 ns |   1.33 ns |   2.57x slower |   0.04x |  0.1755 |     368 B |
| StructLinq_ValueDelegate |   100 |    373.4 ns |   0.75 ns |   0.66 ns |   1.59x slower |   0.03x |  0.1297 |     272 B |
|                Hyperlinq |   100 |    585.4 ns |   1.76 ns |   1.65 ns |   2.48x slower |   0.05x |  0.1297 |     272 B |
|  Hyperlinq_ValueDelegate |   100 |    366.4 ns |   0.52 ns |   0.43 ns |   1.56x slower |   0.03x |  0.1297 |     272 B |
