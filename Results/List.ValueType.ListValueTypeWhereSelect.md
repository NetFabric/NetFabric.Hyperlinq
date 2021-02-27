## List.ValueType.ListValueTypeWhereSelect

### Source
[ListValueTypeWhereSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelect.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta41](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta41)

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
|              **ForLoop** |    **10** |     **47.20 ns** |   **0.248 ns** |   **0.220 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |     81.53 ns |   0.886 ns |   0.786 ns |  1.73 |    0.02 |       - |     - |     - |         - |
|                 Linq |    10 |    205.59 ns |   1.802 ns |   1.505 ns |  4.36 |    0.04 |  0.1798 |     - |     - |     376 B |
|           LinqFaster |    10 |    143.29 ns |   1.540 ns |   1.365 ns |  3.04 |    0.04 |  0.1490 |     - |     - |     312 B |
|               LinqAF |    10 |    264.87 ns |   4.426 ns |   3.924 ns |  5.61 |    0.09 |       - |     - |     - |         - |
|           StructLinq |    10 |     99.59 ns |   0.864 ns |   0.766 ns |  2.11 |    0.02 |  0.0343 |     - |     - |      72 B |
| StructLinq_IFunction |    10 |     92.29 ns |   0.358 ns |   0.335 ns |  1.96 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq |    10 |    127.65 ns |   0.492 ns |   0.437 ns |  2.70 |    0.01 |       - |     - |     - |         - |
|  Hyperlinq_IFunction |    10 |    167.44 ns |   0.652 ns |   0.578 ns |  3.55 |    0.02 |       - |     - |     - |         - |
|                      |       |              |            |            |       |         |         |       |       |           |
|              **ForLoop** |  **1000** |  **9,238.97 ns** |  **36.547 ns** |  **32.398 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 | 12,014.33 ns |  80.111 ns |  74.936 ns |  1.30 |    0.01 |       - |     - |     - |         - |
|                 Linq |  1000 | 19,941.06 ns | 170.668 ns | 159.643 ns |  2.16 |    0.02 |  0.1526 |     - |     - |     376 B |
|           LinqFaster |  1000 | 24,024.21 ns | 160.587 ns | 125.376 ns |  2.60 |    0.01 | 31.2195 |     - |     - |  65,504 B |
|               LinqAF |  1000 | 27,513.32 ns | 262.675 ns | 232.854 ns |  2.98 |    0.03 |       - |     - |     - |         - |
|           StructLinq |  1000 | 12,899.37 ns |  55.901 ns |  43.644 ns |  1.40 |    0.01 |  0.0305 |     - |     - |      72 B |
| StructLinq_IFunction |  1000 | 10,259.35 ns |  33.442 ns |  27.925 ns |  1.11 |    0.00 |       - |     - |     - |         - |
|            Hyperlinq |  1000 | 17,320.82 ns |  85.509 ns |  75.801 ns |  1.87 |    0.01 |       - |     - |     - |         - |
|  Hyperlinq_IFunction |  1000 | 12,460.00 ns |  37.381 ns |  29.185 ns |  1.35 |    0.01 |       - |     - |     - |         - |
