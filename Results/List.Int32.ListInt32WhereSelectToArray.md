## List.Int32.ListInt32WhereSelectToArray

### Source
[ListInt32WhereSelectToArray.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelectToArray.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta43](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta43)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1516-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.1.21103.13
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|                                        Method | Count |         Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------------------------- |------ |-------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                            **ValueLinq_Standard** |    **10** |    **190.87 ns** |  **0.679 ns** |  **0.602 ns** |  **4.76** |    **0.03** | **0.0150** |     **-** |     **-** |      **32 B** |
|                               ValueLinq_Stack |    10 |    148.66 ns |  0.567 ns |  0.474 ns |  3.71 |    0.02 | 0.0153 |     - |     - |      32 B |
|                     ValueLinq_SharedPool_Push |    10 |    383.49 ns |  2.924 ns |  2.735 ns |  9.57 |    0.08 | 0.0153 |     - |     - |      32 B |
|                     ValueLinq_SharedPool_Pull |    10 |    298.10 ns |  1.620 ns |  1.436 ns |  7.44 |    0.07 | 0.0153 |     - |     - |      32 B |
|                ValueLinq_ValueLambda_Standard |    10 |    166.67 ns |  0.597 ns |  0.558 ns |  4.16 |    0.02 | 0.0150 |     - |     - |      32 B |
|                   ValueLinq_ValueLambda_Stack |    10 |    130.83 ns |  0.407 ns |  0.360 ns |  3.27 |    0.02 | 0.0153 |     - |     - |      32 B |
|         ValueLinq_ValueLambda_SharedPool_Push |    10 |    299.21 ns |  0.691 ns |  0.613 ns |  7.47 |    0.04 | 0.0153 |     - |     - |      32 B |
|         ValueLinq_ValueLambda_SharedPool_Pull |    10 |    273.76 ns |  0.925 ns |  0.820 ns |  6.83 |    0.04 | 0.0153 |     - |     - |      32 B |
|                    ValueLinq_Standard_ByIndex |    10 |    165.43 ns |  0.371 ns |  0.310 ns |  4.13 |    0.02 | 0.0150 |     - |     - |      32 B |
|                       ValueLinq_Stack_ByIndex |    10 |    128.05 ns |  0.505 ns |  0.472 ns |  3.20 |    0.02 | 0.0150 |     - |     - |      32 B |
|             ValueLinq_SharedPool_Push_ByIndex |    10 |    382.39 ns |  0.839 ns |  0.744 ns |  9.55 |    0.05 | 0.0153 |     - |     - |      32 B |
|             ValueLinq_SharedPool_Pull_ByIndex |    10 |    260.40 ns |  0.660 ns |  0.585 ns |  6.50 |    0.04 | 0.0153 |     - |     - |      32 B |
|        ValueLinq_ValueLambda_Standard_ByIndex |    10 |    149.72 ns |  0.770 ns |  0.721 ns |  3.74 |    0.02 | 0.0150 |     - |     - |      32 B |
|           ValueLinq_ValueLambda_Stack_ByIndex |    10 |    114.16 ns |  0.334 ns |  0.297 ns |  2.85 |    0.02 | 0.0151 |     - |     - |      32 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |    10 |    298.28 ns |  1.018 ns |  0.903 ns |  7.45 |    0.03 | 0.0153 |     - |     - |      32 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |    10 |    254.03 ns |  1.248 ns |  1.106 ns |  6.34 |    0.04 | 0.0153 |     - |     - |      32 B |
|                                       ForLoop |    10 |     40.06 ns |  0.244 ns |  0.216 ns |  1.00 |    0.00 | 0.0497 |     - |     - |     104 B |
|                                   ForeachLoop |    10 |     57.87 ns |  0.284 ns |  0.251 ns |  1.44 |    0.01 | 0.0497 |     - |     - |     104 B |
|                                          Linq |    10 |    128.47 ns |  0.631 ns |  0.560 ns |  3.21 |    0.02 | 0.1070 |     - |     - |     224 B |
|                                    LinqFaster |    10 |     61.59 ns |  0.274 ns |  0.229 ns |  1.54 |    0.01 | 0.0496 |     - |     - |     104 B |
|                                        LinqAF |    10 |    166.81 ns |  0.989 ns |  0.877 ns |  4.16 |    0.03 | 0.0341 |     - |     - |      72 B |
|                                    StructLinq |    10 |    142.18 ns |  0.577 ns |  0.511 ns |  3.55 |    0.02 | 0.0610 |     - |     - |     128 B |
|                          StructLinq_IFunction |    10 |     91.62 ns |  0.340 ns |  0.301 ns |  2.29 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                     Hyperlinq |    10 |    107.84 ns |  0.299 ns |  0.265 ns |  2.69 |    0.02 | 0.0153 |     - |     - |      32 B |
|                           Hyperlinq_IFunction |    10 |     84.01 ns |  0.230 ns |  0.203 ns |  2.10 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                               |       |              |           |           |       |         |        |       |       |           |
|                            **ValueLinq_Standard** |  **1000** |  **7,917.32 ns** | **38.895 ns** | **34.479 ns** |  **2.51** |    **0.01** | **1.9684** |     **-** |     **-** |   **4,144 B** |
|                               ValueLinq_Stack |  1000 |  7,483.78 ns | 21.742 ns | 19.273 ns |  2.38 |    0.01 | 1.9760 |     - |     - |   4,144 B |
|                     ValueLinq_SharedPool_Push |  1000 |  5,391.97 ns | 18.447 ns | 15.404 ns |  1.71 |    0.01 | 0.9689 |     - |     - |   2,040 B |
|                     ValueLinq_SharedPool_Pull |  1000 |  7,836.09 ns | 25.542 ns | 23.892 ns |  2.49 |    0.02 | 0.9613 |     - |     - |   2,040 B |
|                ValueLinq_ValueLambda_Standard |  1000 |  8,122.11 ns | 33.822 ns | 29.982 ns |  2.58 |    0.02 | 1.9684 |     - |     - |   4,144 B |
|                   ValueLinq_ValueLambda_Stack |  1000 |  8,124.95 ns | 40.315 ns | 35.738 ns |  2.58 |    0.02 | 1.9684 |     - |     - |   4,144 B |
|         ValueLinq_ValueLambda_SharedPool_Push |  1000 |  2,760.41 ns | 17.464 ns | 15.481 ns |  0.88 |    0.01 | 0.9727 |     - |     - |   2,040 B |
|         ValueLinq_ValueLambda_SharedPool_Pull |  1000 |  8,290.19 ns | 28.461 ns | 25.230 ns |  2.63 |    0.01 | 0.9613 |     - |     - |   2,040 B |
|                    ValueLinq_Standard_ByIndex |  1000 |  6,298.62 ns | 27.150 ns | 25.396 ns |  2.00 |    0.02 | 1.9760 |     - |     - |   4,144 B |
|                       ValueLinq_Stack_ByIndex |  1000 |  6,342.66 ns | 42.592 ns | 39.841 ns |  2.01 |    0.02 | 1.9760 |     - |     - |   4,144 B |
|             ValueLinq_SharedPool_Push_ByIndex |  1000 |  5,753.30 ns | 17.663 ns | 15.658 ns |  1.83 |    0.01 | 0.9689 |     - |     - |   2,040 B |
|             ValueLinq_SharedPool_Pull_ByIndex |  1000 |  6,412.99 ns | 28.500 ns | 25.264 ns |  2.04 |    0.01 | 0.9689 |     - |     - |   2,040 B |
|        ValueLinq_ValueLambda_Standard_ByIndex |  1000 |  2,561.24 ns | 13.827 ns | 12.257 ns |  0.81 |    0.01 | 1.9798 |     - |     - |   4,144 B |
|           ValueLinq_ValueLambda_Stack_ByIndex |  1000 |  3,377.14 ns | 26.331 ns | 23.342 ns |  1.07 |    0.01 | 1.9798 |     - |     - |   4,144 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |  1000 |  2,834.63 ns | 23.308 ns | 19.463 ns |  0.90 |    0.01 | 0.9727 |     - |     - |   2,040 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |  1000 |  2,599.57 ns | 38.746 ns | 36.243 ns |  0.83 |    0.01 | 0.9727 |     - |     - |   2,040 B |
|                                       ForLoop |  1000 |  3,148.85 ns | 15.490 ns | 13.732 ns |  1.00 |    0.00 | 3.0289 |     - |     - |   6,344 B |
|                                   ForeachLoop |  1000 |  4,807.33 ns | 24.628 ns | 21.832 ns |  1.53 |    0.01 | 3.0289 |     - |     - |   6,344 B |
|                                          Linq |  1000 |  5,530.51 ns | 24.015 ns | 21.288 ns |  1.76 |    0.01 | 2.1896 |     - |     - |   4,592 B |
|                                    LinqFaster |  1000 |  6,150.77 ns | 30.595 ns | 28.618 ns |  1.95 |    0.01 | 3.0289 |     - |     - |   6,344 B |
|                                        LinqAF |  1000 | 12,946.73 ns | 37.829 ns | 31.589 ns |  4.11 |    0.02 | 3.0060 |     - |     - |   6,312 B |
|                                    StructLinq |  1000 |  5,806.72 ns | 29.589 ns | 27.678 ns |  1.84 |    0.01 | 1.0147 |     - |     - |   2,136 B |
|                          StructLinq_IFunction |  1000 |  3,070.65 ns | 29.971 ns | 28.035 ns |  0.97 |    0.01 | 0.9727 |     - |     - |   2,040 B |
|                                     Hyperlinq |  1000 |  5,347.47 ns | 29.838 ns | 26.450 ns |  1.70 |    0.01 | 0.9689 |     - |     - |   2,040 B |
|                           Hyperlinq_IFunction |  1000 |  2,430.85 ns | 11.275 ns | 10.547 ns |  0.77 |    0.00 | 0.9727 |     - |     - |   2,040 B |
