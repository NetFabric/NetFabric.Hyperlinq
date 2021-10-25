## List.ValueType.ListValueTypeSkipTakeSelect

### Source
[ListValueTypeSkipTakeSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSkipTakeSelect.cs)

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
|                   Method |           Job |                                                   EnvironmentVariables |       Runtime | Skip | Count |      Mean |     Error |    StdDev |    Median |         Ratio | RatioSD |   Gen 0 |   Gen 1 | Allocated |
|------------------------- |-------------- |----------------------------------------------------------------------- |-------------- |----- |------ |----------:|----------:|----------:|----------:|--------------:|--------:|--------:|--------:|----------:|
|                  ForLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 |  1.711 μs | 0.0059 μs | 0.0053 μs |  1.709 μs |      baseline |         |       - |       - |         - |
|                     Linq |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 |  2.859 μs | 0.0091 μs | 0.0081 μs |  2.859 μs |  1.67x slower |   0.01x |  0.1526 |       - |     320 B |
|               LinqFaster |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 |  5.002 μs | 0.0716 μs | 0.0670 μs |  4.963 μs |  2.92x slower |   0.04x |  9.2545 |       - |  19,368 B |
|             LinqFasterer |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 |  8.619 μs | 0.1115 μs | 0.1043 μs |  8.598 μs |  5.04x slower |   0.06x | 39.2151 |       - |  83,304 B |
|                   LinqAF |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 | 14.474 μs | 0.5518 μs | 1.6097 μs | 13.998 μs |  8.64x slower |   0.91x |       - |       - |     816 B |
|            LinqOptimizer |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 | 19.863 μs | 0.2275 μs | 0.2128 μs | 19.816 μs | 11.61x slower |   0.13x | 49.9878 | 16.6626 | 137,863 B |
|                  Streams |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 | 13.264 μs | 0.0586 μs | 0.0519 μs | 13.240 μs |  7.75x slower |   0.04x |  0.5493 |       - |   1,176 B |
|               StructLinq |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 |  1.957 μs | 0.0068 μs | 0.0063 μs |  1.956 μs |  1.14x slower |   0.01x |  0.0572 |       - |     120 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 |  1.912 μs | 0.0057 μs | 0.0048 μs |  1.909 μs |  1.12x slower |   0.00x |       - |       - |         - |
|                Hyperlinq |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 |  1.956 μs | 0.0077 μs | 0.0064 μs |  1.952 μs |  1.14x slower |   0.00x |       - |       - |         - |
|  Hyperlinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 | 1000 |   100 |  1.784 μs | 0.0045 μs | 0.0038 μs |  1.782 μs |  1.04x slower |   0.00x |       - |       - |         - |
|                          |               |                                                                        |               |      |       |           |           |           |           |               |         |         |         |           |
|                  ForLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |  1.652 μs | 0.0049 μs | 0.0046 μs |  1.649 μs |      baseline |         |       - |       - |         - |
|                     Linq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |  2.335 μs | 0.0092 μs | 0.0086 μs |  2.333 μs |  1.41x slower |   0.01x |  0.1526 |       - |     320 B |
|               LinqFaster |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |  4.982 μs | 0.0671 μs | 0.0628 μs |  4.968 μs |  3.02x slower |   0.04x |  9.2545 |       - |  19,368 B |
|             LinqFasterer |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |  8.674 μs | 0.0426 μs | 0.0333 μs |  8.689 μs |  5.25x slower |   0.03x | 39.2151 |       - |  83,304 B |
|                   LinqAF |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |  9.745 μs | 0.0688 μs | 0.0644 μs |  9.742 μs |  5.90x slower |   0.05x |       - |       - |         - |
|            LinqOptimizer |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 | 21.002 μs | 0.2425 μs | 0.2150 μs | 20.996 μs | 12.71x slower |   0.15x | 49.9878 | 16.6626 | 137,863 B |
|                  Streams |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 | 12.144 μs | 0.0470 μs | 0.0416 μs | 12.140 μs |  7.35x slower |   0.02x |  0.5493 |       - |   1,176 B |
|               StructLinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |  1.914 μs | 0.0089 μs | 0.0079 μs |  1.911 μs |  1.16x slower |   0.00x |  0.0572 |       - |     120 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |  1.620 μs | 0.0026 μs | 0.0023 μs |  1.619 μs |  1.02x faster |   0.00x |       - |       - |         - |
|                Hyperlinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |  1.920 μs | 0.0023 μs | 0.0018 μs |  1.919 μs |  1.16x slower |   0.00x |       - |       - |         - |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 | 1000 |   100 |  1.728 μs | 0.0037 μs | 0.0031 μs |  1.725 μs |  1.05x slower |   0.00x |       - |       - |         - |
|                          |               |                                                                        |               |      |       |           |           |           |           |               |         |         |         |           |
|                  ForLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 |  1.939 μs | 0.0032 μs | 0.0027 μs |  1.939 μs |      baseline |         |       - |       - |         - |
|                     Linq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 |  2.993 μs | 0.0326 μs | 0.0289 μs |  2.989 μs |  1.54x slower |   0.02x |  0.1526 |       - |     320 B |
|               LinqFaster | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 |  5.008 μs | 0.0412 μs | 0.0385 μs |  4.998 μs |  2.58x slower |   0.02x |  9.2545 |       - |  19,368 B |
|             LinqFasterer | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 |  8.409 μs | 0.1355 μs | 0.1267 μs |  8.373 μs |  4.33x slower |   0.07x | 39.2151 |       - |  83,304 B |
|                   LinqAF | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 | 30.946 μs | 0.6171 μs | 1.6256 μs | 30.115 μs | 16.61x slower |   1.09x |       - |       - |      48 B |
|            LinqOptimizer | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 | 24.627 μs | 0.4693 μs | 0.5217 μs | 24.663 μs | 12.79x slower |   0.25x | 49.9878 | 16.6626 | 137,895 B |
|                  Streams | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 | 14.104 μs | 0.0657 μs | 0.0583 μs | 14.096 μs |  7.27x slower |   0.03x |  0.5493 |       - |   1,176 B |
|               StructLinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 |  2.224 μs | 0.0064 μs | 0.0053 μs |  2.223 μs |  1.15x slower |   0.00x |  0.0572 |       - |     120 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 |  1.995 μs | 0.0049 μs | 0.0044 μs |  1.994 μs |  1.03x slower |   0.00x |       - |       - |         - |
|                Hyperlinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 |  2.273 μs | 0.0055 μs | 0.0051 μs |  2.270 μs |  1.17x slower |   0.00x |       - |       - |         - |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 | 1000 |   100 |  2.045 μs | 0.0304 μs | 0.0285 μs |  2.032 μs |  1.05x slower |   0.01x |       - |       - |         - |
