## ImmutableArray.Int32.ImmutableArrayInt32Sum

### Source
[ImmutableArrayInt32Sum.cs](../LinqBenchmarks/ImmutableArray/Int32/ImmutableArrayInt32Sum.cs)

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
|                   Method | Count |         Mean |      Error |     StdDev |       Median |          Ratio | RatioSD |  Gen 0 |  Gen 1 | Allocated |
|------------------------- |------ |-------------:|-----------:|-----------:|-------------:|---------------:|--------:|-------:|-------:|----------:|
|                  ForLoop |   100 |     48.15 ns |   0.160 ns |   0.142 ns |     48.08 ns |       baseline |         |      - |      - |         - |
|              ForeachLoop |   100 |     47.97 ns |   0.137 ns |   0.122 ns |     47.94 ns |   1.00x faster |   0.00x |      - |      - |         - |
|                     Linq |   100 |    307.62 ns |   1.593 ns |   1.490 ns |    306.70 ns |   6.39x slower |   0.04x | 0.0267 |      - |      56 B |
|             LinqFasterer |   100 |    148.27 ns |   0.579 ns |   0.483 ns |    148.19 ns |   3.08x slower |   0.02x | 0.2141 |      - |     448 B |
|            LinqOptimizer |   100 | 28,292.92 ns | 238.636 ns | 199.272 ns | 28,237.42 ns | 587.54x slower |   4.20x | 8.3008 |      - |  17,414 B |
|                  Streams |   100 |    422.19 ns |   2.309 ns |   2.047 ns |    421.52 ns |   8.77x slower |   0.04x | 0.1259 |      - |     264 B |
|               StructLinq |   100 |     90.81 ns |   0.342 ns |   0.320 ns |     90.67 ns |   1.89x slower |   0.01x | 0.0153 | 0.0001 |      32 B |
| StructLinq_ValueDelegate |   100 |     66.54 ns |   0.165 ns |   0.146 ns |     66.47 ns |   1.38x slower |   0.01x |      - |      - |         - |
|                Hyperlinq |   100 |     18.11 ns |   0.030 ns |   0.056 ns |     18.08 ns |   2.66x faster |   0.01x |      - |      - |         - |
