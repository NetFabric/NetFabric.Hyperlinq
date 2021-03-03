## List.ValueType.ListValueTypeWhereSelectToList

### Source
[ListValueTypeWhereSelectToList.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelectToList.cs)

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
|                                        Method | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |   Gen 0 |   Gen 1 | Gen 2 | Allocated |
|---------------------------------------------- |------ |-------------:|-----------:|-----------:|------:|--------:|--------:|--------:|------:|----------:|
|                            **ValueLinq_Standard** |    **10** |    **261.60 ns** |   **0.944 ns** |   **0.788 ns** |  **4.30** |    **0.04** |  **0.0877** |       **-** |     **-** |     **184 B** |
|                               ValueLinq_Stack |    10 |    220.54 ns |   4.405 ns |   4.326 ns |  3.63 |    0.10 |  0.0880 |       - |     - |     184 B |
|                     ValueLinq_SharedPool_Push |    10 |    441.90 ns |   1.794 ns |   1.678 ns |  7.27 |    0.07 |  0.0877 |       - |     - |     184 B |
|                     ValueLinq_SharedPool_Pull |    10 |    357.69 ns |   0.754 ns |   0.630 ns |  5.88 |    0.05 |  0.0877 |       - |     - |     184 B |
|                        ValueLinq_Ref_Standard |    10 |    272.73 ns |   1.155 ns |   1.081 ns |  4.49 |    0.04 |  0.0877 |       - |     - |     184 B |
|                           ValueLinq_Ref_Stack |    10 |    231.63 ns |   0.821 ns |   0.685 ns |  3.81 |    0.04 |  0.0880 |       - |     - |     184 B |
|                 ValueLinq_Ref_SharedPool_Push |    10 |    351.93 ns |   1.778 ns |   1.576 ns |  5.79 |    0.07 |  0.0877 |       - |     - |     184 B |
|                 ValueLinq_Ref_SharedPool_Pull |    10 |    369.89 ns |   0.682 ns |   0.605 ns |  6.09 |    0.06 |  0.0877 |       - |     - |     184 B |
|                ValueLinq_ValueLambda_Standard |    10 |    284.10 ns |   1.257 ns |   1.176 ns |  4.67 |    0.05 |  0.0877 |       - |     - |     184 B |
|                   ValueLinq_ValueLambda_Stack |    10 |    243.64 ns |   2.783 ns |   2.603 ns |  4.00 |    0.06 |  0.0877 |       - |     - |     184 B |
|         ValueLinq_ValueLambda_SharedPool_Push |    10 |    354.71 ns |   0.658 ns |   0.583 ns |  5.84 |    0.06 |  0.0877 |       - |     - |     184 B |
|         ValueLinq_ValueLambda_SharedPool_Pull |    10 |    381.16 ns |   3.728 ns |   3.487 ns |  6.28 |    0.08 |  0.0877 |       - |     - |     184 B |
|                    ValueLinq_Standard_ByIndex |    10 |    224.27 ns |   2.074 ns |   1.619 ns |  3.69 |    0.04 |  0.0877 |       - |     - |     184 B |
|                       ValueLinq_Stack_ByIndex |    10 |    188.18 ns |   1.074 ns |   0.952 ns |  3.10 |    0.02 |  0.0880 |       - |     - |     184 B |
|             ValueLinq_SharedPool_Push_ByIndex |    10 |    454.90 ns |   1.614 ns |   1.431 ns |  7.48 |    0.08 |  0.0877 |       - |     - |     184 B |
|             ValueLinq_SharedPool_Pull_ByIndex |    10 |    323.49 ns |   1.414 ns |   1.253 ns |  5.32 |    0.06 |  0.0877 |       - |     - |     184 B |
|                ValueLinq_Ref_Standard_ByIndex |    10 |    206.11 ns |   0.799 ns |   0.747 ns |  3.39 |    0.03 |  0.0880 |       - |     - |     184 B |
|                   ValueLinq_Ref_Stack_ByIndex |    10 |    168.91 ns |   0.726 ns |   0.644 ns |  2.78 |    0.03 |  0.0880 |       - |     - |     184 B |
|         ValueLinq_Ref_SharedPool_Push_ByIndex |    10 |    379.78 ns |   1.386 ns |   1.082 ns |  6.24 |    0.06 |  0.0877 |       - |     - |     184 B |
|         ValueLinq_Ref_SharedPool_Pull_ByIndex |    10 |    307.90 ns |   1.395 ns |   1.236 ns |  5.07 |    0.05 |  0.0877 |       - |     - |     184 B |
|        ValueLinq_ValueLambda_Standard_ByIndex |    10 |    223.47 ns |   0.911 ns |   0.852 ns |  3.68 |    0.03 |  0.0880 |       - |     - |     184 B |
|           ValueLinq_ValueLambda_Stack_ByIndex |    10 |    184.85 ns |   1.105 ns |   0.979 ns |  3.04 |    0.03 |  0.0880 |       - |     - |     184 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |    10 |    371.92 ns |   0.717 ns |   0.636 ns |  6.12 |    0.05 |  0.0877 |       - |     - |     184 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |    10 |    325.48 ns |   1.025 ns |   0.909 ns |  5.35 |    0.05 |  0.0877 |       - |     - |     184 B |
|                                       ForLoop |    10 |     60.79 ns |   0.628 ns |   0.557 ns |  1.00 |    0.00 |  0.1491 |       - |     - |     312 B |
|                                   ForeachLoop |    10 |     93.85 ns |   0.468 ns |   0.414 ns |  1.54 |    0.01 |  0.1491 |       - |     - |     312 B |
|                                          Linq |    10 |    151.60 ns |   1.533 ns |   1.434 ns |  2.49 |    0.03 |  0.3290 |       - |     - |     688 B |
|                                    LinqFaster |    10 |    116.67 ns |   1.125 ns |   0.997 ns |  1.92 |    0.02 |  0.2370 |       - |     - |     496 B |
|                                        LinqAF |    10 |    298.08 ns |   5.773 ns |   6.178 ns |  4.93 |    0.10 |  0.1488 |       - |     - |     312 B |
|                                    StructLinq |    10 |    159.81 ns |   0.412 ns |   0.366 ns |  2.63 |    0.03 |  0.1376 |       - |     - |     288 B |
|                          StructLinq_IFunction |    10 |    127.49 ns |   0.488 ns |   0.457 ns |  2.10 |    0.02 |  0.0880 |       - |     - |     184 B |
|                                     Hyperlinq |    10 |    161.66 ns |   1.378 ns |   1.076 ns |  2.66 |    0.03 |  0.0880 |       - |     - |     184 B |
|                           Hyperlinq_IFunction |    10 |    140.40 ns |   0.538 ns |   0.503 ns |  2.31 |    0.03 |  0.0880 |       - |     - |     184 B |
|                                               |       |              |            |            |       |         |         |         |       |           |
|                            **ValueLinq_Standard** |  **1000** | **16,649.60 ns** | **130.956 ns** | **122.496 ns** |  **1.49** |    **0.01** | **31.2195** |       **-** |     **-** |  **65,504 B** |
|                               ValueLinq_Stack |  1000 | 17,608.43 ns | 150.911 ns | 133.779 ns |  1.58 |    0.01 | 30.2734 |       - |     - |  64,112 B |
|                     ValueLinq_SharedPool_Push |  1000 | 16,745.62 ns | 156.941 ns | 146.803 ns |  1.50 |    0.01 | 15.3809 |       - |     - |  32,248 B |
|                     ValueLinq_SharedPool_Pull |  1000 | 16,650.22 ns | 135.827 ns | 127.053 ns |  1.49 |    0.01 | 15.3809 |       - |     - |  32,248 B |
|                        ValueLinq_Ref_Standard |  1000 | 14,541.87 ns | 136.234 ns | 113.761 ns |  1.30 |    0.01 | 31.2347 |       - |     - |  65,504 B |
|                           ValueLinq_Ref_Stack |  1000 | 20,193.15 ns |  84.134 ns |  74.583 ns |  1.81 |    0.01 | 30.2734 |       - |     - |  64,112 B |
|                 ValueLinq_Ref_SharedPool_Push |  1000 | 14,262.88 ns | 101.002 ns |  89.536 ns |  1.28 |    0.01 | 15.3809 |       - |     - |  32,248 B |
|                 ValueLinq_Ref_SharedPool_Pull |  1000 | 16,692.15 ns |  58.131 ns |  51.532 ns |  1.49 |    0.01 | 15.3809 |       - |     - |  32,248 B |
|                ValueLinq_ValueLambda_Standard |  1000 | 13,798.13 ns | 201.579 ns | 188.557 ns |  1.23 |    0.01 | 31.2347 |       - |     - |  65,504 B |
|                   ValueLinq_ValueLambda_Stack |  1000 | 17,457.74 ns | 187.114 ns | 165.872 ns |  1.56 |    0.02 | 30.2734 |       - |     - |  64,112 B |
|         ValueLinq_ValueLambda_SharedPool_Push |  1000 | 13,837.58 ns | 140.378 ns | 124.441 ns |  1.24 |    0.01 | 15.3809 |       - |     - |  32,248 B |
|         ValueLinq_ValueLambda_SharedPool_Pull |  1000 | 15,934.01 ns | 173.707 ns | 153.987 ns |  1.43 |    0.02 | 15.3809 |       - |     - |  32,248 B |
|                    ValueLinq_Standard_ByIndex |  1000 | 16,555.87 ns | 132.379 ns | 110.543 ns |  1.48 |    0.02 | 31.2195 |       - |     - |  65,504 B |
|                       ValueLinq_Stack_ByIndex |  1000 | 15,915.82 ns | 132.531 ns | 117.486 ns |  1.42 |    0.01 | 30.2734 |       - |     - |  64,112 B |
|             ValueLinq_SharedPool_Push_ByIndex |  1000 | 16,327.24 ns | 260.234 ns | 243.423 ns |  1.46 |    0.02 | 15.3809 |       - |     - |  32,248 B |
|             ValueLinq_SharedPool_Pull_ByIndex |  1000 | 16,163.56 ns | 123.239 ns | 115.278 ns |  1.45 |    0.01 | 15.3809 |       - |     - |  32,248 B |
|                ValueLinq_Ref_Standard_ByIndex |  1000 | 14,354.06 ns |  81.148 ns |  71.935 ns |  1.28 |    0.01 | 31.2347 |       - |     - |  65,504 B |
|                   ValueLinq_Ref_Stack_ByIndex |  1000 | 13,487.04 ns |  88.302 ns |  82.598 ns |  1.21 |    0.01 | 30.2887 |       - |     - |  64,112 B |
|         ValueLinq_Ref_SharedPool_Push_ByIndex |  1000 | 14,669.64 ns |  82.444 ns |  73.085 ns |  1.31 |    0.01 | 15.3809 |       - |     - |  32,248 B |
|         ValueLinq_Ref_SharedPool_Pull_ByIndex |  1000 | 12,660.67 ns |  64.941 ns |  57.568 ns |  1.13 |    0.01 | 15.3809 |       - |     - |  32,248 B |
|        ValueLinq_ValueLambda_Standard_ByIndex |  1000 | 13,874.13 ns | 132.530 ns | 123.969 ns |  1.24 |    0.01 | 31.2347 |       - |     - |  65,504 B |
|           ValueLinq_ValueLambda_Stack_ByIndex |  1000 | 14,386.59 ns |  74.694 ns |  69.869 ns |  1.29 |    0.01 | 30.2887 |       - |     - |  64,112 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |  1000 | 13,942.59 ns | 119.158 ns | 111.461 ns |  1.25 |    0.01 | 15.3809 |       - |     - |  32,248 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |  1000 | 13,147.84 ns | 124.672 ns | 110.519 ns |  1.18 |    0.01 | 15.3809 |       - |     - |  32,248 B |
|                                       ForLoop |  1000 | 11,180.06 ns |  79.545 ns |  70.515 ns |  1.00 |    0.00 | 31.2347 |       - |     - |  65,504 B |
|                                   ForeachLoop |  1000 | 14,450.84 ns |  53.057 ns |  47.034 ns |  1.29 |    0.01 | 31.2347 |       - |     - |  65,504 B |
|                                          Linq |  1000 | 15,516.78 ns | 139.242 ns | 130.247 ns |  1.39 |    0.01 | 31.2195 |       - |     - |  65,880 B |
|                                    LinqFaster |  1000 | 19,250.73 ns | 163.191 ns | 152.649 ns |  1.72 |    0.02 | 44.4336 | 11.1084 |     - |  97,752 B |
|                                        LinqAF |  1000 | 30,009.43 ns | 485.944 ns | 454.552 ns |  2.69 |    0.05 | 31.2195 |       - |     - |  65,504 B |
|                                    StructLinq |  1000 | 14,326.99 ns |  75.413 ns |  66.852 ns |  1.28 |    0.01 | 15.3809 |       - |     - |  32,352 B |
|                          StructLinq_IFunction |  1000 | 10,161.48 ns |  49.295 ns |  41.164 ns |  0.91 |    0.01 | 15.3809 |       - |     - |  32,248 B |
|                                     Hyperlinq |  1000 | 16,061.23 ns | 153.348 ns | 135.939 ns |  1.44 |    0.02 | 15.3809 |       - |     - |  32,248 B |
|                           Hyperlinq_IFunction |  1000 | 11,234.77 ns |  60.911 ns |  53.996 ns |  1.00 |    0.01 | 15.3809 |       - |     - |  32,248 B |
