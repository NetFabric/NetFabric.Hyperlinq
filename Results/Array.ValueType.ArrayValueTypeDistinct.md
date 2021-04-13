## Array.ValueType.ArrayValueTypeDistinct

### Source
[ArrayValueTypeDistinct.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeDistinct.cs)

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
|               Method |    Job |  Runtime | Duplicates | Count |           Mean |        Error |      StdDev |         Median | Ratio | RatioSD |    Gen 0 |   Gen 1 |   Gen 2 | Allocated |
|--------------------- |------- |--------- |----------- |------ |---------------:|-------------:|------------:|---------------:|------:|--------:|---------:|--------:|--------:|----------:|
|              **ForLoop** | **.NET 5** | **.NET 5.0** |          **4** |    **10** |     **1,188.1 ns** |     **14.70 ns** |    **13.75 ns** |     **1,193.1 ns** |  **1.00** |    **0.00** |   **1.0891** |       **-** |       **-** |   **2,280 B** |
|          ForeachLoop | .NET 5 | .NET 5.0 |          4 |    10 |     1,288.1 ns |      8.91 ns |     7.44 ns |     1,286.6 ns |  1.09 |    0.01 |   1.0891 |       - |       - |   2,280 B |
|                 Linq | .NET 5 | .NET 5.0 |          4 |    10 |     1,562.7 ns |      6.75 ns |     6.31 ns |     1,562.3 ns |  1.32 |    0.02 |   0.9441 |       - |       - |   1,976 B |
|               LinqAF | .NET 5 | .NET 5.0 |          4 |    10 |     3,554.9 ns |     22.15 ns |    19.63 ns |     3,553.8 ns |  2.99 |    0.04 |   2.1896 |       - |       - |   4,584 B |
|           StructLinq | .NET 5 | .NET 5.0 |          4 |    10 |     1,470.2 ns |      4.99 ns |     4.16 ns |     1,470.1 ns |  1.24 |    0.01 |   0.0267 |       - |       - |      56 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |          4 |    10 |       577.9 ns |      4.16 ns |     3.25 ns |       578.5 ns |  0.49 |    0.00 |        - |       - |       - |         - |
|            Hyperlinq | .NET 5 | .NET 5.0 |          4 |    10 |     1,247.3 ns |      6.21 ns |     5.81 ns |     1,246.4 ns |  1.05 |    0.01 |        - |       - |       - |         - |
|                      |        |          |            |       |                |              |             |                |       |         |          |         |         |           |
|              ForLoop | .NET 6 | .NET 6.0 |          4 |    10 |     1,178.9 ns |      3.97 ns |     3.52 ns |     1,178.7 ns |  1.00 |    0.00 |   1.0853 |       - |       - |   2,272 B |
|          ForeachLoop | .NET 6 | .NET 6.0 |          4 |    10 |     1,291.0 ns |      5.45 ns |     5.10 ns |     1,293.2 ns |  1.09 |    0.00 |   1.0853 |       - |       - |   2,272 B |
|                 Linq | .NET 6 | .NET 6.0 |          4 |    10 |     1,469.2 ns |      8.83 ns |     8.26 ns |     1,467.6 ns |  1.25 |    0.01 |   1.0242 |       - |       - |   2,144 B |
|               LinqAF | .NET 6 | .NET 6.0 |          4 |    10 |     3,752.3 ns |     20.44 ns |    19.12 ns |     3,756.0 ns |  3.18 |    0.02 |   2.2354 |       - |       - |   4,680 B |
|           StructLinq | .NET 6 | .NET 6.0 |          4 |    10 |     2,283.6 ns |     95.08 ns |   272.80 ns |     2,379.9 ns |  1.45 |    0.30 |   0.0267 |       - |       - |      56 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |          4 |    10 |       592.4 ns |      3.00 ns |     2.80 ns |       592.0 ns |  0.50 |    0.00 |        - |       - |       - |         - |
|            Hyperlinq | .NET 6 | .NET 6.0 |          4 |    10 |     1,362.0 ns |      4.77 ns |     4.23 ns |     1,361.6 ns |  1.16 |    0.01 |        - |       - |       - |         - |
|                      |        |          |            |       |                |              |             |                |       |         |          |         |         |           |
|              **ForLoop** | **.NET 5** | **.NET 5.0** |          **4** |  **1000** |   **192,179.0 ns** |    **701.67 ns** |   **656.34 ns** |   **192,062.4 ns** |  **1.00** |    **0.00** |  **86.9141** | **43.4570** | **43.4570** | **276,496 B** |
|          ForeachLoop | .NET 5 | .NET 5.0 |          4 |  1000 |   197,313.3 ns |    847.73 ns |   792.97 ns |   197,207.6 ns |  1.03 |    0.00 |  86.9141 | 43.4570 | 43.4570 | 276,496 B |
|                 Linq | .NET 5 | .NET 5.0 |          4 |  1000 |   189,170.4 ns |    840.39 ns |   786.10 ns |   189,103.5 ns |  0.98 |    0.00 |  73.9746 |       - |       - | 155,048 B |
|               LinqAF | .NET 5 | .NET 5.0 |          4 |  1000 | 1,527,253.5 ns |  5,791.08 ns | 5,416.98 ns | 1,526,422.9 ns |  7.95 |    0.04 | 183.5938 |       - |       - | 386,640 B |
|           StructLinq | .NET 5 | .NET 5.0 |          4 |  1000 |   155,652.5 ns |    492.31 ns |   436.42 ns |   155,663.2 ns |  0.81 |    0.00 |        - |       - |       - |      56 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |          4 |  1000 |    47,051.8 ns |    358.47 ns |   299.34 ns |    46,985.6 ns |  0.24 |    0.00 |        - |       - |       - |         - |
|            Hyperlinq | .NET 5 | .NET 5.0 |          4 |  1000 |   157,170.1 ns |    675.33 ns |   631.71 ns |   157,241.7 ns |  0.82 |    0.00 |        - |       - |       - |       1 B |
|                      |        |          |            |       |                |              |             |                |       |         |          |         |         |           |
|              ForLoop | .NET 6 | .NET 6.0 |          4 |  1000 |   194,291.0 ns |    955.29 ns |   893.58 ns |   194,311.4 ns |  1.00 |    0.00 |  86.9141 | 43.4570 | 43.4570 | 276,488 B |
|          ForeachLoop | .NET 6 | .NET 6.0 |          4 |  1000 |   195,502.7 ns |  1,431.71 ns | 1,195.54 ns |   195,434.2 ns |  1.01 |    0.01 |  86.9141 | 43.4570 | 43.4570 | 276,488 B |
|                 Linq | .NET 6 | .NET 6.0 |          4 |  1000 |   220,394.6 ns |    936.40 ns |   875.91 ns |   220,225.9 ns |  1.13 |    0.01 |  86.9141 | 43.4570 | 43.4570 | 276,360 B |
|               LinqAF | .NET 6 | .NET 6.0 |          4 |  1000 | 2,712,837.8 ns | 10,713.30 ns | 9,497.06 ns | 2,714,007.2 ns | 13.96 |    0.09 | 179.6875 |       - |       - | 384,264 B |
|           StructLinq | .NET 6 | .NET 6.0 |          4 |  1000 |   155,917.7 ns |    989.66 ns |   826.41 ns |   155,717.5 ns |  0.80 |    0.01 |        - |       - |       - |      56 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |          4 |  1000 |    49,685.4 ns |    144.19 ns |   134.88 ns |    49,688.5 ns |  0.26 |    0.00 |        - |       - |       - |         - |
|            Hyperlinq | .NET 6 | .NET 6.0 |          4 |  1000 |   157,470.5 ns |    942.02 ns |   735.47 ns |   157,300.9 ns |  0.81 |    0.01 |        - |       - |       - |         - |
