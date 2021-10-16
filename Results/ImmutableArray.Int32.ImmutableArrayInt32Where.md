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
|                  ForLoop |   100 |     72.47 ns |   0.742 ns |   0.694 ns |       baseline |         |       - |         - |
|              ForeachLoop |   100 |     72.64 ns |   0.364 ns |   0.304 ns |   1.00x faster |   0.01x |       - |         - |
|                     Linq |   100 |    348.24 ns |   0.921 ns |   0.769 ns |   4.79x slower |   0.02x |  0.0229 |      48 B |
|             LinqFasterer |   100 |    422.42 ns |   1.964 ns |   1.741 ns |   5.82x slower |   0.05x |  0.3443 |     720 B |
|            LinqOptimizer |   100 | 47,410.21 ns | 175.833 ns | 164.474 ns | 654.29x slower |   7.24x | 13.8550 |  29,051 B |
|                  Streams |   100 |  1,260.58 ns |   6.119 ns |   5.724 ns |  17.40x slower |   0.18x |  0.2899 |     608 B |
|               StructLinq |   100 |    368.39 ns |   5.183 ns |   4.848 ns |   5.08x slower |   0.10x |  0.0153 |      32 B |
| StructLinq_ValueDelegate |   100 |    197.87 ns |   0.311 ns |   0.291 ns |   2.73x slower |   0.03x |       - |         - |
|                Hyperlinq |   100 |    322.88 ns |   5.118 ns |   4.787 ns |   4.46x slower |   0.07x |       - |         - |
|  Hyperlinq_ValueDelegate |   100 |    225.60 ns |   0.261 ns |   0.218 ns |   3.10x slower |   0.02x |       - |         - |
