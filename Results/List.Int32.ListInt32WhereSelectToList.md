## List.Int32.ListInt32WhereSelectToList

### Source
[ListInt32WhereSelectToList.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelectToList.cs)

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
|               Method |    Job |  Runtime | Count |         Mean |      Error |     StdDev |       Median |    Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |--------- |------ |-------------:|-----------:|-----------:|-------------:|---------:|--------:|--------:|------:|------:|----------:|
|              **ForLoop** | **.NET 5** | **.NET 5.0** |    **10** |     **29.92 ns** |   **0.249 ns** |   **0.233 ns** |     **29.90 ns** |     **1.00** |    **0.00** |  **0.0343** |     **-** |     **-** |      **72 B** |
|          ForeachLoop | .NET 5 | .NET 5.0 |    10 |     43.22 ns |   0.162 ns |   0.144 ns |     43.25 ns |     1.44 |    0.01 |  0.0343 |     - |     - |      72 B |
|                 Linq | .NET 5 | .NET 5.0 |    10 |    106.84 ns |   0.625 ns |   0.522 ns |    106.74 ns |     3.57 |    0.03 |  0.1070 |     - |     - |     224 B |
|           LinqFaster | .NET 5 | .NET 5.0 |    10 |     64.42 ns |   0.410 ns |   0.363 ns |     64.40 ns |     2.15 |    0.02 |  0.0650 |     - |     - |     136 B |
|               LinqAF | .NET 5 | .NET 5.0 |    10 |    150.23 ns |   0.781 ns |   0.692 ns |    150.26 ns |     5.02 |    0.05 |  0.0343 |     - |     - |      72 B |
|        LinqOptimizer | .NET 5 | .NET 5.0 |    10 | 54,472.64 ns | 512.952 ns | 428.338 ns | 54,551.04 ns | 1,818.41 |   21.34 | 15.2588 |     - |     - |  31,990 B |
|              Streams | .NET 5 | .NET 5.0 |    10 |    313.53 ns |   1.475 ns |   1.231 ns |    312.94 ns |    10.47 |    0.08 |  0.2937 |     - |     - |     616 B |
|           StructLinq | .NET 5 | .NET 5.0 |    10 |    136.15 ns |   0.755 ns |   0.670 ns |    136.16 ns |     4.55 |    0.05 |  0.0763 |     - |     - |     160 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |    10 |    100.06 ns |   0.983 ns |   0.871 ns |    100.16 ns |     3.34 |    0.04 |  0.0305 |     - |     - |      64 B |
|            Hyperlinq | .NET 5 | .NET 5.0 |    10 |    106.89 ns |   0.561 ns |   0.525 ns |    106.82 ns |     3.57 |    0.03 |  0.0305 |     - |     - |      64 B |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 |    10 |     89.43 ns |   1.090 ns |   0.910 ns |     89.48 ns |     2.99 |    0.04 |  0.0305 |     - |     - |      64 B |
|                      |        |          |       |              |            |            |              |          |         |         |       |       |           |
|              ForLoop | .NET 6 | .NET 6.0 |    10 |     28.13 ns |   0.181 ns |   0.160 ns |     28.11 ns |     1.00 |    0.00 |  0.0344 |     - |     - |      72 B |
|          ForeachLoop | .NET 6 | .NET 6.0 |    10 |     29.74 ns |   0.206 ns |   0.192 ns |     29.74 ns |     1.06 |    0.01 |  0.0344 |     - |     - |      72 B |
|                 Linq | .NET 6 | .NET 6.0 |    10 |     92.51 ns |   0.532 ns |   0.498 ns |     92.39 ns |     3.29 |    0.02 |  0.1070 |     - |     - |     224 B |
|           LinqFaster | .NET 6 | .NET 6.0 |    10 |     61.21 ns |   0.422 ns |   0.395 ns |     61.06 ns |     2.17 |    0.01 |  0.0650 |     - |     - |     136 B |
|               LinqAF | .NET 6 | .NET 6.0 |    10 |    151.23 ns |   1.089 ns |   0.910 ns |    151.01 ns |     5.37 |    0.04 |  0.0341 |     - |     - |      72 B |
|        LinqOptimizer | .NET 6 | .NET 6.0 |    10 | 50,523.82 ns | 540.277 ns | 505.376 ns | 50,595.86 ns | 1,795.35 |   16.12 | 15.0757 |     - |     - |  31,540 B |
|              Streams | .NET 6 | .NET 6.0 |    10 |    286.19 ns |   1.065 ns |   0.996 ns |    286.14 ns |    10.17 |    0.08 |  0.2942 |     - |     - |     616 B |
|           StructLinq | .NET 6 | .NET 6.0 |    10 |    154.18 ns |   0.826 ns |   0.732 ns |    153.91 ns |     5.48 |    0.04 |  0.0763 |     - |     - |     160 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |    10 |     96.46 ns |   0.420 ns |   0.373 ns |     96.49 ns |     3.43 |    0.03 |  0.0305 |     - |     - |      64 B |
|            Hyperlinq | .NET 6 | .NET 6.0 |    10 |    108.89 ns |   0.521 ns |   0.461 ns |    108.85 ns |     3.87 |    0.02 |  0.0305 |     - |     - |      64 B |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 |    10 |     92.36 ns |   0.333 ns |   0.260 ns |     92.42 ns |     3.28 |    0.03 |  0.0305 |     - |     - |      64 B |
|                      |        |          |       |              |            |            |              |          |         |         |       |       |           |
|              **ForLoop** | **.NET 5** | **.NET 5.0** |  **1000** |  **3,127.99 ns** |  **34.912 ns** |  **27.257 ns** |  **3,131.32 ns** |     **1.00** |    **0.00** |  **2.0561** |     **-** |     **-** |   **4,304 B** |
|          ForeachLoop | .NET 5 | .NET 5.0 |  1000 |  4,661.29 ns |  33.362 ns |  29.575 ns |  4,663.56 ns |     1.49 |    0.02 |  2.0523 |     - |     - |   4,304 B |
|                 Linq | .NET 5 | .NET 5.0 |  1000 |  5,433.36 ns |  62.761 ns |  52.408 ns |  5,420.95 ns |     1.74 |    0.03 |  2.1286 |     - |     - |   4,456 B |
|           LinqFaster | .NET 5 | .NET 5.0 |  1000 |  5,263.35 ns |  21.035 ns |  19.676 ns |  5,265.39 ns |     1.68 |    0.02 |  3.0441 |     - |     - |   6,376 B |
|               LinqAF | .NET 5 | .NET 5.0 |  1000 | 12,076.43 ns |  47.788 ns |  44.701 ns | 12,091.39 ns |     3.86 |    0.03 |  2.0447 |     - |     - |   4,304 B |
|        LinqOptimizer | .NET 5 | .NET 5.0 |  1000 | 65,438.53 ns | 355.361 ns | 277.442 ns | 65,453.08 ns |    20.92 |    0.21 | 17.2119 |     - |     - |  36,009 B |
|              Streams | .NET 5 | .NET 5.0 |  1000 | 12,284.85 ns |  39.660 ns |  37.098 ns | 12,284.19 ns |     3.93 |    0.04 |  2.3041 |     - |     - |   4,848 B |
|           StructLinq | .NET 5 | .NET 5.0 |  1000 |  5,585.81 ns |  26.260 ns |  24.563 ns |  5,584.82 ns |     1.79 |    0.02 |  1.0300 |     - |     - |   2,168 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |  1000 |  3,011.79 ns |  35.789 ns |  29.885 ns |  2,993.70 ns |     0.96 |    0.01 |  0.9880 |     - |     - |   2,072 B |
|            Hyperlinq | .NET 5 | .NET 5.0 |  1000 |  5,038.32 ns |  42.403 ns |  39.664 ns |  5,042.76 ns |     1.61 |    0.02 |  0.9842 |     - |     - |   2,072 B |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 |  1000 |  3,851.41 ns |  15.635 ns |  14.625 ns |  3,855.09 ns |     1.23 |    0.01 |  0.9880 |     - |     - |   2,072 B |
|                      |        |          |       |              |            |            |              |          |         |         |       |       |           |
|              ForLoop | .NET 6 | .NET 6.0 |  1000 |  2,228.49 ns |  19.023 ns |  17.794 ns |  2,232.11 ns |     1.00 |    0.00 |  2.0561 |     - |     - |   4,304 B |
|          ForeachLoop | .NET 6 | .NET 6.0 |  1000 |  2,091.31 ns |  41.528 ns |  67.059 ns |  2,055.83 ns |     0.97 |    0.03 |  2.0561 |     - |     - |   4,304 B |
|                 Linq | .NET 6 | .NET 6.0 |  1000 |  4,925.91 ns |  37.269 ns |  34.861 ns |  4,917.54 ns |     2.21 |    0.03 |  2.1286 |     - |     - |   4,456 B |
|           LinqFaster | .NET 6 | .NET 6.0 |  1000 |  5,539.21 ns |  49.470 ns |  43.854 ns |  5,546.89 ns |     2.49 |    0.03 |  3.0441 |     - |     - |   6,376 B |
|               LinqAF | .NET 6 | .NET 6.0 |  1000 | 11,586.51 ns | 124.715 ns | 197.811 ns | 11,544.77 ns |     5.22 |    0.13 |  2.0447 |     - |     - |   4,304 B |
|        LinqOptimizer | .NET 6 | .NET 6.0 |  1000 | 62,508.40 ns | 439.405 ns | 389.521 ns | 62,543.68 ns |    28.05 |    0.28 | 16.9678 |     - |     - |  35,559 B |
|              Streams | .NET 6 | .NET 6.0 |  1000 | 11,648.18 ns |  46.344 ns |  41.083 ns | 11,641.57 ns |     5.23 |    0.05 |  2.3041 |     - |     - |   4,848 B |
|           StructLinq | .NET 6 | .NET 6.0 |  1000 |  5,454.08 ns | 107.319 ns | 187.960 ns |  5,324.82 ns |     2.41 |    0.07 |  1.0300 |     - |     - |   2,168 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |  1000 |  2,976.11 ns |  16.378 ns |  14.519 ns |  2,976.83 ns |     1.34 |    0.01 |  0.9880 |     - |     - |   2,072 B |
|            Hyperlinq | .NET 6 | .NET 6.0 |  1000 |  4,808.53 ns |  20.529 ns |  19.203 ns |  4,816.44 ns |     2.16 |    0.02 |  0.9842 |     - |     - |   2,072 B |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 |  1000 |  1,322.43 ns |   8.690 ns |   6.785 ns |  1,321.72 ns |     0.59 |    0.00 |  0.9899 |     - |     - |   2,072 B |
