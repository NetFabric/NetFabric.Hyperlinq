## Array.ValueType.ArrayValueTypeSkipTakeWhere

### Source
[ArrayValueTypeSkipTakeWhere.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSkipTakeWhere.cs)

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
|               Method | Skip | Count |         Mean |        Error |       StdDev |  Ratio | RatioSD |    Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |-------------:|-------------:|-------------:|-------:|--------:|---------:|------:|------:|----------:|
|              **ForLoop** | **1000** |    **10** |     **44.11 ns** |     **0.067 ns** |     **0.052 ns** |   **1.00** |    **0.00** |        **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | 1000 |    10 |  2,448.56 ns |     7.092 ns |     5.537 ns |  55.51 |    0.15 |   0.0153 |     - |     - |      32 B |
|                 Linq | 1000 |    10 |    272.09 ns |     0.971 ns |     0.861 ns |   6.17 |    0.02 |   0.1526 |     - |     - |     320 B |
|           LinqFaster | 1000 |    10 |    223.63 ns |     1.715 ns |     1.521 ns |   5.06 |    0.03 |   1.1170 |     - |     - |   2,336 B |
|               LinqAF | 1000 |    10 |  4,859.21 ns |    95.228 ns |   136.573 ns | 109.81 |    3.37 |        - |     - |     - |         - |
|           StructLinq | 1000 |    10 |    112.76 ns |     0.195 ns |     0.163 ns |   2.56 |    0.01 |   0.0459 |     - |     - |      96 B |
| StructLinq_IFunction | 1000 |    10 |     76.99 ns |     0.183 ns |     0.162 ns |   1.74 |    0.00 |        - |     - |     - |         - |
|            Hyperlinq | 1000 |    10 |    142.63 ns |     0.310 ns |     0.275 ns |   3.23 |    0.01 |        - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |    10 |    113.94 ns |     0.176 ns |     0.156 ns |   2.58 |    0.01 |        - |     - |     - |         - |
|                      |      |       |              |              |              |        |         |          |       |       |           |
|              **ForLoop** | **1000** |  **1000** |  **4,382.53 ns** |    **14.170 ns** |    **13.255 ns** |   **1.00** |    **0.00** |        **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | 1000 |  1000 |  5,598.80 ns |    30.647 ns |    25.592 ns |   1.28 |    0.01 |   0.0153 |     - |     - |      32 B |
|                 Linq | 1000 |  1000 | 20,052.37 ns |    47.244 ns |    44.192 ns |   4.58 |    0.02 |   0.1526 |     - |     - |     320 B |
|           LinqFaster | 1000 |  1000 | 21,397.50 ns |    76.476 ns |    59.707 ns |   4.88 |    0.02 | 105.2551 |     - |     - | 223,520 B |
|               LinqAF | 1000 |  1000 | 32,570.64 ns | 1,049.966 ns | 3,095.850 ns |   7.33 |    0.40 |        - |     - |     - |         - |
|           StructLinq | 1000 |  1000 |  7,449.37 ns |    11.141 ns |     9.304 ns |   1.70 |    0.01 |   0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | 1000 |  1000 |  5,074.97 ns |    10.527 ns |     9.847 ns |   1.16 |    0.00 |        - |     - |     - |         - |
|            Hyperlinq | 1000 |  1000 | 11,992.95 ns |    23.669 ns |    18.479 ns |   2.74 |    0.01 |        - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |  1000 |  7,735.13 ns |    34.518 ns |    28.824 ns |   1.77 |    0.01 |        - |     - |     - |         - |
