## Array.ValueType.ArrayValueTypeWhereSelectToArray

### Source
[ArrayValueTypeWhereSelectToArray.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelectToArray.cs)

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
|                   Method |           Job |                                                EnvironmentVariables |       Runtime | Count |     Mean |     Error |    StdDev |        Ratio | RatioSD |   Gen 0 |   Gen 1 | Allocated |
|------------------------- |-------------- |-------------------------------------------------------------------- |-------------- |------ |---------:|----------:|----------:|-------------:|--------:|--------:|--------:|----------:|
|                  ForLoop |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 1.549 μs | 0.0071 μs | 0.0067 μs |     baseline |         |  5.5237 |       - |     11 KB |
|              ForeachLoop |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 1.657 μs | 0.0042 μs | 0.0037 μs | 1.07x slower |   0.00x |  5.5237 |       - |     11 KB |
|                     Linq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 1.787 μs | 0.0051 μs | 0.0045 μs | 1.15x slower |   0.00x |  3.9291 |       - |      8 KB |
|               LinqFaster |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 1.532 μs | 0.0053 μs | 0.0047 μs | 1.01x faster |   0.00x |  4.7264 |       - |     10 KB |
|             LinqFasterer |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 2.583 μs | 0.0099 μs | 0.0088 μs | 1.67x slower |   0.01x |  6.0043 |       - |     12 KB |
|                   LinqAF |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 2.867 μs | 0.0092 μs | 0.0086 μs | 1.85x slower |   0.01x |  5.5122 |       - |     11 KB |
|            LinqOptimizer |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 9.325 μs | 0.0901 μs | 0.0799 μs | 6.02x slower |   0.06x | 62.4695 |  0.0153 |    132 KB |
|                 SpanLinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 2.360 μs | 0.0055 μs | 0.0052 μs | 1.52x slower |   0.01x |  5.5237 |       - |     11 KB |
|                  Streams |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 2.548 μs | 0.0079 μs | 0.0070 μs | 1.65x slower |   0.01x |  5.7716 |       - |     12 KB |
|               StructLinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 1.544 μs | 0.0085 μs | 0.0071 μs | 1.00x faster |   0.01x |  1.7052 |       - |      3 KB |
| StructLinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 1.234 μs | 0.0018 μs | 0.0016 μs | 1.25x faster |   0.01x |  1.6575 |       - |      3 KB |
|                Hyperlinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 1.732 μs | 0.0136 μs | 0.0127 μs | 1.12x slower |   0.01x |  1.6575 |       - |      3 KB |
|  Hyperlinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 1.364 μs | 0.0058 μs | 0.0051 μs | 1.13x faster |   0.01x |  1.6575 |       - |      3 KB |
|                  Faslinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 1.220 μs | 0.0012 μs | 0.0011 μs | 1.27x faster |   0.01x |  3.0670 |       - |      6 KB |
|                          |               |                                                                     |               |       |          |           |           |              |         |         |         |           |
|                  ForLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 1.548 μs | 0.0038 μs | 0.0034 μs |     baseline |         |  5.5237 |       - |     11 KB |
|              ForeachLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 1.662 μs | 0.0051 μs | 0.0042 μs | 1.07x slower |   0.00x |  5.5237 |       - |     11 KB |
|                     Linq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 1.847 μs | 0.0079 μs | 0.0066 μs | 1.19x slower |   0.00x |  3.9291 |       - |      8 KB |
|               LinqFaster |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 1.543 μs | 0.0061 μs | 0.0057 μs | 1.00x faster |   0.00x |  4.7264 |       - |     10 KB |
|             LinqFasterer |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 2.582 μs | 0.0092 μs | 0.0086 μs | 1.67x slower |   0.01x |  6.0043 |       - |     12 KB |
|                   LinqAF |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 2.850 μs | 0.0178 μs | 0.0166 μs | 1.84x slower |   0.01x |  5.5122 |       - |     11 KB |
|            LinqOptimizer |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 9.420 μs | 0.0962 μs | 0.0900 μs | 6.08x slower |   0.05x | 50.0031 | 16.6626 |    132 KB |
|                 SpanLinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 2.357 μs | 0.0356 μs | 0.0298 μs | 1.52x slower |   0.02x |  5.5237 |       - |     11 KB |
|                  Streams |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 2.570 μs | 0.0087 μs | 0.0068 μs | 1.66x slower |   0.01x |  5.7716 |       - |     12 KB |
|               StructLinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 1.548 μs | 0.0028 μs | 0.0025 μs | 1.00x slower |   0.00x |  1.7052 |       - |      3 KB |
| StructLinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 1.097 μs | 0.0110 μs | 0.0092 μs | 1.41x faster |   0.01x |  1.6575 |       - |      3 KB |
|                Hyperlinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 1.818 μs | 0.0197 μs | 0.0175 μs | 1.17x slower |   0.01x |  1.6575 |       - |      3 KB |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 1.343 μs | 0.0090 μs | 0.0084 μs | 1.15x faster |   0.01x |  1.6575 |       - |      3 KB |
|                  Faslinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 1.252 μs | 0.0050 μs | 0.0044 μs | 1.24x faster |   0.01x |  3.0670 |       - |      6 KB |
|                          |               |                                                                     |               |       |          |           |           |              |         |         |         |           |
|                  ForLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 1.475 μs | 0.0065 μs | 0.0057 μs |     baseline |         |  5.5237 |       - |     11 KB |
|              ForeachLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 1.656 μs | 0.0090 μs | 0.0075 μs | 1.12x slower |   0.01x |  5.5237 |       - |     11 KB |
|                     Linq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 1.815 μs | 0.0081 μs | 0.0072 μs | 1.23x slower |   0.01x |  3.9291 |       - |      8 KB |
|               LinqFaster | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 1.460 μs | 0.0099 μs | 0.0087 μs | 1.01x faster |   0.01x |  4.7264 |       - |     10 KB |
|             LinqFasterer | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 2.492 μs | 0.0100 μs | 0.0084 μs | 1.69x slower |   0.01x |  6.0043 |       - |     12 KB |
|                   LinqAF | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 3.485 μs | 0.0090 μs | 0.0070 μs | 2.36x slower |   0.01x |  5.5122 |       - |     11 KB |
|            LinqOptimizer | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 8.678 μs | 0.1034 μs | 0.0916 μs | 5.88x slower |   0.06x | 62.4847 |  0.2136 |    132 KB |
|                 SpanLinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 2.613 μs | 0.0162 μs | 0.0135 μs | 1.77x slower |   0.01x |  5.5237 |       - |     11 KB |
|                  Streams | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 2.544 μs | 0.0261 μs | 0.0244 μs | 1.73x slower |   0.02x |  5.7716 |       - |     12 KB |
|               StructLinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 1.680 μs | 0.0050 μs | 0.0047 μs | 1.14x slower |   0.01x |  1.7090 |       - |      3 KB |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 1.378 μs | 0.0042 μs | 0.0038 μs | 1.07x faster |   0.01x |  1.6632 |       - |      3 KB |
|                Hyperlinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 2.183 μs | 0.0140 μs | 0.0117 μs | 1.48x slower |   0.01x |  1.6632 |       - |      3 KB |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 1.659 μs | 0.0091 μs | 0.0076 μs | 1.12x slower |   0.01x |  1.6632 |       - |      3 KB |
|                  Faslinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 1.180 μs | 0.0034 μs | 0.0028 μs | 1.25x faster |   0.00x |  3.0670 |       - |      6 KB |
