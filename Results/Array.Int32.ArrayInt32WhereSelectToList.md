## Array.Int32.ArrayInt32WhereSelectToList

### Source
[ArrayInt32WhereSelectToList.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelectToList.cs)

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
|               Method |    Job |  Runtime | Count |         Mean |      Error |     StdDev |    Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |--------- |------ |-------------:|-----------:|-----------:|---------:|--------:|--------:|------:|------:|----------:|
|              **ForLoop** | **.NET 5** | **.NET 5.0** |    **10** |     **23.07 ns** |   **0.122 ns** |   **0.114 ns** |     **1.00** |    **0.00** |  **0.0344** |     **-** |     **-** |      **72 B** |
|          ForeachLoop | .NET 5 | .NET 5.0 |    10 |     22.04 ns |   0.133 ns |   0.118 ns |     0.96 |    0.00 |  0.0344 |     - |     - |      72 B |
|                 Linq | .NET 5 | .NET 5.0 |    10 |     88.59 ns |   0.360 ns |   0.319 ns |     3.84 |    0.02 |  0.0842 |     - |     - |     176 B |
|           LinqFaster | .NET 5 | .NET 5.0 |    10 |     66.96 ns |   0.361 ns |   0.301 ns |     2.90 |    0.01 |  0.0764 |     - |     - |     160 B |
|               LinqAF | .NET 5 | .NET 5.0 |    10 |    100.72 ns |   0.352 ns |   0.329 ns |     4.37 |    0.03 |  0.0343 |     - |     - |      72 B |
|        LinqOptimizer | .NET 5 | .NET 5.0 |    10 | 47,716.84 ns | 246.188 ns | 230.284 ns | 2,068.75 |   12.91 | 14.5874 |     - |     - |  30,634 B |
|              Streams | .NET 5 | .NET 5.0 |    10 |    285.21 ns |   2.553 ns |   2.388 ns |    12.37 |    0.13 |  0.2937 |     - |     - |     616 B |
|           StructLinq | .NET 5 | .NET 5.0 |    10 |    136.74 ns |   0.681 ns |   0.637 ns |     5.93 |    0.04 |  0.0763 |     - |     - |     160 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |    10 |    101.29 ns |   0.362 ns |   0.282 ns |     4.39 |    0.03 |  0.0305 |     - |     - |      64 B |
|            Hyperlinq | .NET 5 | .NET 5.0 |    10 |    110.67 ns |   0.407 ns |   0.380 ns |     4.80 |    0.03 |  0.0305 |     - |     - |      64 B |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 |    10 |     89.56 ns |   0.334 ns |   0.312 ns |     3.88 |    0.02 |  0.0305 |     - |     - |      64 B |
|                      |        |          |       |              |            |            |          |         |         |       |       |           |
|              ForLoop | .NET 6 | .NET 6.0 |    10 |     22.47 ns |   0.197 ns |   0.184 ns |     1.00 |    0.00 |  0.0344 |     - |     - |      72 B |
|          ForeachLoop | .NET 6 | .NET 6.0 |    10 |     22.45 ns |   0.202 ns |   0.189 ns |     1.00 |    0.01 |  0.0344 |     - |     - |      72 B |
|                 Linq | .NET 6 | .NET 6.0 |    10 |     84.32 ns |   0.605 ns |   0.566 ns |     3.75 |    0.04 |  0.0842 |     - |     - |     176 B |
|           LinqFaster | .NET 6 | .NET 6.0 |    10 |     68.38 ns |   0.464 ns |   0.434 ns |     3.04 |    0.03 |  0.0764 |     - |     - |     160 B |
|               LinqAF | .NET 6 | .NET 6.0 |    10 |    102.96 ns |   0.518 ns |   0.459 ns |     4.58 |    0.04 |  0.0343 |     - |     - |      72 B |
|        LinqOptimizer | .NET 6 | .NET 6.0 |    10 | 44,923.91 ns | 173.198 ns | 153.535 ns | 1,998.27 |   17.62 | 14.4653 |     - |     - |  30,376 B |
|              Streams | .NET 6 | .NET 6.0 |    10 |    263.58 ns |   1.047 ns |   0.875 ns |    11.72 |    0.10 |  0.2937 |     - |     - |     616 B |
|           StructLinq | .NET 6 | .NET 6.0 |    10 |    148.48 ns |   0.857 ns |   0.759 ns |     6.60 |    0.05 |  0.0763 |     - |     - |     160 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |    10 |    100.25 ns |   1.520 ns |   1.270 ns |     4.46 |    0.06 |  0.0305 |     - |     - |      64 B |
|            Hyperlinq | .NET 6 | .NET 6.0 |    10 |    106.84 ns |   0.279 ns |   0.261 ns |     4.75 |    0.04 |  0.0305 |     - |     - |      64 B |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 |    10 |     89.16 ns |   0.480 ns |   0.400 ns |     3.96 |    0.04 |  0.0305 |     - |     - |      64 B |
|                      |        |          |       |              |            |            |          |         |         |       |       |           |
|              **ForLoop** | **.NET 5** | **.NET 5.0** |  **1000** |  **2,720.86 ns** |  **20.410 ns** |  **18.093 ns** |     **1.00** |    **0.00** |  **2.0561** |     **-** |     **-** |   **4,304 B** |
|          ForeachLoop | .NET 5 | .NET 5.0 |  1000 |  2,735.16 ns |  13.163 ns |  12.313 ns |     1.01 |    0.01 |  2.0561 |     - |     - |   4,304 B |
|                 Linq | .NET 5 | .NET 5.0 |  1000 |  5,262.23 ns |  33.597 ns |  31.427 ns |     1.93 |    0.02 |  2.1057 |     - |     - |   4,408 B |
|           LinqFaster | .NET 5 | .NET 5.0 |  1000 |  4,932.75 ns |  31.105 ns |  27.573 ns |     1.81 |    0.02 |  3.8834 |     - |     - |   8,136 B |
|               LinqAF | .NET 5 | .NET 5.0 |  1000 |  7,593.69 ns |  34.792 ns |  29.053 ns |     2.79 |    0.02 |  2.0523 |     - |     - |   4,304 B |
|        LinqOptimizer | .NET 5 | .NET 5.0 |  1000 | 50,541.07 ns | 452.416 ns | 377.788 ns |    18.58 |    0.17 | 16.5405 |     - |     - |  34,652 B |
|              Streams | .NET 5 | .NET 5.0 |  1000 | 10,846.55 ns |  46.548 ns |  43.541 ns |     3.99 |    0.04 |  2.3041 |     - |     - |   4,848 B |
|           StructLinq | .NET 5 | .NET 5.0 |  1000 |  5,507.57 ns |  31.253 ns |  29.234 ns |     2.03 |    0.02 |  1.0300 |     - |     - |   2,168 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |  1000 |  2,665.37 ns |  16.609 ns |  12.967 ns |     0.98 |    0.01 |  0.9880 |     - |     - |   2,072 B |
|            Hyperlinq | .NET 5 | .NET 5.0 |  1000 |  5,138.19 ns |  23.767 ns |  21.069 ns |     1.89 |    0.01 |  0.9842 |     - |     - |   2,072 B |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 |  1000 |  3,945.52 ns |  16.404 ns |  14.542 ns |     1.45 |    0.01 |  0.9842 |     - |     - |   2,072 B |
|                      |        |          |       |              |            |            |          |         |         |       |       |           |
|              ForLoop | .NET 6 | .NET 6.0 |  1000 |  1,314.79 ns |  14.629 ns |  13.684 ns |     1.00 |    0.00 |  2.0561 |     - |     - |   4,304 B |
|          ForeachLoop | .NET 6 | .NET 6.0 |  1000 |  1,348.85 ns |   7.228 ns |   6.408 ns |     1.03 |    0.01 |  2.0561 |     - |     - |   4,304 B |
|                 Linq | .NET 6 | .NET 6.0 |  1000 |  4,385.84 ns |  22.218 ns |  19.696 ns |     3.34 |    0.04 |  2.1057 |     - |     - |   4,408 B |
|           LinqFaster | .NET 6 | .NET 6.0 |  1000 |  4,852.73 ns |  27.527 ns |  25.749 ns |     3.69 |    0.04 |  3.8834 |     - |     - |   8,136 B |
|               LinqAF | .NET 6 | .NET 6.0 |  1000 |  6,455.84 ns |  31.560 ns |  29.521 ns |     4.91 |    0.05 |  2.0523 |     - |     - |   4,304 B |
|        LinqOptimizer | .NET 6 | .NET 6.0 |  1000 | 46,762.53 ns | 242.270 ns | 202.307 ns |    35.65 |    0.38 | 16.4185 |     - |     - |  34,394 B |
|              Streams | .NET 6 | .NET 6.0 |  1000 | 10,684.29 ns |  44.936 ns |  42.033 ns |     8.13 |    0.08 |  2.3041 |     - |     - |   4,848 B |
|           StructLinq | .NET 6 | .NET 6.0 |  1000 |  5,523.25 ns |  29.974 ns |  28.038 ns |     4.20 |    0.05 |  1.0300 |     - |     - |   2,168 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |  1000 |  4,399.56 ns |  13.021 ns |  11.543 ns |     3.35 |    0.04 |  0.9842 |     - |     - |   2,072 B |
|            Hyperlinq | .NET 6 | .NET 6.0 |  1000 |  4,569.30 ns |  27.252 ns |  25.492 ns |     3.48 |    0.04 |  0.9842 |     - |     - |   2,072 B |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 |  1000 |  1,332.32 ns |   5.979 ns |   4.992 ns |     1.02 |    0.01 |  0.9899 |     - |     - |   2,072 B |
