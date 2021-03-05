## List.ValueType.ListValueTypeSelectSum

### Source
[ListValueTypeSelectSum.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSelectSum.cs)

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
|              **ForLoop** |    **10** |    **21.44 ns** |   **0.058 ns** |   **0.051 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |    51.29 ns |   0.159 ns |   0.124 ns |  2.39 |    0.01 |      - |     - |     - |         - |
|                 Linq |    10 |   130.40 ns |   0.582 ns |   0.486 ns |  6.08 |    0.02 | 0.0458 |     - |     - |      96 B |
|           LinqFaster |    10 |    41.52 ns |   0.105 ns |   0.088 ns |  1.94 |    0.01 |      - |     - |     - |         - |
|               LinqAF |    10 |   142.13 ns |   2.226 ns |   1.973 ns |  6.63 |    0.09 |      - |     - |     - |         - |
|           StructLinq |    10 |    35.75 ns |   0.117 ns |   0.104 ns |  1.67 |    0.01 | 0.0191 |     - |     - |      40 B |
| StructLinq_IFunction |    10 |    17.86 ns |   0.046 ns |   0.043 ns |  0.83 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |    10 |    67.99 ns |   0.113 ns |   0.106 ns |  3.17 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |    10 |    50.32 ns |   0.083 ns |   0.074 ns |  2.35 |    0.01 |      - |     - |     - |         - |
|                      |       |             |            |            |       |         |        |       |       |           |
|              **ForLoop** |  **1000** | **2,627.18 ns** |   **5.770 ns** |   **5.397 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 | 4,533.44 ns |  58.489 ns |  54.710 ns |  1.73 |    0.02 |      - |     - |     - |         - |
|                 Linq |  1000 | 9,579.21 ns |  18.288 ns |  14.278 ns |  3.65 |    0.01 | 0.0458 |     - |     - |      96 B |
|           LinqFaster |  1000 | 4,563.26 ns |   8.085 ns |   7.167 ns |  1.74 |    0.00 |      - |     - |     - |         - |
|               LinqAF |  1000 | 9,972.09 ns | 197.713 ns | 433.986 ns |  3.77 |    0.17 |      - |     - |     - |         - |
|           StructLinq |  1000 | 2,118.51 ns |   6.900 ns |   6.117 ns |  0.81 |    0.00 | 0.0191 |     - |     - |      40 B |
| StructLinq_IFunction |  1000 |   733.23 ns |   2.553 ns |   2.132 ns |  0.28 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |  1000 | 5,098.06 ns |   7.521 ns |   6.667 ns |  1.94 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |  1000 | 3,708.81 ns |   6.939 ns |   6.151 ns |  1.41 |    0.00 |      - |     - |     - |         - |
