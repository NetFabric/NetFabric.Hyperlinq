## Array.ValueType.ArrayValueTypeWhereSelectToList

### Source
[ArrayValueTypeWhereSelectToList.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelectToList.cs)

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
|                  ForLoop |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  1.295 μs | 0.0034 μs | 0.0031 μs |     baseline |         |  3.8605 |      - |      8 KB |
|              ForeachLoop |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  1.358 μs | 0.0040 μs | 0.0036 μs | 1.05x slower |   0.00x |  3.8605 |      - |      8 KB |
|                     Linq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  1.727 μs | 0.0045 μs | 0.0038 μs | 1.33x slower |   0.00x |  3.9673 |      - |      8 KB |
|               LinqFaster |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  1.843 μs | 0.0164 μs | 0.0137 μs | 1.42x slower |   0.01x |  6.4087 |      - |     13 KB |
|             LinqFasterer |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  3.112 μs | 0.0077 μs | 0.0060 μs | 2.40x slower |   0.01x |  9.0332 |      - |     18 KB |
|                   LinqAF |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  2.688 μs | 0.0052 μs | 0.0046 μs | 2.08x slower |   0.01x |  3.8605 |      - |      8 KB |
|            LinqOptimizer |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  9.670 μs | 0.0578 μs | 0.0540 μs | 7.46x slower |   0.05x | 64.5142 |      - |    135 KB |
|                 SpanLinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  2.043 μs | 0.0038 μs | 0.0034 μs | 1.58x slower |   0.00x |  3.8605 |      - |      8 KB |
|                  Streams |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  2.774 μs | 0.0081 μs | 0.0076 μs | 2.14x slower |   0.01x |  4.1275 |      - |      8 KB |
|               StructLinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  1.554 μs | 0.0036 μs | 0.0028 μs | 1.20x slower |   0.00x |  1.7281 |      - |      4 KB |
| StructLinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  1.274 μs | 0.0041 μs | 0.0037 μs | 1.02x faster |   0.00x |  1.6804 |      - |      3 KB |
|                Hyperlinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  1.743 μs | 0.0020 μs | 0.0018 μs | 1.35x slower |   0.00x |  1.6804 |      - |      3 KB |
|  Hyperlinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  1.400 μs | 0.0052 μs | 0.0044 μs | 1.08x slower |   0.00x |  1.6804 |      - |      3 KB |
|                  Faslinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |  1.783 μs | 0.0041 μs | 0.0039 μs | 1.38x slower |   0.00x |  6.1531 |      - |     13 KB |
|                          |               |                                                                     |               |       |           |           |           |              |         |         |        |           |
|                  ForLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  1.195 μs | 0.0039 μs | 0.0036 μs |     baseline |         |  3.8605 |      - |      8 KB |
|              ForeachLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  1.291 μs | 0.0028 μs | 0.0022 μs | 1.08x slower |   0.00x |  3.8605 |      - |      8 KB |
|                     Linq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  1.748 μs | 0.0060 μs | 0.0056 μs | 1.46x slower |   0.00x |  3.9673 |      - |      8 KB |
|               LinqFaster |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  1.866 μs | 0.0208 μs | 0.0185 μs | 1.56x slower |   0.01x |  6.4087 |      - |     13 KB |
|             LinqFasterer |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  3.162 μs | 0.0139 μs | 0.0130 μs | 2.65x slower |   0.01x |  9.0332 |      - |     18 KB |
|                   LinqAF |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  2.503 μs | 0.0073 μs | 0.0064 μs | 2.10x slower |   0.01x |  3.8605 |      - |      8 KB |
|            LinqOptimizer |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 10.026 μs | 0.1121 μs | 0.0994 μs | 8.39x slower |   0.07x | 64.5142 |      - |    135 KB |
|                 SpanLinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  2.036 μs | 0.0050 μs | 0.0047 μs | 1.70x slower |   0.00x |  3.8605 |      - |      8 KB |
|                  Streams |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  2.790 μs | 0.0052 μs | 0.0046 μs | 2.34x slower |   0.01x |  4.1275 |      - |      8 KB |
|               StructLinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  1.534 μs | 0.0045 μs | 0.0038 μs | 1.28x slower |   0.01x |  1.7281 |      - |      4 KB |
| StructLinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  1.112 μs | 0.0031 μs | 0.0027 μs | 1.07x faster |   0.00x |  1.6804 |      - |      3 KB |
|                Hyperlinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  1.806 μs | 0.0039 μs | 0.0034 μs | 1.51x slower |   0.00x |  1.6804 |      - |      3 KB |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  1.396 μs | 0.0039 μs | 0.0033 μs | 1.17x slower |   0.00x |  1.6804 |      - |      3 KB |
|                  Faslinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |  1.828 μs | 0.0256 μs | 0.0200 μs | 1.53x slower |   0.02x |  6.1531 |      - |     13 KB |
|                          |               |                                                                     |               |       |           |           |           |              |         |         |        |           |
|                  ForLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  1.240 μs | 0.0079 μs | 0.0070 μs |     baseline |         |  3.8605 |      - |      8 KB |
|              ForeachLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  1.393 μs | 0.0085 μs | 0.0075 μs | 1.12x slower |   0.01x |  3.8605 |      - |      8 KB |
|                     Linq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  1.730 μs | 0.0087 μs | 0.0081 μs | 1.40x slower |   0.01x |  3.9673 |      - |      8 KB |
|               LinqFaster | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  1.739 μs | 0.0107 μs | 0.0089 μs | 1.40x slower |   0.01x |  6.4087 |      - |     13 KB |
|             LinqFasterer | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  3.011 μs | 0.0212 μs | 0.0165 μs | 2.43x slower |   0.02x |  9.0332 |      - |     18 KB |
|                   LinqAF | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  3.258 μs | 0.0135 μs | 0.0112 μs | 2.63x slower |   0.02x |  3.8605 |      - |      8 KB |
|            LinqOptimizer | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  8.998 μs | 0.1322 μs | 0.1032 μs | 7.27x slower |   0.08x | 64.4836 | 0.1221 |    135 KB |
|                 SpanLinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  2.329 μs | 0.0083 μs | 0.0078 μs | 1.88x slower |   0.01x |  3.8605 |      - |      8 KB |
|                  Streams | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  2.859 μs | 0.0097 μs | 0.0090 μs | 2.31x slower |   0.01x |  4.1275 |      - |      8 KB |
|               StructLinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  1.726 μs | 0.0046 μs | 0.0043 μs | 1.39x slower |   0.01x |  1.7223 |      - |      4 KB |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  1.435 μs | 0.0138 μs | 0.0129 μs | 1.16x slower |   0.01x |  1.6766 |      - |      3 KB |
|                Hyperlinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  2.194 μs | 0.0099 μs | 0.0092 μs | 1.77x slower |   0.01x |  1.6747 |      - |      3 KB |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  1.657 μs | 0.0030 μs | 0.0025 μs | 1.34x slower |   0.01x |  1.6766 |      - |      3 KB |
|                  Faslinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |  1.705 μs | 0.0173 μs | 0.0153 μs | 1.37x slower |   0.02x |  6.1531 |      - |     13 KB |
