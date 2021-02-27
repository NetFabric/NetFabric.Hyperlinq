## Array.ValueType.ArrayValueTypeWhereSelectToList

### Source
[ArrayValueTypeWhereSelectToList.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelectToList.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta41](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta41)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1516-nightly, OS=Windows 10.0.19042.844 (20H2/October2020Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.1.21103.13
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|                                Method | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |   Gen 0 |   Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |-------------:|-----------:|-----------:|------:|--------:|--------:|--------:|------:|----------:|
|                    **ValueLinq_Standard** |    **10** |    **228.21 ns** |   **1.061 ns** |   **0.828 ns** |  **3.79** |    **0.02** |  **0.0880** |       **-** |     **-** |     **184 B** |
|                       ValueLinq_Stack |    10 |    185.29 ns |   1.771 ns |   1.570 ns |  3.09 |    0.04 |  0.0880 |       - |     - |     184 B |
|             ValueLinq_SharedPool_Push |    10 |    438.88 ns |   2.350 ns |   2.198 ns |  7.31 |    0.07 |  0.0877 |       - |     - |     184 B |
|             ValueLinq_SharedPool_Pull |    10 |    327.84 ns |   1.566 ns |   1.388 ns |  5.46 |    0.06 |  0.0877 |       - |     - |     184 B |
|                ValueLinq_Ref_Standard |    10 |    212.63 ns |   0.865 ns |   0.675 ns |  3.53 |    0.03 |  0.0880 |       - |     - |     184 B |
|                   ValueLinq_Ref_Stack |    10 |    173.23 ns |   1.152 ns |   1.077 ns |  2.89 |    0.03 |  0.0880 |       - |     - |     184 B |
|         ValueLinq_Ref_SharedPool_Push |    10 |    350.14 ns |   2.403 ns |   2.007 ns |  5.83 |    0.07 |  0.0877 |       - |     - |     184 B |
|         ValueLinq_Ref_SharedPool_Pull |    10 |    340.29 ns |   1.570 ns |   1.226 ns |  5.66 |    0.05 |  0.0877 |       - |     - |     184 B |
|        ValueLinq_ValueLambda_Standard |    10 |    230.17 ns |   0.805 ns |   0.672 ns |  3.83 |    0.04 |  0.0880 |       - |     - |     184 B |
|           ValueLinq_ValueLambda_Stack |    10 |    198.35 ns |   1.023 ns |   0.907 ns |  3.30 |    0.04 |  0.0880 |       - |     - |     184 B |
| ValueLinq_ValueLambda_SharedPool_Push |    10 |    361.90 ns |   1.208 ns |   1.009 ns |  6.03 |    0.07 |  0.0877 |       - |     - |     184 B |
| ValueLinq_ValueLambda_SharedPool_Pull |    10 |    356.20 ns |   1.729 ns |   1.444 ns |  5.93 |    0.06 |  0.0877 |       - |     - |     184 B |
|                               ForLoop |    10 |     60.01 ns |   0.613 ns |   0.573 ns |  1.00 |    0.00 |  0.1491 |       - |     - |     312 B |
|                           ForeachLoop |    10 |     70.16 ns |   0.693 ns |   0.648 ns |  1.17 |    0.02 |  0.1491 |       - |     - |     312 B |
|                                  Linq |    10 |    150.35 ns |   0.855 ns |   0.714 ns |  2.50 |    0.03 |  0.2525 |       - |     - |     528 B |
|                            LinqFaster |    10 |    149.52 ns |   1.223 ns |   1.022 ns |  2.49 |    0.03 |  0.4780 |       - |     - |   1,000 B |
|                                LinqAF |    10 |    239.63 ns |   2.614 ns |   2.183 ns |  3.99 |    0.04 |  0.1488 |       - |     - |     312 B |
|                            StructLinq |    10 |    176.73 ns |   0.548 ns |   0.486 ns |  2.94 |    0.03 |  0.1338 |       - |     - |     280 B |
|                  StructLinq_IFunction |    10 |    129.87 ns |   0.725 ns |   0.605 ns |  2.16 |    0.02 |  0.0880 |       - |     - |     184 B |
|                             Hyperlinq |    10 |    170.43 ns |   0.744 ns |   0.621 ns |  2.84 |    0.03 |  0.0880 |       - |     - |     184 B |
|                   Hyperlinq_IFunction |    10 |    145.04 ns |   0.883 ns |   0.783 ns |  2.42 |    0.03 |  0.0880 |       - |     - |     184 B |
|                                       |       |              |            |            |       |         |         |         |       |           |
|                    **ValueLinq_Standard** |  **1000** | **19,214.52 ns** | **239.530 ns** | **224.057 ns** |  **1.52** |    **0.01** | **31.2195** |       **-** |     **-** |  **65,504 B** |
|                       ValueLinq_Stack |  1000 | 16,481.45 ns |  72.004 ns |  60.126 ns |  1.30 |    0.01 | 30.2734 |       - |     - |  64,112 B |
|             ValueLinq_SharedPool_Push |  1000 | 18,061.24 ns | 116.115 ns | 102.933 ns |  1.43 |    0.01 | 15.3809 |       - |     - |  32,248 B |
|             ValueLinq_SharedPool_Pull |  1000 | 14,923.68 ns | 107.519 ns | 100.573 ns |  1.18 |    0.01 | 15.3809 |       - |     - |  32,248 B |
|                ValueLinq_Ref_Standard |  1000 | 17,352.58 ns | 152.335 ns | 142.494 ns |  1.37 |    0.01 | 31.2195 |       - |     - |  65,504 B |
|                   ValueLinq_Ref_Stack |  1000 | 17,121.68 ns | 141.131 ns | 117.851 ns |  1.35 |    0.01 | 30.2734 |       - |     - |  64,112 B |
|         ValueLinq_Ref_SharedPool_Push |  1000 | 16,387.71 ns | 104.933 ns |  87.624 ns |  1.30 |    0.01 | 15.3809 |       - |     - |  32,248 B |
|         ValueLinq_Ref_SharedPool_Pull |  1000 | 15,236.91 ns |  74.257 ns |  62.008 ns |  1.21 |    0.01 | 15.3809 |       - |     - |  32,248 B |
|        ValueLinq_ValueLambda_Standard |  1000 | 16,457.84 ns |  84.495 ns |  70.557 ns |  1.30 |    0.01 | 31.2195 |       - |     - |  65,504 B |
|           ValueLinq_ValueLambda_Stack |  1000 | 16,837.56 ns | 165.323 ns | 154.643 ns |  1.33 |    0.02 | 30.2734 |       - |     - |  64,112 B |
| ValueLinq_ValueLambda_SharedPool_Push |  1000 | 15,327.88 ns |  78.784 ns |  65.788 ns |  1.21 |    0.01 | 15.3809 |       - |     - |  32,248 B |
| ValueLinq_ValueLambda_SharedPool_Pull |  1000 | 14,621.16 ns | 153.178 ns | 143.283 ns |  1.15 |    0.02 | 15.3809 |       - |     - |  32,248 B |
|                               ForLoop |  1000 | 12,653.91 ns | 101.405 ns |  89.892 ns |  1.00 |    0.00 | 31.2347 |       - |     - |  65,504 B |
|                           ForeachLoop |  1000 | 13,930.26 ns | 106.680 ns |  94.569 ns |  1.10 |    0.01 | 31.2347 |       - |     - |  65,504 B |
|                                  Linq |  1000 | 16,808.63 ns | 128.604 ns | 120.296 ns |  1.33 |    0.02 | 31.2195 |       - |     - |  65,720 B |
|                            LinqFaster |  1000 | 19,281.66 ns |  78.627 ns |  65.657 ns |  1.52 |    0.01 | 58.3801 | 14.5874 |     - | 128,488 B |
|                                LinqAF |  1000 | 28,378.12 ns | 406.812 ns | 380.532 ns |  2.24 |    0.03 | 31.2195 |       - |     - |  65,504 B |
|                            StructLinq |  1000 | 16,917.95 ns |  84.777 ns |  75.152 ns |  1.34 |    0.01 | 15.3809 |       - |     - |  32,344 B |
|                  StructLinq_IFunction |  1000 | 11,439.97 ns | 115.677 ns | 102.544 ns |  0.90 |    0.01 | 15.3809 |       - |     - |  32,248 B |
|                             Hyperlinq |  1000 | 16,840.77 ns | 202.874 ns | 179.843 ns |  1.33 |    0.01 | 15.3809 |       - |     - |  32,248 B |
|                   Hyperlinq_IFunction |  1000 | 12,547.93 ns |  72.366 ns |  60.429 ns |  0.99 |    0.01 | 15.3809 |       - |     - |  32,248 B |
