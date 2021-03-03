## List.ValueType.ListValueTypeWhere

### Source
[ListValueTypeWhere.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhere.cs)

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
|               Method | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-------------:|-----------:|-----------:|------:|--------:|--------:|------:|------:|----------:|
|              **ForLoop** |    **10** |     **32.64 ns** |   **0.085 ns** |   **0.080 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |     61.42 ns |   0.453 ns |   0.424 ns |  1.88 |    0.01 |       - |     - |     - |         - |
|                 Linq |    10 |    137.04 ns |   1.223 ns |   1.084 ns |  4.20 |    0.04 |  0.0880 |     - |     - |     184 B |
|           LinqFaster |    10 |     76.68 ns |   0.327 ns |   0.273 ns |  2.35 |    0.01 |  0.1491 |     - |     - |     312 B |
|               LinqAF |    10 |    223.09 ns |   3.585 ns |   3.178 ns |  6.84 |    0.10 |       - |     - |     - |         - |
|           StructLinq |    10 |     56.63 ns |   0.196 ns |   0.174 ns |  1.74 |    0.01 |  0.0191 |     - |     - |      40 B |
| StructLinq_IFunction |    10 |     56.52 ns |   0.178 ns |   0.148 ns |  1.73 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq |    10 |    104.48 ns |   0.200 ns |   0.178 ns |  3.20 |    0.01 |       - |     - |     - |         - |
|  Hyperlinq_IFunction |    10 |     73.16 ns |   0.148 ns |   0.139 ns |  2.24 |    0.01 |       - |     - |     - |         - |
|                      |       |              |            |            |       |         |         |       |       |           |
|              **ForLoop** |  **1000** |  **5,757.64 ns** |  **19.542 ns** |  **17.324 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 |  9,315.17 ns |  78.445 ns |  69.539 ns |  1.62 |    0.01 |       - |     - |     - |         - |
|                 Linq |  1000 | 15,631.62 ns | 133.062 ns | 124.466 ns |  2.71 |    0.02 |  0.0610 |     - |     - |     184 B |
|           LinqFaster |  1000 | 14,300.86 ns |  42.451 ns |  37.632 ns |  2.48 |    0.01 | 31.2347 |     - |     - |  65,504 B |
|               LinqAF |  1000 | 19,821.95 ns | 282.976 ns | 264.696 ns |  3.44 |    0.05 |       - |     - |     - |         - |
|           StructLinq |  1000 |  7,971.69 ns |  30.276 ns |  28.320 ns |  1.39 |    0.00 |  0.0153 |     - |     - |      40 B |
| StructLinq_IFunction |  1000 |  5,031.76 ns |  12.400 ns |  10.992 ns |  0.87 |    0.00 |       - |     - |     - |         - |
|            Hyperlinq |  1000 | 12,431.98 ns |  44.809 ns |  41.915 ns |  2.16 |    0.01 |       - |     - |     - |         - |
|  Hyperlinq_IFunction |  1000 |  8,392.08 ns |  21.189 ns |  18.784 ns |  1.46 |    0.01 |       - |     - |     - |         - |
