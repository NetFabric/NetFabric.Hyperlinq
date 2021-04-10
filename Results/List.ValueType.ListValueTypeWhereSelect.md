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

BenchmarkDotNet=v0.12.1.1527-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.3.21202.5
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|               Method | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-------------:|-----------:|-----------:|------:|--------:|--------:|------:|------:|----------:|
|              **ForLoop** |    **10** |     **50.25 ns** |   **0.204 ns** |   **0.191 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |     83.10 ns |   0.446 ns |   0.396 ns |  1.65 |    0.01 |       - |     - |     - |         - |
|                 Linq |    10 |    194.92 ns |   0.887 ns |   0.786 ns |  3.88 |    0.02 |  0.1798 |     - |     - |     376 B |
|           LinqFaster |    10 |    132.61 ns |   1.806 ns |   1.690 ns |  2.64 |    0.04 |  0.1490 |     - |     - |     312 B |
|               LinqAF |    10 |    279.87 ns |   3.240 ns |   3.031 ns |  5.57 |    0.07 |       - |     - |     - |         - |
|           StructLinq |    10 |     96.96 ns |   1.453 ns |   1.213 ns |  1.93 |    0.03 |  0.0343 |     - |     - |      72 B |
| StructLinq_IFunction |    10 |     99.66 ns |   0.987 ns |   0.923 ns |  1.98 |    0.02 |       - |     - |     - |         - |
|            Hyperlinq |    10 |    126.97 ns |   0.689 ns |   0.644 ns |  2.53 |    0.02 |       - |     - |     - |         - |
|  Hyperlinq_IFunction |    10 |    110.05 ns |   0.394 ns |   0.369 ns |  2.19 |    0.01 |       - |     - |     - |         - |
|                      |       |              |            |            |       |         |         |       |       |           |
|              **ForLoop** |  **1000** | **10,283.92 ns** |  **33.379 ns** |  **27.873 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 | 12,708.73 ns |  35.805 ns |  29.898 ns |  1.24 |    0.00 |       - |     - |     - |         - |
|                 Linq |  1000 | 20,338.53 ns | 123.058 ns | 115.108 ns |  1.98 |    0.01 |  0.1526 |     - |     - |     376 B |
|           LinqFaster |  1000 | 23,542.19 ns | 441.750 ns | 368.881 ns |  2.29 |    0.04 | 31.2195 |     - |     - |  65,504 B |
|               LinqAF |  1000 | 28,954.28 ns | 172.957 ns | 153.322 ns |  2.82 |    0.01 |       - |     - |     - |         - |
|           StructLinq |  1000 | 13,237.82 ns |  88.592 ns |  78.535 ns |  1.29 |    0.01 |  0.0305 |     - |     - |      72 B |
| StructLinq_IFunction |  1000 | 11,096.31 ns |  93.292 ns |  87.266 ns |  1.08 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq |  1000 | 17,059.29 ns | 114.747 ns | 101.720 ns |  1.66 |    0.01 |       - |     - |     - |         - |
|  Hyperlinq_IFunction |  1000 | 13,329.01 ns |  58.828 ns |  52.150 ns |  1.30 |    0.01 |       - |     - |     - |         - |
