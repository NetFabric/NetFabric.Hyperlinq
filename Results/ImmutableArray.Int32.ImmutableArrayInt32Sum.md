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
|                   Method | Count |         Mean |      Error |     StdDev |          Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |------ |-------------:|-----------:|-----------:|---------------:|--------:|-------:|----------:|
|                  ForLoop |   100 |     48.38 ns |   0.090 ns |   0.084 ns |       baseline |         |      - |         - |
|              ForeachLoop |   100 |     48.10 ns |   0.124 ns |   0.110 ns |   1.01x faster |   0.00x |      - |         - |
|                     Linq |   100 |    308.06 ns |   0.961 ns |   0.899 ns |   6.37x slower |   0.02x | 0.0267 |      56 B |
|             LinqFasterer |   100 |    149.46 ns |   0.773 ns |   0.723 ns |   3.09x slower |   0.01x | 0.2141 |     448 B |
|            LinqOptimizer |   100 | 28,590.40 ns | 183.827 ns | 171.952 ns | 590.97x slower |   4.02x | 8.3008 |  17,414 B |
|                  Streams |   100 |    430.89 ns |   8.301 ns |   8.882 ns |   8.90x slower |   0.20x | 0.1259 |     264 B |
|               StructLinq |   100 |    102.05 ns |   1.528 ns |   1.429 ns |   2.11x slower |   0.03x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |   100 |     66.59 ns |   0.129 ns |   0.121 ns |   1.38x slower |   0.00x |      - |         - |
|                Hyperlinq |   100 |     20.32 ns |   0.057 ns |   0.047 ns |   2.38x faster |   0.01x |      - |         - |
