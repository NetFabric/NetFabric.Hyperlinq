## List.Int32.ListInt32WhereSelectToArray

### Source
[ListInt32WhereSelectToArray.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelectToArray.cs)

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
|                                        Method | Count |          Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------------------------- |------ |--------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|                            **ValueLinq_Standard** |     **0** |     **57.193 ns** |  **0.2158 ns** |  **0.1913 ns** | **10.12** |    **0.10** |      **-** |     **-** |     **-** |         **-** |
|                               ValueLinq_Stack |     0 |     89.672 ns |  0.2288 ns |  0.1910 ns | 15.88 |    0.13 |      - |     - |     - |         - |
|                     ValueLinq_SharedPool_Push |     0 |    297.099 ns |  0.8938 ns |  0.7924 ns | 52.57 |    0.44 |      - |     - |     - |         - |
|                     ValueLinq_SharedPool_Pull |     0 |    223.106 ns |  0.6657 ns |  0.5901 ns | 39.48 |    0.35 |      - |     - |     - |         - |
|                ValueLinq_ValueLambda_Standard |     0 |     68.059 ns |  0.2151 ns |  0.2012 ns | 12.05 |    0.11 |      - |     - |     - |         - |
|                   ValueLinq_ValueLambda_Stack |     0 |    101.371 ns |  0.3402 ns |  0.3182 ns | 17.94 |    0.13 |      - |     - |     - |         - |
|         ValueLinq_ValueLambda_SharedPool_Push |     0 |    236.794 ns |  1.3199 ns |  1.1022 ns | 41.93 |    0.35 |      - |     - |     - |         - |
|         ValueLinq_ValueLambda_SharedPool_Pull |     0 |    229.290 ns |  0.4733 ns |  0.3695 ns | 40.64 |    0.34 |      - |     - |     - |         - |
|                    ValueLinq_Standard_ByIndex |     0 |     76.368 ns |  0.1261 ns |  0.1179 ns | 13.52 |    0.12 |      - |     - |     - |         - |
|                       ValueLinq_Stack_ByIndex |     0 |     94.771 ns |  0.2440 ns |  0.2038 ns | 16.78 |    0.16 |      - |     - |     - |         - |
|             ValueLinq_SharedPool_Push_ByIndex |     0 |    311.563 ns |  1.0886 ns |  0.8499 ns | 55.22 |    0.39 |      - |     - |     - |         - |
|             ValueLinq_SharedPool_Pull_ByIndex |     0 |    218.558 ns |  0.6724 ns |  0.5961 ns | 38.68 |    0.30 |      - |     - |     - |         - |
|        ValueLinq_ValueLambda_Standard_ByIndex |     0 |     80.907 ns |  0.2120 ns |  0.1771 ns | 14.33 |    0.12 |      - |     - |     - |         - |
|           ValueLinq_ValueLambda_Stack_ByIndex |     0 |     96.564 ns |  0.2476 ns |  0.2195 ns | 17.09 |    0.14 |      - |     - |     - |         - |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |     0 |    244.642 ns |  1.0508 ns |  0.9829 ns | 43.30 |    0.40 |      - |     - |     - |         - |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |     0 |    236.092 ns |  0.4849 ns |  0.4298 ns | 41.78 |    0.33 |      - |     - |     - |         - |
|                                       ForLoop |     0 |      5.650 ns |  0.0477 ns |  0.0447 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|                                   ForeachLoop |     0 |      8.863 ns |  0.0767 ns |  0.0718 ns |  1.57 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                          Linq |     0 |     62.095 ns |  0.3198 ns |  0.2991 ns | 10.99 |    0.10 | 0.0726 |     - |     - |     152 B |
|                                    LinqFaster |     0 |      8.017 ns |  0.0521 ns |  0.0435 ns |  1.42 |    0.02 | 0.0153 |     - |     - |      32 B |
|                                        LinqAF |     0 |     84.471 ns |  0.2631 ns |  0.2054 ns | 14.97 |    0.13 | 0.0305 |     - |     - |      64 B |
|                                    StructLinq |     0 |     70.200 ns |  0.2458 ns |  0.2179 ns | 12.42 |    0.11 | 0.0572 |     - |     - |     120 B |
|                          StructLinq_IFunction |     0 |     54.482 ns |  0.1189 ns |  0.1054 ns |  9.64 |    0.08 | 0.0114 |     - |     - |      24 B |
|                                     Hyperlinq |     0 |     47.968 ns |  0.1592 ns |  0.1411 ns |  8.49 |    0.07 | 0.0114 |     - |     - |      24 B |
|                           Hyperlinq_IFunction |     0 |     45.082 ns |  0.1892 ns |  0.1580 ns |  7.98 |    0.06 | 0.0114 |     - |     - |      24 B |
|                                               |       |               |            |            |       |         |        |       |       |           |
|                            **ValueLinq_Standard** |    **10** |    **190.787 ns** |  **0.2976 ns** |  **0.2485 ns** |  **4.67** |    **0.02** | **0.0153** |     **-** |     **-** |      **32 B** |
|                               ValueLinq_Stack |    10 |    148.510 ns |  0.4021 ns |  0.3565 ns |  3.64 |    0.02 | 0.0150 |     - |     - |      32 B |
|                     ValueLinq_SharedPool_Push |    10 |    350.906 ns |  1.4684 ns |  1.3017 ns |  8.59 |    0.06 | 0.0153 |     - |     - |      32 B |
|                     ValueLinq_SharedPool_Pull |    10 |    276.950 ns |  1.0901 ns |  0.9103 ns |  6.78 |    0.03 | 0.0153 |     - |     - |      32 B |
|                ValueLinq_ValueLambda_Standard |    10 |    161.938 ns |  0.5589 ns |  0.4954 ns |  3.97 |    0.02 | 0.0153 |     - |     - |      32 B |
|                   ValueLinq_ValueLambda_Stack |    10 |    127.795 ns |  0.5439 ns |  0.5088 ns |  3.13 |    0.02 | 0.0150 |     - |     - |      32 B |
|         ValueLinq_ValueLambda_SharedPool_Push |    10 |    281.947 ns |  1.1522 ns |  0.9622 ns |  6.90 |    0.03 | 0.0153 |     - |     - |      32 B |
|         ValueLinq_ValueLambda_SharedPool_Pull |    10 |    270.641 ns |  0.8768 ns |  0.8201 ns |  6.63 |    0.04 | 0.0153 |     - |     - |      32 B |
|                    ValueLinq_Standard_ByIndex |    10 |    161.342 ns |  0.3360 ns |  0.2979 ns |  3.95 |    0.02 | 0.0153 |     - |     - |      32 B |
|                       ValueLinq_Stack_ByIndex |    10 |    127.573 ns |  0.5085 ns |  0.4508 ns |  3.12 |    0.02 | 0.0153 |     - |     - |      32 B |
|             ValueLinq_SharedPool_Push_ByIndex |    10 |    386.115 ns |  1.2585 ns |  1.1156 ns |  9.46 |    0.04 | 0.0153 |     - |     - |      32 B |
|             ValueLinq_SharedPool_Pull_ByIndex |    10 |    258.183 ns |  1.3970 ns |  1.2384 ns |  6.32 |    0.04 | 0.0153 |     - |     - |      32 B |
|        ValueLinq_ValueLambda_Standard_ByIndex |    10 |    147.296 ns |  0.4801 ns |  0.4256 ns |  3.61 |    0.02 | 0.0153 |     - |     - |      32 B |
|           ValueLinq_ValueLambda_Stack_ByIndex |    10 |    111.669 ns |  0.2539 ns |  0.2251 ns |  2.74 |    0.02 | 0.0151 |     - |     - |      32 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |    10 |    291.541 ns |  1.5477 ns |  1.3720 ns |  7.14 |    0.06 | 0.0153 |     - |     - |      32 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |    10 |    244.536 ns |  0.6934 ns |  0.6147 ns |  5.99 |    0.02 | 0.0153 |     - |     - |      32 B |
|                                       ForLoop |    10 |     40.829 ns |  0.2140 ns |  0.1897 ns |  1.00 |    0.00 | 0.0497 |     - |     - |     104 B |
|                                   ForeachLoop |    10 |     55.405 ns |  0.1338 ns |  0.1251 ns |  1.36 |    0.01 | 0.0497 |     - |     - |     104 B |
|                                          Linq |    10 |    121.112 ns |  0.4920 ns |  0.4362 ns |  2.97 |    0.02 | 0.1070 |     - |     - |     224 B |
|                                    LinqFaster |    10 |     55.157 ns |  0.3735 ns |  0.3311 ns |  1.35 |    0.01 | 0.0497 |     - |     - |     104 B |
|                                        LinqAF |    10 |    158.954 ns |  0.9033 ns |  0.8449 ns |  3.90 |    0.02 | 0.0341 |     - |     - |      72 B |
|                                    StructLinq |    10 |    129.666 ns |  0.6458 ns |  0.5725 ns |  3.18 |    0.02 | 0.0610 |     - |     - |     128 B |
|                          StructLinq_IFunction |    10 |     87.676 ns |  0.4435 ns |  0.4149 ns |  2.15 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                     Hyperlinq |    10 |    105.670 ns |  0.3518 ns |  0.3118 ns |  2.59 |    0.02 | 0.0153 |     - |     - |      32 B |
|                           Hyperlinq_IFunction |    10 |     83.208 ns |  0.4872 ns |  0.4068 ns |  2.04 |    0.02 | 0.0153 |     - |     - |      32 B |
|                                               |       |               |            |            |       |         |        |       |       |           |
|                            **ValueLinq_Standard** |  **1000** |  **7,519.173 ns** | **23.8172 ns** | **21.1134 ns** |  **2.19** |    **0.01** | **1.9760** |     **-** |     **-** |    **4144 B** |
|                               ValueLinq_Stack |  1000 |  7,313.968 ns | 26.0618 ns | 21.7628 ns |  2.13 |    0.01 | 1.9760 |     - |     - |    4144 B |
|                     ValueLinq_SharedPool_Push |  1000 |  5,440.573 ns | 28.3522 ns | 25.1335 ns |  1.59 |    0.01 | 0.9689 |     - |     - |    2040 B |
|                     ValueLinq_SharedPool_Pull |  1000 |  7,049.001 ns | 16.5955 ns | 13.8580 ns |  2.06 |    0.01 | 0.9689 |     - |     - |    2040 B |
|                ValueLinq_ValueLambda_Standard |  1000 |  7,866.054 ns | 18.6039 ns | 17.4021 ns |  2.30 |    0.01 | 1.9684 |     - |     - |    4144 B |
|                   ValueLinq_ValueLambda_Stack |  1000 |  7,983.216 ns | 29.9352 ns | 26.5368 ns |  2.33 |    0.01 | 1.9684 |     - |     - |    4144 B |
|         ValueLinq_ValueLambda_SharedPool_Push |  1000 |  2,968.712 ns | 11.8927 ns | 10.5426 ns |  0.87 |    0.00 | 0.9727 |     - |     - |    2040 B |
|         ValueLinq_ValueLambda_SharedPool_Pull |  1000 |  7,738.736 ns | 19.3307 ns | 16.1420 ns |  2.26 |    0.01 | 0.9613 |     - |     - |    2040 B |
|                    ValueLinq_Standard_ByIndex |  1000 |  5,917.924 ns | 19.4317 ns | 18.1764 ns |  1.73 |    0.01 | 1.9760 |     - |     - |    4144 B |
|                       ValueLinq_Stack_ByIndex |  1000 |  5,797.722 ns | 23.7066 ns | 21.0153 ns |  1.69 |    0.01 | 1.9760 |     - |     - |    4144 B |
|             ValueLinq_SharedPool_Push_ByIndex |  1000 |  4,949.494 ns | 20.9613 ns | 18.5817 ns |  1.44 |    0.01 | 0.9689 |     - |     - |    2040 B |
|             ValueLinq_SharedPool_Pull_ByIndex |  1000 |  6,210.057 ns | 20.3987 ns | 18.0829 ns |  1.81 |    0.01 | 0.9689 |     - |     - |    2040 B |
|        ValueLinq_ValueLambda_Standard_ByIndex |  1000 |  2,593.398 ns | 19.6014 ns | 17.3762 ns |  0.76 |    0.01 | 1.9798 |     - |     - |    4144 B |
|           ValueLinq_ValueLambda_Stack_ByIndex |  1000 |  2,561.199 ns | 12.9151 ns | 11.4489 ns |  0.75 |    0.00 | 1.9798 |     - |     - |    4144 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |  1000 |  2,899.984 ns | 10.1661 ns |  9.5094 ns |  0.85 |    0.00 | 0.9727 |     - |     - |    2040 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |  1000 |  2,499.299 ns | 12.6809 ns |  9.9004 ns |  0.73 |    0.00 | 0.9727 |     - |     - |    2040 B |
|                                       ForLoop |  1000 |  3,427.038 ns | 11.2171 ns |  9.9437 ns |  1.00 |    0.00 | 3.0289 |     - |     - |    6344 B |
|                                   ForeachLoop |  1000 |  4,659.511 ns | 19.7499 ns | 17.5078 ns |  1.36 |    0.01 | 3.0289 |     - |     - |    6344 B |
|                                          Linq |  1000 |  5,404.702 ns | 24.4900 ns | 19.1202 ns |  1.58 |    0.01 | 2.1896 |     - |     - |    4592 B |
|                                    LinqFaster |  1000 |  5,683.553 ns | 23.2881 ns | 21.7837 ns |  1.66 |    0.01 | 3.0289 |     - |     - |    6344 B |
|                                        LinqAF |  1000 | 12,871.808 ns | 32.8659 ns | 29.1348 ns |  3.76 |    0.02 | 3.0060 |     - |     - |    6312 B |
|                                    StructLinq |  1000 |  5,238.031 ns | 18.9250 ns | 14.7754 ns |  1.53 |    0.01 | 1.0147 |     - |     - |    2136 B |
|                          StructLinq_IFunction |  1000 |  2,940.154 ns | 12.1466 ns | 10.7677 ns |  0.86 |    0.00 | 0.9727 |     - |     - |    2040 B |
|                                     Hyperlinq |  1000 |  5,759.197 ns | 14.2645 ns | 11.9115 ns |  1.68 |    0.00 | 0.9689 |     - |     - |    2040 B |
|                           Hyperlinq_IFunction |  1000 |  2,354.424 ns | 17.0884 ns | 15.1484 ns |  0.69 |    0.01 | 0.9727 |     - |     - |    2040 B |
