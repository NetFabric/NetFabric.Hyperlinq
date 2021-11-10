## Range.RangeSelect

### Source
[RangeSelect.cs](../LinqBenchmarks/Range/RangeSelect.cs)

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
|                   Method |           Job |                                                EnvironmentVariables |       Runtime | Start | Count |      Mean |    Error |    StdDev |         Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |-------------- |-------------------------------------------------------------------- |-------------- |------ |------ |----------:|---------:|----------:|--------------:|--------:|-------:|----------:|
|                  ForLoop |        .NET 6 |                                                               Empty |      .NET 6.0 |     0 |   100 |  47.86 ns | 0.079 ns |  0.070 ns |      baseline |         |      - |         - |
|                     Linq |        .NET 6 |                                                               Empty |      .NET 6.0 |     0 |   100 | 678.91 ns | 1.036 ns |  0.865 ns | 14.18x slower |   0.03x | 0.0420 |      88 B |
|               LinqFaster |        .NET 6 |                                                               Empty |      .NET 6.0 |     0 |   100 | 337.53 ns | 2.527 ns |  2.240 ns |  7.05x slower |   0.05x | 0.4053 |     848 B |
|          LinqFaster_SIMD |        .NET 6 |                                                               Empty |      .NET 6.0 |     0 |   100 | 170.49 ns | 2.533 ns |  2.370 ns |  3.56x slower |   0.05x | 0.4053 |     848 B |
|                   LinqAF |        .NET 6 |                                                               Empty |      .NET 6.0 |     0 |   100 | 253.77 ns | 0.329 ns |  0.291 ns |  5.30x slower |   0.01x |      - |         - |
|               StructLinq |        .NET 6 |                                                               Empty |      .NET 6.0 |     0 |   100 | 206.27 ns | 0.259 ns |  0.202 ns |  4.31x slower |   0.01x | 0.0114 |      24 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 |     0 |   100 | 177.22 ns | 0.120 ns |  0.100 ns |  3.70x slower |   0.01x |      - |         - |
|                Hyperlinq |        .NET 6 |                                                               Empty |      .NET 6.0 |     0 |   100 | 221.38 ns | 0.285 ns |  0.253 ns |  4.63x slower |   0.01x |      - |         - |
|  Hyperlinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 |     0 |   100 | 183.87 ns | 0.201 ns |  0.188 ns |  3.84x slower |   0.01x |      - |         - |
|                          |               |                                                                     |               |       |       |           |          |           |               |         |        |           |
|                  ForLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |     0 |   100 |  47.22 ns | 0.124 ns |  0.110 ns |      baseline |         |      - |         - |
|                     Linq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |     0 |   100 | 409.15 ns | 0.698 ns |  0.619 ns |  8.66x slower |   0.03x | 0.0420 |      88 B |
|               LinqFaster |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |     0 |   100 | 367.28 ns | 3.311 ns |  2.765 ns |  7.78x slower |   0.05x | 0.4053 |     848 B |
|          LinqFaster_SIMD |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |     0 |   100 | 174.67 ns | 2.664 ns |  2.491 ns |  3.70x slower |   0.06x | 0.4053 |     848 B |
|                   LinqAF |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |     0 |   100 | 233.52 ns | 0.525 ns |  0.465 ns |  4.95x slower |   0.01x |      - |         - |
|               StructLinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |     0 |   100 | 194.59 ns | 0.158 ns |  0.148 ns |  4.12x slower |   0.01x | 0.0114 |      24 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |     0 |   100 | 179.56 ns | 0.176 ns |  0.164 ns |  3.80x slower |   0.01x |      - |         - |
|                Hyperlinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |     0 |   100 | 248.76 ns | 0.098 ns |  0.087 ns |  5.27x slower |   0.01x |      - |         - |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |     0 |   100 | 186.03 ns | 0.113 ns |  0.106 ns |  3.94x slower |   0.01x |      - |         - |
|                          |               |                                                                     |               |       |       |           |          |           |               |         |        |           |
|                  ForLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |     0 |   100 |  46.68 ns | 0.242 ns |  0.214 ns |      baseline |         |      - |         - |
|                     Linq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |     0 |   100 | 662.43 ns | 4.720 ns |  3.941 ns | 14.19x slower |   0.09x | 0.0420 |      88 B |
|               LinqFaster | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |     0 |   100 | 371.06 ns | 1.546 ns |  1.291 ns |  7.95x slower |   0.05x | 0.4053 |     848 B |
|          LinqFaster_SIMD | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |     0 |   100 | 182.56 ns | 0.495 ns |  0.386 ns |  3.91x slower |   0.02x | 0.4053 |     848 B |
|                   LinqAF | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |     0 |   100 | 567.00 ns | 9.539 ns | 13.057 ns | 12.32x slower |   0.29x |      - |         - |
|               StructLinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |     0 |   100 | 331.23 ns | 0.503 ns |  0.420 ns |  7.10x slower |   0.04x | 0.0114 |      24 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |     0 |   100 | 192.40 ns | 0.120 ns |  0.100 ns |  4.12x slower |   0.02x |      - |         - |
|                Hyperlinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |     0 |   100 | 332.98 ns | 0.205 ns |  0.192 ns |  7.13x slower |   0.03x |      - |         - |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |     0 |   100 | 196.50 ns | 0.223 ns |  0.198 ns |  4.21x slower |   0.02x |      - |         - |
