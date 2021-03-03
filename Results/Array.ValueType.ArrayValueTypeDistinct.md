## Array.ValueType.ArrayValueTypeDistinct

### Source
[ArrayValueTypeDistinct.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeDistinct.cs)

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
|               Method | Duplicates | Count |           Mean |         Error |        StdDev |         Median | Ratio | RatioSD |    Gen 0 |   Gen 1 |   Gen 2 | Allocated |
|--------------------- |----------- |------ |---------------:|--------------:|--------------:|---------------:|------:|--------:|---------:|--------:|--------:|----------:|
|              **ForLoop** |          **4** |    **10** |     **1,119.5 ns** |       **4.12 ns** |       **3.86 ns** |     **1,120.1 ns** |  **1.00** |    **0.00** |   **1.0891** |       **-** |       **-** |   **2,280 B** |
|          ForeachLoop |          4 |    10 |     1,155.8 ns |       5.21 ns |       4.35 ns |     1,156.5 ns |  1.03 |    0.00 |   1.0891 |       - |       - |   2,280 B |
|                 Linq |          4 |    10 |     1,621.0 ns |       3.99 ns |       3.33 ns |     1,621.1 ns |  1.45 |    0.01 |   0.9441 |       - |       - |   1,976 B |
|               LinqAF |          4 |    10 |     3,118.8 ns |      17.88 ns |      16.72 ns |     3,117.0 ns |  2.79 |    0.02 |   2.1706 |       - |       - |   4,544 B |
|           StructLinq |          4 |    10 |     1,445.1 ns |       8.72 ns |       7.28 ns |     1,442.9 ns |  1.29 |    0.01 |   0.0267 |       - |       - |      56 B |
| StructLinq_IFunction |          4 |    10 |       574.9 ns |       2.93 ns |       2.60 ns |       574.1 ns |  0.51 |    0.00 |        - |       - |       - |         - |
|            Hyperlinq |          4 |    10 |     1,147.7 ns |       3.16 ns |       2.95 ns |     1,146.9 ns |  1.03 |    0.00 |        - |       - |       - |         - |
|                      |            |       |                |               |               |                |       |         |          |         |         |           |
|              **ForLoop** |          **4** |  **1000** |   **184,295.0 ns** |     **795.42 ns** |     **705.12 ns** |   **184,263.3 ns** |  **1.00** |    **0.00** |  **86.9141** | **43.4570** | **43.4570** | **276,496 B** |
|          ForeachLoop |          4 |  1000 |   189,497.6 ns |     921.70 ns |     817.06 ns |   189,444.8 ns |  1.03 |    0.00 |  86.9141 | 43.4570 | 43.4570 | 276,496 B |
|                 Linq |          4 |  1000 |   188,421.7 ns |     663.68 ns |     588.34 ns |   188,659.4 ns |  1.02 |    0.01 |  73.9746 |       - |       - | 155,048 B |
|               LinqAF |          4 |  1000 | 6,800,283.1 ns | 228,566.69 ns | 648,405.66 ns | 6,982,297.7 ns | 31.27 |    6.87 | 179.6875 |       - |       - | 383,520 B |
|           StructLinq |          4 |  1000 |   152,971.1 ns |     685.01 ns |     572.01 ns |   152,763.2 ns |  0.83 |    0.00 |        - |       - |       - |      56 B |
| StructLinq_IFunction |          4 |  1000 |    44,584.2 ns |     159.20 ns |     148.92 ns |    44,546.7 ns |  0.24 |    0.00 |        - |       - |       - |         - |
|            Hyperlinq |          4 |  1000 |   149,993.9 ns |     526.52 ns |     466.75 ns |   149,903.6 ns |  0.81 |    0.00 |        - |       - |       - |         - |
