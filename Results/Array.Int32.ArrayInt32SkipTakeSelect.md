## Array.Int32.ArrayInt32SkipTakeSelect

### Source
[ArrayInt32SkipTakeSelect.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SkipTakeSelect.cs)

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
|                      Method | Skip | Count |           Mean |       Error |        StdDev |  Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |----- |------ |---------------:|------------:|--------------:|-------:|--------:|-------:|------:|------:|----------:|
|                     **ForLoop** | **1000** |     **0** |      **0.6248 ns** |   **0.1017 ns** |     **0.3000 ns** |      **?** |       **?** |      **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop | 1000 |     0 |  4,405.6253 ns | 110.5236 ns |   320.6489 ns |      ? |       ? | 0.0153 |     - |     - |      32 B |
|                        Linq | 1000 |     0 |     70.3764 ns |   1.0345 ns |     0.9170 ns |      ? |       ? | 0.0229 |     - |     - |      48 B |
|                  LinqFaster | 1000 |     0 |     37.9660 ns |   0.3730 ns |     0.3489 ns |      ? |       ? | 0.0344 |     - |     - |      72 B |
|                      LinqAF | 1000 |     0 |     95.8378 ns |   1.2810 ns |     2.3744 ns |      ? |       ? |      - |     - |     - |         - |
|                  StructLinq | 1000 |     0 |     56.2680 ns |   0.2757 ns |     0.2579 ns |      ? |       ? | 0.0459 |     - |     - |      96 B |
|        StructLinq_IFunction | 1000 |     0 |     19.2465 ns |   0.0504 ns |     0.0471 ns |      ? |       ? |      - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |     0 |     27.3011 ns |   0.3606 ns |     0.3197 ns |      ? |       ? |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |     0 |     20.0857 ns |   0.1288 ns |     0.1141 ns |      ? |       ? |      - |     - |     - |         - |
|               Hyperlinq_For | 1000 |     0 |     13.2543 ns |   0.3321 ns |     0.3691 ns |      ? |       ? |      - |     - |     - |         - |
|     Hyperlinq_For_IFunction | 1000 |     0 |      6.8882 ns |   0.0294 ns |     0.0261 ns |      ? |       ? |      - |     - |     - |         - |
|                             |      |       |                |             |               |        |         |        |       |       |           |
|                     **ForLoop** | **1000** |    **10** |      **5.7407 ns** |   **0.1807 ns** |     **0.3525 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop | 1000 |    10 |  4,478.2535 ns | 114.6871 ns |   338.1574 ns | 780.11 |   65.97 | 0.0153 |     - |     - |      32 B |
|                        Linq | 1000 |    10 |    256.4387 ns |   5.0487 ns |     7.4003 ns |  44.66 |    3.53 | 0.0725 |     - |     - |     152 B |
|                  LinqFaster | 1000 |    10 |     67.0669 ns |   0.8921 ns |     0.8345 ns |  11.51 |    0.81 | 0.0918 |     - |     - |     192 B |
|                      LinqAF | 1000 |    10 |  2,198.7224 ns |  15.0015 ns |    14.0324 ns | 377.61 |   29.08 |      - |     - |     - |         - |
|                  StructLinq | 1000 |    10 |     85.6406 ns |   1.0596 ns |     0.9912 ns |  14.70 |    1.04 | 0.0459 |     - |     - |      96 B |
|        StructLinq_IFunction | 1000 |    10 |     35.7150 ns |   0.1159 ns |     0.1027 ns |   6.16 |    0.47 |      - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |    10 |     73.4869 ns |   1.5913 ns |     4.6167 ns |  12.87 |    1.15 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |    10 |     33.0716 ns |   0.1534 ns |     0.1435 ns |   5.68 |    0.43 |      - |     - |     - |         - |
|               Hyperlinq_For | 1000 |    10 |     62.8765 ns |   1.6873 ns |     4.9750 ns |  10.92 |    1.06 |      - |     - |     - |         - |
|     Hyperlinq_For_IFunction | 1000 |    10 |     15.3233 ns |   0.0512 ns |     0.0453 ns |   2.64 |    0.20 |      - |     - |     - |         - |
|                             |      |       |                |             |               |        |         |        |       |       |           |
|                     **ForLoop** | **1000** |  **1000** |    **480.8603 ns** |   **3.9066 ns** |     **3.6542 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop | 1000 |  1000 |  8,891.8434 ns | 270.5325 ns |   797.6713 ns |  18.76 |    2.01 | 0.0153 |     - |     - |      32 B |
|                        Linq | 1000 |  1000 | 18,687.7977 ns | 470.0643 ns | 1,385.9951 ns |  38.55 |    3.21 | 0.0610 |     - |     - |     152 B |
|                  LinqFaster | 1000 |  1000 |  3,363.5487 ns |   8.8857 ns |     7.8770 ns |   6.99 |    0.05 | 5.7678 |     - |     - |   12072 B |
|                      LinqAF | 1000 |  1000 | 27,192.8856 ns | 646.0328 ns | 1,904.8424 ns |  55.38 |    4.22 |      - |     - |     - |         - |
|                  StructLinq | 1000 |  1000 |  4,428.4228 ns | 114.1098 ns |   334.6644 ns |   9.29 |    0.68 | 0.0458 |     - |     - |      96 B |
|        StructLinq_IFunction | 1000 |  1000 |  1,563.5696 ns |   5.0891 ns |     4.5114 ns |   3.25 |    0.03 |      - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |  1000 |  4,689.2575 ns | 130.3662 ns |   380.2845 ns |   9.88 |    0.71 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |  1000 |  1,416.4388 ns |   3.3543 ns |     3.1376 ns |   2.95 |    0.02 |      - |     - |     - |         - |
|               Hyperlinq_For | 1000 |  1000 |  4,966.8038 ns | 141.2779 ns |   416.5612 ns |  10.31 |    0.73 |      - |     - |     - |         - |
|     Hyperlinq_For_IFunction | 1000 |  1000 |    786.9167 ns |   2.1481 ns |     1.9042 ns |   1.64 |    0.01 |      - |     - |     - |         - |
