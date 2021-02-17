## List.Int32.ListInt32SkipTakeSelect

### Source
[ListInt32SkipTakeSelect.cs](../LinqBenchmarks/List/Int32/ListInt32SkipTakeSelect.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta38](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta38)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.21079.7
  [Host]        : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                      Method | Skip | Count |           Mean |       Error |        StdDev |     Ratio |   RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |----- |------ |---------------:|------------:|--------------:|----------:|----------:|-------:|------:|------:|----------:|
|                     **ForLoop** | **1000** |     **0** |      **0.7574 ns** |   **0.1259 ns** |     **0.3712 ns** |      **1.00** |      **0.00** |      **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop | 1000 |     0 |  6,519.5925 ns | 128.7171 ns |   257.0620 ns | 15,082.49 | 30,161.30 | 0.0153 |     - |     - |      40 B |
|                        Linq | 1000 |     0 |     63.0117 ns |   0.9134 ns |     0.8544 ns |    129.81 |     50.55 | 0.0229 |     - |     - |      48 B |
|                  LinqFaster | 1000 |     0 |     32.1090 ns |   0.1363 ns |     0.1275 ns |     66.24 |     25.93 | 0.0459 |     - |     - |      96 B |
|                      LinqAF | 1000 |     0 |    135.9868 ns |   2.7196 ns |     3.2374 ns |    257.76 |    110.21 |      - |     - |     - |         - |
|                  StructLinq | 1000 |     0 |     58.2861 ns |   0.6012 ns |     0.5624 ns |    120.20 |     47.10 | 0.0459 |     - |     - |      96 B |
|        StructLinq_IFunction | 1000 |     0 |     20.3223 ns |   0.0611 ns |     0.0541 ns |     41.51 |     16.95 |      - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |     0 |     26.9476 ns |   0.5990 ns |     0.7997 ns |     50.54 |     22.39 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |     0 |     17.8969 ns |   0.1210 ns |     0.1132 ns |     36.88 |     14.37 |      - |     - |     - |         - |
|               Hyperlinq_For | 1000 |     0 |     16.2061 ns |   0.3342 ns |     0.3576 ns |     31.48 |     13.17 |      - |     - |     - |         - |
|                             |      |       |                |             |               |           |           |        |       |       |           |
|                     **ForLoop** | **1000** |    **10** |      **8.3085 ns** |   **0.2493 ns** |     **0.2968 ns** |      **1.00** |      **0.00** |      **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop | 1000 |    10 |  6,620.4472 ns | 130.3575 ns |   224.8603 ns |    799.13 |     46.90 | 0.0153 |     - |     - |      40 B |
|                        Linq | 1000 |    10 |    231.3954 ns |   4.5026 ns |     5.6943 ns |     27.90 |      1.24 | 0.0725 |     - |     - |     152 B |
|                  LinqFaster | 1000 |    10 |    121.1830 ns |   0.9298 ns |     0.8242 ns |     14.66 |      0.43 | 0.1376 |     - |     - |     288 B |
|                      LinqAF | 1000 |    10 | 11,838.3645 ns | 257.5438 ns |   759.3738 ns |  1,419.92 |    125.81 |      - |     - |     - |         - |
|                  StructLinq | 1000 |    10 |     89.1981 ns |   1.4043 ns |     1.3136 ns |     10.75 |      0.34 | 0.0459 |     - |     - |      96 B |
|        StructLinq_IFunction | 1000 |    10 |     35.7647 ns |   0.0549 ns |     0.0487 ns |      4.33 |      0.13 |      - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |    10 |     73.6850 ns |   1.7707 ns |     5.2208 ns |      8.84 |      0.54 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |    10 |     31.6592 ns |   0.0574 ns |     0.0509 ns |      3.83 |      0.11 |      - |     - |     - |         - |
|               Hyperlinq_For | 1000 |    10 |     58.2330 ns |   1.5958 ns |     4.6801 ns |      7.00 |      0.63 |      - |     - |     - |         - |
|                             |      |       |                |             |               |           |           |        |       |       |           |
|                     **ForLoop** | **1000** |  **1000** |    **642.0718 ns** |   **8.0088 ns** |     **6.6877 ns** |      **1.00** |      **0.00** |      **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop | 1000 |  1000 | 13,702.2248 ns | 269.6038 ns |   538.4279 ns |     21.19 |      0.86 | 0.0153 |     - |     - |      40 B |
|                        Linq | 1000 |  1000 | 18,921.6021 ns | 526.3332 ns | 1,551.9054 ns |     28.97 |      1.91 | 0.0610 |     - |     - |     152 B |
|                  LinqFaster | 1000 |  1000 |  8,680.2261 ns |  73.7786 ns |    65.4028 ns |     13.54 |      0.17 | 5.8136 |     - |     - |   12168 B |
|                      LinqAF | 1000 |  1000 | 27,585.1275 ns | 544.5620 ns | 1,206.7118 ns |     42.48 |      1.40 |      - |     - |     - |         - |
|                  StructLinq | 1000 |  1000 |  4,900.4008 ns | 103.1670 ns |   302.5709 ns |      7.76 |      0.49 | 0.0458 |     - |     - |      96 B |
|        StructLinq_IFunction | 1000 |  1000 |  1,392.1043 ns |   3.2589 ns |     2.8889 ns |      2.17 |      0.02 |      - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |  1000 |  4,717.6771 ns | 147.2347 ns |   434.1248 ns |      6.97 |      0.61 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |  1000 |  1,432.3371 ns |   3.5838 ns |     3.1770 ns |      2.23 |      0.02 |      - |     - |     - |         - |
|               Hyperlinq_For | 1000 |  1000 |  4,640.5658 ns | 139.2191 ns |   410.4905 ns |      7.37 |      0.47 |      - |     - |     - |         - |
