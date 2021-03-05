## List.ValueType.ListValueTypeWhereSelectToList

### Source
[ListValueTypeWhereSelectToList.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelectToList.cs)

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
|                                        Method | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |   Gen 0 |   Gen 1 | Gen 2 | Allocated |
|---------------------------------------------- |------ |-------------:|-----------:|-----------:|------:|--------:|--------:|--------:|------:|----------:|
|                            **ValueLinq_Standard** |    **10** |    **259.93 ns** |   **0.825 ns** |   **0.689 ns** |  **4.22** |    **0.05** |  **0.0877** |       **-** |     **-** |     **184 B** |
|                               ValueLinq_Stack |    10 |    220.61 ns |   0.766 ns |   0.640 ns |  3.58 |    0.04 |  0.0880 |       - |     - |     184 B |
|                     ValueLinq_SharedPool_Push |    10 |    443.02 ns |   1.667 ns |   1.478 ns |  7.19 |    0.09 |  0.0877 |       - |     - |     184 B |
|                     ValueLinq_SharedPool_Pull |    10 |    371.38 ns |   2.007 ns |   1.779 ns |  6.03 |    0.08 |  0.0877 |       - |     - |     184 B |
|                        ValueLinq_Ref_Standard |    10 |    269.65 ns |   1.856 ns |   1.646 ns |  4.38 |    0.06 |  0.0877 |       - |     - |     184 B |
|                           ValueLinq_Ref_Stack |    10 |    232.11 ns |   0.552 ns |   0.517 ns |  3.77 |    0.04 |  0.0877 |       - |     - |     184 B |
|                 ValueLinq_Ref_SharedPool_Push |    10 |    356.43 ns |   0.830 ns |   0.736 ns |  5.78 |    0.07 |  0.0877 |       - |     - |     184 B |
|                 ValueLinq_Ref_SharedPool_Pull |    10 |    369.64 ns |   1.043 ns |   0.924 ns |  6.00 |    0.07 |  0.0877 |       - |     - |     184 B |
|                ValueLinq_ValueLambda_Standard |    10 |    283.61 ns |   2.158 ns |   2.018 ns |  4.60 |    0.07 |  0.0877 |       - |     - |     184 B |
|                   ValueLinq_ValueLambda_Stack |    10 |    247.95 ns |   2.482 ns |   2.322 ns |  4.02 |    0.06 |  0.0877 |       - |     - |     184 B |
|         ValueLinq_ValueLambda_SharedPool_Push |    10 |    360.89 ns |   1.348 ns |   1.195 ns |  5.86 |    0.07 |  0.0877 |       - |     - |     184 B |
|         ValueLinq_ValueLambda_SharedPool_Pull |    10 |    381.00 ns |   1.667 ns |   1.392 ns |  6.18 |    0.08 |  0.0877 |       - |     - |     184 B |
|                    ValueLinq_Standard_ByIndex |    10 |    230.19 ns |   1.559 ns |   1.382 ns |  3.74 |    0.04 |  0.0880 |       - |     - |     184 B |
|                       ValueLinq_Stack_ByIndex |    10 |    186.84 ns |   1.008 ns |   0.894 ns |  3.03 |    0.03 |  0.0880 |       - |     - |     184 B |
|             ValueLinq_SharedPool_Push_ByIndex |    10 |    454.79 ns |   2.008 ns |   1.878 ns |  7.38 |    0.08 |  0.0877 |       - |     - |     184 B |
|             ValueLinq_SharedPool_Pull_ByIndex |    10 |    336.08 ns |   0.944 ns |   0.837 ns |  5.45 |    0.07 |  0.0877 |       - |     - |     184 B |
|                ValueLinq_Ref_Standard_ByIndex |    10 |    207.27 ns |   0.587 ns |   0.490 ns |  3.36 |    0.04 |  0.0880 |       - |     - |     184 B |
|                   ValueLinq_Ref_Stack_ByIndex |    10 |    173.55 ns |   0.550 ns |   0.487 ns |  2.82 |    0.03 |  0.0880 |       - |     - |     184 B |
|         ValueLinq_Ref_SharedPool_Push_ByIndex |    10 |    370.36 ns |   0.838 ns |   0.700 ns |  6.01 |    0.06 |  0.0877 |       - |     - |     184 B |
|         ValueLinq_Ref_SharedPool_Pull_ByIndex |    10 |    320.70 ns |   0.546 ns |   0.456 ns |  5.20 |    0.06 |  0.0877 |       - |     - |     184 B |
|        ValueLinq_ValueLambda_Standard_ByIndex |    10 |    221.58 ns |   1.465 ns |   1.299 ns |  3.60 |    0.05 |  0.0880 |       - |     - |     184 B |
|           ValueLinq_ValueLambda_Stack_ByIndex |    10 |    189.59 ns |   0.748 ns |   0.700 ns |  3.08 |    0.03 |  0.0880 |       - |     - |     184 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |    10 |    364.62 ns |   1.060 ns |   0.940 ns |  5.92 |    0.06 |  0.0877 |       - |     - |     184 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |    10 |    340.02 ns |   1.472 ns |   1.377 ns |  5.52 |    0.06 |  0.0877 |       - |     - |     184 B |
|                                       ForLoop |    10 |     61.63 ns |   0.762 ns |   0.675 ns |  1.00 |    0.00 |  0.1491 |       - |     - |     312 B |
|                                   ForeachLoop |    10 |     96.70 ns |   0.727 ns |   0.680 ns |  1.57 |    0.02 |  0.1491 |       - |     - |     312 B |
|                                          Linq |    10 |    151.11 ns |   1.311 ns |   1.162 ns |  2.45 |    0.03 |  0.3290 |       - |     - |     688 B |
|                                    LinqFaster |    10 |    116.44 ns |   0.891 ns |   0.834 ns |  1.89 |    0.02 |  0.2370 |       - |     - |     496 B |
|                                        LinqAF |    10 |    307.45 ns |   5.838 ns |   5.995 ns |  4.98 |    0.12 |  0.1488 |       - |     - |     312 B |
|                                    StructLinq |    10 |    160.62 ns |   0.722 ns |   0.640 ns |  2.61 |    0.03 |  0.1376 |       - |     - |     288 B |
|                          StructLinq_IFunction |    10 |    127.99 ns |   0.608 ns |   0.508 ns |  2.08 |    0.03 |  0.0880 |       - |     - |     184 B |
|                                     Hyperlinq |    10 |    163.20 ns |   1.334 ns |   1.182 ns |  2.65 |    0.04 |  0.0880 |       - |     - |     184 B |
|                           Hyperlinq_IFunction |    10 |    135.33 ns |   0.865 ns |   0.767 ns |  2.20 |    0.03 |  0.0880 |       - |     - |     184 B |
|                                               |       |              |            |            |       |         |         |         |       |           |
|                            **ValueLinq_Standard** |  **1000** | **16,842.43 ns** | **238.536 ns** | **199.188 ns** |  **1.52** |    **0.02** | **31.2195** |       **-** |     **-** |  **65,504 B** |
|                               ValueLinq_Stack |  1000 | 17,660.60 ns | 167.835 ns | 148.781 ns |  1.59 |    0.01 | 30.2734 |       - |     - |  64,112 B |
|                     ValueLinq_SharedPool_Push |  1000 | 16,642.55 ns | 127.622 ns | 119.378 ns |  1.50 |    0.01 | 15.3809 |       - |     - |  32,248 B |
|                     ValueLinq_SharedPool_Pull |  1000 | 16,747.81 ns |  97.941 ns |  86.822 ns |  1.51 |    0.01 | 15.3809 |       - |     - |  32,248 B |
|                        ValueLinq_Ref_Standard |  1000 | 14,528.46 ns |  98.308 ns |  87.147 ns |  1.31 |    0.01 | 31.2347 |       - |     - |  65,504 B |
|                           ValueLinq_Ref_Stack |  1000 | 17,461.13 ns |  73.908 ns |  69.134 ns |  1.57 |    0.01 | 30.2734 |       - |     - |  64,112 B |
|                 ValueLinq_Ref_SharedPool_Push |  1000 | 14,717.32 ns |  95.295 ns |  84.477 ns |  1.33 |    0.01 | 15.3809 |       - |     - |  32,248 B |
|                 ValueLinq_Ref_SharedPool_Pull |  1000 | 16,947.57 ns |  72.374 ns |  67.698 ns |  1.53 |    0.01 | 15.3809 |       - |     - |  32,248 B |
|                ValueLinq_ValueLambda_Standard |  1000 | 13,818.52 ns |  61.685 ns |  57.700 ns |  1.24 |    0.01 | 31.2347 |       - |     - |  65,504 B |
|                   ValueLinq_ValueLambda_Stack |  1000 | 16,932.45 ns | 144.442 ns | 135.111 ns |  1.53 |    0.01 | 30.2734 |       - |     - |  64,112 B |
|         ValueLinq_ValueLambda_SharedPool_Push |  1000 | 13,768.97 ns |  70.091 ns |  65.564 ns |  1.24 |    0.01 | 15.3809 |       - |     - |  32,248 B |
|         ValueLinq_ValueLambda_SharedPool_Pull |  1000 | 15,725.08 ns | 161.053 ns | 142.769 ns |  1.42 |    0.02 | 15.3809 |       - |     - |  32,248 B |
|                    ValueLinq_Standard_ByIndex |  1000 | 16,837.60 ns | 119.168 ns | 105.639 ns |  1.52 |    0.01 | 31.2195 |       - |     - |  65,504 B |
|                       ValueLinq_Stack_ByIndex |  1000 | 15,801.39 ns | 123.239 ns | 109.248 ns |  1.42 |    0.01 | 30.2734 |       - |     - |  64,112 B |
|             ValueLinq_SharedPool_Push_ByIndex |  1000 | 16,532.52 ns | 130.171 ns | 121.762 ns |  1.49 |    0.01 | 15.3809 |       - |     - |  32,248 B |
|             ValueLinq_SharedPool_Pull_ByIndex |  1000 | 14,873.71 ns |  78.934 ns |  73.835 ns |  1.34 |    0.01 | 15.3809 |       - |     - |  32,248 B |
|                ValueLinq_Ref_Standard_ByIndex |  1000 | 14,755.94 ns |  71.959 ns |  67.311 ns |  1.33 |    0.01 | 31.2195 |       - |     - |  65,504 B |
|                   ValueLinq_Ref_Stack_ByIndex |  1000 | 13,918.52 ns |  74.404 ns |  65.957 ns |  1.25 |    0.01 | 30.2887 |       - |     - |  64,112 B |
|         ValueLinq_Ref_SharedPool_Push_ByIndex |  1000 | 14,591.59 ns |  94.856 ns |  84.088 ns |  1.31 |    0.01 | 15.3809 |       - |     - |  32,248 B |
|         ValueLinq_Ref_SharedPool_Pull_ByIndex |  1000 | 12,873.21 ns |  69.017 ns |  61.182 ns |  1.16 |    0.01 | 15.3809 |       - |     - |  32,248 B |
|        ValueLinq_ValueLambda_Standard_ByIndex |  1000 | 18,340.25 ns |  78.973 ns |  65.946 ns |  1.65 |    0.01 | 31.2195 |       - |     - |  65,504 B |
|           ValueLinq_ValueLambda_Stack_ByIndex |  1000 | 14,316.10 ns |  74.308 ns |  65.872 ns |  1.29 |    0.01 | 30.2887 |       - |     - |  64,112 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |  1000 | 14,162.48 ns |  93.165 ns |  87.147 ns |  1.28 |    0.01 | 15.3809 |       - |     - |  32,248 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |  1000 | 13,228.66 ns |  91.497 ns |  81.110 ns |  1.19 |    0.01 | 15.3809 |       - |     - |  32,248 B |
|                                       ForLoop |  1000 | 11,097.05 ns |  52.594 ns |  46.623 ns |  1.00 |    0.00 | 31.2347 |       - |     - |  65,504 B |
|                                   ForeachLoop |  1000 | 14,328.99 ns |  68.445 ns |  60.675 ns |  1.29 |    0.01 | 31.2347 |       - |     - |  65,504 B |
|                                          Linq |  1000 | 16,474.69 ns | 141.483 ns | 132.343 ns |  1.48 |    0.01 | 31.2195 |       - |     - |  65,880 B |
|                                    LinqFaster |  1000 | 19,713.98 ns |  65.451 ns |  54.654 ns |  1.78 |    0.01 | 44.4336 | 11.1084 |     - |  97,752 B |
|                                        LinqAF |  1000 | 29,525.25 ns | 260.460 ns | 243.634 ns |  2.66 |    0.02 | 31.2195 |       - |     - |  65,504 B |
|                                    StructLinq |  1000 | 14,720.46 ns |  80.270 ns |  71.157 ns |  1.33 |    0.01 | 15.3809 |       - |     - |  32,352 B |
|                          StructLinq_IFunction |  1000 | 11,223.15 ns |  40.013 ns |  37.428 ns |  1.01 |    0.01 | 15.3809 |       - |     - |  32,248 B |
|                                     Hyperlinq |  1000 | 15,514.38 ns | 184.075 ns | 172.184 ns |  1.40 |    0.02 | 15.3809 |       - |     - |  32,248 B |
|                           Hyperlinq_IFunction |  1000 | 10,932.49 ns |  64.625 ns |  57.289 ns |  0.99 |    0.01 | 15.3809 |       - |     - |  32,248 B |
