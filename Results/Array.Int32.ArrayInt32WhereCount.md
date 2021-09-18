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
|                   Method | Count |         Mean |      Error |     StdDev |          Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |------ |-------------:|-----------:|-----------:|---------------:|--------:|-------:|----------:|
|                  ForLoop |   100 |     73.04 ns |   0.524 ns |   0.490 ns |       baseline |         |      - |         - |
|              ForeachLoop |   100 |     73.56 ns |   0.447 ns |   0.418 ns |   1.01x slower |   0.01x |      - |         - |
|                     Linq |   100 |    328.80 ns |   0.857 ns |   0.802 ns |   4.50x slower |   0.03x | 0.0153 |      32 B |
|               LinqFaster |   100 |    248.17 ns |   0.180 ns |   0.160 ns |   3.40x slower |   0.02x |      - |         - |
|             LinqFasterer |   100 |    252.12 ns |   0.150 ns |   0.133 ns |   3.45x slower |   0.02x |      - |         - |
|                   LinqAF |   100 |    235.79 ns |   0.619 ns |   0.517 ns |   3.23x slower |   0.02x |      - |         - |
|            LinqOptimizer |   100 | 33,803.82 ns | 201.841 ns | 188.803 ns | 462.84x slower |   3.55x | 9.0942 |  19,066 B |
|                 SpanLinq |   100 |    246.21 ns |   0.137 ns |   0.107 ns |   3.37x slower |   0.02x |      - |         - |
|                  Streams |   100 |    523.92 ns |   3.900 ns |   3.648 ns |   7.17x slower |   0.08x | 0.1717 |     360 B |
|               StructLinq |   100 |    287.91 ns |   0.511 ns |   0.427 ns |   3.94x slower |   0.02x | 0.0305 |      64 B |
| StructLinq_ValueDelegate |   100 |     93.05 ns |   0.131 ns |   0.116 ns |   1.27x slower |   0.01x |      - |         - |
|                Hyperlinq |   100 |    191.15 ns |   1.025 ns |   0.909 ns |   2.62x slower |   0.02x |      - |         - |
|  Hyperlinq_ValueDelegate |   100 |     95.55 ns |   0.090 ns |   0.075 ns |   1.31x slower |   0.01x |      - |         - |
