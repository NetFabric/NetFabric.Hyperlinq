## List.Int32.ListInt32SkipTakeWhere

### Source
[ListInt32SkipTakeWhere.cs](../LinqBenchmarks/List/Int32/ListInt32SkipTakeWhere.cs)

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
|                  ForLoop | 1000 |   100 |     79.98 ns |   0.371 ns |   0.347 ns |       baseline |         |       - |         - |
|                     Linq | 1000 |   100 |    739.15 ns |   3.860 ns |   3.422 ns |   9.24x slower |   0.07x |  0.0725 |     152 B |
|               LinqFaster | 1000 |   100 |    987.08 ns |   4.800 ns |   4.490 ns |  12.34x slower |   0.08x |  0.7458 |   1,560 B |
|             LinqFasterer | 1000 |   100 |    801.75 ns |  15.423 ns |  12.879 ns |  10.02x slower |   0.20x |  2.4424 |   5,112 B |
|                   LinqAF | 1000 |   100 |  3,931.09 ns |  10.877 ns |  10.175 ns |  49.15x slower |   0.26x |       - |         - |
|            LinqOptimizer | 1000 |   100 | 63,920.73 ns | 345.284 ns | 322.979 ns | 799.19x slower |   4.61x | 15.6250 |  32,741 B |
|                 SpanLinq | 1000 |   100 |    274.22 ns |   1.430 ns |   1.267 ns |   3.43x slower |   0.02x |       - |         - |
|                  Streams | 1000 |   100 |  6,946.86 ns |  13.467 ns |  11.938 ns |  86.84x slower |   0.34x |  0.4425 |     936 B |
|               StructLinq | 1000 |   100 |    292.66 ns |   1.753 ns |   1.554 ns |   3.66x slower |   0.03x |  0.0458 |      96 B |
| StructLinq_ValueDelegate | 1000 |   100 |    184.40 ns |   0.321 ns |   0.268 ns |   2.31x slower |   0.01x |       - |         - |
|                Hyperlinq | 1000 |   100 |    310.82 ns |   0.721 ns |   0.639 ns |   3.89x slower |   0.02x |       - |         - |
|  Hyperlinq_ValueDelegate | 1000 |   100 |    240.26 ns |   0.237 ns |   0.198 ns |   3.00x slower |   0.01x |       - |         - |
