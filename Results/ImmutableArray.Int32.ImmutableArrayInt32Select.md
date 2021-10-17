## ImmutableArray.Int32.ImmutableArrayInt32Select

### Source
[ImmutableArrayInt32Select.cs](../LinqBenchmarks/ImmutableArray/Int32/ImmutableArrayInt32Select.cs)

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
|                  ForLoop |   100 |     61.93 ns |   0.292 ns |   0.244 ns |       baseline |         |       - |         - |
|              ForeachLoop |   100 |     62.40 ns |   0.227 ns |   0.212 ns |   1.01x slower |   0.01x |       - |         - |
|                     Linq |   100 |    355.26 ns |   1.736 ns |   1.624 ns |   5.73x slower |   0.04x |  0.0229 |      48 B |
|             LinqFasterer |   100 |    446.25 ns |   2.303 ns |   2.155 ns |   7.20x slower |   0.03x |  0.4320 |     904 B |
|            LinqOptimizer |   100 | 40,376.41 ns | 349.917 ns | 310.193 ns | 652.36x slower |   6.11x | 13.6108 |  28,584 B |
|                  Streams |   100 |  1,599.34 ns |   6.396 ns |   5.983 ns |  25.84x slower |   0.12x |  0.2899 |     608 B |
|               StructLinq |   100 |    226.79 ns |   0.874 ns |   0.817 ns |   3.66x slower |   0.02x |  0.0153 |      32 B |
| StructLinq_ValueDelegate |   100 |    180.11 ns |   0.347 ns |   0.324 ns |   2.91x slower |   0.01x |       - |         - |
|                Hyperlinq |   100 |    255.47 ns |   1.096 ns |   0.915 ns |   4.13x slower |   0.02x |       - |         - |
|  Hyperlinq_ValueDelegate |   100 |    201.31 ns |   0.425 ns |   0.355 ns |   3.25x slower |   0.01x |       - |         - |
