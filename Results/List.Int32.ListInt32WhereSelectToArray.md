## List.Int32.ListInt32WhereSelectToArray

### Source
[ListInt32WhereSelectToArray.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelectToArray.cs)

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
|                                        Method | Count |         Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------------------------- |------ |-------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                            **ValueLinq_Standard** |    **10** |    **198.02 ns** |  **1.239 ns** |  **1.098 ns** |  **4.30** |    **0.03** | **0.0150** |     **-** |     **-** |      **32 B** |
|                               ValueLinq_Stack |    10 |    151.73 ns |  0.885 ns |  0.739 ns |  3.30 |    0.01 | 0.0150 |     - |     - |      32 B |
|                     ValueLinq_SharedPool_Push |    10 |    376.88 ns |  1.546 ns |  1.291 ns |  8.19 |    0.05 | 0.0153 |     - |     - |      32 B |
|                     ValueLinq_SharedPool_Pull |    10 |    303.35 ns |  0.968 ns |  0.808 ns |  6.59 |    0.03 | 0.0153 |     - |     - |      32 B |
|                ValueLinq_ValueLambda_Standard |    10 |    168.65 ns |  1.661 ns |  1.387 ns |  3.66 |    0.03 | 0.0150 |     - |     - |      32 B |
|                   ValueLinq_ValueLambda_Stack |    10 |    133.79 ns |  1.129 ns |  0.881 ns |  2.91 |    0.02 | 0.0150 |     - |     - |      32 B |
|         ValueLinq_ValueLambda_SharedPool_Push |    10 |    293.88 ns |  1.913 ns |  1.598 ns |  6.38 |    0.05 | 0.0153 |     - |     - |      32 B |
|         ValueLinq_ValueLambda_SharedPool_Pull |    10 |    277.06 ns |  2.819 ns |  2.354 ns |  6.02 |    0.06 | 0.0153 |     - |     - |      32 B |
|                    ValueLinq_Standard_ByIndex |    10 |    167.09 ns |  0.674 ns |  0.563 ns |  3.63 |    0.02 | 0.0153 |     - |     - |      32 B |
|                       ValueLinq_Stack_ByIndex |    10 |    130.22 ns |  0.752 ns |  0.703 ns |  2.83 |    0.02 | 0.0153 |     - |     - |      32 B |
|             ValueLinq_SharedPool_Push_ByIndex |    10 |    381.69 ns |  1.360 ns |  1.136 ns |  8.29 |    0.04 | 0.0153 |     - |     - |      32 B |
|             ValueLinq_SharedPool_Pull_ByIndex |    10 |    267.40 ns |  1.477 ns |  1.309 ns |  5.81 |    0.04 | 0.0153 |     - |     - |      32 B |
|        ValueLinq_ValueLambda_Standard_ByIndex |    10 |    163.63 ns |  1.014 ns |  0.899 ns |  3.56 |    0.02 | 0.0153 |     - |     - |      32 B |
|           ValueLinq_ValueLambda_Stack_ByIndex |    10 |    117.06 ns |  0.627 ns |  0.523 ns |  2.54 |    0.02 | 0.0150 |     - |     - |      32 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |    10 |    299.91 ns |  1.006 ns |  0.892 ns |  6.51 |    0.03 | 0.0153 |     - |     - |      32 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |    10 |    250.96 ns |  1.497 ns |  1.400 ns |  5.45 |    0.04 | 0.0153 |     - |     - |      32 B |
|                                       ForLoop |    10 |     46.04 ns |  0.189 ns |  0.158 ns |  1.00 |    0.00 | 0.0497 |     - |     - |     104 B |
|                                   ForeachLoop |    10 |     61.26 ns |  0.468 ns |  0.391 ns |  1.33 |    0.01 | 0.0497 |     - |     - |     104 B |
|                                          Linq |    10 |    134.42 ns |  0.796 ns |  0.705 ns |  2.92 |    0.02 | 0.1068 |     - |     - |     224 B |
|                                    LinqFaster |    10 |     61.11 ns |  0.596 ns |  0.528 ns |  1.33 |    0.01 | 0.0496 |     - |     - |     104 B |
|                                        LinqAF |    10 |    169.82 ns |  0.788 ns |  0.699 ns |  3.69 |    0.03 | 0.0341 |     - |     - |      72 B |
|                                    StructLinq |    10 |    142.41 ns |  0.762 ns |  0.675 ns |  3.09 |    0.02 | 0.0610 |     - |     - |     128 B |
|                          StructLinq_IFunction |    10 |     90.79 ns |  0.238 ns |  0.186 ns |  1.97 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                     Hyperlinq |    10 |    107.85 ns |  0.684 ns |  0.571 ns |  2.34 |    0.02 | 0.0153 |     - |     - |      32 B |
|                           Hyperlinq_IFunction |    10 |     92.83 ns |  0.367 ns |  0.306 ns |  2.02 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                               |       |              |           |           |       |         |        |       |       |           |
|                            **ValueLinq_Standard** |  **1000** |  **8,076.25 ns** | **30.403 ns** | **25.388 ns** |  **2.32** |    **0.01** | **1.9684** |     **-** |     **-** |   **4,144 B** |
|                               ValueLinq_Stack |  1000 |  7,653.55 ns | 45.193 ns | 37.739 ns |  2.20 |    0.02 | 1.9684 |     - |     - |   4,144 B |
|                     ValueLinq_SharedPool_Push |  1000 |  5,497.18 ns | 31.076 ns | 27.548 ns |  1.58 |    0.01 | 0.9689 |     - |     - |   2,040 B |
|                     ValueLinq_SharedPool_Pull |  1000 |  7,909.32 ns | 42.836 ns | 35.770 ns |  2.27 |    0.02 | 0.9613 |     - |     - |   2,040 B |
|                ValueLinq_ValueLambda_Standard |  1000 |  8,334.65 ns | 58.595 ns | 45.747 ns |  2.40 |    0.02 | 1.9684 |     - |     - |   4,144 B |
|                   ValueLinq_ValueLambda_Stack |  1000 |  8,347.11 ns | 29.922 ns | 23.361 ns |  2.40 |    0.02 | 1.9684 |     - |     - |   4,144 B |
|         ValueLinq_ValueLambda_SharedPool_Push |  1000 |  3,202.30 ns | 28.760 ns | 25.495 ns |  0.92 |    0.00 | 0.9727 |     - |     - |   2,040 B |
|         ValueLinq_ValueLambda_SharedPool_Pull |  1000 |  8,149.96 ns | 33.599 ns | 29.785 ns |  2.34 |    0.01 | 0.9613 |     - |     - |   2,040 B |
|                    ValueLinq_Standard_ByIndex |  1000 |  6,568.32 ns | 37.262 ns | 33.032 ns |  1.89 |    0.02 | 1.9760 |     - |     - |   4,144 B |
|                       ValueLinq_Stack_ByIndex |  1000 |  6,495.53 ns | 69.191 ns | 64.722 ns |  1.86 |    0.02 | 1.9760 |     - |     - |   4,144 B |
|             ValueLinq_SharedPool_Push_ByIndex |  1000 |  5,795.55 ns | 17.218 ns | 14.377 ns |  1.66 |    0.01 | 0.9689 |     - |     - |   2,040 B |
|             ValueLinq_SharedPool_Pull_ByIndex |  1000 |  6,366.80 ns | 36.863 ns | 32.678 ns |  1.83 |    0.01 | 0.9689 |     - |     - |   2,040 B |
|        ValueLinq_ValueLambda_Standard_ByIndex |  1000 |  2,660.60 ns | 19.892 ns | 17.634 ns |  0.76 |    0.01 | 1.9798 |     - |     - |   4,144 B |
|           ValueLinq_ValueLambda_Stack_ByIndex |  1000 |  2,637.65 ns | 19.566 ns | 16.339 ns |  0.76 |    0.01 | 1.9798 |     - |     - |   4,144 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |  1000 |  3,121.16 ns | 31.078 ns | 27.549 ns |  0.90 |    0.01 | 0.9727 |     - |     - |   2,040 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |  1000 |  2,542.07 ns | 19.607 ns | 18.340 ns |  0.73 |    0.01 | 0.9727 |     - |     - |   2,040 B |
|                                       ForLoop |  1000 |  3,484.24 ns | 25.811 ns | 22.881 ns |  1.00 |    0.00 | 3.0289 |     - |     - |   6,344 B |
|                                   ForeachLoop |  1000 |  5,018.31 ns | 30.450 ns | 26.993 ns |  1.44 |    0.01 | 3.0289 |     - |     - |   6,344 B |
|                                          Linq |  1000 |  5,972.64 ns | 58.645 ns | 54.856 ns |  1.71 |    0.02 | 2.1896 |     - |     - |   4,592 B |
|                                    LinqFaster |  1000 |  6,078.80 ns | 37.818 ns | 33.525 ns |  1.74 |    0.02 | 3.0289 |     - |     - |   6,344 B |
|                                        LinqAF |  1000 | 13,846.89 ns | 40.933 ns | 34.181 ns |  3.97 |    0.03 | 3.0060 |     - |     - |   6,312 B |
|                                    StructLinq |  1000 |  6,150.56 ns | 18.345 ns | 16.262 ns |  1.77 |    0.01 | 1.0147 |     - |     - |   2,136 B |
|                          StructLinq_IFunction |  1000 |  3,112.52 ns | 24.188 ns | 21.442 ns |  0.89 |    0.01 | 0.9727 |     - |     - |   2,040 B |
|                                     Hyperlinq |  1000 |  5,226.15 ns | 22.975 ns | 19.185 ns |  1.50 |    0.01 | 0.9689 |     - |     - |   2,040 B |
|                           Hyperlinq_IFunction |  1000 |  2,979.83 ns | 16.962 ns | 15.866 ns |  0.86 |    0.01 | 0.9727 |     - |     - |   2,040 B |
