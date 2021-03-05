## Array.ValueType.ArrayValueTypeDistinct

### Source
[ArrayValueTypeDistinct.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeDistinct.cs)

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
|              **ForLoop** |          **4** |    **10** |     **1,212.6 ns** |      **4.29 ns** |      **3.58 ns** |  **1.00** |    **0.00** |   **1.0891** |       **-** |       **-** |   **2,280 B** |
|          ForeachLoop |          4 |    10 |     1,273.5 ns |      4.94 ns |      4.38 ns |  1.05 |    0.00 |   1.0891 |       - |       - |   2,280 B |
|                 Linq |          4 |    10 |     1,663.2 ns |      5.60 ns |      4.97 ns |  1.37 |    0.01 |   0.9441 |       - |       - |   1,976 B |
|               LinqAF |          4 |    10 |     3,362.2 ns |     15.14 ns |     12.64 ns |  2.77 |    0.01 |   2.1744 |       - |       - |   4,552 B |
|           StructLinq |          4 |    10 |     1,441.1 ns |      5.19 ns |      4.60 ns |  1.19 |    0.00 |   0.0267 |       - |       - |      56 B |
| StructLinq_IFunction |          4 |    10 |       575.7 ns |      1.71 ns |      1.43 ns |  0.47 |    0.00 |        - |       - |       - |         - |
|            Hyperlinq |          4 |    10 |     1,261.6 ns |      4.78 ns |      4.47 ns |  1.04 |    0.00 |        - |       - |       - |         - |
|                      |            |       |                |              |              |       |         |          |         |         |           |
|              **ForLoop** |          **4** |  **1000** |   **195,816.2 ns** |    **916.06 ns** |    **856.88 ns** |  **1.00** |    **0.00** |  **86.9141** | **43.4570** | **43.4570** | **276,496 B** |
|          ForeachLoop |          4 |  1000 |   197,025.0 ns |  1,018.92 ns |    903.25 ns |  1.01 |    0.01 |  86.9141 | 43.4570 | 43.4570 | 276,496 B |
|                 Linq |          4 |  1000 |   187,654.6 ns |    263.48 ns |    220.01 ns |  0.96 |    0.00 |  73.9746 |       - |       - | 155,048 B |
|               LinqAF |          4 |  1000 | 5,100,243.4 ns | 20,634.16 ns | 18,291.64 ns | 26.04 |    0.17 | 179.6875 |       - |       - | 383,520 B |
|           StructLinq |          4 |  1000 |   153,658.3 ns |    478.60 ns |    447.69 ns |  0.78 |    0.00 |        - |       - |       - |      56 B |
| StructLinq_IFunction |          4 |  1000 |    45,402.1 ns |    116.81 ns |    109.26 ns |  0.23 |    0.00 |        - |       - |       - |         - |
|            Hyperlinq |          4 |  1000 |   152,535.6 ns |    404.29 ns |    337.60 ns |  0.78 |    0.00 |        - |       - |       - |         - |
