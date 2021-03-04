## List.ValueType.ListValueTypeDistinct

### Source
[ListValueTypeDistinct.cs](../LinqBenchmarks/List/ValueType/ListValueTypeDistinct.cs)

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
|               Method | Duplicates | Count |           Mean |       Error |      StdDev | Ratio | RatioSD |    Gen 0 |   Gen 1 |   Gen 2 | Allocated |
|--------------------- |----------- |------ |---------------:|------------:|------------:|------:|--------:|---------:|--------:|--------:|----------:|
|              **ForLoop** |          **4** |    **10** |     **1,335.4 ns** |    **10.48 ns** |     **9.29 ns** |  **1.00** |    **0.00** |   **1.0891** |       **-** |       **-** |   **2,280 B** |
|          ForeachLoop |          4 |    10 |     1,415.4 ns |     7.45 ns |     6.61 ns |  1.06 |    0.01 |   1.0891 |       - |       - |   2,280 B |
|                 Linq |          4 |    10 |     1,756.6 ns |    10.45 ns |     8.16 ns |  1.32 |    0.01 |   0.9747 |       - |       - |   2,040 B |
|           LinqFaster |          4 |    10 |       235.7 ns |     4.48 ns |     4.19 ns |  0.18 |    0.00 |   0.0114 |       - |       - |      24 B |
|               LinqAF |          4 |    10 |     3,316.8 ns |    10.19 ns |     9.03 ns |  2.48 |    0.02 |   2.0256 |       - |       - |   4,240 B |
|           StructLinq |          4 |    10 |     1,519.1 ns |     6.17 ns |     5.47 ns |  1.14 |    0.01 |   0.0305 |       - |       - |      64 B |
| StructLinq_IFunction |          4 |    10 |       608.8 ns |     4.61 ns |     4.31 ns |  0.46 |    0.00 |        - |       - |       - |         - |
|            Hyperlinq |          4 |    10 |     1,200.1 ns |     8.04 ns |     7.52 ns |  0.90 |    0.01 |        - |       - |       - |         - |
|                      |            |       |                |             |             |       |         |          |         |         |           |
|              **ForLoop** |          **4** |  **1000** |   **253,556.9 ns** | **1,030.19 ns** |   **913.24 ns** |  **1.00** |    **0.00** |  **86.9141** | **43.4570** | **43.4570** | **276,496 B** |
|          ForeachLoop |          4 |  1000 |   211,805.5 ns | 1,199.26 ns | 1,063.12 ns |  0.84 |    0.01 |  86.9141 | 43.4570 | 43.4570 | 276,496 B |
|                 Linq |          4 |  1000 |   200,259.8 ns |   832.55 ns |   695.22 ns |  0.79 |    0.00 |  73.9746 |       - |       - | 155,112 B |
|           LinqFaster |          4 |  1000 |    34,978.9 ns |   105.84 ns |    99.01 ns |  0.14 |    0.00 |        - |       - |       - |      24 B |
|               LinqAF |          4 |  1000 | 1,441,921.0 ns | 5,976.44 ns | 5,297.95 ns |  5.69 |    0.03 | 183.5938 |       - |       - | 387,024 B |
|           StructLinq |          4 |  1000 |   166,395.1 ns |   907.94 ns |   804.86 ns |  0.66 |    0.00 |        - |       - |       - |      64 B |
| StructLinq_IFunction |          4 |  1000 |    47,524.9 ns |   250.10 ns |   233.94 ns |  0.19 |    0.00 |        - |       - |       - |         - |
|            Hyperlinq |          4 |  1000 |   148,670.2 ns |   660.65 ns |   617.98 ns |  0.59 |    0.00 |        - |       - |       - |         - |
