## Array.Int32.ArrayInt32SkipTakeSelect

### Source
[ArrayInt32SkipTakeSelect.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SkipTakeSelect.cs)

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
|                      Method |      Job |  Runtime | Skip | Count |          Mean |      Error |      StdDev |        Median |  Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |--------- |--------- |----- |------ |--------------:|-----------:|------------:|--------------:|-------:|--------:|-------:|------:|------:|----------:|
|                     **ForLoop** | **.NET 5.0** | **.NET 5.0** | **1000** |    **10** |      **7.464 ns** |  **0.0437 ns** |   **0.0388 ns** |      **7.458 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop | .NET 5.0 | .NET 5.0 | 1000 |    10 |  2,396.042 ns |  7.8523 ns |   6.9609 ns |  2,395.394 ns | 321.01 |    1.99 | 0.0153 |     - |     - |      32 B |
|                        Linq | .NET 5.0 | .NET 5.0 | 1000 |    10 |    192.992 ns |  0.4119 ns |   0.3216 ns |    193.001 ns |  25.86 |    0.13 | 0.0725 |     - |     - |     152 B |
|                  LinqFaster | .NET 5.0 | .NET 5.0 | 1000 |    10 |     61.875 ns |  0.4867 ns |   0.4314 ns |     61.871 ns |   8.29 |    0.07 | 0.0918 |     - |     - |     192 B |
|                      LinqAF | .NET 5.0 | .NET 5.0 | 1000 |    10 |  2,030.575 ns |  7.3843 ns |   6.9073 ns |  2,032.275 ns | 272.02 |    1.55 |      - |     - |     - |         - |
|                  StructLinq | .NET 5.0 | .NET 5.0 | 1000 |    10 |     77.622 ns |  0.2322 ns |   0.1939 ns |     77.640 ns |  10.39 |    0.06 | 0.0459 |     - |     - |      96 B |
|        StructLinq_IFunction | .NET 5.0 | .NET 5.0 | 1000 |    10 |     37.761 ns |  0.0945 ns |   0.0838 ns |     37.769 ns |   5.06 |    0.02 |      - |     - |     - |         - |
|           Hyperlinq_Foreach | .NET 5.0 | .NET 5.0 | 1000 |    10 |     59.295 ns |  0.3140 ns |   0.2622 ns |     59.423 ns |   7.94 |    0.05 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | .NET 5.0 | .NET 5.0 | 1000 |    10 |     61.050 ns |  0.1482 ns |   0.1386 ns |     61.080 ns |   8.18 |    0.05 |      - |     - |     - |         - |
|               Hyperlinq_For | .NET 5.0 | .NET 5.0 | 1000 |    10 |     48.412 ns |  0.1698 ns |   0.1505 ns |     48.380 ns |   6.49 |    0.04 |      - |     - |     - |         - |
|     Hyperlinq_For_IFunction | .NET 5.0 | .NET 5.0 | 1000 |    10 |     44.771 ns |  0.0674 ns |   0.0597 ns |     44.773 ns |   6.00 |    0.03 |      - |     - |     - |         - |
|                             |          |          |      |       |               |            |             |               |        |         |        |       |       |           |
|                     ForLoop | .NET 6.0 | .NET 6.0 | 1000 |    10 |      5.723 ns |  0.0186 ns |   0.0155 ns |      5.724 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|                 ForeachLoop | .NET 6.0 | .NET 6.0 | 1000 |    10 |  2,394.423 ns |  6.2032 ns |   5.4989 ns |  2,393.389 ns | 418.34 |    1.44 | 0.0153 |     - |     - |      32 B |
|                        Linq | .NET 6.0 | .NET 6.0 | 1000 |    10 |    182.071 ns |  3.6397 ns |   5.8775 ns |    184.567 ns |  30.87 |    1.15 | 0.0725 |     - |     - |     152 B |
|                  LinqFaster | .NET 6.0 | .NET 6.0 | 1000 |    10 |     58.972 ns |  0.5862 ns |   0.5196 ns |     58.801 ns |  10.31 |    0.11 | 0.0918 |     - |     - |     192 B |
|                      LinqAF | .NET 6.0 | .NET 6.0 | 1000 |    10 |  2,006.687 ns |  9.4808 ns |   7.9169 ns |  2,008.421 ns | 350.61 |    1.74 |      - |     - |     - |         - |
|                  StructLinq | .NET 6.0 | .NET 6.0 | 1000 |    10 |     83.394 ns |  0.4092 ns |   0.5869 ns |     83.153 ns |  14.55 |    0.10 | 0.0459 |     - |     - |      96 B |
|        StructLinq_IFunction | .NET 6.0 | .NET 6.0 | 1000 |    10 |     37.769 ns |  0.0940 ns |   0.0879 ns |     37.778 ns |   6.60 |    0.02 |      - |     - |     - |         - |
|           Hyperlinq_Foreach | .NET 6.0 | .NET 6.0 | 1000 |    10 |     58.793 ns |  0.1568 ns |   0.1467 ns |     58.791 ns |  10.27 |    0.04 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | .NET 6.0 | .NET 6.0 | 1000 |    10 |     59.310 ns |  0.3476 ns |   0.2714 ns |     59.292 ns |  10.37 |    0.06 |      - |     - |     - |         - |
|               Hyperlinq_For | .NET 6.0 | .NET 6.0 | 1000 |    10 |     48.294 ns |  0.3485 ns |   0.3089 ns |     48.269 ns |   8.44 |    0.07 |      - |     - |     - |         - |
|     Hyperlinq_For_IFunction | .NET 6.0 | .NET 6.0 | 1000 |    10 |     43.493 ns |  0.0877 ns |   0.0777 ns |     43.495 ns |   7.60 |    0.02 |      - |     - |     - |         - |
|                             |          |          |      |       |               |            |             |               |        |         |        |       |       |           |
|                     **ForLoop** | **.NET 5.0** | **.NET 5.0** | **1000** |  **1000** |    **786.267 ns** |  **2.1870 ns** |   **1.9387 ns** |    **786.415 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop | .NET 5.0 | .NET 5.0 | 1000 |  1000 |  4,464.799 ns |  9.4467 ns |   7.8885 ns |  4,464.463 ns |   5.68 |    0.02 | 0.0153 |     - |     - |      32 B |
|                        Linq | .NET 5.0 | .NET 5.0 | 1000 |  1000 |  9,322.148 ns | 45.1709 ns |  40.0428 ns |  9,322.946 ns |  11.86 |    0.05 | 0.0610 |     - |     - |     152 B |
|                  LinqFaster | .NET 5.0 | .NET 5.0 | 1000 |  1000 |  3,289.229 ns | 65.6332 ns | 157.2530 ns |  3,198.863 ns |   4.17 |    0.18 | 5.7678 |     - |     - |  12,072 B |
|                      LinqAF | .NET 5.0 | .NET 5.0 | 1000 |  1000 | 10,653.494 ns | 39.8626 ns |  33.2871 ns | 10,654.143 ns |  13.55 |    0.06 |      - |     - |     - |         - |
|                  StructLinq | .NET 5.0 | .NET 5.0 | 1000 |  1000 |  1,926.373 ns | 12.0658 ns |  10.0755 ns |  1,925.754 ns |   2.45 |    0.02 | 0.0458 |     - |     - |      96 B |
|        StructLinq_IFunction | .NET 5.0 | .NET 5.0 | 1000 |  1000 |  1,586.366 ns |  3.4319 ns |   2.8658 ns |  1,585.946 ns |   2.02 |    0.01 |      - |     - |     - |         - |
|           Hyperlinq_Foreach | .NET 5.0 | .NET 5.0 | 1000 |  1000 |  2,123.272 ns |  5.3467 ns |   4.7398 ns |  2,123.773 ns |   2.70 |    0.01 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | .NET 5.0 | .NET 5.0 | 1000 |  1000 |  1,703.343 ns | 13.3731 ns |  10.4409 ns |  1,707.274 ns |   2.17 |    0.02 |      - |     - |     - |         - |
|               Hyperlinq_For | .NET 5.0 | .NET 5.0 | 1000 |  1000 |  2,131.298 ns | 12.0503 ns |  10.0625 ns |  2,133.501 ns |   2.71 |    0.02 |      - |     - |     - |         - |
|     Hyperlinq_For_IFunction | .NET 5.0 | .NET 5.0 | 1000 |  1000 |    827.491 ns |  2.8448 ns |   2.5218 ns |    827.065 ns |   1.05 |    0.00 |      - |     - |     - |         - |
|                             |          |          |      |       |               |            |             |               |        |         |        |       |       |           |
|                     ForLoop | .NET 6.0 | .NET 6.0 | 1000 |  1000 |    553.525 ns |  2.1484 ns |   1.7941 ns |    553.082 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|                 ForeachLoop | .NET 6.0 | .NET 6.0 | 1000 |  1000 |  4,465.097 ns |  7.9381 ns |   6.6286 ns |  4,465.377 ns |   8.07 |    0.03 | 0.0153 |     - |     - |      32 B |
|                        Linq | .NET 6.0 | .NET 6.0 | 1000 |  1000 |  9,683.877 ns | 59.0409 ns |  55.2269 ns |  9,685.182 ns |  17.48 |    0.10 | 0.0610 |     - |     - |     152 B |
|                  LinqFaster | .NET 6.0 | .NET 6.0 | 1000 |  1000 |  3,030.059 ns | 35.1513 ns |  31.1607 ns |  3,035.166 ns |   5.47 |    0.06 | 5.7678 |     - |     - |  12,072 B |
|                      LinqAF | .NET 6.0 | .NET 6.0 | 1000 |  1000 | 11,159.870 ns | 52.7821 ns |  41.2088 ns | 11,168.734 ns |  20.16 |    0.10 |      - |     - |     - |         - |
|                  StructLinq | .NET 6.0 | .NET 6.0 | 1000 |  1000 |  2,228.743 ns | 21.1785 ns |  19.8104 ns |  2,230.900 ns |   4.03 |    0.04 | 0.0458 |     - |     - |      96 B |
|        StructLinq_IFunction | .NET 6.0 | .NET 6.0 | 1000 |  1000 |  1,581.151 ns |  3.4740 ns |   2.9010 ns |  1,580.037 ns |   2.86 |    0.01 |      - |     - |     - |         - |
|           Hyperlinq_Foreach | .NET 6.0 | .NET 6.0 | 1000 |  1000 |  1,877.267 ns |  6.5643 ns |   5.4815 ns |  1,878.330 ns |   3.39 |    0.01 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | .NET 6.0 | .NET 6.0 | 1000 |  1000 |  1,674.747 ns |  5.4000 ns |   5.0512 ns |  1,672.685 ns |   3.03 |    0.01 |      - |     - |     - |         - |
|               Hyperlinq_For | .NET 6.0 | .NET 6.0 | 1000 |  1000 |  2,128.574 ns | 11.1102 ns |  10.3925 ns |  2,130.031 ns |   3.85 |    0.03 |      - |     - |     - |         - |
|     Hyperlinq_For_IFunction | .NET 6.0 | .NET 6.0 | 1000 |  1000 |  1,086.582 ns |  4.3900 ns |   3.8916 ns |  1,086.816 ns |   1.96 |    0.01 |      - |     - |     - |         - |
