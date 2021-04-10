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

BenchmarkDotNet=v0.12.1.1527-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.3.21202.5
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|               Method | Duplicates | Count |           Mean |        Error |       StdDev |         Median | Ratio | RatioSD |    Gen 0 |   Gen 1 |   Gen 2 | Allocated |
|--------------------- |----------- |------ |---------------:|-------------:|-------------:|---------------:|------:|--------:|---------:|--------:|--------:|----------:|
|              **ForLoop** |          **4** |    **10** |     **1,434.5 ns** |     **28.62 ns** |     **70.21 ns** |     **1,384.2 ns** |  **1.00** |    **0.00** |   **1.0891** |       **-** |       **-** |   **2,280 B** |
|          ForeachLoop |          4 |    10 |     1,544.3 ns |      5.90 ns |      4.92 ns |     1,544.5 ns |  1.02 |    0.02 |   1.0891 |       - |       - |   2,280 B |
|                 Linq |          4 |    10 |     1,912.6 ns |     38.08 ns |     48.16 ns |     1,932.6 ns |  1.31 |    0.08 |   0.9747 |       - |       - |   2,040 B |
|           LinqFaster |          4 |    10 |       248.1 ns |      4.76 ns |      5.49 ns |       248.8 ns |  0.17 |    0.01 |   0.0114 |       - |       - |      24 B |
|               LinqAF |          4 |    10 |     4,037.6 ns |     80.18 ns |     75.00 ns |     4,011.9 ns |  2.67 |    0.08 |   2.1896 |       - |       - |   4,592 B |
|           StructLinq |          4 |    10 |     1,570.8 ns |      7.20 ns |      6.38 ns |     1,571.1 ns |  1.03 |    0.02 |   0.0305 |       - |       - |      64 B |
| StructLinq_IFunction |          4 |    10 |       637.0 ns |      2.43 ns |      2.03 ns |       637.2 ns |  0.42 |    0.01 |        - |       - |       - |         - |
|            Hyperlinq |          4 |    10 |     1,295.0 ns |     16.58 ns |     15.51 ns |     1,291.1 ns |  0.86 |    0.02 |        - |       - |       - |         - |
|                      |            |       |                |              |              |                |       |         |          |         |         |           |
|              **ForLoop** |          **4** |  **1000** |   **220,432.6 ns** |  **2,894.60 ns** |  **6,474.19 ns** |   **218,477.9 ns** |  **1.00** |    **0.00** |  **86.9141** | **43.4570** | **43.4570** | **276,496 B** |
|          ForeachLoop |          4 |  1000 |   272,362.1 ns |  4,680.53 ns |  4,378.17 ns |   272,415.7 ns |  1.22 |    0.06 |  86.9141 | 43.4570 | 43.4570 | 276,496 B |
|                 Linq |          4 |  1000 |   201,269.7 ns |    868.75 ns |    725.45 ns |   201,136.1 ns |  0.91 |    0.02 |  73.9746 |       - |       - | 155,112 B |
|           LinqFaster |          4 |  1000 |    35,434.6 ns |    302.95 ns |    268.55 ns |    35,423.3 ns |  0.16 |    0.01 |        - |       - |       - |      24 B |
|               LinqAF |          4 |  1000 | 1,086,009.1 ns | 18,858.24 ns | 17,640.00 ns | 1,085,516.6 ns |  4.85 |    0.28 | 185.5469 |       - |       - | 390,488 B |
|           StructLinq |          4 |  1000 |   157,248.5 ns |    932.05 ns |    871.84 ns |   157,389.1 ns |  0.70 |    0.04 |        - |       - |       - |      64 B |
| StructLinq_IFunction |          4 |  1000 |    51,537.1 ns |    669.50 ns |  1,551.66 ns |    51,262.0 ns |  0.23 |    0.01 |        - |       - |       - |         - |
|            Hyperlinq |          4 |  1000 |   165,569.3 ns |  3,306.90 ns |  9,327.17 ns |   160,945.7 ns |  0.77 |    0.05 |        - |       - |       - |         - |
