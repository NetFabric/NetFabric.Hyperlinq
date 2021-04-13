## Array.ValueType.ArrayValueTypeSkipTakeSelect

### Source
[ArrayValueTypeSkipTakeSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSkipTakeSelect.cs)

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
|                      Method |    Job |  Runtime | Skip | Count |         Mean |       Error |       StdDev |       Median |  Ratio | RatioSD |   Gen 0 |   Gen 1 | Gen 2 | Allocated |
|---------------------------- |------- |--------- |----- |------ |-------------:|------------:|-------------:|-------------:|-------:|--------:|--------:|--------:|------:|----------:|
|                     **ForLoop** | **.NET 5** | **.NET 5.0** | **1000** |    **10** |     **164.0 ns** |     **0.41 ns** |      **0.36 ns** |     **164.1 ns** |   **1.00** |    **0.00** |       **-** |       **-** |     **-** |         **-** |
|                 ForeachLoop | .NET 5 | .NET 5.0 | 1000 |    10 |   2,386.4 ns |    24.74 ns |     20.66 ns |   2,379.5 ns |  14.55 |    0.13 |  0.0153 |       - |     - |      32 B |
|                        Linq | .NET 5 | .NET 5.0 | 1000 |    10 |     359.2 ns |     1.96 ns |      1.84 ns |     358.8 ns |   2.19 |    0.01 |  0.1526 |       - |     - |     320 B |
|                  LinqFaster | .NET 5 | .NET 5.0 | 1000 |    10 |     318.5 ns |     4.47 ns |      3.73 ns |     318.1 ns |   1.94 |    0.03 |  0.9522 |       - |     - |   1,992 B |
|                      LinqAF | .NET 5 | .NET 5.0 | 1000 |    10 |   5,328.8 ns |   105.41 ns |    190.07 ns |   5,285.5 ns |  33.29 |    1.15 |       - |       - |     - |         - |
|               LinqOptimizer | .NET 5 | .NET 5.0 | 1000 |    10 |  53,759.9 ns |   251.48 ns |    222.93 ns |  53,839.1 ns | 327.85 |    1.53 | 74.0356 |       - |     - | 155,210 B |
|                     Streams | .NET 5 | .NET 5.0 | 1000 |    10 |   7,773.1 ns |    46.59 ns |     43.58 ns |   7,768.6 ns |  47.41 |    0.32 |  0.5493 |       - |     - |   1,152 B |
|                  StructLinq | .NET 5 | .NET 5.0 | 1000 |    10 |     251.3 ns |     0.82 ns |      0.77 ns |     251.2 ns |   1.53 |    0.01 |  0.0458 |       - |     - |      96 B |
|        StructLinq_IFunction | .NET 5 | .NET 5.0 | 1000 |    10 |     198.9 ns |     0.43 ns |      0.38 ns |     198.8 ns |   1.21 |    0.00 |       - |       - |     - |         - |
|           Hyperlinq_Foreach | .NET 5 | .NET 5.0 | 1000 |    10 |     237.5 ns |     0.77 ns |      0.69 ns |     237.6 ns |   1.45 |    0.01 |       - |       - |     - |         - |
| Hyperlinq_Foreach_IFunction | .NET 5 | .NET 5.0 | 1000 |    10 |     215.2 ns |     0.88 ns |      0.74 ns |     215.1 ns |   1.31 |    0.01 |       - |       - |     - |         - |
|               Hyperlinq_For | .NET 5 | .NET 5.0 | 1000 |    10 |     229.1 ns |     0.54 ns |      0.48 ns |     229.0 ns |   1.40 |    0.00 |       - |       - |     - |         - |
|     Hyperlinq_For_IFunction | .NET 5 | .NET 5.0 | 1000 |    10 |     205.7 ns |     0.67 ns |      0.63 ns |     205.6 ns |   1.25 |    0.00 |       - |       - |     - |         - |
|                             |        |          |      |       |              |             |              |              |        |         |         |         |       |           |
|                     ForLoop | .NET 6 | .NET 6.0 | 1000 |    10 |     164.5 ns |     0.61 ns |      0.57 ns |     164.6 ns |   1.00 |    0.00 |       - |       - |     - |         - |
|                 ForeachLoop | .NET 6 | .NET 6.0 | 1000 |    10 |   1,485.3 ns |     6.07 ns |      5.68 ns |   1,482.7 ns |   9.03 |    0.04 |  0.0153 |       - |     - |      32 B |
|                        Linq | .NET 6 | .NET 6.0 | 1000 |    10 |     317.6 ns |     1.72 ns |      1.61 ns |     317.4 ns |   1.93 |    0.01 |  0.1526 |       - |     - |     320 B |
|                  LinqFaster | .NET 6 | .NET 6.0 | 1000 |    10 |     389.2 ns |     4.98 ns |      4.66 ns |     388.4 ns |   2.37 |    0.03 |  0.9522 |       - |     - |   1,992 B |
|                      LinqAF | .NET 6 | .NET 6.0 | 1000 |    10 |   5,298.1 ns |   105.70 ns |    125.83 ns |   5,337.4 ns |  32.26 |    0.84 |       - |       - |     - |         - |
|               LinqOptimizer | .NET 6 | .NET 6.0 | 1000 |    10 |  50,860.5 ns |   397.83 ns |    332.20 ns |  50,881.6 ns | 309.20 |    2.38 | 70.1904 | 17.1509 |     - | 154,959 B |
|                     Streams | .NET 6 | .NET 6.0 | 1000 |    10 |   7,002.1 ns |    30.66 ns |     28.68 ns |   7,002.7 ns |  42.56 |    0.23 |  0.5493 |       - |     - |   1,152 B |
|                  StructLinq | .NET 6 | .NET 6.0 | 1000 |    10 |     241.4 ns |     0.96 ns |      0.90 ns |     241.4 ns |   1.47 |    0.01 |  0.0458 |       - |     - |      96 B |
|        StructLinq_IFunction | .NET 6 | .NET 6.0 | 1000 |    10 |     207.1 ns |     0.92 ns |      0.72 ns |     207.2 ns |   1.26 |    0.00 |       - |       - |     - |         - |
|           Hyperlinq_Foreach | .NET 6 | .NET 6.0 | 1000 |    10 |     239.0 ns |     0.94 ns |      0.88 ns |     238.7 ns |   1.45 |    0.01 |       - |       - |     - |         - |
| Hyperlinq_Foreach_IFunction | .NET 6 | .NET 6.0 | 1000 |    10 |     215.0 ns |     0.55 ns |      0.51 ns |     215.0 ns |   1.31 |    0.00 |       - |       - |     - |         - |
|               Hyperlinq_For | .NET 6 | .NET 6.0 | 1000 |    10 |     230.7 ns |     0.66 ns |      0.58 ns |     230.7 ns |   1.40 |    0.01 |       - |       - |     - |         - |
|     Hyperlinq_For_IFunction | .NET 6 | .NET 6.0 | 1000 |    10 |     206.1 ns |     0.59 ns |      0.56 ns |     206.2 ns |   1.25 |    0.01 |       - |       - |     - |         - |
|                             |        |          |      |       |              |             |              |              |        |         |         |         |       |           |
|                     **ForLoop** | **.NET 5** | **.NET 5.0** | **1000** |  **1000** |  **16,373.0 ns** |    **63.15 ns** |     **59.07 ns** |  **16,349.1 ns** |   **1.00** |    **0.00** |       **-** |       **-** |     **-** |         **-** |
|                 ForeachLoop | .NET 5 | .NET 5.0 | 1000 |  1000 |  20,898.5 ns |    66.24 ns |     61.96 ns |  20,896.4 ns |   1.28 |    0.01 |       - |       - |     - |      32 B |
|                        Linq | .NET 5 | .NET 5.0 | 1000 |  1000 |  26,214.6 ns |    92.40 ns |     81.91 ns |  26,226.6 ns |   1.60 |    0.01 |  0.1526 |       - |     - |     320 B |
|                  LinqFaster | .NET 5 | .NET 5.0 | 1000 |  1000 |  30,745.5 ns |   165.34 ns |    146.57 ns |  30,728.6 ns |   1.88 |    0.01 | 90.8813 |       - |     - | 192,072 B |
|                      LinqAF | .NET 5 | .NET 5.0 | 1000 |  1000 |  41,814.6 ns |   555.77 ns |    519.86 ns |  41,907.9 ns |   2.55 |    0.03 |       - |       - |     - |         - |
|               LinqOptimizer | .NET 5 | .NET 5.0 | 1000 |  1000 |  87,196.1 ns |   585.54 ns |    547.72 ns |  87,188.9 ns |   5.33 |    0.04 | 96.6797 | 16.1133 |     - | 218,590 B |
|                     Streams | .NET 5 | .NET 5.0 | 1000 |  1000 | 152,261.5 ns | 8,391.35 ns | 24,742.09 ns | 145,427.1 ns |   9.33 |    1.52 |  0.4883 |       - |     - |   1,152 B |
|                  StructLinq | .NET 5 | .NET 5.0 | 1000 |  1000 |  20,380.7 ns |   402.77 ns |    900.84 ns |  20,521.9 ns |   1.19 |    0.04 |  0.0305 |       - |     - |      96 B |
|        StructLinq_IFunction | .NET 5 | .NET 5.0 | 1000 |  1000 |  19,195.9 ns |   278.46 ns |    246.85 ns |  19,149.2 ns |   1.17 |    0.01 |       - |       - |     - |         - |
|           Hyperlinq_Foreach | .NET 5 | .NET 5.0 | 1000 |  1000 |  22,277.4 ns |   432.49 ns |    404.55 ns |  22,329.0 ns |   1.36 |    0.02 |       - |       - |     - |         - |
| Hyperlinq_Foreach_IFunction | .NET 5 | .NET 5.0 | 1000 |  1000 |  19,741.4 ns |   384.12 ns |    457.27 ns |  19,788.9 ns |   1.20 |    0.03 |       - |       - |     - |         - |
|               Hyperlinq_For | .NET 5 | .NET 5.0 | 1000 |  1000 |  21,394.7 ns |   420.80 ns |    484.59 ns |  21,488.8 ns |   1.31 |    0.03 |       - |       - |     - |         - |
|     Hyperlinq_For_IFunction | .NET 5 | .NET 5.0 | 1000 |  1000 |  18,516.9 ns |   302.76 ns |    283.20 ns |  18,463.8 ns |   1.13 |    0.02 |       - |       - |     - |         - |
|                             |        |          |      |       |              |             |              |              |        |         |         |         |       |           |
|                     ForLoop | .NET 6 | .NET 6.0 | 1000 |  1000 |  17,546.6 ns |   171.54 ns |    152.06 ns |  17,574.1 ns |   1.00 |    0.00 |       - |       - |     - |         - |
|                 ForeachLoop | .NET 6 | .NET 6.0 | 1000 |  1000 |  20,244.1 ns |   222.84 ns |    197.54 ns |  20,200.0 ns |   1.15 |    0.02 |       - |       - |     - |      32 B |
|                        Linq | .NET 6 | .NET 6.0 | 1000 |  1000 |  25,548.8 ns |   506.93 ns |  1,214.57 ns |  24,969.0 ns |   1.55 |    0.08 |  0.1526 |       - |     - |     320 B |
|                  LinqFaster | .NET 6 | .NET 6.0 | 1000 |  1000 |  31,699.6 ns |   264.84 ns |    221.16 ns |  31,649.5 ns |   1.80 |    0.02 | 90.8813 |       - |     - | 192,072 B |
|                      LinqAF | .NET 6 | .NET 6.0 | 1000 |  1000 |  42,303.4 ns |   594.02 ns |    463.77 ns |  42,329.3 ns |   2.41 |    0.04 |       - |       - |     - |         - |
|               LinqOptimizer | .NET 6 | .NET 6.0 | 1000 |  1000 |  84,147.9 ns |   498.85 ns |    466.62 ns |  84,041.0 ns |   4.80 |    0.03 | 96.6797 | 16.1133 |     - | 218,342 B |
|                     Streams | .NET 6 | .NET 6.0 | 1000 |  1000 | 113,714.6 ns |   362.04 ns |    338.65 ns | 113,851.7 ns |   6.48 |    0.06 |  0.4883 |       - |     - |   1,154 B |
|                  StructLinq | .NET 6 | .NET 6.0 | 1000 |  1000 |  18,519.0 ns |   106.71 ns |     89.11 ns |  18,510.2 ns |   1.05 |    0.01 |  0.0305 |       - |     - |      96 B |
|        StructLinq_IFunction | .NET 6 | .NET 6.0 | 1000 |  1000 |  17,604.7 ns |    48.83 ns |     45.67 ns |  17,623.1 ns |   1.00 |    0.01 |       - |       - |     - |         - |
|           Hyperlinq_Foreach | .NET 6 | .NET 6.0 | 1000 |  1000 |  19,491.4 ns |    58.16 ns |     54.40 ns |  19,481.7 ns |   1.11 |    0.01 |       - |       - |     - |         - |
| Hyperlinq_Foreach_IFunction | .NET 6 | .NET 6.0 | 1000 |  1000 |  17,344.3 ns |    50.56 ns |     47.30 ns |  17,335.7 ns |   0.99 |    0.01 |       - |       - |     - |         - |
|               Hyperlinq_For | .NET 6 | .NET 6.0 | 1000 |  1000 |  19,708.7 ns |    62.04 ns |     58.03 ns |  19,708.3 ns |   1.12 |    0.01 |       - |       - |     - |         - |
|     Hyperlinq_For_IFunction | .NET 6 | .NET 6.0 | 1000 |  1000 |  17,217.5 ns |    69.92 ns |     61.98 ns |  17,200.1 ns |   0.98 |    0.01 |       - |       - |     - |         - |
