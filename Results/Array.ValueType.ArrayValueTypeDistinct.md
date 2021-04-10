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

BenchmarkDotNet=v0.12.1.1527-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.3.21202.5
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|               Method | Duplicates | Count |           Mean |        Error |       StdDev |         Median |            P95 | Ratio | RatioSD |    Gen 0 |   Gen 1 |   Gen 2 | Allocated |
|--------------------- |----------- |------ |---------------:|-------------:|-------------:|---------------:|---------------:|------:|--------:|---------:|--------:|--------:|----------:|
|              **ForLoop** |          **4** |    **10** |     **1,288.4 ns** |      **4.94 ns** |      **4.63 ns** |     **1,287.8 ns** |     **1,293.6 ns** |  **1.00** |    **0.00** |   **1.0891** |       **-** |       **-** |   **2,280 B** |
|          ForeachLoop |          4 |    10 |     1,513.2 ns |     10.55 ns |      9.87 ns |     1,512.8 ns |     1,527.1 ns |  1.17 |    0.01 |   1.0891 |       - |       - |   2,280 B |
|                 Linq |          4 |    10 |     1,765.9 ns |      9.35 ns |      8.29 ns |     1,763.6 ns |     1,779.1 ns |  1.37 |    0.01 |   0.9441 |       - |       - |   1,976 B |
|               LinqAF |          4 |    10 |     3,174.6 ns |     14.85 ns |     12.40 ns |     3,171.2 ns |     3,191.4 ns |  2.46 |    0.01 |   2.0065 |       - |       - |   4,200 B |
|           StructLinq |          4 |    10 |     1,558.7 ns |     18.58 ns |     17.38 ns |     1,560.2 ns |     1,583.0 ns |  1.21 |    0.01 |   0.0267 |       - |       - |      56 B |
| StructLinq_IFunction |          4 |    10 |       609.9 ns |      3.33 ns |      2.95 ns |       609.0 ns |       614.9 ns |  0.47 |    0.00 |        - |       - |       - |         - |
|            Hyperlinq |          4 |    10 |     1,277.9 ns |      8.28 ns |      7.75 ns |     1,278.0 ns |     1,286.2 ns |  0.99 |    0.01 |        - |       - |       - |         - |
|                      |            |       |                |              |              |                |                |       |         |          |         |         |           |
|              **ForLoop** |          **4** |  **1000** |   **215,361.0 ns** |  **3,850.81 ns** |  **9,076.82 ns** |   **211,989.2 ns** |   **243,149.5 ns** |  **1.00** |    **0.00** |  **86.9141** | **43.4570** | **43.4570** | **276,496 B** |
|          ForeachLoop |          4 |  1000 |   216,912.5 ns |  1,186.88 ns |  2,199.96 ns |   216,123.2 ns |   221,609.3 ns |  1.00 |    0.04 |  86.9141 | 43.4570 | 43.4570 | 276,496 B |
|                 Linq |          4 |  1000 |   206,157.1 ns |  4,118.13 ns | 10,481.96 ns |   199,618.4 ns |   223,286.5 ns |  0.96 |    0.05 |  73.9746 |       - |       - | 155,048 B |
|               LinqAF |          4 |  1000 | 2,943,767.5 ns | 15,794.90 ns | 14,774.56 ns | 2,941,498.4 ns | 2,968,493.6 ns | 13.44 |    0.73 | 179.6875 |       - |       - | 384,800 B |
|           StructLinq |          4 |  1000 |   158,247.7 ns |    765.58 ns |    716.12 ns |   158,188.5 ns |   159,235.9 ns |  0.72 |    0.04 |        - |       - |       - |      56 B |
| StructLinq_IFunction |          4 |  1000 |    50,927.5 ns |    550.80 ns |    430.03 ns |    51,028.1 ns |    51,368.5 ns |  0.24 |    0.01 |        - |       - |       - |         - |
|            Hyperlinq |          4 |  1000 |   173,762.6 ns |  3,626.41 ns | 10,692.55 ns |   168,470.9 ns |   188,045.5 ns |  0.80 |    0.06 |        - |       - |       - |         - |
