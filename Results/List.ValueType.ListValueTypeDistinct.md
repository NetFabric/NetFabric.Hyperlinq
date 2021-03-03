## List.ValueType.ListValueTypeDistinct

### Source
[ListValueTypeDistinct.cs](../LinqBenchmarks/List/ValueType/ListValueTypeDistinct.cs)

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
|               Method | Duplicates | Count |           Mean |        Error |       StdDev | Ratio | RatioSD |    Gen 0 |   Gen 1 |   Gen 2 | Allocated |
|--------------------- |----------- |------ |---------------:|-------------:|-------------:|------:|--------:|---------:|--------:|--------:|----------:|
|              **ForLoop** |          **4** |    **10** |     **1,221.8 ns** |      **4.81 ns** |      **4.50 ns** |  **1.00** |    **0.00** |   **1.0891** |       **-** |       **-** |   **2,280 B** |
|          ForeachLoop |          4 |    10 |     1,352.5 ns |      5.52 ns |      4.90 ns |  1.11 |    0.01 |   1.0891 |       - |       - |   2,280 B |
|                 Linq |          4 |    10 |     1,737.9 ns |      5.74 ns |      5.09 ns |  1.42 |    0.01 |   0.9747 |       - |       - |   2,040 B |
|           LinqFaster |          4 |    10 |       222.5 ns |      4.34 ns |      4.46 ns |  0.18 |    0.00 |   0.0114 |       - |       - |      24 B |
|               LinqAF |          4 |    10 |     3,440.3 ns |     17.36 ns |     15.39 ns |  2.82 |    0.02 |   2.1553 |       - |       - |   4,512 B |
|           StructLinq |          4 |    10 |     1,501.1 ns |      7.16 ns |      6.70 ns |  1.23 |    0.01 |   0.0305 |       - |       - |      64 B |
| StructLinq_IFunction |          4 |    10 |       577.3 ns |      1.25 ns |      1.04 ns |  0.47 |    0.00 |        - |       - |       - |         - |
|            Hyperlinq |          4 |    10 |     1,153.7 ns |      5.66 ns |      5.29 ns |  0.94 |    0.01 |        - |       - |       - |         - |
|                      |            |       |                |              |              |       |         |          |         |         |           |
|              **ForLoop** |          **4** |  **1000** |   **193,518.1 ns** |    **860.61 ns** |    **762.90 ns** |  **1.00** |    **0.00** |  **86.9141** | **43.4570** | **43.4570** | **276,496 B** |
|          ForeachLoop |          4 |  1000 |   205,089.4 ns |    813.94 ns |    679.67 ns |  1.06 |    0.01 |  86.9141 | 43.4570 | 43.4570 | 276,496 B |
|                 Linq |          4 |  1000 |   195,940.1 ns |    904.28 ns |    755.11 ns |  1.01 |    0.00 |  73.9746 |       - |       - | 155,112 B |
|           LinqFaster |          4 |  1000 |    37,253.3 ns |     71.79 ns |     63.64 ns |  0.19 |    0.00 |        - |       - |       - |      24 B |
|               LinqAF |          4 |  1000 | 4,547,837.0 ns | 17,222.00 ns | 15,266.85 ns | 23.50 |    0.15 | 179.6875 |       - |       - | 384,568 B |
|           StructLinq |          4 |  1000 |   149,265.4 ns |    742.84 ns |    579.96 ns |  0.77 |    0.00 |        - |       - |       - |      64 B |
| StructLinq_IFunction |          4 |  1000 |    44,684.7 ns |     97.04 ns |     86.02 ns |  0.23 |    0.00 |        - |       - |       - |         - |
|            Hyperlinq |          4 |  1000 |   144,249.6 ns |    441.09 ns |    391.02 ns |  0.75 |    0.00 |        - |       - |       - |         - |
