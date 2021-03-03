## List.Int32.ListInt32WhereSelectToList

### Source
[ListInt32WhereSelectToList.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelectToList.cs)

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
|                                        Method | Count |         Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------------------------- |------ |-------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                            **ValueLinq_Standard** |    **10** |    **216.78 ns** |  **0.845 ns** |  **0.749 ns** |  **7.23** |    **0.04** | **0.0305** |     **-** |     **-** |      **64 B** |
|                               ValueLinq_Stack |    10 |    173.38 ns |  2.018 ns |  1.789 ns |  5.78 |    0.07 | 0.0305 |     - |     - |      64 B |
|                     ValueLinq_SharedPool_Push |    10 |    367.13 ns |  1.013 ns |  0.846 ns | 12.24 |    0.07 | 0.0305 |     - |     - |      64 B |
|                     ValueLinq_SharedPool_Pull |    10 |    286.98 ns |  1.399 ns |  1.093 ns |  9.57 |    0.04 | 0.0305 |     - |     - |      64 B |
|                ValueLinq_ValueLambda_Standard |    10 |    188.37 ns |  0.311 ns |  0.275 ns |  6.28 |    0.03 | 0.0305 |     - |     - |      64 B |
|                   ValueLinq_ValueLambda_Stack |    10 |    149.86 ns |  0.360 ns |  0.319 ns |  5.00 |    0.03 | 0.0303 |     - |     - |      64 B |
|         ValueLinq_ValueLambda_SharedPool_Push |    10 |    292.36 ns |  1.100 ns |  0.975 ns |  9.75 |    0.05 | 0.0305 |     - |     - |      64 B |
|         ValueLinq_ValueLambda_SharedPool_Pull |    10 |    272.31 ns |  1.187 ns |  1.111 ns |  9.08 |    0.06 | 0.0305 |     - |     - |      64 B |
|                    ValueLinq_Standard_ByIndex |    10 |    194.72 ns |  0.773 ns |  0.685 ns |  6.49 |    0.04 | 0.0305 |     - |     - |      64 B |
|                       ValueLinq_Stack_ByIndex |    10 |    146.67 ns |  0.717 ns |  0.636 ns |  4.89 |    0.03 | 0.0303 |     - |     - |      64 B |
|             ValueLinq_SharedPool_Push_ByIndex |    10 |    374.89 ns |  1.089 ns |  0.966 ns | 12.50 |    0.06 | 0.0305 |     - |     - |      64 B |
|             ValueLinq_SharedPool_Pull_ByIndex |    10 |    261.11 ns |  1.011 ns |  0.844 ns |  8.71 |    0.05 | 0.0305 |     - |     - |      64 B |
|        ValueLinq_ValueLambda_Standard_ByIndex |    10 |    171.69 ns |  0.305 ns |  0.255 ns |  5.73 |    0.03 | 0.0303 |     - |     - |      64 B |
|           ValueLinq_ValueLambda_Stack_ByIndex |    10 |    133.84 ns |  0.539 ns |  0.450 ns |  4.46 |    0.02 | 0.0303 |     - |     - |      64 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |    10 |    299.28 ns |  0.637 ns |  0.498 ns |  9.98 |    0.05 | 0.0305 |     - |     - |      64 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |    10 |    260.50 ns |  0.681 ns |  0.604 ns |  8.69 |    0.04 | 0.0305 |     - |     - |      64 B |
|                                       ForLoop |    10 |     29.99 ns |  0.150 ns |  0.133 ns |  1.00 |    0.00 | 0.0344 |     - |     - |      72 B |
|                                   ForeachLoop |    10 |     47.37 ns |  0.153 ns |  0.136 ns |  1.58 |    0.01 | 0.0343 |     - |     - |      72 B |
|                                          Linq |    10 |     98.37 ns |  0.504 ns |  0.421 ns |  3.28 |    0.02 | 0.1069 |     - |     - |     224 B |
|                                    LinqFaster |    10 |     66.91 ns |  0.215 ns |  0.179 ns |  2.23 |    0.01 | 0.0648 |     - |     - |     136 B |
|                                        LinqAF |    10 |    156.95 ns |  0.442 ns |  0.413 ns |  5.23 |    0.02 | 0.0343 |     - |     - |      72 B |
|                                    StructLinq |    10 |    135.34 ns |  0.344 ns |  0.268 ns |  4.51 |    0.02 | 0.0763 |     - |     - |     160 B |
|                          StructLinq_IFunction |    10 |     96.37 ns |  0.123 ns |  0.109 ns |  3.21 |    0.02 | 0.0305 |     - |     - |      64 B |
|                                     Hyperlinq |    10 |    114.39 ns |  0.245 ns |  0.217 ns |  3.81 |    0.02 | 0.0305 |     - |     - |      64 B |
|                           Hyperlinq_IFunction |    10 |     90.73 ns |  0.185 ns |  0.155 ns |  3.03 |    0.02 | 0.0305 |     - |     - |      64 B |
|                                               |       |              |           |           |       |         |        |       |       |           |
|                            **ValueLinq_Standard** |  **1000** |  **5,032.80 ns** | **17.426 ns** | **15.447 ns** |  **1.29** |    **0.01** | **2.0523** |     **-** |     **-** |   **4,304 B** |
|                               ValueLinq_Stack |  1000 |  7,835.28 ns | 25.228 ns | 22.364 ns |  2.01 |    0.01 | 1.9836 |     - |     - |   4,176 B |
|                     ValueLinq_SharedPool_Push |  1000 |  5,721.80 ns | 18.315 ns | 16.236 ns |  1.47 |    0.01 | 0.9842 |     - |     - |   2,072 B |
|                     ValueLinq_SharedPool_Pull |  1000 |  7,755.72 ns | 20.246 ns | 16.906 ns |  1.99 |    0.01 | 0.9766 |     - |     - |   2,072 B |
|                ValueLinq_ValueLambda_Standard |  1000 |  1,793.10 ns | 16.848 ns | 15.760 ns |  0.46 |    0.00 | 2.0561 |     - |     - |   4,304 B |
|                   ValueLinq_ValueLambda_Stack |  1000 |  8,133.31 ns | 16.644 ns | 14.755 ns |  2.09 |    0.01 | 1.9836 |     - |     - |   4,176 B |
|         ValueLinq_ValueLambda_SharedPool_Push |  1000 |  3,814.32 ns |  7.423 ns |  6.580 ns |  0.98 |    0.00 | 0.9842 |     - |     - |   2,072 B |
|         ValueLinq_ValueLambda_SharedPool_Pull |  1000 |  8,085.91 ns | 19.258 ns | 18.014 ns |  2.08 |    0.01 | 0.9766 |     - |     - |   2,072 B |
|                    ValueLinq_Standard_ByIndex |  1000 |  5,032.47 ns | 19.586 ns | 17.363 ns |  1.29 |    0.01 | 2.0523 |     - |     - |   4,304 B |
|                       ValueLinq_Stack_ByIndex |  1000 |  6,177.80 ns | 19.199 ns | 16.032 ns |  1.59 |    0.01 | 1.9913 |     - |     - |   4,176 B |
|             ValueLinq_SharedPool_Push_ByIndex |  1000 |  5,507.75 ns | 24.472 ns | 21.694 ns |  1.41 |    0.01 | 0.9842 |     - |     - |   2,072 B |
|             ValueLinq_SharedPool_Pull_ByIndex |  1000 |  6,499.51 ns | 17.924 ns | 15.889 ns |  1.67 |    0.01 | 0.9842 |     - |     - |   2,072 B |
|        ValueLinq_ValueLambda_Standard_ByIndex |  1000 |  2,723.65 ns | 17.160 ns | 15.212 ns |  0.70 |    0.01 | 2.0561 |     - |     - |   4,304 B |
|           ValueLinq_ValueLambda_Stack_ByIndex |  1000 |  3,030.70 ns | 15.906 ns | 14.878 ns |  0.78 |    0.00 | 1.9951 |     - |     - |   4,176 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |  1000 |  3,879.37 ns | 14.375 ns | 13.446 ns |  1.00 |    0.01 | 0.9842 |     - |     - |   2,072 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |  1000 |  2,614.79 ns |  6.816 ns |  6.043 ns |  0.67 |    0.00 | 0.9880 |     - |     - |   2,072 B |
|                                       ForLoop |  1000 |  3,896.30 ns | 17.941 ns | 16.782 ns |  1.00 |    0.00 | 2.0523 |     - |     - |   4,304 B |
|                                   ForeachLoop |  1000 |  5,197.42 ns | 29.588 ns | 26.229 ns |  1.33 |    0.01 | 2.0523 |     - |     - |   4,304 B |
|                                          Linq |  1000 |  5,683.41 ns | 12.277 ns | 10.252 ns |  1.46 |    0.01 | 2.1286 |     - |     - |   4,456 B |
|                                    LinqFaster |  1000 |  5,670.98 ns | 24.126 ns | 20.146 ns |  1.46 |    0.01 | 3.0441 |     - |     - |   6,376 B |
|                                        LinqAF |  1000 | 12,754.30 ns | 43.186 ns | 38.283 ns |  3.27 |    0.02 | 2.0447 |     - |     - |   4,304 B |
|                                    StructLinq |  1000 |  5,314.63 ns | 24.454 ns | 21.678 ns |  1.36 |    0.01 | 1.0300 |     - |     - |   2,168 B |
|                          StructLinq_IFunction |  1000 |  2,759.14 ns |  7.271 ns |  6.071 ns |  0.71 |    0.00 | 0.9880 |     - |     - |   2,072 B |
|                                     Hyperlinq |  1000 |  5,181.77 ns | 21.820 ns | 19.343 ns |  1.33 |    0.01 | 0.9842 |     - |     - |   2,072 B |
|                           Hyperlinq_IFunction |  1000 |  3,508.73 ns |  5.335 ns |  4.729 ns |  0.90 |    0.00 | 0.9880 |     - |     - |   2,072 B |
