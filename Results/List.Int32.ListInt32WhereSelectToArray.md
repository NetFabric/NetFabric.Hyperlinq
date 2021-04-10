## List.Int32.ListInt32WhereSelectToArray

### Source
[ListInt32WhereSelectToArray.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelectToArray.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1527-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.3.21202.5
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|                                        Method | Count |         Mean |      Error |     StdDev |       Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------------------------- |------ |-------------:|-----------:|-----------:|-------------:|------:|--------:|-------:|------:|------:|----------:|
|                            **ValueLinq_Standard** |    **10** |    **195.30 ns** |   **3.468 ns** |   **3.710 ns** |    **193.30 ns** |  **4.85** |    **0.11** | **0.0153** |     **-** |     **-** |      **32 B** |
|                               ValueLinq_Stack |    10 |    145.82 ns |   0.614 ns |   0.513 ns |    145.91 ns |  3.61 |    0.03 | 0.0153 |     - |     - |      32 B |
|                     ValueLinq_SharedPool_Push |    10 |    380.55 ns |   5.751 ns |   5.099 ns |    379.75 ns |  9.40 |    0.14 | 0.0153 |     - |     - |      32 B |
|                     ValueLinq_SharedPool_Pull |    10 |    297.62 ns |   3.328 ns |   3.113 ns |    297.21 ns |  7.36 |    0.11 | 0.0153 |     - |     - |      32 B |
|                ValueLinq_ValueLambda_Standard |    10 |    178.72 ns |   1.207 ns |   1.070 ns |    178.55 ns |  4.42 |    0.03 | 0.0150 |     - |     - |      32 B |
|                   ValueLinq_ValueLambda_Stack |    10 |    132.49 ns |   0.620 ns |   0.549 ns |    132.39 ns |  3.28 |    0.02 | 0.0150 |     - |     - |      32 B |
|         ValueLinq_ValueLambda_SharedPool_Push |    10 |    296.72 ns |   1.807 ns |   1.691 ns |    296.86 ns |  7.34 |    0.06 | 0.0153 |     - |     - |      32 B |
|         ValueLinq_ValueLambda_SharedPool_Pull |    10 |    292.77 ns |   2.373 ns |   2.104 ns |    293.16 ns |  7.24 |    0.06 | 0.0153 |     - |     - |      32 B |
|                    ValueLinq_Standard_ByIndex |    10 |    167.74 ns |   2.924 ns |   2.735 ns |    166.44 ns |  4.16 |    0.07 | 0.0150 |     - |     - |      32 B |
|                       ValueLinq_Stack_ByIndex |    10 |    129.94 ns |   0.638 ns |   0.597 ns |    129.76 ns |  3.21 |    0.02 | 0.0153 |     - |     - |      32 B |
|             ValueLinq_SharedPool_Push_ByIndex |    10 |    394.39 ns |   2.574 ns |   2.408 ns |    394.90 ns |  9.75 |    0.09 | 0.0153 |     - |     - |      32 B |
|             ValueLinq_SharedPool_Pull_ByIndex |    10 |    267.41 ns |   1.635 ns |   1.365 ns |    267.43 ns |  6.61 |    0.06 | 0.0153 |     - |     - |      32 B |
|        ValueLinq_ValueLambda_Standard_ByIndex |    10 |    151.03 ns |   0.664 ns |   0.621 ns |    150.86 ns |  3.74 |    0.03 | 0.0150 |     - |     - |      32 B |
|           ValueLinq_ValueLambda_Stack_ByIndex |    10 |    117.38 ns |   0.466 ns |   0.436 ns |    117.48 ns |  2.90 |    0.02 | 0.0153 |     - |     - |      32 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |    10 |    308.54 ns |   1.334 ns |   1.183 ns |    308.76 ns |  7.63 |    0.06 | 0.0153 |     - |     - |      32 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |    10 |    251.75 ns |   1.533 ns |   1.434 ns |    251.42 ns |  6.23 |    0.06 | 0.0153 |     - |     - |      32 B |
|                                       ForLoop |    10 |     40.43 ns |   0.330 ns |   0.275 ns |     40.48 ns |  1.00 |    0.00 | 0.0497 |     - |     - |     104 B |
|                                   ForeachLoop |    10 |     66.72 ns |   0.740 ns |   0.692 ns |     66.68 ns |  1.65 |    0.02 | 0.0497 |     - |     - |     104 B |
|                                          Linq |    10 |    130.09 ns |   0.670 ns |   0.594 ns |    130.12 ns |  3.22 |    0.03 | 0.1068 |     - |     - |     224 B |
|                                    LinqFaster |    10 |     57.83 ns |   0.327 ns |   0.273 ns |     57.85 ns |  1.43 |    0.01 | 0.0496 |     - |     - |     104 B |
|                                        LinqAF |    10 |    172.80 ns |   0.958 ns |   0.800 ns |    172.75 ns |  4.27 |    0.04 | 0.0341 |     - |     - |      72 B |
|                                    StructLinq |    10 |    145.19 ns |   0.665 ns |   0.555 ns |    145.09 ns |  3.59 |    0.03 | 0.0610 |     - |     - |     128 B |
|                          StructLinq_IFunction |    10 |     91.52 ns |   0.483 ns |   0.377 ns |     91.59 ns |  2.26 |    0.02 | 0.0153 |     - |     - |      32 B |
|                                     Hyperlinq |    10 |    114.80 ns |   0.515 ns |   0.456 ns |    114.80 ns |  2.84 |    0.02 | 0.0153 |     - |     - |      32 B |
|                           Hyperlinq_IFunction |    10 |     92.63 ns |   1.834 ns |   1.963 ns |     93.30 ns |  2.28 |    0.05 | 0.0153 |     - |     - |      32 B |
|                                               |       |              |            |            |              |       |         |        |       |       |           |
|                            **ValueLinq_Standard** |  **1000** |  **7,662.83 ns** | **136.488 ns** | **242.607 ns** |  **7,536.54 ns** |  **2.26** |    **0.07** | **1.9684** |     **-** |     **-** |   **4,144 B** |
|                               ValueLinq_Stack |  1000 |  8,237.95 ns |  58.855 ns |  55.053 ns |  8,230.14 ns |  2.37 |    0.02 | 1.9684 |     - |     - |   4,144 B |
|                     ValueLinq_SharedPool_Push |  1000 |  5,870.25 ns | 114.903 ns | 171.981 ns |  5,929.97 ns |  1.66 |    0.06 | 0.9689 |     - |     - |   2,040 B |
|                     ValueLinq_SharedPool_Pull |  1000 |  7,592.97 ns |  59.444 ns |  52.695 ns |  7,593.49 ns |  2.18 |    0.01 | 0.9613 |     - |     - |   2,040 B |
|                ValueLinq_ValueLambda_Standard |  1000 |  7,681.00 ns |  35.191 ns |  31.196 ns |  7,677.83 ns |  2.21 |    0.02 | 1.9684 |     - |     - |   4,144 B |
|                   ValueLinq_ValueLambda_Stack |  1000 |  8,358.61 ns |  54.199 ns |  48.046 ns |  8,352.07 ns |  2.40 |    0.02 | 1.9684 |     - |     - |   4,144 B |
|         ValueLinq_ValueLambda_SharedPool_Push |  1000 |  4,136.42 ns |  81.312 ns | 102.833 ns |  4,179.84 ns |  1.18 |    0.04 | 0.9689 |     - |     - |   2,040 B |
|         ValueLinq_ValueLambda_SharedPool_Pull |  1000 |  8,335.73 ns | 159.574 ns | 189.962 ns |  8,238.57 ns |  2.41 |    0.05 | 0.9613 |     - |     - |   2,040 B |
|                    ValueLinq_Standard_ByIndex |  1000 |  7,048.79 ns | 140.278 ns | 252.950 ns |  7,122.33 ns |  1.99 |    0.06 | 1.9760 |     - |     - |   4,144 B |
|                       ValueLinq_Stack_ByIndex |  1000 |  6,167.78 ns |  42.351 ns |  37.543 ns |  6,169.51 ns |  1.77 |    0.01 | 1.9760 |     - |     - |   4,144 B |
|             ValueLinq_SharedPool_Push_ByIndex |  1000 |  5,497.00 ns |  26.675 ns |  24.951 ns |  5,495.68 ns |  1.58 |    0.01 | 0.9689 |     - |     - |   2,040 B |
|             ValueLinq_SharedPool_Pull_ByIndex |  1000 |  6,714.73 ns | 128.066 ns | 142.345 ns |  6,766.83 ns |  1.92 |    0.05 | 0.9689 |     - |     - |   2,040 B |
|        ValueLinq_ValueLambda_Standard_ByIndex |  1000 |  2,578.62 ns |  19.057 ns |  17.826 ns |  2,578.23 ns |  0.74 |    0.01 | 1.9798 |     - |     - |   4,144 B |
|           ValueLinq_ValueLambda_Stack_ByIndex |  1000 |  2,555.62 ns |  36.166 ns |  32.061 ns |  2,567.75 ns |  0.73 |    0.01 | 1.9798 |     - |     - |   4,144 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |  1000 |  3,941.37 ns |  35.188 ns |  29.383 ns |  3,932.92 ns |  1.13 |    0.01 | 0.9689 |     - |     - |   2,040 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |  1000 |  2,919.54 ns |  34.988 ns |  32.728 ns |  2,912.64 ns |  0.84 |    0.01 | 0.9727 |     - |     - |   2,040 B |
|                                       ForLoop |  1000 |  3,477.78 ns |  19.874 ns |  18.590 ns |  3,478.80 ns |  1.00 |    0.00 | 3.0289 |     - |     - |   6,344 B |
|                                   ForeachLoop |  1000 |  6,004.00 ns |  37.994 ns |  29.663 ns |  5,997.77 ns |  1.72 |    0.01 | 3.0289 |     - |     - |   6,344 B |
|                                          Linq |  1000 |  6,148.26 ns | 115.583 ns | 137.593 ns |  6,109.31 ns |  1.77 |    0.04 | 2.1896 |     - |     - |   4,592 B |
|                                    LinqFaster |  1000 |  6,368.60 ns | 127.178 ns | 253.987 ns |  6,282.19 ns |  1.85 |    0.07 | 3.0289 |     - |     - |   6,344 B |
|                                        LinqAF |  1000 | 13,572.44 ns | 112.059 ns |  99.337 ns | 13,539.72 ns |  3.90 |    0.03 | 3.0060 |     - |     - |   6,312 B |
|                                    StructLinq |  1000 |  5,858.75 ns | 116.471 ns | 155.485 ns |  5,925.50 ns |  1.66 |    0.05 | 1.0147 |     - |     - |   2,136 B |
|                          StructLinq_IFunction |  1000 |  3,217.23 ns |  36.669 ns |  34.300 ns |  3,214.36 ns |  0.93 |    0.01 | 0.9727 |     - |     - |   2,040 B |
|                                     Hyperlinq |  1000 |  5,630.68 ns |  35.091 ns |  32.824 ns |  5,630.95 ns |  1.62 |    0.01 | 0.9689 |     - |     - |   2,040 B |
|                           Hyperlinq_IFunction |  1000 |  3,385.63 ns |  18.068 ns |  15.088 ns |  3,390.97 ns |  0.97 |    0.01 | 0.9727 |     - |     - |   2,040 B |
