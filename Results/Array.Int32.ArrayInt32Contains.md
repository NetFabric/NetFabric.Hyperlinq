## Array.Int32.ArrayInt32Contains

### Source
[ArrayInt32Contains.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Contains.cs)

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
|                   Method |           Job |                                                   EnvironmentVariables |       Runtime | Count |      Mean |    Error |   StdDev |    Median |        Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |-------------- |----------------------------------------------------------------------- |-------------- |------ |----------:|---------:|---------:|----------:|-------------:|--------:|-------:|----------:|
|                  ForLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  46.76 ns | 0.964 ns | 1.473 ns |  46.01 ns |     baseline |         |      - |         - |
|              ForeachLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  44.57 ns | 0.234 ns | 0.219 ns |  44.56 ns | 1.07x faster |   0.03x |      - |         - |
|                     Linq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  39.51 ns | 0.199 ns | 0.186 ns |  39.41 ns | 1.21x faster |   0.03x |      - |         - |
|               LinqFaster |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  39.90 ns | 0.113 ns | 0.095 ns |  39.87 ns | 1.20x faster |   0.03x |      - |         - |
|          LinqFaster_SIMD |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  13.53 ns | 0.098 ns | 0.091 ns |  13.50 ns | 3.53x faster |   0.10x |      - |         - |
|             LinqFasterer |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  39.38 ns | 0.181 ns | 0.169 ns |  39.33 ns | 1.21x faster |   0.04x |      - |         - |
|                   LinqAF |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  41.88 ns | 0.068 ns | 0.053 ns |  41.88 ns | 1.15x faster |   0.02x |      - |         - |
|               StructLinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 165.34 ns | 1.539 ns | 1.365 ns | 164.69 ns | 3.46x slower |   0.10x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  69.31 ns | 0.416 ns | 0.369 ns |  69.10 ns | 1.45x slower |   0.04x |      - |         - |
|                Hyperlinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  48.74 ns | 0.148 ns | 0.124 ns |  48.68 ns | 1.02x slower |   0.03x | 0.0153 |      32 B |
|           Hyperlinq_SIMD |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  25.28 ns | 0.080 ns | 0.075 ns |  25.29 ns | 1.89x faster |   0.06x |      - |         - |
|                  Faslinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 188.94 ns | 0.936 ns | 0.830 ns | 188.50 ns | 3.95x slower |   0.12x | 0.0305 |      64 B |
|                          |               |                                                                        |               |       |           |          |          |           |              |         |        |           |
|                  ForLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  48.91 ns | 0.168 ns | 0.157 ns |  48.85 ns |     baseline |         |      - |         - |
|              ForeachLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  49.33 ns | 0.191 ns | 0.160 ns |  49.33 ns | 1.01x slower |   0.00x |      - |         - |
|                     Linq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  23.24 ns | 0.156 ns | 0.138 ns |  23.19 ns | 2.11x faster |   0.02x |      - |         - |
|               LinqFaster |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  18.44 ns | 0.129 ns | 0.229 ns |  18.33 ns | 2.65x faster |   0.03x |      - |         - |
|          LinqFaster_SIMD |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  14.31 ns | 0.128 ns | 0.107 ns |  14.26 ns | 3.42x faster |   0.02x |      - |         - |
|             LinqFasterer |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  23.16 ns | 0.115 ns | 0.108 ns |  23.11 ns | 2.11x faster |   0.01x |      - |         - |
|                   LinqAF |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  28.06 ns | 0.400 ns | 0.374 ns |  28.08 ns | 1.74x faster |   0.02x |      - |         - |
|               StructLinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 163.96 ns | 0.661 ns | 0.552 ns | 163.62 ns | 3.35x slower |   0.02x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  72.45 ns | 0.384 ns | 0.341 ns |  72.31 ns | 1.48x slower |   0.01x |      - |         - |
|                Hyperlinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  34.53 ns | 0.750 ns | 1.426 ns |  33.63 ns | 1.35x faster |   0.03x | 0.0153 |      32 B |
|           Hyperlinq_SIMD |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  24.76 ns | 0.598 ns | 0.530 ns |  24.87 ns | 1.98x faster |   0.04x |      - |         - |
|                  Faslinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 190.14 ns | 0.922 ns | 0.770 ns | 189.77 ns | 3.89x slower |   0.02x | 0.0305 |      64 B |
|                          |               |                                                                        |               |       |           |          |          |           |              |         |        |           |
|                  ForLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  63.45 ns | 0.163 ns | 0.128 ns |  63.43 ns |     baseline |         |      - |         - |
|              ForeachLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  63.86 ns | 0.586 ns | 0.548 ns |  63.74 ns | 1.01x slower |   0.01x |      - |         - |
|                     Linq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  51.20 ns | 0.618 ns | 0.578 ns |  51.06 ns | 1.24x faster |   0.02x |      - |         - |
|               LinqFaster | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  38.02 ns | 0.190 ns | 0.169 ns |  37.95 ns | 1.67x faster |   0.01x |      - |         - |
|          LinqFaster_SIMD | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  19.20 ns | 0.120 ns | 0.113 ns |  19.23 ns | 3.30x faster |   0.02x |      - |         - |
|             LinqFasterer | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  35.71 ns | 0.275 ns | 0.230 ns |  35.58 ns | 1.78x faster |   0.01x |      - |         - |
|                   LinqAF | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  31.75 ns | 0.230 ns | 0.215 ns |  31.65 ns | 2.00x faster |   0.01x |      - |         - |
|               StructLinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  84.83 ns | 0.368 ns | 0.326 ns |  84.74 ns | 1.34x slower |   0.01x | 0.0153 |      32 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  70.33 ns | 0.450 ns | 0.399 ns |  70.21 ns | 1.11x slower |   0.01x |      - |         - |
|                Hyperlinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  49.89 ns | 0.211 ns | 0.187 ns |  49.86 ns | 1.27x faster |   0.01x | 0.0153 |      32 B |
|           Hyperlinq_SIMD | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  36.66 ns | 0.423 ns | 0.396 ns |  36.67 ns | 1.74x faster |   0.02x |      - |         - |
|                  Faslinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 186.61 ns | 0.856 ns | 0.759 ns | 186.35 ns | 2.94x slower |   0.01x | 0.0305 |      64 B |
