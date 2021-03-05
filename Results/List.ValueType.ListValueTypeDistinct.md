## List.ValueType.ListValueTypeDistinct

### Source
[ListValueTypeDistinct.cs](../LinqBenchmarks/List/ValueType/ListValueTypeDistinct.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1517-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.1.21103.13
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|               Method | Duplicates | Count |           Mean |        Error |       StdDev | Ratio | RatioSD |    Gen 0 |   Gen 1 |   Gen 2 | Allocated |
|--------------------- |----------- |------ |---------------:|-------------:|-------------:|------:|--------:|---------:|--------:|--------:|----------:|
|              **ForLoop** |          **4** |    **10** |     **1,285.3 ns** |      **4.60 ns** |      **4.30 ns** |  **1.00** |    **0.00** |   **1.0891** |       **-** |       **-** |   **2,280 B** |
|          ForeachLoop |          4 |    10 |     1,400.3 ns |      5.69 ns |      4.75 ns |  1.09 |    0.01 |   1.0891 |       - |       - |   2,280 B |
|                 Linq |          4 |    10 |     1,706.8 ns |      6.53 ns |      6.11 ns |  1.33 |    0.01 |   0.9747 |       - |       - |   2,040 B |
|           LinqFaster |          4 |    10 |       233.3 ns |      3.16 ns |      2.80 ns |  0.18 |    0.00 |   0.0114 |       - |       - |      24 B |
|               LinqAF |          4 |    10 |     3,446.6 ns |     14.52 ns |     12.88 ns |  2.68 |    0.01 |   2.0409 |       - |       - |   4,272 B |
|           StructLinq |          4 |    10 |     1,451.7 ns |      5.29 ns |      4.69 ns |  1.13 |    0.01 |   0.0305 |       - |       - |      64 B |
| StructLinq_IFunction |          4 |    10 |       603.7 ns |      1.30 ns |      1.15 ns |  0.47 |    0.00 |        - |       - |       - |         - |
|            Hyperlinq |          4 |    10 |     1,198.1 ns |      5.70 ns |      5.06 ns |  0.93 |    0.01 |        - |       - |       - |         - |
|                      |            |       |                |              |              |       |         |          |         |         |           |
|              **ForLoop** |          **4** |  **1000** |   **203,445.1 ns** |    **692.34 ns** |    **613.74 ns** |  **1.00** |    **0.00** |  **86.9141** | **43.4570** | **43.4570** | **276,496 B** |
|          ForeachLoop |          4 |  1000 |   210,993.9 ns |  1,679.68 ns |  1,488.99 ns |  1.04 |    0.01 |  86.9141 | 43.4570 | 43.4570 | 276,496 B |
|                 Linq |          4 |  1000 |   192,309.2 ns |  2,405.23 ns |  2,249.85 ns |  0.95 |    0.01 |  73.9746 |       - |       - | 155,112 B |
|           LinqFaster |          4 |  1000 |    36,084.3 ns |     80.80 ns |     75.58 ns |  0.18 |    0.00 |        - |       - |       - |      24 B |
|               LinqAF |          4 |  1000 | 2,703,188.6 ns | 11,441.97 ns | 10,143.01 ns | 13.29 |    0.06 | 179.6875 |       - |       - | 384,304 B |
|           StructLinq |          4 |  1000 |   149,797.7 ns |    550.23 ns |    487.76 ns |  0.74 |    0.00 |        - |       - |       - |      64 B |
| StructLinq_IFunction |          4 |  1000 |    46,713.4 ns |    142.80 ns |    119.24 ns |  0.23 |    0.00 |        - |       - |       - |         - |
|            Hyperlinq |          4 |  1000 |   143,331.2 ns |    468.25 ns |    391.01 ns |  0.70 |    0.00 |        - |       - |       - |         - |
