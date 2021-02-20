## List.Int32.ListInt32WhereSelectToList

### Source
[ListInt32WhereSelectToList.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelectToList.cs)

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
|                                        Method | Count |         Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------------------------- |------ |-------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                            **ValueLinq_Standard** |    **10** |    **211.55 ns** |  **0.492 ns** |  **0.410 ns** |  **7.07** |    **0.03** | **0.0305** |     **-** |     **-** |      **64 B** |
|                               ValueLinq_Stack |    10 |    170.83 ns |  0.553 ns |  0.490 ns |  5.71 |    0.02 | 0.0305 |     - |     - |      64 B |
|                     ValueLinq_SharedPool_Push |    10 |    357.94 ns |  1.493 ns |  1.324 ns | 11.97 |    0.06 | 0.0305 |     - |     - |      64 B |
|                     ValueLinq_SharedPool_Pull |    10 |    299.15 ns |  0.925 ns |  0.820 ns | 10.00 |    0.04 | 0.0305 |     - |     - |      64 B |
|                ValueLinq_ValueLambda_Standard |    10 |    186.89 ns |  0.523 ns |  0.464 ns |  6.25 |    0.03 | 0.0305 |     - |     - |      64 B |
|                   ValueLinq_ValueLambda_Stack |    10 |    148.29 ns |  0.470 ns |  0.392 ns |  4.96 |    0.02 | 0.0303 |     - |     - |      64 B |
|         ValueLinq_ValueLambda_SharedPool_Push |    10 |    295.07 ns |  1.076 ns |  0.899 ns |  9.87 |    0.05 | 0.0305 |     - |     - |      64 B |
|         ValueLinq_ValueLambda_SharedPool_Pull |    10 |    273.64 ns |  0.563 ns |  0.440 ns |  9.15 |    0.04 | 0.0305 |     - |     - |      64 B |
|                    ValueLinq_Standard_ByIndex |    10 |    181.57 ns |  0.457 ns |  0.405 ns |  6.07 |    0.03 | 0.0303 |     - |     - |      64 B |
|                       ValueLinq_Stack_ByIndex |    10 |    146.88 ns |  0.405 ns |  0.359 ns |  4.91 |    0.02 | 0.0303 |     - |     - |      64 B |
|             ValueLinq_SharedPool_Push_ByIndex |    10 |    378.48 ns |  1.273 ns |  1.128 ns | 12.65 |    0.05 | 0.0305 |     - |     - |      64 B |
|             ValueLinq_SharedPool_Pull_ByIndex |    10 |    265.85 ns |  1.204 ns |  1.067 ns |  8.89 |    0.04 | 0.0305 |     - |     - |      64 B |
|        ValueLinq_ValueLambda_Standard_ByIndex |    10 |    170.22 ns |  0.410 ns |  0.363 ns |  5.69 |    0.03 | 0.0305 |     - |     - |      64 B |
|           ValueLinq_ValueLambda_Stack_ByIndex |    10 |    134.84 ns |  0.366 ns |  0.306 ns |  4.51 |    0.02 | 0.0305 |     - |     - |      64 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |    10 |    299.90 ns |  0.762 ns |  0.636 ns | 10.03 |    0.03 | 0.0305 |     - |     - |      64 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |    10 |    252.58 ns |  0.534 ns |  0.499 ns |  8.44 |    0.03 | 0.0305 |     - |     - |      64 B |
|                                       ForLoop |    10 |     29.91 ns |  0.112 ns |  0.099 ns |  1.00 |    0.00 | 0.0343 |     - |     - |      72 B |
|                                   ForeachLoop |    10 |     47.20 ns |  0.172 ns |  0.152 ns |  1.58 |    0.01 | 0.0344 |     - |     - |      72 B |
|                                          Linq |    10 |    100.22 ns |  0.582 ns |  0.516 ns |  3.35 |    0.02 | 0.1069 |     - |     - |     224 B |
|                                    LinqFaster |    10 |     66.78 ns |  0.226 ns |  0.212 ns |  2.23 |    0.01 | 0.0650 |     - |     - |     136 B |
|                                        LinqAF |    10 |    155.48 ns |  0.484 ns |  0.429 ns |  5.20 |    0.02 | 0.0341 |     - |     - |      72 B |
|                                    StructLinq |    10 |    139.17 ns |  0.829 ns |  0.734 ns |  4.65 |    0.03 | 0.0763 |     - |     - |     160 B |
|                          StructLinq_IFunction |    10 |     96.75 ns |  0.134 ns |  0.118 ns |  3.23 |    0.01 | 0.0305 |     - |     - |      64 B |
|                                     Hyperlinq |    10 |    104.76 ns |  0.357 ns |  0.316 ns |  3.50 |    0.02 | 0.0305 |     - |     - |      64 B |
|                           Hyperlinq_IFunction |    10 |     83.11 ns |  0.207 ns |  0.193 ns |  2.78 |    0.01 | 0.0305 |     - |     - |      64 B |
|                                               |       |              |           |           |       |         |        |       |       |           |
|                            **ValueLinq_Standard** |  **1000** |  **5,057.17 ns** | **25.321 ns** | **23.685 ns** |  **1.52** |    **0.01** | **2.0523** |     **-** |     **-** |    **4304 B** |
|                               ValueLinq_Stack |  1000 |  7,751.23 ns | 79.192 ns | 66.129 ns |  2.33 |    0.03 | 1.9836 |     - |     - |    4176 B |
|                     ValueLinq_SharedPool_Push |  1000 |  5,181.72 ns | 17.227 ns | 16.114 ns |  1.56 |    0.01 | 0.9842 |     - |     - |    2072 B |
|                     ValueLinq_SharedPool_Pull |  1000 |  7,483.62 ns | 24.979 ns | 20.859 ns |  2.25 |    0.01 | 0.9842 |     - |     - |    2072 B |
|                ValueLinq_ValueLambda_Standard |  1000 |  2,925.80 ns | 31.415 ns | 26.233 ns |  0.88 |    0.01 | 2.0561 |     - |     - |    4304 B |
|                   ValueLinq_ValueLambda_Stack |  1000 |  8,104.88 ns | 16.338 ns | 14.483 ns |  2.44 |    0.01 | 1.9836 |     - |     - |    4176 B |
|         ValueLinq_ValueLambda_SharedPool_Push |  1000 |  2,919.10 ns | 11.204 ns |  9.932 ns |  0.88 |    0.00 | 0.9880 |     - |     - |    2072 B |
|         ValueLinq_ValueLambda_SharedPool_Pull |  1000 |  7,899.42 ns | 21.417 ns | 20.034 ns |  2.37 |    0.01 | 0.9766 |     - |     - |    2072 B |
|                    ValueLinq_Standard_ByIndex |  1000 |  5,038.38 ns | 28.006 ns | 24.827 ns |  1.51 |    0.01 | 2.0523 |     - |     - |    4304 B |
|                       ValueLinq_Stack_ByIndex |  1000 |  6,189.21 ns |  9.596 ns |  7.492 ns |  1.86 |    0.01 | 1.9913 |     - |     - |    4176 B |
|             ValueLinq_SharedPool_Push_ByIndex |  1000 |  5,611.11 ns | 20.338 ns | 19.024 ns |  1.69 |    0.01 | 0.9842 |     - |     - |    2072 B |
|             ValueLinq_SharedPool_Pull_ByIndex |  1000 |  7,059.97 ns | 31.520 ns | 27.942 ns |  2.12 |    0.01 | 0.9842 |     - |     - |    2072 B |
|        ValueLinq_ValueLambda_Standard_ByIndex |  1000 |  2,858.01 ns | 13.206 ns | 12.352 ns |  0.86 |    0.01 | 2.0561 |     - |     - |    4304 B |
|           ValueLinq_ValueLambda_Stack_ByIndex |  1000 |  2,943.91 ns | 25.597 ns | 22.691 ns |  0.88 |    0.01 | 1.9951 |     - |     - |    4176 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |  1000 |  2,604.87 ns | 13.381 ns | 11.862 ns |  0.78 |    0.00 | 0.9880 |     - |     - |    2072 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |  1000 |  2,795.24 ns | 28.034 ns | 23.410 ns |  0.84 |    0.01 | 0.9880 |     - |     - |    2072 B |
|                                       ForLoop |  1000 |  3,329.54 ns | 18.116 ns | 16.945 ns |  1.00 |    0.00 | 2.0561 |     - |     - |    4304 B |
|                                   ForeachLoop |  1000 |  4,747.75 ns | 25.021 ns | 22.181 ns |  1.43 |    0.01 | 2.0523 |     - |     - |    4304 B |
|                                          Linq |  1000 |  5,626.33 ns | 23.753 ns | 21.056 ns |  1.69 |    0.01 | 2.1286 |     - |     - |    4456 B |
|                                    LinqFaster |  1000 |  5,494.21 ns | 32.201 ns | 30.121 ns |  1.65 |    0.01 | 3.0441 |     - |     - |    6376 B |
|                                        LinqAF |  1000 | 12,664.57 ns | 26.107 ns | 23.143 ns |  3.80 |    0.02 | 2.0447 |     - |     - |    4304 B |
|                                    StructLinq |  1000 |  4,996.05 ns | 14.868 ns | 13.180 ns |  1.50 |    0.01 | 1.0300 |     - |     - |    2168 B |
|                          StructLinq_IFunction |  1000 |  2,796.32 ns | 11.414 ns | 10.118 ns |  0.84 |    0.01 | 0.9880 |     - |     - |    2072 B |
|                                     Hyperlinq |  1000 |  5,069.09 ns | 19.765 ns | 18.488 ns |  1.52 |    0.01 | 0.9842 |     - |     - |    2072 B |
|                           Hyperlinq_IFunction |  1000 |  2,418.75 ns | 10.926 ns | 10.220 ns |  0.73 |    0.01 | 0.9880 |     - |     - |    2072 B |
