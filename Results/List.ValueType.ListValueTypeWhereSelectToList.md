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
|                  ForLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  1.395 μs | 0.0128 μs | 0.0114 μs |     baseline |         |  3.8605 |       - |      8 KB |
|              ForeachLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  1.537 μs | 0.0111 μs | 0.0104 μs | 1.10x slower |   0.01x |  3.8605 |       - |      8 KB |
|                     Linq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  1.742 μs | 0.0127 μs | 0.0113 μs | 1.25x slower |   0.01x |  4.0436 |       - |      8 KB |
|               LinqFaster |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  2.079 μs | 0.0248 μs | 0.0232 μs | 1.49x slower |   0.02x |  5.5389 |       - |     11 KB |
|             LinqFasterer |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  2.350 μs | 0.0233 μs | 0.0218 μs | 1.68x slower |   0.02x |  8.0643 |       - |     16 KB |
|                   LinqAF |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  3.518 μs | 0.0236 μs | 0.0209 μs | 2.52x slower |   0.02x |  3.8605 |       - |      8 KB |
|            LinqOptimizer |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 10.313 μs | 0.1413 μs | 0.1252 μs | 7.39x slower |   0.08x | 64.5142 |       - |    135 KB |
|                  Streams |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  3.015 μs | 0.0236 μs | 0.0221 μs | 2.16x slower |   0.02x |  4.1275 |       - |      8 KB |
|               StructLinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  1.554 μs | 0.0159 μs | 0.0149 μs | 1.11x slower |   0.02x |  1.7300 |       - |      4 KB |
| StructLinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  1.288 μs | 0.0088 μs | 0.0083 μs | 1.08x faster |   0.01x |  1.6804 |       - |      3 KB |
|                Hyperlinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  1.778 μs | 0.0179 μs | 0.0168 μs | 1.28x slower |   0.01x |  1.6804 |       - |      3 KB |
|  Hyperlinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  1.438 μs | 0.0233 μs | 0.0218 μs | 1.03x slower |   0.02x |  1.6804 |       - |      3 KB |
|                  Faslinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  1.764 μs | 0.0148 μs | 0.0138 μs | 1.26x slower |   0.01x |  3.8605 |       - |      8 KB |
|                          |               |                                                                        |               |       |           |           |           |              |         |         |         |           |
|                  ForLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  1.339 μs | 0.0031 μs | 0.0024 μs |     baseline |         |  3.8605 |       - |      8 KB |
|              ForeachLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  1.477 μs | 0.0167 μs | 0.0156 μs | 1.10x slower |   0.01x |  3.8605 |       - |      8 KB |
|                     Linq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  1.793 μs | 0.0169 μs | 0.0158 μs | 1.34x slower |   0.01x |  4.0455 |       - |      8 KB |
|               LinqFaster |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  2.133 μs | 0.0319 μs | 0.0299 μs | 1.59x slower |   0.02x |  5.5428 |       - |     11 KB |
|             LinqFasterer |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  2.417 μs | 0.0408 μs | 0.0361 μs | 1.81x slower |   0.03x |  8.0643 |       - |     16 KB |
|                   LinqAF |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  2.662 μs | 0.0150 μs | 0.0133 μs | 1.99x slower |   0.01x |  3.8605 |       - |      8 KB |
|            LinqOptimizer |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 10.632 μs | 0.1677 μs | 0.1568 μs | 7.95x slower |   0.11x | 64.5142 |       - |    135 KB |
|                  Streams |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  3.086 μs | 0.0244 μs | 0.0216 μs | 2.30x slower |   0.02x |  4.1275 |       - |      8 KB |
|               StructLinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  1.485 μs | 0.0172 μs | 0.0161 μs | 1.11x slower |   0.01x |  1.7300 |       - |      4 KB |
| StructLinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  1.144 μs | 0.0134 μs | 0.0119 μs | 1.17x faster |   0.01x |  1.6804 |       - |      3 KB |
|                Hyperlinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  1.875 μs | 0.0100 μs | 0.0083 μs | 1.40x slower |   0.01x |  1.6785 |       - |      3 KB |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  1.412 μs | 0.0102 μs | 0.0091 μs | 1.05x slower |   0.01x |  1.6804 |       - |      3 KB |
|                  Faslinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  1.826 μs | 0.0194 μs | 0.0182 μs | 1.36x slower |   0.01x |  3.8605 |       - |      8 KB |
|                          |               |                                                                        |               |       |           |           |           |              |         |         |         |           |
|                  ForLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  1.343 μs | 0.0229 μs | 0.0214 μs |     baseline |         |  3.8605 |       - |      8 KB |
|              ForeachLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  1.684 μs | 0.0123 μs | 0.0115 μs | 1.25x slower |   0.03x |  3.8605 |       - |      8 KB |
|                     Linq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  1.718 μs | 0.0223 μs | 0.0208 μs | 1.28x slower |   0.02x |  4.0455 |       - |      8 KB |
|               LinqFaster | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  1.974 μs | 0.0201 μs | 0.0188 μs | 1.47x slower |   0.03x |  5.5389 |       - |     11 KB |
|             LinqFasterer | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  2.305 μs | 0.0359 μs | 0.0300 μs | 1.72x slower |   0.04x |  8.0643 |       - |     16 KB |
|                   LinqAF | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  4.648 μs | 0.0303 μs | 0.0284 μs | 3.46x slower |   0.06x |  3.8605 |       - |      8 KB |
|            LinqOptimizer | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  9.635 μs | 0.1921 μs | 0.2933 μs | 7.15x slower |   0.28x | 62.5000 | 11.7188 |    135 KB |
|                  Streams | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  3.249 μs | 0.0248 μs | 0.0232 μs | 2.42x slower |   0.03x |  4.1275 |       - |      8 KB |
|               StructLinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  1.788 μs | 0.0347 μs | 0.0439 μs | 1.33x slower |   0.05x |  1.7262 |       - |      4 KB |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  1.460 μs | 0.0285 μs | 0.0305 μs | 1.09x slower |   0.02x |  1.6766 |       - |      3 KB |
|                Hyperlinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  2.202 μs | 0.0145 μs | 0.0136 μs | 1.64x slower |   0.03x |  1.6747 |       - |      3 KB |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  1.680 μs | 0.0104 μs | 0.0087 μs | 1.25x slower |   0.02x |  1.6766 |       - |      3 KB |
|                  Faslinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  1.722 μs | 0.0323 μs | 0.0302 μs | 1.28x slower |   0.03x |  3.8605 |       - |      8 KB |
