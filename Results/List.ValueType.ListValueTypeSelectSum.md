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

BenchmarkDotNet=v0.12.1.1527-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.3.21202.5
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|               Method | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** |    **10** |     **21.87 ns** |   **0.055 ns** |   **0.049 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |     53.21 ns |   0.315 ns |   0.294 ns |  2.43 |    0.01 |      - |     - |     - |         - |
|                 Linq |    10 |    140.80 ns |   0.949 ns |   0.793 ns |  6.44 |    0.03 | 0.0458 |     - |     - |      96 B |
|           LinqFaster |    10 |     43.45 ns |   0.167 ns |   0.156 ns |  1.99 |    0.01 |      - |     - |     - |         - |
|               LinqAF |    10 |    167.32 ns |   2.863 ns |   2.678 ns |  7.67 |    0.11 |      - |     - |     - |         - |
|           StructLinq |    10 |     36.21 ns |   0.227 ns |   0.190 ns |  1.66 |    0.01 | 0.0191 |     - |     - |      40 B |
| StructLinq_IFunction |    10 |     21.34 ns |   0.220 ns |   0.206 ns |  0.98 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |    10 |     70.00 ns |   0.443 ns |   0.393 ns |  3.20 |    0.02 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |    10 |     51.56 ns |   0.258 ns |   0.229 ns |  2.36 |    0.01 |      - |     - |     - |         - |
|                      |       |              |            |            |       |         |        |       |       |           |
|              **ForLoop** |  **1000** |  **2,687.42 ns** |  **11.837 ns** |  **10.493 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 |  4,765.75 ns |  87.015 ns |  81.394 ns |  1.77 |    0.03 |      - |     - |     - |         - |
|                 Linq |  1000 |  9,644.14 ns | 114.184 ns | 101.221 ns |  3.59 |    0.04 | 0.0458 |     - |     - |      96 B |
|           LinqFaster |  1000 |  4,682.22 ns |  12.978 ns |  10.837 ns |  1.74 |    0.01 |      - |     - |     - |         - |
|               LinqAF |  1000 | 11,083.06 ns | 221.350 ns | 517.399 ns |  4.19 |    0.17 |      - |     - |     - |         - |
|           StructLinq |  1000 |  2,180.04 ns |  11.078 ns |   9.820 ns |  0.81 |    0.00 | 0.0191 |     - |     - |      40 B |
| StructLinq_IFunction |  1000 |    823.84 ns |   3.892 ns |   3.451 ns |  0.31 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |  1000 |  5,316.59 ns |  19.402 ns |  18.149 ns |  1.98 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |  1000 |  3,794.08 ns |  11.702 ns |  10.946 ns |  1.41 |    0.01 |      - |     - |     - |         - |
