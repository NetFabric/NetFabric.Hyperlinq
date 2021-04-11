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
  .NET 6.0 : .NET 6.0.0 (6.0.21.20104), X64 RyuJIT


```
|               Method |      Job |  Runtime | Duplicates | Count |           Mean |        Error |       StdDev |         Median | Ratio | RatioSD |    Gen 0 |   Gen 1 |   Gen 2 | Allocated |
|--------------------- |--------- |--------- |----------- |------ |---------------:|-------------:|-------------:|---------------:|------:|--------:|---------:|--------:|--------:|----------:|
|              **ForLoop** | **.NET 5.0** | **.NET 5.0** |          **4** |    **10** |     **1,263.3 ns** |     **19.64 ns** |     **15.33 ns** |     **1,258.2 ns** |  **1.00** |    **0.00** |   **1.0891** |       **-** |       **-** |   **2,280 B** |
|          ForeachLoop | .NET 5.0 | .NET 5.0 |          4 |    10 |     1,309.3 ns |     19.38 ns |     20.74 ns |     1,304.1 ns |  1.04 |    0.02 |   1.0891 |       - |       - |   2,280 B |
|                 Linq | .NET 5.0 | .NET 5.0 |          4 |    10 |     1,753.1 ns |     34.90 ns |     70.51 ns |     1,708.6 ns |  1.35 |    0.03 |   0.9441 |       - |       - |   1,976 B |
|               LinqAF | .NET 5.0 | .NET 5.0 |          4 |    10 |     3,105.5 ns |     11.20 ns |      9.93 ns |     3,103.4 ns |  2.46 |    0.03 |   2.0218 |       - |       - |   4,232 B |
|           StructLinq | .NET 5.0 | .NET 5.0 |          4 |    10 |     1,461.4 ns |      9.07 ns |      7.57 ns |     1,460.4 ns |  1.16 |    0.02 |   0.0267 |       - |       - |      56 B |
| StructLinq_IFunction | .NET 5.0 | .NET 5.0 |          4 |    10 |       599.0 ns |      3.69 ns |      3.27 ns |       598.4 ns |  0.47 |    0.01 |        - |       - |       - |         - |
|            Hyperlinq | .NET 5.0 | .NET 5.0 |          4 |    10 |     1,405.8 ns |      6.49 ns |      5.76 ns |     1,403.8 ns |  1.11 |    0.01 |        - |       - |       - |         - |
|                      |          |          |            |       |                |              |              |                |       |         |          |         |         |           |
|              ForLoop | .NET 6.0 | .NET 6.0 |          4 |    10 |     1,312.0 ns |      5.91 ns |      5.24 ns |     1,312.1 ns |  1.00 |    0.00 |   1.0853 |       - |       - |   2,272 B |
|          ForeachLoop | .NET 6.0 | .NET 6.0 |          4 |    10 |     1,431.6 ns |      6.18 ns |      5.48 ns |     1,432.2 ns |  1.09 |    0.01 |   1.0853 |       - |       - |   2,272 B |
|                 Linq | .NET 6.0 | .NET 6.0 |          4 |    10 |     1,628.2 ns |     11.89 ns |     10.54 ns |     1,627.8 ns |  1.24 |    0.01 |   1.0242 |       - |       - |   2,144 B |
|               LinqAF | .NET 6.0 | .NET 6.0 |          4 |    10 |     3,783.1 ns |     68.76 ns |     57.42 ns |     3,792.4 ns |  2.88 |    0.05 |   2.1553 |       - |       - |   4,512 B |
|           StructLinq | .NET 6.0 | .NET 6.0 |          4 |    10 |     1,503.3 ns |      8.73 ns |      7.74 ns |     1,502.5 ns |  1.15 |    0.01 |   0.0267 |       - |       - |      56 B |
| StructLinq_IFunction | .NET 6.0 | .NET 6.0 |          4 |    10 |       617.5 ns |      3.34 ns |      2.96 ns |       616.2 ns |  0.47 |    0.00 |        - |       - |       - |         - |
|            Hyperlinq | .NET 6.0 | .NET 6.0 |          4 |    10 |     1,267.5 ns |      6.47 ns |      5.74 ns |     1,266.7 ns |  0.97 |    0.01 |        - |       - |       - |         - |
|                      |          |          |            |       |                |              |              |                |       |         |          |         |         |           |
|              **ForLoop** | **.NET 5.0** | **.NET 5.0** |          **4** |  **1000** |   **238,800.6 ns** |  **2,449.58 ns** |  **2,171.49 ns** |   **238,756.3 ns** |  **1.00** |    **0.00** |  **86.9141** | **43.4570** | **43.4570** | **276,496 B** |
|          ForeachLoop | .NET 5.0 | .NET 5.0 |          4 |  1000 |   210,614.9 ns |  2,302.94 ns |  2,154.17 ns |   210,681.1 ns |  0.88 |    0.01 |  86.9141 | 43.4570 | 43.4570 | 276,496 B |
|                 Linq | .NET 5.0 | .NET 5.0 |          4 |  1000 |   189,362.0 ns |    577.72 ns |    512.13 ns |   189,408.7 ns |  0.79 |    0.01 |  73.9746 |       - |       - | 155,048 B |
|               LinqAF | .NET 5.0 | .NET 5.0 |          4 |  1000 | 5,229,850.0 ns | 31,250.34 ns | 24,398.21 ns | 5,224,815.6 ns | 21.92 |    0.16 | 179.6875 |       - |       - | 384,568 B |
|           StructLinq | .NET 5.0 | .NET 5.0 |          4 |  1000 |   173,112.7 ns |    914.37 ns |    810.56 ns |   172,893.6 ns |  0.72 |    0.01 |        - |       - |       - |      56 B |
| StructLinq_IFunction | .NET 5.0 | .NET 5.0 |          4 |  1000 |    49,693.3 ns |    513.83 ns |    455.50 ns |    49,665.6 ns |  0.21 |    0.00 |        - |       - |       - |         - |
|            Hyperlinq | .NET 5.0 | .NET 5.0 |          4 |  1000 |   159,722.2 ns |  3,026.02 ns |  2,830.54 ns |   159,914.2 ns |  0.67 |    0.01 |        - |       - |       - |         - |
|                      |          |          |            |       |                |              |              |                |       |         |          |         |         |           |
|              ForLoop | .NET 6.0 | .NET 6.0 |          4 |  1000 |   241,176.0 ns |  2,789.43 ns |  2,609.24 ns |   240,652.6 ns |  1.00 |    0.00 |  86.9141 | 43.4570 | 43.4570 | 276,488 B |
|          ForeachLoop | .NET 6.0 | .NET 6.0 |          4 |  1000 |   209,044.9 ns |  1,325.39 ns |  1,034.78 ns |   208,924.6 ns |  0.87 |    0.01 |  86.9141 | 43.4570 | 43.4570 | 276,488 B |
|                 Linq | .NET 6.0 | .NET 6.0 |          4 |  1000 |   232,444.7 ns |  1,251.32 ns |  1,044.91 ns |   232,467.0 ns |  0.97 |    0.01 |  86.9141 | 43.4570 | 43.4570 | 276,360 B |
|               LinqAF | .NET 6.0 | .NET 6.0 |          4 |  1000 | 2,850,187.6 ns | 28,311.05 ns | 23,641.01 ns | 2,857,037.5 ns | 11.85 |    0.14 | 179.6875 |       - |       - | 385,337 B |
|           StructLinq | .NET 6.0 | .NET 6.0 |          4 |  1000 |   156,482.0 ns |    701.21 ns |    585.55 ns |   156,293.1 ns |  0.65 |    0.01 |        - |       - |       - |      56 B |
| StructLinq_IFunction | .NET 6.0 | .NET 6.0 |          4 |  1000 |    50,909.8 ns |    825.20 ns |    731.51 ns |    50,928.9 ns |  0.21 |    0.00 |        - |       - |       - |         - |
|            Hyperlinq | .NET 6.0 | .NET 6.0 |          4 |  1000 |   162,153.5 ns |  2,093.47 ns |  1,958.24 ns |   162,181.1 ns |  0.67 |    0.01 |        - |       - |       - |         - |
