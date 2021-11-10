## Array.Int32.ArrayInt32Where

### Source
[ArrayInt32Where.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Where.cs)

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

BenchmarkDotNet=v0.13.1, OS=macOS Catalina 10.15.7 (19H1519) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100
  [Host]        : .NET Core 3.1.20 (CoreCLR 4.700.21.47003, CoreFX 4.700.21.47101), X64 RyuJIT
  .NET 6        : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT
  .NET 6 PGO    : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT
  .NET Core 3.1 : .NET Core 3.1.20 (CoreCLR 4.700.21.47003, CoreFX 4.700.21.47101), X64 RyuJIT


```
|                   Method |           Job |                                                EnvironmentVariables |       Runtime | Count |        Mean |     Error |    StdDev |         Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |-------------- |-------------------------------------------------------------------- |-------------- |------ |------------:|----------:|----------:|--------------:|--------:|-------:|----------:|
|                  ForLoop |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |    71.75 ns |  0.690 ns |  0.646 ns |      baseline |         |      - |         - |
|              ForeachLoop |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |    72.33 ns |  0.682 ns |  0.638 ns |  1.01x slower |   0.01x |      - |         - |
|                     Linq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   539.90 ns |  0.999 ns |  0.885 ns |  7.53x slower |   0.07x | 0.0229 |      48 B |
|               LinqFaster |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   342.78 ns |  0.553 ns |  0.432 ns |  4.77x slower |   0.04x | 0.3171 |     664 B |
|             LinqFasterer |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   828.82 ns |  1.337 ns |  1.117 ns | 11.55x slower |   0.10x | 0.2136 |     448 B |
|                   LinqAF |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   391.11 ns |  1.591 ns |  1.411 ns |  5.45x slower |   0.06x |      - |         - |
|            LinqOptimizer |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 1,728.99 ns | 11.079 ns | 10.363 ns | 24.10x slower |   0.31x | 4.1485 |   8,682 B |
|                 SpanLinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   305.96 ns |  1.733 ns |  1.536 ns |  4.27x slower |   0.04x |      - |         - |
|                  Streams |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 1,638.13 ns |  2.243 ns |  1.873 ns | 22.83x slower |   0.21x | 0.2785 |     584 B |
|               StructLinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   353.49 ns |  6.316 ns |  5.908 ns |  4.93x slower |   0.08x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   178.62 ns |  0.231 ns |  0.205 ns |  2.49x slower |   0.02x |      - |         - |
|                Hyperlinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   286.43 ns |  5.547 ns |  6.812 ns |  4.01x slower |   0.10x |      - |         - |
|  Hyperlinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   222.07 ns |  0.529 ns |  0.441 ns |  3.09x slower |   0.03x |      - |         - |
|                  Faslinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   509.58 ns |  8.890 ns |  8.316 ns |  7.10x slower |   0.15x | 0.2022 |     424 B |
|                          |               |                                                                     |               |       |             |           |           |               |         |        |           |
|                  ForLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |    72.59 ns |  0.643 ns |  0.570 ns |      baseline |         |      - |         - |
|              ForeachLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |    72.88 ns |  1.211 ns |  1.133 ns |  1.00x slower |   0.02x |      - |         - |
|                     Linq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   351.72 ns |  1.276 ns |  1.193 ns |  4.84x slower |   0.04x | 0.0229 |      48 B |
|               LinqFaster |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   325.83 ns |  1.004 ns |  0.890 ns |  4.49x slower |   0.04x | 0.3171 |     664 B |
|             LinqFasterer |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   493.24 ns |  0.777 ns |  0.649 ns |  6.79x slower |   0.06x | 0.2136 |     448 B |
|                   LinqAF |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   496.79 ns |  7.868 ns |  7.360 ns |  6.83x slower |   0.13x |      - |         - |
|            LinqOptimizer |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 1,534.64 ns |  8.453 ns |  7.059 ns | 21.14x slower |   0.23x | 4.1485 |   8,682 B |
|                 SpanLinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   245.50 ns |  0.367 ns |  0.344 ns |  3.38x slower |   0.03x |      - |         - |
|                  Streams |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 1,187.59 ns |  2.304 ns |  2.042 ns | 16.36x slower |   0.13x | 0.2785 |     584 B |
|               StructLinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   317.71 ns |  6.093 ns |  7.253 ns |  4.38x slower |   0.10x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   216.25 ns |  1.730 ns |  1.533 ns |  2.98x slower |   0.03x |      - |         - |
|                Hyperlinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   311.18 ns |  5.895 ns |  8.823 ns |  4.28x slower |   0.12x |      - |         - |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   221.66 ns |  0.380 ns |  0.337 ns |  3.05x slower |   0.02x |      - |         - |
|                  Faslinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   389.11 ns |  0.437 ns |  0.365 ns |  5.36x slower |   0.04x | 0.2027 |     424 B |
|                          |               |                                                                     |               |       |             |           |           |               |         |        |           |
|                  ForLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |    66.20 ns |  0.091 ns |  0.085 ns |      baseline |         |      - |         - |
|              ForeachLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |    66.29 ns |  0.154 ns |  0.144 ns |  1.00x slower |   0.00x |      - |         - |
|                     Linq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   532.25 ns |  0.928 ns |  0.775 ns |  8.04x slower |   0.02x | 0.0229 |      48 B |
|               LinqFaster | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   334.98 ns |  1.406 ns |  1.246 ns |  5.06x slower |   0.02x | 0.3171 |     664 B |
|             LinqFasterer | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   836.47 ns |  0.730 ns |  0.647 ns | 12.64x slower |   0.02x | 0.2136 |     448 B |
|                   LinqAF | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   411.28 ns |  2.593 ns |  2.425 ns |  6.21x slower |   0.03x |      - |         - |
|            LinqOptimizer | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 1,826.03 ns | 16.364 ns | 14.506 ns | 27.59x slower |   0.22x | 4.1599 |   8,712 B |
|                 SpanLinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   407.50 ns |  4.095 ns |  3.831 ns |  6.16x slower |   0.06x |      - |         - |
|                  Streams | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 1,857.45 ns |  2.535 ns |  2.247 ns | 28.06x slower |   0.06x | 0.2785 |     584 B |
|               StructLinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   428.88 ns |  4.161 ns |  3.892 ns |  6.48x slower |   0.06x | 0.0153 |      32 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   185.40 ns |  0.260 ns |  0.217 ns |  2.80x slower |   0.01x |      - |         - |
|                Hyperlinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   440.84 ns |  3.871 ns |  3.432 ns |  6.66x slower |   0.05x |      - |         - |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   230.29 ns |  0.290 ns |  0.242 ns |  3.48x slower |   0.01x |      - |         - |
|                  Faslinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   431.88 ns |  2.238 ns |  1.869 ns |  6.52x slower |   0.03x | 0.2027 |     424 B |
