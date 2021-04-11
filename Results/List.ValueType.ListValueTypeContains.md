## List.ValueType.ListValueTypeContains

### Source
[ListValueTypeContains.cs](../LinqBenchmarks/List/ValueType/ListValueTypeContains.cs)

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
|               Method |      Job |  Runtime | Count |        Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |--------- |--------- |------ |------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** | **.NET 5.0** | **.NET 5.0** |    **10** |    **57.54 ns** |   **0.169 ns** |   **0.141 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5.0 | .NET 5.0 |    10 |    97.75 ns |   1.940 ns |   2.156 ns |  1.69 |    0.04 |      - |     - |     - |         - |
|                 Linq | .NET 5.0 | .NET 5.0 |    10 |    31.05 ns |   0.080 ns |   0.067 ns |  0.54 |    0.00 |      - |     - |     - |         - |
|           LinqFaster | .NET 5.0 | .NET 5.0 |    10 |    29.37 ns |   0.091 ns |   0.080 ns |  0.51 |    0.00 |      - |     - |     - |         - |
|               LinqAF | .NET 5.0 | .NET 5.0 |    10 |    32.75 ns |   0.184 ns |   0.143 ns |  0.57 |    0.00 |      - |     - |     - |         - |
|           StructLinq | .NET 5.0 | .NET 5.0 |    10 |    54.80 ns |   0.265 ns |   0.260 ns |  0.95 |    0.00 | 0.0191 |     - |     - |      40 B |
| StructLinq_IFunction | .NET 5.0 | .NET 5.0 |    10 |    58.02 ns |   0.732 ns |   0.611 ns |  1.01 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | .NET 5.0 | .NET 5.0 |    10 |    29.65 ns |   0.531 ns |   0.443 ns |  0.52 |    0.01 |      - |     - |     - |         - |
|                      |          |          |       |             |            |            |       |         |        |       |       |           |
|              ForLoop | .NET 6.0 | .NET 6.0 |    10 |    58.02 ns |   0.448 ns |   0.419 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 6.0 | .NET 6.0 |    10 |   106.87 ns |   2.062 ns |   1.928 ns |  1.84 |    0.03 |      - |     - |     - |         - |
|                 Linq | .NET 6.0 | .NET 6.0 |    10 |    29.33 ns |   0.517 ns |   0.459 ns |  0.51 |    0.01 |      - |     - |     - |         - |
|           LinqFaster | .NET 6.0 | .NET 6.0 |    10 |    29.30 ns |   0.600 ns |   0.691 ns |  0.51 |    0.02 |      - |     - |     - |         - |
|               LinqAF | .NET 6.0 | .NET 6.0 |    10 |    29.37 ns |   0.313 ns |   0.278 ns |  0.51 |    0.01 |      - |     - |     - |         - |
|           StructLinq | .NET 6.0 | .NET 6.0 |    10 |    50.72 ns |   0.583 ns |   0.546 ns |  0.87 |    0.01 | 0.0191 |     - |     - |      40 B |
| StructLinq_IFunction | .NET 6.0 | .NET 6.0 |    10 |    60.15 ns |   0.605 ns |   0.536 ns |  1.04 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | .NET 6.0 | .NET 6.0 |    10 |    30.68 ns |   0.172 ns |   0.153 ns |  0.53 |    0.01 |      - |     - |     - |         - |
|                      |          |          |       |             |            |            |       |         |        |       |       |           |
|              **ForLoop** | **.NET 5.0** | **.NET 5.0** |  **1000** | **6,694.92 ns** |  **52.770 ns** |  **46.779 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5.0 | .NET 5.0 |  1000 | 8,235.31 ns | 156.429 ns | 238.884 ns |  1.22 |    0.04 |      - |     - |     - |         - |
|                 Linq | .NET 5.0 | .NET 5.0 |  1000 | 2,097.93 ns |  12.811 ns |  10.698 ns |  0.31 |    0.00 |      - |     - |     - |         - |
|           LinqFaster | .NET 5.0 | .NET 5.0 |  1000 | 1,876.10 ns |  23.321 ns |  20.673 ns |  0.28 |    0.00 |      - |     - |     - |         - |
|               LinqAF | .NET 5.0 | .NET 5.0 |  1000 | 2,407.40 ns |  29.294 ns |  27.402 ns |  0.36 |    0.01 |      - |     - |     - |         - |
|           StructLinq | .NET 5.0 | .NET 5.0 |  1000 | 4,247.56 ns |  81.915 ns |  84.120 ns |  0.63 |    0.01 | 0.0153 |     - |     - |      40 B |
| StructLinq_IFunction | .NET 5.0 | .NET 5.0 |  1000 | 4,113.52 ns |  18.752 ns |  15.659 ns |  0.61 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | .NET 5.0 | .NET 5.0 |  1000 | 1,855.38 ns |   6.661 ns |   5.905 ns |  0.28 |    0.00 |      - |     - |     - |         - |
|                      |          |          |       |             |            |            |       |         |        |       |       |           |
|              ForLoop | .NET 6.0 | .NET 6.0 |  1000 | 6,448.94 ns |  23.153 ns |  21.658 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 6.0 | .NET 6.0 |  1000 | 8,020.80 ns | 158.372 ns | 232.139 ns |  1.25 |    0.03 |      - |     - |     - |         - |
|                 Linq | .NET 6.0 | .NET 6.0 |  1000 | 1,852.89 ns |   6.824 ns |   6.049 ns |  0.29 |    0.00 |      - |     - |     - |         - |
|           LinqFaster | .NET 6.0 | .NET 6.0 |  1000 | 2,104.08 ns |   7.136 ns |   6.325 ns |  0.33 |    0.00 |      - |     - |     - |         - |
|               LinqAF | .NET 6.0 | .NET 6.0 |  1000 | 2,106.69 ns |   6.796 ns |   5.675 ns |  0.33 |    0.00 |      - |     - |     - |         - |
|           StructLinq | .NET 6.0 | .NET 6.0 |  1000 | 3,497.08 ns |  17.241 ns |  15.283 ns |  0.54 |    0.00 | 0.0153 |     - |     - |      40 B |
| StructLinq_IFunction | .NET 6.0 | .NET 6.0 |  1000 | 3,940.96 ns |  14.816 ns |  13.134 ns |  0.61 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq | .NET 6.0 | .NET 6.0 |  1000 | 2,117.65 ns |   8.970 ns |   7.490 ns |  0.33 |    0.00 |      - |     - |     - |         - |
