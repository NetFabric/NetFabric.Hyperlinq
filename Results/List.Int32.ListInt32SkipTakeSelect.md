## List.Int32.ListInt32SkipTakeSelect

### Source
[ListInt32SkipTakeSelect.cs](../LinqBenchmarks/List/Int32/ListInt32SkipTakeSelect.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [0.7.0](https://www.nuget.org/packages/LinqOptimizer.CSharp/0.7.0)
- SpanLinq: [0.0.1](https://www.nuget.org/packages/SpanLinq/0.0.1)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.26.0](https://www.nuget.org/packages/StructLinq/0.26.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)

### Results:
``` ini

BenchmarkDotNet=v0.13.0, OS=macOS Catalina 10.15.7 (19H1323) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.7.21379.14
  [Host] : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.37719), X64 RyuJIT

Job=.NET 6  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Skip | Count |         Mean |      Error |     StdDev |       Median |          Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |----- |------ |-------------:|-----------:|-----------:|-------------:|---------------:|--------:|--------:|------:|------:|----------:|
|                  ForLoop | 1000 |   100 |     79.38 ns |   0.084 ns |   0.078 ns |     79.36 ns |       baseline |         |       - |     - |     - |         - |
|                     Linq | 1000 |   100 |    464.51 ns |   0.575 ns |   0.480 ns |    464.35 ns |   5.85x slower |   0.01x |  0.0725 |     - |     - |     152 B |
|               LinqFaster | 1000 |   100 |    852.35 ns |   6.868 ns |   6.088 ns |    851.44 ns |  10.74x slower |   0.07x |  0.6542 |     - |     - |   1,368 B |
|             LinqFasterer | 1000 |   100 |    764.62 ns |  15.300 ns |  18.214 ns |    752.80 ns |   9.61x slower |   0.23x |  2.5311 |     - |     - |   5,304 B |
|                   LinqAF | 1000 |   100 |  3,108.55 ns |   1.651 ns |   1.463 ns |  3,108.57 ns |  39.16x slower |   0.04x |       - |     - |     - |         - |
|            LinqOptimizer | 1000 |   100 | 57,242.91 ns | 300.290 ns | 280.892 ns | 57,106.47 ns | 721.09x slower |   3.39x | 15.3809 |     - |     - |  32,273 B |
|                 SpanLinq | 1000 |   100 |    303.14 ns |   0.267 ns |   0.236 ns |    303.07 ns |   3.82x slower |   0.00x |       - |     - |     - |         - |
|                  Streams | 1000 |   100 |  7,166.83 ns |   3.569 ns |   3.164 ns |  7,165.40 ns |  90.27x slower |   0.10x |  0.4425 |     - |     - |     936 B |
|               StructLinq | 1000 |   100 |    256.78 ns |   5.149 ns |   5.057 ns |    254.47 ns |   3.24x slower |   0.06x |  0.0458 |     - |     - |      96 B |
| StructLinq_ValueDelegate | 1000 |   100 |    177.63 ns |   0.148 ns |   0.139 ns |    177.63 ns |   2.24x slower |   0.00x |       - |     - |     - |         - |
|                Hyperlinq | 1000 |   100 |    252.67 ns |   0.082 ns |   0.077 ns |    252.69 ns |   3.18x slower |   0.00x |       - |     - |     - |         - |
|  Hyperlinq_ValueDelegate | 1000 |   100 |    221.59 ns |   0.198 ns |   0.185 ns |    221.59 ns |   2.79x slower |   0.00x |       - |     - |     - |         - |
