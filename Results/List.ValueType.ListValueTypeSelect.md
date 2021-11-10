## List.ValueType.ListValueTypeSelect

### Source
[ListValueTypeSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSelect.cs)

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
|                   Method |           Job |                                                EnvironmentVariables |       Runtime | Count |      Mean |     Error |    StdDev |        Ratio | RatioSD |   Gen 0 |   Gen 1 | Allocated |
|------------------------- |-------------- |-------------------------------------------------------------------- |-------------- |------ |----------:|----------:|----------:|-------------:|--------:|--------:|--------:|----------:|
|                  ForLoop |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  1.705 μs | 0.0013 μs | 0.0012 μs |     baseline |         |       - |       - |         - |
|              ForeachLoop |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  2.023 μs | 0.0013 μs | 0.0010 μs | 1.19x slower |   0.00x |       - |       - |         - |
|                     Linq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  2.876 μs | 0.0029 μs | 0.0024 μs | 1.69x slower |   0.00x |  0.0877 |       - |     184 B |
|               LinqFaster |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  3.071 μs | 0.0051 μs | 0.0048 μs | 1.80x slower |   0.00x |  3.0861 |       - |   6,456 B |
|             LinqFasterer |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  3.407 μs | 0.0087 μs | 0.0081 μs | 2.00x slower |   0.00x |  6.1531 |       - |  12,880 B |
|                   LinqAF |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  2.888 μs | 0.0049 μs | 0.0044 μs | 1.69x slower |   0.00x |       - |       - |         - |
|            LinqOptimizer |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 11.620 μs | 0.1863 μs | 0.1742 μs | 6.82x slower |   0.10x | 50.0031 | 16.6626 | 137,863 B |
|                  Streams |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  3.854 μs | 0.0072 μs | 0.0067 μs | 2.26x slower |   0.00x |  0.4044 |       - |     848 B |
|               StructLinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  1.932 μs | 0.0022 μs | 0.0018 μs | 1.13x slower |   0.00x |  0.0191 |       - |      40 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  1.794 μs | 0.0014 μs | 0.0012 μs | 1.05x slower |   0.00x |       - |       - |         - |
|                Hyperlinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  1.930 μs | 0.0011 μs | 0.0010 μs | 1.13x slower |   0.00x |       - |       - |         - |
|  Hyperlinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  1.845 μs | 0.0008 μs | 0.0007 μs | 1.08x slower |   0.00x |       - |       - |         - |
|                  Faslinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  3.980 μs | 0.0174 μs | 0.0146 μs | 2.33x slower |   0.01x |  7.7820 |       - |  16,304 B |
|                          |               |                                                                     |               |       |           |           |           |              |         |         |         |           |
|                  ForLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  1.647 μs | 0.0008 μs | 0.0007 μs |     baseline |         |       - |       - |         - |
|              ForeachLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  2.000 μs | 0.0040 μs | 0.0037 μs | 1.21x slower |   0.00x |       - |       - |         - |
|                     Linq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  2.384 μs | 0.0010 μs | 0.0008 μs | 1.45x slower |   0.00x |  0.0877 |       - |     184 B |
|               LinqFaster |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  3.078 μs | 0.0041 μs | 0.0037 μs | 1.87x slower |   0.00x |  3.0861 |       - |   6,456 B |
|             LinqFasterer |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  3.254 μs | 0.0036 μs | 0.0032 μs | 1.97x slower |   0.00x |  6.1531 |       - |  12,880 B |
|                   LinqAF |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  2.862 μs | 0.0071 μs | 0.0063 μs | 1.74x slower |   0.00x |       - |       - |         - |
|            LinqOptimizer |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 11.443 μs | 0.0583 μs | 0.0487 μs | 6.95x slower |   0.03x | 50.0031 | 16.6626 | 137,863 B |
|                  Streams |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  3.519 μs | 0.0089 μs | 0.0074 μs | 2.14x slower |   0.00x |  0.4044 |       - |     848 B |
|               StructLinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  1.927 μs | 0.0013 μs | 0.0011 μs | 1.17x slower |   0.00x |  0.0191 |       - |      40 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  1.600 μs | 0.0009 μs | 0.0008 μs | 1.03x faster |   0.00x |       - |       - |         - |
|                Hyperlinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  1.903 μs | 0.0008 μs | 0.0007 μs | 1.16x slower |   0.00x |       - |       - |         - |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  1.817 μs | 0.0013 μs | 0.0011 μs | 1.10x slower |   0.00x |       - |       - |         - |
|                  Faslinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  3.916 μs | 0.0077 μs | 0.0064 μs | 2.38x slower |   0.00x |  7.7820 |       - |  16,304 B |
|                          |               |                                                                     |               |       |           |           |           |              |         |         |         |           |
|                  ForLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  1.882 μs | 0.0015 μs | 0.0013 μs |     baseline |         |       - |       - |         - |
|              ForeachLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  2.150 μs | 0.0018 μs | 0.0015 μs | 1.14x slower |   0.00x |       - |       - |         - |
|                     Linq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  3.506 μs | 0.0031 μs | 0.0026 μs | 1.86x slower |   0.00x |  0.0877 |       - |     184 B |
|               LinqFaster | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  3.155 μs | 0.0129 μs | 0.0114 μs | 1.68x slower |   0.01x |  3.0861 |       - |   6,456 B |
|             LinqFasterer | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  3.411 μs | 0.0207 μs | 0.0184 μs | 1.81x slower |   0.01x |  6.1531 |       - |  12,880 B |
|                   LinqAF | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  4.622 μs | 0.0038 μs | 0.0035 μs | 2.46x slower |   0.00x |       - |       - |         - |
|            LinqOptimizer | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 15.640 μs | 0.3014 μs | 0.2353 μs | 8.31x slower |   0.13x | 60.5164 | 15.1367 | 137,900 B |
|                  Streams | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  4.029 μs | 0.0050 μs | 0.0045 μs | 2.14x slower |   0.00x |  0.4044 |       - |     848 B |
|               StructLinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  2.077 μs | 0.0011 μs | 0.0009 μs | 1.10x slower |   0.00x |  0.0191 |       - |      40 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  2.047 μs | 0.0021 μs | 0.0018 μs | 1.09x slower |   0.00x |       - |       - |         - |
|                Hyperlinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  2.245 μs | 0.0016 μs | 0.0014 μs | 1.19x slower |   0.00x |       - |       - |         - |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  1.911 μs | 0.0034 μs | 0.0032 μs | 1.02x slower |   0.00x |       - |       - |         - |
|                  Faslinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  3.942 μs | 0.0211 μs | 0.0197 μs | 2.10x slower |   0.01x |  7.7820 |       - |  16,304 B |
