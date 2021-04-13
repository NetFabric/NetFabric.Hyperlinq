## List.ValueType.ListValueTypeDistinct

### Source
[ListValueTypeDistinct.cs](../LinqBenchmarks/List/ValueType/ListValueTypeDistinct.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [](https://www.nuget.org/packages/LinqOptimizer.CSharp/)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1527-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.3.21202.5
  [Host] : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.20104), X64 RyuJIT

EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  

```
|               Method |    Job |  Runtime | Duplicates | Count |           Mean |        Error |       StdDev | Ratio | RatioSD |    Gen 0 |   Gen 1 |   Gen 2 | Allocated |
|--------------------- |------- |--------- |----------- |------ |---------------:|-------------:|-------------:|------:|--------:|---------:|--------:|--------:|----------:|
|              **ForLoop** | **.NET 5** | **.NET 5.0** |          **4** |    **10** |     **1,397.6 ns** |      **5.62 ns** |      **4.98 ns** |  **1.00** |    **0.00** |   **1.0891** |       **-** |       **-** |   **2,280 B** |
|          ForeachLoop | .NET 5 | .NET 5.0 |          4 |    10 |     1,417.4 ns |      6.70 ns |      5.93 ns |  1.01 |    0.01 |   1.0891 |       - |       - |   2,280 B |
|                 Linq | .NET 5 | .NET 5.0 |          4 |    10 |     1,829.8 ns |     26.56 ns |     23.55 ns |  1.31 |    0.02 |   0.9747 |       - |       - |   2,040 B |
|           LinqFaster | .NET 5 | .NET 5.0 |          4 |    10 |       238.2 ns |      4.77 ns |      6.52 ns |  0.17 |    0.00 |   0.0114 |       - |       - |      24 B |
|               LinqAF | .NET 5 | .NET 5.0 |          4 |    10 |     3,525.6 ns |     24.73 ns |     19.31 ns |  2.52 |    0.02 |   2.0409 |       - |       - |   4,272 B |
|           StructLinq | .NET 5 | .NET 5.0 |          4 |    10 |     1,493.3 ns |     11.51 ns |     10.21 ns |  1.07 |    0.01 |   0.0305 |       - |       - |      64 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |          4 |    10 |       610.6 ns |     10.16 ns |      9.51 ns |  0.44 |    0.01 |        - |       - |       - |         - |
|            Hyperlinq | .NET 5 | .NET 5.0 |          4 |    10 |     1,272.2 ns |      6.69 ns |      5.93 ns |  0.91 |    0.01 |        - |       - |       - |         - |
|                      |        |          |            |       |                |              |              |       |         |          |         |         |           |
|              ForLoop | .NET 6 | .NET 6.0 |          4 |    10 |     1,288.9 ns |      8.09 ns |      7.17 ns |  1.00 |    0.00 |   1.0853 |       - |       - |   2,272 B |
|          ForeachLoop | .NET 6 | .NET 6.0 |          4 |    10 |     1,419.4 ns |      9.37 ns |      8.77 ns |  1.10 |    0.01 |   1.0853 |       - |       - |   2,272 B |
|                 Linq | .NET 6 | .NET 6.0 |          4 |    10 |     1,567.9 ns |      9.93 ns |      8.29 ns |  1.22 |    0.01 |   1.0548 |       - |       - |   2,208 B |
|           LinqFaster | .NET 6 | .NET 6.0 |          4 |    10 |       229.3 ns |      3.80 ns |      3.37 ns |  0.18 |    0.00 |   0.0114 |       - |       - |      24 B |
|               LinqAF | .NET 6 | .NET 6.0 |          4 |    10 |     3,677.2 ns |     17.73 ns |     15.71 ns |  2.85 |    0.02 |   2.1896 |       - |       - |   4,584 B |
|           StructLinq | .NET 6 | .NET 6.0 |          4 |    10 |     1,472.6 ns |     11.09 ns |      9.26 ns |  1.14 |    0.01 |   0.0305 |       - |       - |      64 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |          4 |    10 |       603.3 ns |      2.51 ns |      2.23 ns |  0.47 |    0.00 |        - |       - |       - |         - |
|            Hyperlinq | .NET 6 | .NET 6.0 |          4 |    10 |     1,252.7 ns |      6.02 ns |      5.63 ns |  0.97 |    0.01 |        - |       - |       - |         - |
|                      |        |          |            |       |                |              |              |       |         |          |         |         |           |
|              **ForLoop** | **.NET 5** | **.NET 5.0** |          **4** |  **1000** |   **199,360.2 ns** |  **1,305.63 ns** |  **1,019.35 ns** |  **1.00** |    **0.00** |  **86.9141** | **43.4570** | **43.4570** | **276,496 B** |
|          ForeachLoop | .NET 5 | .NET 5.0 |          4 |  1000 |   206,822.2 ns |    853.47 ns |    756.58 ns |  1.04 |    0.01 |  86.9141 | 43.4570 | 43.4570 | 276,496 B |
|                 Linq | .NET 5 | .NET 5.0 |          4 |  1000 |   192,258.2 ns |  3,505.06 ns |  3,278.64 ns |  0.96 |    0.01 |  73.9746 |       - |       - | 155,112 B |
|           LinqFaster | .NET 5 | .NET 5.0 |          4 |  1000 |    41,164.5 ns |    218.29 ns |    170.43 ns |  0.21 |    0.00 |        - |       - |       - |      24 B |
|               LinqAF | .NET 5 | .NET 5.0 |          4 |  1000 | 1,563,590.9 ns |  5,229.72 ns |  4,891.89 ns |  7.84 |    0.04 | 183.5938 |       - |       - | 387,304 B |
|           StructLinq | .NET 5 | .NET 5.0 |          4 |  1000 |   156,456.9 ns |    686.29 ns |    641.96 ns |  0.78 |    0.01 |        - |       - |       - |      64 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |          4 |  1000 |    46,958.4 ns |    360.39 ns |    281.37 ns |  0.24 |    0.00 |        - |       - |       - |         - |
|            Hyperlinq | .NET 5 | .NET 5.0 |          4 |  1000 |   151,821.8 ns |    594.93 ns |    556.50 ns |  0.76 |    0.00 |        - |       - |       - |         - |
|                      |        |          |            |       |                |              |              |       |         |          |         |         |           |
|              ForLoop | .NET 6 | .NET 6.0 |          4 |  1000 |   199,734.6 ns |  1,221.71 ns |  1,142.79 ns |  1.00 |    0.00 |  86.9141 | 43.4570 | 43.4570 | 276,488 B |
|          ForeachLoop | .NET 6 | .NET 6.0 |          4 |  1000 |   207,253.8 ns |  1,031.97 ns |    861.74 ns |  1.04 |    0.01 |  86.9141 | 43.4570 | 43.4570 | 276,488 B |
|                 Linq | .NET 6 | .NET 6.0 |          4 |  1000 |   223,658.4 ns |  1,412.20 ns |  1,320.97 ns |  1.12 |    0.01 |  86.9141 | 43.4570 | 43.4570 | 276,424 B |
|           LinqFaster | .NET 6 | .NET 6.0 |          4 |  1000 |    39,132.9 ns |    113.99 ns |    101.05 ns |  0.20 |    0.00 |        - |       - |       - |      24 B |
|               LinqAF | .NET 6 | .NET 6.0 |          4 |  1000 | 2,844,827.3 ns | 50,167.72 ns | 41,892.32 ns | 14.24 |    0.24 | 179.6875 |       - |       - | 385,336 B |
|           StructLinq | .NET 6 | .NET 6.0 |          4 |  1000 |   153,408.3 ns |    764.52 ns |    715.13 ns |  0.77 |    0.01 |        - |       - |       - |      64 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |          4 |  1000 |    48,637.7 ns |    243.47 ns |    203.31 ns |  0.24 |    0.00 |        - |       - |       - |         - |
|            Hyperlinq | .NET 6 | .NET 6.0 |          4 |  1000 |   152,499.3 ns |    583.93 ns |    455.89 ns |  0.76 |    0.01 |        - |       - |       - |         - |
