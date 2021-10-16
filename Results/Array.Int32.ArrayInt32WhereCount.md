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
|                   Method | Count |         Mean |      Error |     StdDev |          Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |------ |-------------:|-----------:|-----------:|---------------:|--------:|-------:|----------:|
|                  ForLoop |   100 |     73.06 ns |   0.666 ns |   0.591 ns |       baseline |         |      - |         - |
|              ForeachLoop |   100 |     72.63 ns |   0.521 ns |   0.461 ns |   1.01x faster |   0.01x |      - |         - |
|                     Linq |   100 |    328.52 ns |   1.269 ns |   1.059 ns |   4.50x slower |   0.03x | 0.0153 |      32 B |
|               LinqFaster |   100 |    260.64 ns |   0.103 ns |   0.086 ns |   3.57x slower |   0.03x |      - |         - |
|             LinqFasterer |   100 |    256.09 ns |   1.611 ns |   1.507 ns |   3.51x slower |   0.04x |      - |         - |
|                   LinqAF |   100 |    262.43 ns |   0.278 ns |   0.232 ns |   3.59x slower |   0.03x |      - |         - |
|            LinqOptimizer |   100 | 33,855.56 ns | 132.828 ns | 124.247 ns | 463.28x slower |   4.23x | 9.0942 |  19,066 B |
|                 SpanLinq |   100 |    258.09 ns |   1.737 ns |   1.624 ns |   3.53x slower |   0.03x |      - |         - |
|                  Streams |   100 |    505.72 ns |   3.117 ns |   2.916 ns |   6.92x slower |   0.08x | 0.1717 |     360 B |
|               StructLinq |   100 |    264.90 ns |   0.911 ns |   0.761 ns |   3.63x slower |   0.03x | 0.0305 |      64 B |
| StructLinq_ValueDelegate |   100 |    102.64 ns |   0.104 ns |   0.087 ns |   1.41x slower |   0.01x |      - |         - |
|                Hyperlinq |   100 |    212.60 ns |   0.260 ns |   0.243 ns |   2.91x slower |   0.02x |      - |         - |
|  Hyperlinq_ValueDelegate |   100 |     94.83 ns |   0.056 ns |   0.049 ns |   1.30x slower |   0.01x |      - |         - |
