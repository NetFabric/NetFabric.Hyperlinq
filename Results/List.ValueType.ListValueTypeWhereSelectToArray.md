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

BenchmarkDotNet=v0.13.1, OS=macOS Catalina 10.15.7 (19H1419) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-rc.2.21505.57
  [Host]        : .NET Core 3.1.20 (CoreCLR 4.700.21.47003, CoreFX 4.700.21.47101), X64 RyuJIT
  .NET 6        : .NET 6.0.0 (6.0.21.48005), X64 RyuJIT
  .NET 6 PGO    : .NET 6.0.0 (6.0.21.48005), X64 RyuJIT
  .NET Core 3.1 : .NET Core 3.1.20 (CoreCLR 4.700.21.47003, CoreFX 4.700.21.47101), X64 RyuJIT


```
|                   Method |           Job |                                                   EnvironmentVariables |       Runtime | Count |      Mean |     Error |    StdDev |        Ratio | RatioSD |   Gen 0 |   Gen 1 | Allocated |
|------------------------- |-------------- |----------------------------------------------------------------------- |-------------- |------ |----------:|----------:|----------:|-------------:|--------:|--------:|--------:|----------:|
|                  ForLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  1.666 μs | 0.0162 μs | 0.0152 μs |     baseline |         |  5.5237 |       - |     11 KB |
|              ForeachLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  1.830 μs | 0.0116 μs | 0.0103 μs | 1.10x slower |   0.01x |  5.5237 |       - |     11 KB |
|                     Linq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  1.807 μs | 0.0174 μs | 0.0163 μs | 1.08x slower |   0.02x |  4.0035 |       - |      8 KB |
|               LinqFaster |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  2.052 μs | 0.0253 μs | 0.0212 μs | 1.23x slower |   0.02x |  5.5237 |       - |     11 KB |
|             LinqFasterer |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  2.028 μs | 0.0219 μs | 0.0194 μs | 1.22x slower |   0.02x |  6.3934 |       - |     13 KB |
|                   LinqAF |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  3.746 μs | 0.0238 μs | 0.0223 μs | 2.25x slower |   0.02x |  5.5122 |       - |     11 KB |
|            LinqOptimizer |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  9.898 μs | 0.0948 μs | 0.0840 μs | 5.94x slower |   0.05x | 49.3774 | 12.3444 |    132 KB |
|                  Streams |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  2.765 μs | 0.0177 μs | 0.0157 μs | 1.66x slower |   0.01x |  5.7716 |       - |     12 KB |
|               StructLinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  1.548 μs | 0.0109 μs | 0.0102 μs | 1.08x faster |   0.02x |  1.7109 |       - |      4 KB |
| StructLinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  1.216 μs | 0.0129 μs | 0.0101 μs | 1.37x faster |   0.02x |  1.6575 |       - |      3 KB |
|                Hyperlinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  1.761 μs | 0.0172 μs | 0.0153 μs | 1.06x slower |   0.01x |  1.6575 |       - |      3 KB |
|  Hyperlinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  1.412 μs | 0.0170 μs | 0.0159 μs | 1.18x faster |   0.02x |  1.6575 |       - |      3 KB |
|                  Faslinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  2.047 μs | 0.0123 μs | 0.0096 μs | 1.23x slower |   0.01x |  5.5237 |       - |     11 KB |
|                          |               |                                                                        |               |       |           |           |           |              |         |         |         |           |
|                  ForLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  1.611 μs | 0.0172 μs | 0.0153 μs |     baseline |         |  5.5237 |       - |     11 KB |
|              ForeachLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  1.782 μs | 0.0136 μs | 0.0128 μs | 1.11x slower |   0.01x |  5.5237 |       - |     11 KB |
|                     Linq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  1.898 μs | 0.0205 μs | 0.0182 μs | 1.18x slower |   0.02x |  4.0016 |       - |      8 KB |
|               LinqFaster |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  2.095 μs | 0.0220 μs | 0.0195 μs | 1.30x slower |   0.02x |  5.5237 |       - |     11 KB |
|             LinqFasterer |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  2.076 μs | 0.0274 μs | 0.0256 μs | 1.29x slower |   0.02x |  6.3934 |       - |     13 KB |
|                   LinqAF |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  3.105 μs | 0.0206 μs | 0.0192 μs | 1.93x slower |   0.02x |  5.5122 |       - |     11 KB |
|            LinqOptimizer |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 10.103 μs | 0.1666 μs | 0.1558 μs | 6.27x slower |   0.11x | 50.0031 | 16.6626 |    132 KB |
|                  Streams |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  2.848 μs | 0.0191 μs | 0.0179 μs | 1.77x slower |   0.02x |  5.7716 |       - |     12 KB |
|               StructLinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  1.488 μs | 0.0117 μs | 0.0110 μs | 1.08x faster |   0.02x |  1.7109 |       - |      4 KB |
| StructLinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  1.109 μs | 0.0074 μs | 0.0062 μs | 1.45x faster |   0.01x |  1.6575 |       - |      3 KB |
|                Hyperlinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  1.847 μs | 0.0178 μs | 0.0166 μs | 1.15x slower |   0.01x |  1.6575 |       - |      3 KB |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  1.393 μs | 0.0167 μs | 0.0148 μs | 1.16x faster |   0.02x |  1.6575 |       - |      3 KB |
|                  Faslinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  2.096 μs | 0.0118 μs | 0.0092 μs | 1.30x slower |   0.01x |  5.5237 |       - |     11 KB |
|                          |               |                                                                        |               |       |           |           |           |              |         |         |         |           |
|                  ForLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  1.595 μs | 0.0157 μs | 0.0139 μs |     baseline |         |  5.5237 |       - |     11 KB |
|              ForeachLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  1.973 μs | 0.0390 μs | 0.0365 μs | 1.24x slower |   0.03x |  5.5237 |       - |     11 KB |
|                     Linq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  1.841 μs | 0.0144 μs | 0.0120 μs | 1.15x slower |   0.01x |  4.0016 |       - |      8 KB |
|               LinqFaster | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  1.944 μs | 0.0123 μs | 0.0103 μs | 1.22x slower |   0.01x |  5.5237 |       - |     11 KB |
|             LinqFasterer | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  1.987 μs | 0.0143 μs | 0.0127 μs | 1.25x slower |   0.01x |  6.3934 |       - |     13 KB |
|                   LinqAF | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  4.888 μs | 0.0376 μs | 0.0314 μs | 3.06x slower |   0.04x |  5.5084 |       - |     11 KB |
|            LinqOptimizer | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  9.554 μs | 0.1437 μs | 0.1344 μs | 5.98x slower |   0.09x | 62.5000 |  0.1831 |    132 KB |
|                  Streams | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  2.823 μs | 0.0237 μs | 0.0210 μs | 1.77x slower |   0.02x |  5.7716 |       - |     12 KB |
|               StructLinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  1.729 μs | 0.0243 μs | 0.0228 μs | 1.09x slower |   0.01x |  1.7109 |       - |      4 KB |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  1.406 μs | 0.0120 μs | 0.0106 μs | 1.13x faster |   0.01x |  1.6632 |       - |      3 KB |
|                Hyperlinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  2.171 μs | 0.0156 μs | 0.0138 μs | 1.36x slower |   0.01x |  1.6632 |       - |      3 KB |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  1.675 μs | 0.0176 μs | 0.0156 μs | 1.05x slower |   0.01x |  1.6632 |       - |      3 KB |
|                  Faslinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  1.984 μs | 0.0366 μs | 0.0359 μs | 1.25x slower |   0.03x |  5.5237 |       - |     11 KB |
