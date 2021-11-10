## List.ValueType.ListValueTypeWhereSelectToArray

### Source
[ListValueTypeWhereSelectToArray.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelectToArray.cs)

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
|                  ForLoop |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  1.704 μs | 0.0117 μs | 0.0103 μs |     baseline |         |  5.5237 |       - |     11 KB |
|              ForeachLoop |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  1.856 μs | 0.0111 μs | 0.0098 μs | 1.09x slower |   0.01x |  5.5237 |       - |     11 KB |
|                     Linq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  1.830 μs | 0.0021 μs | 0.0020 μs | 1.07x slower |   0.01x |  4.0035 |       - |      8 KB |
|               LinqFaster |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  2.060 μs | 0.0085 μs | 0.0075 μs | 1.21x slower |   0.01x |  5.5237 |       - |     11 KB |
|             LinqFasterer |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  2.031 μs | 0.0038 μs | 0.0035 μs | 1.19x slower |   0.01x |  6.3934 |       - |     13 KB |
|                   LinqAF |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  3.775 μs | 0.0118 μs | 0.0104 μs | 2.22x slower |   0.01x |  5.5122 |       - |     11 KB |
|            LinqOptimizer |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  9.818 μs | 0.1417 μs | 0.1686 μs | 5.78x slower |   0.12x | 49.3774 | 12.3444 |    132 KB |
|                  Streams |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  2.852 μs | 0.0104 μs | 0.0092 μs | 1.67x slower |   0.01x |  5.7716 |       - |     12 KB |
|               StructLinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  1.522 μs | 0.0022 μs | 0.0021 μs | 1.12x faster |   0.01x |  1.7109 |       - |      4 KB |
| StructLinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  1.254 μs | 0.0012 μs | 0.0010 μs | 1.36x faster |   0.01x |  1.6575 |       - |      3 KB |
|                Hyperlinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  1.679 μs | 0.0030 μs | 0.0027 μs | 1.02x faster |   0.01x |  1.6575 |       - |      3 KB |
|  Hyperlinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  1.374 μs | 0.0184 μs | 0.0204 μs | 1.24x faster |   0.02x |  1.6575 |       - |      3 KB |
|                  Faslinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  2.066 μs | 0.0063 μs | 0.0059 μs | 1.21x slower |   0.01x |  5.5237 |       - |     11 KB |
|                          |               |                                                                     |               |       |           |           |           |              |         |         |         |           |
|                  ForLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  1.618 μs | 0.0223 μs | 0.0208 μs |     baseline |         |  5.5237 |       - |     11 KB |
|              ForeachLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  1.763 μs | 0.0116 μs | 0.0108 μs | 1.09x slower |   0.01x |  5.5237 |       - |     11 KB |
|                     Linq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  1.912 μs | 0.0140 μs | 0.0131 μs | 1.18x slower |   0.01x |  4.0035 |       - |      8 KB |
|               LinqFaster |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  2.131 μs | 0.0121 μs | 0.0107 μs | 1.32x slower |   0.02x |  5.5237 |       - |     11 KB |
|             LinqFasterer |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  2.087 μs | 0.0101 μs | 0.0090 μs | 1.29x slower |   0.01x |  6.3934 |       - |     13 KB |
|                   LinqAF |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  3.103 μs | 0.0238 μs | 0.0222 μs | 1.92x slower |   0.03x |  5.5122 |       - |     11 KB |
|            LinqOptimizer |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 10.122 μs | 0.0667 μs | 0.0557 μs | 6.25x slower |   0.09x | 50.0031 | 16.6626 |    132 KB |
|                  Streams |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  2.834 μs | 0.0249 μs | 0.0208 μs | 1.75x slower |   0.02x |  5.7716 |       - |     12 KB |
|               StructLinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  1.485 μs | 0.0089 μs | 0.0083 μs | 1.09x faster |   0.01x |  1.7109 |       - |      4 KB |
| StructLinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  1.097 μs | 0.0029 μs | 0.0024 μs | 1.48x faster |   0.02x |  1.6575 |       - |      3 KB |
|                Hyperlinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  1.811 μs | 0.0167 μs | 0.0156 μs | 1.12x slower |   0.01x |  1.6575 |       - |      3 KB |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  1.349 μs | 0.0088 μs | 0.0082 μs | 1.20x faster |   0.02x |  1.6575 |       - |      3 KB |
|                  Faslinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  2.116 μs | 0.0078 μs | 0.0069 μs | 1.31x slower |   0.02x |  5.5237 |       - |     11 KB |
|                          |               |                                                                     |               |       |           |           |           |              |         |         |         |           |
|                  ForLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  1.616 μs | 0.0110 μs | 0.0092 μs |     baseline |         |  5.5237 |       - |     11 KB |
|              ForeachLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  1.951 μs | 0.0074 μs | 0.0066 μs | 1.21x slower |   0.01x |  5.5237 |       - |     11 KB |
|                     Linq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  1.869 μs | 0.0045 μs | 0.0038 μs | 1.16x slower |   0.01x |  4.0054 |       - |      8 KB |
|               LinqFaster | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  1.971 μs | 0.0134 μs | 0.0112 μs | 1.22x slower |   0.01x |  5.5237 |       - |     11 KB |
|             LinqFasterer | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  1.986 μs | 0.0078 μs | 0.0073 μs | 1.23x slower |   0.01x |  6.3934 |       - |     13 KB |
|                   LinqAF | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  4.872 μs | 0.0312 μs | 0.0292 μs | 3.02x slower |   0.03x |  5.5084 |       - |     11 KB |
|            LinqOptimizer | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  9.705 μs | 0.1743 μs | 0.1630 μs | 6.00x slower |   0.11x | 62.7594 |  4.3335 |    132 KB |
|                  Streams | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  2.877 μs | 0.0118 μs | 0.0105 μs | 1.78x slower |   0.01x |  5.7716 |       - |     12 KB |
|               StructLinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  1.715 μs | 0.0175 μs | 0.0163 μs | 1.06x slower |   0.01x |  1.7109 |       - |      4 KB |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  1.404 μs | 0.0125 μs | 0.0117 μs | 1.15x faster |   0.01x |  1.6632 |       - |      3 KB |
|                Hyperlinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  2.152 μs | 0.0112 μs | 0.0100 μs | 1.33x slower |   0.01x |  1.6632 |       - |      3 KB |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  1.647 μs | 0.0055 μs | 0.0049 μs | 1.02x slower |   0.01x |  1.6632 |       - |      3 KB |
|                  Faslinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  2.004 μs | 0.0140 μs | 0.0124 μs | 1.24x slower |   0.01x |  5.5237 |       - |     11 KB |
