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

Job=.NET 5.0  Runtime=.NET 5.0  

```
|                                        Method | Count |         Mean |      Error |     StdDev |       Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------------------------- |------ |-------------:|-----------:|-----------:|-------------:|------:|--------:|-------:|------:|------:|----------:|
|                            **ValueLinq_Standard** |    **10** |    **221.46 ns** |   **4.401 ns** |   **4.520 ns** |    **219.23 ns** |  **7.15** |    **0.25** | **0.0305** |     **-** |     **-** |      **64 B** |
|                               ValueLinq_Stack |    10 |    179.38 ns |   0.813 ns |   0.679 ns |    179.63 ns |  5.77 |    0.18 | 0.0305 |     - |     - |      64 B |
|                     ValueLinq_SharedPool_Push |    10 |    382.47 ns |   5.674 ns |   5.030 ns |    383.88 ns | 12.32 |    0.42 | 0.0305 |     - |     - |      64 B |
|                     ValueLinq_SharedPool_Pull |    10 |    300.94 ns |   6.093 ns |   6.772 ns |    297.48 ns |  9.73 |    0.31 | 0.0305 |     - |     - |      64 B |
|                ValueLinq_ValueLambda_Standard |    10 |    194.74 ns |   0.911 ns |   0.761 ns |    194.65 ns |  6.26 |    0.19 | 0.0305 |     - |     - |      64 B |
|                   ValueLinq_ValueLambda_Stack |    10 |    162.19 ns |   0.662 ns |   0.517 ns |    162.35 ns |  5.21 |    0.16 | 0.0305 |     - |     - |      64 B |
|         ValueLinq_ValueLambda_SharedPool_Push |    10 |    307.68 ns |   1.991 ns |   1.862 ns |    307.32 ns |  9.92 |    0.30 | 0.0305 |     - |     - |      64 B |
|         ValueLinq_ValueLambda_SharedPool_Pull |    10 |    285.73 ns |   3.314 ns |   3.100 ns |    285.28 ns |  9.21 |    0.28 | 0.0305 |     - |     - |      64 B |
|                    ValueLinq_Standard_ByIndex |    10 |    196.20 ns |   3.207 ns |   2.843 ns |    197.08 ns |  6.32 |    0.19 | 0.0305 |     - |     - |      64 B |
|                       ValueLinq_Stack_ByIndex |    10 |    151.54 ns |   0.637 ns |   0.596 ns |    151.37 ns |  4.89 |    0.13 | 0.0303 |     - |     - |      64 B |
|             ValueLinq_SharedPool_Push_ByIndex |    10 |    388.68 ns |   2.235 ns |   1.981 ns |    388.41 ns | 12.52 |    0.39 | 0.0305 |     - |     - |      64 B |
|             ValueLinq_SharedPool_Pull_ByIndex |    10 |    273.08 ns |   1.941 ns |   1.815 ns |    273.08 ns |  8.80 |    0.26 | 0.0305 |     - |     - |      64 B |
|        ValueLinq_ValueLambda_Standard_ByIndex |    10 |    188.88 ns |   1.305 ns |   1.157 ns |    188.67 ns |  6.08 |    0.19 | 0.0305 |     - |     - |      64 B |
|           ValueLinq_ValueLambda_Stack_ByIndex |    10 |    139.70 ns |   0.676 ns |   0.599 ns |    139.62 ns |  4.50 |    0.13 | 0.0305 |     - |     - |      64 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |    10 |    319.12 ns |   1.763 ns |   1.563 ns |    318.65 ns | 10.28 |    0.29 | 0.0305 |     - |     - |      64 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |    10 |    266.27 ns |   5.057 ns |   4.730 ns |    266.86 ns |  8.59 |    0.32 | 0.0305 |     - |     - |      64 B |
|                                       ForLoop |    10 |     30.87 ns |   0.331 ns |   0.605 ns |     30.69 ns |  1.00 |    0.00 | 0.0343 |     - |     - |      72 B |
|                                   ForeachLoop |    10 |     57.04 ns |   0.201 ns |   0.188 ns |     56.99 ns |  1.84 |    0.05 | 0.0343 |     - |     - |      72 B |
|                                          Linq |    10 |    112.87 ns |   2.321 ns |   5.991 ns |    108.50 ns |  3.62 |    0.19 | 0.1069 |     - |     - |     224 B |
|                                    LinqFaster |    10 |     76.45 ns |   1.476 ns |   3.836 ns |     74.00 ns |  2.56 |    0.13 | 0.0650 |     - |     - |     136 B |
|                                        LinqAF |    10 |    170.96 ns |   1.235 ns |   0.964 ns |    170.70 ns |  5.49 |    0.18 | 0.0341 |     - |     - |      72 B |
|                                    StructLinq |    10 |    149.11 ns |   3.014 ns |   6.488 ns |    145.58 ns |  4.87 |    0.23 | 0.0763 |     - |     - |     160 B |
|                          StructLinq_IFunction |    10 |    107.83 ns |   0.801 ns |   0.749 ns |    108.09 ns |  3.48 |    0.10 | 0.0305 |     - |     - |      64 B |
|                                     Hyperlinq |    10 |    120.14 ns |   0.700 ns |   0.584 ns |    119.99 ns |  3.86 |    0.13 | 0.0305 |     - |     - |      64 B |
|                           Hyperlinq_IFunction |    10 |    101.41 ns |   2.100 ns |   2.731 ns |    102.54 ns |  3.27 |    0.13 | 0.0305 |     - |     - |      64 B |
|                                               |       |              |            |            |              |       |         |        |       |       |           |
|                            **ValueLinq_Standard** |  **1000** |  **5,398.25 ns** |  **31.022 ns** |  **25.905 ns** |  **5,396.41 ns** |  **1.74** |    **0.02** | **2.0523** |     **-** |     **-** |   **4,304 B** |
|                               ValueLinq_Stack |  1000 |  8,242.89 ns |  33.134 ns |  29.372 ns |  8,248.31 ns |  2.65 |    0.03 | 1.9836 |     - |     - |   4,176 B |
|                     ValueLinq_SharedPool_Push |  1000 |  6,038.85 ns |  45.346 ns |  42.416 ns |  6,035.40 ns |  1.94 |    0.02 | 0.9842 |     - |     - |   2,072 B |
|                     ValueLinq_SharedPool_Pull |  1000 |  8,237.41 ns | 103.412 ns |  96.731 ns |  8,254.23 ns |  2.65 |    0.04 | 0.9766 |     - |     - |   2,072 B |
|                ValueLinq_ValueLambda_Standard |  1000 |  1,944.72 ns |  28.686 ns |  22.396 ns |  1,945.36 ns |  0.62 |    0.01 | 2.0561 |     - |     - |   4,304 B |
|                   ValueLinq_ValueLambda_Stack |  1000 |  8,091.35 ns |  43.473 ns |  38.538 ns |  8,100.93 ns |  2.60 |    0.03 | 1.9836 |     - |     - |   4,176 B |
|         ValueLinq_ValueLambda_SharedPool_Push |  1000 |  3,328.28 ns |  30.168 ns |  25.192 ns |  3,337.69 ns |  1.07 |    0.02 | 0.9880 |     - |     - |   2,072 B |
|         ValueLinq_ValueLambda_SharedPool_Pull |  1000 |  8,767.16 ns |  42.235 ns |  39.507 ns |  8,761.38 ns |  2.82 |    0.03 | 0.9766 |     - |     - |   2,072 B |
|                    ValueLinq_Standard_ByIndex |  1000 |  5,414.13 ns |  28.301 ns |  25.088 ns |  5,405.05 ns |  1.74 |    0.02 | 2.0523 |     - |     - |   4,304 B |
|                       ValueLinq_Stack_ByIndex |  1000 |  7,043.36 ns | 136.956 ns | 140.643 ns |  7,061.37 ns |  2.26 |    0.05 | 1.9913 |     - |     - |   4,176 B |
|             ValueLinq_SharedPool_Push_ByIndex |  1000 |  6,075.45 ns |  43.876 ns |  41.042 ns |  6,059.66 ns |  1.95 |    0.03 | 0.9842 |     - |     - |   2,072 B |
|             ValueLinq_SharedPool_Pull_ByIndex |  1000 |  6,695.31 ns |  35.673 ns |  31.623 ns |  6,691.70 ns |  2.15 |    0.03 | 0.9842 |     - |     - |   2,072 B |
|        ValueLinq_ValueLambda_Standard_ByIndex |  1000 |  1,924.57 ns |  24.911 ns |  23.302 ns |  1,924.73 ns |  0.62 |    0.01 | 2.0561 |     - |     - |   4,304 B |
|           ValueLinq_ValueLambda_Stack_ByIndex |  1000 |  3,096.62 ns |  33.558 ns |  31.390 ns |  3,098.95 ns |  1.00 |    0.01 | 1.9951 |     - |     - |   4,176 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |  1000 |  4,038.75 ns |  27.595 ns |  25.813 ns |  4,037.55 ns |  1.30 |    0.02 | 0.9842 |     - |     - |   2,072 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |  1000 |  2,893.23 ns |  57.497 ns | 126.208 ns |  2,849.68 ns |  0.91 |    0.03 | 0.9880 |     - |     - |   2,072 B |
|                                       ForLoop |  1000 |  3,112.03 ns |  36.726 ns |  32.556 ns |  3,104.07 ns |  1.00 |    0.00 | 2.0561 |     - |     - |   4,304 B |
|                                   ForeachLoop |  1000 |  4,906.11 ns |  62.789 ns |  55.661 ns |  4,909.10 ns |  1.58 |    0.02 | 2.0523 |     - |     - |   4,304 B |
|                                          Linq |  1000 |  6,473.11 ns |  33.551 ns |  31.384 ns |  6,468.84 ns |  2.08 |    0.03 | 2.1286 |     - |     - |   4,456 B |
|                                    LinqFaster |  1000 |  5,521.60 ns |  32.445 ns |  28.761 ns |  5,520.37 ns |  1.77 |    0.02 | 3.0441 |     - |     - |   6,376 B |
|                                        LinqAF |  1000 | 13,110.87 ns |  76.274 ns |  63.692 ns | 13,090.70 ns |  4.21 |    0.05 | 2.0447 |     - |     - |   4,304 B |
|                                    StructLinq |  1000 |  5,682.02 ns |  42.150 ns |  39.427 ns |  5,676.01 ns |  1.83 |    0.02 | 1.0300 |     - |     - |   2,168 B |
|                          StructLinq_IFunction |  1000 |  3,230.80 ns |  25.129 ns |  20.984 ns |  3,237.12 ns |  1.04 |    0.01 | 0.9880 |     - |     - |   2,072 B |
|                                     Hyperlinq |  1000 |  5,463.75 ns |  45.264 ns |  42.340 ns |  5,457.44 ns |  1.76 |    0.03 | 0.9842 |     - |     - |   2,072 B |
|                           Hyperlinq_IFunction |  1000 |  2,708.14 ns |  17.529 ns |  15.539 ns |  2,709.03 ns |  0.87 |    0.01 | 0.9880 |     - |     - |   2,072 B |
