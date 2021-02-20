## List.Int32.ListInt32Select

### Source
[ListInt32Select.cs](../LinqBenchmarks/List/Int32/ListInt32Select.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta39](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta39)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=6.0.100-preview.1.21103.13
  [Host]        : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                      Method | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |------ |-------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|                     **ForLoop** |    **10** |     **15.68 ns** |   **0.388 ns** |   **0.568 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop |    10 |     77.93 ns |   1.791 ns |   5.282 ns |  5.02 |    0.34 |      - |     - |     - |         - |
|                        Linq |    10 |    202.35 ns |   4.088 ns |   6.484 ns | 12.87 |    0.61 | 0.0343 |     - |     - |      72 B |
|                  LinqFaster |    10 |     62.14 ns |   0.590 ns |   0.493 ns |  4.02 |    0.16 | 0.0459 |     - |     - |      96 B |
|                      LinqAF |    10 |    217.38 ns |   4.059 ns |   5.949 ns | 13.89 |    0.68 |      - |     - |     - |         - |
|                  StructLinq |    10 |     38.99 ns |   0.073 ns |   0.065 ns |  2.52 |    0.10 | 0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction |    10 |     36.29 ns |   0.108 ns |   0.095 ns |  2.34 |    0.09 |      - |     - |     - |         - |
|           Hyperlinq_Foreach |    10 |     40.98 ns |   0.576 ns |   0.539 ns |  2.64 |    0.12 |      - |     - |     - |         - |
| Hyperlinq_IFunction_Foreach |    10 |     31.14 ns |   0.143 ns |   0.133 ns |  2.00 |    0.08 |      - |     - |     - |         - |
|               Hyperlinq_For |    10 |     26.80 ns |   0.048 ns |   0.038 ns |  1.74 |    0.07 |      - |     - |     - |         - |
|     Hyperlinq_IFunction_For |    10 |     16.05 ns |   0.050 ns |   0.044 ns |  1.04 |    0.04 |      - |     - |     - |         - |
|              Hyperlinq_SIMD |    10 |     45.19 ns |   0.819 ns |   0.726 ns |  2.92 |    0.14 |      - |     - |     - |         - |
|    Hyperlinq_SIMD_IFunction |    10 |     32.03 ns |   0.101 ns |   0.090 ns |  2.07 |    0.08 |      - |     - |     - |         - |
|                             |       |              |            |            |       |         |        |       |       |           |
|                     **ForLoop** |  **1000** |  **1,298.94 ns** |   **2.888 ns** |   **2.702 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop |  1000 |  6,047.63 ns | 135.701 ns | 400.119 ns |  4.66 |    0.32 |      - |     - |     - |         - |
|                        Linq |  1000 | 15,331.20 ns | 304.355 ns | 858.438 ns | 11.58 |    0.75 | 0.0305 |     - |     - |      72 B |
|                  LinqFaster |  1000 |  4,983.37 ns |  97.849 ns | 100.483 ns |  3.84 |    0.08 | 1.9379 |     - |     - |    4056 B |
|                      LinqAF |  1000 | 14,056.96 ns | 305.368 ns | 895.591 ns | 10.16 |    0.50 |      - |     - |     - |         - |
|                  StructLinq |  1000 |  2,251.79 ns |  44.938 ns |  65.870 ns |  1.75 |    0.06 | 0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction |  1000 |  1,396.26 ns |  17.323 ns |  34.994 ns |  1.09 |    0.04 |      - |     - |     - |         - |
|           Hyperlinq_Foreach |  1000 |  1,837.38 ns |   5.663 ns |   4.729 ns |  1.41 |    0.00 |      - |     - |     - |         - |
| Hyperlinq_IFunction_Foreach |  1000 |  1,565.58 ns |   2.909 ns |   2.579 ns |  1.20 |    0.00 |      - |     - |     - |         - |
|               Hyperlinq_For |  1000 |  2,081.46 ns |   4.263 ns |   3.988 ns |  1.60 |    0.00 |      - |     - |     - |         - |
|     Hyperlinq_IFunction_For |  1000 |    786.60 ns |   2.072 ns |   1.837 ns |  0.61 |    0.00 |      - |     - |     - |         - |
|              Hyperlinq_SIMD |  1000 |  1,844.33 ns |   4.357 ns |   3.638 ns |  1.42 |    0.00 |      - |     - |     - |         - |
|    Hyperlinq_SIMD_IFunction |  1000 |  1,426.40 ns |   3.490 ns |   2.914 ns |  1.10 |    0.00 |      - |     - |     - |         - |
