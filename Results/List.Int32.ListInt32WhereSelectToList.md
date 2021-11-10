## List.Int32.ListInt32WhereSelectToList

### Source
[ListInt32WhereSelectToList.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelectToList.cs)

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
|                   Method |           Job |                                                EnvironmentVariables |       Runtime | Count |       Mean |    Error |   StdDev |        Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |-------------- |-------------------------------------------------------------------- |-------------- |------ |-----------:|---------:|---------:|-------------:|--------:|-------:|----------:|
|                  ForLoop |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   302.8 ns |  0.42 ns |  0.37 ns |     baseline |         | 0.3095 |     648 B |
|              ForeachLoop |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   327.9 ns |  0.66 ns |  0.55 ns | 1.08x slower |   0.00x | 0.3095 |     648 B |
|                     Linq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   622.7 ns |  2.19 ns |  1.94 ns | 2.06x slower |   0.01x | 0.3824 |     800 B |
|               LinqFaster |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   560.5 ns |  0.68 ns |  0.63 ns | 1.85x slower |   0.00x | 0.4396 |     920 B |
|             LinqFasterer |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   546.9 ns |  0.54 ns |  0.45 ns | 1.81x slower |   0.00x | 0.5617 |   1,176 B |
|                   LinqAF |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 1,266.7 ns |  8.89 ns |  8.31 ns | 4.18x slower |   0.03x | 0.3090 |     648 B |
|            LinqOptimizer |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 2,465.7 ns | 11.32 ns | 10.04 ns | 8.14x slower |   0.04x | 4.2801 |   8,962 B |
|                  Streams |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 1,419.3 ns |  7.48 ns |  6.25 ns | 4.69x slower |   0.02x | 0.5684 |   1,192 B |
|               StructLinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   551.8 ns |  0.96 ns |  0.85 ns | 1.82x slower |   0.00x | 0.1755 |     368 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   331.1 ns |  0.27 ns |  0.21 ns | 1.09x slower |   0.00x | 0.1297 |     272 B |
|                Hyperlinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   648.0 ns |  2.16 ns |  2.02 ns | 2.14x slower |   0.01x | 0.1297 |     272 B |
|  Hyperlinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   431.4 ns |  6.93 ns |  6.48 ns | 1.43x slower |   0.02x | 0.1297 |     272 B |
|                  Faslinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   527.0 ns |  0.78 ns |  0.65 ns | 1.74x slower |   0.00x | 0.3090 |     648 B |
|                          |               |                                                                     |               |       |            |          |          |              |         |        |           |
|                  ForLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   321.9 ns |  0.34 ns |  0.32 ns |     baseline |         | 0.3095 |     648 B |
|              ForeachLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   322.0 ns |  1.09 ns |  0.97 ns | 1.00x slower |   0.00x | 0.3095 |     648 B |
|                     Linq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   570.9 ns |  1.57 ns |  1.31 ns | 1.77x slower |   0.00x | 0.3824 |     800 B |
|               LinqFaster |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   529.6 ns |  1.80 ns |  1.60 ns | 1.65x slower |   0.01x | 0.4396 |     920 B |
|             LinqFasterer |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   503.7 ns |  1.28 ns |  1.19 ns | 1.56x slower |   0.00x | 0.5617 |   1,176 B |
|                   LinqAF |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   659.8 ns |  2.04 ns |  1.70 ns | 2.05x slower |   0.01x | 0.3090 |     648 B |
|            LinqOptimizer |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 2,461.1 ns |  7.14 ns |  6.33 ns | 7.65x slower |   0.02x | 4.2801 |   8,962 B |
|                  Streams |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 1,354.1 ns |  1.91 ns |  1.60 ns | 4.21x slower |   0.01x | 0.5684 |   1,192 B |
|               StructLinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   605.0 ns |  0.88 ns |  0.74 ns | 1.88x slower |   0.00x | 0.1755 |     368 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   332.8 ns |  1.44 ns |  1.35 ns | 1.03x slower |   0.00x | 0.1297 |     272 B |
|                Hyperlinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   601.9 ns |  0.90 ns |  0.79 ns | 1.87x slower |   0.00x | 0.1297 |     272 B |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   383.5 ns |  0.75 ns |  0.66 ns | 1.19x slower |   0.00x | 0.1297 |     272 B |
|                  Faslinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   492.7 ns |  2.02 ns |  1.89 ns | 1.53x slower |   0.01x | 0.3090 |     648 B |
|                          |               |                                                                     |               |       |            |          |          |              |         |        |           |
|                  ForLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   361.0 ns |  0.93 ns |  0.83 ns |     baseline |         | 0.3095 |     648 B |
|              ForeachLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   491.3 ns |  1.07 ns |  0.89 ns | 1.36x slower |   0.00x | 0.3090 |     648 B |
|                     Linq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   615.8 ns |  2.57 ns |  2.28 ns | 1.71x slower |   0.01x | 0.3824 |     800 B |
|               LinqFaster | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   561.1 ns |  1.54 ns |  1.29 ns | 1.55x slower |   0.01x | 0.4396 |     920 B |
|             LinqFasterer | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   553.2 ns |  1.19 ns |  1.11 ns | 1.53x slower |   0.01x | 0.5617 |   1,176 B |
|                   LinqAF | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 1,631.8 ns |  4.86 ns |  4.31 ns | 4.52x slower |   0.02x | 0.3090 |     648 B |
|            LinqOptimizer | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 2,528.8 ns | 14.42 ns | 13.49 ns | 7.00x slower |   0.04x | 4.2953 |   8,992 B |
|                  Streams | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 1,433.0 ns |  1.93 ns |  1.51 ns | 3.97x slower |   0.01x | 0.5684 |   1,192 B |
|               StructLinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   907.4 ns |  2.52 ns |  2.36 ns | 2.51x slower |   0.01x | 0.1755 |     368 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   475.9 ns |  1.40 ns |  1.17 ns | 1.32x slower |   0.00x | 0.1297 |     272 B |
|                Hyperlinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   957.4 ns |  1.97 ns |  1.74 ns | 2.65x slower |   0.01x | 0.1297 |     272 B |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   587.1 ns |  0.77 ns |  0.72 ns | 1.63x slower |   0.00x | 0.1297 |     272 B |
|                  Faslinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   561.2 ns |  3.52 ns |  3.12 ns | 1.55x slower |   0.01x | 0.3090 |     648 B |
