## List.ValueType.ListValueTypeWhereSelectToList

### Source
[ListValueTypeWhereSelectToList.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelectToList.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta39](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta39)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=6.0.100-preview.1.21103.13
  [Host]        : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                                        Method | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |   Gen 0 |   Gen 1 | Gen 2 | Allocated |
|---------------------------------------------- |------ |-------------:|-----------:|-----------:|------:|--------:|--------:|--------:|------:|----------:|
|                            **ValueLinq_Standard** |    **10** |    **260.21 ns** |   **0.853 ns** |   **0.756 ns** |  **4.26** |    **0.04** |  **0.0877** |       **-** |     **-** |     **184 B** |
|                               ValueLinq_Stack |    10 |    219.38 ns |   0.408 ns |   0.319 ns |  3.59 |    0.03 |  0.0880 |       - |     - |     184 B |
|                     ValueLinq_SharedPool_Push |    10 |    446.94 ns |   2.204 ns |   1.841 ns |  7.32 |    0.06 |  0.0877 |       - |     - |     184 B |
|                     ValueLinq_SharedPool_Pull |    10 |    354.70 ns |   1.355 ns |   1.201 ns |  5.81 |    0.06 |  0.0877 |       - |     - |     184 B |
|                        ValueLinq_Ref_Standard |    10 |    269.01 ns |   0.725 ns |   0.678 ns |  4.41 |    0.03 |  0.0877 |       - |     - |     184 B |
|                           ValueLinq_Ref_Stack |    10 |    230.75 ns |   0.735 ns |   0.651 ns |  3.78 |    0.04 |  0.0880 |       - |     - |     184 B |
|                 ValueLinq_Ref_SharedPool_Push |    10 |    353.44 ns |   0.924 ns |   0.772 ns |  5.79 |    0.05 |  0.0877 |       - |     - |     184 B |
|                 ValueLinq_Ref_SharedPool_Pull |    10 |    367.29 ns |   0.783 ns |   0.694 ns |  6.02 |    0.05 |  0.0877 |       - |     - |     184 B |
|                ValueLinq_ValueLambda_Standard |    10 |    289.85 ns |   2.097 ns |   1.859 ns |  4.75 |    0.05 |  0.0877 |       - |     - |     184 B |
|                   ValueLinq_ValueLambda_Stack |    10 |    251.20 ns |   1.880 ns |   1.667 ns |  4.12 |    0.04 |  0.0877 |       - |     - |     184 B |
|         ValueLinq_ValueLambda_SharedPool_Push |    10 |    352.73 ns |   0.858 ns |   0.760 ns |  5.78 |    0.05 |  0.0877 |       - |     - |     184 B |
|         ValueLinq_ValueLambda_SharedPool_Pull |    10 |    393.53 ns |   1.556 ns |   1.455 ns |  6.45 |    0.06 |  0.0877 |       - |     - |     184 B |
|                    ValueLinq_Standard_ByIndex |    10 |    224.40 ns |   1.206 ns |   1.069 ns |  3.68 |    0.04 |  0.0880 |       - |     - |     184 B |
|                       ValueLinq_Stack_ByIndex |    10 |    183.75 ns |   1.661 ns |   1.472 ns |  3.01 |    0.04 |  0.0877 |       - |     - |     184 B |
|             ValueLinq_SharedPool_Push_ByIndex |    10 |    447.86 ns |   1.698 ns |   1.505 ns |  7.34 |    0.07 |  0.0877 |       - |     - |     184 B |
|             ValueLinq_SharedPool_Pull_ByIndex |    10 |    324.39 ns |   1.454 ns |   1.135 ns |  5.31 |    0.04 |  0.0877 |       - |     - |     184 B |
|                ValueLinq_Ref_Standard_ByIndex |    10 |    204.73 ns |   0.938 ns |   0.831 ns |  3.35 |    0.03 |  0.0880 |       - |     - |     184 B |
|                   ValueLinq_Ref_Stack_ByIndex |    10 |    167.87 ns |   0.520 ns |   0.434 ns |  2.75 |    0.02 |  0.0880 |       - |     - |     184 B |
|         ValueLinq_Ref_SharedPool_Push_ByIndex |    10 |    377.33 ns |   1.092 ns |   0.968 ns |  6.18 |    0.06 |  0.0877 |       - |     - |     184 B |
|         ValueLinq_Ref_SharedPool_Pull_ByIndex |    10 |    312.96 ns |   0.872 ns |   0.816 ns |  5.13 |    0.05 |  0.0877 |       - |     - |     184 B |
|        ValueLinq_ValueLambda_Standard_ByIndex |    10 |    220.85 ns |   0.935 ns |   0.829 ns |  3.62 |    0.04 |  0.0880 |       - |     - |     184 B |
|           ValueLinq_ValueLambda_Stack_ByIndex |    10 |    221.24 ns |   1.088 ns |   0.964 ns |  3.63 |    0.03 |  0.0880 |       - |     - |     184 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |    10 |    361.84 ns |   0.997 ns |   0.833 ns |  5.93 |    0.05 |  0.0877 |       - |     - |     184 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |    10 |    316.17 ns |   1.192 ns |   1.057 ns |  5.18 |    0.05 |  0.0877 |       - |     - |     184 B |
|                                       ForLoop |    10 |     61.03 ns |   0.597 ns |   0.529 ns |  1.00 |    0.00 |  0.1491 |       - |     - |     312 B |
|                                   ForeachLoop |    10 |     92.35 ns |   0.719 ns |   0.637 ns |  1.51 |    0.02 |  0.1491 |       - |     - |     312 B |
|                                          Linq |    10 |    148.00 ns |   0.929 ns |   0.869 ns |  2.43 |    0.03 |  0.3290 |       - |     - |     688 B |
|                                    LinqFaster |    10 |    116.47 ns |   1.013 ns |   0.948 ns |  1.91 |    0.02 |  0.2370 |       - |     - |     496 B |
|                                        LinqAF |    10 |    302.04 ns |   5.972 ns |   5.865 ns |  4.96 |    0.11 |  0.1488 |       - |     - |     312 B |
|                                    StructLinq |    10 |    157.16 ns |   0.426 ns |   0.377 ns |  2.58 |    0.02 |  0.1376 |       - |     - |     288 B |
|                          StructLinq_IFunction |    10 |    126.35 ns |   0.556 ns |   0.520 ns |  2.07 |    0.02 |  0.0880 |       - |     - |     184 B |
|                                     Hyperlinq |    10 |    132.34 ns |   0.613 ns |   0.574 ns |  2.17 |    0.02 |  0.0880 |       - |     - |     184 B |
|                           Hyperlinq_IFunction |    10 |    105.98 ns |   0.354 ns |   0.276 ns |  1.73 |    0.02 |  0.0880 |       - |     - |     184 B |
|                                               |       |              |            |            |       |         |         |         |       |           |
|                            **ValueLinq_Standard** |  **1000** | **16,860.72 ns** | **234.810 ns** | **208.153 ns** |  **1.50** |    **0.02** | **31.2195** |       **-** |     **-** |   **65504 B** |
|                               ValueLinq_Stack |  1000 | 17,485.68 ns | 161.855 ns | 143.480 ns |  1.56 |    0.02 | 30.2734 |       - |     - |   64112 B |
|                     ValueLinq_SharedPool_Push |  1000 | 16,622.71 ns | 196.809 ns | 184.095 ns |  1.48 |    0.02 | 15.3809 |       - |     - |   32248 B |
|                     ValueLinq_SharedPool_Pull |  1000 | 17,389.84 ns | 196.826 ns | 184.111 ns |  1.55 |    0.02 | 15.3809 |       - |     - |   32248 B |
|                        ValueLinq_Ref_Standard |  1000 | 14,475.49 ns |  82.987 ns |  77.626 ns |  1.29 |    0.01 | 31.2347 |       - |     - |   65504 B |
|                           ValueLinq_Ref_Stack |  1000 | 17,386.65 ns | 111.615 ns |  87.142 ns |  1.55 |    0.02 | 30.2734 |       - |     - |   64112 B |
|                 ValueLinq_Ref_SharedPool_Push |  1000 | 14,379.32 ns |  91.723 ns |  81.310 ns |  1.28 |    0.01 | 15.3809 |       - |     - |   32248 B |
|                 ValueLinq_Ref_SharedPool_Pull |  1000 | 16,851.22 ns |  64.649 ns |  53.985 ns |  1.50 |    0.01 | 15.3809 |       - |     - |   32248 B |
|                ValueLinq_ValueLambda_Standard |  1000 | 14,059.23 ns | 180.456 ns | 150.689 ns |  1.25 |    0.02 | 31.2347 |       - |     - |   65504 B |
|                   ValueLinq_ValueLambda_Stack |  1000 | 17,550.37 ns | 221.236 ns | 206.944 ns |  1.56 |    0.02 | 30.2734 |       - |     - |   64112 B |
|         ValueLinq_ValueLambda_SharedPool_Push |  1000 | 13,899.75 ns |  89.431 ns |  79.278 ns |  1.24 |    0.01 | 15.3809 |       - |     - |   32248 B |
|         ValueLinq_ValueLambda_SharedPool_Pull |  1000 | 16,516.57 ns | 170.113 ns | 159.123 ns |  1.47 |    0.01 | 15.3809 |       - |     - |   32248 B |
|                    ValueLinq_Standard_ByIndex |  1000 | 16,493.14 ns | 180.322 ns | 168.674 ns |  1.47 |    0.02 | 31.2195 |       - |     - |   65504 B |
|                       ValueLinq_Stack_ByIndex |  1000 | 16,386.13 ns |  86.492 ns |  76.673 ns |  1.46 |    0.01 | 30.2734 |       - |     - |   64112 B |
|             ValueLinq_SharedPool_Push_ByIndex |  1000 | 16,982.06 ns | 161.602 ns | 143.256 ns |  1.51 |    0.02 | 15.3809 |       - |     - |   32248 B |
|             ValueLinq_SharedPool_Pull_ByIndex |  1000 | 15,602.59 ns |  52.506 ns |  46.545 ns |  1.39 |    0.01 | 15.3809 |       - |     - |   32248 B |
|                ValueLinq_Ref_Standard_ByIndex |  1000 | 14,669.24 ns |  64.133 ns |  56.852 ns |  1.31 |    0.01 | 31.2347 |       - |     - |   65504 B |
|                   ValueLinq_Ref_Stack_ByIndex |  1000 | 13,629.45 ns |  76.437 ns |  59.677 ns |  1.21 |    0.01 | 30.2887 |       - |     - |   64112 B |
|         ValueLinq_Ref_SharedPool_Push_ByIndex |  1000 | 14,618.22 ns |  80.703 ns |  71.541 ns |  1.30 |    0.01 | 15.3809 |       - |     - |   32248 B |
|         ValueLinq_Ref_SharedPool_Pull_ByIndex |  1000 | 13,060.66 ns |  83.831 ns |  70.003 ns |  1.16 |    0.01 | 15.3809 |       - |     - |   32248 B |
|        ValueLinq_ValueLambda_Standard_ByIndex |  1000 | 13,784.41 ns | 116.432 ns | 103.214 ns |  1.23 |    0.01 | 31.2347 |       - |     - |   65504 B |
|           ValueLinq_ValueLambda_Stack_ByIndex |  1000 | 22,891.39 ns | 255.805 ns | 226.765 ns |  2.04 |    0.02 | 30.2887 |       - |     - |   64112 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |  1000 | 13,984.25 ns |  93.220 ns |  82.637 ns |  1.25 |    0.01 | 15.3809 |       - |     - |   32248 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |  1000 | 12,989.25 ns | 125.415 ns | 117.313 ns |  1.16 |    0.01 | 15.3809 |       - |     - |   32248 B |
|                                       ForLoop |  1000 | 11,227.09 ns |  73.790 ns |  65.413 ns |  1.00 |    0.00 | 31.2347 |       - |     - |   65504 B |
|                                   ForeachLoop |  1000 | 14,113.33 ns |  59.391 ns |  52.649 ns |  1.26 |    0.01 | 31.2347 |       - |     - |   65504 B |
|                                          Linq |  1000 | 15,119.64 ns |  98.161 ns |  81.969 ns |  1.35 |    0.01 | 31.2347 |       - |     - |   65880 B |
|                                    LinqFaster |  1000 | 19,120.10 ns | 220.205 ns | 205.980 ns |  1.70 |    0.02 | 44.4336 | 11.1084 |     - |   97752 B |
|                                        LinqAF |  1000 | 30,085.60 ns | 538.100 ns | 477.011 ns |  2.68 |    0.05 | 31.2195 |       - |     - |   65504 B |
|                                    StructLinq |  1000 | 14,603.56 ns |  61.633 ns |  54.636 ns |  1.30 |    0.01 | 15.3809 |       - |     - |   32352 B |
|                          StructLinq_IFunction |  1000 | 10,312.18 ns |  53.704 ns |  47.607 ns |  0.92 |    0.01 | 15.3809 |       - |     - |   32248 B |
|                                     Hyperlinq |  1000 | 10,503.98 ns |  60.874 ns |  56.942 ns |  0.94 |    0.01 | 15.3809 |       - |     - |   32248 B |
|                           Hyperlinq_IFunction |  1000 |  8,306.00 ns |  66.954 ns |  59.353 ns |  0.74 |    0.01 | 15.3809 |       - |     - |   32248 B |
