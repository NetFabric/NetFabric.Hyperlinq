## Enumerable.Int32.EnumerableInt32WhereSelectToArray

### Source
[EnumerableInt32WhereSelectToArray.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelectToArray.cs)

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
|                                Method |      Job |  Runtime | Count |        Mean |     Error |    StdDev |      Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |--------- |--------- |------ |------------:|----------:|----------:|------------:|------:|--------:|-------:|------:|------:|----------:|
|                    **ValueLinq_Standard** | **.NET 5.0** | **.NET 5.0** |    **10** |    **256.9 ns** |   **1.18 ns** |   **1.10 ns** |    **256.6 ns** |  **2.24** |    **0.02** | **0.0415** |     **-** |     **-** |      **88 B** |
|                       ValueLinq_Stack | .NET 5.0 | .NET 5.0 |    10 |    223.4 ns |   1.36 ns |   1.21 ns |    223.4 ns |  1.95 |    0.02 | 0.0420 |     - |     - |      88 B |
|             ValueLinq_SharedPool_Push | .NET 5.0 | .NET 5.0 |    10 |    464.3 ns |   1.29 ns |   1.08 ns |    463.9 ns |  4.07 |    0.03 | 0.0420 |     - |     - |      88 B |
|             ValueLinq_SharedPool_Pull | .NET 5.0 | .NET 5.0 |    10 |    359.7 ns |   1.51 ns |   1.41 ns |    359.3 ns |  3.14 |    0.03 | 0.0420 |     - |     - |      88 B |
|        ValueLinq_ValueLambda_Standard | .NET 5.0 | .NET 5.0 |    10 |    221.4 ns |   0.97 ns |   0.76 ns |    221.2 ns |  1.94 |    0.01 | 0.0420 |     - |     - |      88 B |
|           ValueLinq_ValueLambda_Stack | .NET 5.0 | .NET 5.0 |    10 |    178.2 ns |   0.49 ns |   0.43 ns |    178.2 ns |  1.56 |    0.01 | 0.0417 |     - |     - |      88 B |
| ValueLinq_ValueLambda_SharedPool_Push | .NET 5.0 | .NET 5.0 |    10 |    377.3 ns |   5.60 ns |   4.96 ns |    374.7 ns |  3.30 |    0.05 | 0.0420 |     - |     - |      88 B |
| ValueLinq_ValueLambda_SharedPool_Pull | .NET 5.0 | .NET 5.0 |    10 |    330.2 ns |   5.74 ns |   5.37 ns |    331.6 ns |  2.89 |    0.06 | 0.0420 |     - |     - |      88 B |
|                           ForeachLoop | .NET 5.0 | .NET 5.0 |    10 |    114.4 ns |   1.14 ns |   1.01 ns |    114.1 ns |  1.00 |    0.00 | 0.1031 |     - |     - |     216 B |
|                                  Linq | .NET 5.0 | .NET 5.0 |    10 |    225.2 ns |   4.53 ns |   8.72 ns |    220.0 ns |  2.07 |    0.06 | 0.1452 |     - |     - |     304 B |
|                                LinqAF | .NET 5.0 | .NET 5.0 |    10 |    227.0 ns |   4.34 ns |   4.06 ns |    228.5 ns |  1.98 |    0.04 | 0.0877 |     - |     - |     184 B |
|                            StructLinq | .NET 5.0 | .NET 5.0 |    10 |    207.7 ns |   1.16 ns |   1.03 ns |    207.3 ns |  1.82 |    0.02 | 0.0842 |     - |     - |     176 B |
|                  StructLinq_IFunction | .NET 5.0 | .NET 5.0 |    10 |    159.4 ns |   3.11 ns |   3.70 ns |    161.2 ns |  1.38 |    0.04 | 0.0420 |     - |     - |      88 B |
|                             Hyperlinq | .NET 5.0 | .NET 5.0 |    10 |    167.5 ns |   0.90 ns |   0.75 ns |    167.5 ns |  1.47 |    0.01 | 0.0420 |     - |     - |      88 B |
|                   Hyperlinq_IFunction | .NET 5.0 | .NET 5.0 |    10 |    139.9 ns |   0.75 ns |   0.70 ns |    139.8 ns |  1.22 |    0.01 | 0.0420 |     - |     - |      88 B |
|                                       |          |          |       |             |           |           |             |       |         |        |       |       |           |
|                    ValueLinq_Standard | .NET 6.0 | .NET 6.0 |    10 |    262.3 ns |   1.28 ns |   1.13 ns |    262.0 ns |  2.29 |    0.09 | 0.0415 |     - |     - |      88 B |
|                       ValueLinq_Stack | .NET 6.0 | .NET 6.0 |    10 |    206.7 ns |   0.87 ns |   0.77 ns |    206.5 ns |  1.80 |    0.07 | 0.0417 |     - |     - |      88 B |
|             ValueLinq_SharedPool_Push | .NET 6.0 | .NET 6.0 |    10 |    466.3 ns |   4.99 ns |   4.42 ns |    467.8 ns |  4.07 |    0.15 | 0.0420 |     - |     - |      88 B |
|             ValueLinq_SharedPool_Pull | .NET 6.0 | .NET 6.0 |    10 |    338.1 ns |   1.03 ns |   0.91 ns |    338.0 ns |  2.95 |    0.12 | 0.0420 |     - |     - |      88 B |
|        ValueLinq_ValueLambda_Standard | .NET 6.0 | .NET 6.0 |    10 |    208.1 ns |   1.22 ns |   1.08 ns |    208.1 ns |  1.82 |    0.08 | 0.0417 |     - |     - |      88 B |
|           ValueLinq_ValueLambda_Stack | .NET 6.0 | .NET 6.0 |    10 |    167.8 ns |   0.61 ns |   0.54 ns |    167.9 ns |  1.46 |    0.06 | 0.0417 |     - |     - |      88 B |
| ValueLinq_ValueLambda_SharedPool_Push | .NET 6.0 | .NET 6.0 |    10 |    366.9 ns |   1.47 ns |   1.37 ns |    367.1 ns |  3.19 |    0.13 | 0.0420 |     - |     - |      88 B |
| ValueLinq_ValueLambda_SharedPool_Pull | .NET 6.0 | .NET 6.0 |    10 |    330.6 ns |   1.84 ns |   1.54 ns |    330.0 ns |  2.89 |    0.12 | 0.0420 |     - |     - |      88 B |
|                           ForeachLoop | .NET 6.0 | .NET 6.0 |    10 |    111.5 ns |   2.29 ns |   4.98 ns |    108.3 ns |  1.00 |    0.00 | 0.1032 |     - |     - |     216 B |
|                                  Linq | .NET 6.0 | .NET 6.0 |    10 |    195.0 ns |   0.78 ns |   1.20 ns |    194.6 ns |  1.71 |    0.07 | 0.1450 |     - |     - |     304 B |
|                                LinqAF | .NET 6.0 | .NET 6.0 |    10 |    217.5 ns |   4.35 ns |   7.50 ns |    221.4 ns |  1.93 |    0.10 | 0.0875 |     - |     - |     184 B |
|                            StructLinq | .NET 6.0 | .NET 6.0 |    10 |    221.4 ns |   0.53 ns |   0.41 ns |    221.5 ns |  1.94 |    0.08 | 0.0842 |     - |     - |     176 B |
|                  StructLinq_IFunction | .NET 6.0 | .NET 6.0 |    10 |    149.6 ns |   3.06 ns |   3.87 ns |    151.6 ns |  1.29 |    0.03 | 0.0420 |     - |     - |      88 B |
|                             Hyperlinq | .NET 6.0 | .NET 6.0 |    10 |    164.3 ns |   3.16 ns |   4.32 ns |    162.0 ns |  1.42 |    0.08 | 0.0420 |     - |     - |      88 B |
|                   Hyperlinq_IFunction | .NET 6.0 | .NET 6.0 |    10 |    135.9 ns |   0.49 ns |   0.39 ns |    136.0 ns |  1.19 |    0.05 | 0.0420 |     - |     - |      88 B |
|                                       |          |          |       |             |           |           |             |       |         |        |       |       |           |
|                    **ValueLinq_Standard** | **.NET 5.0** | **.NET 5.0** |  **1000** |  **8,426.6 ns** |  **50.56 ns** |  **42.22 ns** |  **8,418.7 ns** |  **1.49** |    **0.03** | **1.9836** |     **-** |     **-** |   **4,168 B** |
|                       ValueLinq_Stack | .NET 5.0 | .NET 5.0 |  1000 |  8,162.0 ns |  29.16 ns |  24.35 ns |  8,160.2 ns |  1.44 |    0.03 | 1.9836 |     - |     - |   4,168 B |
|             ValueLinq_SharedPool_Push | .NET 5.0 | .NET 5.0 |  1000 |  9,367.4 ns |  44.76 ns |  41.87 ns |  9,366.7 ns |  1.64 |    0.04 | 0.9766 |     - |     - |   2,064 B |
|             ValueLinq_SharedPool_Pull | .NET 5.0 | .NET 5.0 |  1000 |  7,867.8 ns |  34.12 ns |  31.92 ns |  7,878.1 ns |  1.38 |    0.04 | 0.9766 |     - |     - |   2,064 B |
|        ValueLinq_ValueLambda_Standard | .NET 5.0 | .NET 5.0 |  1000 |  6,099.0 ns |  17.93 ns |  16.77 ns |  6,105.6 ns |  1.07 |    0.03 | 1.9913 |     - |     - |   4,168 B |
|           ValueLinq_ValueLambda_Stack | .NET 5.0 | .NET 5.0 |  1000 |  6,491.6 ns | 126.82 ns | 185.89 ns |  6,572.8 ns |  1.10 |    0.04 | 1.9913 |     - |     - |   4,168 B |
| ValueLinq_ValueLambda_SharedPool_Push | .NET 5.0 | .NET 5.0 |  1000 |  6,361.6 ns |  26.75 ns |  23.72 ns |  6,361.6 ns |  1.12 |    0.03 | 0.9842 |     - |     - |   2,064 B |
| ValueLinq_ValueLambda_SharedPool_Pull | .NET 5.0 | .NET 5.0 |  1000 |  5,906.4 ns |  20.73 ns |  19.39 ns |  5,907.5 ns |  1.04 |    0.03 | 0.9842 |     - |     - |   2,064 B |
|                           ForeachLoop | .NET 5.0 | .NET 5.0 |  1000 |  5,820.2 ns | 115.51 ns | 241.12 ns |  5,813.9 ns |  1.00 |    0.00 | 3.0441 |     - |     - |   6,368 B |
|                                  Linq | .NET 5.0 | .NET 5.0 |  1000 |  8,232.8 ns |  47.62 ns |  44.54 ns |  8,236.9 ns |  1.44 |    0.04 | 2.1820 |     - |     - |   4,584 B |
|                                LinqAF | .NET 5.0 | .NET 5.0 |  1000 |  9,481.0 ns |  45.56 ns |  40.39 ns |  9,476.3 ns |  1.67 |    0.05 | 3.0212 |     - |     - |   6,336 B |
|                            StructLinq | .NET 5.0 | .NET 5.0 |  1000 |  8,406.3 ns |  35.90 ns |  33.58 ns |  8,402.8 ns |  1.48 |    0.05 | 1.0223 |     - |     - |   2,152 B |
|                  StructLinq_IFunction | .NET 5.0 | .NET 5.0 |  1000 |  5,582.4 ns |  24.72 ns |  21.91 ns |  5,574.2 ns |  0.98 |    0.03 | 0.9842 |     - |     - |   2,064 B |
|                             Hyperlinq | .NET 5.0 | .NET 5.0 |  1000 |  8,137.6 ns |  38.61 ns |  32.24 ns |  8,145.9 ns |  1.44 |    0.03 | 0.9766 |     - |     - |   2,064 B |
|                   Hyperlinq_IFunction | .NET 5.0 | .NET 5.0 |  1000 |  5,838.8 ns |  12.62 ns |   9.85 ns |  5,839.3 ns |  1.03 |    0.02 | 0.9842 |     - |     - |   2,064 B |
|                                       |          |          |       |             |           |           |             |       |         |        |       |       |           |
|                    ValueLinq_Standard | .NET 6.0 | .NET 6.0 |  1000 |  8,482.0 ns | 169.05 ns | 236.98 ns |  8,580.3 ns |  1.44 |    0.09 | 1.9836 |     - |     - |   4,168 B |
|                       ValueLinq_Stack | .NET 6.0 | .NET 6.0 |  1000 |  8,611.8 ns | 167.64 ns | 235.01 ns |  8,465.8 ns |  1.46 |    0.04 | 1.9836 |     - |     - |   4,168 B |
|             ValueLinq_SharedPool_Push | .NET 6.0 | .NET 6.0 |  1000 |  8,673.3 ns |  30.96 ns |  25.85 ns |  8,673.2 ns |  1.42 |    0.05 | 0.9766 |     - |     - |   2,064 B |
|             ValueLinq_SharedPool_Pull | .NET 6.0 | .NET 6.0 |  1000 |  7,823.8 ns |  34.88 ns |  32.63 ns |  7,816.3 ns |  1.29 |    0.05 | 0.9766 |     - |     - |   2,064 B |
|        ValueLinq_ValueLambda_Standard | .NET 6.0 | .NET 6.0 |  1000 |  6,238.3 ns |  26.10 ns |  21.80 ns |  6,241.2 ns |  1.02 |    0.03 | 1.9913 |     - |     - |   4,168 B |
|           ValueLinq_ValueLambda_Stack | .NET 6.0 | .NET 6.0 |  1000 |  6,324.9 ns | 124.65 ns | 221.57 ns |  6,196.5 ns |  1.08 |    0.02 | 1.9913 |     - |     - |   4,168 B |
| ValueLinq_ValueLambda_SharedPool_Push | .NET 6.0 | .NET 6.0 |  1000 |  5,627.0 ns |  23.17 ns |  20.54 ns |  5,623.9 ns |  0.92 |    0.03 | 0.9842 |     - |     - |   2,064 B |
| ValueLinq_ValueLambda_SharedPool_Pull | .NET 6.0 | .NET 6.0 |  1000 |  6,239.2 ns |  61.80 ns |  51.61 ns |  6,228.1 ns |  1.02 |    0.04 | 0.9842 |     - |     - |   2,064 B |
|                           ForeachLoop | .NET 6.0 | .NET 6.0 |  1000 |  5,853.3 ns | 114.94 ns | 210.17 ns |  5,740.0 ns |  1.00 |    0.00 | 3.0441 |     - |     - |   6,368 B |
|                                  Linq | .NET 6.0 | .NET 6.0 |  1000 |  8,113.2 ns |  43.76 ns |  40.93 ns |  8,115.8 ns |  1.34 |    0.05 | 2.1820 |     - |     - |   4,584 B |
|                                LinqAF | .NET 6.0 | .NET 6.0 |  1000 | 10,191.0 ns | 194.70 ns | 191.22 ns | 10,245.4 ns |  1.69 |    0.08 | 3.0212 |     - |     - |   6,336 B |
|                            StructLinq | .NET 6.0 | .NET 6.0 |  1000 |  7,753.3 ns | 151.16 ns | 148.46 ns |  7,829.3 ns |  1.28 |    0.03 | 1.0223 |     - |     - |   2,152 B |
|                  StructLinq_IFunction | .NET 6.0 | .NET 6.0 |  1000 |  5,642.6 ns |  49.80 ns |  44.15 ns |  5,632.7 ns |  0.93 |    0.03 | 0.9842 |     - |     - |   2,064 B |
|                             Hyperlinq | .NET 6.0 | .NET 6.0 |  1000 |  8,437.8 ns | 109.70 ns |  97.25 ns |  8,453.6 ns |  1.39 |    0.05 | 0.9766 |     - |     - |   2,064 B |
|                   Hyperlinq_IFunction | .NET 6.0 | .NET 6.0 |  1000 |  5,788.9 ns |  94.12 ns |  96.66 ns |  5,741.2 ns |  0.96 |    0.04 | 0.9842 |     - |     - |   2,064 B |
