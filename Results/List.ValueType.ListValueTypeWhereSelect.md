## List.ValueType.ListValueTypeWhereSelect

### Source
[ListValueTypeWhereSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelect.cs)

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
|               Method | Count |         Mean |      Error |     StdDev |       Median | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-------------:|-----------:|-----------:|-------------:|------:|--------:|--------:|------:|------:|----------:|
|              **ForLoop** |    **10** |     **49.11 ns** |   **0.127 ns** |   **0.113 ns** |     **49.08 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |     81.39 ns |   0.232 ns |   0.217 ns |     81.39 ns |  1.66 |    0.01 |       - |     - |     - |         - |
|                 Linq |    10 |    184.43 ns |   1.041 ns |   0.813 ns |    184.62 ns |  3.75 |    0.02 |  0.1798 |     - |     - |     376 B |
|           LinqFaster |    10 |    109.71 ns |   1.017 ns |   0.902 ns |    109.60 ns |  2.23 |    0.02 |  0.1491 |     - |     - |     312 B |
|               LinqAF |    10 |    257.47 ns |   5.147 ns |   4.814 ns |    256.34 ns |  5.24 |    0.10 |       - |     - |     - |         - |
|           StructLinq |    10 |     91.68 ns |   0.201 ns |   0.188 ns |     91.74 ns |  1.87 |    0.01 |  0.0343 |     - |     - |      72 B |
| StructLinq_IFunction |    10 |     91.10 ns |   0.124 ns |   0.110 ns |     91.11 ns |  1.86 |    0.00 |       - |     - |     - |         - |
|            Hyperlinq |    10 |    120.82 ns |   0.286 ns |   0.267 ns |    120.75 ns |  2.46 |    0.01 |       - |     - |     - |         - |
|  Hyperlinq_IFunction |    10 |    105.88 ns |   0.218 ns |   0.182 ns |    105.89 ns |  2.16 |    0.00 |       - |     - |     - |         - |
|                      |       |              |            |            |              |       |         |         |       |       |           |
|              **ForLoop** |  **1000** | **10,385.28 ns** | **206.797 ns** | **470.982 ns** | **10,134.93 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 | 12,268.50 ns |  36.049 ns |  31.956 ns | 12,269.38 ns |  1.10 |    0.04 |       - |     - |     - |         - |
|                 Linq |  1000 | 19,648.34 ns |  93.653 ns |  87.603 ns | 19,613.64 ns |  1.76 |    0.06 |  0.1526 |     - |     - |     376 B |
|           LinqFaster |  1000 | 21,602.11 ns | 232.565 ns | 217.541 ns | 21,560.13 ns |  1.94 |    0.07 | 31.2195 |     - |     - |  65,504 B |
|               LinqAF |  1000 | 27,242.40 ns | 255.312 ns | 238.819 ns | 27,184.49 ns |  2.45 |    0.08 |       - |     - |     - |         - |
|           StructLinq |  1000 | 12,319.87 ns |  45.322 ns |  40.177 ns | 12,321.71 ns |  1.11 |    0.04 |  0.0305 |     - |     - |      72 B |
| StructLinq_IFunction |  1000 | 10,491.68 ns |  44.022 ns |  34.370 ns | 10,481.40 ns |  0.94 |    0.04 |       - |     - |     - |         - |
|            Hyperlinq |  1000 | 16,467.81 ns |  52.351 ns |  46.408 ns | 16,457.95 ns |  1.48 |    0.05 |       - |     - |     - |         - |
|  Hyperlinq_IFunction |  1000 | 12,605.39 ns |  18.228 ns |  15.222 ns | 12,609.11 ns |  1.13 |    0.04 |       - |     - |     - |         - |
