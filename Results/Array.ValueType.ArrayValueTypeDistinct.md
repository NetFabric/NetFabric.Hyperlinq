## Array.ValueType.ArrayValueTypeDistinct

### Source
[ArrayValueTypeDistinct.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeDistinct.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta43](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta43)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1516-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.1.21103.13
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|               Method | Duplicates | Count |           Mean |        Error |       StdDev | Ratio | RatioSD |    Gen 0 |   Gen 1 |   Gen 2 | Allocated |
|--------------------- |----------- |------ |---------------:|-------------:|-------------:|------:|--------:|---------:|--------:|--------:|----------:|
|              **ForLoop** |          **4** |    **10** |     **1,169.1 ns** |      **8.77 ns** |      **7.77 ns** |  **1.00** |    **0.00** |   **1.0891** |       **-** |       **-** |   **2,280 B** |
|          ForeachLoop |          4 |    10 |     1,227.0 ns |      6.16 ns |      5.46 ns |  1.05 |    0.01 |   1.0891 |       - |       - |   2,280 B |
|                 Linq |          4 |    10 |     1,781.5 ns |     23.53 ns |     37.99 ns |  1.53 |    0.04 |   0.9422 |       - |       - |   1,976 B |
|               LinqAF |          4 |    10 |     3,316.6 ns |     18.04 ns |     15.06 ns |  2.84 |    0.02 |   2.1553 |       - |       - |   4,512 B |
|           StructLinq |          4 |    10 |     1,548.5 ns |      6.41 ns |      5.68 ns |  1.32 |    0.01 |   0.0267 |       - |       - |      56 B |
| StructLinq_IFunction |          4 |    10 |       626.9 ns |      2.04 ns |      1.81 ns |  0.54 |    0.00 |        - |       - |       - |         - |
|            Hyperlinq |          4 |    10 |     1,232.4 ns |      6.28 ns |      5.87 ns |  1.05 |    0.01 |        - |       - |       - |         - |
|                      |            |       |                |              |              |       |         |          |         |         |           |
|              **ForLoop** |          **4** |  **1000** |   **191,692.5 ns** |  **1,063.59 ns** |    **830.38 ns** |  **1.00** |    **0.00** |  **86.9141** | **43.4570** | **43.4570** | **276,496 B** |
|          ForeachLoop |          4 |  1000 |   198,985.9 ns |  2,943.28 ns |  3,022.54 ns |  1.04 |    0.02 |  86.9141 | 43.4570 | 43.4570 | 276,496 B |
|                 Linq |          4 |  1000 |   199,294.6 ns |    722.08 ns |    640.11 ns |  1.04 |    0.01 |  73.9746 |       - |       - | 155,048 B |
|               LinqAF |          4 |  1000 | 4,687,440.1 ns | 22,194.59 ns | 19,674.93 ns | 24.46 |    0.15 | 179.6875 |       - |       - | 383,520 B |
|           StructLinq |          4 |  1000 |   156,510.1 ns |    487.64 ns |    456.14 ns |  0.82 |    0.00 |        - |       - |       - |      56 B |
| StructLinq_IFunction |          4 |  1000 |    53,656.9 ns |    253.18 ns |    224.44 ns |  0.28 |    0.00 |        - |       - |       - |         - |
|            Hyperlinq |          4 |  1000 |   154,681.9 ns |    481.57 ns |    450.46 ns |  0.81 |    0.00 |        - |       - |       - |         - |
