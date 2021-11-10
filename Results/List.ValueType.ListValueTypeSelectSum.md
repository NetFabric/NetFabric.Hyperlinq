## List.ValueType.ListValueTypeSelectSum

### Source
[ListValueTypeSelectSum.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSelectSum.cs)

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
|                   Method |           Job |                                                EnvironmentVariables |       Runtime | Count |        Mean |     Error |    StdDev |        Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |-------------- |-------------------------------------------------------------------- |-------------- |------ |------------:|----------:|----------:|-------------:|--------:|-------:|----------:|
|                  ForLoop |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   164.03 ns |  0.087 ns |  0.068 ns |     baseline |         |      - |         - |
|              ForeachLoop |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   400.21 ns |  2.359 ns |  1.842 ns | 2.44x slower |   0.01x |      - |         - |
|                     Linq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 1,037.62 ns |  2.542 ns |  2.378 ns | 6.33x slower |   0.02x | 0.0458 |      96 B |
|               LinqFaster |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   396.28 ns |  0.103 ns |  0.097 ns | 2.42x slower |   0.00x |      - |         - |
|             LinqFasterer |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   691.76 ns |  1.051 ns |  0.878 ns | 4.22x slower |   0.01x | 3.0670 |   6,424 B |
|                   LinqAF |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 1,049.65 ns | 19.980 ns | 20.518 ns | 6.36x slower |   0.13x |      - |         - |
|            LinqOptimizer |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 1,378.43 ns |  3.184 ns |  2.659 ns | 8.40x slower |   0.01x | 0.0572 |     120 B |
|                  Streams |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   831.97 ns |  1.498 ns |  1.328 ns | 5.07x slower |   0.01x | 0.1717 |     360 B |
|               StructLinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   224.70 ns |  1.320 ns |  1.171 ns | 1.37x slower |   0.01x | 0.0191 |      40 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |    92.25 ns |  0.062 ns |  0.055 ns | 1.78x faster |   0.00x |      - |         - |
|                Hyperlinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   538.50 ns | 10.142 ns |  8.990 ns | 3.28x slower |   0.06x |      - |         - |
|  Hyperlinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   302.57 ns |  5.863 ns |  6.752 ns | 1.84x slower |   0.05x |      - |         - |
|                  Faslinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 1,336.34 ns |  1.476 ns |  1.232 ns | 8.15x slower |   0.01x | 0.5836 |   1,224 B |
|                          |               |                                                                     |               |       |             |           |           |              |         |        |           |
|                  ForLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   171.38 ns |  0.142 ns |  0.118 ns |     baseline |         |      - |         - |
|              ForeachLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   376.11 ns |  3.831 ns |  3.584 ns | 2.20x slower |   0.02x |      - |         - |
|                     Linq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   714.30 ns |  2.127 ns |  1.885 ns | 4.17x slower |   0.01x | 0.0458 |      96 B |
|               LinqFaster |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   384.61 ns |  0.584 ns |  0.547 ns | 2.24x slower |   0.00x |      - |         - |
|             LinqFasterer |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   708.12 ns | 14.034 ns | 16.162 ns | 4.16x slower |   0.10x | 3.0670 |   6,424 B |
|                   LinqAF |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   964.05 ns |  4.944 ns |  4.624 ns | 5.63x slower |   0.03x |      - |         - |
|            LinqOptimizer |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 1,316.28 ns |  1.909 ns |  1.594 ns | 7.68x slower |   0.01x | 0.0572 |     120 B |
|                  Streams |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   827.30 ns |  1.286 ns |  1.202 ns | 4.83x slower |   0.01x | 0.1717 |     360 B |
|               StructLinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   221.21 ns |  0.256 ns |  0.227 ns | 1.29x slower |   0.00x | 0.0191 |      40 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |    95.89 ns |  0.046 ns |  0.041 ns | 1.79x faster |   0.00x |      - |         - |
|                Hyperlinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   535.80 ns |  9.951 ns |  9.308 ns | 3.12x slower |   0.06x |      - |         - |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   284.54 ns |  1.805 ns |  1.600 ns | 1.66x slower |   0.01x |      - |         - |
|                  Faslinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   900.75 ns |  2.748 ns |  2.571 ns | 5.26x slower |   0.02x | 0.5846 |   1,224 B |
|                          |               |                                                                     |               |       |             |           |           |              |         |        |           |
|                  ForLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   224.23 ns |  1.094 ns |  0.970 ns |     baseline |         |      - |         - |
|              ForeachLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   509.73 ns |  0.312 ns |  0.292 ns | 2.27x slower |   0.01x |      - |         - |
|                     Linq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 1,072.75 ns |  1.954 ns |  1.732 ns | 4.78x slower |   0.02x | 0.0458 |      96 B |
|               LinqFaster | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   416.92 ns |  0.237 ns |  0.198 ns | 1.86x slower |   0.01x |      - |         - |
|             LinqFasterer | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   664.17 ns |  2.150 ns |  1.906 ns | 2.96x slower |   0.01x | 3.0670 |   6,424 B |
|                   LinqAF | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 1,754.37 ns |  3.278 ns |  2.738 ns | 7.82x slower |   0.03x |      - |         - |
|            LinqOptimizer | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 1,422.19 ns |  3.983 ns |  3.726 ns | 6.34x slower |   0.03x | 0.0725 |     152 B |
|                  Streams | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   932.59 ns |  1.084 ns |  0.961 ns | 4.16x slower |   0.02x | 0.1717 |     360 B |
|               StructLinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   249.58 ns |  0.504 ns |  0.472 ns | 1.11x slower |   0.01x | 0.0191 |      40 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |    98.44 ns |  0.092 ns |  0.076 ns | 2.28x faster |   0.01x |      - |         - |
|                Hyperlinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   630.39 ns |  0.567 ns |  0.503 ns | 2.81x slower |   0.01x |      - |         - |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   314.05 ns |  1.060 ns |  0.885 ns | 1.40x slower |   0.01x |      - |         - |
|                  Faslinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 1,510.80 ns |  2.094 ns |  1.857 ns | 6.74x slower |   0.03x | 0.5836 |   1,224 B |
