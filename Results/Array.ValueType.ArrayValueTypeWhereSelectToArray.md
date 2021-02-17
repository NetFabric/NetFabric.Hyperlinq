## Array.ValueType.ArrayValueTypeWhereSelectToArray

### Source
[ArrayValueTypeWhereSelectToArray.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelectToArray.cs)

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
|                                Method | Count |          Mean |       Error |      StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |--------------:|------------:|------------:|------:|--------:|--------:|------:|------:|----------:|
|                    **ValueLinq_Standard** |     **0** |     **57.631 ns** |   **0.2124 ns** |   **0.1987 ns** |  **7.78** |    **0.07** |       **-** |     **-** |     **-** |         **-** |
|                       ValueLinq_Stack |     0 |     76.042 ns |   0.2301 ns |   0.2152 ns | 10.26 |    0.09 |       - |     - |     - |         - |
|             ValueLinq_SharedPool_Push |     0 |    296.916 ns |   0.6903 ns |   0.6457 ns | 40.07 |    0.37 |       - |     - |     - |         - |
|             ValueLinq_SharedPool_Pull |     0 |    227.537 ns |   1.0482 ns |   0.9292 ns | 30.69 |    0.32 |       - |     - |     - |         - |
|                ValueLinq_Ref_Standard |     0 |     53.868 ns |   0.0905 ns |   0.0802 ns |  7.27 |    0.06 |       - |     - |     - |         - |
|                   ValueLinq_Ref_Stack |     0 |     71.815 ns |   0.1131 ns |   0.1003 ns |  9.69 |    0.08 |       - |     - |     - |         - |
|         ValueLinq_Ref_SharedPool_Push |     0 |    220.486 ns |   0.8975 ns |   0.8396 ns | 29.76 |    0.30 |       - |     - |     - |         - |
|         ValueLinq_Ref_SharedPool_Pull |     0 |    221.272 ns |   0.8054 ns |   0.7140 ns | 29.84 |    0.30 |       - |     - |     - |         - |
|        ValueLinq_ValueLambda_Standard |     0 |     69.345 ns |   0.1579 ns |   0.1477 ns |  9.36 |    0.08 |       - |     - |     - |         - |
|           ValueLinq_ValueLambda_Stack |     0 |     77.716 ns |   0.2138 ns |   0.2000 ns | 10.49 |    0.10 |       - |     - |     - |         - |
| ValueLinq_ValueLambda_SharedPool_Push |     0 |    236.275 ns |   1.0022 ns |   0.9375 ns | 31.89 |    0.27 |       - |     - |     - |         - |
| ValueLinq_ValueLambda_SharedPool_Pull |     0 |    227.609 ns |   1.2860 ns |   1.1400 ns | 30.70 |    0.32 |       - |     - |     - |         - |
|                               ForLoop |     0 |      7.411 ns |   0.0685 ns |   0.0641 ns |  1.00 |    0.00 |  0.0153 |     - |     - |      32 B |
|                           ForeachLoop |     0 |      7.523 ns |   0.0422 ns |   0.0374 ns |  1.01 |    0.01 |  0.0153 |     - |     - |      32 B |
|                                  Linq |     0 |     28.886 ns |   0.1282 ns |   0.1070 ns |  3.89 |    0.04 |       - |     - |     - |         - |
|                            LinqFaster |     0 |      8.776 ns |   0.0584 ns |   0.0518 ns |  1.18 |    0.01 |  0.0115 |     - |     - |      24 B |
|                                LinqAF |     0 |     97.198 ns |   0.4344 ns |   0.4063 ns | 13.12 |    0.12 |  0.0994 |     - |     - |     208 B |
|                            StructLinq |     0 |     64.413 ns |   0.4593 ns |   0.4071 ns |  8.69 |    0.11 |  0.0573 |     - |     - |     120 B |
|                  StructLinq_IFunction |     0 |     48.221 ns |   0.2904 ns |   0.2716 ns |  6.51 |    0.07 |  0.0114 |     - |     - |      24 B |
|                             Hyperlinq |     0 |     47.897 ns |   0.1695 ns |   0.1586 ns |  6.46 |    0.06 |  0.0114 |     - |     - |      24 B |
|                   Hyperlinq_IFunction |     0 |     44.923 ns |   0.1491 ns |   0.1322 ns |  6.06 |    0.05 |  0.0114 |     - |     - |      24 B |
|                                       |       |               |             |             |       |         |         |       |       |           |
|                    **ValueLinq_Standard** |    **10** |    **181.345 ns** |   **0.6750 ns** |   **0.5984 ns** |  **3.26** |    **0.02** |  **0.0496** |     **-** |     **-** |     **104 B** |
|                       ValueLinq_Stack |    10 |    143.552 ns |   0.7362 ns |   0.6886 ns |  2.58 |    0.02 |  0.0496 |     - |     - |     104 B |
|             ValueLinq_SharedPool_Push |    10 |    393.013 ns |   1.7069 ns |   1.4253 ns |  7.07 |    0.04 |  0.0496 |     - |     - |     104 B |
|             ValueLinq_SharedPool_Pull |    10 |    288.123 ns |   1.4785 ns |   1.3830 ns |  5.18 |    0.04 |  0.0496 |     - |     - |     104 B |
|                ValueLinq_Ref_Standard |    10 |    171.040 ns |   0.9642 ns |   0.8052 ns |  3.08 |    0.02 |  0.0496 |     - |     - |     104 B |
|                   ValueLinq_Ref_Stack |    10 |    136.698 ns |   0.4979 ns |   0.4414 ns |  2.46 |    0.02 |  0.0496 |     - |     - |     104 B |
|         ValueLinq_Ref_SharedPool_Push |    10 |    311.546 ns |   1.0013 ns |   0.8876 ns |  5.60 |    0.03 |  0.0496 |     - |     - |     104 B |
|         ValueLinq_Ref_SharedPool_Pull |    10 |    286.579 ns |   0.8591 ns |   0.8036 ns |  5.15 |    0.04 |  0.0496 |     - |     - |     104 B |
|        ValueLinq_ValueLambda_Standard |    10 |    179.148 ns |   0.8644 ns |   0.7218 ns |  3.22 |    0.02 |  0.0496 |     - |     - |     104 B |
|           ValueLinq_ValueLambda_Stack |    10 |    145.565 ns |   0.9288 ns |   0.8688 ns |  2.62 |    0.03 |  0.0496 |     - |     - |     104 B |
| ValueLinq_ValueLambda_SharedPool_Push |    10 |    322.263 ns |   0.5321 ns |   0.4154 ns |  5.80 |    0.03 |  0.0496 |     - |     - |     104 B |
| ValueLinq_ValueLambda_SharedPool_Pull |    10 |    303.871 ns |   0.7714 ns |   0.6442 ns |  5.47 |    0.03 |  0.0496 |     - |     - |     104 B |
|                               ForLoop |    10 |     55.596 ns |   0.3723 ns |   0.3300 ns |  1.00 |    0.00 |  0.1529 |     - |     - |     320 B |
|                           ForeachLoop |    10 |     61.549 ns |   0.3962 ns |   0.3706 ns |  1.11 |    0.01 |  0.1529 |     - |     - |     320 B |
|                                  Linq |    10 |    154.386 ns |   0.8245 ns |   0.7309 ns |  2.78 |    0.02 |  0.2177 |     - |     - |     456 B |
|                            LinqFaster |    10 |     73.893 ns |   0.7778 ns |   0.6895 ns |  1.33 |    0.01 |  0.2524 |     - |     - |     528 B |
|                                LinqAF |    10 |    200.856 ns |   1.7844 ns |   1.5818 ns |  3.61 |    0.04 |  0.1376 |     - |     - |     288 B |
|                            StructLinq |    10 |    138.231 ns |   0.5956 ns |   0.5572 ns |  2.49 |    0.02 |  0.0956 |     - |     - |     200 B |
|                  StructLinq_IFunction |    10 |    108.354 ns |   0.7956 ns |   0.6644 ns |  1.95 |    0.01 |  0.0497 |     - |     - |     104 B |
|                             Hyperlinq |    10 |    119.010 ns |   0.6093 ns |   0.5401 ns |  2.14 |    0.01 |  0.0496 |     - |     - |     104 B |
|                   Hyperlinq_IFunction |    10 |    103.738 ns |   0.3075 ns |   0.2726 ns |  1.87 |    0.01 |  0.0497 |     - |     - |     104 B |
|                                       |       |               |             |             |       |         |         |       |       |           |
|                    **ValueLinq_Standard** |  **1000** | **13,580.967 ns** |  **47.8793 ns** |  **44.7864 ns** |  **1.47** |    **0.01** | **19.0430** |     **-** |     **-** |   **40104 B** |
|                       ValueLinq_Stack |  1000 | 11,899.041 ns |  59.8569 ns |  55.9902 ns |  1.29 |    0.01 | 19.0430 |     - |     - |   40104 B |
|             ValueLinq_SharedPool_Push |  1000 | 13,825.762 ns |  51.0199 ns |  45.2278 ns |  1.50 |    0.01 |  9.6130 |     - |     - |   20144 B |
|             ValueLinq_SharedPool_Pull |  1000 | 11,382.413 ns |  28.9928 ns |  25.7013 ns |  1.23 |    0.00 |  9.6130 |     - |     - |   20144 B |
|                ValueLinq_Ref_Standard |  1000 | 11,745.093 ns |  54.2233 ns |  50.7205 ns |  1.27 |    0.01 | 19.0430 |     - |     - |   40104 B |
|                   ValueLinq_Ref_Stack |  1000 | 11,824.343 ns |  35.5869 ns |  31.5468 ns |  1.28 |    0.00 | 19.0430 |     - |     - |   40104 B |
|         ValueLinq_Ref_SharedPool_Push |  1000 | 12,320.473 ns |  64.2739 ns |  56.9771 ns |  1.33 |    0.01 |  9.6130 |     - |     - |   20144 B |
|         ValueLinq_Ref_SharedPool_Pull |  1000 | 11,319.927 ns |  51.6344 ns |  45.7726 ns |  1.23 |    0.01 |  9.6130 |     - |     - |   20144 B |
|        ValueLinq_ValueLambda_Standard |  1000 |  9,869.075 ns |  59.6822 ns |  55.8267 ns |  1.07 |    0.01 | 19.0430 |     - |     - |   40104 B |
|           ValueLinq_ValueLambda_Stack |  1000 | 10,014.563 ns |  38.5169 ns |  36.0288 ns |  1.08 |    0.00 | 19.0430 |     - |     - |   40104 B |
| ValueLinq_ValueLambda_SharedPool_Push |  1000 |  9,315.968 ns |  38.8277 ns |  36.3194 ns |  1.01 |    0.01 |  9.6130 |     - |     - |   20144 B |
| ValueLinq_ValueLambda_SharedPool_Pull |  1000 |  9,715.038 ns |  53.6667 ns |  50.1999 ns |  1.05 |    0.01 |  9.6130 |     - |     - |   20144 B |
|                               ForLoop |  1000 |  9,236.024 ns |  31.5343 ns |  26.3326 ns |  1.00 |    0.00 | 29.1138 |     - |     - |   61168 B |
|                           ForeachLoop |  1000 |  9,358.816 ns |  26.4472 ns |  22.0846 ns |  1.01 |    0.00 | 29.1138 |     - |     - |   61168 B |
|                                  Linq |  1000 | 12,823.899 ns |  78.4161 ns |  69.5138 ns |  1.39 |    0.01 | 19.6075 |     - |     - |   41288 B |
|                            LinqFaster |  1000 | 10,332.062 ns |  56.1552 ns |  52.5276 ns |  1.12 |    0.01 | 28.5645 |     - |     - |   60168 B |
|                                LinqAF |  1000 | 24,622.376 ns | 159.1561 ns | 148.8747 ns |  2.66 |    0.02 | 29.1138 |     - |     - |   61136 B |
|                            StructLinq |  1000 | 12,529.136 ns |  90.0671 ns |  79.8421 ns |  1.36 |    0.01 |  9.6130 |     - |     - |   20240 B |
|                  StructLinq_IFunction |  1000 |  7,463.021 ns |  27.9585 ns |  24.7845 ns |  0.81 |    0.00 |  9.6130 |     - |     - |   20144 B |
|                             Hyperlinq |  1000 |  9,394.042 ns |  55.5733 ns |  51.9833 ns |  1.02 |    0.01 |  9.6130 |     - |     - |   20144 B |
|                   Hyperlinq_IFunction |  1000 |  7,216.652 ns | 135.4516 ns | 218.7292 ns |  0.80 |    0.03 |  9.6130 |     - |     - |   20144 B |
