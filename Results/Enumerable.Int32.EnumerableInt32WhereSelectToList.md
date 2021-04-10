## Enumerable.Int32.EnumerableInt32WhereSelectToList

### Source
[EnumerableInt32WhereSelectToList.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelectToList.cs)

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
|                                Method | Count |         Mean |      Error |     StdDev |       Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |-------------:|-----------:|-----------:|-------------:|------:|--------:|-------:|------:|------:|----------:|
|                    **ValueLinq_Standard** |    **10** |    **237.12 ns** |   **0.771 ns** |   **0.684 ns** |    **237.34 ns** |  **2.38** |    **0.02** | **0.0801** |     **-** |     **-** |     **168 B** |
|                       ValueLinq_Stack |    10 |    244.00 ns |   1.124 ns |   0.997 ns |    244.09 ns |  2.45 |    0.02 | 0.0567 |     - |     - |     120 B |
|             ValueLinq_SharedPool_Push |    10 |    513.33 ns |   2.857 ns |   2.672 ns |    512.37 ns |  5.15 |    0.04 | 0.0572 |     - |     - |     120 B |
|             ValueLinq_SharedPool_Pull |    10 |    363.71 ns |   1.094 ns |   1.024 ns |    363.67 ns |  3.65 |    0.02 | 0.0572 |     - |     - |     120 B |
|        ValueLinq_ValueLambda_Standard |    10 |    225.38 ns |   1.005 ns |   0.891 ns |    225.21 ns |  2.26 |    0.01 | 0.0801 |     - |     - |     168 B |
|           ValueLinq_ValueLambda_Stack |    10 |    209.39 ns |   4.196 ns |   6.018 ns |    212.58 ns |  2.06 |    0.06 | 0.0572 |     - |     - |     120 B |
| ValueLinq_ValueLambda_SharedPool_Push |    10 |    388.11 ns |   1.671 ns |   1.396 ns |    388.41 ns |  3.89 |    0.02 | 0.0572 |     - |     - |     120 B |
| ValueLinq_ValueLambda_SharedPool_Pull |    10 |    355.06 ns |   7.169 ns |   8.256 ns |    357.37 ns |  3.54 |    0.09 | 0.0572 |     - |     - |     120 B |
|                           ForeachLoop |    10 |     99.73 ns |   0.631 ns |   0.559 ns |     99.59 ns |  1.00 |    0.00 | 0.0802 |     - |     - |     168 B |
|                                  Linq |    10 |    184.50 ns |   1.075 ns |   0.898 ns |    184.50 ns |  1.85 |    0.01 | 0.1376 |     - |     - |     288 B |
|                                LinqAF |    10 |    214.74 ns |   1.645 ns |   1.374 ns |    214.78 ns |  2.15 |    0.01 | 0.0799 |     - |     - |     168 B |
|                            StructLinq |    10 |    243.40 ns |   1.554 ns |   1.453 ns |    243.67 ns |  2.44 |    0.02 | 0.0992 |     - |     - |     208 B |
|                  StructLinq_IFunction |    10 |    168.27 ns |   0.780 ns |   0.730 ns |    168.01 ns |  1.69 |    0.01 | 0.0572 |     - |     - |     120 B |
|                             Hyperlinq |    10 |    188.76 ns |   1.190 ns |   0.994 ns |    189.03 ns |  1.89 |    0.02 | 0.0572 |     - |     - |     120 B |
|                   Hyperlinq_IFunction |    10 |    159.44 ns |   3.112 ns |   3.459 ns |    160.70 ns |  1.59 |    0.04 | 0.0572 |     - |     - |     120 B |
|                                       |       |              |            |            |              |       |         |        |       |       |           |
|                    **ValueLinq_Standard** |  **1000** |  **8,361.61 ns** |  **60.185 ns** |  **50.257 ns** |  **8,355.80 ns** |  **1.58** |    **0.01** | **2.0752** |     **-** |     **-** |   **4,344 B** |
|                       ValueLinq_Stack |  1000 |  8,877.00 ns |  36.189 ns |  32.081 ns |  8,878.95 ns |  1.68 |    0.01 | 1.9989 |     - |     - |   4,200 B |
|             ValueLinq_SharedPool_Push |  1000 |  9,466.10 ns |  53.895 ns |  50.414 ns |  9,455.12 ns |  1.79 |    0.01 | 0.9918 |     - |     - |   2,096 B |
|             ValueLinq_SharedPool_Pull |  1000 |  8,527.25 ns |  74.032 ns |  69.249 ns |  8,531.03 ns |  1.62 |    0.01 | 0.9918 |     - |     - |   2,096 B |
|        ValueLinq_ValueLambda_Standard |  1000 |  5,517.05 ns |  24.356 ns |  21.591 ns |  5,515.23 ns |  1.05 |    0.01 | 2.0752 |     - |     - |   4,344 B |
|           ValueLinq_ValueLambda_Stack |  1000 |  6,502.36 ns |  27.603 ns |  24.469 ns |  6,501.73 ns |  1.23 |    0.01 | 2.0065 |     - |     - |   4,200 B |
| ValueLinq_ValueLambda_SharedPool_Push |  1000 |  6,095.10 ns | 114.640 ns | 117.727 ns |  6,132.43 ns |  1.15 |    0.02 | 0.9995 |     - |     - |   2,096 B |
| ValueLinq_ValueLambda_SharedPool_Pull |  1000 |  6,374.89 ns |  89.966 ns |  75.126 ns |  6,351.78 ns |  1.21 |    0.02 | 0.9995 |     - |     - |   2,096 B |
|                           ForeachLoop |  1000 |  5,278.97 ns |  24.669 ns |  21.869 ns |  5,272.52 ns |  1.00 |    0.00 | 2.0752 |     - |     - |   4,344 B |
|                                  Linq |  1000 |  7,861.46 ns |  56.287 ns |  43.945 ns |  7,858.56 ns |  1.49 |    0.01 | 2.1210 |     - |     - |   4,464 B |
|                                LinqAF |  1000 | 10,550.15 ns |  75.278 ns |  66.732 ns | 10,573.48 ns |  2.00 |    0.02 | 2.0752 |     - |     - |   4,344 B |
|                            StructLinq |  1000 |  8,759.75 ns |  54.576 ns |  48.380 ns |  8,749.24 ns |  1.66 |    0.01 | 1.0376 |     - |     - |   2,184 B |
|                  StructLinq_IFunction |  1000 |  6,782.70 ns | 133.960 ns | 164.515 ns |  6,862.58 ns |  1.27 |    0.03 | 0.9995 |     - |     - |   2,096 B |
|                             Hyperlinq |  1000 |  8,349.39 ns | 149.372 ns | 139.723 ns |  8,335.43 ns |  1.58 |    0.03 | 0.9918 |     - |     - |   2,096 B |
|                   Hyperlinq_IFunction |  1000 |  6,010.54 ns |  20.445 ns |  19.125 ns |  6,013.20 ns |  1.14 |    0.01 | 0.9995 |     - |     - |   2,096 B |
