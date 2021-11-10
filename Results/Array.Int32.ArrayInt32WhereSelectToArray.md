## Array.Int32.ArrayInt32WhereSelectToArray

### Source
[ArrayInt32WhereSelectToArray.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelectToArray.cs)

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
|                  ForLoop |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   277.3 ns |  0.43 ns |  0.33 ns |     baseline |         | 0.4244 |     888 B |
|              ForeachLoop |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   277.8 ns |  0.49 ns |  0.44 ns | 1.00x slower |   0.00x | 0.4244 |     888 B |
|                     Linq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   582.4 ns |  1.49 ns |  1.25 ns | 2.10x slower |   0.01x | 0.3786 |     792 B |
|               LinqFaster |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   405.8 ns |  0.57 ns |  0.51 ns | 1.46x slower |   0.00x | 0.3171 |     664 B |
|             LinqFasterer |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   549.6 ns |  0.85 ns |  0.76 ns | 1.98x slower |   0.00x | 0.3977 |     832 B |
|                   LinqAF |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   716.8 ns |  5.67 ns |  4.74 ns | 2.58x slower |   0.02x | 0.4091 |     856 B |
|            LinqOptimizer |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 1,416.6 ns | 10.15 ns |  9.50 ns | 5.12x slower |   0.03x | 4.1313 |   8,650 B |
|                 SpanLinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   617.7 ns |  0.79 ns |  0.66 ns | 2.23x slower |   0.00x | 0.4244 |     888 B |
|                  Streams |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   976.2 ns |  1.42 ns |  1.11 ns | 3.52x slower |   0.00x | 0.6695 |   1,400 B |
|               StructLinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   615.6 ns |  2.08 ns |  1.85 ns | 2.22x slower |   0.01x | 0.1602 |     336 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   309.8 ns |  3.16 ns |  2.64 ns | 1.12x slower |   0.01x | 0.1144 |     240 B |
|                Hyperlinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   600.2 ns |  0.72 ns |  0.60 ns | 2.16x slower |   0.00x | 0.1144 |     240 B |
|  Hyperlinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   427.9 ns |  1.17 ns |  1.09 ns | 1.54x slower |   0.00x | 0.1144 |     240 B |
|                  Faslinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   359.5 ns |  7.04 ns |  8.65 ns | 1.29x slower |   0.04x | 0.2027 |     424 B |
|                          |               |                                                                     |               |       |            |          |          |              |         |        |           |
|                  ForLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   261.4 ns |  4.33 ns |  3.84 ns |     baseline |         | 0.4244 |     888 B |
|              ForeachLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   257.2 ns |  1.12 ns |  1.05 ns | 1.02x faster |   0.02x | 0.4244 |     888 B |
|                     Linq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   551.4 ns |  0.87 ns |  0.77 ns | 2.11x slower |   0.03x | 0.3786 |     792 B |
|               LinqFaster |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   345.4 ns |  0.86 ns |  0.76 ns | 1.32x slower |   0.02x | 0.3171 |     664 B |
|             LinqFasterer |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   539.8 ns |  2.93 ns |  2.59 ns | 2.07x slower |   0.03x | 0.3977 |     832 B |
|                   LinqAF |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   608.8 ns |  3.33 ns |  3.12 ns | 2.33x slower |   0.03x | 0.4091 |     856 B |
|            LinqOptimizer |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 1,422.7 ns |  4.54 ns |  4.03 ns | 5.44x slower |   0.08x | 4.1313 |   8,650 B |
|                 SpanLinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   597.1 ns |  7.96 ns |  7.45 ns | 2.29x slower |   0.04x | 0.4244 |     888 B |
|                  Streams |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 1,044.4 ns |  3.93 ns |  3.68 ns | 3.99x slower |   0.06x | 0.6695 |   1,400 B |
|               StructLinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   622.2 ns |  5.71 ns |  5.34 ns | 2.38x slower |   0.04x | 0.1602 |     336 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   359.5 ns |  0.90 ns |  0.84 ns | 1.37x slower |   0.02x | 0.1144 |     240 B |
|                Hyperlinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   586.2 ns |  1.04 ns |  0.98 ns | 2.24x slower |   0.03x | 0.1144 |     240 B |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   361.2 ns |  2.40 ns |  2.13 ns | 1.38x slower |   0.02x | 0.1144 |     240 B |
|                  Faslinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   370.9 ns |  0.87 ns |  0.77 ns | 1.42x slower |   0.02x | 0.2027 |     424 B |
|                          |               |                                                                     |               |       |            |          |          |              |         |        |           |
|                  ForLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   298.1 ns |  0.84 ns |  0.79 ns |     baseline |         | 0.4244 |     888 B |
|              ForeachLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   293.0 ns |  1.13 ns |  1.05 ns | 1.02x faster |   0.00x | 0.4244 |     888 B |
|                     Linq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   683.7 ns |  1.41 ns |  1.25 ns | 2.29x slower |   0.01x | 0.3786 |     792 B |
|               LinqFaster | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   355.4 ns |  0.93 ns |  0.87 ns | 1.19x slower |   0.01x | 0.3171 |     664 B |
|             LinqFasterer | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   521.2 ns |  1.22 ns |  1.14 ns | 1.75x slower |   0.00x | 0.3977 |     832 B |
|                   LinqAF | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   976.7 ns |  6.47 ns |  6.05 ns | 3.28x slower |   0.02x | 0.4082 |     856 B |
|            LinqOptimizer | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 1,529.1 ns | 12.04 ns | 11.26 ns | 5.13x slower |   0.04x | 4.1485 |   8,680 B |
|                 SpanLinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   846.0 ns |  4.68 ns |  4.38 ns | 2.84x slower |   0.01x | 0.4244 |     888 B |
|                  Streams | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 1,005.8 ns |  1.81 ns |  1.60 ns | 3.37x slower |   0.01x | 0.6695 |   1,400 B |
|               StructLinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   935.1 ns |  3.33 ns |  2.96 ns | 3.14x slower |   0.01x | 0.1602 |     336 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   398.8 ns |  3.43 ns |  2.87 ns | 1.34x slower |   0.01x | 0.1144 |     240 B |
|                Hyperlinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   951.5 ns |  4.49 ns |  4.20 ns | 3.19x slower |   0.01x | 0.1144 |     240 B |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   567.9 ns |  2.26 ns |  2.11 ns | 1.91x slower |   0.01x | 0.1144 |     240 B |
|                  Faslinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   351.9 ns |  0.74 ns |  0.66 ns | 1.18x slower |   0.00x | 0.2027 |     424 B |
