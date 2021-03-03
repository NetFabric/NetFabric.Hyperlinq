## List.ValueType.ListValueTypeSelectSum

### Source
[ListValueTypeSelectSum.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSelectSum.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta42](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta42)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1516-nightly, OS=Windows 10.0.19042.844 (20H2/October2020Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.1.21103.13
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|               Method | Count |        Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** |    **10** |    **18.97 ns** |   **0.050 ns** |   **0.044 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |    52.16 ns |   0.156 ns |   0.146 ns |  2.75 |    0.01 |      - |     - |     - |         - |
|                 Linq |    10 |   133.18 ns |   0.417 ns |   0.348 ns |  7.02 |    0.02 | 0.0458 |     - |     - |      96 B |
|           LinqFaster |    10 |    41.06 ns |   0.413 ns |   0.366 ns |  2.16 |    0.02 |      - |     - |     - |         - |
|               LinqAF |    10 |   142.26 ns |   2.810 ns |   3.007 ns |  7.48 |    0.17 |      - |     - |     - |         - |
|           StructLinq |    10 |    34.20 ns |   0.258 ns |   0.229 ns |  1.80 |    0.01 | 0.0191 |     - |     - |      40 B |
| StructLinq_IFunction |    10 |    17.81 ns |   0.044 ns |   0.039 ns |  0.94 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |    10 |    63.69 ns |   0.174 ns |   0.145 ns |  3.36 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |    10 |    49.81 ns |   0.091 ns |   0.076 ns |  2.63 |    0.01 |      - |     - |     - |         - |
|                      |       |             |            |            |       |         |        |       |       |           |
|              **ForLoop** |  **1000** | **2,300.79 ns** |   **4.978 ns** |   **4.656 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 | 4,035.55 ns |  79.195 ns |  74.079 ns |  1.75 |    0.03 |      - |     - |     - |         - |
|                 Linq |  1000 | 9,016.34 ns |  45.391 ns |  37.904 ns |  3.92 |    0.02 | 0.0458 |     - |     - |      96 B |
|           LinqFaster |  1000 | 4,643.52 ns |  11.651 ns |  10.329 ns |  2.02 |    0.01 |      - |     - |     - |         - |
|               LinqAF |  1000 | 9,461.44 ns | 188.278 ns | 409.300 ns |  4.08 |    0.21 |      - |     - |     - |         - |
|           StructLinq |  1000 | 2,108.28 ns |   6.985 ns |   6.533 ns |  0.92 |    0.00 | 0.0191 |     - |     - |      40 B |
| StructLinq_IFunction |  1000 |   733.62 ns |   2.035 ns |   1.804 ns |  0.32 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |  1000 | 4,717.04 ns |  17.055 ns |  15.119 ns |  2.05 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |  1000 | 3,617.86 ns |   8.838 ns |   7.834 ns |  1.57 |    0.00 |      - |     - |     - |         - |
