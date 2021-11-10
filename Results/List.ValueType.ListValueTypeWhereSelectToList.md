## List.ValueType.ListValueTypeWhereSelectToList

### Source
[ListValueTypeWhereSelectToList.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelectToList.cs)

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
|                   Method |           Job |                                                EnvironmentVariables |       Runtime | Count |      Mean |     Error |    StdDev |        Ratio | RatioSD |   Gen 0 |  Gen 1 | Allocated |
|------------------------- |-------------- |-------------------------------------------------------------------- |-------------- |------ |----------:|----------:|----------:|-------------:|--------:|--------:|-------:|----------:|
|                  ForLoop |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  1.392 μs | 0.0047 μs | 0.0037 μs |     baseline |         |  3.8605 |      - |      8 KB |
|              ForeachLoop |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  1.573 μs | 0.0033 μs | 0.0031 μs | 1.13x slower |   0.00x |  3.8605 |      - |      8 KB |
|                     Linq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  1.762 μs | 0.0049 μs | 0.0044 μs | 1.27x slower |   0.00x |  4.0436 |      - |      8 KB |
|               LinqFaster |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  2.096 μs | 0.0106 μs | 0.0094 μs | 1.51x slower |   0.01x |  5.5389 |      - |     11 KB |
|             LinqFasterer |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  2.373 μs | 0.0093 μs | 0.0082 μs | 1.70x slower |   0.01x |  8.0643 |      - |     16 KB |
|                   LinqAF |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  3.523 μs | 0.0153 μs | 0.0128 μs | 2.53x slower |   0.01x |  3.8605 |      - |      8 KB |
|            LinqOptimizer |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 10.319 μs | 0.1280 μs | 0.1198 μs | 7.44x slower |   0.08x | 64.5142 |      - |    135 KB |
|                  Streams |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  3.019 μs | 0.0039 μs | 0.0032 μs | 2.17x slower |   0.01x |  4.1275 |      - |      8 KB |
|               StructLinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  1.565 μs | 0.0039 μs | 0.0034 μs | 1.12x slower |   0.00x |  1.7300 |      - |      4 KB |
| StructLinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  1.255 μs | 0.0029 μs | 0.0026 μs | 1.11x faster |   0.00x |  1.6804 |      - |      3 KB |
|                Hyperlinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  1.747 μs | 0.0028 μs | 0.0025 μs | 1.26x slower |   0.00x |  1.6804 |      - |      3 KB |
|  Hyperlinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  1.421 μs | 0.0037 μs | 0.0031 μs | 1.02x slower |   0.00x |  1.6804 |      - |      3 KB |
|                  Faslinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  1.809 μs | 0.0105 μs | 0.0088 μs | 1.30x slower |   0.01x |  3.8605 |      - |      8 KB |
|                          |               |                                                                     |               |       |           |           |           |              |         |         |        |           |
|                  ForLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  1.388 μs | 0.0043 μs | 0.0036 μs |     baseline |         |  3.8605 |      - |      8 KB |
|              ForeachLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  1.471 μs | 0.0078 μs | 0.0073 μs | 1.06x slower |   0.01x |  3.8605 |      - |      8 KB |
|                     Linq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  1.781 μs | 0.0233 μs | 0.0218 μs | 1.29x slower |   0.01x |  4.0455 |      - |      8 KB |
|               LinqFaster |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  2.161 μs | 0.0125 μs | 0.0117 μs | 1.56x slower |   0.01x |  5.5428 |      - |     11 KB |
|             LinqFasterer |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  2.388 μs | 0.0164 μs | 0.0154 μs | 1.72x slower |   0.01x |  8.0643 |      - |     16 KB |
|                   LinqAF |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  2.671 μs | 0.0187 μs | 0.0175 μs | 1.92x slower |   0.01x |  3.8605 |      - |      8 KB |
|            LinqOptimizer |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 10.670 μs | 0.1100 μs | 0.1029 μs | 7.68x slower |   0.08x | 64.5142 |      - |    135 KB |
|                  Streams |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  3.101 μs | 0.0284 μs | 0.0252 μs | 2.24x slower |   0.02x |  4.1275 |      - |      8 KB |
|               StructLinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  1.480 μs | 0.0205 μs | 0.0191 μs | 1.07x slower |   0.01x |  1.7300 |      - |      4 KB |
| StructLinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  1.119 μs | 0.0033 μs | 0.0027 μs | 1.24x faster |   0.00x |  1.6804 |      - |      3 KB |
|                Hyperlinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  1.813 μs | 0.0177 μs | 0.0166 μs | 1.31x slower |   0.01x |  1.6804 |      - |      3 KB |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  1.397 μs | 0.0044 μs | 0.0041 μs | 1.01x slower |   0.00x |  1.6804 |      - |      3 KB |
|                  Faslinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  1.804 μs | 0.0255 μs | 0.0213 μs | 1.30x slower |   0.02x |  3.8605 |      - |      8 KB |
|                          |               |                                                                     |               |       |           |           |           |              |         |         |        |           |
|                  ForLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  1.348 μs | 0.0084 μs | 0.0079 μs |     baseline |         |  3.8605 |      - |      8 KB |
|              ForeachLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  1.670 μs | 0.0073 μs | 0.0061 μs | 1.24x slower |   0.01x |  3.8605 |      - |      8 KB |
|                     Linq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  1.722 μs | 0.0064 μs | 0.0057 μs | 1.28x slower |   0.01x |  4.0436 |      - |      8 KB |
|               LinqFaster | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  2.002 μs | 0.0259 μs | 0.0217 μs | 1.49x slower |   0.01x |  5.5389 |      - |     11 KB |
|             LinqFasterer | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  2.270 μs | 0.0114 μs | 0.0101 μs | 1.68x slower |   0.01x |  8.0643 |      - |     16 KB |
|                   LinqAF | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  4.707 μs | 0.0114 μs | 0.0101 μs | 3.49x slower |   0.02x |  3.8605 |      - |      8 KB |
|            LinqOptimizer | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 10.094 μs | 0.2002 μs | 0.2383 μs | 7.48x slower |   0.18x | 64.4989 | 0.0305 |    135 KB |
|                  Streams | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  3.307 μs | 0.0095 μs | 0.0084 μs | 2.45x slower |   0.02x |  4.1275 |      - |      8 KB |
|               StructLinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  1.727 μs | 0.0167 μs | 0.0130 μs | 1.28x slower |   0.01x |  1.7262 |      - |      4 KB |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  1.426 μs | 0.0032 μs | 0.0027 μs | 1.06x slower |   0.01x |  1.6766 |      - |      3 KB |
|                Hyperlinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  2.192 μs | 0.0122 μs | 0.0114 μs | 1.63x slower |   0.01x |  1.6747 |      - |      3 KB |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  1.674 μs | 0.0078 μs | 0.0069 μs | 1.24x slower |   0.01x |  1.6766 |      - |      3 KB |
|                  Faslinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  1.743 μs | 0.0072 μs | 0.0060 μs | 1.29x slower |   0.01x |  3.8605 |      - |      8 KB |
