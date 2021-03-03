## List.Int32.ListInt32SkipTakeSelect

### Source
[ListInt32SkipTakeSelect.cs](../LinqBenchmarks/List/Int32/ListInt32SkipTakeSelect.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta42](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta42)

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
|                     **ForLoop** | **1000** |    **10** |      **7.748 ns** |  **0.0213 ns** |  **0.0178 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop | 1000 |    10 |  4,195.149 ns | 10.6430 ns |  9.4348 ns | 541.58 |    1.94 | 0.0153 |     - |     - |      40 B |
|                        Linq | 1000 |    10 |    173.647 ns |  0.5800 ns |  0.4529 ns |  22.41 |    0.07 | 0.0725 |     - |     - |     152 B |
|                  LinqFaster | 1000 |    10 |    105.725 ns |  0.3411 ns |  0.3191 ns |  13.65 |    0.06 | 0.1377 |     - |     - |     288 B |
|                      LinqAF | 1000 |    10 |  4,110.180 ns | 16.1577 ns | 13.4924 ns | 530.51 |    2.44 |      - |     - |     - |         - |
|                  StructLinq | 1000 |    10 |     77.937 ns |  0.2581 ns |  0.2288 ns |  10.06 |    0.04 | 0.0459 |     - |     - |      96 B |
|        StructLinq_IFunction | 1000 |    10 |     37.949 ns |  0.0692 ns |  0.0647 ns |   4.90 |    0.02 |      - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |    10 |     58.923 ns |  0.1269 ns |  0.1187 ns |   7.61 |    0.03 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |    10 |     57.829 ns |  0.1140 ns |  0.1011 ns |   7.46 |    0.02 |      - |     - |     - |         - |
|               Hyperlinq_For | 1000 |    10 |     48.020 ns |  0.1184 ns |  0.1050 ns |   6.20 |    0.02 |      - |     - |     - |         - |
|                             |      |       |               |            |            |        |         |        |       |       |           |
|                     **ForLoop** | **1000** |  **1000** |    **781.211 ns** |  **2.5523 ns** |  **2.2626 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop | 1000 |  1000 |  6,989.920 ns | 20.5137 ns | 16.0157 ns |   8.95 |    0.03 | 0.0153 |     - |     - |      40 B |
|                        Linq | 1000 |  1000 |  8,697.015 ns | 30.8236 ns | 28.8324 ns |  11.13 |    0.06 | 0.0610 |     - |     - |     152 B |
|                  LinqFaster | 1000 |  1000 |  7,320.378 ns | 28.3788 ns | 25.1571 ns |   9.37 |    0.04 | 5.8136 |     - |     - |  12,168 B |
|                      LinqAF | 1000 |  1000 | 14,930.346 ns | 16.3879 ns | 15.3292 ns |  19.11 |    0.06 |      - |     - |     - |         - |
|                  StructLinq | 1000 |  1000 |  1,923.349 ns |  9.7211 ns |  8.1175 ns |   2.46 |    0.01 | 0.0458 |     - |     - |      96 B |
|        StructLinq_IFunction | 1000 |  1000 |  1,399.251 ns |  4.3265 ns |  3.8354 ns |   1.79 |    0.01 |      - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |  1000 |  2,119.728 ns |  5.7440 ns |  5.3730 ns |   2.71 |    0.01 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |  1000 |  1,496.927 ns |  2.4320 ns |  2.1559 ns |   1.92 |    0.01 |      - |     - |     - |         - |
|               Hyperlinq_For | 1000 |  1000 |  2,102.602 ns |  5.6237 ns |  4.9853 ns |   2.69 |    0.01 |      - |     - |     - |         - |
