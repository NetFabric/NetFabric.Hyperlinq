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
|                  ForLoop | 1000 |   100 |     74.59 ns |   0.243 ns |   0.228 ns |       baseline |         |       - |         - |
|                     Linq | 1000 |   100 |    499.89 ns |   1.036 ns |   0.865 ns |   6.70x slower |   0.02x |  0.0839 |     176 B |
|             LinqFasterer | 1000 |   100 |    829.36 ns |   5.317 ns |   4.973 ns |  11.12x slower |   0.08x |  2.5444 |   5,328 B |
|            LinqOptimizer | 1000 |   100 | 57,351.05 ns | 232.609 ns | 217.583 ns | 768.87x slower |   3.25x | 15.6250 |  32,723 B |
|                  Streams | 1000 |   100 |  7,425.67 ns |  24.389 ns |  22.814 ns |  99.55x slower |   0.48x |  0.4425 |     936 B |
|               StructLinq | 1000 |   100 |    284.30 ns |   5.598 ns |   6.222 ns |   3.81x slower |   0.08x |  0.0458 |      96 B |
| StructLinq_ValueDelegate | 1000 |   100 |    181.43 ns |   1.807 ns |   1.690 ns |   2.43x slower |   0.03x |       - |         - |
|                Hyperlinq | 1000 |   100 |    231.03 ns |   0.174 ns |   0.136 ns |   3.10x slower |   0.01x |       - |         - |
|  Hyperlinq_ValueDelegate | 1000 |   100 |    224.46 ns |   0.442 ns |   0.414 ns |   3.01x slower |   0.01x |       - |         - |
