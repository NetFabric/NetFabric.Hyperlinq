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

Job=.NET 5.0  Runtime=.NET 5.0  

```
|               Method | Count |         Mean |      Error |       StdDev |       Median | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-------------:|-----------:|-------------:|-------------:|------:|--------:|--------:|------:|------:|----------:|
|              **ForLoop** |    **10** |     **23.84 ns** |   **0.143 ns** |     **0.134 ns** |     **23.79 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |     33.43 ns |   0.168 ns |     0.157 ns |     33.43 ns |  1.40 |    0.01 |       - |     - |     - |         - |
|                 Linq |    10 |    106.49 ns |   0.977 ns |     0.866 ns |    106.43 ns |  4.47 |    0.05 |  0.0497 |     - |     - |     104 B |
|           LinqFaster |    10 |     96.40 ns |   1.231 ns |     1.151 ns |     96.37 ns |  4.04 |    0.05 |  0.3901 |     - |     - |     816 B |
|               LinqAF |    10 |    153.41 ns |   2.898 ns |     3.338 ns |    153.96 ns |  6.44 |    0.16 |       - |     - |     - |         - |
|           StructLinq |    10 |     61.83 ns |   0.459 ns |     0.491 ns |     61.68 ns |  2.60 |    0.03 |  0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |    10 |     58.49 ns |   0.124 ns |     0.110 ns |     58.48 ns |  2.45 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq |    10 |    109.10 ns |   1.095 ns |     1.025 ns |    109.13 ns |  4.58 |    0.05 |       - |     - |     - |         - |
|  Hyperlinq_IFunction |    10 |     77.91 ns |   0.500 ns |     0.468 ns |     77.93 ns |  3.27 |    0.02 |       - |     - |     - |         - |
|                      |       |              |            |              |              |       |         |         |       |       |           |
|              **ForLoop** |  **1000** |  **5,065.23 ns** |  **25.106 ns** |    **22.256 ns** |  **5,071.69 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 |  6,073.96 ns |  31.084 ns |    27.555 ns |  6,071.92 ns |  1.20 |    0.01 |       - |     - |     - |         - |
|                 Linq |  1000 | 12,511.34 ns | 109.746 ns |    91.643 ns | 12,506.38 ns |  2.47 |    0.02 |  0.0458 |     - |     - |     104 B |
|           LinqFaster |  1000 | 17,218.92 ns | 800.545 ns | 2,335.229 ns | 15,901.85 ns |  3.57 |    0.34 | 45.4407 |     - |     - |  96,240 B |
|               LinqAF |  1000 | 17,487.60 ns | 185.260 ns |   173.292 ns | 17,526.22 ns |  3.45 |    0.03 |       - |     - |     - |         - |
|           StructLinq |  1000 |  7,944.99 ns |  41.696 ns |    36.963 ns |  7,934.23 ns |  1.57 |    0.01 |  0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |  1000 |  6,447.60 ns |  36.958 ns |    32.762 ns |  6,447.01 ns |  1.27 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq |  1000 | 16,136.12 ns |  77.724 ns |    72.703 ns | 16,133.61 ns |  3.19 |    0.02 |       - |     - |     - |         - |
|  Hyperlinq_IFunction |  1000 |  9,435.61 ns |  47.660 ns |    42.249 ns |  9,419.02 ns |  1.86 |    0.01 |       - |     - |     - |         - |
