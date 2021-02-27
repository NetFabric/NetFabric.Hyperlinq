## Array.ValueType.ArrayValueTypeDistinct

### Source
[ArrayValueTypeDistinct.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeDistinct.cs)

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
|               Method | Duplicates | Count |           Mean |        Error |       StdDev | Ratio | RatioSD |    Gen 0 |   Gen 1 |   Gen 2 | Allocated |
|--------------------- |----------- |------ |---------------:|-------------:|-------------:|------:|--------:|---------:|--------:|--------:|----------:|
|              **ForLoop** |          **4** |    **10** |     **1,268.7 ns** |      **5.14 ns** |      **4.29 ns** |  **1.00** |    **0.00** |   **1.0891** |       **-** |       **-** |   **2,280 B** |
|          ForeachLoop |          4 |    10 |     1,328.9 ns |      7.50 ns |      6.27 ns |  1.05 |    0.01 |   1.0891 |       - |       - |   2,280 B |
|                 Linq |          4 |    10 |     1,681.3 ns |     11.73 ns |     10.40 ns |  1.33 |    0.01 |   0.9441 |       - |       - |   1,976 B |
|               LinqAF |          4 |    10 |     3,286.7 ns |     21.12 ns |     18.72 ns |  2.59 |    0.02 |   2.0370 |       - |       - |   4,264 B |
|           StructLinq |          4 |    10 |     1,426.9 ns |      5.13 ns |      4.01 ns |  1.12 |    0.00 |   0.0267 |       - |       - |      56 B |
| StructLinq_IFunction |          4 |    10 |       600.3 ns |      2.17 ns |      1.92 ns |  0.47 |    0.00 |        - |       - |       - |         - |
|            Hyperlinq |          4 |    10 |     1,290.3 ns |      4.43 ns |      3.93 ns |  1.02 |    0.01 |        - |       - |       - |         - |
|                      |            |       |                |              |              |       |         |          |         |         |           |
|              **ForLoop** |          **4** |  **1000** |   **201,737.9 ns** |  **1,590.95 ns** |  **1,410.33 ns** |  **1.00** |    **0.00** |  **86.9141** | **43.4570** | **43.4570** | **276,496 B** |
|          ForeachLoop |          4 |  1000 |   206,281.9 ns |  1,974.43 ns |  1,846.88 ns |  1.02 |    0.01 |  86.9141 | 43.4570 | 43.4570 | 276,496 B |
|                 Linq |          4 |  1000 |   203,197.1 ns |    845.91 ns |    706.37 ns |  1.01 |    0.01 |  73.9746 |       - |       - | 155,048 B |
|               LinqAF |          4 |  1000 | 4,732,844.5 ns | 49,307.04 ns | 46,121.83 ns | 23.48 |    0.26 | 179.6875 |       - |       - | 385,616 B |
|           StructLinq |          4 |  1000 |   157,200.8 ns |    734.92 ns |    651.49 ns |  0.78 |    0.01 |        - |       - |       - |      56 B |
| StructLinq_IFunction |          4 |  1000 |    47,062.1 ns |    320.86 ns |    267.93 ns |  0.23 |    0.00 |        - |       - |       - |         - |
|            Hyperlinq |          4 |  1000 |   154,837.7 ns |    575.98 ns |    510.59 ns |  0.77 |    0.01 |        - |       - |       - |         - |
