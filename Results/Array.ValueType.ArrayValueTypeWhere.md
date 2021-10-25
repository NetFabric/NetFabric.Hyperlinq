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

BenchmarkDotNet=v0.13.1, OS=macOS Catalina 10.15.7 (19H1419) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-rc.2.21505.57
  [Host]        : .NET Core 3.1.20 (CoreCLR 4.700.21.47003, CoreFX 4.700.21.47101), X64 RyuJIT
  .NET 6        : .NET 6.0.0 (6.0.21.48005), X64 RyuJIT
  .NET 6 PGO    : .NET 6.0.0 (6.0.21.48005), X64 RyuJIT
  .NET Core 3.1 : .NET Core 3.1.20 (CoreCLR 4.700.21.47003, CoreFX 4.700.21.47101), X64 RyuJIT


```
|                   Method |           Job |                                                   EnvironmentVariables |       Runtime | Count |        Mean |       Error |      StdDev |      Median |         Ratio | RatioSD |   Gen 0 |   Gen 1 | Allocated |
|------------------------- |-------------- |----------------------------------------------------------------------- |-------------- |------ |------------:|------------:|------------:|------------:|--------------:|--------:|--------:|--------:|----------:|
|                  ForLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |    470.9 ns |     1.10 ns |     0.91 ns |    470.5 ns |      baseline |         |       - |       - |         - |
|              ForeachLoop |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |    536.6 ns |     0.88 ns |     0.69 ns |    536.7 ns |  1.14x slower |   0.00x |       - |       - |         - |
|                     Linq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  1,136.0 ns |     6.19 ns |     5.79 ns |  1,133.4 ns |  2.41x slower |   0.01x |  0.0496 |       - |     104 B |
|               LinqFaster |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  1,529.1 ns |    28.39 ns |    30.38 ns |  1,523.5 ns |  3.23x slower |   0.06x |  4.7264 |       - |   9,904 B |
|             LinqFasterer |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  2,279.3 ns |    15.72 ns |    14.70 ns |  2,271.9 ns |  4.84x slower |   0.03x |  3.0174 |       - |   6,328 B |
|                   LinqAF |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  1,290.0 ns |     7.12 ns |     6.66 ns |  1,289.6 ns |  2.74x slower |   0.01x |       - |       - |         - |
|            LinqOptimizer |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  8,898.7 ns |   104.05 ns |    97.33 ns |  8,848.6 ns | 18.92x slower |   0.20x | 52.0782 | 10.4065 | 134,824 B |
|                 SpanLinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |    796.0 ns |     2.17 ns |     1.81 ns |    795.4 ns |  1.69x slower |   0.00x |       - |       - |         - |
|                  Streams |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  2,525.8 ns |    16.60 ns |    15.53 ns |  2,515.5 ns |  5.36x slower |   0.03x |  0.3929 |       - |     824 B |
|               StructLinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |    673.6 ns |     2.40 ns |     2.13 ns |    674.1 ns |  1.43x slower |   0.01x |  0.0153 |       - |      32 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |    582.3 ns |     2.94 ns |     2.61 ns |    580.8 ns |  1.24x slower |   0.01x |       - |       - |         - |
|                Hyperlinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  1,024.9 ns |     5.96 ns |     5.57 ns |  1,022.2 ns |  2.18x slower |   0.01x |       - |       - |         - |
|  Hyperlinq_ValueDelegate |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |    819.9 ns |     2.44 ns |     2.28 ns |    818.4 ns |  1.74x slower |   0.01x |       - |       - |         - |
|                  Faslinq |        .NET 6 |                                                                  Empty |      .NET 6.0 |   100 |  1,853.2 ns |    12.35 ns |    10.94 ns |  1,848.8 ns |  3.93x slower |   0.03x |  3.0670 |       - |   6,424 B |
|                          |               |                                                                        |               |       |             |             |             |             |               |         |         |         |           |
|                  ForLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |    449.1 ns |     1.16 ns |     1.03 ns |    448.7 ns |      baseline |         |       - |       - |         - |
|              ForeachLoop |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |    523.3 ns |     1.89 ns |     1.77 ns |    522.8 ns |  1.16x slower |   0.01x |       - |       - |         - |
|                     Linq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |    946.6 ns |     5.72 ns |     5.07 ns |    945.8 ns |  2.11x slower |   0.01x |  0.0496 |       - |     104 B |
|               LinqFaster |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  1,507.6 ns |    11.03 ns |    10.32 ns |  1,510.3 ns |  3.35x slower |   0.02x |  4.7264 |       - |   9,904 B |
|             LinqFasterer |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  2,050.3 ns |    13.47 ns |    12.60 ns |  2,045.1 ns |  4.57x slower |   0.04x |  3.0174 |       - |   6,328 B |
|                   LinqAF |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  1,136.7 ns |     8.84 ns |     6.90 ns |  1,139.0 ns |  2.53x slower |   0.01x |       - |       - |         - |
|            LinqOptimizer |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  8,914.3 ns |   162.29 ns |   151.81 ns |  8,961.4 ns | 19.87x slower |   0.34x | 52.0782 | 10.4065 | 134,824 B |
|                 SpanLinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |    770.2 ns |     2.71 ns |     2.54 ns |    769.1 ns |  1.72x slower |   0.01x |       - |       - |         - |
|                  Streams |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  1,946.8 ns |    27.19 ns |    25.43 ns |  1,939.6 ns |  4.34x slower |   0.06x |  0.3929 |       - |     824 B |
|               StructLinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |    645.4 ns |     3.54 ns |     3.31 ns |    645.4 ns |  1.44x slower |   0.01x |  0.0153 |       - |      32 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |    583.4 ns |     1.54 ns |     1.44 ns |    582.7 ns |  1.30x slower |   0.00x |       - |       - |         - |
|                Hyperlinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |    989.7 ns |     4.27 ns |     4.00 ns |    988.3 ns |  2.20x slower |   0.01x |       - |       - |         - |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |    876.3 ns |     1.86 ns |     1.74 ns |    875.5 ns |  1.95x slower |   0.00x |       - |       - |         - |
|                  Faslinq |    .NET 6 PGO | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 |      .NET 6.0 |   100 |  1,821.5 ns |    19.37 ns |    16.17 ns |  1,817.5 ns |  4.06x slower |   0.04x |  3.0670 |       - |   6,424 B |
|                          |               |                                                                        |               |       |             |             |             |             |               |         |         |         |           |
|                  ForLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |    562.2 ns |     1.50 ns |     1.40 ns |    561.6 ns |      baseline |         |       - |       - |         - |
|              ForeachLoop | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |    631.8 ns |     1.80 ns |     1.68 ns |    631.2 ns |  1.12x slower |   0.00x |       - |       - |         - |
|                     Linq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  1,540.6 ns |     6.28 ns |     5.87 ns |  1,539.2 ns |  2.74x slower |   0.01x |  0.0496 |       - |     104 B |
|               LinqFaster | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  1,502.7 ns |    12.84 ns |    12.01 ns |  1,496.7 ns |  2.67x slower |   0.02x |  4.7264 |       - |   9,904 B |
|             LinqFasterer | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  2,294.4 ns |    14.89 ns |    13.20 ns |  2,290.3 ns |  4.08x slower |   0.03x |  3.0212 |       - |   6,328 B |
|                   LinqAF | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  1,857.2 ns |     9.65 ns |     8.06 ns |  1,856.9 ns |  3.30x slower |   0.02x |       - |       - |         - |
|            LinqOptimizer | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 | 13,966.6 ns | 1,375.28 ns | 3,500.53 ns | 16,174.9 ns | 17.74x slower |   4.99x | 50.0183 | 12.4817 | 134,855 B |
|                 SpanLinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |    984.4 ns |     4.61 ns |     4.31 ns |    982.5 ns |  1.75x slower |   0.01x |       - |       - |         - |
|                  Streams | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  2,747.6 ns |    16.92 ns |    15.00 ns |  2,742.8 ns |  4.89x slower |   0.03x |  0.3929 |       - |     824 B |
|               StructLinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |    817.2 ns |     3.39 ns |     3.17 ns |    816.5 ns |  1.45x slower |   0.01x |  0.0153 |       - |      32 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |    663.6 ns |     1.77 ns |     1.57 ns |    663.3 ns |  1.18x slower |   0.00x |       - |       - |         - |
|                Hyperlinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  1,197.9 ns |     6.17 ns |     5.47 ns |  1,196.1 ns |  2.13x slower |   0.01x |       - |       - |         - |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |    890.6 ns |     2.79 ns |     2.47 ns |    890.7 ns |  1.58x slower |   0.01x |       - |       - |         - |
|                  Faslinq | .NET Core 3.1 |                                                                  Empty | .NET Core 3.1 |   100 |  1,882.1 ns |    12.22 ns |    10.20 ns |  1,879.3 ns |  3.35x slower |   0.02x |  3.0670 |       - |   6,424 B |
