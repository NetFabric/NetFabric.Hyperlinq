## List.ValueType.ListValueTypeWhereSelectToList

### Source
[ListValueTypeWhereSelectToList.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelectToList.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.19.2](https://www.nuget.org/packages/StructLinq.BCL/0.19.2)
- NetFabric.Hyperlinq: [3.0.0-beta26](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta26)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19041.630 (2004/?/20H1)
Intel Core i7 CPU 930 2.80GHz (Nehalem), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=5.0.100
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.51904, CoreFX 5.0.20.51904), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.51904, CoreFX 5.0.20.51904), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                                            Method | Count |      Mean |     Error |    StdDev |    Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------------------- |------ |----------:|----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                                ValueLinq_Standard |   100 |  3.176 μs | 0.0063 μs | 0.0049 μs |  3.179 μs |  1.72 |    0.07 | 1.2207 |     - |     - |   4.99 KB |
|                                   ValueLinq_Stack |   100 |  2.779 μs | 0.0376 μs | 0.0352 μs |  2.787 μs |  1.49 |    0.05 | 0.4883 |     - |     - |   2.01 KB |
|                         ValueLinq_SharedPool_Push |   100 |  3.619 μs | 0.0552 μs | 0.0516 μs |  3.617 μs |  1.95 |    0.07 | 0.4883 |     - |     - |   2.01 KB |
|                         ValueLinq_SharedPool_Pull |   100 |  3.094 μs | 0.0597 μs | 0.0734 μs |  3.130 μs |  1.65 |    0.07 | 0.4883 |     - |     - |   2.01 KB |
|                            ValueLinq_Ref_Standard |   100 |  3.243 μs | 0.0635 μs | 0.0825 μs |  3.251 μs |  1.74 |    0.07 | 1.2207 |     - |     - |   4.99 KB |
|                               ValueLinq_Ref_Stack |   100 |  4.235 μs | 0.0515 μs | 0.0482 μs |  4.250 μs |  2.28 |    0.09 | 0.4883 |     - |     - |   2.01 KB |
|                     ValueLinq_Ref_SharedPool_Push |   100 |  3.443 μs | 0.0687 μs | 0.1927 μs |  3.436 μs |  1.86 |    0.11 | 0.4883 |     - |     - |   2.01 KB |
|                     ValueLinq_Ref_SharedPool_Pull |   100 |  3.176 μs | 0.0637 μs | 0.1643 μs |  3.192 μs |  1.70 |    0.10 | 0.4883 |     - |     - |   2.01 KB |
|                    ValueLinq_ValueLambda_Standard |   100 |  2.789 μs | 0.0552 μs | 0.0678 μs |  2.805 μs |  1.49 |    0.06 | 1.2207 |     - |     - |   4.99 KB |
|                       ValueLinq_ValueLambda_Stack |   100 |  2.870 μs | 0.0573 μs | 0.1489 μs |  2.933 μs |  1.54 |    0.11 | 0.4883 |     - |     - |   2.01 KB |
|             ValueLinq_ValueLambda_SharedPool_Push |   100 |  2.889 μs | 0.0578 μs | 0.1418 μs |  2.893 μs |  1.54 |    0.11 | 0.4883 |     - |     - |   2.01 KB |
|             ValueLinq_ValueLambda_SharedPool_Pull |   100 |  3.065 μs | 0.0610 μs | 0.1413 μs |  3.087 μs |  1.65 |    0.11 | 0.4883 |     - |     - |   2.01 KB |
|                ValueLinq_ValueLambda_Ref_Standard |   100 |  2.339 μs | 0.0468 μs | 0.0946 μs |  2.381 μs |  1.26 |    0.07 | 1.2207 |     - |     - |   4.99 KB |
|                   ValueLinq_ValueLambda_Ref_Stack |   100 |  2.522 μs | 0.0505 μs | 0.1275 μs |  2.568 μs |  1.35 |    0.08 | 0.4883 |     - |     - |   2.01 KB |
|         ValueLinq_ValueLambda_Ref_SharedPool_Push |   100 |  2.568 μs | 0.0496 μs | 0.0695 μs |  2.596 μs |  1.38 |    0.06 | 0.4883 |     - |     - |   2.01 KB |
|         ValueLinq_ValueLambda_Ref_SharedPool_Pull |   100 |  2.756 μs | 0.0552 μs | 0.1312 μs |  2.802 μs |  1.48 |    0.08 | 0.4883 |     - |     - |   2.01 KB |
|                        ValueLinq_Standard_ByIndex |   100 |  3.011 μs | 0.0597 μs | 0.1259 μs |  3.056 μs |  1.62 |    0.09 | 1.2207 |     - |     - |   4.99 KB |
|                           ValueLinq_Stack_ByIndex |   100 |  2.249 μs | 0.0447 μs | 0.0981 μs |  2.288 μs |  1.20 |    0.07 | 0.4883 |     - |     - |   2.01 KB |
|                 ValueLinq_SharedPool_Push_ByIndex |   100 |  3.173 μs | 0.0622 μs | 0.1169 μs |  3.225 μs |  1.70 |    0.08 | 0.4883 |     - |     - |   2.01 KB |
|                 ValueLinq_SharedPool_Pull_ByIndex |   100 |  2.576 μs | 0.0513 μs | 0.1455 μs |  2.627 μs |  1.40 |    0.08 | 0.4883 |     - |     - |   2.01 KB |
|                    ValueLinq_Ref_Standard_ByIndex |   100 |  2.840 μs | 0.0565 μs | 0.1115 μs |  2.893 μs |  1.52 |    0.06 | 1.2207 |     - |     - |   4.99 KB |
|                       ValueLinq_Ref_Stack_ByIndex |   100 |  2.081 μs | 0.0417 μs | 0.0991 μs |  2.111 μs |  1.12 |    0.06 | 0.4883 |     - |     - |   2.01 KB |
|             ValueLinq_Ref_SharedPool_Push_ByIndex |   100 |  3.042 μs | 0.0293 μs | 0.0274 μs |  3.051 μs |  1.64 |    0.06 | 0.4883 |     - |     - |   2.01 KB |
|             ValueLinq_Ref_SharedPool_Pull_ByIndex |   100 |  2.422 μs | 0.0481 μs | 0.1198 μs |  2.461 μs |  1.30 |    0.07 | 0.4883 |     - |     - |   2.01 KB |
|            ValueLinq_ValueLambda_Standard_ByIndex |   100 |  2.226 μs | 0.0440 μs | 0.0848 μs |  2.271 μs |  1.20 |    0.05 | 1.2207 |     - |     - |   4.99 KB |
|               ValueLinq_ValueLambda_Stack_ByIndex |   100 |  2.320 μs | 0.0460 μs | 0.0990 μs |  2.356 μs |  1.25 |    0.06 | 0.4883 |     - |     - |   2.01 KB |
|     ValueLinq_ValueLambda_SharedPool_Push_ByIndex |   100 |  2.395 μs | 0.0478 μs | 0.1038 μs |  2.432 μs |  1.28 |    0.07 | 0.4883 |     - |     - |   2.01 KB |
|     ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |   100 |  2.309 μs | 0.0462 μs | 0.1167 μs |  2.323 μs |  1.25 |    0.05 | 0.4883 |     - |     - |   2.01 KB |
|        ValueLinq_ValueLambda_Ref_Standard_ByIndex |   100 |  2.244 μs | 0.0332 μs | 0.0311 μs |  2.256 μs |  1.21 |    0.05 | 1.2207 |     - |     - |   4.99 KB |
|           ValueLinq_ValueLambda_Ref_Stack_ByIndex |   100 |  1.938 μs | 0.0375 μs | 0.0432 μs |  1.954 μs |  1.04 |    0.04 | 0.4902 |     - |     - |   2.01 KB |
| ValueLinq_ValueLambda_Ref_SharedPool_Push_ByIndex |   100 |  2.413 μs | 0.0475 μs | 0.0959 μs |  2.460 μs |  1.30 |    0.06 | 0.4883 |     - |     - |   2.01 KB |
| ValueLinq_ValueLambda_Ref_SharedPool_Pull_ByIndex |   100 |  2.138 μs | 0.0423 μs | 0.0835 μs |  2.182 μs |  1.15 |    0.06 | 0.4883 |     - |     - |   2.01 KB |
|                                           ForLoop |   100 |  1.870 μs | 0.0369 μs | 0.0586 μs |  1.897 μs |  1.00 |    0.00 | 1.2207 |     - |     - |   4.99 KB |
|                                       ForeachLoop |   100 |  2.223 μs | 0.0390 μs | 0.0365 μs |  2.237 μs |  1.20 |    0.05 | 1.2207 |     - |     - |   4.99 KB |
|                                              Linq |   100 |  2.789 μs | 0.0542 μs | 0.0685 μs |  2.815 μs |  1.49 |    0.06 | 1.2856 |     - |     - |   5.27 KB |
|                                        LinqFaster |   100 |  2.936 μs | 0.0575 μs | 0.1051 μs |  2.951 μs |  1.58 |    0.08 | 1.7128 |     - |     - |      7 KB |
|                                            LinqAF |   100 | 13.049 μs | 0.2390 μs | 0.4186 μs | 13.100 μs |  7.00 |    0.33 |      - |     - |     - |   4.99 KB |
|                                        StructLinq |   100 |  2.150 μs | 0.0428 μs | 0.0941 μs |  2.188 μs |  1.14 |    0.06 | 0.5112 |     - |     - |    2.1 KB |
|                              StructLinq_IFunction |   100 |  1.566 μs | 0.0314 μs | 0.0582 μs |  1.593 μs |  0.84 |    0.04 | 0.4902 |     - |     - |   2.01 KB |
|                                         Hyperlinq |   100 |  2.230 μs | 0.0465 μs | 0.1370 μs |  2.219 μs |  1.18 |    0.04 | 0.5074 |     - |     - |   2.08 KB |
