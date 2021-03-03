## List.ValueType.ListValueTypeSkipTakeWhere

### Source
[ListValueTypeSkipTakeWhere.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSkipTakeWhere.cs)

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
|               Method | Skip | Count |         Mean |      Error |     StdDev |  Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |-------------:|-----------:|-----------:|-------:|--------:|--------:|------:|------:|----------:|
|              **ForLoop** | **1000** |    **10** |     **56.56 ns** |   **0.116 ns** |   **0.108 ns** |   **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | 1000 |    10 |  4,106.74 ns |  11.667 ns |  10.342 ns |  72.61 |    0.18 |  0.0458 |     - |     - |      96 B |
|                 Linq | 1000 |    10 |    251.05 ns |   0.750 ns |   0.702 ns |   4.44 |    0.02 |  0.1526 |     - |     - |     320 B |
|           LinqFaster | 1000 |    10 |    321.73 ns |   5.226 ns |   4.364 ns |   5.69 |    0.08 |  1.0710 |     - |     - |   2,240 B |
|               LinqAF | 1000 |    10 |  7,876.10 ns | 153.549 ns | 157.684 ns | 139.38 |    2.88 |       - |     - |     - |         - |
|           StructLinq | 1000 |    10 |    126.45 ns |   0.326 ns |   0.305 ns |   2.24 |    0.01 |  0.0572 |     - |     - |     120 B |
| StructLinq_IFunction | 1000 |    10 |     98.10 ns |   0.149 ns |   0.140 ns |   1.73 |    0.00 |       - |     - |     - |         - |
|            Hyperlinq | 1000 |    10 |    146.70 ns |   0.288 ns |   0.256 ns |   2.59 |    0.01 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |    10 |    117.17 ns |   0.372 ns |   0.348 ns |   2.07 |    0.01 |       - |     - |     - |         - |
|                      |      |       |              |            |            |        |         |         |       |       |           |
|              **ForLoop** | **1000** |  **1000** |  **5,483.29 ns** |  **15.143 ns** |  **14.165 ns** |   **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | 1000 |  1000 |  7,618.74 ns |  23.509 ns |  20.840 ns |   1.39 |    0.01 |  0.0458 |     - |     - |      96 B |
|                 Linq | 1000 |  1000 | 19,891.11 ns |  80.844 ns |  71.666 ns |   3.63 |    0.02 |  0.1526 |     - |     - |     320 B |
|           LinqFaster | 1000 |  1000 | 32,823.29 ns | 348.790 ns | 309.193 ns |   5.99 |    0.06 | 90.8813 |     - |     - | 193,616 B |
|               LinqAF | 1000 |  1000 | 38,795.51 ns | 728.457 ns | 681.399 ns |   7.08 |    0.12 |       - |     - |     - |         - |
|           StructLinq | 1000 |  1000 |  9,061.87 ns |  27.690 ns |  24.546 ns |   1.65 |    0.01 |  0.0458 |     - |     - |     120 B |
| StructLinq_IFunction | 1000 |  1000 |  5,049.22 ns |  13.501 ns |  10.540 ns |   0.92 |    0.00 |       - |     - |     - |         - |
|            Hyperlinq | 1000 |  1000 | 11,416.24 ns |  16.464 ns |  14.595 ns |   2.08 |    0.01 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |  1000 |  8,145.56 ns |  34.502 ns |  30.585 ns |   1.49 |    0.01 |       - |     - |     - |         - |
