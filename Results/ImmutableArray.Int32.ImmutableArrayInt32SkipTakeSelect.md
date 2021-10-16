## ImmutableArray.Int32.ImmutableArrayInt32SkipTakeSelect

### Source
[ImmutableArrayInt32SkipTakeSelect.cs](../LinqBenchmarks/ImmutableArray/Int32/ImmutableArrayInt32SkipTakeSelect.cs)

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
|                   Method | Skip | Count |         Mean |      Error |     StdDev |          Ratio | RatioSD |   Gen 0 | Allocated |
|------------------------- |----- |------ |-------------:|-----------:|-----------:|---------------:|--------:|--------:|----------:|
|                  ForLoop | 1000 |   100 |     74.54 ns |   0.165 ns |   0.147 ns |       baseline |         |       - |         - |
|                     Linq | 1000 |   100 |    498.45 ns |   3.363 ns |   3.145 ns |   6.69x slower |   0.05x |  0.0839 |     176 B |
|             LinqFasterer | 1000 |   100 |    870.87 ns |   3.982 ns |   3.325 ns |  11.68x slower |   0.05x |  2.5444 |   5,328 B |
|            LinqOptimizer | 1000 |   100 | 57,407.05 ns | 234.980 ns | 219.801 ns | 770.46x slower |   3.18x | 15.6250 |  32,723 B |
|                  Streams | 1000 |   100 |  7,442.64 ns |  19.597 ns |  17.373 ns |  99.85x slower |   0.31x |  0.4425 |     936 B |
|               StructLinq | 1000 |   100 |    284.25 ns |   0.895 ns |   0.793 ns |   3.81x slower |   0.01x |  0.0458 |      96 B |
| StructLinq_ValueDelegate | 1000 |   100 |    180.02 ns |   0.288 ns |   0.270 ns |   2.42x slower |   0.01x |       - |         - |
|                Hyperlinq | 1000 |   100 |    246.27 ns |   0.604 ns |   0.565 ns |   3.30x slower |   0.01x |       - |         - |
|  Hyperlinq_ValueDelegate | 1000 |   100 |    217.18 ns |   0.299 ns |   0.265 ns |   2.91x slower |   0.01x |       - |         - |
