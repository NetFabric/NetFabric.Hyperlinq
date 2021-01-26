## List.ValueType.ListValueTypeWhereSelectToArray

### Source
[ListValueTypeWhereSelectToArray.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelectToArray.cs)

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
|                                ValueLinq_Standard |   100 |  3.798 μs | 0.0753 μs | 0.1278 μs |  3.805 μs |  1.69 |    0.06 | 1.5717 |     - |     - |    6576 B |
|                                   ValueLinq_Stack |   100 |  2.609 μs | 0.0519 μs | 0.1106 μs |  2.643 μs |  1.18 |    0.04 | 0.4807 |     - |     - |    2024 B |
|                         ValueLinq_SharedPool_Push |   100 |  3.582 μs | 0.0709 μs | 0.1333 μs |  3.635 μs |  1.62 |    0.05 | 0.4807 |     - |     - |    2024 B |
|                         ValueLinq_SharedPool_Pull |   100 |  3.125 μs | 0.0624 μs | 0.1471 μs |  3.210 μs |  1.41 |    0.07 | 0.4807 |     - |     - |    2024 B |
|                            ValueLinq_Ref_Standard |   100 |  3.717 μs | 0.0734 μs | 0.1596 μs |  3.761 μs |  1.67 |    0.08 | 1.5717 |     - |     - |    6576 B |
|                               ValueLinq_Ref_Stack |   100 |  2.590 μs | 0.0519 μs | 0.1439 μs |  2.628 μs |  1.17 |    0.06 | 0.4807 |     - |     - |    2024 B |
|                     ValueLinq_Ref_SharedPool_Push |   100 |  3.440 μs | 0.0551 μs | 0.0460 μs |  3.452 μs |  1.54 |    0.05 | 0.4807 |     - |     - |    2024 B |
|                     ValueLinq_Ref_SharedPool_Pull |   100 |  3.022 μs | 0.0602 μs | 0.1688 μs |  3.087 μs |  1.36 |    0.09 | 0.4807 |     - |     - |    2024 B |
|                    ValueLinq_ValueLambda_Standard |   100 |  3.146 μs | 0.0626 μs | 0.1413 μs |  3.195 μs |  1.43 |    0.07 | 1.5717 |     - |     - |    6576 B |
|                       ValueLinq_ValueLambda_Stack |   100 |  2.665 μs | 0.0534 μs | 0.1387 μs |  2.716 μs |  1.20 |    0.07 | 0.4807 |     - |     - |    2024 B |
|             ValueLinq_ValueLambda_SharedPool_Push |   100 |  2.770 μs | 0.0555 μs | 0.1382 μs |  2.833 μs |  1.26 |    0.06 | 0.4807 |     - |     - |    2024 B |
|             ValueLinq_ValueLambda_SharedPool_Pull |   100 |  2.837 μs | 0.0566 μs | 0.1521 μs |  2.905 μs |  1.30 |    0.07 | 0.4807 |     - |     - |    2024 B |
|                ValueLinq_ValueLambda_Ref_Standard |   100 |  2.782 μs | 0.0585 μs | 0.0650 μs |  2.803 μs |  1.25 |    0.04 | 1.5717 |     - |     - |    6576 B |
|                   ValueLinq_ValueLambda_Ref_Stack |   100 |  2.251 μs | 0.0448 μs | 0.1039 μs |  2.288 μs |  1.03 |    0.04 | 0.4807 |     - |     - |    2024 B |
|         ValueLinq_ValueLambda_Ref_SharedPool_Push |   100 |  2.417 μs | 0.0471 μs | 0.0484 μs |  2.432 μs |  1.08 |    0.03 | 0.4807 |     - |     - |    2024 B |
|         ValueLinq_ValueLambda_Ref_SharedPool_Pull |   100 |  2.531 μs | 0.0503 μs | 0.1317 μs |  2.583 μs |  1.16 |    0.06 | 0.4807 |     - |     - |    2024 B |
|                        ValueLinq_Standard_ByIndex |   100 |  3.539 μs | 0.0706 μs | 0.0785 μs |  3.571 μs |  1.58 |    0.05 | 1.5717 |     - |     - |    6576 B |
|                           ValueLinq_Stack_ByIndex |   100 |  2.025 μs | 0.0400 μs | 0.0912 μs |  2.047 μs |  0.92 |    0.04 | 0.4807 |     - |     - |    2024 B |
|                 ValueLinq_SharedPool_Push_ByIndex |   100 |  3.076 μs | 0.0614 μs | 0.1562 μs |  3.124 μs |  1.39 |    0.08 | 0.4807 |     - |     - |    2024 B |
|                 ValueLinq_SharedPool_Pull_ByIndex |   100 |  2.458 μs | 0.0486 μs | 0.1127 μs |  2.490 μs |  1.13 |    0.04 | 0.4807 |     - |     - |    2024 B |
|                    ValueLinq_Ref_Standard_ByIndex |   100 |  3.219 μs | 0.0644 μs | 0.1467 μs |  3.270 μs |  1.46 |    0.07 | 1.5717 |     - |     - |    6576 B |
|                       ValueLinq_Ref_Stack_ByIndex |   100 |  1.912 μs | 0.0380 μs | 0.0917 μs |  1.940 μs |  0.87 |    0.03 | 0.4807 |     - |     - |    2024 B |
|             ValueLinq_Ref_SharedPool_Push_ByIndex |   100 |  2.914 μs | 0.0578 μs | 0.1244 μs |  2.964 μs |  1.32 |    0.05 | 0.4807 |     - |     - |    2024 B |
|             ValueLinq_Ref_SharedPool_Pull_ByIndex |   100 |  2.336 μs | 0.0464 μs | 0.1113 μs |  2.378 μs |  1.06 |    0.06 | 0.4807 |     - |     - |    2024 B |
|            ValueLinq_ValueLambda_Standard_ByIndex |   100 |  2.604 μs | 0.0515 μs | 0.1130 μs |  2.639 μs |  1.18 |    0.06 | 1.5717 |     - |     - |    6576 B |
|               ValueLinq_ValueLambda_Stack_ByIndex |   100 |  2.002 μs | 0.0400 μs | 0.0967 μs |  2.030 μs |  0.91 |    0.04 | 0.4807 |     - |     - |    2024 B |
|     ValueLinq_ValueLambda_SharedPool_Push_ByIndex |   100 |  2.212 μs | 0.0443 μs | 0.1111 μs |  2.234 μs |  1.02 |    0.05 | 0.4807 |     - |     - |    2024 B |
|     ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |   100 |  2.199 μs | 0.0439 μs | 0.0991 μs |  2.235 μs |  0.98 |    0.05 | 0.4807 |     - |     - |    2024 B |
|        ValueLinq_ValueLambda_Ref_Standard_ByIndex |   100 |  2.695 μs | 0.0515 μs | 0.0632 μs |  2.715 μs |  1.21 |    0.05 | 1.5717 |     - |     - |    6576 B |
|           ValueLinq_ValueLambda_Ref_Stack_ByIndex |   100 |  1.689 μs | 0.0339 μs | 0.0715 μs |  1.711 μs |  0.76 |    0.04 | 0.4826 |     - |     - |    2024 B |
| ValueLinq_ValueLambda_Ref_SharedPool_Push_ByIndex |   100 |  2.246 μs | 0.0447 μs | 0.0913 μs |  2.286 μs |  1.01 |    0.05 | 0.4807 |     - |     - |    2024 B |
| ValueLinq_ValueLambda_Ref_SharedPool_Pull_ByIndex |   100 |  1.950 μs | 0.0388 μs | 0.0802 μs |  1.992 μs |  0.88 |    0.04 | 0.4807 |     - |     - |    2024 B |
|                                           ForLoop |   100 |  2.233 μs | 0.0418 μs | 0.0448 μs |  2.247 μs |  1.00 |    0.00 | 1.7052 |     - |     - |    7136 B |
|                                       ForeachLoop |   100 |  2.583 μs | 0.0514 μs | 0.1106 μs |  2.633 μs |  1.17 |    0.06 | 1.7052 |     - |     - |    7136 B |
|                                              Linq |   100 |  2.767 μs | 0.0552 μs | 0.1268 μs |  2.823 μs |  1.26 |    0.06 | 1.2398 |     - |     - |    5200 B |
|                                        LinqFaster |   100 |  2.895 μs | 0.0579 μs | 0.1259 μs |  2.921 μs |  1.31 |    0.06 | 1.7052 |     - |     - |    7136 B |
|                                            LinqAF |   100 | 12.717 μs | 0.2367 μs | 0.6237 μs | 12.700 μs |  5.81 |    0.40 |      - |     - |     - |    7104 B |
|                                        StructLinq |   100 |  2.194 μs | 0.0424 μs | 0.0622 μs |  2.208 μs |  0.98 |    0.04 | 0.5035 |     - |     - |    2120 B |
|                              StructLinq_IFunction |   100 |  1.554 μs | 0.0311 μs | 0.0670 μs |  1.577 μs |  0.71 |    0.03 | 0.4826 |     - |     - |    2024 B |
|                                         Hyperlinq |   100 |  2.142 μs | 0.0424 μs | 0.1055 μs |  2.164 μs |  0.96 |    0.05 | 0.4807 |     - |     - |    2024 B |
|                                    Hyperlinq_Pool |   100 |  1.907 μs | 0.0381 μs | 0.1044 μs |  1.966 μs |  0.86 |    0.06 | 0.0076 |     - |     - |      56 B |
