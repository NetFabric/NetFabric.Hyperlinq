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
  .NET 6.0 : .NET 6.0.0 (6.0.21.20104), X64 RyuJIT


```
|               Method |      Job |  Runtime | Duplicates | Count |           Mean |        Error |       StdDev |         Median |            P95 | Ratio | RatioSD |    Gen 0 |   Gen 1 |   Gen 2 | Allocated |
|--------------------- |--------- |--------- |----------- |------ |---------------:|-------------:|-------------:|---------------:|---------------:|------:|--------:|---------:|--------:|--------:|----------:|
|              **ForLoop** | **.NET 5.0** | **.NET 5.0** |          **4** |    **10** |     **1,350.6 ns** |     **26.87 ns** |     **69.35 ns** |     **1,305.4 ns** |     **1,451.1 ns** |  **1.00** |    **0.00** |   **1.0891** |       **-** |       **-** |   **2,280 B** |
|          ForeachLoop | .NET 5.0 | .NET 5.0 |          4 |    10 |     1,456.7 ns |     10.78 ns |      9.00 ns |     1,457.2 ns |     1,467.7 ns |  1.06 |    0.06 |   1.0891 |       - |       - |   2,280 B |
|                 Linq | .NET 5.0 | .NET 5.0 |          4 |    10 |     1,834.8 ns |     35.43 ns |     34.80 ns |     1,844.4 ns |     1,851.9 ns |  1.33 |    0.06 |   0.9747 |       - |       - |   2,040 B |
|           LinqFaster | .NET 5.0 | .NET 5.0 |          4 |    10 |       231.2 ns |      3.91 ns |      3.66 ns |       231.5 ns |       236.2 ns |  0.17 |    0.01 |   0.0114 |       - |       - |      24 B |
|               LinqAF | .NET 5.0 | .NET 5.0 |          4 |    10 |     3,693.0 ns |     31.35 ns |     29.32 ns |     3,692.5 ns |     3,740.8 ns |  2.68 |    0.14 |   2.1706 |       - |       - |   4,544 B |
|           StructLinq | .NET 5.0 | .NET 5.0 |          4 |    10 |     1,505.8 ns |      8.95 ns |      7.94 ns |     1,505.5 ns |     1,516.9 ns |  1.10 |    0.05 |   0.0305 |       - |       - |      64 B |
| StructLinq_IFunction | .NET 5.0 | .NET 5.0 |          4 |    10 |       634.3 ns |      4.04 ns |      3.37 ns |       633.4 ns |       640.3 ns |  0.46 |    0.02 |        - |       - |       - |         - |
|            Hyperlinq | .NET 5.0 | .NET 5.0 |          4 |    10 |     1,270.4 ns |      5.60 ns |      4.97 ns |     1,270.8 ns |     1,278.1 ns |  0.93 |    0.05 |        - |       - |       - |         - |
|                      |          |          |            |       |                |              |              |                |                |       |         |          |         |         |           |
|              ForLoop | .NET 6.0 | .NET 6.0 |          4 |    10 |     1,373.3 ns |     27.43 ns |     66.23 ns |     1,327.3 ns |     1,465.3 ns |  1.00 |    0.00 |   1.0853 |       - |       - |   2,272 B |
|          ForeachLoop | .NET 6.0 | .NET 6.0 |          4 |    10 |     1,456.0 ns |     10.36 ns |      9.69 ns |     1,452.0 ns |     1,471.8 ns |  1.08 |    0.05 |   1.0853 |       - |       - |   2,272 B |
|                 Linq | .NET 6.0 | .NET 6.0 |          4 |    10 |     1,723.6 ns |     34.08 ns |     72.63 ns |     1,680.6 ns |     1,832.5 ns |  1.25 |    0.09 |   1.0548 |       - |       - |   2,208 B |
|           LinqFaster | .NET 6.0 | .NET 6.0 |          4 |    10 |       243.2 ns |      4.86 ns |      5.60 ns |       243.3 ns |       250.6 ns |  0.18 |    0.01 |   0.0114 |       - |       - |      24 B |
|               LinqAF | .NET 6.0 | .NET 6.0 |          4 |    10 |     3,572.4 ns |     36.92 ns |     67.51 ns |     3,552.5 ns |     3,666.6 ns |  2.55 |    0.14 |   2.0370 |       - |       - |   4,272 B |
|           StructLinq | .NET 6.0 | .NET 6.0 |          4 |    10 |     1,573.2 ns |      6.15 ns |      5.14 ns |     1,572.7 ns |     1,580.8 ns |  1.18 |    0.04 |   0.0305 |       - |       - |      64 B |
| StructLinq_IFunction | .NET 6.0 | .NET 6.0 |          4 |    10 |       617.3 ns |      2.31 ns |      2.05 ns |       616.4 ns |       620.7 ns |  0.46 |    0.02 |        - |       - |       - |         - |
|            Hyperlinq | .NET 6.0 | .NET 6.0 |          4 |    10 |     1,420.7 ns |      5.68 ns |      5.31 ns |     1,421.2 ns |     1,429.8 ns |  1.05 |    0.05 |        - |       - |       - |         - |
|                      |          |          |            |       |                |              |              |                |                |       |         |          |         |         |           |
|              **ForLoop** | **.NET 5.0** | **.NET 5.0** |          **4** |  **1000** |   **213,360.4 ns** |  **3,105.48 ns** |  **2,904.87 ns** |   **213,743.9 ns** |   **217,379.0 ns** |  **1.00** |    **0.00** |  **86.9141** | **43.4570** | **43.4570** | **276,496 B** |
|          ForeachLoop | .NET 5.0 | .NET 5.0 |          4 |  1000 |   225,045.8 ns |  4,364.37 ns | 10,115.09 ns |   221,186.0 ns |   256,166.8 ns |  1.08 |    0.07 |  86.9141 | 43.4570 | 43.4570 | 276,496 B |
|                 Linq | .NET 5.0 | .NET 5.0 |          4 |  1000 |   218,935.2 ns |  1,896.18 ns |  1,773.69 ns |   218,529.4 ns |   222,066.1 ns |  1.03 |    0.02 |  73.9746 |       - |       - | 155,112 B |
|           LinqFaster | .NET 5.0 | .NET 5.0 |          4 |  1000 |    34,708.4 ns |     96.39 ns |     80.49 ns |    34,704.2 ns |    34,836.0 ns |  0.16 |    0.00 |        - |       - |       - |      24 B |
|               LinqAF | .NET 5.0 | .NET 5.0 |          4 |  1000 | 5,199,028.7 ns | 31,414.01 ns | 26,232.12 ns | 5,203,586.7 ns | 5,241,004.8 ns | 24.37 |    0.31 | 179.6875 |       - |       - | 382,472 B |
|           StructLinq | .NET 5.0 | .NET 5.0 |          4 |  1000 |   171,495.0 ns |  3,357.40 ns |  4,815.09 ns |   173,230.3 ns |   174,156.5 ns |  0.80 |    0.03 |        - |       - |       - |      64 B |
| StructLinq_IFunction | .NET 5.0 | .NET 5.0 |          4 |  1000 |    50,114.5 ns |    628.36 ns |    524.71 ns |    50,214.5 ns |    50,744.7 ns |  0.23 |    0.00 |        - |       - |       - |         - |
|            Hyperlinq | .NET 5.0 | .NET 5.0 |          4 |  1000 |   162,755.5 ns |  3,251.26 ns |  9,276.03 ns |   159,085.4 ns |   177,616.7 ns |  0.78 |    0.05 |        - |       - |       - |         - |
|                      |          |          |            |       |                |              |              |                |                |       |         |          |         |         |           |
|              ForLoop | .NET 6.0 | .NET 6.0 |          4 |  1000 |   211,535.5 ns |  1,059.85 ns |    885.02 ns |   211,383.9 ns |   212,994.1 ns |  1.00 |    0.00 |  86.9141 | 43.4570 | 43.4570 | 276,488 B |
|          ForeachLoop | .NET 6.0 | .NET 6.0 |          4 |  1000 |   226,780.3 ns |  1,239.47 ns |  2,001.51 ns |   226,318.3 ns |   230,621.9 ns |  1.07 |    0.01 |  86.9141 | 43.4570 | 43.4570 | 276,488 B |
|                 Linq | .NET 6.0 | .NET 6.0 |          4 |  1000 |   238,820.0 ns |  2,904.13 ns |  2,267.35 ns |   239,004.4 ns |   241,769.8 ns |  1.13 |    0.01 |  86.9141 | 43.4570 | 43.4570 | 276,424 B |
|           LinqFaster | .NET 6.0 | .NET 6.0 |          4 |  1000 |    35,320.9 ns |    110.48 ns |    103.34 ns |    35,295.5 ns |    35,484.2 ns |  0.17 |    0.00 |        - |       - |       - |      24 B |
|               LinqAF | .NET 6.0 | .NET 6.0 |          4 |  1000 | 5,198,051.0 ns | 16,973.22 ns | 14,173.40 ns | 5,200,821.9 ns | 5,218,593.0 ns | 24.57 |    0.14 | 179.6875 |       - |       - | 381,425 B |
|           StructLinq | .NET 6.0 | .NET 6.0 |          4 |  1000 |   152,246.4 ns |    912.40 ns |    712.34 ns |   152,184.1 ns |   153,407.4 ns |  0.72 |    0.00 |        - |       - |       - |      64 B |
| StructLinq_IFunction | .NET 6.0 | .NET 6.0 |          4 |  1000 |    50,978.0 ns |    567.31 ns |    849.13 ns |    50,894.8 ns |    52,101.0 ns |  0.24 |    0.00 |        - |       - |       - |         - |
|            Hyperlinq | .NET 6.0 | .NET 6.0 |          4 |  1000 |   157,946.5 ns |  2,604.80 ns |  2,436.53 ns |   159,379.9 ns |   160,895.1 ns |  0.75 |    0.01 |        - |       - |       - |         - |
