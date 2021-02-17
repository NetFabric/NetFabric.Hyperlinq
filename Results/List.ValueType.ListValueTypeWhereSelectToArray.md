## List.ValueType.ListValueTypeWhereSelectToArray

### Source
[ListValueTypeWhereSelectToArray.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelectToArray.cs)

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
|                                        Method | Count |          Mean |       Error |      StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------------------------- |------ |--------------:|------------:|------------:|------:|--------:|--------:|------:|------:|----------:|
|                            **ValueLinq_Standard** |     **0** |     **57.713 ns** |   **0.1213 ns** |   **0.1135 ns** |  **9.50** |    **0.07** |       **-** |     **-** |     **-** |         **-** |
|                               ValueLinq_Stack |     0 |     90.973 ns |   0.3731 ns |   0.3308 ns | 14.98 |    0.12 |       - |     - |     - |         - |
|                     ValueLinq_SharedPool_Push |     0 |    298.103 ns |   1.1286 ns |   1.0005 ns | 49.07 |    0.30 |       - |     - |     - |         - |
|                     ValueLinq_SharedPool_Pull |     0 |    242.882 ns |   0.9354 ns |   0.8749 ns | 39.99 |    0.35 |       - |     - |     - |         - |
|                        ValueLinq_Ref_Standard |     0 |     54.023 ns |   0.0871 ns |   0.0815 ns |  8.89 |    0.06 |       - |     - |     - |         - |
|                           ValueLinq_Ref_Stack |     0 |    100.152 ns |   0.4653 ns |   0.4125 ns | 16.49 |    0.15 |       - |     - |     - |         - |
|                 ValueLinq_Ref_SharedPool_Push |     0 |    226.000 ns |   4.4856 ns |   5.8326 ns | 37.53 |    1.26 |       - |     - |     - |         - |
|                 ValueLinq_Ref_SharedPool_Pull |     0 |    243.577 ns |   0.8112 ns |   0.7191 ns | 40.10 |    0.32 |       - |     - |     - |         - |
|                ValueLinq_ValueLambda_Standard |     0 |     68.363 ns |   0.1242 ns |   0.1162 ns | 11.25 |    0.09 |       - |     - |     - |         - |
|                   ValueLinq_ValueLambda_Stack |     0 |    107.656 ns |   0.2991 ns |   0.2651 ns | 17.72 |    0.13 |       - |     - |     - |         - |
|         ValueLinq_ValueLambda_SharedPool_Push |     0 |    240.692 ns |   0.4627 ns |   0.4102 ns | 39.62 |    0.27 |       - |     - |     - |         - |
|         ValueLinq_ValueLambda_SharedPool_Pull |     0 |    253.367 ns |   1.0462 ns |   0.9786 ns | 41.72 |    0.27 |       - |     - |     - |         - |
|                    ValueLinq_Standard_ByIndex |     0 |     76.397 ns |   0.1106 ns |   0.0923 ns | 12.58 |    0.09 |       - |     - |     - |         - |
|                       ValueLinq_Stack_ByIndex |     0 |     97.614 ns |   0.1863 ns |   0.1651 ns | 16.07 |    0.12 |       - |     - |     - |         - |
|             ValueLinq_SharedPool_Push_ByIndex |     0 |    312.790 ns |   0.8069 ns |   0.7153 ns | 51.49 |    0.40 |       - |     - |     - |         - |
|             ValueLinq_SharedPool_Pull_ByIndex |     0 |    237.196 ns |   0.6498 ns |   0.5760 ns | 39.05 |    0.32 |       - |     - |     - |         - |
|                ValueLinq_Ref_Standard_ByIndex |     0 |     73.759 ns |   0.1972 ns |   0.1646 ns | 12.14 |    0.10 |       - |     - |     - |         - |
|                   ValueLinq_Ref_Stack_ByIndex |     0 |     93.668 ns |   0.3321 ns |   0.3107 ns | 15.42 |    0.12 |       - |     - |     - |         - |
|         ValueLinq_Ref_SharedPool_Push_ByIndex |     0 |    237.903 ns |   1.3829 ns |   1.2259 ns | 39.16 |    0.37 |       - |     - |     - |         - |
|         ValueLinq_Ref_SharedPool_Pull_ByIndex |     0 |    246.189 ns |   1.2504 ns |   0.9763 ns | 40.54 |    0.33 |       - |     - |     - |         - |
|        ValueLinq_ValueLambda_Standard_ByIndex |     0 |     80.356 ns |   0.1860 ns |   0.1740 ns | 13.23 |    0.08 |       - |     - |     - |         - |
|           ValueLinq_ValueLambda_Stack_ByIndex |     0 |     99.484 ns |   0.2913 ns |   0.2582 ns | 16.38 |    0.11 |       - |     - |     - |         - |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |     0 |    244.601 ns |   0.4676 ns |   0.4145 ns | 40.27 |    0.30 |       - |     - |     - |         - |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |     0 |    244.053 ns |   0.5384 ns |   0.4496 ns | 40.17 |    0.28 |       - |     - |     - |         - |
|                                       ForLoop |     0 |      6.075 ns |   0.0506 ns |   0.0448 ns |  1.00 |    0.00 |  0.0153 |     - |     - |      32 B |
|                                   ForeachLoop |     0 |     14.981 ns |   0.0406 ns |   0.0360 ns |  2.47 |    0.02 |  0.0153 |     - |     - |      32 B |
|                                          Linq |     0 |     67.896 ns |   0.9022 ns |   0.7998 ns | 11.18 |    0.13 |  0.1339 |     - |     - |     280 B |
|                                    LinqFaster |     0 |      8.139 ns |   0.0308 ns |   0.0257 ns |  1.34 |    0.01 |  0.0153 |     - |     - |      32 B |
|                                        LinqAF |     0 |    144.276 ns |   0.2769 ns |   0.2590 ns | 23.75 |    0.19 |  0.0992 |     - |     - |     208 B |
|                                    StructLinq |     0 |     69.508 ns |   0.3010 ns |   0.2816 ns | 11.44 |    0.10 |  0.0612 |     - |     - |     128 B |
|                          StructLinq_IFunction |     0 |     52.898 ns |   0.2074 ns |   0.1839 ns |  8.71 |    0.07 |  0.0114 |     - |     - |      24 B |
|                                     Hyperlinq |     0 |     48.036 ns |   0.1039 ns |   0.0972 ns |  7.91 |    0.06 |  0.0114 |     - |     - |      24 B |
|                           Hyperlinq_IFunction |     0 |     44.635 ns |   0.1782 ns |   0.1488 ns |  7.35 |    0.07 |  0.0114 |     - |     - |      24 B |
|                                               |       |               |             |             |       |         |         |       |       |           |
|                            **ValueLinq_Standard** |    **10** |    **214.214 ns** |   **0.7462 ns** |   **0.6615 ns** |  **3.34** |    **0.03** |  **0.0496** |     **-** |     **-** |     **104 B** |
|                               ValueLinq_Stack |    10 |    177.238 ns |   1.4918 ns |   1.3955 ns |  2.77 |    0.03 |  0.0496 |     - |     - |     104 B |
|                     ValueLinq_SharedPool_Push |    10 |    405.177 ns |   2.0222 ns |   1.7926 ns |  6.32 |    0.04 |  0.0496 |     - |     - |     104 B |
|                     ValueLinq_SharedPool_Pull |    10 |    325.331 ns |   0.9670 ns |   0.9045 ns |  5.08 |    0.04 |  0.0496 |     - |     - |     104 B |
|                        ValueLinq_Ref_Standard |    10 |    209.414 ns |   0.4417 ns |   0.3688 ns |  3.27 |    0.02 |  0.0496 |     - |     - |     104 B |
|                           ValueLinq_Ref_Stack |    10 |    167.498 ns |   0.5775 ns |   0.4509 ns |  2.61 |    0.02 |  0.0496 |     - |     - |     104 B |
|                 ValueLinq_Ref_SharedPool_Push |    10 |    329.101 ns |   1.4108 ns |   1.2507 ns |  5.13 |    0.03 |  0.0496 |     - |     - |     104 B |
|                 ValueLinq_Ref_SharedPool_Pull |    10 |    426.958 ns |   0.9342 ns |   0.7293 ns |  6.66 |    0.05 |  0.0496 |     - |     - |     104 B |
|                ValueLinq_ValueLambda_Standard |    10 |    212.883 ns |   1.0993 ns |   0.9180 ns |  3.32 |    0.03 |  0.0496 |     - |     - |     104 B |
|                   ValueLinq_ValueLambda_Stack |    10 |    175.195 ns |   0.9741 ns |   0.8635 ns |  2.73 |    0.02 |  0.0496 |     - |     - |     104 B |
|         ValueLinq_ValueLambda_SharedPool_Push |    10 |    327.490 ns |   0.9084 ns |   0.8052 ns |  5.11 |    0.03 |  0.0496 |     - |     - |     104 B |
|         ValueLinq_ValueLambda_SharedPool_Pull |    10 |    322.944 ns |   1.4378 ns |   1.3449 ns |  5.04 |    0.05 |  0.0496 |     - |     - |     104 B |
|                    ValueLinq_Standard_ByIndex |    10 |    188.416 ns |   0.7771 ns |   0.6489 ns |  2.94 |    0.02 |  0.0496 |     - |     - |     104 B |
|                       ValueLinq_Stack_ByIndex |    10 |    155.818 ns |   1.0157 ns |   0.9004 ns |  2.43 |    0.02 |  0.0496 |     - |     - |     104 B |
|             ValueLinq_SharedPool_Push_ByIndex |    10 |    423.457 ns |   2.3737 ns |   2.1042 ns |  6.61 |    0.04 |  0.0496 |     - |     - |     104 B |
|             ValueLinq_SharedPool_Pull_ByIndex |    10 |    303.430 ns |   1.2453 ns |   1.0399 ns |  4.74 |    0.03 |  0.0496 |     - |     - |     104 B |
|                ValueLinq_Ref_Standard_ByIndex |    10 |    178.892 ns |   0.5733 ns |   0.5082 ns |  2.79 |    0.02 |  0.0496 |     - |     - |     104 B |
|                   ValueLinq_Ref_Stack_ByIndex |    10 |    143.161 ns |   0.6882 ns |   0.6100 ns |  2.23 |    0.02 |  0.0496 |     - |     - |     104 B |
|         ValueLinq_Ref_SharedPool_Push_ByIndex |    10 |    344.495 ns |   1.1515 ns |   1.0208 ns |  5.37 |    0.04 |  0.0496 |     - |     - |     104 B |
|         ValueLinq_Ref_SharedPool_Pull_ByIndex |    10 |    291.114 ns |   0.9883 ns |   0.8761 ns |  4.54 |    0.03 |  0.0496 |     - |     - |     104 B |
|        ValueLinq_ValueLambda_Standard_ByIndex |    10 |    192.198 ns |   0.5962 ns |   0.5577 ns |  3.00 |    0.02 |  0.0496 |     - |     - |     104 B |
|           ValueLinq_ValueLambda_Stack_ByIndex |    10 |    152.217 ns |   0.5258 ns |   0.4661 ns |  2.37 |    0.02 |  0.0496 |     - |     - |     104 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |    10 |    340.084 ns |   1.4408 ns |   1.2772 ns |  5.31 |    0.04 |  0.0496 |     - |     - |     104 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |    10 |    298.436 ns |   1.3665 ns |   1.2113 ns |  4.66 |    0.04 |  0.0496 |     - |     - |     104 B |
|                                       ForLoop |    10 |     64.105 ns |   0.4659 ns |   0.4130 ns |  1.00 |    0.00 |  0.1528 |     - |     - |     320 B |
|                                   ForeachLoop |    10 |     95.864 ns |   0.4986 ns |   0.4163 ns |  1.50 |    0.01 |  0.1529 |     - |     - |     320 B |
|                                          Linq |    10 |    157.566 ns |   0.7929 ns |   0.6621 ns |  2.46 |    0.02 |  0.2716 |     - |     - |     568 B |
|                                    LinqFaster |    10 |     87.964 ns |   0.4589 ns |   0.4292 ns |  1.37 |    0.01 |  0.1528 |     - |     - |     320 B |
|                                        LinqAF |    10 |    283.334 ns |   5.6517 ns |   5.2866 ns |  4.41 |    0.09 |  0.1373 |     - |     - |     288 B |
|                                    StructLinq |    10 |    147.349 ns |   1.5954 ns |   1.3322 ns |  2.30 |    0.03 |  0.0994 |     - |     - |     208 B |
|                          StructLinq_IFunction |    10 |    110.941 ns |   0.4226 ns |   0.3746 ns |  1.73 |    0.01 |  0.0497 |     - |     - |     104 B |
|                                     Hyperlinq |    10 |    119.684 ns |   0.4895 ns |   0.4339 ns |  1.87 |    0.02 |  0.0496 |     - |     - |     104 B |
|                           Hyperlinq_IFunction |    10 |     92.814 ns |   0.2865 ns |   0.2540 ns |  1.45 |    0.01 |  0.0497 |     - |     - |     104 B |
|                                               |       |               |             |             |       |         |         |       |       |           |
|                            **ValueLinq_Standard** |  **1000** | **14,339.381 ns** |  **63.4723 ns** |  **56.2665 ns** |  **1.35** |    **0.01** | **19.0430** |     **-** |     **-** |   **40104 B** |
|                               ValueLinq_Stack |  1000 | 14,943.947 ns |  75.8199 ns |  67.2123 ns |  1.41 |    0.01 | 19.0430 |     - |     - |   40104 B |
|                     ValueLinq_SharedPool_Push |  1000 | 13,666.835 ns |  94.4796 ns |  88.3763 ns |  1.29 |    0.01 |  9.6130 |     - |     - |   20144 B |
|                     ValueLinq_SharedPool_Pull |  1000 | 14,373.943 ns |  32.2426 ns |  30.1597 ns |  1.35 |    0.00 |  9.6130 |     - |     - |   20144 B |
|                        ValueLinq_Ref_Standard |  1000 | 15,214.648 ns |  95.7489 ns |  89.5635 ns |  1.43 |    0.01 | 19.0430 |     - |     - |   40104 B |
|                           ValueLinq_Ref_Stack |  1000 | 14,891.257 ns |  41.8960 ns |  37.1398 ns |  1.40 |    0.00 | 19.0430 |     - |     - |   40104 B |
|                 ValueLinq_Ref_SharedPool_Push |  1000 | 12,084.380 ns |  46.5042 ns |  43.5001 ns |  1.14 |    0.01 |  9.6130 |     - |     - |   20144 B |
|                 ValueLinq_Ref_SharedPool_Pull |  1000 | 22,330.930 ns |  95.7273 ns |  84.8598 ns |  2.10 |    0.01 |  9.6130 |     - |     - |   20144 B |
|                ValueLinq_ValueLambda_Standard |  1000 | 14,413.634 ns | 133.3253 ns | 118.1894 ns |  1.36 |    0.01 | 19.0430 |     - |     - |   40104 B |
|                   ValueLinq_ValueLambda_Stack |  1000 | 14,140.958 ns |  71.4528 ns |  63.3411 ns |  1.33 |    0.01 | 19.0430 |     - |     - |   40104 B |
|         ValueLinq_ValueLambda_SharedPool_Push |  1000 |  9,071.982 ns |  38.5864 ns |  34.2059 ns |  0.85 |    0.00 |  9.6130 |     - |     - |   20144 B |
|         ValueLinq_ValueLambda_SharedPool_Pull |  1000 | 14,385.251 ns |  55.7951 ns |  49.4609 ns |  1.35 |    0.00 |  9.6130 |     - |     - |   20144 B |
|                    ValueLinq_Standard_ByIndex |  1000 | 13,339.930 ns |  56.9698 ns |  47.5724 ns |  1.26 |    0.00 | 19.0430 |     - |     - |   40104 B |
|                       ValueLinq_Stack_ByIndex |  1000 | 14,147.217 ns |  62.0580 ns |  58.0491 ns |  1.33 |    0.01 | 19.0430 |     - |     - |   40104 B |
|             ValueLinq_SharedPool_Push_ByIndex |  1000 | 13,797.225 ns |  64.3961 ns |  53.7737 ns |  1.30 |    0.01 |  9.6130 |     - |     - |   20144 B |
|             ValueLinq_SharedPool_Pull_ByIndex |  1000 | 13,045.770 ns |  48.7344 ns |  43.2018 ns |  1.23 |    0.01 |  9.6130 |     - |     - |   20144 B |
|                ValueLinq_Ref_Standard_ByIndex |  1000 | 11,668.168 ns |  50.4340 ns |  39.3755 ns |  1.10 |    0.00 | 19.0430 |     - |     - |   40104 B |
|                   ValueLinq_Ref_Stack_ByIndex |  1000 | 11,351.219 ns |  40.7665 ns |  36.1385 ns |  1.07 |    0.00 | 19.0430 |     - |     - |   40104 B |
|         ValueLinq_Ref_SharedPool_Push_ByIndex |  1000 | 12,202.831 ns |  38.7562 ns |  32.3632 ns |  1.15 |    0.01 |  9.6130 |     - |     - |   20144 B |
|         ValueLinq_Ref_SharedPool_Pull_ByIndex |  1000 | 11,072.116 ns |  27.9503 ns |  21.8217 ns |  1.04 |    0.00 |  9.6130 |     - |     - |   20144 B |
|        ValueLinq_ValueLambda_Standard_ByIndex |  1000 | 10,345.946 ns |  50.7803 ns |  47.4999 ns |  0.97 |    0.01 | 19.0430 |     - |     - |   40104 B |
|           ValueLinq_ValueLambda_Stack_ByIndex |  1000 |  9,765.830 ns |  40.3172 ns |  37.7128 ns |  0.92 |    0.00 | 19.0430 |     - |     - |   40104 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |  1000 |  9,494.487 ns |  26.7907 ns |  22.3714 ns |  0.89 |    0.00 |  9.6130 |     - |     - |   20144 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |  1000 |  9,237.296 ns |  43.5536 ns |  40.7401 ns |  0.87 |    0.01 |  9.6130 |     - |     - |   20144 B |
|                                       ForLoop |  1000 | 10,619.062 ns |  37.3908 ns |  33.1459 ns |  1.00 |    0.00 | 29.1138 |     - |     - |   61168 B |
|                                   ForeachLoop |  1000 | 11,859.630 ns |  62.8233 ns |  49.0483 ns |  1.12 |    0.00 | 29.1138 |     - |     - |   61168 B |
|                                          Linq |  1000 | 13,222.155 ns |  63.9876 ns |  56.7233 ns |  1.25 |    0.01 | 19.7296 |     - |     - |   41400 B |
|                                    LinqFaster |  1000 | 14,850.780 ns |  87.8198 ns |  73.3335 ns |  1.40 |    0.01 | 29.1138 |     - |     - |   61168 B |
|                                        LinqAF |  1000 | 28,205.098 ns | 224.9814 ns | 210.4477 ns |  2.66 |    0.02 | 29.1138 |     - |     - |   61136 B |
|                                    StructLinq |  1000 | 12,210.781 ns |  49.3285 ns |  43.7284 ns |  1.15 |    0.00 |  9.6130 |     - |     - |   20248 B |
|                          StructLinq_IFunction |  1000 |  7,362.275 ns |  24.8840 ns |  23.2765 ns |  0.69 |    0.00 |  9.6130 |     - |     - |   20144 B |
|                                     Hyperlinq |  1000 |  9,285.247 ns |  52.4543 ns |  40.9529 ns |  0.87 |    0.00 |  9.6130 |     - |     - |   20144 B |
|                           Hyperlinq_IFunction |  1000 |  7,284.009 ns |  21.8779 ns |  19.3942 ns |  0.69 |    0.00 |  9.6130 |     - |     - |   20144 B |
