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
|                   Method | Skip | Count |         Mean |      Error |     StdDev |       Median |          Ratio | RatioSD |   Gen 0 | Allocated |
|------------------------- |----- |------ |-------------:|-----------:|-----------:|-------------:|---------------:|--------:|--------:|----------:|
|                  ForLoop | 1000 |   100 |     74.73 ns |   0.283 ns |   0.250 ns |     74.61 ns |       baseline |         |       - |         - |
|                     Linq | 1000 |   100 |    500.33 ns |   1.201 ns |   0.938 ns |    500.06 ns |   6.69x slower |   0.03x |  0.0839 |     176 B |
|             LinqFasterer | 1000 |   100 |    807.80 ns |   9.443 ns |   8.833 ns |    803.46 ns |  10.82x slower |   0.12x |  2.5444 |   5,328 B |
|            LinqOptimizer | 1000 |   100 | 58,135.74 ns | 385.052 ns | 360.178 ns | 57,943.25 ns | 777.49x slower |   5.94x | 15.6250 |  32,723 B |
|                  Streams | 1000 |   100 |  7,792.68 ns | 149.646 ns | 349.793 ns |  7,656.46 ns | 104.19x slower |   4.95x |  0.4425 |     936 B |
|               StructLinq | 1000 |   100 |    283.15 ns |   5.559 ns |   7.030 ns |    279.84 ns |   3.79x slower |   0.10x |  0.0458 |      96 B |
| StructLinq_ValueDelegate | 1000 |   100 |    175.88 ns |   3.569 ns |   4.383 ns |    174.96 ns |   2.38x slower |   0.05x |       - |         - |
|                Hyperlinq | 1000 |   100 |    259.67 ns |   2.670 ns |   2.230 ns |    258.56 ns |   3.47x slower |   0.03x |       - |         - |
|  Hyperlinq_ValueDelegate | 1000 |   100 |    330.21 ns |  28.800 ns |  84.466 ns |    332.26 ns |   3.89x slower |   0.88x |       - |         - |
