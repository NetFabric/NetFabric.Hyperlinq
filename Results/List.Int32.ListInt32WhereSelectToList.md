## List.Int32.ListInt32WhereSelectToList

### Source
[ListInt32WhereSelectToList.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelectToList.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [0.7.0](https://www.nuget.org/packages/LinqOptimizer.CSharp/0.7.0)
- SpanLinq: [0.0.1](https://www.nuget.org/packages/SpanLinq/0.0.1)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.27.0](https://www.nuget.org/packages/StructLinq/0.27.0)
- NetFabric.Hyperlinq: [3.0.0-beta46](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta46)
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
|                  ForLoop |   100 |    332.7 ns |   1.63 ns |   1.36 ns |       baseline |         |  0.3095 |     648 B |
|              ForeachLoop |   100 |    325.4 ns |   1.78 ns |   1.66 ns |   1.02x faster |   0.01x |  0.3095 |     648 B |
|                     Linq |   100 |    550.2 ns |   0.98 ns |   0.77 ns |   1.65x slower |   0.01x |  0.3824 |     800 B |
|               LinqFaster |   100 |    521.3 ns |   4.41 ns |   3.91 ns |   1.57x slower |   0.01x |  0.4396 |     920 B |
|             LinqFasterer |   100 |    531.3 ns |   2.44 ns |   2.16 ns |   1.60x slower |   0.01x |  0.5617 |   1,176 B |
|                   LinqAF |   100 |    656.9 ns |   2.62 ns |   2.45 ns |   1.97x slower |   0.01x |  0.3090 |     648 B |
|            LinqOptimizer |   100 | 53,322.7 ns | 214.40 ns | 190.06 ns | 160.30x slower |   0.88x | 15.1978 |  31,844 B |
|                 SpanLinq |   100 |    532.6 ns |   1.48 ns |   1.31 ns |   1.60x slower |   0.01x |  0.3090 |     648 B |
|                  Streams |   100 |  1,393.8 ns |   6.52 ns |   6.10 ns |   4.19x slower |   0.02x |  0.5684 |   1,192 B |
|               StructLinq |   100 |    583.1 ns |   1.45 ns |   1.21 ns |   1.75x slower |   0.01x |  0.1755 |     368 B |
| StructLinq_ValueDelegate |   100 |    339.1 ns |   2.50 ns |   2.22 ns |   1.02x slower |   0.01x |  0.1297 |     272 B |
|                Hyperlinq |   100 |    610.8 ns |   1.43 ns |   1.19 ns |   1.84x slower |   0.01x |  0.1297 |     272 B |
|  Hyperlinq_ValueDelegate |   100 |    373.0 ns |   2.42 ns |   2.26 ns |   1.12x slower |   0.01x |  0.1297 |     272 B |
