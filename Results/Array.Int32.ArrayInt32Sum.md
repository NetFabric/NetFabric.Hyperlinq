## Array.Int32.ArrayInt32Sum

### Source
[ArrayInt32Sum.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Sum.cs)

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
|                   Method |           Job |                                                   EnvironmentVariables |       Runtime | Count |      Mean |     Error |   StdDev |         Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |-------------- |----------------------------------------------------------------------- |-------------- |------ |----------:|----------:|---------:|--------------:|--------:|-------:|----------:|
|                  ForLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  47.22 ns |  0.167 ns | 0.148 ns |      baseline |         |      - |         - |
|              ForeachLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  47.80 ns |  0.270 ns | 0.252 ns |  1.01x slower |   0.01x |      - |         - |
|                     Linq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 501.99 ns |  2.702 ns | 2.396 ns | 10.63x slower |   0.07x | 0.0153 |      32 B |
|               LinqFaster |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  54.12 ns |  0.239 ns | 0.212 ns |  1.15x slower |   0.00x |      - |         - |
|          LinqFaster_SIMD |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  12.82 ns |  0.097 ns | 0.086 ns |  3.68x faster |   0.02x |      - |         - |
|             LinqFasterer |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  66.52 ns |  0.189 ns | 0.157 ns |  1.41x slower |   0.01x |      - |         - |
|                   LinqAF |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 101.82 ns |  0.279 ns | 0.261 ns |  2.16x slower |   0.01x |      - |         - |
|            LinqOptimizer |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 618.68 ns |  2.662 ns | 2.078 ns | 13.10x slower |   0.07x | 0.0114 |      24 B |
|                  Streams |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 | 245.85 ns |  3.142 ns | 2.786 ns |  5.21x slower |   0.05x | 0.0992 |     208 B |
|               StructLinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  81.48 ns |  0.328 ns | 0.291 ns |  1.73x slower |   0.01x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  65.70 ns |  0.162 ns | 0.144 ns |  1.39x slower |   0.01x |      - |         - |
|                Hyperlinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  22.47 ns |  0.063 ns | 0.059 ns |  2.10x faster |   0.01x |      - |         - |
|                          |               |                                                                        |               |       |           |           |          |               |         |        |           |
|                  ForLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  48.41 ns |  0.239 ns | 0.212 ns |      baseline |         |      - |         - |
|              ForeachLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  48.36 ns |  0.128 ns | 0.107 ns |  1.00x faster |   0.00x |      - |         - |
|                     Linq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 272.27 ns |  1.498 ns | 1.401 ns |  5.62x slower |   0.04x | 0.0153 |      32 B |
|               LinqFaster |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  54.46 ns |  0.147 ns | 0.138 ns |  1.12x slower |   0.00x |      - |         - |
|          LinqFaster_SIMD |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  13.37 ns |  0.055 ns | 0.046 ns |  3.62x faster |   0.02x |      - |         - |
|             LinqFasterer |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  66.60 ns |  0.098 ns | 0.082 ns |  1.38x slower |   0.01x |      - |         - |
|                   LinqAF |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  94.11 ns |  0.395 ns | 0.350 ns |  1.94x slower |   0.01x |      - |         - |
|            LinqOptimizer |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 597.36 ns | 10.508 ns | 9.830 ns | 12.35x slower |   0.18x | 0.0114 |      24 B |
|                  Streams |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 | 197.61 ns |  1.052 ns | 0.984 ns |  4.08x slower |   0.02x | 0.0994 |     208 B |
|               StructLinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  80.68 ns |  0.122 ns | 0.095 ns |  1.67x slower |   0.01x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  66.45 ns |  0.133 ns | 0.111 ns |  1.37x slower |   0.01x |      - |         - |
|                Hyperlinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  20.56 ns |  0.079 ns | 0.074 ns |  2.35x faster |   0.01x |      - |         - |
|                          |               |                                                                        |               |       |           |           |          |               |         |        |           |
|                  ForLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  63.08 ns |  0.370 ns | 0.328 ns |      baseline |         |      - |         - |
|              ForeachLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  63.15 ns |  0.424 ns | 0.397 ns |  1.00x slower |   0.01x |      - |         - |
|                     Linq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 529.66 ns |  0.545 ns | 0.426 ns |  8.39x slower |   0.05x | 0.0153 |      32 B |
|               LinqFaster | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  54.12 ns |  0.178 ns | 0.167 ns |  1.17x faster |   0.01x |      - |         - |
|          LinqFaster_SIMD | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  23.25 ns |  0.127 ns | 0.119 ns |  2.71x faster |   0.02x |      - |         - |
|             LinqFasterer | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  72.58 ns |  0.315 ns | 0.279 ns |  1.15x slower |   0.01x |      - |         - |
|                   LinqAF | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 104.16 ns |  0.544 ns | 0.482 ns |  1.65x slower |   0.01x |      - |         - |
|            LinqOptimizer | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 729.36 ns |  4.545 ns | 4.029 ns | 11.56x slower |   0.09x | 0.0267 |      56 B |
|                  Streams | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 236.57 ns |  0.461 ns | 0.385 ns |  3.75x slower |   0.02x | 0.0992 |     208 B |
|               StructLinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 135.14 ns |  2.627 ns | 3.322 ns |  2.14x slower |   0.06x | 0.0153 |      32 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  91.75 ns |  0.325 ns | 0.288 ns |  1.45x slower |   0.01x |      - |         - |
|                Hyperlinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  46.25 ns |  0.395 ns | 0.369 ns |  1.36x faster |   0.01x |      - |         - |
