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

BenchmarkDotNet=v0.12.1.1527-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.3.21202.5
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 6.0 : .NET 6.0.0 (6.0.21.20104), X64 RyuJIT


```
|                                        Method |      Job |  Runtime | Count |         Mean |      Error |     StdDev |       Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------------------------- |--------- |--------- |------ |-------------:|-----------:|-----------:|-------------:|------:|--------:|-------:|------:|------:|----------:|
|                            **ValueLinq_Standard** | **.NET 5.0** | **.NET 5.0** |    **10** |    **211.58 ns** |   **1.199 ns** |   **1.122 ns** |    **211.28 ns** |  **7.41** |    **0.04** | **0.0303** |     **-** |     **-** |      **64 B** |
|                               ValueLinq_Stack | .NET 5.0 | .NET 5.0 |    10 |    175.06 ns |   0.720 ns |   0.674 ns |    174.87 ns |  6.13 |    0.05 | 0.0305 |     - |     - |      64 B |
|                     ValueLinq_SharedPool_Push | .NET 5.0 | .NET 5.0 |    10 |    372.59 ns |   1.946 ns |   1.625 ns |    371.92 ns | 13.04 |    0.11 | 0.0305 |     - |     - |      64 B |
|                     ValueLinq_SharedPool_Pull | .NET 5.0 | .NET 5.0 |    10 |    290.86 ns |   1.463 ns |   1.368 ns |    290.68 ns | 10.18 |    0.06 | 0.0305 |     - |     - |      64 B |
|                ValueLinq_ValueLambda_Standard | .NET 5.0 | .NET 5.0 |    10 |    189.27 ns |   1.456 ns |   1.216 ns |    189.09 ns |  6.62 |    0.07 | 0.0305 |     - |     - |      64 B |
|                   ValueLinq_ValueLambda_Stack | .NET 5.0 | .NET 5.0 |    10 |    155.79 ns |   1.041 ns |   0.922 ns |    155.50 ns |  5.45 |    0.04 | 0.0305 |     - |     - |      64 B |
|         ValueLinq_ValueLambda_SharedPool_Push | .NET 5.0 | .NET 5.0 |    10 |    309.89 ns |   1.801 ns |   1.685 ns |    309.81 ns | 10.85 |    0.07 | 0.0305 |     - |     - |      64 B |
|         ValueLinq_ValueLambda_SharedPool_Pull | .NET 5.0 | .NET 5.0 |    10 |    275.47 ns |   0.845 ns |   0.790 ns |    275.47 ns |  9.65 |    0.06 | 0.0305 |     - |     - |      64 B |
|                    ValueLinq_Standard_ByIndex | .NET 5.0 | .NET 5.0 |    10 |    186.33 ns |   0.684 ns |   0.606 ns |    186.36 ns |  6.52 |    0.04 | 0.0305 |     - |     - |      64 B |
|                       ValueLinq_Stack_ByIndex | .NET 5.0 | .NET 5.0 |    10 |    149.49 ns |   0.458 ns |   0.406 ns |    149.39 ns |  5.23 |    0.04 | 0.0305 |     - |     - |      64 B |
|             ValueLinq_SharedPool_Push_ByIndex | .NET 5.0 | .NET 5.0 |    10 |    401.96 ns |   2.111 ns |   1.975 ns |    402.66 ns | 14.07 |    0.11 | 0.0305 |     - |     - |      64 B |
|             ValueLinq_SharedPool_Pull_ByIndex | .NET 5.0 | .NET 5.0 |    10 |    271.30 ns |   3.852 ns |   3.956 ns |    269.85 ns |  9.51 |    0.14 | 0.0305 |     - |     - |      64 B |
|        ValueLinq_ValueLambda_Standard_ByIndex | .NET 5.0 | .NET 5.0 |    10 |    175.72 ns |   0.376 ns |   0.352 ns |    175.81 ns |  6.15 |    0.03 | 0.0303 |     - |     - |      64 B |
|           ValueLinq_ValueLambda_Stack_ByIndex | .NET 5.0 | .NET 5.0 |    10 |    136.57 ns |   0.544 ns |   0.454 ns |    136.56 ns |  4.78 |    0.04 | 0.0305 |     - |     - |      64 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex | .NET 5.0 | .NET 5.0 |    10 |    307.23 ns |   3.489 ns |   3.093 ns |    306.48 ns | 10.75 |    0.13 | 0.0305 |     - |     - |      64 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex | .NET 5.0 | .NET 5.0 |    10 |    262.48 ns |   1.347 ns |   1.260 ns |    262.55 ns |  9.19 |    0.06 | 0.0305 |     - |     - |      64 B |
|                                       ForLoop | .NET 5.0 | .NET 5.0 |    10 |     28.56 ns |   0.179 ns |   0.167 ns |     28.46 ns |  1.00 |    0.00 | 0.0343 |     - |     - |      72 B |
|                                   ForeachLoop | .NET 5.0 | .NET 5.0 |    10 |     55.27 ns |   0.381 ns |   0.357 ns |     55.26 ns |  1.94 |    0.01 | 0.0343 |     - |     - |      72 B |
|                                          Linq | .NET 5.0 | .NET 5.0 |    10 |    110.61 ns |   2.199 ns |   4.289 ns |    108.36 ns |  4.04 |    0.17 | 0.1069 |     - |     - |     224 B |
|                                    LinqFaster | .NET 5.0 | .NET 5.0 |    10 |     67.85 ns |   0.651 ns |   0.609 ns |     67.66 ns |  2.38 |    0.02 | 0.0650 |     - |     - |     136 B |
|                                        LinqAF | .NET 5.0 | .NET 5.0 |    10 |    167.49 ns |   2.881 ns |   2.695 ns |    168.23 ns |  5.86 |    0.11 | 0.0343 |     - |     - |      72 B |
|                                    StructLinq | .NET 5.0 | .NET 5.0 |    10 |    142.08 ns |   0.495 ns |   0.386 ns |    142.12 ns |  4.97 |    0.03 | 0.0763 |     - |     - |     160 B |
|                          StructLinq_IFunction | .NET 5.0 | .NET 5.0 |    10 |     96.02 ns |   1.172 ns |   0.915 ns |     96.04 ns |  3.36 |    0.04 | 0.0305 |     - |     - |      64 B |
|                                     Hyperlinq | .NET 5.0 | .NET 5.0 |    10 |    118.97 ns |   0.401 ns |   0.375 ns |    118.91 ns |  4.17 |    0.03 | 0.0305 |     - |     - |      64 B |
|                           Hyperlinq_IFunction | .NET 5.0 | .NET 5.0 |    10 |     92.59 ns |   0.389 ns |   0.304 ns |     92.53 ns |  3.24 |    0.02 | 0.0305 |     - |     - |      64 B |
|                                               |          |          |       |              |            |            |              |       |         |        |       |       |           |
|                            ValueLinq_Standard | .NET 6.0 | .NET 6.0 |    10 |    206.46 ns |   0.583 ns |   0.455 ns |    206.42 ns |  7.29 |    0.06 | 0.0303 |     - |     - |      64 B |
|                               ValueLinq_Stack | .NET 6.0 | .NET 6.0 |    10 |    166.67 ns |   0.326 ns |   0.272 ns |    166.72 ns |  5.88 |    0.04 | 0.0305 |     - |     - |      64 B |
|                     ValueLinq_SharedPool_Push | .NET 6.0 | .NET 6.0 |    10 |    354.84 ns |   0.977 ns |   0.763 ns |    354.89 ns | 12.53 |    0.10 | 0.0305 |     - |     - |      64 B |
|                     ValueLinq_SharedPool_Pull | .NET 6.0 | .NET 6.0 |    10 |    279.35 ns |   0.949 ns |   0.841 ns |    279.00 ns |  9.86 |    0.08 | 0.0305 |     - |     - |      64 B |
|                ValueLinq_ValueLambda_Standard | .NET 6.0 | .NET 6.0 |    10 |    182.68 ns |   0.316 ns |   0.264 ns |    182.60 ns |  6.45 |    0.05 | 0.0303 |     - |     - |      64 B |
|                   ValueLinq_ValueLambda_Stack | .NET 6.0 | .NET 6.0 |    10 |    144.87 ns |   0.512 ns |   0.479 ns |    144.76 ns |  5.12 |    0.04 | 0.0303 |     - |     - |      64 B |
|         ValueLinq_ValueLambda_SharedPool_Push | .NET 6.0 | .NET 6.0 |    10 |    288.89 ns |   0.974 ns |   0.863 ns |    288.73 ns | 10.20 |    0.08 | 0.0305 |     - |     - |      64 B |
|         ValueLinq_ValueLambda_SharedPool_Pull | .NET 6.0 | .NET 6.0 |    10 |    282.70 ns |   0.800 ns |   0.709 ns |    282.63 ns |  9.98 |    0.08 | 0.0305 |     - |     - |      64 B |
|                    ValueLinq_Standard_ByIndex | .NET 6.0 | .NET 6.0 |    10 |    181.80 ns |   0.785 ns |   0.613 ns |    181.59 ns |  6.42 |    0.05 | 0.0303 |     - |     - |      64 B |
|                       ValueLinq_Stack_ByIndex | .NET 6.0 | .NET 6.0 |    10 |    148.84 ns |   2.992 ns |   3.073 ns |    147.89 ns |  5.26 |    0.10 | 0.0305 |     - |     - |      64 B |
|             ValueLinq_SharedPool_Push_ByIndex | .NET 6.0 | .NET 6.0 |    10 |    372.91 ns |   5.356 ns |   4.472 ns |    371.94 ns | 13.17 |    0.18 | 0.0305 |     - |     - |      64 B |
|             ValueLinq_SharedPool_Pull_ByIndex | .NET 6.0 | .NET 6.0 |    10 |    272.67 ns |   4.120 ns |   3.440 ns |    271.13 ns |  9.63 |    0.16 | 0.0305 |     - |     - |      64 B |
|        ValueLinq_ValueLambda_Standard_ByIndex | .NET 6.0 | .NET 6.0 |    10 |    172.91 ns |   2.808 ns |   3.234 ns |    171.94 ns |  6.13 |    0.13 | 0.0303 |     - |     - |      64 B |
|           ValueLinq_ValueLambda_Stack_ByIndex | .NET 6.0 | .NET 6.0 |    10 |    132.38 ns |   1.906 ns |   1.690 ns |    131.79 ns |  4.66 |    0.06 | 0.0305 |     - |     - |      64 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex | .NET 6.0 | .NET 6.0 |    10 |    293.59 ns |   3.358 ns |   3.141 ns |    292.36 ns | 10.36 |    0.09 | 0.0305 |     - |     - |      64 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex | .NET 6.0 | .NET 6.0 |    10 |    249.15 ns |   1.287 ns |   1.074 ns |    249.47 ns |  8.80 |    0.08 | 0.0305 |     - |     - |      64 B |
|                                       ForLoop | .NET 6.0 | .NET 6.0 |    10 |     28.32 ns |   0.259 ns |   0.217 ns |     28.30 ns |  1.00 |    0.00 | 0.0343 |     - |     - |      72 B |
|                                   ForeachLoop | .NET 6.0 | .NET 6.0 |    10 |     31.60 ns |   0.437 ns |   0.409 ns |     31.42 ns |  1.12 |    0.02 | 0.0343 |     - |     - |      72 B |
|                                          Linq | .NET 6.0 | .NET 6.0 |    10 |    101.74 ns |   1.047 ns |   0.980 ns |    101.72 ns |  3.58 |    0.05 | 0.1069 |     - |     - |     224 B |
|                                    LinqFaster | .NET 6.0 | .NET 6.0 |    10 |     69.98 ns |   1.436 ns |   1.536 ns |     69.25 ns |  2.47 |    0.06 | 0.0648 |     - |     - |     136 B |
|                                        LinqAF | .NET 6.0 | .NET 6.0 |    10 |    159.02 ns |   2.500 ns |   2.338 ns |    157.63 ns |  5.62 |    0.11 | 0.0341 |     - |     - |      72 B |
|                                    StructLinq | .NET 6.0 | .NET 6.0 |    10 |    148.73 ns |   1.972 ns |   1.845 ns |    147.63 ns |  5.26 |    0.09 | 0.0763 |     - |     - |     160 B |
|                          StructLinq_IFunction | .NET 6.0 | .NET 6.0 |    10 |     97.82 ns |   1.762 ns |   1.562 ns |     97.93 ns |  3.45 |    0.06 | 0.0305 |     - |     - |      64 B |
|                                     Hyperlinq | .NET 6.0 | .NET 6.0 |    10 |    117.74 ns |   1.837 ns |   1.628 ns |    117.15 ns |  4.16 |    0.06 | 0.0305 |     - |     - |      64 B |
|                           Hyperlinq_IFunction | .NET 6.0 | .NET 6.0 |    10 |     97.76 ns |   0.686 ns |   0.536 ns |     97.59 ns |  3.45 |    0.03 | 0.0305 |     - |     - |      64 B |
|                                               |          |          |       |              |            |            |              |       |         |        |       |       |           |
|                            **ValueLinq_Standard** | **.NET 5.0** | **.NET 5.0** |  **1000** |  **5,089.35 ns** |  **83.533 ns** |  **74.050 ns** |  **5,091.21 ns** |  **1.75** |    **0.03** | **2.0523** |     **-** |     **-** |   **4,304 B** |
|                               ValueLinq_Stack | .NET 5.0 | .NET 5.0 |  1000 |  7,824.00 ns |  28.457 ns |  26.619 ns |  7,824.82 ns |  2.69 |    0.02 | 1.9836 |     - |     - |   4,176 B |
|                     ValueLinq_SharedPool_Push | .NET 5.0 | .NET 5.0 |  1000 |  5,729.44 ns |  18.267 ns |  16.193 ns |  5,730.25 ns |  1.97 |    0.02 | 0.9842 |     - |     - |   2,072 B |
|                     ValueLinq_SharedPool_Pull | .NET 5.0 | .NET 5.0 |  1000 |  7,352.93 ns |  40.545 ns |  33.857 ns |  7,351.56 ns |  2.53 |    0.02 | 0.9842 |     - |     - |   2,072 B |
|                ValueLinq_ValueLambda_Standard | .NET 5.0 | .NET 5.0 |  1000 |  1,803.44 ns |   6.802 ns |   5.310 ns |  1,804.16 ns |  0.62 |    0.00 | 2.0561 |     - |     - |   4,304 B |
|                   ValueLinq_ValueLambda_Stack | .NET 5.0 | .NET 5.0 |  1000 |  7,794.72 ns |  24.342 ns |  22.769 ns |  7,790.71 ns |  2.68 |    0.02 | 1.9836 |     - |     - |   4,176 B |
|         ValueLinq_ValueLambda_SharedPool_Push | .NET 5.0 | .NET 5.0 |  1000 |  3,029.67 ns |  17.778 ns |  14.845 ns |  3,025.49 ns |  1.04 |    0.01 | 0.9880 |     - |     - |   2,072 B |
|         ValueLinq_ValueLambda_SharedPool_Pull | .NET 5.0 | .NET 5.0 |  1000 |  8,301.86 ns |  37.326 ns |  33.089 ns |  8,306.87 ns |  2.86 |    0.02 | 0.9766 |     - |     - |   2,072 B |
|                    ValueLinq_Standard_ByIndex | .NET 5.0 | .NET 5.0 |  1000 |  5,309.53 ns |  24.402 ns |  22.826 ns |  5,304.77 ns |  1.83 |    0.01 | 2.0523 |     - |     - |   4,304 B |
|                       ValueLinq_Stack_ByIndex | .NET 5.0 | .NET 5.0 |  1000 |  6,619.64 ns | 123.703 ns | 127.034 ns |  6,663.15 ns |  2.27 |    0.05 | 1.9913 |     - |     - |   4,176 B |
|             ValueLinq_SharedPool_Push_ByIndex | .NET 5.0 | .NET 5.0 |  1000 |  5,893.51 ns |  30.093 ns |  26.677 ns |  5,897.49 ns |  2.03 |    0.02 | 0.9842 |     - |     - |   2,072 B |
|             ValueLinq_SharedPool_Pull_ByIndex | .NET 5.0 | .NET 5.0 |  1000 |  6,477.00 ns |  29.560 ns |  27.651 ns |  6,473.66 ns |  2.23 |    0.02 | 0.9842 |     - |     - |   2,072 B |
|        ValueLinq_ValueLambda_Standard_ByIndex | .NET 5.0 | .NET 5.0 |  1000 |  1,843.13 ns |  24.692 ns |  20.619 ns |  1,834.44 ns |  0.63 |    0.01 | 2.0561 |     - |     - |   4,304 B |
|           ValueLinq_ValueLambda_Stack_ByIndex | .NET 5.0 | .NET 5.0 |  1000 |  2,653.12 ns |  15.023 ns |  20.056 ns |  2,647.81 ns |  0.91 |    0.01 | 1.9951 |     - |     - |   4,176 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex | .NET 5.0 | .NET 5.0 |  1000 |  3,918.20 ns |  15.333 ns |  12.804 ns |  3,921.76 ns |  1.35 |    0.01 | 0.9842 |     - |     - |   2,072 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex | .NET 5.0 | .NET 5.0 |  1000 |  2,796.66 ns |  55.992 ns | 119.323 ns |  2,800.92 ns |  0.95 |    0.04 | 0.9880 |     - |     - |   2,072 B |
|                                       ForLoop | .NET 5.0 | .NET 5.0 |  1000 |  2,905.05 ns |  24.284 ns |  21.527 ns |  2,900.09 ns |  1.00 |    0.00 | 2.0561 |     - |     - |   4,304 B |
|                                   ForeachLoop | .NET 5.0 | .NET 5.0 |  1000 |  5,000.65 ns |  99.367 ns | 139.299 ns |  5,049.13 ns |  1.70 |    0.06 | 2.0523 |     - |     - |   4,304 B |
|                                          Linq | .NET 5.0 | .NET 5.0 |  1000 |  5,857.41 ns |  27.675 ns |  24.533 ns |  5,858.14 ns |  2.02 |    0.02 | 2.1286 |     - |     - |   4,456 B |
|                                    LinqFaster | .NET 5.0 | .NET 5.0 |  1000 |  5,723.00 ns |  25.287 ns |  23.653 ns |  5,720.74 ns |  1.97 |    0.02 | 3.0441 |     - |     - |   6,376 B |
|                                        LinqAF | .NET 5.0 | .NET 5.0 |  1000 | 13,313.93 ns |  26.685 ns |  24.961 ns | 13,316.69 ns |  4.58 |    0.03 | 2.0447 |     - |     - |   4,304 B |
|                                    StructLinq | .NET 5.0 | .NET 5.0 |  1000 |  5,536.07 ns |  35.030 ns |  29.252 ns |  5,529.65 ns |  1.90 |    0.02 | 1.0300 |     - |     - |   2,168 B |
|                          StructLinq_IFunction | .NET 5.0 | .NET 5.0 |  1000 |  2,859.02 ns |  19.167 ns |  17.929 ns |  2,856.57 ns |  0.98 |    0.01 | 0.9880 |     - |     - |   2,072 B |
|                                     Hyperlinq | .NET 5.0 | .NET 5.0 |  1000 |  5,155.74 ns |  26.879 ns |  23.828 ns |  5,153.04 ns |  1.77 |    0.02 | 0.9842 |     - |     - |   2,072 B |
|                           Hyperlinq_IFunction | .NET 5.0 | .NET 5.0 |  1000 |  2,563.16 ns |  15.161 ns |  14.181 ns |  2,559.82 ns |  0.88 |    0.01 | 0.9880 |     - |     - |   2,072 B |
|                                               |          |          |       |              |            |            |              |       |         |        |       |       |           |
|                            ValueLinq_Standard | .NET 6.0 | .NET 6.0 |  1000 |  4,869.26 ns |  16.596 ns |  15.524 ns |  4,866.02 ns |  1.67 |    0.01 | 2.0523 |     - |     - |   4,304 B |
|                               ValueLinq_Stack | .NET 6.0 | .NET 6.0 |  1000 |  7,887.17 ns |  40.072 ns |  37.483 ns |  7,883.97 ns |  2.70 |    0.02 | 1.9836 |     - |     - |   4,176 B |
|                     ValueLinq_SharedPool_Push | .NET 6.0 | .NET 6.0 |  1000 |  5,617.89 ns |  21.724 ns |  20.320 ns |  5,621.66 ns |  1.92 |    0.01 | 0.9842 |     - |     - |   2,072 B |
|                     ValueLinq_SharedPool_Pull | .NET 6.0 | .NET 6.0 |  1000 |  8,429.24 ns |  79.727 ns |  66.575 ns |  8,406.26 ns |  2.89 |    0.02 | 0.9766 |     - |     - |   2,072 B |
|                ValueLinq_ValueLambda_Standard | .NET 6.0 | .NET 6.0 |  1000 |  3,159.03 ns |  63.015 ns | 153.386 ns |  3,065.33 ns |  1.14 |    0.01 | 2.0561 |     - |     - |   4,304 B |
|                   ValueLinq_ValueLambda_Stack | .NET 6.0 | .NET 6.0 |  1000 |  7,700.41 ns |  35.518 ns |  33.224 ns |  7,689.47 ns |  2.64 |    0.02 | 1.9836 |     - |     - |   4,176 B |
|         ValueLinq_ValueLambda_SharedPool_Push | .NET 6.0 | .NET 6.0 |  1000 |  4,005.10 ns |  13.287 ns |  12.429 ns |  4,004.74 ns |  1.37 |    0.01 | 0.9842 |     - |     - |   2,072 B |
|         ValueLinq_ValueLambda_SharedPool_Pull | .NET 6.0 | .NET 6.0 |  1000 |  8,794.49 ns |  27.505 ns |  25.728 ns |  8,785.82 ns |  3.01 |    0.02 | 0.9766 |     - |     - |   2,072 B |
|                    ValueLinq_Standard_ByIndex | .NET 6.0 | .NET 6.0 |  1000 |  5,557.18 ns |  20.103 ns |  16.787 ns |  5,561.47 ns |  1.90 |    0.01 | 2.0523 |     - |     - |   4,304 B |
|                       ValueLinq_Stack_ByIndex | .NET 6.0 | .NET 6.0 |  1000 |  6,156.47 ns |  20.754 ns |  18.398 ns |  6,150.12 ns |  2.11 |    0.01 | 1.9913 |     - |     - |   4,176 B |
|             ValueLinq_SharedPool_Push_ByIndex | .NET 6.0 | .NET 6.0 |  1000 |  5,596.91 ns |  24.267 ns |  21.512 ns |  5,596.70 ns |  1.92 |    0.01 | 0.9842 |     - |     - |   2,072 B |
|             ValueLinq_SharedPool_Pull_ByIndex | .NET 6.0 | .NET 6.0 |  1000 |  8,015.76 ns | 157.033 ns | 174.542 ns |  8,017.27 ns |  2.72 |    0.06 | 0.9766 |     - |     - |   2,072 B |
|        ValueLinq_ValueLambda_Standard_ByIndex | .NET 6.0 | .NET 6.0 |  1000 |  4,594.13 ns |  64.650 ns |  53.986 ns |  4,573.62 ns |  1.57 |    0.01 | 2.0523 |     - |     - |   4,304 B |
|           ValueLinq_ValueLambda_Stack_ByIndex | .NET 6.0 | .NET 6.0 |  1000 |  3,408.11 ns |  28.726 ns |  26.870 ns |  3,401.95 ns |  1.17 |    0.01 | 1.9951 |     - |     - |   4,176 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex | .NET 6.0 | .NET 6.0 |  1000 |  3,089.22 ns |  16.310 ns |  14.459 ns |  3,085.89 ns |  1.06 |    0.01 | 0.9880 |     - |     - |   2,072 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex | .NET 6.0 | .NET 6.0 |  1000 |  2,963.37 ns |  28.585 ns |  23.870 ns |  2,957.56 ns |  1.02 |    0.01 | 0.9880 |     - |     - |   2,072 B |
|                                       ForLoop | .NET 6.0 | .NET 6.0 |  1000 |  2,919.11 ns |  17.815 ns |  13.909 ns |  2,918.61 ns |  1.00 |    0.00 | 2.0561 |     - |     - |   4,304 B |
|                                   ForeachLoop | .NET 6.0 | .NET 6.0 |  1000 |  1,886.85 ns |  19.253 ns |  16.077 ns |  1,884.97 ns |  0.65 |    0.01 | 2.0561 |     - |     - |   4,304 B |
|                                          Linq | .NET 6.0 | .NET 6.0 |  1000 |  5,987.28 ns | 118.991 ns | 166.809 ns |  6,049.09 ns |  2.01 |    0.06 | 2.1286 |     - |     - |   4,456 B |
|                                    LinqFaster | .NET 6.0 | .NET 6.0 |  1000 |  6,003.55 ns |  25.685 ns |  22.769 ns |  6,005.65 ns |  2.06 |    0.01 | 3.0441 |     - |     - |   6,376 B |
|                                        LinqAF | .NET 6.0 | .NET 6.0 |  1000 | 13,235.94 ns |  44.932 ns |  37.520 ns | 13,236.22 ns |  4.53 |    0.02 | 2.0447 |     - |     - |   4,304 B |
|                                    StructLinq | .NET 6.0 | .NET 6.0 |  1000 |  5,419.87 ns |  29.416 ns |  27.516 ns |  5,416.28 ns |  1.86 |    0.01 | 1.0300 |     - |     - |   2,168 B |
|                          StructLinq_IFunction | .NET 6.0 | .NET 6.0 |  1000 |  2,901.99 ns |  13.536 ns |  11.999 ns |  2,905.41 ns |  0.99 |    0.01 | 0.9880 |     - |     - |   2,072 B |
|                                     Hyperlinq | .NET 6.0 | .NET 6.0 |  1000 |  5,311.21 ns |  20.102 ns |  16.786 ns |  5,304.30 ns |  1.82 |    0.01 | 0.9842 |     - |     - |   2,072 B |
|                           Hyperlinq_IFunction | .NET 6.0 | .NET 6.0 |  1000 |  2,386.15 ns |  14.981 ns |  12.509 ns |  2,383.99 ns |  0.82 |    0.01 | 0.9880 |     - |     - |   2,072 B |
