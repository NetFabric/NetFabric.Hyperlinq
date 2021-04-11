## List.Int32.ListInt32Select

### Source
[ListInt32Select.cs](../LinqBenchmarks/List/Int32/ListInt32Select.cs)

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
|                      Method |      Job |  Runtime | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |--------- |--------- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                     **ForLoop** | **.NET 5.0** | **.NET 5.0** |    **10** |    **10.94 ns** |  **0.040 ns** |  **0.033 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop | .NET 5.0 | .NET 5.0 |    10 |    26.21 ns |  0.194 ns |  0.182 ns |  2.39 |    0.02 |      - |     - |     - |         - |
|                        Linq | .NET 5.0 | .NET 5.0 |    10 |   137.92 ns |  2.548 ns |  3.488 ns | 12.37 |    0.28 | 0.0343 |     - |     - |      72 B |
|                  LinqFaster | .NET 5.0 | .NET 5.0 |    10 |    49.69 ns |  0.723 ns |  0.641 ns |  4.54 |    0.06 | 0.0459 |     - |     - |      96 B |
|                      LinqAF | .NET 5.0 | .NET 5.0 |    10 |   116.67 ns |  0.531 ns |  0.470 ns | 10.67 |    0.06 |      - |     - |     - |         - |
|                  StructLinq | .NET 5.0 | .NET 5.0 |    10 |    40.23 ns |  0.177 ns |  0.138 ns |  3.68 |    0.02 | 0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction | .NET 5.0 | .NET 5.0 |    10 |    38.14 ns |  0.108 ns |  0.101 ns |  3.49 |    0.01 |      - |     - |     - |         - |
|           Hyperlinq_Foreach | .NET 5.0 | .NET 5.0 |    10 |    42.44 ns |  0.111 ns |  0.103 ns |  3.88 |    0.01 |      - |     - |     - |         - |
| Hyperlinq_IFunction_Foreach | .NET 5.0 | .NET 5.0 |    10 |    41.79 ns |  0.119 ns |  0.112 ns |  3.82 |    0.02 |      - |     - |     - |         - |
|               Hyperlinq_For | .NET 5.0 | .NET 5.0 |    10 |    33.02 ns |  0.134 ns |  0.118 ns |  3.02 |    0.01 |      - |     - |     - |         - |
|     Hyperlinq_IFunction_For | .NET 5.0 | .NET 5.0 |    10 |    25.47 ns |  0.061 ns |  0.057 ns |  2.33 |    0.01 |      - |     - |     - |         - |
|                             |          |          |       |             |           |           |       |         |        |       |       |           |
|                     ForLoop | .NET 6.0 | .NET 6.0 |    10 |    10.57 ns |  0.073 ns |  0.061 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                 ForeachLoop | .NET 6.0 | .NET 6.0 |    10 |    16.47 ns |  0.070 ns |  0.059 ns |  1.56 |    0.01 |      - |     - |     - |         - |
|                        Linq | .NET 6.0 | .NET 6.0 |    10 |   118.08 ns |  0.978 ns |  0.816 ns | 11.17 |    0.07 | 0.0343 |     - |     - |      72 B |
|                  LinqFaster | .NET 6.0 | .NET 6.0 |    10 |    47.11 ns |  0.715 ns |  1.325 ns |  4.55 |    0.20 | 0.0459 |     - |     - |      96 B |
|                      LinqAF | .NET 6.0 | .NET 6.0 |    10 |   115.18 ns |  0.269 ns |  0.239 ns | 10.89 |    0.06 |      - |     - |     - |         - |
|                  StructLinq | .NET 6.0 | .NET 6.0 |    10 |    40.25 ns |  0.165 ns |  0.128 ns |  3.81 |    0.02 | 0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction | .NET 6.0 | .NET 6.0 |    10 |    38.01 ns |  0.143 ns |  0.127 ns |  3.59 |    0.02 |      - |     - |     - |         - |
|           Hyperlinq_Foreach | .NET 6.0 | .NET 6.0 |    10 |    43.00 ns |  0.245 ns |  0.204 ns |  4.07 |    0.03 |      - |     - |     - |         - |
| Hyperlinq_IFunction_Foreach | .NET 6.0 | .NET 6.0 |    10 |    41.78 ns |  0.090 ns |  0.084 ns |  3.95 |    0.03 |      - |     - |     - |         - |
|               Hyperlinq_For | .NET 6.0 | .NET 6.0 |    10 |    34.47 ns |  0.096 ns |  0.090 ns |  3.26 |    0.02 |      - |     - |     - |         - |
|     Hyperlinq_IFunction_For | .NET 6.0 | .NET 6.0 |    10 |    24.98 ns |  0.178 ns |  0.166 ns |  2.37 |    0.02 |      - |     - |     - |         - |
|                             |          |          |       |             |           |           |       |         |        |       |       |           |
|                     **ForLoop** | **.NET 5.0** | **.NET 5.0** |  **1000** | **1,305.87 ns** |  **5.583 ns** |  **4.662 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop | .NET 5.0 | .NET 5.0 |  1000 | 2,367.64 ns |  7.299 ns |  6.828 ns |  1.81 |    0.01 |      - |     - |     - |         - |
|                        Linq | .NET 5.0 | .NET 5.0 |  1000 | 7,653.56 ns | 31.957 ns | 29.893 ns |  5.86 |    0.02 | 0.0305 |     - |     - |      72 B |
|                  LinqFaster | .NET 5.0 | .NET 5.0 |  1000 | 3,993.85 ns | 25.584 ns | 22.680 ns |  3.06 |    0.02 | 1.9379 |     - |     - |   4,056 B |
|                      LinqAF | .NET 5.0 | .NET 5.0 |  1000 | 6,937.10 ns |  8.475 ns |  7.077 ns |  5.31 |    0.02 |      - |     - |     - |         - |
|                  StructLinq | .NET 5.0 | .NET 5.0 |  1000 | 1,897.94 ns |  7.761 ns |  6.880 ns |  1.45 |    0.01 | 0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction | .NET 5.0 | .NET 5.0 |  1000 | 1,462.74 ns |  3.258 ns |  2.888 ns |  1.12 |    0.00 |      - |     - |     - |         - |
|           Hyperlinq_Foreach | .NET 5.0 | .NET 5.0 |  1000 | 2,107.84 ns |  8.732 ns |  7.741 ns |  1.61 |    0.01 |      - |     - |     - |         - |
| Hyperlinq_IFunction_Foreach | .NET 5.0 | .NET 5.0 |  1000 | 1,669.79 ns | 13.168 ns | 11.673 ns |  1.28 |    0.01 |      - |     - |     - |         - |
|               Hyperlinq_For | .NET 5.0 | .NET 5.0 |  1000 | 1,842.95 ns |  4.690 ns |  4.157 ns |  1.41 |    0.01 |      - |     - |     - |         - |
|     Hyperlinq_IFunction_For | .NET 5.0 | .NET 5.0 |  1000 |   806.76 ns |  3.290 ns |  2.917 ns |  0.62 |    0.00 |      - |     - |     - |         - |
|                             |          |          |       |             |           |           |       |         |        |       |       |           |
|                     ForLoop | .NET 6.0 | .NET 6.0 |  1000 |   984.54 ns |  3.277 ns |  3.066 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                 ForeachLoop | .NET 6.0 | .NET 6.0 |  1000 | 1,585.80 ns |  7.362 ns |  6.526 ns |  1.61 |    0.01 |      - |     - |     - |         - |
|                        Linq | .NET 6.0 | .NET 6.0 |  1000 | 6,608.29 ns | 22.653 ns | 21.189 ns |  6.71 |    0.03 | 0.0305 |     - |     - |      72 B |
|                  LinqFaster | .NET 6.0 | .NET 6.0 |  1000 | 3,522.10 ns | 10.227 ns |  8.540 ns |  3.58 |    0.01 | 1.9379 |     - |     - |   4,056 B |
|                      LinqAF | .NET 6.0 | .NET 6.0 |  1000 | 6,752.14 ns | 26.506 ns | 23.497 ns |  6.86 |    0.03 |      - |     - |     - |         - |
|                  StructLinq | .NET 6.0 | .NET 6.0 |  1000 | 1,881.98 ns |  9.701 ns |  8.600 ns |  1.91 |    0.01 | 0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction | .NET 6.0 | .NET 6.0 |  1000 | 1,473.65 ns |  3.339 ns |  3.123 ns |  1.50 |    0.01 |      - |     - |     - |         - |
|           Hyperlinq_Foreach | .NET 6.0 | .NET 6.0 |  1000 | 2,173.36 ns | 12.541 ns | 11.731 ns |  2.21 |    0.01 |      - |     - |     - |         - |
| Hyperlinq_IFunction_Foreach | .NET 6.0 | .NET 6.0 |  1000 | 1,654.93 ns |  5.774 ns |  5.119 ns |  1.68 |    0.01 |      - |     - |     - |         - |
|               Hyperlinq_For | .NET 6.0 | .NET 6.0 |  1000 | 2,127.25 ns |  6.811 ns |  6.371 ns |  2.16 |    0.01 |      - |     - |     - |         - |
|     Hyperlinq_IFunction_For | .NET 6.0 | .NET 6.0 |  1000 | 1,573.35 ns |  2.816 ns |  2.634 ns |  1.60 |    0.00 |      - |     - |     - |         - |
