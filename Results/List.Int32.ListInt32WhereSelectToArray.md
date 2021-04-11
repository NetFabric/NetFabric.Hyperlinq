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
  .NET 6.0 : .NET 6.0.0 (6.0.21.20104), X64 RyuJIT


```
|                                        Method |      Job |  Runtime | Count |         Mean |      Error |     StdDev |       Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------------------------- |--------- |--------- |------ |-------------:|-----------:|-----------:|-------------:|------:|--------:|-------:|------:|------:|----------:|
|                            **ValueLinq_Standard** | **.NET 5.0** | **.NET 5.0** |    **10** |    **190.78 ns** |   **2.259 ns** |   **2.002 ns** |    **191.19 ns** |  **4.49** |    **0.04** | **0.0150** |     **-** |     **-** |      **32 B** |
|                               ValueLinq_Stack | .NET 5.0 | .NET 5.0 |    10 |    150.59 ns |   0.655 ns |   0.581 ns |    150.58 ns |  3.54 |    0.03 | 0.0153 |     - |     - |      32 B |
|                     ValueLinq_SharedPool_Push | .NET 5.0 | .NET 5.0 |    10 |    365.70 ns |   2.651 ns |   2.350 ns |    365.99 ns |  8.61 |    0.09 | 0.0153 |     - |     - |      32 B |
|                     ValueLinq_SharedPool_Pull | .NET 5.0 | .NET 5.0 |    10 |    282.11 ns |   2.953 ns |   2.618 ns |    281.55 ns |  6.64 |    0.06 | 0.0153 |     - |     - |      32 B |
|                ValueLinq_ValueLambda_Standard | .NET 5.0 | .NET 5.0 |    10 |    163.91 ns |   0.446 ns |   0.396 ns |    163.92 ns |  3.86 |    0.03 | 0.0153 |     - |     - |      32 B |
|                   ValueLinq_ValueLambda_Stack | .NET 5.0 | .NET 5.0 |    10 |    128.43 ns |   0.404 ns |   0.378 ns |    128.51 ns |  3.02 |    0.02 | 0.0150 |     - |     - |      32 B |
|         ValueLinq_ValueLambda_SharedPool_Push | .NET 5.0 | .NET 5.0 |    10 |    293.70 ns |   0.589 ns |   0.551 ns |    293.70 ns |  6.91 |    0.04 | 0.0153 |     - |     - |      32 B |
|         ValueLinq_ValueLambda_SharedPool_Pull | .NET 5.0 | .NET 5.0 |    10 |    272.19 ns |   2.804 ns |   2.485 ns |    271.31 ns |  6.41 |    0.06 | 0.0153 |     - |     - |      32 B |
|                    ValueLinq_Standard_ByIndex | .NET 5.0 | .NET 5.0 |    10 |    162.05 ns |   0.550 ns |   0.514 ns |    162.07 ns |  3.81 |    0.02 | 0.0150 |     - |     - |      32 B |
|                       ValueLinq_Stack_ByIndex | .NET 5.0 | .NET 5.0 |    10 |    126.65 ns |   0.706 ns |   0.626 ns |    126.60 ns |  2.98 |    0.03 | 0.0150 |     - |     - |      32 B |
|             ValueLinq_SharedPool_Push_ByIndex | .NET 5.0 | .NET 5.0 |    10 |    377.83 ns |   1.446 ns |   1.282 ns |    377.83 ns |  8.89 |    0.07 | 0.0153 |     - |     - |      32 B |
|             ValueLinq_SharedPool_Pull_ByIndex | .NET 5.0 | .NET 5.0 |    10 |    269.18 ns |   0.717 ns |   0.670 ns |    269.09 ns |  6.33 |    0.04 | 0.0153 |     - |     - |      32 B |
|        ValueLinq_ValueLambda_Standard_ByIndex | .NET 5.0 | .NET 5.0 |    10 |    150.61 ns |   0.485 ns |   0.454 ns |    150.62 ns |  3.54 |    0.03 | 0.0153 |     - |     - |      32 B |
|           ValueLinq_ValueLambda_Stack_ByIndex | .NET 5.0 | .NET 5.0 |    10 |    118.89 ns |   1.958 ns |   1.831 ns |    119.33 ns |  2.80 |    0.04 | 0.0151 |     - |     - |      32 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex | .NET 5.0 | .NET 5.0 |    10 |    299.09 ns |   1.252 ns |   1.110 ns |    298.98 ns |  7.04 |    0.04 | 0.0153 |     - |     - |      32 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex | .NET 5.0 | .NET 5.0 |    10 |    245.29 ns |   1.075 ns |   1.006 ns |    244.98 ns |  5.77 |    0.04 | 0.0153 |     - |     - |      32 B |
|                                       ForLoop | .NET 5.0 | .NET 5.0 |    10 |     42.49 ns |   0.303 ns |   0.269 ns |     42.45 ns |  1.00 |    0.00 | 0.0497 |     - |     - |     104 B |
|                                   ForeachLoop | .NET 5.0 | .NET 5.0 |    10 |     64.24 ns |   0.534 ns |   0.500 ns |     64.05 ns |  1.51 |    0.02 | 0.0496 |     - |     - |     104 B |
|                                          Linq | .NET 5.0 | .NET 5.0 |    10 |    131.76 ns |   0.634 ns |   0.562 ns |    131.76 ns |  3.10 |    0.02 | 0.1070 |     - |     - |     224 B |
|                                    LinqFaster | .NET 5.0 | .NET 5.0 |    10 |     59.36 ns |   0.404 ns |   0.378 ns |     59.29 ns |  1.40 |    0.01 | 0.0496 |     - |     - |     104 B |
|                                        LinqAF | .NET 5.0 | .NET 5.0 |    10 |    181.18 ns |   1.008 ns |   0.943 ns |    180.95 ns |  4.26 |    0.04 | 0.0343 |     - |     - |      72 B |
|                                    StructLinq | .NET 5.0 | .NET 5.0 |    10 |    133.14 ns |   0.599 ns |   0.560 ns |    133.13 ns |  3.13 |    0.02 | 0.0610 |     - |     - |     128 B |
|                          StructLinq_IFunction | .NET 5.0 | .NET 5.0 |    10 |     89.37 ns |   0.417 ns |   0.348 ns |     89.32 ns |  2.10 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                     Hyperlinq | .NET 5.0 | .NET 5.0 |    10 |    112.93 ns |   1.801 ns |   1.597 ns |    113.47 ns |  2.66 |    0.03 | 0.0153 |     - |     - |      32 B |
|                           Hyperlinq_IFunction | .NET 5.0 | .NET 5.0 |    10 |     83.07 ns |   0.336 ns |   0.281 ns |     83.03 ns |  1.95 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                               |          |          |       |              |            |            |              |       |         |        |       |       |           |
|                            ValueLinq_Standard | .NET 6.0 | .NET 6.0 |    10 |    188.73 ns |   1.068 ns |   0.946 ns |    188.67 ns |  4.23 |    0.12 | 0.0150 |     - |     - |      32 B |
|                               ValueLinq_Stack | .NET 6.0 | .NET 6.0 |    10 |    144.55 ns |   0.457 ns |   0.382 ns |    144.56 ns |  3.24 |    0.08 | 0.0150 |     - |     - |      32 B |
|                     ValueLinq_SharedPool_Push | .NET 6.0 | .NET 6.0 |    10 |    352.70 ns |   1.038 ns |   0.867 ns |    352.97 ns |  7.90 |    0.21 | 0.0153 |     - |     - |      32 B |
|                     ValueLinq_SharedPool_Pull | .NET 6.0 | .NET 6.0 |    10 |    280.82 ns |   1.278 ns |   1.132 ns |    280.66 ns |  6.29 |    0.17 | 0.0153 |     - |     - |      32 B |
|                ValueLinq_ValueLambda_Standard | .NET 6.0 | .NET 6.0 |    10 |    164.61 ns |   1.214 ns |   1.076 ns |    164.91 ns |  3.69 |    0.07 | 0.0150 |     - |     - |      32 B |
|                   ValueLinq_ValueLambda_Stack | .NET 6.0 | .NET 6.0 |    10 |    131.59 ns |   0.704 ns |   0.550 ns |    131.71 ns |  2.95 |    0.08 | 0.0150 |     - |     - |      32 B |
|         ValueLinq_ValueLambda_SharedPool_Push | .NET 6.0 | .NET 6.0 |    10 |    287.01 ns |   1.127 ns |   1.054 ns |    287.12 ns |  6.43 |    0.16 | 0.0153 |     - |     - |      32 B |
|         ValueLinq_ValueLambda_SharedPool_Pull | .NET 6.0 | .NET 6.0 |    10 |    267.39 ns |   1.298 ns |   1.084 ns |    267.35 ns |  5.99 |    0.17 | 0.0153 |     - |     - |      32 B |
|                    ValueLinq_Standard_ByIndex | .NET 6.0 | .NET 6.0 |    10 |    164.45 ns |   0.665 ns |   0.589 ns |    164.71 ns |  3.68 |    0.09 | 0.0150 |     - |     - |      32 B |
|                       ValueLinq_Stack_ByIndex | .NET 6.0 | .NET 6.0 |    10 |    123.37 ns |   0.605 ns |   0.537 ns |    123.38 ns |  2.76 |    0.08 | 0.0150 |     - |     - |      32 B |
|             ValueLinq_SharedPool_Push_ByIndex | .NET 6.0 | .NET 6.0 |    10 |    368.78 ns |   1.603 ns |   1.338 ns |    368.84 ns |  8.26 |    0.20 | 0.0153 |     - |     - |      32 B |
|             ValueLinq_SharedPool_Pull_ByIndex | .NET 6.0 | .NET 6.0 |    10 |    255.88 ns |   1.478 ns |   1.382 ns |    255.84 ns |  5.73 |    0.15 | 0.0153 |     - |     - |      32 B |
|        ValueLinq_ValueLambda_Standard_ByIndex | .NET 6.0 | .NET 6.0 |    10 |    155.46 ns |   1.692 ns |   1.413 ns |    156.04 ns |  3.48 |    0.08 | 0.0150 |     - |     - |      32 B |
|           ValueLinq_ValueLambda_Stack_ByIndex | .NET 6.0 | .NET 6.0 |    10 |    114.97 ns |   2.385 ns |   2.449 ns |    115.87 ns |  2.57 |    0.09 | 0.0150 |     - |     - |      32 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex | .NET 6.0 | .NET 6.0 |    10 |    292.68 ns |   0.847 ns |   0.707 ns |    292.67 ns |  6.56 |    0.17 | 0.0153 |     - |     - |      32 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex | .NET 6.0 | .NET 6.0 |    10 |    245.73 ns |   1.525 ns |   1.426 ns |    245.17 ns |  5.50 |    0.13 | 0.0153 |     - |     - |      32 B |
|                                       ForLoop | .NET 6.0 | .NET 6.0 |    10 |     44.72 ns |   0.932 ns |   0.957 ns |     44.85 ns |  1.00 |    0.00 | 0.0497 |     - |     - |     104 B |
|                                   ForeachLoop | .NET 6.0 | .NET 6.0 |    10 |     43.83 ns |   0.254 ns |   0.225 ns |     43.84 ns |  0.98 |    0.02 | 0.0497 |     - |     - |     104 B |
|                                          Linq | .NET 6.0 | .NET 6.0 |    10 |    126.99 ns |   2.598 ns |   4.121 ns |    128.56 ns |  2.80 |    0.10 | 0.1068 |     - |     - |     224 B |
|                                    LinqFaster | .NET 6.0 | .NET 6.0 |    10 |     56.33 ns |   0.296 ns |   0.262 ns |     56.37 ns |  1.26 |    0.03 | 0.0496 |     - |     - |     104 B |
|                                        LinqAF | .NET 6.0 | .NET 6.0 |    10 |    161.64 ns |   0.554 ns |   0.462 ns |    161.67 ns |  3.62 |    0.10 | 0.0341 |     - |     - |      72 B |
|                                    StructLinq | .NET 6.0 | .NET 6.0 |    10 |    151.89 ns |   0.795 ns |   0.704 ns |    151.79 ns |  3.40 |    0.09 | 0.0610 |     - |     - |     128 B |
|                          StructLinq_IFunction | .NET 6.0 | .NET 6.0 |    10 |     88.89 ns |   0.397 ns |   0.352 ns |     88.83 ns |  1.99 |    0.05 | 0.0153 |     - |     - |      32 B |
|                                     Hyperlinq | .NET 6.0 | .NET 6.0 |    10 |    112.95 ns |   1.691 ns |   1.499 ns |    113.36 ns |  2.53 |    0.07 | 0.0153 |     - |     - |      32 B |
|                           Hyperlinq_IFunction | .NET 6.0 | .NET 6.0 |    10 |     81.78 ns |   0.268 ns |   0.209 ns |     81.78 ns |  1.83 |    0.05 | 0.0153 |     - |     - |      32 B |
|                                               |          |          |       |              |            |            |              |       |         |        |       |       |           |
|                            **ValueLinq_Standard** | **.NET 5.0** | **.NET 5.0** |  **1000** |  **7,902.75 ns** |  **26.454 ns** |  **23.451 ns** |  **7,910.71 ns** |  **2.37** |    **0.02** | **1.9684** |     **-** |     **-** |   **4,144 B** |
|                               ValueLinq_Stack | .NET 5.0 | .NET 5.0 |  1000 |  8,013.98 ns |  29.736 ns |  24.831 ns |  8,014.71 ns |  2.41 |    0.01 | 1.9760 |     - |     - |   4,144 B |
|                     ValueLinq_SharedPool_Push | .NET 5.0 | .NET 5.0 |  1000 |  5,466.16 ns |  23.376 ns |  20.722 ns |  5,468.24 ns |  1.64 |    0.01 | 0.9689 |     - |     - |   2,040 B |
|                     ValueLinq_SharedPool_Pull | .NET 5.0 | .NET 5.0 |  1000 |  7,323.39 ns |  20.247 ns |  16.907 ns |  7,322.90 ns |  2.20 |    0.01 | 0.9689 |     - |     - |   2,040 B |
|                ValueLinq_ValueLambda_Standard | .NET 5.0 | .NET 5.0 |  1000 |  7,745.95 ns |  34.678 ns |  32.438 ns |  7,747.86 ns |  2.33 |    0.02 | 1.9684 |     - |     - |   4,144 B |
|                   ValueLinq_ValueLambda_Stack | .NET 5.0 | .NET 5.0 |  1000 |  7,723.40 ns |  29.049 ns |  24.257 ns |  7,719.26 ns |  2.32 |    0.01 | 1.9684 |     - |     - |   4,144 B |
|         ValueLinq_ValueLambda_SharedPool_Push | .NET 5.0 | .NET 5.0 |  1000 |  3,794.49 ns |  11.783 ns |  10.445 ns |  3,791.92 ns |  1.14 |    0.01 | 0.9727 |     - |     - |   2,040 B |
|         ValueLinq_ValueLambda_SharedPool_Pull | .NET 5.0 | .NET 5.0 |  1000 |  8,173.95 ns | 139.622 ns | 130.602 ns |  8,149.70 ns |  2.45 |    0.04 | 0.9613 |     - |     - |   2,040 B |
|                    ValueLinq_Standard_ByIndex | .NET 5.0 | .NET 5.0 |  1000 |  6,676.94 ns | 133.153 ns | 199.297 ns |  6,571.34 ns |  2.04 |    0.07 | 1.9760 |     - |     - |   4,144 B |
|                       ValueLinq_Stack_ByIndex | .NET 5.0 | .NET 5.0 |  1000 |  7,219.20 ns |  40.983 ns |  34.223 ns |  7,207.72 ns |  2.17 |    0.02 | 1.9760 |     - |     - |   4,144 B |
|             ValueLinq_SharedPool_Push_ByIndex | .NET 5.0 | .NET 5.0 |  1000 |  5,306.12 ns |  25.437 ns |  21.241 ns |  5,318.44 ns |  1.59 |    0.01 | 0.9689 |     - |     - |   2,040 B |
|             ValueLinq_SharedPool_Pull_ByIndex | .NET 5.0 | .NET 5.0 |  1000 |  6,269.41 ns |  24.845 ns |  22.025 ns |  6,265.43 ns |  1.88 |    0.01 | 0.9689 |     - |     - |   2,040 B |
|        ValueLinq_ValueLambda_Standard_ByIndex | .NET 5.0 | .NET 5.0 |  1000 |  2,747.86 ns |  52.301 ns |  55.961 ns |  2,753.58 ns |  0.83 |    0.02 | 1.9798 |     - |     - |   4,144 B |
|           ValueLinq_ValueLambda_Stack_ByIndex | .NET 5.0 | .NET 5.0 |  1000 |  2,445.01 ns |  20.422 ns |  15.945 ns |  2,444.93 ns |  0.73 |    0.01 | 1.9798 |     - |     - |   4,144 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex | .NET 5.0 | .NET 5.0 |  1000 |  3,804.94 ns |  12.712 ns |  11.891 ns |  3,806.58 ns |  1.14 |    0.01 | 0.9689 |     - |     - |   2,040 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex | .NET 5.0 | .NET 5.0 |  1000 |  2,721.46 ns |  13.595 ns |  12.052 ns |  2,725.51 ns |  0.82 |    0.01 | 0.9727 |     - |     - |   2,040 B |
|                                       ForLoop | .NET 5.0 | .NET 5.0 |  1000 |  3,328.66 ns |  17.582 ns |  15.586 ns |  3,331.76 ns |  1.00 |    0.00 | 3.0289 |     - |     - |   6,344 B |
|                                   ForeachLoop | .NET 5.0 | .NET 5.0 |  1000 |  5,129.16 ns |  97.829 ns | 116.459 ns |  5,171.63 ns |  1.53 |    0.04 | 3.0289 |     - |     - |   6,344 B |
|                                          Linq | .NET 5.0 | .NET 5.0 |  1000 |  5,690.67 ns |  39.564 ns |  35.073 ns |  5,679.70 ns |  1.71 |    0.01 | 2.1896 |     - |     - |   4,592 B |
|                                    LinqFaster | .NET 5.0 | .NET 5.0 |  1000 |  5,841.98 ns |  13.681 ns |  12.128 ns |  5,841.62 ns |  1.76 |    0.01 | 3.0289 |     - |     - |   6,344 B |
|                                        LinqAF | .NET 5.0 | .NET 5.0 |  1000 | 13,288.03 ns |  32.962 ns |  29.220 ns | 13,282.10 ns |  3.99 |    0.02 | 3.0060 |     - |     - |   6,312 B |
|                                    StructLinq | .NET 5.0 | .NET 5.0 |  1000 |  5,619.85 ns |  46.074 ns |  38.474 ns |  5,623.98 ns |  1.69 |    0.01 | 1.0147 |     - |     - |   2,136 B |
|                          StructLinq_IFunction | .NET 5.0 | .NET 5.0 |  1000 |  2,945.93 ns |  12.425 ns |  11.622 ns |  2,944.06 ns |  0.88 |    0.00 | 0.9727 |     - |     - |   2,040 B |
|                                     Hyperlinq | .NET 5.0 | .NET 5.0 |  1000 |  5,599.39 ns |  15.139 ns |  12.642 ns |  5,599.86 ns |  1.68 |    0.01 | 0.9689 |     - |     - |   2,040 B |
|                           Hyperlinq_IFunction | .NET 5.0 | .NET 5.0 |  1000 |  3,518.85 ns |  25.464 ns |  23.819 ns |  3,511.62 ns |  1.06 |    0.01 | 0.9727 |     - |     - |   2,040 B |
|                                               |          |          |       |              |            |            |              |       |         |        |       |       |           |
|                            ValueLinq_Standard | .NET 6.0 | .NET 6.0 |  1000 |  7,508.04 ns |  23.601 ns |  20.921 ns |  7,506.29 ns |  2.44 |    0.01 | 1.9760 |     - |     - |   4,144 B |
|                               ValueLinq_Stack | .NET 6.0 | .NET 6.0 |  1000 |  7,772.56 ns | 154.581 ns | 221.696 ns |  7,623.73 ns |  2.60 |    0.04 | 1.9760 |     - |     - |   4,144 B |
|                     ValueLinq_SharedPool_Push | .NET 6.0 | .NET 6.0 |  1000 |  5,519.66 ns |  20.960 ns |  19.606 ns |  5,522.78 ns |  1.80 |    0.01 | 0.9689 |     - |     - |   2,040 B |
|                     ValueLinq_SharedPool_Pull | .NET 6.0 | .NET 6.0 |  1000 |  8,047.23 ns | 160.131 ns | 149.787 ns |  8,103.02 ns |  2.61 |    0.05 | 0.9613 |     - |     - |   2,040 B |
|                ValueLinq_ValueLambda_Standard | .NET 6.0 | .NET 6.0 |  1000 |  8,545.17 ns | 167.989 ns | 240.925 ns |  8,421.19 ns |  2.83 |    0.09 | 1.9684 |     - |     - |   4,144 B |
|                   ValueLinq_ValueLambda_Stack | .NET 6.0 | .NET 6.0 |  1000 |  8,024.13 ns |  28.152 ns |  26.333 ns |  8,032.60 ns |  2.61 |    0.01 | 1.9684 |     - |     - |   4,144 B |
|         ValueLinq_ValueLambda_SharedPool_Push | .NET 6.0 | .NET 6.0 |  1000 |  3,939.13 ns |  16.910 ns |  15.817 ns |  3,935.88 ns |  1.28 |    0.01 | 0.9689 |     - |     - |   2,040 B |
|         ValueLinq_ValueLambda_SharedPool_Pull | .NET 6.0 | .NET 6.0 |  1000 |  8,957.28 ns |  14.857 ns |  12.407 ns |  8,961.01 ns |  2.91 |    0.01 | 0.9613 |     - |     - |   2,040 B |
|                    ValueLinq_Standard_ByIndex | .NET 6.0 | .NET 6.0 |  1000 |  6,977.88 ns |  44.132 ns |  36.852 ns |  6,977.85 ns |  2.27 |    0.02 | 1.9760 |     - |     - |   4,144 B |
|                       ValueLinq_Stack_ByIndex | .NET 6.0 | .NET 6.0 |  1000 |  6,542.58 ns |  42.161 ns |  35.206 ns |  6,539.49 ns |  2.13 |    0.01 | 1.9760 |     - |     - |   4,144 B |
|             ValueLinq_SharedPool_Push_ByIndex | .NET 6.0 | .NET 6.0 |  1000 |  5,357.68 ns |  23.706 ns |  19.795 ns |  5,362.86 ns |  1.74 |    0.01 | 0.9689 |     - |     - |   2,040 B |
|             ValueLinq_SharedPool_Pull_ByIndex | .NET 6.0 | .NET 6.0 |  1000 |  6,673.86 ns |  36.336 ns |  33.989 ns |  6,661.24 ns |  2.17 |    0.01 | 0.9689 |     - |     - |   2,040 B |
|        ValueLinq_ValueLambda_Standard_ByIndex | .NET 6.0 | .NET 6.0 |  1000 |  2,755.75 ns |  14.307 ns |  11.947 ns |  2,754.25 ns |  0.90 |    0.01 | 1.9798 |     - |     - |   4,144 B |
|           ValueLinq_ValueLambda_Stack_ByIndex | .NET 6.0 | .NET 6.0 |  1000 |  2,705.45 ns |  12.419 ns |  11.009 ns |  2,704.15 ns |  0.88 |    0.00 | 1.9798 |     - |     - |   4,144 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex | .NET 6.0 | .NET 6.0 |  1000 |  3,788.99 ns |  37.069 ns |  34.675 ns |  3,798.64 ns |  1.23 |    0.01 | 0.9727 |     - |     - |   2,040 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex | .NET 6.0 | .NET 6.0 |  1000 |  2,839.52 ns |  39.779 ns |  37.209 ns |  2,822.77 ns |  0.92 |    0.01 | 0.9727 |     - |     - |   2,040 B |
|                                       ForLoop | .NET 6.0 | .NET 6.0 |  1000 |  3,073.74 ns |  14.766 ns |  12.330 ns |  3,076.25 ns |  1.00 |    0.00 | 3.0289 |     - |     - |   6,344 B |
|                                   ForeachLoop | .NET 6.0 | .NET 6.0 |  1000 |  2,259.77 ns |  13.461 ns |  12.591 ns |  2,258.79 ns |  0.74 |    0.00 | 3.0289 |     - |     - |   6,344 B |
|                                          Linq | .NET 6.0 | .NET 6.0 |  1000 |  6,026.81 ns |  26.578 ns |  22.194 ns |  6,027.48 ns |  1.96 |    0.01 | 2.1896 |     - |     - |   4,592 B |
|                                    LinqFaster | .NET 6.0 | .NET 6.0 |  1000 |  6,036.57 ns | 117.871 ns | 186.956 ns |  6,117.25 ns |  1.91 |    0.07 | 3.0289 |     - |     - |   6,344 B |
|                                        LinqAF | .NET 6.0 | .NET 6.0 |  1000 | 13,253.22 ns |  32.622 ns |  27.241 ns | 13,251.36 ns |  4.31 |    0.01 | 3.0060 |     - |     - |   6,312 B |
|                                    StructLinq | .NET 6.0 | .NET 6.0 |  1000 |  5,648.88 ns |  28.792 ns |  26.932 ns |  5,645.39 ns |  1.84 |    0.01 | 1.0147 |     - |     - |   2,136 B |
|                          StructLinq_IFunction | .NET 6.0 | .NET 6.0 |  1000 |  2,928.80 ns |  11.852 ns |  11.087 ns |  2,929.45 ns |  0.95 |    0.00 | 0.9727 |     - |     - |   2,040 B |
|                                     Hyperlinq | .NET 6.0 | .NET 6.0 |  1000 |  5,072.43 ns |  45.572 ns |  40.399 ns |  5,059.57 ns |  1.65 |    0.02 | 0.9689 |     - |     - |   2,040 B |
|                           Hyperlinq_IFunction | .NET 6.0 | .NET 6.0 |  1000 |  2,497.38 ns |  46.572 ns |  72.507 ns |  2,532.23 ns |  0.79 |    0.03 | 0.9727 |     - |     - |   2,040 B |
