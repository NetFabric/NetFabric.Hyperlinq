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

Job=.NET 5.0  Runtime=.NET 5.0  

```
|               Method | Count |        Mean |      Error |     StdDev |      Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |------------:|-----------:|-----------:|------------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** |    **10** |    **60.24 ns** |   **1.082 ns** |   **2.508 ns** |    **59.33 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |   109.44 ns |   2.093 ns |   1.958 ns |   109.24 ns |  1.73 |    0.10 |      - |     - |     - |         - |
|                 Linq |    10 |    32.07 ns |   0.138 ns |   0.115 ns |    32.06 ns |  0.50 |    0.03 |      - |     - |     - |         - |
|           LinqFaster |    10 |    29.13 ns |   0.111 ns |   0.098 ns |    29.12 ns |  0.46 |    0.03 |      - |     - |     - |         - |
|               LinqAF |    10 |    34.02 ns |   0.155 ns |   0.145 ns |    34.03 ns |  0.54 |    0.03 |      - |     - |     - |         - |
|           StructLinq |    10 |    59.59 ns |   1.225 ns |   1.944 ns |    58.71 ns |  0.98 |    0.04 | 0.0191 |     - |     - |      40 B |
| StructLinq_IFunction |    10 |    64.70 ns |   0.565 ns |   0.529 ns |    64.52 ns |  1.02 |    0.06 |      - |     - |     - |         - |
|            Hyperlinq |    10 |    31.10 ns |   0.338 ns |   0.300 ns |    31.17 ns |  0.49 |    0.03 |      - |     - |     - |         - |
|                      |       |             |            |            |             |       |         |        |       |       |           |
|              **ForLoop** |  **1000** | **6,862.45 ns** |  **21.284 ns** |  **19.909 ns** | **6,859.71 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 | 8,426.09 ns | 167.693 ns | 240.500 ns | 8,474.17 ns |  1.22 |    0.04 |      - |     - |     - |         - |
|                 Linq |  1000 | 2,164.95 ns |  21.270 ns |  18.855 ns | 2,158.99 ns |  0.32 |    0.00 |      - |     - |     - |         - |
|           LinqFaster |  1000 | 2,373.01 ns |  10.488 ns |   9.297 ns | 2,373.31 ns |  0.35 |    0.00 |      - |     - |     - |         - |
|               LinqAF |  1000 | 2,455.39 ns |  11.501 ns |  10.195 ns | 2,456.40 ns |  0.36 |    0.00 |      - |     - |     - |         - |
|           StructLinq |  1000 | 4,331.55 ns |  15.386 ns |  12.848 ns | 4,334.29 ns |  0.63 |    0.00 | 0.0153 |     - |     - |      40 B |
| StructLinq_IFunction |  1000 | 4,065.57 ns |  25.095 ns |  23.474 ns | 4,063.75 ns |  0.59 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |  1000 | 1,921.29 ns |  14.400 ns |  12.024 ns | 1,919.16 ns |  0.28 |    0.00 |      - |     - |     - |         - |
