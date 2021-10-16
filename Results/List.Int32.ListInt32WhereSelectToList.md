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
|                  ForLoop |   100 |    328.3 ns |   1.38 ns |   1.29 ns |       baseline |         |  0.3095 |     648 B |
|              ForeachLoop |   100 |    323.8 ns |   1.18 ns |   1.11 ns |   1.01x faster |   0.01x |  0.3095 |     648 B |
|                     Linq |   100 |    547.9 ns |   2.64 ns |   2.34 ns |   1.67x slower |   0.01x |  0.3824 |     800 B |
|               LinqFaster |   100 |    524.2 ns |   1.54 ns |   1.29 ns |   1.60x slower |   0.01x |  0.4396 |     920 B |
|             LinqFasterer |   100 |    500.4 ns |   2.52 ns |   2.36 ns |   1.52x slower |   0.01x |  0.5617 |   1,176 B |
|                   LinqAF |   100 |    699.4 ns |   2.55 ns |   2.39 ns |   2.13x slower |   0.01x |  0.3090 |     648 B |
|            LinqOptimizer |   100 | 54,266.3 ns | 322.29 ns | 285.70 ns | 165.26x slower |   0.95x | 15.1978 |  31,844 B |
|                 SpanLinq |   100 |    557.2 ns |   8.76 ns |   7.76 ns |   1.70x slower |   0.02x |  0.3090 |     648 B |
|                  Streams |   100 |  1,351.1 ns |   6.00 ns |   5.61 ns |   4.12x slower |   0.02x |  0.5684 |   1,192 B |
|               StructLinq |   100 |    604.9 ns |   2.92 ns |   2.73 ns |   1.84x slower |   0.01x |  0.1755 |     368 B |
| StructLinq_ValueDelegate |   100 |    337.5 ns |   1.72 ns |   1.53 ns |   1.03x slower |   0.01x |  0.1297 |     272 B |
|                Hyperlinq |   100 |    599.8 ns |   1.88 ns |   1.76 ns |   1.83x slower |   0.01x |  0.1297 |     272 B |
|  Hyperlinq_ValueDelegate |   100 |    371.5 ns |   1.20 ns |   1.12 ns |   1.13x slower |   0.01x |  0.1297 |     272 B |
