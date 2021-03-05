## List.Int32.ListInt32WhereSelectToList

### Source
[ListInt32WhereSelectToList.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelectToList.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1517-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.1.21103.13
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|                                        Method | Count |         Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------------------------- |------ |-------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                            **ValueLinq_Standard** |    **10** |    **211.48 ns** |  **1.413 ns** |  **2.399 ns** |  **7.02** |    **0.04** | **0.0300** |     **-** |     **-** |      **64 B** |
|                               ValueLinq_Stack |    10 |    171.57 ns |  0.495 ns |  0.463 ns |  5.70 |    0.03 | 0.0305 |     - |     - |      64 B |
|                     ValueLinq_SharedPool_Push |    10 |    360.02 ns |  0.604 ns |  0.565 ns | 11.95 |    0.05 | 0.0305 |     - |     - |      64 B |
|                     ValueLinq_SharedPool_Pull |    10 |    289.50 ns |  0.792 ns |  0.702 ns |  9.61 |    0.04 | 0.0305 |     - |     - |      64 B |
|                ValueLinq_ValueLambda_Standard |    10 |    186.96 ns |  0.366 ns |  0.306 ns |  6.21 |    0.03 | 0.0305 |     - |     - |      64 B |
|                   ValueLinq_ValueLambda_Stack |    10 |    148.85 ns |  0.686 ns |  0.608 ns |  4.94 |    0.02 | 0.0305 |     - |     - |      64 B |
|         ValueLinq_ValueLambda_SharedPool_Push |    10 |    295.33 ns |  0.721 ns |  0.602 ns |  9.80 |    0.04 | 0.0305 |     - |     - |      64 B |
|         ValueLinq_ValueLambda_SharedPool_Pull |    10 |    276.52 ns |  1.951 ns |  1.729 ns |  9.18 |    0.07 | 0.0305 |     - |     - |      64 B |
|                    ValueLinq_Standard_ByIndex |    10 |    183.02 ns |  0.462 ns |  0.385 ns |  6.08 |    0.02 | 0.0303 |     - |     - |      64 B |
|                       ValueLinq_Stack_ByIndex |    10 |    143.99 ns |  0.477 ns |  0.399 ns |  4.78 |    0.02 | 0.0303 |     - |     - |      64 B |
|             ValueLinq_SharedPool_Push_ByIndex |    10 |    380.85 ns |  0.779 ns |  0.690 ns | 12.65 |    0.05 | 0.0305 |     - |     - |      64 B |
|             ValueLinq_SharedPool_Pull_ByIndex |    10 |    269.80 ns |  1.233 ns |  1.030 ns |  8.96 |    0.05 | 0.0305 |     - |     - |      64 B |
|        ValueLinq_ValueLambda_Standard_ByIndex |    10 |    173.10 ns |  0.804 ns |  0.712 ns |  5.75 |    0.02 | 0.0303 |     - |     - |      64 B |
|           ValueLinq_ValueLambda_Stack_ByIndex |    10 |    134.22 ns |  0.175 ns |  0.136 ns |  4.45 |    0.02 | 0.0303 |     - |     - |      64 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |    10 |    297.88 ns |  0.554 ns |  0.491 ns |  9.89 |    0.04 | 0.0305 |     - |     - |      64 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |    10 |    252.33 ns |  0.698 ns |  0.545 ns |  8.37 |    0.04 | 0.0305 |     - |     - |      64 B |
|                                       ForLoop |    10 |     30.11 ns |  0.135 ns |  0.120 ns |  1.00 |    0.00 | 0.0343 |     - |     - |      72 B |
|                                   ForeachLoop |    10 |     44.47 ns |  0.124 ns |  0.116 ns |  1.48 |    0.01 | 0.0344 |     - |     - |      72 B |
|                                          Linq |    10 |    104.22 ns |  0.392 ns |  0.348 ns |  3.46 |    0.02 | 0.1069 |     - |     - |     224 B |
|                                    LinqFaster |    10 |     69.03 ns |  0.348 ns |  0.326 ns |  2.29 |    0.01 | 0.0650 |     - |     - |     136 B |
|                                        LinqAF |    10 |    157.65 ns |  0.585 ns |  0.518 ns |  5.24 |    0.03 | 0.0343 |     - |     - |      72 B |
|                                    StructLinq |    10 |    137.53 ns |  0.380 ns |  0.337 ns |  4.57 |    0.02 | 0.0763 |     - |     - |     160 B |
|                          StructLinq_IFunction |    10 |     97.76 ns |  0.252 ns |  0.235 ns |  3.25 |    0.01 | 0.0305 |     - |     - |      64 B |
|                                     Hyperlinq |    10 |    112.01 ns |  0.382 ns |  0.357 ns |  3.72 |    0.02 | 0.0305 |     - |     - |      64 B |
|                           Hyperlinq_IFunction |    10 |     90.57 ns |  1.778 ns |  1.484 ns |  3.01 |    0.04 | 0.0305 |     - |     - |      64 B |
|                                               |       |              |           |           |       |         |        |       |       |           |
|                            **ValueLinq_Standard** |  **1000** |  **5,072.96 ns** | **29.469 ns** | **26.123 ns** |  **1.57** |    **0.01** | **2.0523** |     **-** |     **-** |   **4,304 B** |
|                               ValueLinq_Stack |  1000 |  8,177.25 ns | 27.593 ns | 25.810 ns |  2.53 |    0.01 | 1.9836 |     - |     - |   4,176 B |
|                     ValueLinq_SharedPool_Push |  1000 |  5,896.22 ns | 26.931 ns | 22.488 ns |  1.83 |    0.01 | 0.9842 |     - |     - |   2,072 B |
|                     ValueLinq_SharedPool_Pull |  1000 |  7,982.60 ns | 24.989 ns | 23.375 ns |  2.47 |    0.01 | 0.9766 |     - |     - |   2,072 B |
|                ValueLinq_ValueLambda_Standard |  1000 |  2,530.78 ns | 11.353 ns |  9.480 ns |  0.78 |    0.00 | 2.0561 |     - |     - |   4,304 B |
|                   ValueLinq_ValueLambda_Stack |  1000 |  8,253.69 ns | 27.444 ns | 24.329 ns |  2.56 |    0.01 | 1.9836 |     - |     - |   4,176 B |
|         ValueLinq_ValueLambda_SharedPool_Push |  1000 |  3,130.62 ns |  6.631 ns |  5.878 ns |  0.97 |    0.00 | 0.9880 |     - |     - |   2,072 B |
|         ValueLinq_ValueLambda_SharedPool_Pull |  1000 |  8,016.27 ns | 18.185 ns | 16.121 ns |  2.48 |    0.01 | 0.9766 |     - |     - |   2,072 B |
|                    ValueLinq_Standard_ByIndex |  1000 |  5,109.55 ns | 21.563 ns | 19.115 ns |  1.58 |    0.01 | 2.0523 |     - |     - |   4,304 B |
|                       ValueLinq_Stack_ByIndex |  1000 |  6,098.30 ns | 25.063 ns | 20.929 ns |  1.89 |    0.01 | 1.9913 |     - |     - |   4,176 B |
|             ValueLinq_SharedPool_Push_ByIndex |  1000 |  5,778.00 ns | 31.592 ns | 28.005 ns |  1.79 |    0.01 | 0.9842 |     - |     - |   2,072 B |
|             ValueLinq_SharedPool_Pull_ByIndex |  1000 |  7,150.97 ns | 29.692 ns | 26.322 ns |  2.21 |    0.01 | 0.9842 |     - |     - |   2,072 B |
|        ValueLinq_ValueLambda_Standard_ByIndex |  1000 |  3,417.79 ns | 15.246 ns | 12.731 ns |  1.06 |    0.01 | 2.0561 |     - |     - |   4,304 B |
|           ValueLinq_ValueLambda_Stack_ByIndex |  1000 |  2,650.10 ns | 13.754 ns | 12.865 ns |  0.82 |    0.00 | 1.9951 |     - |     - |   4,176 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |  1000 |  2,789.23 ns | 12.038 ns | 11.260 ns |  0.86 |    0.00 | 0.9880 |     - |     - |   2,072 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |  1000 |  2,766.34 ns | 11.390 ns | 10.654 ns |  0.86 |    0.00 | 0.9880 |     - |     - |   2,072 B |
|                                       ForLoop |  1000 |  3,229.74 ns | 12.833 ns | 11.377 ns |  1.00 |    0.00 | 2.0561 |     - |     - |   4,304 B |
|                                   ForeachLoop |  1000 |  3,955.30 ns | 12.780 ns |  9.978 ns |  1.23 |    0.01 | 2.0523 |     - |     - |   4,304 B |
|                                          Linq |  1000 |  5,508.54 ns | 16.230 ns | 13.553 ns |  1.71 |    0.01 | 2.1286 |     - |     - |   4,456 B |
|                                    LinqFaster |  1000 |  5,948.25 ns | 32.161 ns | 28.509 ns |  1.84 |    0.01 | 3.0441 |     - |     - |   6,376 B |
|                                        LinqAF |  1000 | 12,895.37 ns | 30.382 ns | 26.933 ns |  3.99 |    0.01 | 2.0447 |     - |     - |   4,304 B |
|                                    StructLinq |  1000 |  5,281.40 ns | 15.627 ns | 13.853 ns |  1.64 |    0.01 | 1.0300 |     - |     - |   2,168 B |
|                          StructLinq_IFunction |  1000 |  2,816.57 ns | 13.026 ns | 11.547 ns |  0.87 |    0.00 | 0.9880 |     - |     - |   2,072 B |
|                                     Hyperlinq |  1000 |  5,344.46 ns | 13.395 ns | 10.458 ns |  1.66 |    0.01 | 0.9842 |     - |     - |   2,072 B |
|                           Hyperlinq_IFunction |  1000 |  2,320.30 ns | 13.510 ns | 11.976 ns |  0.72 |    0.00 | 0.9880 |     - |     - |   2,072 B |
