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

BenchmarkDotNet=v0.13.1, OS=macOS Catalina 10.15.7 (19H1419) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-rc.2.21505.57
  [Host]        : .NET Core 3.1.20 (CoreCLR 4.700.21.47003, CoreFX 4.700.21.47101), X64 RyuJIT
  .NET 6        : .NET 6.0.0 (6.0.21.48005), X64 RyuJIT
  .NET 6 PGO    : .NET 6.0.0 (6.0.21.48005), X64 RyuJIT
  .NET Core 3.1 : .NET Core 3.1.20 (CoreCLR 4.700.21.47003, CoreFX 4.700.21.47101), X64 RyuJIT


```
|                   Method |           Job |                                                   EnvironmentVariables |       Runtime | Count |     Mean |     Error |    StdDev |        Ratio | RatioSD |   Gen 0 | Allocated |
|------------------------- |-------------- |----------------------------------------------------------------------- |-------------- |------ |---------:|----------:|----------:|-------------:|--------:|--------:|----------:|
|                  ForLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 1.267 μs | 0.0114 μs | 0.0107 μs |     baseline |         |  3.8605 |      8 KB |
|              ForeachLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 1.365 μs | 0.0166 μs | 0.0155 μs | 1.08x slower |   0.02x |  3.8605 |      8 KB |
|                     Linq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 1.737 μs | 0.0139 μs | 0.0116 μs | 1.37x slower |   0.01x |  3.9673 |      8 KB |
|               LinqFaster |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 1.839 μs | 0.0233 μs | 0.0218 μs | 1.45x slower |   0.03x |  6.4087 |     13 KB |
|             LinqFasterer |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 3.049 μs | 0.0270 μs | 0.0253 μs | 2.41x slower |   0.03x |  9.0332 |     18 KB |
|                   LinqAF |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 2.664 μs | 0.0234 μs | 0.0219 μs | 2.10x slower |   0.03x |  3.8605 |      8 KB |
|            LinqOptimizer |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 9.464 μs | 0.1080 μs | 0.0958 μs | 7.47x slower |   0.08x | 64.5142 |    135 KB |
|                 SpanLinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 2.118 μs | 0.0194 μs | 0.0182 μs | 1.67x slower |   0.02x |  3.8605 |      8 KB |
|                  Streams |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 2.766 μs | 0.0255 μs | 0.0213 μs | 2.18x slower |   0.03x |  4.1275 |      8 KB |
|               StructLinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 1.556 μs | 0.0168 μs | 0.0157 μs | 1.23x slower |   0.02x |  1.7281 |      4 KB |
| StructLinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 1.241 μs | 0.0159 μs | 0.0149 μs | 1.02x faster |   0.02x |  1.6804 |      3 KB |
|                Hyperlinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 1.769 μs | 0.0133 μs | 0.0124 μs | 1.40x slower |   0.01x |  1.6804 |      3 KB |
|  Hyperlinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 1.444 μs | 0.0170 μs | 0.0151 μs | 1.14x slower |   0.02x |  1.6804 |      3 KB |
|                  Faslinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 1.747 μs | 0.0226 μs | 0.0201 μs | 1.38x slower |   0.02x |  6.1531 |     13 KB |
|                          |               |                                                                        |               |       |          |           |           |              |         |         |           |
|                  ForLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 1.195 μs | 0.0106 μs | 0.0094 μs |     baseline |         |  3.8605 |      8 KB |
|              ForeachLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 1.300 μs | 0.0186 μs | 0.0174 μs | 1.09x slower |   0.02x |  3.8605 |      8 KB |
|                     Linq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 1.754 μs | 0.0164 μs | 0.0154 μs | 1.47x slower |   0.02x |  3.9673 |      8 KB |
|               LinqFaster |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 1.885 μs | 0.0136 μs | 0.0127 μs | 1.58x slower |   0.02x |  6.4087 |     13 KB |
|             LinqFasterer |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 3.200 μs | 0.0223 μs | 0.0198 μs | 2.68x slower |   0.03x |  9.0332 |     18 KB |
|                   LinqAF |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 2.490 μs | 0.0220 μs | 0.0195 μs | 2.08x slower |   0.03x |  3.8605 |      8 KB |
|            LinqOptimizer |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 9.925 μs | 0.0841 μs | 0.0786 μs | 8.31x slower |   0.10x | 64.5142 |    135 KB |
|                 SpanLinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 2.025 μs | 0.0216 μs | 0.0203 μs | 1.69x slower |   0.02x |  3.8605 |      8 KB |
|                  Streams |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 2.828 μs | 0.0229 μs | 0.0214 μs | 2.37x slower |   0.03x |  4.1275 |      8 KB |
|               StructLinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 1.515 μs | 0.0213 μs | 0.0199 μs | 1.27x slower |   0.02x |  1.7281 |      4 KB |
| StructLinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 1.124 μs | 0.0133 μs | 0.0118 μs | 1.06x faster |   0.01x |  1.6804 |      3 KB |
|                Hyperlinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 1.853 μs | 0.0183 μs | 0.0171 μs | 1.55x slower |   0.02x |  1.6804 |      3 KB |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 1.420 μs | 0.0120 μs | 0.0106 μs | 1.19x slower |   0.01x |  1.6804 |      3 KB |
|                  Faslinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 1.827 μs | 0.0178 μs | 0.0167 μs | 1.53x slower |   0.01x |  6.1531 |     13 KB |
|                          |               |                                                                        |               |       |          |           |           |              |         |         |           |
|                  ForLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 1.220 μs | 0.0169 μs | 0.0150 μs |     baseline |         |  3.8605 |      8 KB |
|              ForeachLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 1.400 μs | 0.0280 μs | 0.0392 μs | 1.16x slower |   0.03x |  3.8605 |      8 KB |
|                     Linq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 1.680 μs | 0.0125 μs | 0.0117 μs | 1.38x slower |   0.01x |  3.9673 |      8 KB |
|               LinqFaster | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 1.755 μs | 0.0231 μs | 0.0216 μs | 1.44x slower |   0.02x |  6.4087 |     13 KB |
|             LinqFasterer | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 3.025 μs | 0.0535 μs | 0.0446 μs | 2.48x slower |   0.04x |  9.0332 |     18 KB |
|                   LinqAF | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 3.367 μs | 0.0385 μs | 0.0341 μs | 2.76x slower |   0.05x |  3.8605 |      8 KB |
|            LinqOptimizer | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 8.910 μs | 0.1749 μs | 0.3017 μs | 7.25x slower |   0.29x | 64.5142 |    135 KB |
|                 SpanLinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 2.309 μs | 0.0273 μs | 0.0255 μs | 1.89x slower |   0.02x |  3.8605 |      8 KB |
|                  Streams | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 2.843 μs | 0.0169 μs | 0.0132 μs | 2.33x slower |   0.03x |  4.1275 |      8 KB |
|               StructLinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 1.749 μs | 0.0103 μs | 0.0092 μs | 1.43x slower |   0.02x |  1.7223 |      4 KB |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 1.416 μs | 0.0155 μs | 0.0145 μs | 1.16x slower |   0.02x |  1.6766 |      3 KB |
|                Hyperlinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 2.187 μs | 0.0208 μs | 0.0184 μs | 1.79x slower |   0.02x |  1.6747 |      3 KB |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 1.704 μs | 0.0088 μs | 0.0069 μs | 1.40x slower |   0.02x |  1.6766 |      3 KB |
|                  Faslinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 1.709 μs | 0.0274 μs | 0.0256 μs | 1.40x slower |   0.02x |  6.1531 |     13 KB |
