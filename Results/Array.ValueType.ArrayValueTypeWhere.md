## Array.ValueType.ArrayValueTypeWhere

### Source
[ArrayValueTypeWhere.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhere.cs)

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
|               Method |      Job |  Runtime | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |--------- |--------- |------ |-------------:|-----------:|-----------:|------:|--------:|--------:|------:|------:|----------:|
|              **ForLoop** | **.NET 5.0** | **.NET 5.0** |    **10** |     **23.34 ns** |   **0.046 ns** |   **0.041 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5.0 | .NET 5.0 |    10 |     33.01 ns |   0.099 ns |   0.092 ns |  1.41 |    0.00 |       - |     - |     - |         - |
|                 Linq | .NET 5.0 | .NET 5.0 |    10 |     98.60 ns |   1.976 ns |   3.759 ns |  4.30 |    0.27 |  0.0497 |     - |     - |     104 B |
|           LinqFaster | .NET 5.0 | .NET 5.0 |    10 |     93.77 ns |   1.268 ns |   1.186 ns |  4.01 |    0.05 |  0.3901 |     - |     - |     816 B |
|               LinqAF | .NET 5.0 | .NET 5.0 |    10 |    146.00 ns |   2.814 ns |   3.128 ns |  6.30 |    0.12 |       - |     - |     - |         - |
|           StructLinq | .NET 5.0 | .NET 5.0 |    10 |     60.40 ns |   0.300 ns |   0.280 ns |  2.59 |    0.01 |  0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 5.0 | .NET 5.0 |    10 |     57.76 ns |   0.248 ns |   0.232 ns |  2.47 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq | .NET 5.0 | .NET 5.0 |    10 |    106.01 ns |   1.804 ns |   1.599 ns |  4.54 |    0.07 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 5.0 | .NET 5.0 |    10 |     77.01 ns |   0.419 ns |   0.372 ns |  3.30 |    0.01 |       - |     - |     - |         - |
|                      |          |          |       |              |            |            |       |         |         |       |       |           |
|              ForLoop | .NET 6.0 | .NET 6.0 |    10 |     23.35 ns |   0.055 ns |   0.046 ns |  1.00 |    0.00 |       - |     - |     - |         - |
|          ForeachLoop | .NET 6.0 | .NET 6.0 |    10 |     32.93 ns |   0.106 ns |   0.094 ns |  1.41 |    0.00 |       - |     - |     - |         - |
|                 Linq | .NET 6.0 | .NET 6.0 |    10 |     85.97 ns |   1.269 ns |   1.125 ns |  3.68 |    0.05 |  0.0497 |     - |     - |     104 B |
|           LinqFaster | .NET 6.0 | .NET 6.0 |    10 |     96.65 ns |   1.970 ns |   1.538 ns |  4.14 |    0.06 |  0.3901 |     - |     - |     816 B |
|               LinqAF | .NET 6.0 | .NET 6.0 |    10 |    146.46 ns |   2.842 ns |   4.076 ns |  6.19 |    0.16 |       - |     - |     - |         - |
|           StructLinq | .NET 6.0 | .NET 6.0 |    10 |     61.57 ns |   0.284 ns |   0.265 ns |  2.64 |    0.01 |  0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 6.0 | .NET 6.0 |    10 |     58.61 ns |   0.202 ns |   0.179 ns |  2.51 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq | .NET 6.0 | .NET 6.0 |    10 |    104.08 ns |   0.927 ns |   0.822 ns |  4.46 |    0.04 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 6.0 | .NET 6.0 |    10 |     77.46 ns |   0.337 ns |   0.315 ns |  3.32 |    0.01 |       - |     - |     - |         - |
|                      |          |          |       |              |            |            |       |         |         |       |       |           |
|              **ForLoop** | **.NET 5.0** | **.NET 5.0** |  **1000** |  **4,924.33 ns** |  **11.908 ns** |  **11.139 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5.0 | .NET 5.0 |  1000 |  5,906.26 ns |  25.235 ns |  23.605 ns |  1.20 |    0.00 |       - |     - |     - |         - |
|                 Linq | .NET 5.0 | .NET 5.0 |  1000 | 12,234.00 ns |  96.246 ns |  85.320 ns |  2.48 |    0.02 |  0.0458 |     - |     - |     104 B |
|           LinqFaster | .NET 5.0 | .NET 5.0 |  1000 | 14,755.89 ns | 135.203 ns | 193.904 ns |  3.02 |    0.03 | 45.4407 |     - |     - |  96,240 B |
|               LinqAF | .NET 5.0 | .NET 5.0 |  1000 | 16,114.18 ns | 306.587 ns | 301.109 ns |  3.27 |    0.07 |       - |     - |     - |         - |
|           StructLinq | .NET 5.0 | .NET 5.0 |  1000 |  7,994.47 ns |  32.140 ns |  28.491 ns |  1.62 |    0.01 |  0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 5.0 | .NET 5.0 |  1000 |  6,352.98 ns |  65.795 ns |  61.545 ns |  1.29 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq | .NET 5.0 | .NET 5.0 |  1000 | 15,624.27 ns | 137.172 ns | 121.600 ns |  3.17 |    0.02 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 5.0 | .NET 5.0 |  1000 |  8,764.84 ns |  47.368 ns |  41.990 ns |  1.78 |    0.01 |       - |     - |     - |         - |
|                      |          |          |       |              |            |            |       |         |         |       |       |           |
|              ForLoop | .NET 6.0 | .NET 6.0 |  1000 |  4,959.44 ns |  28.028 ns |  24.846 ns |  1.00 |    0.00 |       - |     - |     - |         - |
|          ForeachLoop | .NET 6.0 | .NET 6.0 |  1000 |  6,054.13 ns |  65.231 ns |  57.826 ns |  1.22 |    0.01 |       - |     - |     - |         - |
|                 Linq | .NET 6.0 | .NET 6.0 |  1000 | 12,103.14 ns |  30.515 ns |  27.051 ns |  2.44 |    0.02 |  0.0458 |     - |     - |     104 B |
|           LinqFaster | .NET 6.0 | .NET 6.0 |  1000 | 14,428.87 ns | 203.397 ns | 190.257 ns |  2.91 |    0.04 | 45.4407 |     - |     - |  96,240 B |
|               LinqAF | .NET 6.0 | .NET 6.0 |  1000 | 16,322.99 ns | 256.116 ns | 239.571 ns |  3.29 |    0.04 |       - |     - |     - |         - |
|           StructLinq | .NET 6.0 | .NET 6.0 |  1000 |  7,527.36 ns |  69.236 ns |  61.376 ns |  1.52 |    0.02 |  0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 6.0 | .NET 6.0 |  1000 |  6,170.05 ns |  23.316 ns |  20.669 ns |  1.24 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq | .NET 6.0 | .NET 6.0 |  1000 | 15,295.59 ns |  95.780 ns |  89.593 ns |  3.09 |    0.03 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 6.0 | .NET 6.0 |  1000 |  8,796.17 ns | 100.630 ns |  89.206 ns |  1.77 |    0.02 |       - |     - |     - |         - |
