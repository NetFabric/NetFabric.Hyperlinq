## Array.ValueType.ArrayValueTypeWhereSelect

### Source
[ArrayValueTypeWhereSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelect.cs)

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
|               Method | Count |         Mean |      Error |     StdDev |       Median | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-------------:|-----------:|-----------:|-------------:|------:|--------:|--------:|------:|------:|----------:|
|              **ForLoop** |    **10** |     **41.98 ns** |   **0.827 ns** |   **1.949 ns** |     **40.84 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |     52.05 ns |   0.349 ns |   0.326 ns |     52.12 ns |  1.16 |    0.04 |       - |     - |     - |         - |
|                 Linq |    10 |    143.69 ns |   0.842 ns |   0.703 ns |    143.60 ns |  3.19 |    0.13 |  0.1032 |     - |     - |     216 B |
|           LinqFaster |    10 |    123.55 ns |   2.832 ns |   8.260 ns |    119.50 ns |  3.02 |    0.26 |  0.3901 |     - |     - |     816 B |
|               LinqAF |    10 |  2,241.11 ns | 291.132 ns | 811.559 ns |  1,800.00 ns | 54.45 |   19.93 |       - |     - |     - |         - |
|           StructLinq |    10 |     95.60 ns |   0.559 ns |   0.495 ns |     95.58 ns |  2.13 |    0.09 |  0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |    10 |     87.90 ns |   0.443 ns |   0.393 ns |     88.06 ns |  1.96 |    0.09 |       - |     - |     - |         - |
|            Hyperlinq |    10 |    129.41 ns |   0.831 ns |   0.777 ns |    129.52 ns |  2.89 |    0.12 |       - |     - |     - |         - |
|  Hyperlinq_IFunction |    10 |    108.87 ns |   0.398 ns |   0.372 ns |    108.83 ns |  2.43 |    0.11 |       - |     - |     - |         - |
|                      |       |              |            |            |              |       |         |         |       |       |           |
|              **ForLoop** |  **1000** |  **8,915.20 ns** |  **71.211 ns** |  **59.464 ns** |  **8,910.92 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 | 10,224.73 ns |  37.789 ns |  33.499 ns | 10,228.57 ns |  1.15 |    0.01 |       - |     - |     - |         - |
|                 Linq |  1000 | 16,368.96 ns |  78.184 ns |  73.133 ns | 16,373.14 ns |  1.84 |    0.02 |  0.0916 |     - |     - |     216 B |
|           LinqFaster |  1000 | 18,464.88 ns | 214.576 ns | 200.714 ns | 18,432.21 ns |  2.07 |    0.03 | 45.4407 |     - |     - |  96,240 B |
|               LinqAF |  1000 | 23,869.09 ns | 202.495 ns | 189.414 ns | 23,847.36 ns |  2.67 |    0.03 |       - |     - |     - |         - |
|           StructLinq |  1000 | 13,118.25 ns |  43.889 ns |  38.906 ns | 13,113.66 ns |  1.47 |    0.01 |  0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |  1000 | 10,736.10 ns |  38.820 ns |  36.313 ns | 10,743.20 ns |  1.20 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq |  1000 | 17,508.60 ns | 103.915 ns |  97.202 ns | 17,505.28 ns |  1.97 |    0.01 |       - |     - |     - |         - |
|  Hyperlinq_IFunction |  1000 | 13,792.42 ns |  53.688 ns |  44.832 ns | 13,778.78 ns |  1.55 |    0.01 |       - |     - |     - |         - |
