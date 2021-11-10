## List.Int32.ListInt32Select

### Source
[ListInt32Select.cs](../LinqBenchmarks/List/Int32/ListInt32Select.cs)

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
|                  ForLoop |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |    77.97 ns |  0.879 ns |  0.734 ns |      baseline |         |      - |         - |
|              ForeachLoop |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   176.03 ns |  0.092 ns |  0.082 ns |  2.26x slower |   0.02x |      - |         - |
|                     Linq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   860.90 ns |  0.435 ns |  0.339 ns | 11.04x slower |   0.11x | 0.0343 |      72 B |
|               LinqFaster |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   448.81 ns |  1.142 ns |  0.891 ns |  5.75x slower |   0.06x | 0.2179 |     456 B |
|             LinqFasterer |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   814.12 ns |  8.766 ns |  7.771 ns | 10.45x slower |   0.15x | 0.4206 |     880 B |
|                   LinqAF |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   427.36 ns |  8.337 ns |  9.266 ns |  5.49x slower |   0.12x |      - |         - |
|            LinqOptimizer |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 2,762.60 ns | 12.483 ns | 11.066 ns | 35.45x slower |   0.41x | 4.2534 |   8,906 B |
|                  Streams |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 1,839.60 ns |  1.940 ns |  1.814 ns | 23.59x slower |   0.22x | 0.2899 |     608 B |
|               StructLinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   226.21 ns |  0.234 ns |  0.208 ns |  2.90x slower |   0.03x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   176.23 ns |  0.135 ns |  0.113 ns |  2.26x slower |   0.02x |      - |         - |
|                Hyperlinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   229.71 ns |  0.302 ns |  0.282 ns |  2.95x slower |   0.03x |      - |         - |
|  Hyperlinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   197.33 ns |  1.102 ns |  0.860 ns |  2.53x slower |   0.03x |      - |         - |
|                  Faslinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   625.26 ns |  1.023 ns |  0.854 ns |  8.02x slower |   0.08x | 0.5655 |   1,184 B |
|                          |               |                                                                     |               |       |             |           |           |               |         |        |           |
|                  ForLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |    78.31 ns |  0.198 ns |  0.185 ns |      baseline |         |      - |         - |
|              ForeachLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   149.64 ns |  0.062 ns |  0.058 ns |  1.91x slower |   0.00x |      - |         - |
|                     Linq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   437.49 ns |  0.936 ns |  0.781 ns |  5.59x slower |   0.02x | 0.0343 |      72 B |
|               LinqFaster |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   370.09 ns |  0.738 ns |  0.654 ns |  4.73x slower |   0.01x | 0.2179 |     456 B |
|             LinqFasterer |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   433.56 ns |  0.714 ns |  0.596 ns |  5.54x slower |   0.01x | 0.4206 |     880 B |
|                   LinqAF |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   359.83 ns |  3.387 ns |  2.828 ns |  4.59x slower |   0.03x |      - |         - |
|            LinqOptimizer |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 2,519.51 ns | 20.220 ns | 17.925 ns | 32.17x slower |   0.21x | 4.2534 |   8,906 B |
|                  Streams |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 1,498.98 ns |  1.592 ns |  1.489 ns | 19.14x slower |   0.05x | 0.2899 |     608 B |
|               StructLinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   226.25 ns |  0.213 ns |  0.178 ns |  2.89x slower |   0.01x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   178.27 ns |  0.098 ns |  0.086 ns |  2.28x slower |   0.01x |      - |         - |
|                Hyperlinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   226.40 ns |  0.412 ns |  0.385 ns |  2.89x slower |   0.01x |      - |         - |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   199.89 ns |  1.679 ns |  1.402 ns |  2.55x slower |   0.02x |      - |         - |
|                  Faslinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   543.98 ns |  0.743 ns |  0.659 ns |  6.95x slower |   0.02x | 0.5655 |   1,184 B |
|                          |               |                                                                     |               |       |             |           |           |               |         |        |           |
|                  ForLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   176.27 ns |  0.047 ns |  0.036 ns |      baseline |         |      - |         - |
|              ForeachLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   238.63 ns |  0.195 ns |  0.183 ns |  1.35x slower |   0.00x |      - |         - |
|                     Linq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 1,014.15 ns |  3.978 ns |  3.721 ns |  5.76x slower |   0.02x | 0.0343 |      72 B |
|               LinqFaster | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   578.93 ns |  0.585 ns |  0.519 ns |  3.28x slower |   0.00x | 0.2174 |     456 B |
|             LinqFasterer | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   790.71 ns |  1.723 ns |  1.527 ns |  4.49x slower |   0.01x | 0.4206 |     880 B |
|                   LinqAF | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   767.03 ns |  1.129 ns |  0.943 ns |  4.35x slower |   0.01x |      - |         - |
|            LinqOptimizer | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 2,889.37 ns | 13.422 ns | 11.898 ns | 16.39x slower |   0.07x | 4.2725 |   8,936 B |
|                  Streams | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 2,071.35 ns | 40.629 ns | 36.016 ns | 11.75x slower |   0.22x | 0.2899 |     608 B |
|               StructLinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   339.52 ns |  0.469 ns |  0.439 ns |  1.93x slower |   0.00x | 0.0153 |      32 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   189.64 ns |  0.078 ns |  0.073 ns |  1.08x slower |   0.00x |      - |         - |
|                Hyperlinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   282.76 ns |  0.460 ns |  0.359 ns |  1.60x slower |   0.00x |      - |         - |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   210.14 ns |  0.087 ns |  0.072 ns |  1.19x slower |   0.00x |      - |         - |
|                  Faslinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   704.20 ns |  1.439 ns |  1.275 ns |  4.00x slower |   0.01x | 0.5655 |   1,184 B |
