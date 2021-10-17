## ImmutableArray.Int32.ImmutableArrayInt32Where

### Source
[ImmutableArrayInt32Where.cs](../LinqBenchmarks/ImmutableArray/Int32/ImmutableArrayInt32Where.cs)

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
|                   Method | Count |         Mean |      Error |     StdDev |          Ratio | RatioSD |   Gen 0 | Allocated |
|------------------------- |------ |-------------:|-----------:|-----------:|---------------:|--------:|--------:|----------:|
|                  ForLoop |   100 |     73.45 ns |   0.595 ns |   0.557 ns |       baseline |         |       - |         - |
|              ForeachLoop |   100 |     72.74 ns |   0.467 ns |   0.390 ns |   1.01x faster |   0.01x |       - |         - |
|                     Linq |   100 |    347.68 ns |   1.529 ns |   1.430 ns |   4.73x slower |   0.04x |  0.0229 |      48 B |
|             LinqFasterer |   100 |    427.53 ns |   2.358 ns |   2.206 ns |   5.82x slower |   0.05x |  0.3443 |     720 B |
|            LinqOptimizer |   100 | 47,611.62 ns | 468.426 ns | 415.248 ns | 647.85x slower |   7.82x | 13.8550 |  29,051 B |
|                  Streams |   100 |  1,237.33 ns |   1.793 ns |   1.400 ns |  16.83x slower |   0.13x |  0.2899 |     608 B |
|               StructLinq |   100 |    366.90 ns |   4.172 ns |   3.902 ns |   5.00x slower |   0.07x |  0.0153 |      32 B |
| StructLinq_ValueDelegate |   100 |    198.05 ns |   0.626 ns |   0.586 ns |   2.70x slower |   0.02x |       - |         - |
|                Hyperlinq |   100 |    339.41 ns |   5.032 ns |   4.707 ns |   4.62x slower |   0.06x |       - |         - |
|  Hyperlinq_ValueDelegate |   100 |    223.18 ns |   0.414 ns |   0.367 ns |   3.04x slower |   0.02x |       - |         - |
