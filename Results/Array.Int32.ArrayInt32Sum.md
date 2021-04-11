## Array.Int32.ArrayInt32Sum

### Source
[ArrayInt32Sum.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Sum.cs)

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
|               Method |      Job |  Runtime | Count |         Mean |      Error |     StdDev |       Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |--------- |--------- |------ |-------------:|-----------:|-----------:|-------------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** | **.NET 5.0** | **.NET 5.0** |    **10** |     **5.061 ns** |  **0.0262 ns** |  **0.0232 ns** |     **5.059 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5.0 | .NET 5.0 |    10 |     5.028 ns |  0.0140 ns |  0.0131 ns |     5.028 ns |  0.99 |    0.01 |      - |     - |     - |         - |
|                 Linq | .NET 5.0 | .NET 5.0 |    10 |    55.057 ns |  1.1103 ns |  1.5198 ns |    54.175 ns | 11.08 |    0.27 | 0.0153 |     - |     - |      32 B |
|           LinqFaster | .NET 5.0 | .NET 5.0 |    10 |     4.469 ns |  0.0655 ns |  0.1038 ns |     4.442 ns |  0.88 |    0.01 |      - |     - |     - |         - |
|      LinqFaster_SIMD | .NET 5.0 | .NET 5.0 |    10 |     6.918 ns |  0.0537 ns |  0.0476 ns |     6.901 ns |  1.37 |    0.01 |      - |     - |     - |         - |
|               LinqAF | .NET 5.0 | .NET 5.0 |    10 |    30.370 ns |  0.1121 ns |  0.0993 ns |    30.377 ns |  6.00 |    0.03 |      - |     - |     - |         - |
|           StructLinq | .NET 5.0 | .NET 5.0 |    10 |    17.028 ns |  0.1442 ns |  0.1204 ns |    17.030 ns |  3.36 |    0.03 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 5.0 | .NET 5.0 |    10 |     6.645 ns |  0.0481 ns |  0.0450 ns |     6.633 ns |  1.31 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | .NET 5.0 | .NET 5.0 |    10 |    17.166 ns |  0.1439 ns |  0.1346 ns |    17.095 ns |  3.39 |    0.03 |      - |     - |     - |         - |
|                      |          |          |       |              |            |            |              |       |         |        |       |       |           |
|              ForLoop | .NET 6.0 | .NET 6.0 |    10 |     2.948 ns |  0.0139 ns |  0.0130 ns |     2.947 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 6.0 | .NET 6.0 |    10 |     2.958 ns |  0.0211 ns |  0.0187 ns |     2.963 ns |  1.00 |    0.01 |      - |     - |     - |         - |
|                 Linq | .NET 6.0 | .NET 6.0 |    10 |    52.792 ns |  1.0399 ns |  1.1559 ns |    53.204 ns | 17.84 |    0.40 | 0.0153 |     - |     - |      32 B |
|           LinqFaster | .NET 6.0 | .NET 6.0 |    10 |     4.328 ns |  0.0187 ns |  0.0175 ns |     4.328 ns |  1.47 |    0.01 |      - |     - |     - |         - |
|      LinqFaster_SIMD | .NET 6.0 | .NET 6.0 |    10 |     6.548 ns |  0.0344 ns |  0.0305 ns |     6.541 ns |  2.22 |    0.01 |      - |     - |     - |         - |
|               LinqAF | .NET 6.0 | .NET 6.0 |    10 |    31.778 ns |  0.1011 ns |  0.0896 ns |    31.768 ns | 10.78 |    0.07 |      - |     - |     - |         - |
|           StructLinq | .NET 6.0 | .NET 6.0 |    10 |    18.692 ns |  0.3967 ns |  0.5562 ns |    18.923 ns |  6.26 |    0.21 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 6.0 | .NET 6.0 |    10 |     6.556 ns |  0.0297 ns |  0.0278 ns |     6.552 ns |  2.22 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | .NET 6.0 | .NET 6.0 |    10 |    14.952 ns |  0.0449 ns |  0.0420 ns |    14.952 ns |  5.07 |    0.03 |      - |     - |     - |         - |
|                      |          |          |       |              |            |            |              |       |         |        |       |       |           |
|              **ForLoop** | **.NET 5.0** | **.NET 5.0** |  **1000** |   **525.511 ns** |  **1.4640 ns** |  **1.2978 ns** |   **525.315 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5.0 | .NET 5.0 |  1000 |   528.821 ns |  1.9477 ns |  1.8218 ns |   528.257 ns |  1.01 |    0.00 |      - |     - |     - |         - |
|                 Linq | .NET 5.0 | .NET 5.0 |  1000 | 4,345.981 ns | 23.1213 ns | 19.3073 ns | 4,348.800 ns |  8.27 |    0.04 | 0.0153 |     - |     - |      32 B |
|           LinqFaster | .NET 5.0 | .NET 5.0 |  1000 |   447.811 ns |  1.5871 ns |  1.4069 ns |   447.627 ns |  0.85 |    0.00 |      - |     - |     - |         - |
|      LinqFaster_SIMD | .NET 5.0 | .NET 5.0 |  1000 |    74.143 ns |  0.3558 ns |  0.3154 ns |    74.105 ns |  0.14 |    0.00 |      - |     - |     - |         - |
|               LinqAF | .NET 5.0 | .NET 5.0 |  1000 | 1,974.749 ns |  5.5381 ns |  4.9094 ns | 1,975.955 ns |  3.76 |    0.01 |      - |     - |     - |         - |
|           StructLinq | .NET 5.0 | .NET 5.0 |  1000 |   682.115 ns |  4.2574 ns |  3.5551 ns |   681.967 ns |  1.30 |    0.01 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 5.0 | .NET 5.0 |  1000 |   602.880 ns |  1.6992 ns |  1.5063 ns |   602.880 ns |  1.15 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq | .NET 5.0 | .NET 5.0 |  1000 |    88.570 ns |  0.2561 ns |  0.2270 ns |    88.546 ns |  0.17 |    0.00 |      - |     - |     - |         - |
|                      |          |          |       |              |            |            |              |       |         |        |       |       |           |
|              ForLoop | .NET 6.0 | .NET 6.0 |  1000 |   402.243 ns |  0.8637 ns |  0.7656 ns |   402.308 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 6.0 | .NET 6.0 |  1000 |   406.510 ns |  1.7004 ns |  1.4199 ns |   406.525 ns |  1.01 |    0.00 |      - |     - |     - |         - |
|                 Linq | .NET 6.0 | .NET 6.0 |  1000 | 3,972.698 ns | 44.6469 ns | 37.2822 ns | 3,964.253 ns |  9.88 |    0.10 | 0.0153 |     - |     - |      32 B |
|           LinqFaster | .NET 6.0 | .NET 6.0 |  1000 |   449.398 ns |  1.5790 ns |  1.3185 ns |   449.288 ns |  1.12 |    0.00 |      - |     - |     - |         - |
|      LinqFaster_SIMD | .NET 6.0 | .NET 6.0 |  1000 |    54.334 ns |  0.3355 ns |  0.2801 ns |    54.259 ns |  0.14 |    0.00 |      - |     - |     - |         - |
|               LinqAF | .NET 6.0 | .NET 6.0 |  1000 | 1,899.868 ns | 10.0931 ns |  8.9473 ns | 1,897.941 ns |  4.72 |    0.02 |      - |     - |     - |         - |
|           StructLinq | .NET 6.0 | .NET 6.0 |  1000 |   681.308 ns |  2.3654 ns |  2.0969 ns |   681.088 ns |  1.69 |    0.01 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 6.0 | .NET 6.0 |  1000 |   596.728 ns |  3.9681 ns |  3.5176 ns |   596.472 ns |  1.48 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | .NET 6.0 | .NET 6.0 |  1000 |    89.760 ns |  0.7662 ns |  0.5982 ns |    89.778 ns |  0.22 |    0.00 |      - |     - |     - |         - |
