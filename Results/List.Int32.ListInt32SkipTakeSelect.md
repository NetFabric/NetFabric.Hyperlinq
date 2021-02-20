## List.Int32.ListInt32SkipTakeSelect

### Source
[ListInt32SkipTakeSelect.cs](../LinqBenchmarks/List/Int32/ListInt32SkipTakeSelect.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta39](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta39)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=6.0.100-preview.1.21103.13
  [Host]        : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                      Method | Skip | Count |          Mean |       Error |        StdDev |    Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |----- |------ |--------------:|------------:|--------------:|---------:|--------:|-------:|------:|------:|----------:|
|                     **ForLoop** | **1000** |    **10** |      **8.966 ns** |   **0.2677 ns** |     **0.3665 ns** |     **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop | 1000 |    10 |  7,257.511 ns | 138.9028 ns |   289.9419 ns |   810.64 |   46.67 | 0.0153 |     - |     - |      40 B |
|                        Linq | 1000 |    10 |    238.138 ns |   4.6194 ns |     6.3231 ns |    26.60 |    1.26 | 0.0725 |     - |     - |     152 B |
|                  LinqFaster | 1000 |    10 |    120.269 ns |   0.7401 ns |     0.6180 ns |    13.46 |    0.66 | 0.1376 |     - |     - |     288 B |
|                      LinqAF | 1000 |    10 | 12,003.241 ns | 276.9278 ns |   816.5279 ns | 1,340.03 |  106.41 |      - |     - |     - |         - |
|                  StructLinq | 1000 |    10 |     92.980 ns |   0.3053 ns |     0.2707 ns |    10.44 |    0.49 | 0.0459 |     - |     - |      96 B |
|        StructLinq_IFunction | 1000 |    10 |     37.936 ns |   0.0513 ns |     0.0455 ns |     4.26 |    0.20 |      - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |    10 |     52.465 ns |   0.6102 ns |     0.5708 ns |     5.88 |    0.27 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |    10 |     32.483 ns |   0.1277 ns |     0.1132 ns |     3.65 |    0.17 |      - |     - |     - |         - |
|               Hyperlinq_For | 1000 |    10 |     32.037 ns |   0.1629 ns |     0.1361 ns |     3.59 |    0.17 |      - |     - |     - |         - |
|                             |      |       |               |             |               |          |         |        |       |       |           |
|                     **ForLoop** | **1000** |  **1000** |    **597.088 ns** |   **3.5017 ns** |     **3.1042 ns** |     **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop | 1000 |  1000 | 13,852.893 ns | 275.1200 ns |   753.1367 ns |    23.39 |    1.79 | 0.0153 |     - |     - |      40 B |
|                        Linq | 1000 |  1000 | 22,035.704 ns | 766.8061 ns | 2,260.9451 ns |    36.66 |    4.77 | 0.0610 |     - |     - |     152 B |
|                  LinqFaster | 1000 |  1000 |  8,693.229 ns |  68.0701 ns |    60.3424 ns |    14.56 |    0.14 | 5.8136 |     - |     - |   12168 B |
|                      LinqAF | 1000 |  1000 | 40,730.773 ns | 814.2579 ns | 2,400.8578 ns |    66.81 |    2.26 |      - |     - |     - |         - |
|                  StructLinq | 1000 |  1000 |  2,687.559 ns |   8.4202 ns |     7.0312 ns |     4.50 |    0.03 | 0.0458 |     - |     - |      96 B |
|        StructLinq_IFunction | 1000 |  1000 |  1,390.057 ns |   3.6475 ns |     2.8477 ns |     2.33 |    0.01 |      - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |  1000 |  2,628.129 ns |   5.1147 ns |     4.7843 ns |     4.40 |    0.02 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |  1000 |  1,427.764 ns |   2.2092 ns |     1.9584 ns |     2.39 |    0.01 |      - |     - |     - |         - |
|               Hyperlinq_For | 1000 |  1000 |  2,349.033 ns |  14.5206 ns |    12.8721 ns |     3.93 |    0.03 |      - |     - |     - |         - |
