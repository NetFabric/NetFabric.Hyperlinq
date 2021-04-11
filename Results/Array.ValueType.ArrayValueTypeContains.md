## Array.ValueType.ArrayValueTypeContains

### Source
[ArrayValueTypeContains.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeContains.cs)

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
|               Method |      Job |  Runtime | Count |        Mean |     Error |    StdDev |      Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |--------- |--------- |------ |------------:|----------:|----------:|------------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** | **.NET 5.0** | **.NET 5.0** |    **10** |    **47.62 ns** |  **0.986 ns** |  **2.596 ns** |    **46.15 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5.0 | .NET 5.0 |    10 |    46.46 ns |  0.172 ns |  0.161 ns |    46.43 ns |  1.00 |    0.03 |      - |     - |     - |         - |
|                 Linq | .NET 5.0 | .NET 5.0 |    10 |    25.89 ns |  0.129 ns |  0.108 ns |    25.86 ns |  0.56 |    0.01 |      - |     - |     - |         - |
|           LinqFaster | .NET 5.0 | .NET 5.0 |    10 |    33.42 ns |  0.168 ns |  0.140 ns |    33.43 ns |  0.73 |    0.02 |      - |     - |     - |         - |
|               LinqAF | .NET 5.0 | .NET 5.0 |    10 |    32.70 ns |  0.101 ns |  0.089 ns |    32.69 ns |  0.71 |    0.02 |      - |     - |     - |         - |
|           StructLinq | .NET 5.0 | .NET 5.0 |    10 |    54.74 ns |  0.285 ns |  0.252 ns |    54.67 ns |  1.18 |    0.03 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 5.0 | .NET 5.0 |    10 |    41.30 ns |  0.141 ns |  0.117 ns |    41.30 ns |  0.90 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq | .NET 5.0 | .NET 5.0 |    10 |    32.39 ns |  0.193 ns |  0.171 ns |    32.39 ns |  0.70 |    0.02 |      - |     - |     - |         - |
|                      |          |          |       |             |           |           |             |       |         |        |       |       |           |
|              ForLoop | .NET 6.0 | .NET 6.0 |    10 |    44.22 ns |  0.084 ns |  0.070 ns |    44.19 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 6.0 | .NET 6.0 |    10 |    43.98 ns |  0.156 ns |  0.138 ns |    43.96 ns |  0.99 |    0.00 |      - |     - |     - |         - |
|                 Linq | .NET 6.0 | .NET 6.0 |    10 |    26.62 ns |  0.104 ns |  0.098 ns |    26.60 ns |  0.60 |    0.00 |      - |     - |     - |         - |
|           LinqFaster | .NET 6.0 | .NET 6.0 |    10 |    31.63 ns |  0.100 ns |  0.094 ns |    31.62 ns |  0.72 |    0.00 |      - |     - |     - |         - |
|               LinqAF | .NET 6.0 | .NET 6.0 |    10 |    32.40 ns |  0.117 ns |  0.104 ns |    32.41 ns |  0.73 |    0.00 |      - |     - |     - |         - |
|           StructLinq | .NET 6.0 | .NET 6.0 |    10 |    56.39 ns |  0.300 ns |  0.266 ns |    56.33 ns |  1.28 |    0.01 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 6.0 | .NET 6.0 |    10 |    46.62 ns |  0.234 ns |  0.196 ns |    46.58 ns |  1.05 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq | .NET 6.0 | .NET 6.0 |    10 |    32.02 ns |  0.079 ns |  0.070 ns |    32.02 ns |  0.72 |    0.00 |      - |     - |     - |         - |
|                      |          |          |       |             |           |           |             |       |         |        |       |       |           |
|              **ForLoop** | **.NET 5.0** | **.NET 5.0** |  **1000** | **5,036.99 ns** | **10.615 ns** |  **9.410 ns** | **5,038.29 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5.0 | .NET 5.0 |  1000 | 4,771.37 ns | 14.047 ns | 13.140 ns | 4,773.27 ns |  0.95 |    0.00 |      - |     - |     - |         - |
|                 Linq | .NET 5.0 | .NET 5.0 |  1000 | 1,860.42 ns |  9.289 ns |  8.689 ns | 1,860.30 ns |  0.37 |    0.00 |      - |     - |     - |         - |
|           LinqFaster | .NET 5.0 | .NET 5.0 |  1000 | 2,400.29 ns | 10.412 ns |  9.740 ns | 2,399.47 ns |  0.48 |    0.00 |      - |     - |     - |         - |
|               LinqAF | .NET 5.0 | .NET 5.0 |  1000 | 2,375.00 ns | 16.836 ns | 15.749 ns | 2,371.42 ns |  0.47 |    0.00 |      - |     - |     - |         - |
|           StructLinq | .NET 5.0 | .NET 5.0 |  1000 | 4,230.29 ns | 14.589 ns | 12.932 ns | 4,227.78 ns |  0.84 |    0.00 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 5.0 | .NET 5.0 |  1000 | 3,710.90 ns | 10.246 ns |  9.082 ns | 3,710.28 ns |  0.74 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq | .NET 5.0 | .NET 5.0 |  1000 | 2,292.98 ns | 12.048 ns | 10.680 ns | 2,291.53 ns |  0.46 |    0.00 |      - |     - |     - |         - |
|                      |          |          |       |             |           |           |             |       |         |        |       |       |           |
|              ForLoop | .NET 6.0 | .NET 6.0 |  1000 | 4,626.54 ns |  9.301 ns |  7.767 ns | 4,628.09 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 6.0 | .NET 6.0 |  1000 | 4,786.22 ns | 17.625 ns | 15.624 ns | 4,785.26 ns |  1.03 |    0.00 |      - |     - |     - |         - |
|                 Linq | .NET 6.0 | .NET 6.0 |  1000 | 1,878.76 ns | 12.393 ns | 11.592 ns | 1,878.01 ns |  0.41 |    0.00 |      - |     - |     - |         - |
|           LinqFaster | .NET 6.0 | .NET 6.0 |  1000 | 2,193.26 ns |  8.579 ns |  7.605 ns | 2,191.92 ns |  0.47 |    0.00 |      - |     - |     - |         - |
|               LinqAF | .NET 6.0 | .NET 6.0 |  1000 | 2,114.94 ns | 20.527 ns | 17.141 ns | 2,110.90 ns |  0.46 |    0.00 |      - |     - |     - |         - |
|           StructLinq | .NET 6.0 | .NET 6.0 |  1000 | 4,220.44 ns | 12.898 ns | 12.065 ns | 4,218.66 ns |  0.91 |    0.00 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 6.0 | .NET 6.0 |  1000 | 3,979.65 ns | 26.311 ns | 21.971 ns | 3,978.40 ns |  0.86 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | .NET 6.0 | .NET 6.0 |  1000 | 1,889.25 ns | 16.933 ns | 15.011 ns | 1,886.82 ns |  0.41 |    0.00 |      - |     - |     - |         - |
