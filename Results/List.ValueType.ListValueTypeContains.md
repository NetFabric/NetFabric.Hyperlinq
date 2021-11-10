## List.ValueType.ListValueTypeContains

### Source
[ListValueTypeContains.cs](../LinqBenchmarks/List/ValueType/ListValueTypeContains.cs)

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
|                   Method |           Job |                                                EnvironmentVariables |       Runtime | Count |       Mean |   Error |  StdDev |        Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |-------------- |-------------------------------------------------------------------- |-------------- |------ |-----------:|--------:|--------:|-------------:|--------:|-------:|----------:|
|                  ForLoop |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   732.1 ns | 0.26 ns | 0.22 ns |     baseline |         |      - |         - |
|              ForeachLoop |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 1,236.0 ns | 1.06 ns | 0.99 ns | 1.69x slower |   0.00x |      - |         - |
|                     Linq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   237.4 ns | 0.27 ns | 0.24 ns | 3.08x faster |   0.00x |      - |         - |
|               LinqFaster |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   238.4 ns | 0.35 ns | 0.28 ns | 3.07x faster |   0.00x |      - |         - |
|             LinqFasterer |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   700.2 ns | 5.57 ns | 4.93 ns | 1.05x faster |   0.01x | 3.0670 |   6,424 B |
|                   LinqAF |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   238.3 ns | 0.10 ns | 0.09 ns | 3.07x faster |   0.00x |      - |         - |
|               StructLinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   580.4 ns | 1.50 ns | 1.26 ns | 1.26x faster |   0.00x | 0.0191 |      40 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   600.3 ns | 1.27 ns | 1.06 ns | 1.22x faster |   0.00x |      - |         - |
|                Hyperlinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   249.2 ns | 0.29 ns | 0.24 ns | 2.94x faster |   0.00x | 0.0153 |      32 B |
|                  Faslinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   601.8 ns | 0.59 ns | 0.49 ns | 1.22x faster |   0.00x | 0.0305 |      64 B |
|                          |               |                                                                     |               |       |            |         |         |              |         |        |           |
|                  ForLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   732.7 ns | 0.22 ns | 0.20 ns |     baseline |         |      - |         - |
|              ForeachLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 1,166.8 ns | 1.18 ns | 1.04 ns | 1.59x slower |   0.00x |      - |         - |
|                     Linq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   145.4 ns | 1.50 ns | 1.40 ns | 5.03x faster |   0.00x |      - |         - |
|               LinqFaster |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   143.4 ns | 2.90 ns | 5.16 ns | 4.99x faster |   0.15x |      - |         - |
|             LinqFasterer |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   609.4 ns | 2.41 ns | 2.01 ns | 1.20x faster |   0.00x | 3.0670 |   6,424 B |
|                   LinqAF |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   145.7 ns | 0.20 ns | 0.18 ns | 5.03x faster |   0.01x |      - |         - |
|               StructLinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   516.0 ns | 2.29 ns | 2.03 ns | 1.42x faster |   0.01x | 0.0191 |      40 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   573.7 ns | 4.07 ns | 3.61 ns | 1.28x faster |   0.01x |      - |         - |
|                Hyperlinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   148.7 ns | 0.22 ns | 0.20 ns | 4.93x faster |   0.01x | 0.0153 |      32 B |
|                  Faslinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   591.5 ns | 0.45 ns | 0.42 ns | 1.24x faster |   0.00x | 0.0305 |      64 B |
|                          |               |                                                                     |               |       |            |         |         |              |         |        |           |
|                  ForLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   789.1 ns | 0.52 ns | 0.48 ns |     baseline |         |      - |         - |
|              ForeachLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 1,321.5 ns | 1.68 ns | 1.49 ns | 1.67x slower |   0.00x |      - |         - |
|                     Linq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   273.3 ns | 1.44 ns | 1.28 ns | 2.89x faster |   0.01x |      - |         - |
|               LinqFaster | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   260.6 ns | 0.20 ns | 0.16 ns | 3.03x faster |   0.00x |      - |         - |
|             LinqFasterer | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   679.5 ns | 9.50 ns | 8.89 ns | 1.16x faster |   0.02x | 3.0670 |   6,424 B |
|                   LinqAF | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   260.0 ns | 0.29 ns | 0.27 ns | 3.03x faster |   0.00x |      - |         - |
|               StructLinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   649.2 ns | 7.33 ns | 6.50 ns | 1.22x faster |   0.01x | 0.0191 |      40 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   644.4 ns | 0.62 ns | 0.48 ns | 1.22x faster |   0.00x |      - |         - |
|                Hyperlinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   256.7 ns | 0.19 ns | 0.15 ns | 3.07x faster |   0.00x | 0.0153 |      32 B |
|                  Faslinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   730.0 ns | 0.73 ns | 0.68 ns | 1.08x faster |   0.00x | 0.0305 |      64 B |
