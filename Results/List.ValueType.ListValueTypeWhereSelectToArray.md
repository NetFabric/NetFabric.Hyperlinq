## List.ValueType.ListValueTypeWhereSelectToArray

### Source
[ListValueTypeWhereSelectToArray.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelectToArray.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta43](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta43)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1516-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.1.21103.13
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|                                        Method | Count |         Mean |      Error |     StdDev |       Median | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------------------------- |------ |-------------:|-----------:|-----------:|-------------:|------:|--------:|--------:|------:|------:|----------:|
|                            **ValueLinq_Standard** |    **10** |    **241.92 ns** |   **0.966 ns** |   **0.857 ns** |    **241.94 ns** |  **3.02** |    **0.02** |  **0.0725** |     **-** |     **-** |     **152 B** |
|                               ValueLinq_Stack |    10 |    207.04 ns |   1.245 ns |   1.103 ns |    207.14 ns |  2.59 |    0.02 |  0.0725 |     - |     - |     152 B |
|                     ValueLinq_SharedPool_Push |    10 |    444.64 ns |   1.504 ns |   1.407 ns |    444.06 ns |  5.56 |    0.03 |  0.0725 |     - |     - |     152 B |
|                     ValueLinq_SharedPool_Pull |    10 |    366.89 ns |   1.216 ns |   1.078 ns |    367.06 ns |  4.58 |    0.02 |  0.0725 |     - |     - |     152 B |
|                        ValueLinq_Ref_Standard |    10 |    256.70 ns |   1.444 ns |   1.280 ns |    256.34 ns |  3.21 |    0.02 |  0.0725 |     - |     - |     152 B |
|                           ValueLinq_Ref_Stack |    10 |    212.46 ns |   0.426 ns |   0.378 ns |    212.49 ns |  2.65 |    0.01 |  0.0725 |     - |     - |     152 B |
|                 ValueLinq_Ref_SharedPool_Push |    10 |    368.41 ns |   2.300 ns |   2.039 ns |    367.94 ns |  4.60 |    0.03 |  0.0725 |     - |     - |     152 B |
|                 ValueLinq_Ref_SharedPool_Pull |    10 |    388.72 ns |   1.781 ns |   1.666 ns |    388.28 ns |  4.86 |    0.02 |  0.0725 |     - |     - |     152 B |
|                ValueLinq_ValueLambda_Standard |    10 |    265.14 ns |   2.398 ns |   2.243 ns |    265.51 ns |  3.31 |    0.04 |  0.0725 |     - |     - |     152 B |
|                   ValueLinq_ValueLambda_Stack |    10 |    229.36 ns |   1.866 ns |   1.654 ns |    228.77 ns |  2.87 |    0.03 |  0.0725 |     - |     - |     152 B |
|         ValueLinq_ValueLambda_SharedPool_Push |    10 |    357.62 ns |   1.601 ns |   1.498 ns |    357.69 ns |  4.47 |    0.03 |  0.0725 |     - |     - |     152 B |
|         ValueLinq_ValueLambda_SharedPool_Pull |    10 |    392.87 ns |   1.156 ns |   1.025 ns |    392.87 ns |  4.91 |    0.02 |  0.0725 |     - |     - |     152 B |
|                    ValueLinq_Standard_ByIndex |    10 |    205.97 ns |   0.982 ns |   0.918 ns |    205.99 ns |  2.57 |    0.01 |  0.0725 |     - |     - |     152 B |
|                       ValueLinq_Stack_ByIndex |    10 |    241.33 ns |   0.763 ns |   0.714 ns |    241.23 ns |  3.02 |    0.01 |  0.0725 |     - |     - |     152 B |
|             ValueLinq_SharedPool_Push_ByIndex |    10 |    466.87 ns |   1.658 ns |   1.384 ns |    466.83 ns |  5.83 |    0.03 |  0.0725 |     - |     - |     152 B |
|             ValueLinq_SharedPool_Pull_ByIndex |    10 |    340.85 ns |   1.776 ns |   1.574 ns |    340.52 ns |  4.26 |    0.03 |  0.0725 |     - |     - |     152 B |
|                ValueLinq_Ref_Standard_ByIndex |    10 |    189.29 ns |   0.618 ns |   0.548 ns |    189.10 ns |  2.37 |    0.01 |  0.0725 |     - |     - |     152 B |
|                   ValueLinq_Ref_Stack_ByIndex |    10 |    153.01 ns |   0.441 ns |   0.344 ns |    152.97 ns |  1.91 |    0.01 |  0.0725 |     - |     - |     152 B |
|         ValueLinq_Ref_SharedPool_Push_ByIndex |    10 |    376.55 ns |   1.922 ns |   1.704 ns |    376.78 ns |  4.71 |    0.03 |  0.0725 |     - |     - |     152 B |
|         ValueLinq_Ref_SharedPool_Pull_ByIndex |    10 |    313.85 ns |   0.640 ns |   0.599 ns |    313.94 ns |  3.92 |    0.01 |  0.0725 |     - |     - |     152 B |
|        ValueLinq_ValueLambda_Standard_ByIndex |    10 |    203.03 ns |   0.750 ns |   0.627 ns |    202.92 ns |  2.54 |    0.01 |  0.0725 |     - |     - |     152 B |
|           ValueLinq_ValueLambda_Stack_ByIndex |    10 |    175.88 ns |   0.805 ns |   0.753 ns |    175.78 ns |  2.19 |    0.01 |  0.0725 |     - |     - |     152 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |    10 |    378.44 ns |   0.806 ns |   0.673 ns |    378.13 ns |  4.73 |    0.02 |  0.0725 |     - |     - |     152 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |    10 |    332.65 ns |   1.303 ns |   1.155 ns |    332.67 ns |  4.16 |    0.01 |  0.0725 |     - |     - |     152 B |
|                                       ForLoop |    10 |     80.03 ns |   0.374 ns |   0.292 ns |     79.97 ns |  1.00 |    0.00 |  0.2218 |     - |     - |     464 B |
|                                   ForeachLoop |    10 |    115.01 ns |   1.064 ns |   0.943 ns |    115.02 ns |  1.44 |    0.01 |  0.2217 |     - |     - |     464 B |
|                                          Linq |    10 |    187.33 ns |   0.937 ns |   0.830 ns |    187.23 ns |  2.34 |    0.01 |  0.3860 |     - |     - |     808 B |
|                                    LinqFaster |    10 |    109.92 ns |   0.932 ns |   0.778 ns |    110.04 ns |  1.37 |    0.01 |  0.2218 |     - |     - |     464 B |
|                                        LinqAF |    10 |    320.20 ns |   5.463 ns |   4.843 ns |    320.75 ns |  4.00 |    0.06 |  0.2065 |     - |     - |     432 B |
|                                    StructLinq |    10 |    154.59 ns |   0.979 ns |   0.764 ns |    154.36 ns |  1.93 |    0.01 |  0.1223 |     - |     - |     256 B |
|                          StructLinq_IFunction |    10 |    121.61 ns |   0.616 ns |   0.515 ns |    121.42 ns |  1.52 |    0.01 |  0.0725 |     - |     - |     152 B |
|                                     Hyperlinq |    10 |    159.48 ns |   1.467 ns |   1.372 ns |    159.14 ns |  1.99 |    0.02 |  0.0725 |     - |     - |     152 B |
|                           Hyperlinq_IFunction |    10 |    135.70 ns |   1.260 ns |   1.179 ns |    135.85 ns |  1.70 |    0.02 |  0.0725 |     - |     - |     152 B |
|                                               |       |              |            |            |              |       |         |         |       |       |           |
|                            **ValueLinq_Standard** |  **1000** | **19,372.54 ns** | **386.137 ns** | **902.582 ns** | **18,943.12 ns** |  **1.40** |    **0.08** | **30.2734** |     **-** |     **-** |  **64,080 B** |
|                               ValueLinq_Stack |  1000 | 19,083.04 ns | 130.502 ns | 108.975 ns | 19,091.22 ns |  1.38 |    0.01 | 30.2734 |     - |     - |  64,080 B |
|                     ValueLinq_SharedPool_Push |  1000 | 17,475.07 ns |  75.192 ns |  70.334 ns | 17,496.69 ns |  1.26 |    0.01 | 15.1367 |     - |     - |  32,216 B |
|                     ValueLinq_SharedPool_Pull |  1000 | 17,732.45 ns | 106.066 ns |  99.214 ns | 17,738.54 ns |  1.28 |    0.01 | 15.1367 |     - |     - |  32,216 B |
|                        ValueLinq_Ref_Standard |  1000 | 18,024.42 ns |  65.224 ns |  61.010 ns | 18,022.28 ns |  1.30 |    0.01 | 30.2734 |     - |     - |  64,080 B |
|                           ValueLinq_Ref_Stack |  1000 | 17,967.11 ns | 121.723 ns | 113.860 ns | 17,923.48 ns |  1.30 |    0.01 | 30.2734 |     - |     - |  64,080 B |
|                 ValueLinq_Ref_SharedPool_Push |  1000 | 14,894.91 ns |  87.874 ns |  73.379 ns | 14,885.73 ns |  1.08 |    0.01 | 15.1367 |     - |     - |  32,216 B |
|                 ValueLinq_Ref_SharedPool_Pull |  1000 | 17,273.93 ns |  92.887 ns |  77.564 ns | 17,244.91 ns |  1.25 |    0.01 | 15.1367 |     - |     - |  32,216 B |
|                ValueLinq_ValueLambda_Standard |  1000 | 16,783.28 ns | 159.496 ns | 149.193 ns | 16,775.78 ns |  1.21 |    0.02 | 30.2734 |     - |     - |  64,080 B |
|                   ValueLinq_ValueLambda_Stack |  1000 | 18,109.83 ns | 102.378 ns |  95.764 ns | 18,119.24 ns |  1.31 |    0.01 | 30.2734 |     - |     - |  64,080 B |
|         ValueLinq_ValueLambda_SharedPool_Push |  1000 | 14,230.07 ns |  45.317 ns |  40.173 ns | 14,222.45 ns |  1.03 |    0.01 | 15.1367 |     - |     - |  32,216 B |
|         ValueLinq_ValueLambda_SharedPool_Pull |  1000 | 16,377.56 ns | 227.731 ns | 213.020 ns | 16,374.50 ns |  1.18 |    0.01 | 15.1367 |     - |     - |  32,216 B |
|                    ValueLinq_Standard_ByIndex |  1000 | 17,053.94 ns |  91.962 ns |  86.021 ns | 17,059.41 ns |  1.23 |    0.01 | 30.2734 |     - |     - |  64,080 B |
|                       ValueLinq_Stack_ByIndex |  1000 | 16,325.07 ns |  62.021 ns |  51.790 ns | 16,341.49 ns |  1.18 |    0.01 | 30.2734 |     - |     - |  64,080 B |
|             ValueLinq_SharedPool_Push_ByIndex |  1000 | 17,450.32 ns | 104.780 ns |  92.885 ns | 17,464.30 ns |  1.26 |    0.01 | 15.1367 |     - |     - |  32,216 B |
|             ValueLinq_SharedPool_Pull_ByIndex |  1000 | 15,527.12 ns | 106.908 ns | 100.002 ns | 15,526.03 ns |  1.12 |    0.01 | 15.1367 |     - |     - |  32,216 B |
|                ValueLinq_Ref_Standard_ByIndex |  1000 | 14,700.68 ns |  65.578 ns |  54.761 ns | 14,697.81 ns |  1.06 |    0.01 | 30.2887 |     - |     - |  64,080 B |
|                   ValueLinq_Ref_Stack_ByIndex |  1000 | 14,005.61 ns |  61.743 ns |  54.733 ns | 13,998.64 ns |  1.01 |    0.01 | 30.2887 |     - |     - |  64,080 B |
|         ValueLinq_Ref_SharedPool_Push_ByIndex |  1000 | 15,146.99 ns |  58.341 ns |  51.718 ns | 15,122.79 ns |  1.09 |    0.01 | 15.1367 |     - |     - |  32,216 B |
|         ValueLinq_Ref_SharedPool_Pull_ByIndex |  1000 | 13,630.64 ns |  70.358 ns |  62.370 ns | 13,637.58 ns |  0.98 |    0.01 | 15.1367 |     - |     - |  32,216 B |
|        ValueLinq_ValueLambda_Standard_ByIndex |  1000 | 14,656.98 ns |  92.016 ns |  86.072 ns | 14,631.59 ns |  1.06 |    0.01 | 30.2887 |     - |     - |  64,080 B |
|           ValueLinq_ValueLambda_Stack_ByIndex |  1000 | 14,352.14 ns | 101.288 ns |  89.789 ns | 14,376.88 ns |  1.04 |    0.01 | 30.2887 |     - |     - |  64,080 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |  1000 | 14,341.99 ns |  68.142 ns |  60.406 ns | 14,341.19 ns |  1.04 |    0.01 | 15.1367 |     - |     - |  32,216 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |  1000 | 13,608.50 ns |  95.332 ns |  79.606 ns | 13,600.03 ns |  0.98 |    0.01 | 15.1367 |     - |     - |  32,216 B |
|                                       ForLoop |  1000 | 13,842.80 ns | 106.536 ns |  94.441 ns | 13,839.72 ns |  1.00 |    0.00 | 46.5088 |     - |     - |  97,720 B |
|                                   ForeachLoop |  1000 | 16,911.77 ns |  71.116 ns |  66.522 ns | 16,912.67 ns |  1.22 |    0.01 | 46.5088 |     - |     - |  97,720 B |
|                                          Linq |  1000 | 16,985.15 ns | 200.801 ns | 187.829 ns | 17,009.63 ns |  1.23 |    0.02 | 31.2195 |     - |     - |  65,952 B |
|                                    LinqFaster |  1000 | 19,361.13 ns | 195.189 ns | 162.992 ns | 19,387.82 ns |  1.40 |    0.01 | 46.5088 |     - |     - |  97,720 B |
|                                        LinqAF |  1000 | 32,548.19 ns | 260.384 ns | 203.291 ns | 32,595.10 ns |  2.35 |    0.02 | 46.5088 |     - |     - |  97,688 B |
|                                    StructLinq |  1000 | 15,853.17 ns |  63.286 ns |  56.101 ns | 15,867.43 ns |  1.15 |    0.01 | 15.3809 |     - |     - |  32,320 B |
|                          StructLinq_IFunction |  1000 | 10,806.69 ns |  93.550 ns |  87.506 ns | 10,793.84 ns |  0.78 |    0.01 | 15.1367 |     - |     - |  32,216 B |
|                                     Hyperlinq |  1000 | 16,294.62 ns | 149.444 ns | 139.790 ns | 16,296.07 ns |  1.18 |    0.02 | 15.1367 |     - |     - |  32,216 B |
|                           Hyperlinq_IFunction |  1000 | 11,635.27 ns |  63.604 ns |  56.383 ns | 11,640.94 ns |  0.84 |    0.01 | 15.1367 |     - |     - |  32,216 B |
