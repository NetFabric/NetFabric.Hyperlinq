## Array.ValueType.ArrayValueTypeWhereSelectToList

### Source
[ArrayValueTypeWhereSelectToList.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelectToList.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta42](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta42)

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
|                    **ValueLinq_Standard** |    **10** |    **217.90 ns** |   **0.701 ns** |   **0.621 ns** |  **4.30** |    **0.05** |  **0.0880** |       **-** |     **-** |     **184 B** |
|                       ValueLinq_Stack |    10 |    173.76 ns |   0.793 ns |   0.703 ns |  3.43 |    0.04 |  0.0880 |       - |     - |     184 B |
|             ValueLinq_SharedPool_Push |    10 |    422.47 ns |   1.229 ns |   1.089 ns |  8.33 |    0.09 |  0.0877 |       - |     - |     184 B |
|             ValueLinq_SharedPool_Pull |    10 |    310.92 ns |   1.959 ns |   1.636 ns |  6.13 |    0.07 |  0.0877 |       - |     - |     184 B |
|                ValueLinq_Ref_Standard |    10 |    198.00 ns |   0.522 ns |   0.463 ns |  3.91 |    0.04 |  0.0880 |       - |     - |     184 B |
|                   ValueLinq_Ref_Stack |    10 |    159.35 ns |   0.611 ns |   0.542 ns |  3.14 |    0.03 |  0.0880 |       - |     - |     184 B |
|         ValueLinq_Ref_SharedPool_Push |    10 |    339.37 ns |   0.774 ns |   0.724 ns |  6.70 |    0.07 |  0.0877 |       - |     - |     184 B |
|         ValueLinq_Ref_SharedPool_Pull |    10 |    311.30 ns |   1.578 ns |   1.476 ns |  6.15 |    0.07 |  0.0877 |       - |     - |     184 B |
|        ValueLinq_ValueLambda_Standard |    10 |    225.87 ns |   0.620 ns |   0.550 ns |  4.46 |    0.05 |  0.0877 |       - |     - |     184 B |
|           ValueLinq_ValueLambda_Stack |    10 |    178.71 ns |   1.088 ns |   0.965 ns |  3.53 |    0.05 |  0.0880 |       - |     - |     184 B |
| ValueLinq_ValueLambda_SharedPool_Push |    10 |    340.68 ns |   1.065 ns |   0.889 ns |  6.72 |    0.08 |  0.0877 |       - |     - |     184 B |
| ValueLinq_ValueLambda_SharedPool_Pull |    10 |    329.91 ns |   0.973 ns |   0.910 ns |  6.51 |    0.07 |  0.0877 |       - |     - |     184 B |
|                               ForLoop |    10 |     50.65 ns |   0.558 ns |   0.522 ns |  1.00 |    0.00 |  0.1492 |       - |     - |     312 B |
|                           ForeachLoop |    10 |     61.46 ns |   1.089 ns |   0.909 ns |  1.21 |    0.02 |  0.1491 |       - |     - |     312 B |
|                                  Linq |    10 |    131.78 ns |   1.090 ns |   0.967 ns |  2.60 |    0.04 |  0.2525 |       - |     - |     528 B |
|                            LinqFaster |    10 |    121.23 ns |   0.840 ns |   0.745 ns |  2.39 |    0.03 |  0.4780 |       - |     - |   1,000 B |
|                                LinqAF |    10 |    224.02 ns |   4.150 ns |   4.075 ns |  4.42 |    0.09 |  0.1490 |       - |     - |     312 B |
|                            StructLinq |    10 |    152.45 ns |   0.770 ns |   0.643 ns |  3.01 |    0.04 |  0.1338 |       - |     - |     280 B |
|                  StructLinq_IFunction |    10 |    126.36 ns |   0.497 ns |   0.465 ns |  2.49 |    0.03 |  0.0880 |       - |     - |     184 B |
|                             Hyperlinq |    10 |    161.71 ns |   0.977 ns |   0.816 ns |  3.19 |    0.03 |  0.0880 |       - |     - |     184 B |
|                   Hyperlinq_IFunction |    10 |    136.57 ns |   1.201 ns |   1.064 ns |  2.69 |    0.04 |  0.0880 |       - |     - |     184 B |
|                                       |       |              |            |            |       |         |         |         |       |           |
|                    **ValueLinq_Standard** |  **1000** | **16,806.33 ns** | **154.271 ns** | **144.306 ns** |  **1.69** |    **0.01** | **31.2195** |       **-** |     **-** |  **65,504 B** |
|                       ValueLinq_Stack |  1000 | 13,801.47 ns |  88.309 ns |  78.284 ns |  1.39 |    0.01 | 30.2887 |       - |     - |  64,112 B |
|             ValueLinq_SharedPool_Push |  1000 | 16,819.58 ns | 198.641 ns | 185.809 ns |  1.70 |    0.02 | 15.3809 |       - |     - |  32,248 B |
|             ValueLinq_SharedPool_Pull |  1000 | 13,525.24 ns |  54.041 ns |  47.906 ns |  1.36 |    0.01 | 15.3809 |       - |     - |  32,248 B |
|                ValueLinq_Ref_Standard |  1000 | 14,621.03 ns |  40.115 ns |  33.498 ns |  1.47 |    0.01 | 31.2347 |       - |     - |  65,504 B |
|                   ValueLinq_Ref_Stack |  1000 | 15,011.30 ns |  69.114 ns |  53.960 ns |  1.51 |    0.01 | 30.2887 |       - |     - |  64,112 B |
|         ValueLinq_Ref_SharedPool_Push |  1000 | 14,801.53 ns |  66.825 ns |  59.239 ns |  1.49 |    0.01 | 15.3809 |       - |     - |  32,248 B |
|         ValueLinq_Ref_SharedPool_Pull |  1000 | 13,382.37 ns |  79.255 ns |  74.135 ns |  1.35 |    0.01 | 15.3809 |       - |     - |  32,248 B |
|        ValueLinq_ValueLambda_Standard |  1000 | 14,087.98 ns |  95.039 ns |  84.250 ns |  1.42 |    0.01 | 31.2347 |       - |     - |  65,504 B |
|           ValueLinq_ValueLambda_Stack |  1000 | 14,062.56 ns | 113.794 ns | 106.443 ns |  1.42 |    0.01 | 30.2887 |       - |     - |  64,112 B |
| ValueLinq_ValueLambda_SharedPool_Push |  1000 | 13,833.98 ns |  79.945 ns |  70.869 ns |  1.40 |    0.01 | 15.3809 |       - |     - |  32,248 B |
| ValueLinq_ValueLambda_SharedPool_Pull |  1000 | 13,175.29 ns |  99.473 ns |  93.047 ns |  1.33 |    0.01 | 15.3809 |       - |     - |  32,248 B |
|                               ForLoop |  1000 |  9,916.92 ns |  56.236 ns |  52.603 ns |  1.00 |    0.00 | 31.2347 |       - |     - |  65,504 B |
|                           ForeachLoop |  1000 | 11,779.98 ns |  81.623 ns |  72.356 ns |  1.19 |    0.01 | 31.2347 |       - |     - |  65,504 B |
|                                  Linq |  1000 | 15,179.27 ns |  60.617 ns |  50.618 ns |  1.53 |    0.01 | 31.2347 |       - |     - |  65,720 B |
|                            LinqFaster |  1000 | 15,267.30 ns |  90.788 ns |  84.923 ns |  1.54 |    0.01 | 58.3801 | 14.5874 |     - | 128,488 B |
|                                LinqAF |  1000 | 25,501.14 ns | 377.644 ns | 353.249 ns |  2.57 |    0.04 | 31.2195 |       - |     - |  65,504 B |
|                            StructLinq |  1000 | 14,046.26 ns | 115.777 ns | 108.297 ns |  1.42 |    0.01 | 15.3809 |       - |     - |  32,344 B |
|                  StructLinq_IFunction |  1000 | 10,245.07 ns |  49.030 ns |  40.942 ns |  1.03 |    0.01 | 15.3809 |       - |     - |  32,248 B |
|                             Hyperlinq |  1000 | 15,955.98 ns | 175.826 ns | 155.865 ns |  1.61 |    0.02 | 15.3809 |       - |     - |  32,248 B |
|                   Hyperlinq_IFunction |  1000 | 11,149.74 ns |  89.184 ns |  79.060 ns |  1.12 |    0.01 | 15.3809 |       - |     - |  32,248 B |
