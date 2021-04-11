## Array.Int32.ArrayInt32WhereSelectToArray

### Source
[ArrayInt32WhereSelectToArray.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelectToArray.cs)

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
|                                Method |      Job |  Runtime | Count |        Mean |      Error |     StdDev |      Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |--------- |--------- |------ |------------:|-----------:|-----------:|------------:|------:|--------:|-------:|------:|------:|----------:|
|                    **ValueLinq_Standard** | **.NET 5.0** | **.NET 5.0** |    **10** |   **175.26 ns** |   **0.947 ns** |   **0.791 ns** |   **175.10 ns** |  **4.84** |    **0.08** | **0.0153** |     **-** |     **-** |      **32 B** |
|                       ValueLinq_Stack | .NET 5.0 | .NET 5.0 |    10 |   129.82 ns |   0.513 ns |   0.429 ns |   129.72 ns |  3.58 |    0.05 | 0.0150 |     - |     - |      32 B |
|             ValueLinq_SharedPool_Push | .NET 5.0 | .NET 5.0 |    10 |   357.80 ns |   3.524 ns |   3.124 ns |   357.95 ns |  9.86 |    0.14 | 0.0153 |     - |     - |      32 B |
|             ValueLinq_SharedPool_Pull | .NET 5.0 | .NET 5.0 |    10 |   265.82 ns |   3.636 ns |   3.401 ns |   266.64 ns |  7.32 |    0.16 | 0.0153 |     - |     - |      32 B |
|        ValueLinq_ValueLambda_Standard | .NET 5.0 | .NET 5.0 |    10 |   149.34 ns |   2.287 ns |   4.724 ns |   147.96 ns |  4.19 |    0.22 | 0.0150 |     - |     - |      32 B |
|           ValueLinq_ValueLambda_Stack | .NET 5.0 | .NET 5.0 |    10 |   116.29 ns |   2.155 ns |   1.799 ns |   116.83 ns |  3.21 |    0.05 | 0.0153 |     - |     - |      32 B |
| ValueLinq_ValueLambda_SharedPool_Push | .NET 5.0 | .NET 5.0 |    10 |   281.02 ns |   1.126 ns |   0.940 ns |   280.91 ns |  7.76 |    0.12 | 0.0153 |     - |     - |      32 B |
| ValueLinq_ValueLambda_SharedPool_Pull | .NET 5.0 | .NET 5.0 |    10 |   254.18 ns |   0.999 ns |   0.834 ns |   254.24 ns |  7.02 |    0.10 | 0.0153 |     - |     - |      32 B |
|                               ForLoop | .NET 5.0 | .NET 5.0 |    10 |    36.34 ns |   0.607 ns |   0.568 ns |    36.22 ns |  1.00 |    0.00 | 0.0497 |     - |     - |     104 B |
|                           ForeachLoop | .NET 5.0 | .NET 5.0 |    10 |    38.95 ns |   0.232 ns |   0.205 ns |    38.92 ns |  1.07 |    0.01 | 0.0497 |     - |     - |     104 B |
|                                  Linq | .NET 5.0 | .NET 5.0 |    10 |   116.54 ns |   0.770 ns |   0.720 ns |   116.42 ns |  3.21 |    0.05 | 0.0842 |     - |     - |     176 B |
|                            LinqFaster | .NET 5.0 | .NET 5.0 |    10 |    42.61 ns |   0.270 ns |   0.252 ns |    42.53 ns |  1.17 |    0.02 | 0.0458 |     - |     - |      96 B |
|                                LinqAF | .NET 5.0 | .NET 5.0 |    10 |   108.75 ns |   1.037 ns |   0.919 ns |   108.68 ns |  3.00 |    0.06 | 0.0342 |     - |     - |      72 B |
|                            StructLinq | .NET 5.0 | .NET 5.0 |    10 |   133.44 ns |   0.602 ns |   0.533 ns |   133.27 ns |  3.68 |    0.06 | 0.0610 |     - |     - |     128 B |
|                  StructLinq_IFunction | .NET 5.0 | .NET 5.0 |    10 |    91.58 ns |   0.405 ns |   0.359 ns |    91.43 ns |  2.52 |    0.03 | 0.0153 |     - |     - |      32 B |
|                             Hyperlinq | .NET 5.0 | .NET 5.0 |    10 |   112.86 ns |   1.447 ns |   1.130 ns |   113.15 ns |  3.11 |    0.05 | 0.0153 |     - |     - |      32 B |
|                   Hyperlinq_IFunction | .NET 5.0 | .NET 5.0 |    10 |    83.82 ns |   0.393 ns |   0.349 ns |    83.78 ns |  2.31 |    0.04 | 0.0153 |     - |     - |      32 B |
|                                       |          |          |       |             |            |            |             |       |         |        |       |       |           |
|                    ValueLinq_Standard | .NET 6.0 | .NET 6.0 |    10 |   164.13 ns |   0.529 ns |   0.442 ns |   164.01 ns |  4.35 |    0.02 | 0.0150 |     - |     - |      32 B |
|                       ValueLinq_Stack | .NET 6.0 | .NET 6.0 |    10 |   131.96 ns |   0.851 ns |   0.754 ns |   131.79 ns |  3.50 |    0.02 | 0.0153 |     - |     - |      32 B |
|             ValueLinq_SharedPool_Push | .NET 6.0 | .NET 6.0 |    10 |   348.59 ns |   2.510 ns |   2.348 ns |   347.55 ns |  9.24 |    0.06 | 0.0153 |     - |     - |      32 B |
|             ValueLinq_SharedPool_Pull | .NET 6.0 | .NET 6.0 |    10 |   265.53 ns |   1.306 ns |   1.158 ns |   265.40 ns |  7.04 |    0.06 | 0.0153 |     - |     - |      32 B |
|        ValueLinq_ValueLambda_Standard | .NET 6.0 | .NET 6.0 |    10 |   146.00 ns |   0.648 ns |   0.606 ns |   146.05 ns |  3.87 |    0.02 | 0.0150 |     - |     - |      32 B |
|           ValueLinq_ValueLambda_Stack | .NET 6.0 | .NET 6.0 |    10 |   110.94 ns |   0.422 ns |   0.374 ns |   110.92 ns |  2.94 |    0.01 | 0.0150 |     - |     - |      32 B |
| ValueLinq_ValueLambda_SharedPool_Push | .NET 6.0 | .NET 6.0 |    10 |   284.21 ns |   1.049 ns |   0.930 ns |   284.34 ns |  7.54 |    0.05 | 0.0153 |     - |     - |      32 B |
| ValueLinq_ValueLambda_SharedPool_Pull | .NET 6.0 | .NET 6.0 |    10 |   259.36 ns |   1.008 ns |   0.943 ns |   259.10 ns |  6.88 |    0.04 | 0.0153 |     - |     - |      32 B |
|                               ForLoop | .NET 6.0 | .NET 6.0 |    10 |    37.71 ns |   0.201 ns |   0.188 ns |    37.67 ns |  1.00 |    0.00 | 0.0497 |     - |     - |     104 B |
|                           ForeachLoop | .NET 6.0 | .NET 6.0 |    10 |    41.96 ns |   0.436 ns |   0.387 ns |    41.93 ns |  1.11 |    0.01 | 0.0497 |     - |     - |     104 B |
|                                  Linq | .NET 6.0 | .NET 6.0 |    10 |   111.08 ns |   0.870 ns |   0.814 ns |   111.26 ns |  2.95 |    0.02 | 0.0837 |     - |     - |     176 B |
|                            LinqFaster | .NET 6.0 | .NET 6.0 |    10 |    43.58 ns |   0.894 ns |   0.746 ns |    43.30 ns |  1.16 |    0.02 | 0.0458 |     - |     - |      96 B |
|                                LinqAF | .NET 6.0 | .NET 6.0 |    10 |   113.25 ns |   2.223 ns |   3.043 ns |   112.68 ns |  3.02 |    0.09 | 0.0342 |     - |     - |      72 B |
|                            StructLinq | .NET 6.0 | .NET 6.0 |    10 |   140.20 ns |   1.255 ns |   1.174 ns |   139.82 ns |  3.72 |    0.03 | 0.0610 |     - |     - |     128 B |
|                  StructLinq_IFunction | .NET 6.0 | .NET 6.0 |    10 |    92.29 ns |   0.672 ns |   0.596 ns |    92.07 ns |  2.45 |    0.02 | 0.0153 |     - |     - |      32 B |
|                             Hyperlinq | .NET 6.0 | .NET 6.0 |    10 |   110.00 ns |   2.225 ns |   2.285 ns |   110.74 ns |  2.92 |    0.06 | 0.0153 |     - |     - |      32 B |
|                   Hyperlinq_IFunction | .NET 6.0 | .NET 6.0 |    10 |    80.91 ns |   0.268 ns |   0.251 ns |    80.81 ns |  2.15 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                       |          |          |       |             |            |            |             |       |         |        |       |       |           |
|                    **ValueLinq_Standard** | **.NET 5.0** | **.NET 5.0** |  **1000** | **6,902.75 ns** | **135.759 ns** | **244.801 ns** | **6,800.75 ns** |  **1.99** |    **0.10** | **1.9760** |     **-** |     **-** |   **4,144 B** |
|                       ValueLinq_Stack | .NET 5.0 | .NET 5.0 |  1000 | 6,443.97 ns |  28.867 ns |  27.002 ns | 6,441.13 ns |  1.84 |    0.01 | 1.9760 |     - |     - |   4,144 B |
|             ValueLinq_SharedPool_Push | .NET 5.0 | .NET 5.0 |  1000 | 5,493.46 ns |  19.976 ns |  17.708 ns | 5,489.66 ns |  1.57 |    0.01 | 0.9689 |     - |     - |   2,040 B |
|             ValueLinq_SharedPool_Pull | .NET 5.0 | .NET 5.0 |  1000 | 6,784.15 ns |  21.561 ns |  20.168 ns | 6,781.80 ns |  1.93 |    0.01 | 0.9689 |     - |     - |   2,040 B |
|        ValueLinq_ValueLambda_Standard | .NET 5.0 | .NET 5.0 |  1000 | 3,014.20 ns |  24.516 ns |  24.078 ns | 3,014.36 ns |  0.86 |    0.01 | 1.9798 |     - |     - |   4,144 B |
|           ValueLinq_ValueLambda_Stack | .NET 5.0 | .NET 5.0 |  1000 | 2,712.69 ns |   8.308 ns |   6.486 ns | 2,712.28 ns |  0.77 |    0.00 | 1.9798 |     - |     - |   4,144 B |
| ValueLinq_ValueLambda_SharedPool_Push | .NET 5.0 | .NET 5.0 |  1000 | 3,845.07 ns |  15.642 ns |  13.866 ns | 3,844.15 ns |  1.10 |    0.01 | 0.9689 |     - |     - |   2,040 B |
| ValueLinq_ValueLambda_SharedPool_Pull | .NET 5.0 | .NET 5.0 |  1000 | 3,130.09 ns |  60.708 ns |  87.066 ns | 3,172.94 ns |  0.88 |    0.03 | 0.9727 |     - |     - |   2,040 B |
|                               ForLoop | .NET 5.0 | .NET 5.0 |  1000 | 3,508.02 ns |  17.518 ns |  16.386 ns | 3,506.17 ns |  1.00 |    0.00 | 3.0289 |     - |     - |   6,344 B |
|                           ForeachLoop | .NET 5.0 | .NET 5.0 |  1000 | 2,788.79 ns |  17.340 ns |  16.220 ns | 2,790.32 ns |  0.79 |    0.00 | 3.0289 |     - |     - |   6,344 B |
|                                  Linq | .NET 5.0 | .NET 5.0 |  1000 | 5,322.06 ns |  25.340 ns |  19.784 ns | 5,327.69 ns |  1.52 |    0.01 | 2.1667 |     - |     - |   4,544 B |
|                            LinqFaster | .NET 5.0 | .NET 5.0 |  1000 | 4,623.18 ns |  25.442 ns |  19.864 ns | 4,622.58 ns |  1.32 |    0.01 | 2.8915 |     - |     - |   6,064 B |
|                                LinqAF | .NET 5.0 | .NET 5.0 |  1000 | 9,041.18 ns |  58.757 ns |  54.962 ns | 9,037.53 ns |  2.58 |    0.02 | 3.0060 |     - |     - |   6,312 B |
|                            StructLinq | .NET 5.0 | .NET 5.0 |  1000 | 5,625.50 ns |  35.145 ns |  31.155 ns | 5,620.13 ns |  1.60 |    0.01 | 1.0147 |     - |     - |   2,136 B |
|                  StructLinq_IFunction | .NET 5.0 | .NET 5.0 |  1000 | 4,449.71 ns |  84.948 ns |  94.420 ns | 4,497.64 ns |  1.26 |    0.03 | 0.9689 |     - |     - |   2,040 B |
|                             Hyperlinq | .NET 5.0 | .NET 5.0 |  1000 | 5,629.26 ns | 107.201 ns | 123.453 ns | 5,564.49 ns |  1.61 |    0.03 | 0.9689 |     - |     - |   2,040 B |
|                   Hyperlinq_IFunction | .NET 5.0 | .NET 5.0 |  1000 | 2,713.31 ns |  12.176 ns |  10.794 ns | 2,714.35 ns |  0.77 |    0.00 | 0.9727 |     - |     - |   2,040 B |
|                                       |          |          |       |             |            |            |             |       |         |        |       |       |           |
|                    ValueLinq_Standard | .NET 6.0 | .NET 6.0 |  1000 | 7,077.01 ns | 133.473 ns | 153.708 ns | 7,148.72 ns |  1.77 |    0.03 | 1.9760 |     - |     - |   4,144 B |
|                       ValueLinq_Stack | .NET 6.0 | .NET 6.0 |  1000 | 6,221.72 ns |  25.769 ns |  21.519 ns | 6,222.24 ns |  1.57 |    0.05 | 1.9760 |     - |     - |   4,144 B |
|             ValueLinq_SharedPool_Push | .NET 6.0 | .NET 6.0 |  1000 | 5,883.26 ns |  16.923 ns |  14.131 ns | 5,880.64 ns |  1.48 |    0.05 | 0.9689 |     - |     - |   2,040 B |
|             ValueLinq_SharedPool_Pull | .NET 6.0 | .NET 6.0 |  1000 | 6,998.88 ns |  22.242 ns |  20.805 ns | 6,996.75 ns |  1.76 |    0.05 | 0.9689 |     - |     - |   2,040 B |
|        ValueLinq_ValueLambda_Standard | .NET 6.0 | .NET 6.0 |  1000 | 2,625.01 ns |  17.182 ns |  14.348 ns | 2,624.32 ns |  0.66 |    0.02 | 1.9798 |     - |     - |   4,144 B |
|           ValueLinq_ValueLambda_Stack | .NET 6.0 | .NET 6.0 |  1000 | 2,840.41 ns |  55.681 ns |  70.419 ns | 2,860.39 ns |  0.71 |    0.02 | 1.9798 |     - |     - |   4,144 B |
| ValueLinq_ValueLambda_SharedPool_Push | .NET 6.0 | .NET 6.0 |  1000 | 3,898.78 ns |  11.951 ns |  10.595 ns | 3,894.77 ns |  0.98 |    0.03 | 0.9689 |     - |     - |   2,040 B |
| ValueLinq_ValueLambda_SharedPool_Pull | .NET 6.0 | .NET 6.0 |  1000 | 2,688.25 ns |  19.882 ns |  15.522 ns | 2,689.99 ns |  0.68 |    0.02 | 0.9727 |     - |     - |   2,040 B |
|                               ForLoop | .NET 6.0 | .NET 6.0 |  1000 | 3,829.49 ns |  76.552 ns | 161.475 ns | 3,722.07 ns |  1.00 |    0.00 | 3.0289 |     - |     - |   6,344 B |
|                           ForeachLoop | .NET 6.0 | .NET 6.0 |  1000 | 3,844.16 ns |  76.947 ns | 170.509 ns | 3,732.15 ns |  1.01 |    0.02 | 3.0289 |     - |     - |   6,344 B |
|                                  Linq | .NET 6.0 | .NET 6.0 |  1000 | 5,511.04 ns | 106.392 ns | 113.838 ns | 5,544.69 ns |  1.38 |    0.03 | 2.1667 |     - |     - |   4,544 B |
|                            LinqFaster | .NET 6.0 | .NET 6.0 |  1000 | 4,311.91 ns |  47.126 ns |  39.353 ns | 4,299.69 ns |  1.09 |    0.04 | 2.8915 |     - |     - |   6,064 B |
|                                LinqAF | .NET 6.0 | .NET 6.0 |  1000 | 8,387.86 ns |  33.867 ns |  31.679 ns | 8,383.76 ns |  2.11 |    0.07 | 3.0060 |     - |     - |   6,312 B |
|                            StructLinq | .NET 6.0 | .NET 6.0 |  1000 | 5,502.31 ns |  24.626 ns |  23.035 ns | 5,504.60 ns |  1.38 |    0.04 | 1.0147 |     - |     - |   2,136 B |
|                  StructLinq_IFunction | .NET 6.0 | .NET 6.0 |  1000 | 2,875.31 ns |  56.945 ns | 108.344 ns | 2,925.62 ns |  0.75 |    0.04 | 0.9727 |     - |     - |   2,040 B |
|                             Hyperlinq | .NET 6.0 | .NET 6.0 |  1000 | 5,118.17 ns |  21.627 ns |  16.885 ns | 5,120.80 ns |  1.29 |    0.04 | 0.9689 |     - |     - |   2,040 B |
|                   Hyperlinq_IFunction | .NET 6.0 | .NET 6.0 |  1000 | 3,240.48 ns |   9.926 ns |   8.289 ns | 3,239.23 ns |  0.82 |    0.02 | 0.9727 |     - |     - |   2,040 B |
