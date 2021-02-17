## List.ValueType.ListValueTypeWhereSelectToList

### Source
[ListValueTypeWhereSelectToList.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelectToList.cs)

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
|                            **ValueLinq_Standard** |     **0** |     **55.251 ns** |   **0.3329 ns** |   **0.2599 ns** | **12.37** |    **0.10** |  **0.0152** |     **-** |     **-** |      **32 B** |
|                               ValueLinq_Stack |     0 |    119.065 ns |   0.3185 ns |   0.2660 ns | 26.66 |    0.20 |  0.0153 |     - |     - |      32 B |
|                     ValueLinq_SharedPool_Push |     0 |    321.226 ns |   0.5147 ns |   0.4563 ns | 71.97 |    0.56 |  0.0153 |     - |     - |      32 B |
|                     ValueLinq_SharedPool_Pull |     0 |    258.035 ns |   0.6446 ns |   0.5383 ns | 57.78 |    0.51 |  0.0153 |     - |     - |      32 B |
|                        ValueLinq_Ref_Standard |     0 |     51.748 ns |   0.1473 ns |   0.1378 ns | 11.60 |    0.09 |  0.0153 |     - |     - |      32 B |
|                           ValueLinq_Ref_Stack |     0 |    119.381 ns |   0.2918 ns |   0.2587 ns | 26.75 |    0.21 |  0.0150 |     - |     - |      32 B |
|                 ValueLinq_Ref_SharedPool_Push |     0 |    235.756 ns |   0.8790 ns |   0.8222 ns | 52.85 |    0.38 |  0.0153 |     - |     - |      32 B |
|                 ValueLinq_Ref_SharedPool_Pull |     0 |    252.242 ns |   0.5511 ns |   0.4885 ns | 56.51 |    0.40 |  0.0153 |     - |     - |      32 B |
|                ValueLinq_ValueLambda_Standard |     0 |     68.658 ns |   0.1808 ns |   0.1692 ns | 15.39 |    0.14 |  0.0153 |     - |     - |      32 B |
|                   ValueLinq_ValueLambda_Stack |     0 |    124.510 ns |   0.3708 ns |   0.3469 ns | 27.91 |    0.23 |  0.0150 |     - |     - |      32 B |
|         ValueLinq_ValueLambda_SharedPool_Push |     0 |    250.160 ns |   0.9150 ns |   0.8559 ns | 56.08 |    0.46 |  0.0153 |     - |     - |      32 B |
|         ValueLinq_ValueLambda_SharedPool_Pull |     0 |    264.572 ns |   0.7587 ns |   0.7097 ns | 59.31 |    0.48 |  0.0153 |     - |     - |      32 B |
|                    ValueLinq_Standard_ByIndex |     0 |     73.876 ns |   0.1683 ns |   0.1574 ns | 16.56 |    0.13 |  0.0151 |     - |     - |      32 B |
|                       ValueLinq_Stack_ByIndex |     0 |    115.093 ns |   0.4015 ns |   0.3756 ns | 25.80 |    0.17 |  0.0150 |     - |     - |      32 B |
|             ValueLinq_SharedPool_Push_ByIndex |     0 |    320.590 ns |   1.0357 ns |   0.9181 ns | 71.82 |    0.60 |  0.0153 |     - |     - |      32 B |
|             ValueLinq_SharedPool_Pull_ByIndex |     0 |    248.960 ns |   0.5501 ns |   0.4295 ns | 55.76 |    0.47 |  0.0153 |     - |     - |      32 B |
|                ValueLinq_Ref_Standard_ByIndex |     0 |     71.298 ns |   0.2170 ns |   0.1812 ns | 15.97 |    0.12 |  0.0153 |     - |     - |      32 B |
|                   ValueLinq_Ref_Stack_ByIndex |     0 |    108.856 ns |   0.4338 ns |   0.4058 ns | 24.40 |    0.22 |  0.0150 |     - |     - |      32 B |
|         ValueLinq_Ref_SharedPool_Push_ByIndex |     0 |    244.316 ns |   0.5119 ns |   0.4275 ns | 54.71 |    0.42 |  0.0153 |     - |     - |      32 B |
|         ValueLinq_Ref_SharedPool_Pull_ByIndex |     0 |    241.706 ns |   0.4909 ns |   0.4592 ns | 54.18 |    0.40 |  0.0153 |     - |     - |      32 B |
|        ValueLinq_ValueLambda_Standard_ByIndex |     0 |     79.267 ns |   0.3725 ns |   0.3302 ns | 17.76 |    0.19 |  0.0151 |     - |     - |      32 B |
|           ValueLinq_ValueLambda_Stack_ByIndex |     0 |    118.491 ns |   0.3725 ns |   0.3302 ns | 26.55 |    0.18 |  0.0150 |     - |     - |      32 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |     0 |    254.091 ns |   0.8223 ns |   0.7289 ns | 56.93 |    0.55 |  0.0153 |     - |     - |      32 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |     0 |    256.124 ns |   1.3946 ns |   1.1646 ns | 57.35 |    0.52 |  0.0153 |     - |     - |      32 B |
|                                       ForLoop |     0 |      4.461 ns |   0.0369 ns |   0.0345 ns |  1.00 |    0.00 |  0.0153 |     - |     - |      32 B |
|                                   ForeachLoop |     0 |     14.069 ns |   0.1496 ns |   0.1249 ns |  3.15 |    0.03 |  0.0153 |     - |     - |      32 B |
|                                          Linq |     0 |     64.630 ns |   0.1978 ns |   0.1753 ns | 14.48 |    0.13 |  0.1490 |     - |     - |     312 B |
|                                    LinqFaster |     0 |     17.973 ns |   0.1506 ns |   0.1335 ns |  4.03 |    0.05 |  0.0306 |     - |     - |      64 B |
|                                        LinqAF |     0 |    118.543 ns |   0.5829 ns |   0.4868 ns | 26.55 |    0.22 |  0.0151 |     - |     - |      32 B |
|                                    StructLinq |     0 |     75.286 ns |   0.1830 ns |   0.1622 ns | 16.87 |    0.13 |  0.0763 |     - |     - |     160 B |
|                          StructLinq_IFunction |     0 |     62.161 ns |   0.2404 ns |   0.2248 ns | 13.93 |    0.10 |  0.0266 |     - |     - |      56 B |
|                                     Hyperlinq |     0 |     20.847 ns |   0.0430 ns |   0.0359 ns |  4.67 |    0.03 |  0.0153 |     - |     - |      32 B |
|                           Hyperlinq_IFunction |     0 |     19.003 ns |   0.0496 ns |   0.0440 ns |  4.26 |    0.04 |  0.0153 |     - |     - |      32 B |
|                                               |       |               |             |             |       |         |         |       |       |           |
|                            **ValueLinq_Standard** |    **10** |    **240.542 ns** |   **2.4877 ns** |   **2.3270 ns** |  **4.82** |    **0.05** |  **0.0648** |     **-** |     **-** |     **136 B** |
|                               ValueLinq_Stack |    10 |    201.519 ns |   0.9993 ns |   0.8859 ns |  4.04 |    0.03 |  0.0648 |     - |     - |     136 B |
|                     ValueLinq_SharedPool_Push |    10 |    415.587 ns |   1.5459 ns |   1.4460 ns |  8.34 |    0.05 |  0.0648 |     - |     - |     136 B |
|                     ValueLinq_SharedPool_Pull |    10 |    324.329 ns |   1.2291 ns |   1.1497 ns |  6.51 |    0.04 |  0.0648 |     - |     - |     136 B |
|                        ValueLinq_Ref_Standard |    10 |    229.418 ns |   1.0761 ns |   0.8986 ns |  4.60 |    0.03 |  0.0648 |     - |     - |     136 B |
|                           ValueLinq_Ref_Stack |    10 |    191.382 ns |   1.3810 ns |   1.2918 ns |  3.84 |    0.03 |  0.0648 |     - |     - |     136 B |
|                 ValueLinq_Ref_SharedPool_Push |    10 |    331.186 ns |   0.9067 ns |   0.7572 ns |  6.65 |    0.04 |  0.0648 |     - |     - |     136 B |
|                 ValueLinq_Ref_SharedPool_Pull |    10 |    332.331 ns |   2.0891 ns |   1.9541 ns |  6.67 |    0.06 |  0.0648 |     - |     - |     136 B |
|                ValueLinq_ValueLambda_Standard |    10 |    232.539 ns |   0.7872 ns |   0.6979 ns |  4.67 |    0.02 |  0.0648 |     - |     - |     136 B |
|                   ValueLinq_ValueLambda_Stack |    10 |    200.056 ns |   1.4072 ns |   1.2475 ns |  4.01 |    0.03 |  0.0648 |     - |     - |     136 B |
|         ValueLinq_ValueLambda_SharedPool_Push |    10 |    341.172 ns |   1.1111 ns |   0.9850 ns |  6.85 |    0.04 |  0.0648 |     - |     - |     136 B |
|         ValueLinq_ValueLambda_SharedPool_Pull |    10 |    338.024 ns |   1.7255 ns |   1.4409 ns |  6.78 |    0.05 |  0.0648 |     - |     - |     136 B |
|                    ValueLinq_Standard_ByIndex |    10 |    211.278 ns |   0.8058 ns |   0.6729 ns |  4.24 |    0.02 |  0.0648 |     - |     - |     136 B |
|                       ValueLinq_Stack_ByIndex |    10 |    174.536 ns |   0.6595 ns |   0.6169 ns |  3.50 |    0.02 |  0.0648 |     - |     - |     136 B |
|             ValueLinq_SharedPool_Push_ByIndex |    10 |    424.523 ns |   1.5131 ns |   1.2635 ns |  8.52 |    0.06 |  0.0648 |     - |     - |     136 B |
|             ValueLinq_SharedPool_Pull_ByIndex |    10 |    315.240 ns |   1.1909 ns |   1.1140 ns |  6.32 |    0.04 |  0.0648 |     - |     - |     136 B |
|                ValueLinq_Ref_Standard_ByIndex |    10 |    202.454 ns |   1.1570 ns |   1.0823 ns |  4.06 |    0.03 |  0.0648 |     - |     - |     136 B |
|                   ValueLinq_Ref_Stack_ByIndex |    10 |    164.995 ns |   1.0910 ns |   1.0205 ns |  3.31 |    0.03 |  0.0648 |     - |     - |     136 B |
|         ValueLinq_Ref_SharedPool_Push_ByIndex |    10 |    356.484 ns |   1.8533 ns |   1.6429 ns |  7.15 |    0.04 |  0.0648 |     - |     - |     136 B |
|         ValueLinq_Ref_SharedPool_Pull_ByIndex |    10 |    304.594 ns |   1.5466 ns |   1.2915 ns |  6.11 |    0.03 |  0.0648 |     - |     - |     136 B |
|        ValueLinq_ValueLambda_Standard_ByIndex |    10 |    210.874 ns |   0.8598 ns |   0.8042 ns |  4.23 |    0.03 |  0.0648 |     - |     - |     136 B |
|           ValueLinq_ValueLambda_Stack_ByIndex |    10 |    173.283 ns |   1.3166 ns |   1.1671 ns |  3.48 |    0.02 |  0.0648 |     - |     - |     136 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |    10 |    343.468 ns |   0.9372 ns |   0.7826 ns |  6.89 |    0.04 |  0.0648 |     - |     - |     136 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |    10 |    305.598 ns |   1.1194 ns |   0.9923 ns |  6.13 |    0.03 |  0.0648 |     - |     - |     136 B |
|                                       ForLoop |    10 |     49.841 ns |   0.2755 ns |   0.2442 ns |  1.00 |    0.00 |  0.1033 |     - |     - |     216 B |
|                                   ForeachLoop |    10 |     79.193 ns |   0.6338 ns |   0.5928 ns |  1.59 |    0.01 |  0.1032 |     - |     - |     216 B |
|                                          Linq |    10 |    137.413 ns |   0.9559 ns |   0.8942 ns |  2.76 |    0.02 |  0.2370 |     - |     - |     496 B |
|                                    LinqFaster |    10 |    101.161 ns |   0.5866 ns |   0.5200 ns |  2.03 |    0.02 |  0.1683 |     - |     - |     352 B |
|                                        LinqAF |    10 |    280.752 ns |   3.6151 ns |   3.3816 ns |  5.64 |    0.08 |  0.1030 |     - |     - |     216 B |
|                                    StructLinq |    10 |    154.569 ns |   1.2542 ns |   1.1732 ns |  3.10 |    0.02 |  0.1147 |     - |     - |     240 B |
|                          StructLinq_IFunction |    10 |    118.850 ns |   1.0711 ns |   0.9495 ns |  2.38 |    0.02 |  0.0648 |     - |     - |     136 B |
|                                     Hyperlinq |    10 |    125.993 ns |   0.7708 ns |   0.7210 ns |  2.53 |    0.02 |  0.0648 |     - |     - |     136 B |
|                           Hyperlinq_IFunction |    10 |    103.902 ns |   0.3215 ns |   0.3007 ns |  2.08 |    0.01 |  0.0650 |     - |     - |     136 B |
|                                               |       |               |             |             |       |         |         |       |       |           |
|                            **ValueLinq_Standard** |  **1000** | **13,865.958 ns** |  **84.7966 ns** |  **75.1700 ns** |  **1.42** |    **0.01** | **19.6075** |     **-** |     **-** |   **41024 B** |
|                               ValueLinq_Stack |  1000 | 14,777.355 ns |  47.7123 ns |  39.8419 ns |  1.51 |    0.01 | 19.1040 |     - |     - |   40136 B |
|                     ValueLinq_SharedPool_Push |  1000 | 13,773.101 ns |  46.8984 ns |  43.8688 ns |  1.41 |    0.01 |  9.6130 |     - |     - |   20176 B |
|                     ValueLinq_SharedPool_Pull |  1000 | 15,563.708 ns | 187.5568 ns | 175.4408 ns |  1.59 |    0.02 |  9.6130 |     - |     - |   20176 B |
|                        ValueLinq_Ref_Standard |  1000 | 14,702.726 ns |  46.9305 ns |  43.8988 ns |  1.51 |    0.01 | 19.6075 |     - |     - |   41024 B |
|                           ValueLinq_Ref_Stack |  1000 | 15,327.034 ns |  58.0382 ns |  48.4645 ns |  1.57 |    0.01 | 19.1040 |     - |     - |   40136 B |
|                 ValueLinq_Ref_SharedPool_Push |  1000 | 12,482.448 ns |  47.3370 ns |  41.9630 ns |  1.28 |    0.01 |  9.6130 |     - |     - |   20176 B |
|                 ValueLinq_Ref_SharedPool_Pull |  1000 | 15,325.220 ns |  64.3757 ns |  57.0674 ns |  1.57 |    0.01 |  9.6130 |     - |     - |   20176 B |
|                ValueLinq_ValueLambda_Standard |  1000 | 12,320.243 ns |  66.3366 ns |  58.8056 ns |  1.26 |    0.01 | 19.6075 |     - |     - |   41024 B |
|                   ValueLinq_ValueLambda_Stack |  1000 | 13,982.225 ns |  40.1124 ns |  35.5586 ns |  1.43 |    0.01 | 19.1040 |     - |     - |   40136 B |
|         ValueLinq_ValueLambda_SharedPool_Push |  1000 | 10,127.894 ns |  35.3931 ns |  33.1067 ns |  1.04 |    0.01 |  9.6130 |     - |     - |   20176 B |
|         ValueLinq_ValueLambda_SharedPool_Pull |  1000 | 14,192.148 ns |  59.3851 ns |  55.5488 ns |  1.45 |    0.01 |  9.6130 |     - |     - |   20176 B |
|                    ValueLinq_Standard_ByIndex |  1000 | 13,415.533 ns | 162.4836 ns | 144.0375 ns |  1.37 |    0.02 | 19.6075 |     - |     - |   41024 B |
|                       ValueLinq_Stack_ByIndex |  1000 | 12,745.804 ns | 234.3760 ns | 195.7146 ns |  1.30 |    0.02 | 19.1040 |     - |     - |   40136 B |
|             ValueLinq_SharedPool_Push_ByIndex |  1000 | 14,193.471 ns |  64.5512 ns |  57.2230 ns |  1.45 |    0.01 |  9.6130 |     - |     - |   20176 B |
|             ValueLinq_SharedPool_Pull_ByIndex |  1000 | 13,112.007 ns |  50.9099 ns |  45.1303 ns |  1.34 |    0.01 |  9.6130 |     - |     - |   20176 B |
|                ValueLinq_Ref_Standard_ByIndex |  1000 | 11,772.497 ns |  57.2812 ns |  53.5809 ns |  1.21 |    0.01 | 19.6075 |     - |     - |   41024 B |
|                   ValueLinq_Ref_Stack_ByIndex |  1000 | 11,411.727 ns |  35.3239 ns |  31.3137 ns |  1.17 |    0.01 | 19.1040 |     - |     - |   40136 B |
|         ValueLinq_Ref_SharedPool_Push_ByIndex |  1000 | 12,339.925 ns |  65.1429 ns |  60.9347 ns |  1.26 |    0.01 |  9.6130 |     - |     - |   20176 B |
|         ValueLinq_Ref_SharedPool_Pull_ByIndex |  1000 | 11,278.512 ns |  48.1863 ns |  42.7159 ns |  1.15 |    0.01 |  9.6130 |     - |     - |   20176 B |
|        ValueLinq_ValueLambda_Standard_ByIndex |  1000 |  9,254.772 ns |  58.0021 ns |  54.2552 ns |  0.95 |    0.01 | 19.6075 |     - |     - |   41024 B |
|           ValueLinq_ValueLambda_Stack_ByIndex |  1000 | 10,359.737 ns |  66.3332 ns |  62.0481 ns |  1.06 |    0.01 | 19.1040 |     - |     - |   40136 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |  1000 |  9,798.118 ns |  68.7793 ns |  57.4339 ns |  1.00 |    0.01 |  9.6130 |     - |     - |   20176 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |  1000 |  9,517.816 ns |  45.4404 ns |  40.2817 ns |  0.97 |    0.01 |  9.6130 |     - |     - |   20176 B |
|                                       ForLoop |  1000 |  9,768.409 ns |  76.5324 ns |  71.5884 ns |  1.00 |    0.00 | 19.6075 |     - |     - |   41024 B |
|                                   ForeachLoop |  1000 | 10,599.703 ns |  94.7103 ns |  88.5921 ns |  1.09 |    0.01 | 19.6075 |     - |     - |   41024 B |
|                                          Linq |  1000 | 12,586.170 ns |  82.2148 ns |  68.6531 ns |  1.29 |    0.01 | 19.6075 |     - |     - |   41304 B |
|                                    LinqFaster |  1000 | 14,992.071 ns |  65.8643 ns |  58.3870 ns |  1.53 |    0.01 | 29.1138 |     - |     - |   61200 B |
|                                        LinqAF |  1000 | 27,438.434 ns | 376.9484 ns | 314.7689 ns |  2.81 |    0.03 | 19.5923 |     - |     - |   41024 B |
|                                    StructLinq |  1000 | 12,065.537 ns |  34.0651 ns |  30.1978 ns |  1.23 |    0.01 |  9.6130 |     - |     - |   20280 B |
|                          StructLinq_IFunction |  1000 |  7,634.973 ns |  27.2019 ns |  24.1138 ns |  0.78 |    0.01 |  9.6130 |     - |     - |   20176 B |
|                                     Hyperlinq |  1000 |  9,497.697 ns |  87.6662 ns |  82.0031 ns |  0.97 |    0.01 |  9.6130 |     - |     - |   20176 B |
|                           Hyperlinq_IFunction |  1000 |  7,374.232 ns |  28.2360 ns |  26.4120 ns |  0.75 |    0.01 |  9.6130 |     - |     - |   20176 B |
