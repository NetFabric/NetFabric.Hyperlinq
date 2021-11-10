## Array.Int32.ArrayInt32SelectToList

### Source
[ArrayInt32SelectToList.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SelectToList.cs)

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
|                       Method |           Job |                                                EnvironmentVariables |       Runtime | Count |        Mean |    Error |   StdDev |        Ratio | RatioSD |  Gen 0 | Allocated |
|----------------------------- |-------------- |-------------------------------------------------------------------- |-------------- |------ |------------:|---------:|---------:|-------------:|--------:|-------:|----------:|
|                      ForLoop |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   333.78 ns | 1.077 ns | 0.955 ns |     baseline |         | 0.5660 |   1,184 B |
|                  ForeachLoop |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   335.60 ns | 0.571 ns | 0.507 ns | 1.01x slower |   0.00x | 0.5660 |   1,184 B |
|                         Linq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   352.82 ns | 0.482 ns | 0.403 ns | 1.06x slower |   0.00x | 0.2408 |     504 B |
|                   LinqFaster |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   302.18 ns | 2.723 ns | 2.414 ns | 1.10x faster |   0.01x | 0.4206 |     880 B |
|              LinqFaster_SIMD |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   142.19 ns | 0.528 ns | 0.413 ns | 2.35x faster |   0.01x | 0.4208 |     880 B |
|                 LinqFasterer |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   310.40 ns | 1.067 ns | 0.946 ns | 1.08x faster |   0.00x | 0.4206 |     880 B |
|                       LinqAF |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   638.04 ns | 2.289 ns | 2.029 ns | 1.91x slower |   0.01x | 0.5655 |   1,184 B |
|                LinqOptimizer |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 1,678.67 ns | 5.296 ns | 4.695 ns | 5.03x slower |   0.02x | 4.4365 |   9,290 B |
|                     SpanLinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   378.37 ns | 0.326 ns | 0.254 ns | 1.13x slower |   0.00x | 0.2179 |     456 B |
|                      Streams |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 1,559.90 ns | 3.923 ns | 3.276 ns | 4.67x slower |   0.01x | 0.7534 |   1,576 B |
|                   StructLinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   309.82 ns | 1.133 ns | 1.059 ns | 1.08x faster |   0.00x | 0.2484 |     520 B |
|     StructLinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   153.81 ns | 0.508 ns | 0.425 ns | 2.17x faster |   0.01x | 0.2370 |     496 B |
|                    Hyperlinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   288.40 ns | 0.519 ns | 0.460 ns | 1.16x faster |   0.00x | 0.2179 |     456 B |
|      Hyperlinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   123.41 ns | 0.252 ns | 0.236 ns | 2.71x faster |   0.01x | 0.2179 |     456 B |
|               Hyperlinq_SIMD |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   109.60 ns | 0.274 ns | 0.229 ns | 3.05x faster |   0.01x | 0.2180 |     456 B |
| Hyperlinq_ValueDelegate_SIMD |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |    70.38 ns | 0.174 ns | 0.145 ns | 4.74x faster |   0.02x | 0.2180 |     456 B |
|                      Faslinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   369.53 ns | 0.674 ns | 0.562 ns | 1.11x slower |   0.00x | 0.4206 |     880 B |
|                              |               |                                                                     |               |       |             |          |          |              |         |        |           |
|                      ForLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   319.48 ns | 1.760 ns | 1.470 ns |     baseline |         | 0.5660 |   1,184 B |
|                  ForeachLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   319.20 ns | 0.837 ns | 0.742 ns | 1.00x faster |   0.01x | 0.5660 |   1,184 B |
|                         Linq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   310.77 ns | 0.433 ns | 0.361 ns | 1.03x faster |   0.00x | 0.2408 |     504 B |
|                   LinqFaster |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   303.10 ns | 0.705 ns | 0.589 ns | 1.05x faster |   0.00x | 0.4206 |     880 B |
|              LinqFaster_SIMD |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   142.96 ns | 0.652 ns | 0.578 ns | 2.24x faster |   0.01x | 0.4208 |     880 B |
|                 LinqFasterer |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   333.07 ns | 1.795 ns | 1.679 ns | 1.04x slower |   0.01x | 0.4206 |     880 B |
|                       LinqAF |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   575.12 ns | 5.235 ns | 4.897 ns | 1.80x slower |   0.02x | 0.5655 |   1,184 B |
|                LinqOptimizer |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 1,676.92 ns | 7.111 ns | 6.652 ns | 5.25x slower |   0.03x | 4.4365 |   9,290 B |
|                     SpanLinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   326.95 ns | 1.308 ns | 1.223 ns | 1.02x slower |   0.00x | 0.2179 |     456 B |
|                      Streams |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 1,467.55 ns | 1.593 ns | 1.331 ns | 4.59x slower |   0.02x | 0.7534 |   1,576 B |
|                   StructLinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   297.93 ns | 0.873 ns | 0.681 ns | 1.07x faster |   0.01x | 0.2484 |     520 B |
|     StructLinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   203.91 ns | 0.501 ns | 0.468 ns | 1.57x faster |   0.01x | 0.2370 |     496 B |
|                    Hyperlinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   264.67 ns | 0.371 ns | 0.290 ns | 1.21x faster |   0.01x | 0.2179 |     456 B |
|      Hyperlinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   125.92 ns | 0.581 ns | 0.515 ns | 2.54x faster |   0.02x | 0.2179 |     456 B |
|               Hyperlinq_SIMD |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   108.06 ns | 0.261 ns | 0.218 ns | 2.96x faster |   0.01x | 0.2180 |     456 B |
| Hyperlinq_ValueDelegate_SIMD |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |    72.10 ns | 0.731 ns | 0.683 ns | 4.44x faster |   0.04x | 0.2180 |     456 B |
|                      Faslinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   315.56 ns | 0.697 ns | 0.582 ns | 1.01x faster |   0.00x | 0.4206 |     880 B |
|                              |               |                                                                     |               |       |             |          |          |              |         |        |           |
|                      ForLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   370.73 ns | 1.211 ns | 1.074 ns |     baseline |         | 0.5660 |   1,184 B |
|                  ForeachLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   372.57 ns | 2.534 ns | 2.370 ns | 1.01x slower |   0.01x | 0.5660 |   1,184 B |
|                         Linq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   381.76 ns | 0.802 ns | 0.750 ns | 1.03x slower |   0.00x | 0.2408 |     504 B |
|                   LinqFaster | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   286.25 ns | 3.594 ns | 3.362 ns | 1.29x faster |   0.02x | 0.4206 |     880 B |
|              LinqFaster_SIMD | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   166.72 ns | 1.747 ns | 1.635 ns | 2.23x faster |   0.02x | 0.4208 |     880 B |
|                 LinqFasterer | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   301.68 ns | 1.347 ns | 1.194 ns | 1.23x faster |   0.01x | 0.4206 |     880 B |
|                       LinqAF | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   872.42 ns | 0.815 ns | 0.636 ns | 2.35x slower |   0.01x | 0.5655 |   1,184 B |
|                LinqOptimizer | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 1,719.04 ns | 9.102 ns | 8.069 ns | 4.64x slower |   0.03x | 4.4537 |   9,320 B |
|                     SpanLinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   561.88 ns | 0.670 ns | 0.559 ns | 1.52x slower |   0.00x | 0.2174 |     456 B |
|                      Streams | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 1,451.98 ns | 2.628 ns | 2.330 ns | 3.92x slower |   0.01x | 0.7534 |   1,576 B |
|                   StructLinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   342.21 ns | 0.519 ns | 0.434 ns | 1.08x faster |   0.00x | 0.2484 |     520 B |
|     StructLinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   168.71 ns | 0.731 ns | 0.648 ns | 2.20x faster |   0.01x | 0.2370 |     496 B |
|                    Hyperlinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   334.69 ns | 0.628 ns | 0.588 ns | 1.11x faster |   0.00x | 0.2179 |     456 B |
|      Hyperlinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   137.81 ns | 0.398 ns | 0.353 ns | 2.69x faster |   0.01x | 0.2179 |     456 B |
|               Hyperlinq_SIMD | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   142.41 ns | 0.940 ns | 0.879 ns | 2.60x faster |   0.02x | 0.2179 |     456 B |
| Hyperlinq_ValueDelegate_SIMD | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |    89.24 ns | 0.789 ns | 0.738 ns | 4.15x faster |   0.04x | 0.2180 |     456 B |
|                      Faslinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   408.03 ns | 1.434 ns | 1.271 ns | 1.10x slower |   0.00x | 0.4206 |     880 B |
