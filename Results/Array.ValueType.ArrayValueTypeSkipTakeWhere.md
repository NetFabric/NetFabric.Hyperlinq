## Array.ValueType.ArrayValueTypeSkipTakeWhere

### Source
[ArrayValueTypeSkipTakeWhere.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSkipTakeWhere.cs)

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
- Faslinq: [1.0.5](https://www.nuget.org/packages/Faslinq/1.0.5)

### Results:
``` ini

BenchmarkDotNet=v0.13.1, OS=macOS Catalina 10.15.7 (19H1419) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-rc.2.21505.57
  [Host]        : .NET Core 3.1.20 (CoreCLR 4.700.21.47003, CoreFX 4.700.21.47101), X64 RyuJIT
  .NET 6        : .NET 6.0.0 (6.0.21.48005), X64 RyuJIT
  .NET 6 PGO    : .NET 6.0.0 (6.0.21.48005), X64 RyuJIT
  .NET Core 3.1 : .NET Core 3.1.20 (CoreCLR 4.700.21.47003, CoreFX 4.700.21.47101), X64 RyuJIT


```
|                   Method |           Job |                                                   EnvironmentVariables |       Runtime | Skip | Count |        Mean |       Error |      StdDev |      Median |         Ratio | RatioSD |   Gen 0 |   Gen 1 | Allocated |
|------------------------- |-------------- |----------------------------------------------------------------------- |-------------- |----- |------ |------------:|------------:|------------:|------------:|--------------:|--------:|--------:|--------:|----------:|
|                  ForLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 |    458.2 ns |     1.77 ns |     1.57 ns |    457.2 ns |      baseline |         |       - |       - |         - |
|                     Linq |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 |  2,261.2 ns |    12.07 ns |    11.29 ns |  2,254.9 ns |  4.94x slower |   0.03x |  0.1526 |       - |     320 B |
|               LinqFaster |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 |  2,426.8 ns |    19.91 ns |    17.65 ns |  2,422.7 ns |  5.30x slower |   0.04x | 10.7803 |       - |  22,560 B |
|             LinqFasterer |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 |  1,887.6 ns |    11.20 ns |    10.48 ns |  1,882.8 ns |  4.12x slower |   0.03x |  4.6501 |       - |   9,744 B |
|                   LinqAF |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 |  6,912.4 ns |    32.33 ns |    27.00 ns |  6,904.1 ns | 15.08x slower |   0.07x |       - |       - |         - |
|            LinqOptimizer |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 | 10,783.8 ns |    99.03 ns |    92.63 ns | 10,741.3 ns | 23.51x slower |   0.20x | 50.0031 | 12.4969 | 134,631 B |
|                 SpanLinq |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 |    765.7 ns |     1.81 ns |     1.69 ns |    766.0 ns |  1.67x slower |   0.01x |       - |       - |         - |
|                  Streams |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 | 11,760.9 ns |    50.78 ns |    47.50 ns | 11,739.2 ns | 25.66x slower |   0.15x |  0.5493 |       - |   1,152 B |
|               StructLinq |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 |    679.5 ns |     2.19 ns |     1.94 ns |    678.9 ns |  1.48x slower |   0.01x |  0.0458 |       - |      96 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 |    558.6 ns |     3.38 ns |     3.00 ns |    556.9 ns |  1.22x slower |   0.01x |       - |       - |         - |
|                Hyperlinq |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 |  1,007.6 ns |     2.73 ns |     2.28 ns |  1,006.7 ns |  2.20x slower |   0.01x |       - |       - |         - |
|  Hyperlinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 |    811.1 ns |     2.27 ns |     1.89 ns |    811.3 ns |  1.77x slower |   0.01x |       - |       - |         - |
|                          |               |                                                                        |               |      |       |             |             |             |             |               |         |         |         |           |
|                  ForLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |    443.2 ns |     0.90 ns |     0.80 ns |    443.0 ns |      baseline |         |       - |       - |         - |
|                     Linq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |  1,510.8 ns |     6.20 ns |     5.49 ns |  1,509.6 ns |  3.41x slower |   0.02x |  0.1526 |       - |     320 B |
|               LinqFaster |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |  2,480.2 ns |    25.45 ns |    22.56 ns |  2,475.4 ns |  5.60x slower |   0.05x | 10.7803 |       - |  22,560 B |
|             LinqFasterer |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |  1,848.2 ns |    15.49 ns |    13.73 ns |  1,842.6 ns |  4.17x slower |   0.03x |  4.6501 |       - |   9,744 B |
|                   LinqAF |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |  6,079.9 ns |    44.32 ns |    41.46 ns |  6,067.9 ns | 13.72x slower |   0.08x |       - |       - |         - |
|            LinqOptimizer |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 | 10,758.3 ns |   215.19 ns |   239.18 ns | 10,654.5 ns | 24.27x slower |   0.53x | 50.0031 | 12.4969 | 134,631 B |
|                 SpanLinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |    750.9 ns |     2.18 ns |     2.04 ns |    749.8 ns |  1.69x slower |   0.01x |       - |       - |         - |
|                  Streams |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |  8,795.7 ns |    43.55 ns |    38.60 ns |  8,777.1 ns | 19.85x slower |   0.09x |  0.5493 |       - |   1,152 B |
|               StructLinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |    649.7 ns |     3.68 ns |     3.44 ns |    650.1 ns |  1.47x slower |   0.01x |  0.0458 |       - |      96 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |    542.5 ns |     0.68 ns |     0.53 ns |    542.3 ns |  1.22x slower |   0.00x |       - |       - |         - |
|                Hyperlinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |    963.6 ns |     3.17 ns |     2.81 ns |    962.5 ns |  2.17x slower |   0.01x |       - |       - |         - |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |    862.2 ns |     2.80 ns |     2.62 ns |    860.9 ns |  1.95x slower |   0.01x |       - |       - |         - |
|                          |               |                                                                        |               |      |       |             |             |             |             |               |         |         |         |           |
|                  ForLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 |    544.4 ns |     2.27 ns |     2.12 ns |    543.5 ns |      baseline |         |       - |       - |         - |
|                     Linq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 |  3,045.1 ns |    15.13 ns |    13.41 ns |  3,045.4 ns |  5.59x slower |   0.03x |  0.1526 |       - |     320 B |
|               LinqFaster | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 |  2,366.8 ns |    27.45 ns |    25.68 ns |  2,364.9 ns |  4.35x slower |   0.05x | 10.7803 |       - |  22,560 B |
|             LinqFasterer | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 |  1,919.7 ns |    13.85 ns |    12.28 ns |  1,914.2 ns |  3.53x slower |   0.03x |  4.6501 |       - |   9,744 B |
|                   LinqAF | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 |  8,604.3 ns |    47.29 ns |    41.93 ns |  8,595.8 ns | 15.80x slower |   0.12x |       - |       - |         - |
|            LinqOptimizer | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 | 21,505.2 ns | 2,208.32 ns | 6,511.27 ns | 25,176.6 ns | 43.59x slower |   5.39x | 50.0183 | 12.4817 | 134,663 B |
|                 SpanLinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 |  1,082.9 ns |    12.38 ns |    10.97 ns |  1,080.3 ns |  1.99x slower |   0.02x |       - |       - |         - |
|                  Streams | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 | 12,823.1 ns |    76.43 ns |    71.49 ns | 12,785.7 ns | 23.55x slower |   0.13x |  0.5493 |       - |   1,152 B |
|               StructLinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 |    934.1 ns |     4.23 ns |     3.96 ns |    934.1 ns |  1.72x slower |   0.01x |  0.0458 |       - |      96 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 |    635.7 ns |     1.68 ns |     1.49 ns |    635.0 ns |  1.17x slower |   0.01x |       - |       - |         - |
|                Hyperlinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 |  1,223.9 ns |     4.11 ns |     3.65 ns |  1,223.2 ns |  2.25x slower |   0.01x |       - |       - |         - |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 |    890.0 ns |     3.12 ns |     2.77 ns |    889.5 ns |  1.63x slower |   0.01x |       - |       - |         - |
