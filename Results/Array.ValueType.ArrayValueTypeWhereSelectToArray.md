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

BenchmarkDotNet=v0.13.1, OS=macOS Catalina 10.15.7 (19H1419) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-rc.2.21505.57
  [Host]        : .NET Core 3.1.20 (CoreCLR 4.700.21.47003, CoreFX 4.700.21.47101), X64 RyuJIT
  .NET 6        : .NET 6.0.0 (6.0.21.48005), X64 RyuJIT
  .NET 6 PGO    : .NET 6.0.0 (6.0.21.48005), X64 RyuJIT
  .NET Core 3.1 : .NET Core 3.1.20 (CoreCLR 4.700.21.47003, CoreFX 4.700.21.47101), X64 RyuJIT


```
|                   Method |           Job |                                                   EnvironmentVariables |       Runtime | Count |     Mean |     Error |    StdDev |        Ratio | RatioSD |   Gen 0 |   Gen 1 | Allocated |
|------------------------- |-------------- |----------------------------------------------------------------------- |-------------- |------ |---------:|----------:|----------:|-------------:|--------:|--------:|--------:|----------:|
|                  ForLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 1.547 μs | 0.0092 μs | 0.0086 μs |     baseline |         |  5.5237 |       - |     11 KB |
|              ForeachLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 1.648 μs | 0.0137 μs | 0.0114 μs | 1.07x slower |   0.01x |  5.5237 |       - |     11 KB |
|                     Linq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 1.788 μs | 0.0135 μs | 0.0126 μs | 1.16x slower |   0.01x |  3.9291 |       - |      8 KB |
|               LinqFaster |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 1.512 μs | 0.0132 μs | 0.0117 μs | 1.02x faster |   0.01x |  4.7264 |       - |     10 KB |
|             LinqFasterer |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 2.532 μs | 0.0314 μs | 0.0294 μs | 1.64x slower |   0.02x |  6.0043 |       - |     12 KB |
|                   LinqAF |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 2.864 μs | 0.0295 μs | 0.0276 μs | 1.85x slower |   0.02x |  5.5122 |       - |     11 KB |
|            LinqOptimizer |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 9.278 μs | 0.1360 μs | 0.1205 μs | 6.00x slower |   0.09x | 62.4695 |  0.0153 |    132 KB |
|                 SpanLinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 2.372 μs | 0.0213 μs | 0.0200 μs | 1.53x slower |   0.01x |  5.5237 |       - |     11 KB |
|                  Streams |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 2.534 μs | 0.0179 μs | 0.0159 μs | 1.64x slower |   0.01x |  5.7716 |       - |     12 KB |
|               StructLinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 1.548 μs | 0.0113 μs | 0.0106 μs | 1.00x slower |   0.01x |  1.7052 |       - |      3 KB |
| StructLinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 1.222 μs | 0.0143 μs | 0.0134 μs | 1.27x faster |   0.01x |  1.6575 |       - |      3 KB |
|                Hyperlinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 1.731 μs | 0.0175 μs | 0.0155 μs | 1.12x slower |   0.01x |  1.6575 |       - |      3 KB |
|  Hyperlinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 1.404 μs | 0.0157 μs | 0.0147 μs | 1.10x faster |   0.02x |  1.6575 |       - |      3 KB |
|                  Faslinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 1.223 μs | 0.0094 μs | 0.0084 μs | 1.27x faster |   0.01x |  3.0670 |       - |      6 KB |
|                          |               |                                                                        |               |       |          |           |           |              |         |         |         |           |
|                  ForLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 1.532 μs | 0.0183 μs | 0.0163 μs |     baseline |         |  5.5237 |       - |     11 KB |
|              ForeachLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 1.659 μs | 0.0157 μs | 0.0147 μs | 1.08x slower |   0.01x |  5.5237 |       - |     11 KB |
|                     Linq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 1.841 μs | 0.0173 μs | 0.0161 μs | 1.20x slower |   0.02x |  3.9291 |       - |      8 KB |
|               LinqFaster |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 1.570 μs | 0.0142 μs | 0.0126 μs | 1.03x slower |   0.01x |  4.7264 |       - |     10 KB |
|             LinqFasterer |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 2.610 μs | 0.0229 μs | 0.0214 μs | 1.71x slower |   0.02x |  6.0043 |       - |     12 KB |
|                   LinqAF |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 2.859 μs | 0.0245 μs | 0.0229 μs | 1.87x slower |   0.03x |  5.5122 |       - |     11 KB |
|            LinqOptimizer |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 9.236 μs | 0.1609 μs | 0.1505 μs | 6.04x slower |   0.09x | 50.0031 | 16.6626 |    132 KB |
|                 SpanLinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 2.336 μs | 0.0191 μs | 0.0179 μs | 1.53x slower |   0.02x |  5.5237 |       - |     11 KB |
|                  Streams |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 2.581 μs | 0.0210 μs | 0.0196 μs | 1.68x slower |   0.02x |  5.7716 |       - |     12 KB |
|               StructLinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 1.519 μs | 0.0090 μs | 0.0080 μs | 1.01x faster |   0.01x |  1.7052 |       - |      3 KB |
| StructLinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 1.111 μs | 0.0123 μs | 0.0115 μs | 1.38x faster |   0.02x |  1.6575 |       - |      3 KB |
|                Hyperlinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 1.844 μs | 0.0145 μs | 0.0136 μs | 1.20x slower |   0.01x |  1.6575 |       - |      3 KB |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 1.396 μs | 0.0102 μs | 0.0095 μs | 1.10x faster |   0.02x |  1.6575 |       - |      3 KB |
|                  Faslinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 1.254 μs | 0.0144 μs | 0.0135 μs | 1.22x faster |   0.02x |  3.0670 |       - |      6 KB |
|                          |               |                                                                        |               |       |          |           |           |              |         |         |         |           |
|                  ForLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 1.466 μs | 0.0136 μs | 0.0127 μs |     baseline |         |  5.5237 |       - |     11 KB |
|              ForeachLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 1.648 μs | 0.0150 μs | 0.0140 μs | 1.12x slower |   0.01x |  5.5237 |       - |     11 KB |
|                     Linq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 1.794 μs | 0.0114 μs | 0.0107 μs | 1.22x slower |   0.01x |  3.9291 |       - |      8 KB |
|               LinqFaster | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 1.461 μs | 0.0183 μs | 0.0171 μs | 1.00x faster |   0.01x |  4.7264 |       - |     10 KB |
|             LinqFasterer | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 2.524 μs | 0.0397 μs | 0.0352 μs | 1.72x slower |   0.03x |  6.0043 |       - |     12 KB |
|                   LinqAF | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 3.581 μs | 0.0288 μs | 0.0270 μs | 2.44x slower |   0.02x |  5.5122 |       - |     11 KB |
|            LinqOptimizer | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 8.524 μs | 0.1181 μs | 0.1047 μs | 5.81x slower |   0.08x | 62.4847 |  0.0305 |    132 KB |
|                 SpanLinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 2.642 μs | 0.0352 μs | 0.0312 μs | 1.80x slower |   0.03x |  5.5237 |       - |     11 KB |
|                  Streams | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 2.508 μs | 0.0265 μs | 0.0248 μs | 1.71x slower |   0.02x |  5.7716 |       - |     12 KB |
|               StructLinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 1.721 μs | 0.0180 μs | 0.0160 μs | 1.17x slower |   0.01x |  1.7090 |       - |      3 KB |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 1.395 μs | 0.0105 μs | 0.0098 μs | 1.05x faster |   0.01x |  1.6632 |       - |      3 KB |
|                Hyperlinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 2.213 μs | 0.0268 μs | 0.0250 μs | 1.51x slower |   0.02x |  1.6632 |       - |      3 KB |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 1.676 μs | 0.0155 μs | 0.0145 μs | 1.14x slower |   0.02x |  1.6632 |       - |      3 KB |
|                  Faslinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 1.183 μs | 0.0130 μs | 0.0122 μs | 1.24x faster |   0.02x |  3.0670 |       - |      6 KB |
