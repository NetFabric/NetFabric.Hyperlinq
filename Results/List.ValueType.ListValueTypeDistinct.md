## List.ValueType.ListValueTypeDistinct

### Source
[ListValueTypeDistinct.cs](../LinqBenchmarks/List/ValueType/ListValueTypeDistinct.cs)

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
|               Method | Duplicates | Count |           Mean |         Error |        StdDev | Ratio | RatioSD |    Gen 0 |   Gen 1 |   Gen 2 | Allocated |
|--------------------- |----------- |------ |---------------:|--------------:|--------------:|------:|--------:|---------:|--------:|--------:|----------:|
|              **ForLoop** |          **4** |    **10** |     **1,355.1 ns** |       **5.13 ns** |       **4.54 ns** |  **1.00** |    **0.00** |   **1.0891** |       **-** |       **-** |   **2,280 B** |
|          ForeachLoop |          4 |    10 |     1,537.4 ns |       7.99 ns |       7.08 ns |  1.13 |    0.01 |   1.0891 |       - |       - |   2,280 B |
|                 Linq |          4 |    10 |     1,781.3 ns |      11.30 ns |      10.57 ns |  1.32 |    0.01 |   0.9747 |       - |       - |   2,040 B |
|           LinqFaster |          4 |    10 |       286.7 ns |       4.26 ns |       3.99 ns |  0.21 |    0.00 |   0.0114 |       - |       - |      24 B |
|               LinqAF |          4 |    10 |     3,720.1 ns |      15.30 ns |      12.78 ns |  2.74 |    0.01 |   2.1744 |       - |       - |   4,552 B |
|           StructLinq |          4 |    10 |     1,580.3 ns |      16.73 ns |      14.83 ns |  1.17 |    0.01 |   0.0305 |       - |       - |      64 B |
| StructLinq_IFunction |          4 |    10 |       625.3 ns |       3.82 ns |       3.39 ns |  0.46 |    0.00 |        - |       - |       - |         - |
|            Hyperlinq |          4 |    10 |     1,296.9 ns |       5.40 ns |       4.51 ns |  0.96 |    0.00 |        - |       - |       - |         - |
|                      |            |       |                |               |               |       |         |          |         |         |           |
|              **ForLoop** |          **4** |  **1000** |   **262,425.3 ns** |   **1,032.10 ns** |     **861.85 ns** |  **1.00** |    **0.00** |  **86.9141** | **43.4570** | **43.4570** | **276,496 B** |
|          ForeachLoop |          4 |  1000 |   223,583.1 ns |   1,869.03 ns |   1,748.29 ns |  0.85 |    0.01 |  86.9141 | 43.4570 | 43.4570 | 276,496 B |
|                 Linq |          4 |  1000 |   205,258.0 ns |     731.59 ns |     648.54 ns |  0.78 |    0.00 |  73.9746 |       - |       - | 155,112 B |
|           LinqFaster |          4 |  1000 |    34,961.4 ns |     205.79 ns |     192.50 ns |  0.13 |    0.00 |        - |       - |       - |      24 B |
|               LinqAF |          4 |  1000 | 3,813,680.3 ns | 107,328.09 ns | 300,959.46 ns | 12.87 |    2.53 | 179.6875 |       - |       - | 385,336 B |
|           StructLinq |          4 |  1000 |   156,851.7 ns |     965.26 ns |     902.91 ns |  0.60 |    0.00 |        - |       - |       - |      64 B |
| StructLinq_IFunction |          4 |  1000 |    47,506.1 ns |     112.01 ns |      93.54 ns |  0.18 |    0.00 |        - |       - |       - |         - |
|            Hyperlinq |          4 |  1000 |   151,740.9 ns |     505.41 ns |     394.59 ns |  0.58 |    0.00 |        - |       - |       - |         - |
