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

BenchmarkDotNet=v0.12.1.1517-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.1.21103.13
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|               Method | Count |        Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** |    **10** |    **56.62 ns** |   **0.092 ns** |   **0.077 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |    97.70 ns |   1.768 ns |   1.653 ns |  1.73 |    0.03 |      - |     - |     - |         - |
|                 Linq |    10 |    28.95 ns |   0.067 ns |   0.059 ns |  0.51 |    0.00 |      - |     - |     - |         - |
|           LinqFaster |    10 |    28.64 ns |   0.071 ns |   0.067 ns |  0.51 |    0.00 |      - |     - |     - |         - |
|               LinqAF |    10 |    30.65 ns |   0.085 ns |   0.075 ns |  0.54 |    0.00 |      - |     - |     - |         - |
|           StructLinq |    10 |    56.43 ns |   0.285 ns |   0.238 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
| StructLinq_IFunction |    10 |    61.13 ns |   0.241 ns |   0.201 ns |  1.08 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |    10 |    29.57 ns |   0.290 ns |   0.226 ns |  0.52 |    0.00 |      - |     - |     - |         - |
|                      |       |             |            |            |       |         |        |       |       |           |
|              **ForLoop** |  **1000** | **6,666.06 ns** |  **10.800 ns** |   **9.574 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 | 7,958.63 ns | 136.605 ns | 127.781 ns |  1.19 |    0.02 |      - |     - |     - |         - |
|                 Linq |  1000 | 2,095.45 ns |   7.554 ns |   6.697 ns |  0.31 |    0.00 |      - |     - |     - |         - |
|           LinqFaster |  1000 | 1,861.38 ns |   3.627 ns |   3.393 ns |  0.28 |    0.00 |      - |     - |     - |         - |
|               LinqAF |  1000 | 2,436.50 ns |  13.543 ns |  12.668 ns |  0.37 |    0.00 |      - |     - |     - |         - |
|           StructLinq |  1000 | 4,193.24 ns |  11.243 ns |  10.517 ns |  0.63 |    0.00 | 0.0153 |     - |     - |      40 B |
| StructLinq_IFunction |  1000 | 4,012.39 ns |  13.472 ns |  11.250 ns |  0.60 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |  1000 | 2,103.67 ns |   4.295 ns |   3.807 ns |  0.32 |    0.00 |      - |     - |     - |         - |
