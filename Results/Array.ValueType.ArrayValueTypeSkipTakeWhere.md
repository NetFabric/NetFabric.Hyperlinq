## Array.ValueType.ArrayValueTypeSkipTakeWhere

### Source
[ArrayValueTypeSkipTakeWhere.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSkipTakeWhere.cs)

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
|               Method |      Job |  Runtime | Skip | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |    Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |--------- |--------- |----- |------ |-------------:|-----------:|-----------:|------:|--------:|---------:|------:|------:|----------:|
|              **ForLoop** | **.NET 5.0** | **.NET 5.0** | **1000** |    **10** |     **57.32 ns** |   **0.675 ns** |   **0.564 ns** |  **1.00** |    **0.00** |        **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5.0 | .NET 5.0 | 1000 |    10 |  3,221.93 ns |  62.695 ns |  87.889 ns | 56.51 |    1.63 |   0.0153 |     - |     - |      32 B |
|                 Linq | .NET 5.0 | .NET 5.0 | 1000 |    10 |    361.13 ns |   9.326 ns |  27.498 ns |  6.70 |    0.40 |   0.1526 |     - |     - |     320 B |
|           LinqFaster | .NET 5.0 | .NET 5.0 | 1000 |    10 |    251.00 ns |   9.142 ns |  24.083 ns |  5.10 |    0.66 |   1.1168 |     - |     - |   2,336 B |
|               LinqAF | .NET 5.0 | .NET 5.0 | 1000 |    10 |  5,346.99 ns | 104.936 ns | 107.761 ns | 93.59 |    2.12 |        - |     - |     - |         - |
|           StructLinq | .NET 5.0 | .NET 5.0 | 1000 |    10 |    124.07 ns |   0.821 ns |   0.768 ns |  2.17 |    0.02 |   0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | .NET 5.0 | .NET 5.0 | 1000 |    10 |     87.93 ns |   0.175 ns |   0.164 ns |  1.53 |    0.01 |        - |     - |     - |         - |
|            Hyperlinq | .NET 5.0 | .NET 5.0 | 1000 |    10 |    148.30 ns |   0.485 ns |   0.430 ns |  2.59 |    0.02 |        - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 5.0 | .NET 5.0 | 1000 |    10 |    122.76 ns |   0.514 ns |   0.481 ns |  2.14 |    0.02 |        - |     - |     - |         - |
|                      |          |          |      |       |              |            |            |       |         |          |       |       |           |
|              ForLoop | .NET 6.0 | .NET 6.0 | 1000 |    10 |     52.01 ns |   0.076 ns |   0.063 ns |  1.00 |    0.00 |        - |     - |     - |         - |
|          ForeachLoop | .NET 6.0 | .NET 6.0 | 1000 |    10 |  2,227.40 ns |  16.369 ns |  13.669 ns | 42.83 |    0.26 |   0.0153 |     - |     - |      32 B |
|                 Linq | .NET 6.0 | .NET 6.0 | 1000 |    10 |    287.34 ns |   1.519 ns |   1.347 ns |  5.52 |    0.03 |   0.1526 |     - |     - |     320 B |
|           LinqFaster | .NET 6.0 | .NET 6.0 | 1000 |    10 |    247.29 ns |   2.264 ns |   2.118 ns |  4.76 |    0.04 |   1.1168 |     - |     - |   2,336 B |
|               LinqAF | .NET 6.0 | .NET 6.0 | 1000 |    10 |  4,707.03 ns |  91.956 ns | 128.909 ns | 89.73 |    2.42 |        - |     - |     - |         - |
|           StructLinq | .NET 6.0 | .NET 6.0 | 1000 |    10 |    133.20 ns |   0.728 ns |   0.646 ns |  2.56 |    0.01 |   0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | .NET 6.0 | .NET 6.0 | 1000 |    10 |     88.62 ns |   0.167 ns |   0.148 ns |  1.70 |    0.00 |        - |     - |     - |         - |
|            Hyperlinq | .NET 6.0 | .NET 6.0 | 1000 |    10 |    147.39 ns |   0.418 ns |   0.370 ns |  2.83 |    0.01 |        - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 6.0 | .NET 6.0 | 1000 |    10 |    122.76 ns |   0.554 ns |   0.518 ns |  2.36 |    0.01 |        - |     - |     - |         - |
|                      |          |          |      |       |              |            |            |       |         |          |       |       |           |
|              **ForLoop** | **.NET 5.0** | **.NET 5.0** | **1000** |  **1000** |  **5,066.63 ns** |  **46.575 ns** |  **41.288 ns** |  **1.00** |    **0.00** |        **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5.0 | .NET 5.0 | 1000 |  1000 |  5,056.16 ns |  24.438 ns |  20.407 ns |  1.00 |    0.01 |   0.0153 |     - |     - |      32 B |
|                 Linq | .NET 5.0 | .NET 5.0 | 1000 |  1000 | 21,168.58 ns |  98.067 ns |  86.934 ns |  4.18 |    0.04 |   0.1526 |     - |     - |     320 B |
|           LinqFaster | .NET 5.0 | .NET 5.0 | 1000 |  1000 | 27,022.42 ns | 319.239 ns | 266.579 ns |  5.34 |    0.05 | 105.2551 |     - |     - | 223,520 B |
|               LinqAF | .NET 5.0 | .NET 5.0 | 1000 |  1000 | 30,560.64 ns | 579.684 ns | 711.904 ns |  6.02 |    0.15 |        - |     - |     - |         - |
|           StructLinq | .NET 5.0 | .NET 5.0 | 1000 |  1000 |  8,357.34 ns |  63.808 ns |  56.564 ns |  1.65 |    0.01 |   0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | .NET 5.0 | .NET 5.0 | 1000 |  1000 |  6,067.84 ns |  25.267 ns |  21.099 ns |  1.20 |    0.01 |        - |     - |     - |         - |
|            Hyperlinq | .NET 5.0 | .NET 5.0 | 1000 |  1000 | 13,846.93 ns |  91.645 ns |  76.528 ns |  2.73 |    0.02 |        - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 5.0 | .NET 5.0 | 1000 |  1000 |  8,769.84 ns |  33.370 ns |  29.582 ns |  1.73 |    0.02 |        - |     - |     - |         - |
|                      |          |          |      |       |              |            |            |       |         |          |       |       |           |
|              ForLoop | .NET 6.0 | .NET 6.0 | 1000 |  1000 |  5,046.35 ns |  12.078 ns |  10.085 ns |  1.00 |    0.00 |        - |     - |     - |         - |
|          ForeachLoop | .NET 6.0 | .NET 6.0 | 1000 |  1000 |  5,512.55 ns |  15.110 ns |  14.134 ns |  1.09 |    0.00 |   0.0153 |     - |     - |      32 B |
|                 Linq | .NET 6.0 | .NET 6.0 | 1000 |  1000 | 21,707.10 ns |  89.183 ns |  74.472 ns |  4.30 |    0.01 |   0.1526 |     - |     - |     320 B |
|           LinqFaster | .NET 6.0 | .NET 6.0 | 1000 |  1000 | 23,692.89 ns | 133.257 ns | 236.864 ns |  4.69 |    0.04 | 105.2551 |     - |     - | 223,520 B |
|               LinqAF | .NET 6.0 | .NET 6.0 | 1000 |  1000 | 30,872.52 ns | 565.221 ns | 471.985 ns |  6.12 |    0.09 |        - |     - |     - |         - |
|           StructLinq | .NET 6.0 | .NET 6.0 | 1000 |  1000 |  7,940.96 ns |  26.484 ns |  23.477 ns |  1.57 |    0.01 |   0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | .NET 6.0 | .NET 6.0 | 1000 |  1000 |  6,094.42 ns |  14.176 ns |  12.567 ns |  1.21 |    0.00 |        - |     - |     - |         - |
|            Hyperlinq | .NET 6.0 | .NET 6.0 | 1000 |  1000 | 13,912.34 ns |  35.470 ns |  29.619 ns |  2.76 |    0.01 |        - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 6.0 | .NET 6.0 | 1000 |  1000 |  8,912.96 ns |  40.141 ns |  33.520 ns |  1.77 |    0.01 |        - |     - |     - |         - |
