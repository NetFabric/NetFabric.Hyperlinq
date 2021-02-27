## List.Int32.ListInt32SkipTakeSelect

### Source
[ListInt32SkipTakeSelect.cs](../LinqBenchmarks/List/Int32/ListInt32SkipTakeSelect.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta41](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta41)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1516-nightly, OS=Windows 10.0.19042.844 (20H2/October2020Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.1.21103.13
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|                      Method | Skip | Count |          Mean |      Error |     StdDev |  Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |----- |------ |--------------:|-----------:|-----------:|-------:|--------:|-------:|------:|------:|----------:|
|                     **ForLoop** | **1000** |    **10** |      **8.070 ns** |  **0.0296 ns** |  **0.0262 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop | 1000 |    10 |  4,339.239 ns | 15.1081 ns | 12.6159 ns | 537.79 |    1.26 | 0.0153 |     - |     - |      40 B |
|                        Linq | 1000 |    10 |    185.265 ns |  1.1713 ns |  0.9145 ns |  22.96 |    0.15 | 0.0725 |     - |     - |     152 B |
|                  LinqFaster | 1000 |    10 |    118.831 ns |  0.9016 ns |  0.7992 ns |  14.73 |    0.11 | 0.1376 |     - |     - |     288 B |
|                      LinqAF | 1000 |    10 |  4,372.745 ns | 11.2000 ns |  9.9285 ns | 541.86 |    2.06 |      - |     - |     - |         - |
|                  StructLinq | 1000 |    10 |     83.209 ns |  0.4523 ns |  0.3777 ns |  10.31 |    0.04 | 0.0459 |     - |     - |      96 B |
|        StructLinq_IFunction | 1000 |    10 |     39.227 ns |  0.1450 ns |  0.1286 ns |   4.86 |    0.02 |      - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |    10 |     60.616 ns |  0.2028 ns |  0.1693 ns |   7.51 |    0.03 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |    10 |     57.744 ns |  0.1949 ns |  0.1823 ns |   7.16 |    0.03 |      - |     - |     - |         - |
|               Hyperlinq_For | 1000 |    10 |     50.095 ns |  0.1975 ns |  0.1649 ns |   6.21 |    0.03 |      - |     - |     - |         - |
|                             |      |       |               |            |            |        |         |        |       |       |           |
|                     **ForLoop** | **1000** |  **1000** |    **805.989 ns** |  **3.0156 ns** |  **2.5181 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop | 1000 |  1000 |  7,251.834 ns | 45.3287 ns | 40.1827 ns |   9.00 |    0.06 | 0.0153 |     - |     - |      40 B |
|                        Linq | 1000 |  1000 |  9,036.098 ns | 49.2965 ns | 43.7001 ns |  11.21 |    0.07 | 0.0610 |     - |     - |     152 B |
|                  LinqFaster | 1000 |  1000 |  7,938.436 ns | 34.4269 ns | 30.5185 ns |   9.85 |    0.04 | 5.8136 |     - |     - |  12,168 B |
|                      LinqAF | 1000 |  1000 | 15,573.151 ns | 74.6279 ns | 66.1557 ns |  19.33 |    0.08 |      - |     - |     - |         - |
|                  StructLinq | 1000 |  1000 |  1,996.061 ns | 13.3171 ns | 11.8052 ns |   2.48 |    0.02 | 0.0458 |     - |     - |      96 B |
|        StructLinq_IFunction | 1000 |  1000 |  1,454.333 ns |  9.0079 ns |  7.9853 ns |   1.80 |    0.01 |      - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |  1000 |  2,204.358 ns | 14.7991 ns | 13.8431 ns |   2.74 |    0.02 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |  1000 |  1,555.405 ns |  3.7841 ns |  3.1599 ns |   1.93 |    0.01 |      - |     - |     - |         - |
|               Hyperlinq_For | 1000 |  1000 |  2,187.283 ns |  9.3339 ns |  8.2742 ns |   2.71 |    0.02 |      - |     - |     - |         - |
