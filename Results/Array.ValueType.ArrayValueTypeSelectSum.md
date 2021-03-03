## Array.ValueType.ArrayValueTypeSelectSum

### Source
[ArrayValueTypeSelectSum.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSelectSum.cs)

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
|               Method | Count |         Mean |       Error |      StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-------------:|------------:|------------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** |    **10** |     **4.729 ns** |   **0.0163 ns** |   **0.0152 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |    15.068 ns |   0.0297 ns |   0.0278 ns |  3.19 |    0.01 |      - |     - |     - |         - |
|                 Linq |    10 |    84.240 ns |   0.2226 ns |   0.1973 ns | 17.82 |    0.06 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |    10 |    33.640 ns |   0.0703 ns |   0.0623 ns |  7.12 |    0.03 |      - |     - |     - |         - |
|               LinqAF |    10 |    84.174 ns |   1.5697 ns |   1.9852 ns | 17.74 |    0.44 |      - |     - |     - |         - |
|           StructLinq |    10 |    29.193 ns |   0.0935 ns |   0.0829 ns |  6.17 |    0.03 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |    10 |     6.524 ns |   0.0229 ns |   0.0214 ns |  1.38 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |    10 |    65.983 ns |   0.1844 ns |   0.1540 ns | 13.95 |    0.04 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |    10 |    51.860 ns |   0.0796 ns |   0.0706 ns | 10.97 |    0.03 |      - |     - |     - |         - |
|                      |       |              |             |             |       |         |        |       |       |           |
|              **ForLoop** |  **1000** |   **612.356 ns** |   **1.3017 ns** |   **1.0869 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 | 2,008.840 ns |   4.2364 ns |   3.9627 ns |  3.28 |    0.01 |      - |     - |     - |         - |
|                 Linq |  1000 | 6,016.144 ns |  10.7311 ns |   9.5129 ns |  9.83 |    0.02 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |  1000 | 3,653.026 ns |   8.3955 ns |   7.4424 ns |  5.96 |    0.02 |      - |     - |     - |         - |
|               LinqAF |  1000 | 7,549.847 ns | 149.0298 ns | 290.6713 ns | 12.44 |    0.55 |      - |     - |     - |         - |
|           StructLinq |  1000 | 1,938.490 ns |   3.7969 ns |   3.3658 ns |  3.17 |    0.01 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |  1000 |   714.030 ns |   1.5912 ns |   1.4106 ns |  1.17 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |  1000 | 4,896.965 ns |  11.7703 ns |  10.4340 ns |  8.00 |    0.02 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |  1000 | 3,698.249 ns |   6.9072 ns |   5.7678 ns |  6.04 |    0.01 |      - |     - |     - |         - |
