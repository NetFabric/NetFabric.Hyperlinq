## List.Int32.ListInt32WhereSelectToList

### Source
[ListInt32WhereSelectToList.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelectToList.cs)

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
|                            **ValueLinq_Standard** |    **10** |    **214.47 ns** |  **0.541 ns** |  **0.479 ns** |  **6.60** |    **0.03** | **0.0305** |     **-** |     **-** |      **64 B** |
|                               ValueLinq_Stack |    10 |    177.41 ns |  0.604 ns |  0.535 ns |  5.46 |    0.02 | 0.0303 |     - |     - |      64 B |
|                     ValueLinq_SharedPool_Push |    10 |    373.32 ns |  1.427 ns |  1.265 ns | 11.49 |    0.06 | 0.0305 |     - |     - |      64 B |
|                     ValueLinq_SharedPool_Pull |    10 |    294.50 ns |  1.946 ns |  1.725 ns |  9.07 |    0.06 | 0.0305 |     - |     - |      64 B |
|                ValueLinq_ValueLambda_Standard |    10 |    191.24 ns |  0.615 ns |  0.545 ns |  5.89 |    0.03 | 0.0305 |     - |     - |      64 B |
|                   ValueLinq_ValueLambda_Stack |    10 |    154.60 ns |  0.480 ns |  0.401 ns |  4.76 |    0.02 | 0.0305 |     - |     - |      64 B |
|         ValueLinq_ValueLambda_SharedPool_Push |    10 |    298.95 ns |  1.304 ns |  1.089 ns |  9.20 |    0.05 | 0.0305 |     - |     - |      64 B |
|         ValueLinq_ValueLambda_SharedPool_Pull |    10 |    281.31 ns |  0.720 ns |  0.638 ns |  8.66 |    0.03 | 0.0305 |     - |     - |      64 B |
|                    ValueLinq_Standard_ByIndex |    10 |    189.50 ns |  0.625 ns |  0.554 ns |  5.83 |    0.03 | 0.0303 |     - |     - |      64 B |
|                       ValueLinq_Stack_ByIndex |    10 |    151.40 ns |  0.728 ns |  0.646 ns |  4.66 |    0.02 | 0.0303 |     - |     - |      64 B |
|             ValueLinq_SharedPool_Push_ByIndex |    10 |    385.04 ns |  1.122 ns |  1.050 ns | 11.85 |    0.06 | 0.0305 |     - |     - |      64 B |
|             ValueLinq_SharedPool_Pull_ByIndex |    10 |    282.15 ns |  0.807 ns |  0.715 ns |  8.69 |    0.04 | 0.0305 |     - |     - |      64 B |
|        ValueLinq_ValueLambda_Standard_ByIndex |    10 |    177.21 ns |  0.499 ns |  0.443 ns |  5.46 |    0.02 | 0.0305 |     - |     - |      64 B |
|           ValueLinq_ValueLambda_Stack_ByIndex |    10 |    136.83 ns |  0.644 ns |  0.571 ns |  4.21 |    0.02 | 0.0303 |     - |     - |      64 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |    10 |    304.00 ns |  0.739 ns |  0.691 ns |  9.36 |    0.04 | 0.0305 |     - |     - |      64 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |    10 |    258.37 ns |  1.316 ns |  1.231 ns |  7.95 |    0.04 | 0.0305 |     - |     - |      64 B |
|                                       ForLoop |    10 |     32.48 ns |  0.153 ns |  0.136 ns |  1.00 |    0.00 | 0.0343 |     - |     - |      72 B |
|                                   ForeachLoop |    10 |     45.99 ns |  0.375 ns |  0.332 ns |  1.42 |    0.01 | 0.0344 |     - |     - |      72 B |
|                                          Linq |    10 |    105.01 ns |  0.518 ns |  0.459 ns |  3.23 |    0.02 | 0.1069 |     - |     - |     224 B |
|                                    LinqFaster |    10 |     74.76 ns |  0.241 ns |  0.214 ns |  2.30 |    0.01 | 0.0650 |     - |     - |     136 B |
|                                        LinqAF |    10 |    162.91 ns |  0.436 ns |  0.364 ns |  5.01 |    0.03 | 0.0341 |     - |     - |      72 B |
|                                    StructLinq |    10 |    150.38 ns |  0.776 ns |  0.648 ns |  4.63 |    0.03 | 0.0763 |     - |     - |     160 B |
|                          StructLinq_IFunction |    10 |    100.35 ns |  0.480 ns |  0.426 ns |  3.09 |    0.01 | 0.0305 |     - |     - |      64 B |
|                                     Hyperlinq |    10 |    115.19 ns |  0.488 ns |  0.456 ns |  3.55 |    0.02 | 0.0305 |     - |     - |      64 B |
|                           Hyperlinq_IFunction |    10 |     91.69 ns |  0.517 ns |  0.458 ns |  2.82 |    0.02 | 0.0305 |     - |     - |      64 B |
|                                               |       |              |           |           |       |         |        |       |       |           |
|                            **ValueLinq_Standard** |  **1000** |  **5,505.38 ns** | **48.178 ns** | **42.709 ns** |  **1.59** |    **0.03** | **2.0523** |     **-** |     **-** |   **4,304 B** |
|                               ValueLinq_Stack |  1000 |  8,497.64 ns | 37.659 ns | 33.384 ns |  2.45 |    0.03 | 1.9836 |     - |     - |   4,176 B |
|                     ValueLinq_SharedPool_Push |  1000 |  5,477.85 ns | 30.104 ns | 26.687 ns |  1.58 |    0.02 | 0.9842 |     - |     - |   2,072 B |
|                     ValueLinq_SharedPool_Pull |  1000 |  8,040.75 ns | 44.011 ns | 39.014 ns |  2.32 |    0.03 | 0.9766 |     - |     - |   2,072 B |
|                ValueLinq_ValueLambda_Standard |  1000 |  2,758.86 ns | 17.658 ns | 15.654 ns |  0.80 |    0.01 | 2.0561 |     - |     - |   4,304 B |
|                   ValueLinq_ValueLambda_Stack |  1000 |  8,384.99 ns | 40.923 ns | 36.277 ns |  2.42 |    0.02 | 1.9836 |     - |     - |   4,176 B |
|         ValueLinq_ValueLambda_SharedPool_Push |  1000 |  3,733.81 ns | 30.753 ns | 28.766 ns |  1.08 |    0.01 | 0.9880 |     - |     - |   2,072 B |
|         ValueLinq_ValueLambda_SharedPool_Pull |  1000 |  8,260.65 ns | 41.063 ns | 36.402 ns |  2.38 |    0.02 | 0.9766 |     - |     - |   2,072 B |
|                    ValueLinq_Standard_ByIndex |  1000 |  5,335.30 ns | 28.782 ns | 24.034 ns |  1.54 |    0.02 | 2.0523 |     - |     - |   4,304 B |
|                       ValueLinq_Stack_ByIndex |  1000 |  6,375.22 ns | 18.913 ns | 15.793 ns |  1.84 |    0.02 | 1.9913 |     - |     - |   4,176 B |
|             ValueLinq_SharedPool_Push_ByIndex |  1000 |  5,975.30 ns | 26.539 ns | 24.824 ns |  1.72 |    0.02 | 0.9842 |     - |     - |   2,072 B |
|             ValueLinq_SharedPool_Pull_ByIndex |  1000 |  7,421.72 ns | 51.657 ns | 45.793 ns |  2.14 |    0.03 | 0.9842 |     - |     - |   2,072 B |
|        ValueLinq_ValueLambda_Standard_ByIndex |  1000 |  4,257.91 ns |  9.906 ns |  7.734 ns |  1.23 |    0.01 | 2.0523 |     - |     - |   4,304 B |
|           ValueLinq_ValueLambda_Stack_ByIndex |  1000 |  3,617.72 ns | 36.706 ns | 34.335 ns |  1.04 |    0.01 | 1.9951 |     - |     - |   4,176 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |  1000 |  3,062.59 ns | 15.525 ns | 14.522 ns |  0.88 |    0.01 | 0.9880 |     - |     - |   2,072 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |  1000 |  2,677.20 ns | 42.395 ns | 39.656 ns |  0.77 |    0.01 | 0.9880 |     - |     - |   2,072 B |
|                                       ForLoop |  1000 |  3,465.16 ns | 37.450 ns | 35.030 ns |  1.00 |    0.00 | 2.0561 |     - |     - |   4,304 B |
|                                   ForeachLoop |  1000 |  4,700.07 ns | 32.541 ns | 30.439 ns |  1.36 |    0.02 | 2.0523 |     - |     - |   4,304 B |
|                                          Linq |  1000 |  5,715.61 ns | 32.289 ns | 28.623 ns |  1.65 |    0.02 | 2.1286 |     - |     - |   4,456 B |
|                                    LinqFaster |  1000 |  6,151.44 ns | 23.734 ns | 43.993 ns |  1.78 |    0.02 | 3.0441 |     - |     - |   6,376 B |
|                                        LinqAF |  1000 | 13,314.91 ns | 67.536 ns | 59.869 ns |  3.84 |    0.03 | 2.0447 |     - |     - |   4,304 B |
|                                    StructLinq |  1000 |  5,582.87 ns | 17.437 ns | 16.310 ns |  1.61 |    0.02 | 1.0300 |     - |     - |   2,168 B |
|                          StructLinq_IFunction |  1000 |  3,281.84 ns | 24.536 ns | 22.951 ns |  0.95 |    0.01 | 0.9880 |     - |     - |   2,072 B |
|                                     Hyperlinq |  1000 |  5,532.59 ns | 20.737 ns | 17.316 ns |  1.60 |    0.02 | 0.9842 |     - |     - |   2,072 B |
|                           Hyperlinq_IFunction |  1000 |  3,611.03 ns | 13.561 ns | 12.685 ns |  1.04 |    0.01 | 0.9880 |     - |     - |   2,072 B |
