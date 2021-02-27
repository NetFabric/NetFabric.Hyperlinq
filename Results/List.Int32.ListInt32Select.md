## List.Int32.ListInt32Select

### Source
[ListInt32Select.cs](../LinqBenchmarks/List/Int32/ListInt32Select.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta41](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta41)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1516-nightly, OS=Windows 10.0.19042.844 (20H2/October2020Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.1.21103.13
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|                      Method | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                     **ForLoop** |    **10** |    **12.28 ns** |  **0.057 ns** |  **0.047 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop |    10 |    27.51 ns |  0.143 ns |  0.127 ns |  2.24 |    0.01 |      - |     - |     - |         - |
|                        Linq |    10 |   128.98 ns |  0.821 ns |  0.685 ns | 10.51 |    0.08 | 0.0343 |     - |     - |      72 B |
|                  LinqFaster |    10 |    54.10 ns |  0.490 ns |  0.434 ns |  4.40 |    0.04 | 0.0459 |     - |     - |      96 B |
|                      LinqAF |    10 |   118.31 ns |  0.746 ns |  0.698 ns |  9.63 |    0.06 |      - |     - |     - |         - |
|                  StructLinq |    10 |    42.30 ns |  0.270 ns |  0.225 ns |  3.45 |    0.02 | 0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction |    10 |    38.31 ns |  0.164 ns |  0.146 ns |  3.12 |    0.02 |      - |     - |     - |         - |
|           Hyperlinq_Foreach |    10 |    43.03 ns |  0.212 ns |  0.188 ns |  3.51 |    0.02 |      - |     - |     - |         - |
| Hyperlinq_IFunction_Foreach |    10 |    41.29 ns |  0.210 ns |  0.196 ns |  3.36 |    0.02 |      - |     - |     - |         - |
|               Hyperlinq_For |    10 |    33.41 ns |  0.189 ns |  0.168 ns |  2.72 |    0.02 |      - |     - |     - |         - |
|     Hyperlinq_IFunction_For |    10 |    22.65 ns |  0.107 ns |  0.089 ns |  1.85 |    0.01 |      - |     - |     - |         - |
|                             |       |             |           |           |       |         |        |       |       |           |
|                     **ForLoop** |  **1000** | **1,335.54 ns** |  **7.934 ns** |  **6.626 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop |  1000 | 2,431.36 ns | 14.939 ns | 12.475 ns |  1.82 |    0.01 |      - |     - |     - |         - |
|                        Linq |  1000 | 7,104.62 ns | 56.936 ns | 50.473 ns |  5.32 |    0.05 | 0.0305 |     - |     - |      72 B |
|                  LinqFaster |  1000 | 4,021.48 ns | 17.384 ns | 15.410 ns |  3.01 |    0.02 | 1.9379 |     - |     - |   4,056 B |
|                      LinqAF |  1000 | 7,112.76 ns | 44.658 ns | 39.588 ns |  5.32 |    0.05 |      - |     - |     - |         - |
|                  StructLinq |  1000 | 2,203.37 ns |  8.075 ns |  7.158 ns |  1.65 |    0.01 | 0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction |  1000 | 1,427.80 ns |  6.113 ns |  5.105 ns |  1.07 |    0.01 |      - |     - |     - |         - |
|           Hyperlinq_Foreach |  1000 | 2,163.17 ns | 13.401 ns | 11.191 ns |  1.62 |    0.01 |      - |     - |     - |         - |
| Hyperlinq_IFunction_Foreach |  1000 | 1,499.66 ns |  4.230 ns |  3.750 ns |  1.12 |    0.01 |      - |     - |     - |         - |
|               Hyperlinq_For |  1000 | 2,170.11 ns | 10.462 ns |  8.737 ns |  1.62 |    0.01 |      - |     - |     - |         - |
|     Hyperlinq_IFunction_For |  1000 |   817.35 ns |  4.382 ns |  4.098 ns |  0.61 |    0.00 |      - |     - |     - |         - |
