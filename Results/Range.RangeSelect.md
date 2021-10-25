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

BenchmarkDotNet=v0.13.1, OS=macOS Catalina 10.15.7 (19H1419) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-rc.2.21505.57
  [Host]        : .NET Core 3.1.20 (CoreCLR 4.700.21.47003, CoreFX 4.700.21.47101), X64 RyuJIT
  .NET 6        : .NET 6.0.0 (6.0.21.48005), X64 RyuJIT
  .NET 6 PGO    : .NET 6.0.0 (6.0.21.48005), X64 RyuJIT
  .NET Core 3.1 : .NET Core 3.1.20 (CoreCLR 4.700.21.47003, CoreFX 4.700.21.47101), X64 RyuJIT


```
|                   Method |           Job |                                                   EnvironmentVariables |       Runtime | Start | Count |      Mean |    Error |   StdDev |         Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |-------------- |----------------------------------------------------------------------- |-------------- |------ |------ |----------:|---------:|---------:|--------------:|--------:|-------:|----------:|
|                  ForLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 |     0 |   100 |  46.35 ns | 0.370 ns | 0.309 ns |      baseline |         |      - |         - |
|                     Linq |        .NET 6 |                                                                  Empty |      .NET 6.0 |     0 |   100 | 690.35 ns | 3.509 ns | 3.283 ns | 14.89x slower |   0.14x | 0.0420 |      88 B |
|               LinqFaster |        .NET 6 |                                                                  Empty |      .NET 6.0 |     0 |   100 | 337.50 ns | 3.084 ns | 2.885 ns |  7.27x slower |   0.05x | 0.4053 |     848 B |
|          LinqFaster_SIMD |        .NET 6 |                                                                  Empty |      .NET 6.0 |     0 |   100 | 168.73 ns | 1.832 ns | 1.624 ns |  3.64x slower |   0.04x | 0.4053 |     848 B |
|                   LinqAF |        .NET 6 |                                                                  Empty |      .NET 6.0 |     0 |   100 | 255.09 ns | 1.600 ns | 1.496 ns |  5.50x slower |   0.05x |      - |         - |
|               StructLinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |     0 |   100 | 206.96 ns | 0.903 ns | 0.844 ns |  4.46x slower |   0.03x | 0.0114 |      24 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 |     0 |   100 | 177.60 ns | 0.261 ns | 0.231 ns |  3.83x slower |   0.03x |      - |         - |
|                Hyperlinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |     0 |   100 | 222.01 ns | 0.546 ns | 0.484 ns |  4.79x slower |   0.03x |      - |         - |
|  Hyperlinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 |     0 |   100 | 184.73 ns | 0.358 ns | 0.317 ns |  3.99x slower |   0.03x |      - |         - |
|                          |               |                                                                        |               |       |       |           |          |          |               |         |        |           |
|                  ForLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |     0 |   100 |  47.57 ns | 0.194 ns | 0.172 ns |      baseline |         |      - |         - |
|                     Linq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |     0 |   100 | 412.88 ns | 1.876 ns | 1.566 ns |  8.68x slower |   0.05x | 0.0420 |      88 B |
|               LinqFaster |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |     0 |   100 | 368.88 ns | 3.557 ns | 3.153 ns |  7.75x slower |   0.06x | 0.4053 |     848 B |
|          LinqFaster_SIMD |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |     0 |   100 | 168.70 ns | 1.619 ns | 1.352 ns |  3.55x slower |   0.03x | 0.4053 |     848 B |
|                   LinqAF |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |     0 |   100 | 229.43 ns | 0.941 ns | 0.881 ns |  4.82x slower |   0.03x |      - |         - |
|               StructLinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |     0 |   100 | 242.60 ns | 0.810 ns | 0.718 ns |  5.10x slower |   0.03x | 0.0114 |      24 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |     0 |   100 | 179.50 ns | 0.241 ns | 0.226 ns |  3.77x slower |   0.01x |      - |         - |
|                Hyperlinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |     0 |   100 | 199.78 ns | 0.727 ns | 0.607 ns |  4.20x slower |   0.02x |      - |         - |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |     0 |   100 | 186.96 ns | 0.377 ns | 0.334 ns |  3.93x slower |   0.01x |      - |         - |
|                          |               |                                                                        |               |       |       |           |          |          |               |         |        |           |
|                  ForLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |     0 |   100 |  46.02 ns | 0.176 ns | 0.156 ns |      baseline |         |      - |         - |
|                     Linq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |     0 |   100 | 687.60 ns | 3.783 ns | 3.539 ns | 14.94x slower |   0.10x | 0.0420 |      88 B |
|               LinqFaster | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |     0 |   100 | 339.49 ns | 4.343 ns | 4.062 ns |  7.37x slower |   0.11x | 0.4053 |     848 B |
|          LinqFaster_SIMD | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |     0 |   100 | 175.13 ns | 2.763 ns | 2.449 ns |  3.81x slower |   0.06x | 0.4053 |     848 B |
|                   LinqAF | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |     0 |   100 | 544.06 ns | 1.717 ns | 1.606 ns | 11.82x slower |   0.02x |      - |         - |
|               StructLinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |     0 |   100 | 286.14 ns | 1.755 ns | 1.642 ns |  6.22x slower |   0.02x | 0.0114 |      24 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |     0 |   100 | 193.64 ns | 0.403 ns | 0.377 ns |  4.21x slower |   0.02x |      - |         - |
|                Hyperlinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |     0 |   100 | 311.50 ns | 1.529 ns | 1.355 ns |  6.77x slower |   0.03x |      - |         - |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |     0 |   100 | 201.17 ns | 0.318 ns | 0.298 ns |  4.37x slower |   0.01x |      - |         - |
