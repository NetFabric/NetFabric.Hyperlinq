## List.ValueType.ListValueTypeSkipTakeSelect

### Source
[ListValueTypeSkipTakeSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSkipTakeSelect.cs)

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
|                   Method |           Job |                                                EnvironmentVariables |       Runtime | Skip | Count |      Mean |     Error |    StdDev |         Ratio | RatioSD |   Gen 0 |   Gen 1 | Allocated |
|------------------------- |-------------- |-------------------------------------------------------------------- |-------------- |----- |------ |----------:|----------:|----------:|--------------:|--------:|--------:|--------:|----------:|
|                  ForLoop |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 |  1.705 μs | 0.0032 μs | 0.0025 μs |      baseline |         |       - |       - |         - |
|                     Linq |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 |  2.848 μs | 0.0042 μs | 0.0033 μs |  1.67x slower |   0.00x |  0.1526 |       - |     320 B |
|               LinqFaster |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 |  4.936 μs | 0.0072 μs | 0.0060 μs |  2.90x slower |   0.00x |  9.2545 |       - |  19,368 B |
|             LinqFasterer |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 |  8.692 μs | 0.0776 μs | 0.0726 μs |  5.10x slower |   0.05x | 39.2151 |       - |  83,304 B |
|                   LinqAF |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 |  9.176 μs | 0.0395 μs | 0.0330 μs |  5.38x slower |   0.02x |       - |       - |         - |
|            LinqOptimizer |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 | 20.370 μs | 0.2123 μs | 0.1986 μs | 11.98x slower |   0.12x | 49.9878 | 16.6626 | 137,863 B |
|                  Streams |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 | 12.847 μs | 0.0272 μs | 0.0212 μs |  7.54x slower |   0.02x |  0.5493 |       - |   1,176 B |
|               StructLinq |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 |  1.970 μs | 0.0016 μs | 0.0015 μs |  1.16x slower |   0.00x |  0.0572 |       - |     120 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 |  1.924 μs | 0.0017 μs | 0.0015 μs |  1.13x slower |   0.00x |       - |       - |         - |
|                Hyperlinq |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 |  1.947 μs | 0.0017 μs | 0.0014 μs |  1.14x slower |   0.00x |       - |       - |         - |
|  Hyperlinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 | 1000 |   100 |  1.781 μs | 0.0033 μs | 0.0027 μs |  1.04x slower |   0.00x |       - |       - |         - |
|                          |               |                                                                     |               |      |       |           |           |           |               |         |         |         |           |
|                  ForLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |  1.648 μs | 0.0016 μs | 0.0014 μs |      baseline |         |       - |       - |         - |
|                     Linq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |  2.327 μs | 0.0017 μs | 0.0014 μs |  1.41x slower |   0.00x |  0.1526 |       - |     320 B |
|               LinqFaster |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |  4.945 μs | 0.0092 μs | 0.0072 μs |  3.00x slower |   0.00x |  9.2545 |       - |  19,368 B |
|             LinqFasterer |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |  8.657 μs | 0.0463 μs | 0.0386 μs |  5.25x slower |   0.02x | 39.2151 |       - |  83,304 B |
|                   LinqAF |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |  9.515 μs | 0.0719 μs | 0.0673 μs |  5.78x slower |   0.04x |       - |       - |         - |
|            LinqOptimizer |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 | 21.607 μs | 0.2323 μs | 0.2173 μs | 13.10x slower |   0.13x | 49.9878 | 16.6626 | 137,863 B |
|                  Streams |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 | 11.603 μs | 0.0335 μs | 0.0313 μs |  7.04x slower |   0.02x |  0.5493 |       - |   1,176 B |
|               StructLinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |  1.906 μs | 0.0024 μs | 0.0022 μs |  1.16x slower |   0.00x |  0.0572 |       - |     120 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |  1.616 μs | 0.0006 μs | 0.0005 μs |  1.02x faster |   0.00x |       - |       - |         - |
|                Hyperlinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |  1.917 μs | 0.0006 μs | 0.0005 μs |  1.16x slower |   0.00x |       - |       - |         - |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |  1.723 μs | 0.0021 μs | 0.0019 μs |  1.05x slower |   0.00x |       - |       - |         - |
|                          |               |                                                                     |               |      |       |           |           |           |               |         |         |         |           |
|                  ForLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 |  1.936 μs | 0.0010 μs | 0.0007 μs |      baseline |         |       - |       - |         - |
|                     Linq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 |  2.964 μs | 0.0061 μs | 0.0054 μs |  1.53x slower |   0.00x |  0.1526 |       - |     320 B |
|               LinqFaster | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 |  4.938 μs | 0.0110 μs | 0.0092 μs |  2.55x slower |   0.00x |  9.2545 |       - |  19,368 B |
|             LinqFasterer | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 |  8.410 μs | 0.1639 μs | 0.1683 μs |  4.32x slower |   0.06x | 38.7573 |       - |  83,304 B |
|                   LinqAF | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 | 20.242 μs | 0.0154 μs | 0.0128 μs | 10.45x slower |   0.01x |       - |       - |         - |
|            LinqOptimizer | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 | 25.512 μs | 0.3097 μs | 0.3803 μs | 13.17x slower |   0.26x | 60.5774 | 15.1367 | 137,900 B |
|                  Streams | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 | 13.804 μs | 0.0183 μs | 0.0172 μs |  7.13x slower |   0.01x |  0.5493 |       - |   1,176 B |
|               StructLinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 |  2.220 μs | 0.0019 μs | 0.0017 μs |  1.15x slower |   0.00x |  0.0572 |       - |     120 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 |  2.062 μs | 0.0013 μs | 0.0011 μs |  1.06x slower |   0.00x |       - |       - |         - |
|                Hyperlinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 |  2.267 μs | 0.0023 μs | 0.0021 μs |  1.17x slower |   0.00x |       - |       - |         - |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 | 1000 |   100 |  1.988 μs | 0.0013 μs | 0.0012 μs |  1.03x slower |   0.00x |       - |       - |         - |
