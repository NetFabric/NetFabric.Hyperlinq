## Array.ValueType.ArrayValueTypeWhere

### Source
[ArrayValueTypeWhere.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhere.cs)

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
|                   Method |           Job |                                                EnvironmentVariables |       Runtime | Count |       Mean |     Error |    StdDev |         Ratio | RatioSD |   Gen 0 |   Gen 1 | Allocated |
|------------------------- |-------------- |-------------------------------------------------------------------- |-------------- |------ |-----------:|----------:|----------:|--------------:|--------:|--------:|--------:|----------:|
|                  ForLoop |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   470.0 ns |   0.32 ns |   0.27 ns |      baseline |         |       - |       - |         - |
|              ForeachLoop |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   539.9 ns |   7.28 ns |   6.45 ns |  1.15x slower |   0.01x |       - |       - |         - |
|                     Linq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 1,121.9 ns |   2.63 ns |   2.20 ns |  2.39x slower |   0.01x |  0.0496 |       - |     104 B |
|               LinqFaster |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 1,478.3 ns |   5.05 ns |   4.47 ns |  3.15x slower |   0.01x |  4.7264 |       - |   9,904 B |
|             LinqFasterer |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 2,270.0 ns |   2.46 ns |   2.30 ns |  4.83x slower |   0.01x |  3.0174 |       - |   6,328 B |
|                   LinqAF |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 1,290.5 ns |   5.68 ns |   5.03 ns |  2.74x slower |   0.01x |       - |       - |         - |
|            LinqOptimizer |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 8,824.5 ns |  50.34 ns |  39.30 ns | 18.77x slower |   0.08x | 52.0782 | 10.4065 | 134,824 B |
|                 SpanLinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   790.8 ns |   1.42 ns |   1.26 ns |  1.68x slower |   0.00x |       - |       - |         - |
|                  Streams |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 2,462.4 ns |   4.58 ns |   3.82 ns |  5.24x slower |   0.01x |  0.3929 |       - |     824 B |
|               StructLinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   671.1 ns |   1.76 ns |   1.65 ns |  1.43x slower |   0.00x |  0.0153 |       - |      32 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   580.4 ns |   0.25 ns |   0.21 ns |  1.23x slower |   0.00x |       - |       - |         - |
|                Hyperlinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   991.5 ns |   0.58 ns |   0.48 ns |  2.11x slower |   0.00x |       - |       - |         - |
|  Hyperlinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 |   806.3 ns |   0.37 ns |   0.29 ns |  1.72x slower |   0.00x |       - |       - |         - |
|                  Faslinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 1,775.4 ns |   3.41 ns |   3.19 ns |  3.78x slower |   0.01x |  3.0670 |       - |   6,424 B |
|                          |               |                                                                     |               |       |            |           |           |               |         |         |         |           |
|                  ForLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   448.0 ns |   0.21 ns |   0.19 ns |      baseline |         |       - |       - |         - |
|              ForeachLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   521.0 ns |   0.45 ns |   0.42 ns |  1.16x slower |   0.00x |       - |       - |         - |
|                     Linq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   956.5 ns |   1.33 ns |   1.18 ns |  2.14x slower |   0.00x |  0.0496 |       - |     104 B |
|               LinqFaster |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 1,496.1 ns |   3.25 ns |   2.88 ns |  3.34x slower |   0.01x |  4.7264 |       - |   9,904 B |
|             LinqFasterer |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 2,037.9 ns |   3.16 ns |   2.95 ns |  4.55x slower |   0.01x |  3.0174 |       - |   6,328 B |
|                   LinqAF |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 1,180.2 ns |   6.06 ns |   5.38 ns |  2.63x slower |   0.01x |       - |       - |         - |
|            LinqOptimizer |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 9,143.9 ns | 168.22 ns | 157.36 ns | 20.41x slower |   0.36x | 52.0782 | 10.4065 | 134,824 B |
|                 SpanLinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   771.1 ns |   0.51 ns |   0.45 ns |  1.72x slower |   0.00x |       - |       - |         - |
|                  Streams |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 2,001.0 ns |  12.19 ns |  11.40 ns |  4.47x slower |   0.03x |  0.3929 |       - |     824 B |
|               StructLinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   643.4 ns |   4.42 ns |   3.92 ns |  1.44x slower |   0.01x |  0.0153 |       - |      32 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   566.5 ns |   0.29 ns |   0.23 ns |  1.26x slower |   0.00x |       - |       - |         - |
|                Hyperlinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 1,000.0 ns |   1.29 ns |   1.21 ns |  2.23x slower |   0.00x |       - |       - |         - |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 |   892.0 ns |   0.66 ns |   0.58 ns |  1.99x slower |   0.00x |       - |       - |         - |
|                  Faslinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 1,786.4 ns |   5.82 ns |   4.54 ns |  3.99x slower |   0.01x |  3.0670 |       - |   6,424 B |
|                          |               |                                                                     |               |       |            |           |           |               |         |         |         |           |
|                  ForLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   560.9 ns |   0.20 ns |   0.15 ns |      baseline |         |       - |       - |         - |
|              ForeachLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   630.4 ns |   0.90 ns |   0.80 ns |  1.12x slower |   0.00x |       - |       - |         - |
|                     Linq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 1,543.5 ns |   2.21 ns |   2.07 ns |  2.75x slower |   0.00x |  0.0496 |       - |     104 B |
|               LinqFaster | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 1,500.1 ns |   8.98 ns |   7.50 ns |  2.67x slower |   0.01x |  4.7264 |       - |   9,904 B |
|             LinqFasterer | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 2,330.7 ns |   7.10 ns |   6.30 ns |  4.16x slower |   0.01x |  3.0212 |       - |   6,328 B |
|                   LinqAF | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 1,867.7 ns |   4.26 ns |   3.77 ns |  3.33x slower |   0.01x |       - |       - |         - |
|            LinqOptimizer | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 9,074.7 ns |  79.23 ns | 113.63 ns | 16.23x slower |   0.24x | 62.4847 |       - | 134,860 B |
|                 SpanLinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 1,036.2 ns |   4.31 ns |   3.82 ns |  1.85x slower |   0.01x |       - |       - |         - |
|                  Streams | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 2,751.7 ns |  13.08 ns |  10.92 ns |  4.91x slower |   0.02x |  0.3929 |       - |     824 B |
|               StructLinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   819.5 ns |   2.69 ns |   2.51 ns |  1.46x slower |   0.00x |  0.0153 |       - |      32 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   662.1 ns |   0.37 ns |   0.33 ns |  1.18x slower |   0.00x |       - |       - |         - |
|                Hyperlinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 1,243.7 ns |   2.87 ns |   2.54 ns |  2.22x slower |   0.00x |       - |       - |         - |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 |   890.5 ns |   1.85 ns |   1.73 ns |  1.59x slower |   0.00x |       - |       - |         - |
|                  Faslinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 1,915.7 ns |   7.31 ns |   6.10 ns |  3.41x slower |   0.01x |  3.0670 |       - |   6,424 B |
