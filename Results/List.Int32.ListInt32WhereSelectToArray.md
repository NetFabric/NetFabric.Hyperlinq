## List.Int32.ListInt32WhereSelectToArray

### Source
[ListInt32WhereSelectToArray.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelectToArray.cs)

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
|                                        Method | Count |         Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------------------------- |------ |-------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                            **ValueLinq_Standard** |    **10** |    **185.75 ns** |  **0.451 ns** |  **0.400 ns** |  **4.76** |    **0.01** | **0.0153** |     **-** |     **-** |      **32 B** |
|                               ValueLinq_Stack |    10 |    148.14 ns |  0.674 ns |  0.631 ns |  3.79 |    0.02 | 0.0150 |     - |     - |      32 B |
|                     ValueLinq_SharedPool_Push |    10 |    370.61 ns |  0.857 ns |  0.802 ns |  9.50 |    0.03 | 0.0153 |     - |     - |      32 B |
|                     ValueLinq_SharedPool_Pull |    10 |    275.86 ns |  0.637 ns |  0.596 ns |  7.07 |    0.03 | 0.0153 |     - |     - |      32 B |
|                ValueLinq_ValueLambda_Standard |    10 |    161.10 ns |  0.255 ns |  0.226 ns |  4.13 |    0.01 | 0.0150 |     - |     - |      32 B |
|                   ValueLinq_ValueLambda_Stack |    10 |    126.60 ns |  0.451 ns |  0.352 ns |  3.24 |    0.01 | 0.0150 |     - |     - |      32 B |
|         ValueLinq_ValueLambda_SharedPool_Push |    10 |    284.46 ns |  0.443 ns |  0.346 ns |  7.29 |    0.02 | 0.0153 |     - |     - |      32 B |
|         ValueLinq_ValueLambda_SharedPool_Pull |    10 |    271.24 ns |  0.774 ns |  0.724 ns |  6.95 |    0.03 | 0.0153 |     - |     - |      32 B |
|                    ValueLinq_Standard_ByIndex |    10 |    160.46 ns |  0.393 ns |  0.348 ns |  4.11 |    0.01 | 0.0153 |     - |     - |      32 B |
|                       ValueLinq_Stack_ByIndex |    10 |    124.04 ns |  0.357 ns |  0.298 ns |  3.18 |    0.01 | 0.0153 |     - |     - |      32 B |
|             ValueLinq_SharedPool_Push_ByIndex |    10 |    376.03 ns |  1.056 ns |  0.882 ns |  9.63 |    0.02 | 0.0153 |     - |     - |      32 B |
|             ValueLinq_SharedPool_Pull_ByIndex |    10 |    256.50 ns |  0.373 ns |  0.291 ns |  6.57 |    0.02 | 0.0153 |     - |     - |      32 B |
|        ValueLinq_ValueLambda_Standard_ByIndex |    10 |    145.54 ns |  0.543 ns |  0.481 ns |  3.73 |    0.02 | 0.0153 |     - |     - |      32 B |
|           ValueLinq_ValueLambda_Stack_ByIndex |    10 |    113.10 ns |  0.198 ns |  0.165 ns |  2.90 |    0.01 | 0.0153 |     - |     - |      32 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |    10 |    293.90 ns |  0.549 ns |  0.487 ns |  7.53 |    0.02 | 0.0153 |     - |     - |      32 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |    10 |    244.55 ns |  0.892 ns |  0.834 ns |  6.26 |    0.03 | 0.0153 |     - |     - |      32 B |
|                                       ForLoop |    10 |     39.04 ns |  0.114 ns |  0.095 ns |  1.00 |    0.00 | 0.0497 |     - |     - |     104 B |
|                                   ForeachLoop |    10 |     59.47 ns |  0.220 ns |  0.183 ns |  1.52 |    0.01 | 0.0497 |     - |     - |     104 B |
|                                          Linq |    10 |    124.10 ns |  0.459 ns |  0.407 ns |  3.18 |    0.01 | 0.1068 |     - |     - |     224 B |
|                                    LinqFaster |    10 |     55.93 ns |  0.163 ns |  0.136 ns |  1.43 |    0.01 | 0.0497 |     - |     - |     104 B |
|                                        LinqAF |    10 |    161.78 ns |  0.499 ns |  0.443 ns |  4.14 |    0.02 | 0.0343 |     - |     - |      72 B |
|                                    StructLinq |    10 |    126.06 ns |  0.792 ns |  0.741 ns |  3.23 |    0.02 | 0.0610 |     - |     - |     128 B |
|                          StructLinq_IFunction |    10 |     89.26 ns |  0.334 ns |  0.296 ns |  2.29 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                     Hyperlinq |    10 |    104.28 ns |  0.443 ns |  0.393 ns |  2.67 |    0.01 | 0.0153 |     - |     - |      32 B |
|                           Hyperlinq_IFunction |    10 |     83.86 ns |  0.404 ns |  0.358 ns |  2.15 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                               |       |              |           |           |       |         |        |       |       |           |
|                            **ValueLinq_Standard** |  **1000** |  **7,745.50 ns** | **22.892 ns** | **17.873 ns** |  **2.38** |    **0.01** | **1.9684** |     **-** |     **-** |   **4,144 B** |
|                               ValueLinq_Stack |  1000 |  7,407.17 ns | 17.227 ns | 15.271 ns |  2.28 |    0.01 | 1.9760 |     - |     - |   4,144 B |
|                     ValueLinq_SharedPool_Push |  1000 |  5,480.23 ns | 19.378 ns | 17.179 ns |  1.68 |    0.01 | 0.9689 |     - |     - |   2,040 B |
|                     ValueLinq_SharedPool_Pull |  1000 |  8,297.17 ns | 22.635 ns | 20.065 ns |  2.55 |    0.01 | 0.9613 |     - |     - |   2,040 B |
|                ValueLinq_ValueLambda_Standard |  1000 |  7,833.70 ns | 23.421 ns | 21.908 ns |  2.41 |    0.01 | 1.9684 |     - |     - |   4,144 B |
|                   ValueLinq_ValueLambda_Stack |  1000 |  7,981.50 ns | 28.705 ns | 26.851 ns |  2.46 |    0.01 | 1.9684 |     - |     - |   4,144 B |
|         ValueLinq_ValueLambda_SharedPool_Push |  1000 |  3,713.67 ns | 12.451 ns | 11.038 ns |  1.14 |    0.00 | 0.9727 |     - |     - |   2,040 B |
|         ValueLinq_ValueLambda_SharedPool_Pull |  1000 |  7,688.70 ns | 18.573 ns | 17.373 ns |  2.37 |    0.01 | 0.9613 |     - |     - |   2,040 B |
|                    ValueLinq_Standard_ByIndex |  1000 |  6,348.51 ns | 22.211 ns | 19.690 ns |  1.95 |    0.01 | 1.9760 |     - |     - |   4,144 B |
|                       ValueLinq_Stack_ByIndex |  1000 |  5,727.29 ns | 14.242 ns | 13.322 ns |  1.76 |    0.01 | 1.9760 |     - |     - |   4,144 B |
|             ValueLinq_SharedPool_Push_ByIndex |  1000 |  5,358.51 ns | 15.296 ns | 12.773 ns |  1.65 |    0.01 | 0.9689 |     - |     - |   2,040 B |
|             ValueLinq_SharedPool_Pull_ByIndex |  1000 |  7,574.99 ns | 16.411 ns | 13.704 ns |  2.33 |    0.01 | 0.9689 |     - |     - |   2,040 B |
|        ValueLinq_ValueLambda_Standard_ByIndex |  1000 |  2,444.70 ns |  9.457 ns |  8.383 ns |  0.75 |    0.00 | 1.9798 |     - |     - |   4,144 B |
|           ValueLinq_ValueLambda_Stack_ByIndex |  1000 |  2,410.62 ns |  9.201 ns |  7.683 ns |  0.74 |    0.00 | 1.9798 |     - |     - |   4,144 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |  1000 |  2,887.48 ns |  9.148 ns |  8.109 ns |  0.89 |    0.00 | 0.9727 |     - |     - |   2,040 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |  1000 |  2,675.31 ns |  8.911 ns |  7.899 ns |  0.82 |    0.00 | 0.9727 |     - |     - |   2,040 B |
|                                       ForLoop |  1000 |  3,250.02 ns | 13.589 ns | 10.609 ns |  1.00 |    0.00 | 3.0289 |     - |     - |   6,344 B |
|                                   ForeachLoop |  1000 |  4,921.72 ns | 18.499 ns | 14.442 ns |  1.51 |    0.01 | 3.0289 |     - |     - |   6,344 B |
|                                          Linq |  1000 |  5,734.58 ns | 23.085 ns | 20.465 ns |  1.76 |    0.01 | 2.1896 |     - |     - |   4,592 B |
|                                    LinqFaster |  1000 |  5,429.56 ns | 28.511 ns | 23.808 ns |  1.67 |    0.01 | 3.0289 |     - |     - |   6,344 B |
|                                        LinqAF |  1000 | 13,050.02 ns | 28.387 ns | 25.164 ns |  4.02 |    0.01 | 3.0060 |     - |     - |   6,312 B |
|                                    StructLinq |  1000 |  5,481.64 ns | 23.691 ns | 19.783 ns |  1.69 |    0.01 | 1.0147 |     - |     - |   2,136 B |
|                          StructLinq_IFunction |  1000 |  2,734.98 ns |  9.478 ns |  8.402 ns |  0.84 |    0.00 | 0.9727 |     - |     - |   2,040 B |
|                                     Hyperlinq |  1000 |  5,494.40 ns | 20.931 ns | 17.479 ns |  1.69 |    0.01 | 0.9689 |     - |     - |   2,040 B |
|                           Hyperlinq_IFunction |  1000 |  2,382.20 ns | 11.393 ns |  9.514 ns |  0.73 |    0.00 | 0.9727 |     - |     - |   2,040 B |
