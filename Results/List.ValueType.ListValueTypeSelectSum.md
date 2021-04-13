## List.ValueType.ListValueTypeSelectSum

### Source
[ListValueTypeSelectSum.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSelectSum.cs)

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
|               Method |    Job |  Runtime | Count |         Mean |      Error |       StdDev |       Median |    Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |--------- |------ |-------------:|-----------:|-------------:|-------------:|---------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** | **.NET 5** | **.NET 5.0** |    **10** |     **19.65 ns** |   **0.097 ns** |     **0.081 ns** |     **19.66 ns** |     **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5 | .NET 5.0 |    10 |     51.84 ns |   0.579 ns |     0.483 ns |     51.79 ns |     2.64 |    0.03 |      - |     - |     - |         - |
|                 Linq | .NET 5 | .NET 5.0 |    10 |    140.76 ns |   1.268 ns |     1.058 ns |    141.05 ns |     7.16 |    0.07 | 0.0458 |     - |     - |      96 B |
|           LinqFaster | .NET 5 | .NET 5.0 |    10 |     42.09 ns |   0.194 ns |     0.181 ns |     42.02 ns |     2.14 |    0.01 |      - |     - |     - |         - |
|               LinqAF | .NET 5 | .NET 5.0 |    10 |    149.49 ns |   2.714 ns |     2.539 ns |    149.62 ns |     7.60 |    0.14 |      - |     - |     - |         - |
|        LinqOptimizer | .NET 5 | .NET 5.0 |    10 | 37,385.48 ns | 245.653 ns |   229.784 ns | 37,457.39 ns | 1,901.18 |   14.73 | 9.5825 |     - |     - |  20,140 B |
|              Streams | .NET 5 | .NET 5.0 |    10 |    225.24 ns |   1.680 ns |     1.571 ns |    225.61 ns |    11.46 |    0.09 | 0.1721 |     - |     - |     360 B |
|           StructLinq | .NET 5 | .NET 5.0 |    10 |     32.25 ns |   0.649 ns |     0.575 ns |     32.00 ns |     1.64 |    0.03 | 0.0191 |     - |     - |      40 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |    10 |     19.32 ns |   0.450 ns |     1.024 ns |     18.67 ns |     1.06 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq | .NET 5 | .NET 5.0 |    10 |     69.67 ns |   1.387 ns |     1.297 ns |     69.04 ns |     3.55 |    0.07 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 |    10 |     49.47 ns |   1.042 ns |     2.129 ns |     48.02 ns |     2.58 |    0.06 |      - |     - |     - |         - |
|                      |        |          |       |              |            |              |              |          |         |        |       |       |           |
|              ForLoop | .NET 6 | .NET 6.0 |    10 |     19.98 ns |   1.279 ns |     3.772 ns |     19.32 ns |     1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 6 | .NET 6.0 |    10 |     51.60 ns |   1.078 ns |     2.582 ns |     50.55 ns |     2.40 |    0.30 |      - |     - |     - |         - |
|                 Linq | .NET 6 | .NET 6.0 |    10 |    127.54 ns |   2.596 ns |     2.168 ns |    127.18 ns |     5.30 |    0.43 | 0.0458 |     - |     - |      96 B |
|           LinqFaster | .NET 6 | .NET 6.0 |    10 |     42.55 ns |   0.311 ns |     0.260 ns |     42.52 ns |     1.77 |    0.15 |      - |     - |     - |         - |
|               LinqAF | .NET 6 | .NET 6.0 |    10 |    139.61 ns |   2.731 ns |     3.251 ns |    140.00 ns |     5.74 |    0.60 |      - |     - |     - |         - |
|        LinqOptimizer | .NET 6 | .NET 6.0 |    10 | 36,429.59 ns | 629.162 ns |   588.519 ns | 36,262.26 ns | 1,473.42 |  170.56 | 9.4604 |     - |     - |  19,892 B |
|              Streams | .NET 6 | .NET 6.0 |    10 |    217.94 ns |   2.024 ns |     1.794 ns |    218.54 ns |     8.91 |    0.90 | 0.1721 |     - |     - |     360 B |
|           StructLinq | .NET 6 | .NET 6.0 |    10 |     33.71 ns |   0.837 ns |     2.428 ns |     32.27 ns |     1.72 |    0.25 | 0.0191 |     - |     - |      40 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |    10 |     17.83 ns |   0.163 ns |     0.136 ns |     17.80 ns |     0.74 |    0.06 |      - |     - |     - |         - |
|            Hyperlinq | .NET 6 | .NET 6.0 |    10 |     63.46 ns |   0.538 ns |     0.477 ns |     63.29 ns |     2.59 |    0.26 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 |    10 |     53.46 ns |   0.203 ns |     0.158 ns |     53.50 ns |     2.22 |    0.20 |      - |     - |     - |         - |
|                      |        |          |       |              |            |              |              |          |         |        |       |       |           |
|              **ForLoop** | **.NET 5** | **.NET 5.0** |  **1000** |  **2,333.87 ns** |  **22.277 ns** |    **19.748 ns** |  **2,326.68 ns** |     **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5 | .NET 5.0 |  1000 |  4,498.69 ns |  75.237 ns |    66.695 ns |  4,514.10 ns |     1.93 |    0.03 |      - |     - |     - |         - |
|                 Linq | .NET 5 | .NET 5.0 |  1000 |  9,122.64 ns | 175.002 ns |   201.533 ns |  9,041.11 ns |     3.93 |    0.12 | 0.0458 |     - |     - |      96 B |
|           LinqFaster | .NET 5 | .NET 5.0 |  1000 |  4,935.28 ns |  34.384 ns |    32.163 ns |  4,936.19 ns |     2.12 |    0.03 |      - |     - |     - |         - |
|               LinqAF | .NET 5 | .NET 5.0 |  1000 | 11,467.31 ns | 225.682 ns |   466.072 ns | 11,428.74 ns |     4.93 |    0.17 |      - |     - |     - |         - |
|        LinqOptimizer | .NET 5 | .NET 5.0 |  1000 | 47,492.53 ns | 905.181 ns | 1,042.408 ns | 47,528.45 ns |    20.28 |    0.54 | 9.5825 |     - |     - |  20,140 B |
|              Streams | .NET 5 | .NET 5.0 |  1000 |  5,573.69 ns | 107.546 ns |   128.026 ns |  5,533.24 ns |     2.39 |    0.05 | 0.1678 |     - |     - |     360 B |
|           StructLinq | .NET 5 | .NET 5.0 |  1000 |  2,123.02 ns |  37.507 ns |    33.249 ns |  2,118.39 ns |     0.91 |    0.01 | 0.0191 |     - |     - |      40 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |  1000 |    743.54 ns |   9.502 ns |     8.423 ns |    741.11 ns |     0.32 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq | .NET 5 | .NET 5.0 |  1000 |  4,751.42 ns |  39.875 ns |    33.298 ns |  4,748.88 ns |     2.03 |    0.02 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 |  1000 |  3,617.07 ns |  10.767 ns |    10.072 ns |  3,615.51 ns |     1.55 |    0.01 |      - |     - |     - |         - |
|                      |        |          |       |              |            |              |              |          |         |        |       |       |           |
|              ForLoop | .NET 6 | .NET 6.0 |  1000 |  2,261.40 ns |  10.353 ns |     8.083 ns |  2,261.18 ns |     1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 6 | .NET 6.0 |  1000 |  3,927.72 ns |  70.129 ns |    65.599 ns |  3,929.49 ns |     1.74 |    0.03 |      - |     - |     - |         - |
|                 Linq | .NET 6 | .NET 6.0 |  1000 |  9,425.18 ns |  86.100 ns |    71.897 ns |  9,399.95 ns |     4.17 |    0.04 | 0.0458 |     - |     - |      96 B |
|           LinqFaster | .NET 6 | .NET 6.0 |  1000 |  4,337.69 ns |  17.072 ns |    14.256 ns |  4,338.34 ns |     1.92 |    0.01 |      - |     - |     - |         - |
|               LinqAF | .NET 6 | .NET 6.0 |  1000 | 10,401.31 ns | 206.793 ns |   412.988 ns | 10,315.54 ns |     4.51 |    0.19 |      - |     - |     - |         - |
|        LinqOptimizer | .NET 6 | .NET 6.0 |  1000 | 43,759.63 ns | 560.594 ns |   468.122 ns | 43,841.67 ns |    19.32 |    0.20 | 9.4604 |     - |     - |  19,892 B |
|              Streams | .NET 6 | .NET 6.0 |  1000 |  5,425.70 ns | 103.650 ns |   115.206 ns |  5,400.84 ns |     2.41 |    0.05 | 0.1678 |     - |     - |     360 B |
|           StructLinq | .NET 6 | .NET 6.0 |  1000 |  2,099.38 ns |   9.317 ns |     8.715 ns |  2,099.96 ns |     0.93 |    0.01 | 0.0191 |     - |     - |      40 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |  1000 |    735.29 ns |   3.113 ns |     2.599 ns |    735.78 ns |     0.33 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq | .NET 6 | .NET 6.0 |  1000 |  4,660.30 ns |  17.517 ns |    15.528 ns |  4,661.48 ns |     2.06 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 |  1000 |  3,528.55 ns |  10.535 ns |     9.339 ns |  3,527.24 ns |     1.56 |    0.01 |      - |     - |     - |         - |
