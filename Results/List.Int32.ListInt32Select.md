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

BenchmarkDotNet=v0.12.1.1517-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.1.21103.13
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|                      Method | Count |        Mean |      Error |     StdDev |      Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |------ |------------:|-----------:|-----------:|------------:|------:|--------:|-------:|------:|------:|----------:|
|                     **ForLoop** |    **10** |    **12.44 ns** |   **0.024 ns** |   **0.022 ns** |    **12.44 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop |    10 |    26.54 ns |   0.063 ns |   0.059 ns |    26.52 ns |  2.13 |    0.01 |      - |     - |     - |         - |
|                        Linq |    10 |   122.67 ns |   0.392 ns |   0.327 ns |   122.62 ns |  9.86 |    0.03 | 0.0343 |     - |     - |      72 B |
|                  LinqFaster |    10 |    49.29 ns |   0.284 ns |   0.251 ns |    49.23 ns |  3.96 |    0.02 | 0.0459 |     - |     - |      96 B |
|                      LinqAF |    10 |   113.35 ns |   0.283 ns |   0.251 ns |   113.33 ns |  9.11 |    0.02 |      - |     - |     - |         - |
|                  StructLinq |    10 |    40.05 ns |   0.068 ns |   0.060 ns |    40.05 ns |  3.22 |    0.01 | 0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction |    10 |    37.56 ns |   0.090 ns |   0.080 ns |    37.54 ns |  3.02 |    0.01 |      - |     - |     - |         - |
|           Hyperlinq_Foreach |    10 |    42.47 ns |   0.118 ns |   0.105 ns |    42.45 ns |  3.41 |    0.01 |      - |     - |     - |         - |
| Hyperlinq_IFunction_Foreach |    10 |    40.38 ns |   0.086 ns |   0.072 ns |    40.39 ns |  3.25 |    0.01 |      - |     - |     - |         - |
|               Hyperlinq_For |    10 |    32.50 ns |   0.118 ns |   0.099 ns |    32.49 ns |  2.61 |    0.01 |      - |     - |     - |         - |
|     Hyperlinq_IFunction_For |    10 |    22.22 ns |   0.041 ns |   0.037 ns |    22.21 ns |  1.79 |    0.00 |      - |     - |     - |         - |
|                             |       |             |            |            |             |       |         |        |       |       |           |
|                     **ForLoop** |  **1000** | **1,300.44 ns** |   **2.557 ns** |   **2.267 ns** | **1,300.52 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop |  1000 | 2,356.20 ns |   7.380 ns |   6.903 ns | 2,356.81 ns |  1.81 |    0.01 |      - |     - |     - |         - |
|                        Linq |  1000 | 6,845.05 ns |  10.166 ns |   9.012 ns | 6,845.16 ns |  5.26 |    0.01 | 0.0305 |     - |     - |      72 B |
|                  LinqFaster |  1000 | 3,764.41 ns |   9.374 ns |   7.827 ns | 3,766.55 ns |  2.89 |    0.01 | 1.9379 |     - |     - |   4,056 B |
|                      LinqAF |  1000 | 6,961.82 ns |  18.663 ns |  16.545 ns | 6,962.75 ns |  5.35 |    0.02 |      - |     - |     - |         - |
|                  StructLinq |  1000 | 2,139.82 ns |   8.215 ns |   7.282 ns | 2,137.89 ns |  1.65 |    0.00 | 0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction |  1000 | 1,402.72 ns |   2.914 ns |   2.726 ns | 1,403.25 ns |  1.08 |    0.00 |      - |     - |     - |         - |
|           Hyperlinq_Foreach |  1000 | 2,517.24 ns | 202.498 ns | 571.150 ns | 2,201.49 ns |  1.78 |    0.08 |      - |     - |     - |         - |
| Hyperlinq_IFunction_Foreach |  1000 | 1,467.33 ns |   3.509 ns |   3.110 ns | 1,466.50 ns |  1.13 |    0.00 |      - |     - |     - |         - |
|               Hyperlinq_For |  1000 | 2,170.22 ns |   6.222 ns |   4.857 ns | 2,170.01 ns |  1.67 |    0.00 |      - |     - |     - |         - |
|     Hyperlinq_IFunction_For |  1000 |   796.13 ns |   1.504 ns |   1.256 ns |   795.89 ns |  0.61 |    0.00 |      - |     - |     - |         - |
