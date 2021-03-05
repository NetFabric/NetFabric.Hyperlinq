## List.ValueType.ListValueTypeWhereSelectToArray

### Source
[ListValueTypeWhereSelectToArray.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelectToArray.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1517-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.1.21103.13
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|                                        Method | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------------------------- |------ |-------------:|-----------:|-----------:|------:|--------:|--------:|------:|------:|----------:|
|                            **ValueLinq_Standard** |    **10** |    **232.37 ns** |   **0.776 ns** |   **0.726 ns** |  **3.01** |    **0.03** |  **0.0725** |     **-** |     **-** |     **152 B** |
|                               ValueLinq_Stack |    10 |    197.70 ns |   1.575 ns |   1.315 ns |  2.56 |    0.03 |  0.0725 |     - |     - |     152 B |
|                     ValueLinq_SharedPool_Push |    10 |    441.81 ns |   1.132 ns |   1.004 ns |  5.71 |    0.05 |  0.0725 |     - |     - |     152 B |
|                     ValueLinq_SharedPool_Pull |    10 |    358.21 ns |   1.435 ns |   1.272 ns |  4.63 |    0.05 |  0.0725 |     - |     - |     152 B |
|                        ValueLinq_Ref_Standard |    10 |    248.27 ns |   0.991 ns |   0.927 ns |  3.21 |    0.03 |  0.0725 |     - |     - |     152 B |
|                           ValueLinq_Ref_Stack |    10 |    211.12 ns |   0.534 ns |   0.474 ns |  2.73 |    0.02 |  0.0725 |     - |     - |     152 B |
|                 ValueLinq_Ref_SharedPool_Push |    10 |    351.34 ns |   0.676 ns |   0.633 ns |  4.55 |    0.04 |  0.0725 |     - |     - |     152 B |
|                 ValueLinq_Ref_SharedPool_Pull |    10 |    364.53 ns |   1.127 ns |   0.999 ns |  4.71 |    0.04 |  0.0725 |     - |     - |     152 B |
|                ValueLinq_ValueLambda_Standard |    10 |    260.07 ns |   2.683 ns |   2.510 ns |  3.37 |    0.05 |  0.0725 |     - |     - |     152 B |
|                   ValueLinq_ValueLambda_Stack |    10 |    219.95 ns |   1.661 ns |   1.554 ns |  2.85 |    0.03 |  0.0725 |     - |     - |     152 B |
|         ValueLinq_ValueLambda_SharedPool_Push |    10 |    357.64 ns |   0.995 ns |   0.930 ns |  4.63 |    0.04 |  0.0725 |     - |     - |     152 B |
|         ValueLinq_ValueLambda_SharedPool_Pull |    10 |    371.04 ns |   1.979 ns |   1.852 ns |  4.80 |    0.05 |  0.0725 |     - |     - |     152 B |
|                    ValueLinq_Standard_ByIndex |    10 |    214.89 ns |   1.455 ns |   1.290 ns |  2.78 |    0.03 |  0.0725 |     - |     - |     152 B |
|                       ValueLinq_Stack_ByIndex |    10 |    165.55 ns |   2.053 ns |   1.715 ns |  2.14 |    0.03 |  0.0725 |     - |     - |     152 B |
|             ValueLinq_SharedPool_Push_ByIndex |    10 |    446.59 ns |   1.494 ns |   1.398 ns |  5.78 |    0.06 |  0.0725 |     - |     - |     152 B |
|             ValueLinq_SharedPool_Pull_ByIndex |    10 |    312.55 ns |   1.070 ns |   0.949 ns |  4.04 |    0.03 |  0.0725 |     - |     - |     152 B |
|                ValueLinq_Ref_Standard_ByIndex |    10 |    183.10 ns |   0.616 ns |   0.576 ns |  2.37 |    0.02 |  0.0725 |     - |     - |     152 B |
|                   ValueLinq_Ref_Stack_ByIndex |    10 |    152.25 ns |   0.581 ns |   0.515 ns |  1.97 |    0.02 |  0.0725 |     - |     - |     152 B |
|         ValueLinq_Ref_SharedPool_Push_ByIndex |    10 |    361.75 ns |   1.070 ns |   0.949 ns |  4.68 |    0.04 |  0.0725 |     - |     - |     152 B |
|         ValueLinq_Ref_SharedPool_Pull_ByIndex |    10 |    303.11 ns |   1.040 ns |   0.922 ns |  3.92 |    0.03 |  0.0725 |     - |     - |     152 B |
|        ValueLinq_ValueLambda_Standard_ByIndex |    10 |    194.70 ns |   1.325 ns |   1.239 ns |  2.52 |    0.02 |  0.0725 |     - |     - |     152 B |
|           ValueLinq_ValueLambda_Stack_ByIndex |    10 |    167.76 ns |   0.937 ns |   0.830 ns |  2.17 |    0.02 |  0.0725 |     - |     - |     152 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |    10 |    370.27 ns |   0.716 ns |   0.559 ns |  4.78 |    0.03 |  0.0725 |     - |     - |     152 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |    10 |    315.33 ns |   1.322 ns |   1.104 ns |  4.08 |    0.04 |  0.0725 |     - |     - |     152 B |
|                                       ForLoop |    10 |     77.28 ns |   0.667 ns |   0.624 ns |  1.00 |    0.00 |  0.2218 |     - |     - |     464 B |
|                                   ForeachLoop |    10 |    109.35 ns |   0.392 ns |   0.306 ns |  1.41 |    0.01 |  0.2218 |     - |     - |     464 B |
|                                          Linq |    10 |    177.39 ns |   0.905 ns |   0.847 ns |  2.30 |    0.02 |  0.3862 |     - |     - |     808 B |
|                                    LinqFaster |    10 |    103.72 ns |   0.969 ns |   0.757 ns |  1.34 |    0.01 |  0.2218 |     - |     - |     464 B |
|                                        LinqAF |    10 |    309.49 ns |   5.938 ns |   5.832 ns |  4.01 |    0.08 |  0.2065 |     - |     - |     432 B |
|                                    StructLinq |    10 |    144.83 ns |   0.376 ns |   0.314 ns |  1.87 |    0.02 |  0.1223 |     - |     - |     256 B |
|                          StructLinq_IFunction |    10 |    117.70 ns |   0.590 ns |   0.523 ns |  1.52 |    0.01 |  0.0725 |     - |     - |     152 B |
|                                     Hyperlinq |    10 |    152.18 ns |   0.988 ns |   0.771 ns |  1.97 |    0.02 |  0.0725 |     - |     - |     152 B |
|                           Hyperlinq_IFunction |    10 |    127.85 ns |   0.913 ns |   0.854 ns |  1.65 |    0.02 |  0.0725 |     - |     - |     152 B |
|                                               |       |              |            |            |       |         |         |       |       |           |
|                            **ValueLinq_Standard** |  **1000** | **18,061.03 ns** | **158.841 ns** | **140.809 ns** |  **1.24** |    **0.01** | **30.2734** |     **-** |     **-** |  **64,080 B** |
|                               ValueLinq_Stack |  1000 | 18,052.83 ns | 161.526 ns | 151.092 ns |  1.24 |    0.01 | 30.2734 |     - |     - |  64,080 B |
|                     ValueLinq_SharedPool_Push |  1000 | 16,498.13 ns | 165.308 ns | 138.039 ns |  1.13 |    0.01 | 15.1367 |     - |     - |  32,216 B |
|                     ValueLinq_SharedPool_Pull |  1000 | 16,940.66 ns | 183.797 ns | 162.931 ns |  1.16 |    0.01 | 15.1367 |     - |     - |  32,216 B |
|                        ValueLinq_Ref_Standard |  1000 | 17,236.07 ns |  78.165 ns |  65.271 ns |  1.18 |    0.01 | 30.2734 |     - |     - |  64,080 B |
|                           ValueLinq_Ref_Stack |  1000 | 17,198.51 ns | 108.748 ns |  96.402 ns |  1.18 |    0.01 | 30.2734 |     - |     - |  64,080 B |
|                 ValueLinq_Ref_SharedPool_Push |  1000 | 14,851.49 ns |  65.090 ns |  57.701 ns |  1.02 |    0.00 | 15.1367 |     - |     - |  32,216 B |
|                 ValueLinq_Ref_SharedPool_Pull |  1000 | 16,416.41 ns |  43.201 ns |  36.074 ns |  1.13 |    0.01 | 15.1367 |     - |     - |  32,216 B |
|                ValueLinq_ValueLambda_Standard |  1000 | 16,246.83 ns | 217.862 ns | 181.925 ns |  1.11 |    0.01 | 30.2734 |     - |     - |  64,080 B |
|                   ValueLinq_ValueLambda_Stack |  1000 | 15,981.13 ns | 181.328 ns | 169.615 ns |  1.10 |    0.01 | 30.2734 |     - |     - |  64,080 B |
|         ValueLinq_ValueLambda_SharedPool_Push |  1000 | 13,649.38 ns |  92.833 ns |  72.478 ns |  0.94 |    0.01 | 15.1367 |     - |     - |  32,216 B |
|         ValueLinq_ValueLambda_SharedPool_Pull |  1000 | 15,683.03 ns | 242.731 ns | 215.175 ns |  1.07 |    0.02 | 15.1367 |     - |     - |  32,216 B |
|                    ValueLinq_Standard_ByIndex |  1000 | 15,445.31 ns | 121.547 ns | 113.695 ns |  1.06 |    0.01 | 30.2734 |     - |     - |  64,080 B |
|                       ValueLinq_Stack_ByIndex |  1000 | 16,248.70 ns |  74.268 ns |  69.470 ns |  1.11 |    0.01 | 30.2734 |     - |     - |  64,080 B |
|             ValueLinq_SharedPool_Push_ByIndex |  1000 | 17,115.75 ns |  73.385 ns |  61.280 ns |  1.17 |    0.01 | 15.1367 |     - |     - |  32,216 B |
|             ValueLinq_SharedPool_Pull_ByIndex |  1000 | 14,895.85 ns |  57.798 ns |  51.236 ns |  1.02 |    0.01 | 15.1367 |     - |     - |  32,216 B |
|                ValueLinq_Ref_Standard_ByIndex |  1000 | 13,690.22 ns |  35.102 ns |  31.117 ns |  0.94 |    0.00 | 30.2887 |     - |     - |  64,080 B |
|                   ValueLinq_Ref_Stack_ByIndex |  1000 | 13,032.02 ns |  32.692 ns |  30.580 ns |  0.89 |    0.00 | 30.2887 |     - |     - |  64,080 B |
|         ValueLinq_Ref_SharedPool_Push_ByIndex |  1000 | 14,426.86 ns |  65.684 ns |  61.441 ns |  0.99 |    0.00 | 15.1367 |     - |     - |  32,216 B |
|         ValueLinq_Ref_SharedPool_Pull_ByIndex |  1000 | 14,167.47 ns |  40.710 ns |  36.088 ns |  0.97 |    0.00 | 15.1367 |     - |     - |  32,216 B |
|        ValueLinq_ValueLambda_Standard_ByIndex |  1000 | 14,068.31 ns |  73.737 ns |  68.974 ns |  0.96 |    0.01 | 30.2887 |     - |     - |  64,080 B |
|           ValueLinq_ValueLambda_Stack_ByIndex |  1000 | 13,875.74 ns | 102.583 ns |  90.937 ns |  0.95 |    0.01 | 30.2887 |     - |     - |  64,080 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |  1000 | 13,687.72 ns |  75.727 ns |  67.130 ns |  0.94 |    0.01 | 15.1367 |     - |     - |  32,216 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |  1000 | 13,184.66 ns | 113.916 ns | 100.983 ns |  0.90 |    0.01 | 15.1367 |     - |     - |  32,216 B |
|                                       ForLoop |  1000 | 14,589.60 ns |  76.321 ns |  63.731 ns |  1.00 |    0.00 | 46.5088 |     - |     - |  97,720 B |
|                                   ForeachLoop |  1000 | 16,379.12 ns |  86.220 ns |  76.432 ns |  1.12 |    0.01 | 46.5088 |     - |     - |  97,720 B |
|                                          Linq |  1000 | 16,259.63 ns | 243.695 ns | 227.952 ns |  1.12 |    0.02 | 31.2195 |     - |     - |  65,952 B |
|                                    LinqFaster |  1000 | 19,006.81 ns | 185.283 ns | 173.314 ns |  1.30 |    0.01 | 46.5088 |     - |     - |  97,720 B |
|                                        LinqAF |  1000 | 31,409.79 ns | 391.473 ns | 347.030 ns |  2.15 |    0.03 | 46.5088 |     - |     - |  97,688 B |
|                                    StructLinq |  1000 | 13,899.28 ns | 109.680 ns |  91.588 ns |  0.95 |    0.01 | 15.3809 |     - |     - |  32,320 B |
|                          StructLinq_IFunction |  1000 | 10,286.13 ns |  44.617 ns |  41.735 ns |  0.70 |    0.00 | 15.1367 |     - |     - |  32,216 B |
|                                     Hyperlinq |  1000 | 15,536.76 ns | 238.645 ns | 223.228 ns |  1.07 |    0.02 | 15.1367 |     - |     - |  32,216 B |
|                           Hyperlinq_IFunction |  1000 | 11,182.04 ns |  68.009 ns |  63.616 ns |  0.77 |    0.01 | 15.1367 |     - |     - |  32,216 B |
