## Array.ValueType.ArrayValueTypeWhereSelectToList

### Source
[ArrayValueTypeWhereSelectToList.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelectToList.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.19.2](https://www.nuget.org/packages/StructLinq.BCL/0.19.2)
- NetFabric.Hyperlinq: [3.0.0-beta27](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta27)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19041.630 (2004/?/20H1)
Intel Core i7 CPU 930 2.80GHz (Nehalem), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=5.0.100
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.51904, CoreFX 5.0.20.51904), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.51904, CoreFX 5.0.20.51904), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                                    Method | Count |      Mean |     Error |    StdDev |    Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------------ |------ |----------:|----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                        ValueLinq_Standard |   100 |  2.833 μs | 0.0557 μs | 0.1059 μs |  2.855 μs |  1.37 |    0.07 | 1.2207 |     - |     - |   4.99 KB |
|                           ValueLinq_Stack |   100 |  2.474 μs | 0.0495 μs | 0.1117 μs |  2.502 μs |  1.20 |    0.08 | 0.4883 |     - |     - |   2.01 KB |
|                 ValueLinq_SharedPool_Push |   100 |  3.234 μs | 0.0648 μs | 0.1450 μs |  3.227 μs |  1.56 |    0.08 | 0.4883 |     - |     - |   2.01 KB |
|                 ValueLinq_SharedPool_Pull |   100 |  3.095 μs | 0.0619 μs | 0.1359 μs |  3.096 μs |  1.50 |    0.09 | 0.4883 |     - |     - |   2.01 KB |
|                    ValueLinq_Ref_Standard |   100 |  3.025 μs | 0.0607 μs | 0.1369 μs |  3.024 μs |  1.46 |    0.09 | 1.2207 |     - |     - |   4.99 KB |
|                       ValueLinq_Ref_Stack |   100 |  2.686 μs | 0.0531 μs | 0.1262 μs |  2.688 μs |  1.30 |    0.08 | 0.4883 |     - |     - |   2.01 KB |
|             ValueLinq_Ref_SharedPool_Push |   100 |  3.185 μs | 0.0628 μs | 0.1391 μs |  3.197 μs |  1.54 |    0.09 | 0.4883 |     - |     - |   2.01 KB |
|             ValueLinq_Ref_SharedPool_Pull |   100 |  2.986 μs | 0.0598 μs | 0.1764 μs |  2.971 μs |  1.45 |    0.11 | 0.4883 |     - |     - |   2.01 KB |
|            ValueLinq_ValueLambda_Standard |   100 |  2.639 μs | 0.0528 μs | 0.1223 μs |  2.641 μs |  1.28 |    0.08 | 1.2207 |     - |     - |   4.99 KB |
|               ValueLinq_ValueLambda_Stack |   100 |  2.712 μs | 0.0542 μs | 0.1400 μs |  2.703 μs |  1.31 |    0.09 | 0.4883 |     - |     - |   2.01 KB |
|     ValueLinq_ValueLambda_SharedPool_Push |   100 |  2.875 μs | 0.0571 μs | 0.0985 μs |  2.885 μs |  1.39 |    0.07 | 0.4883 |     - |     - |   2.01 KB |
|     ValueLinq_ValueLambda_SharedPool_Pull |   100 |  2.873 μs | 0.0571 μs | 0.1506 μs |  2.892 μs |  1.39 |    0.09 | 0.4883 |     - |     - |   2.01 KB |
|        ValueLinq_ValueLambda_Ref_Standard |   100 |  2.514 μs | 0.0503 μs | 0.1062 μs |  2.529 μs |  1.21 |    0.07 | 1.2207 |     - |     - |   4.99 KB |
|           ValueLinq_ValueLambda_Ref_Stack |   100 |  2.618 μs | 0.0761 μs | 0.2244 μs |  2.679 μs |  1.20 |    0.13 | 0.4883 |     - |     - |   2.01 KB |
| ValueLinq_ValueLambda_Ref_SharedPool_Push |   100 |  2.718 μs | 0.0543 μs | 0.1280 μs |  2.718 μs |  1.32 |    0.09 | 0.4883 |     - |     - |   2.01 KB |
| ValueLinq_ValueLambda_Ref_SharedPool_Pull |   100 |  2.601 μs | 0.0521 μs | 0.1327 μs |  2.634 μs |  1.26 |    0.09 | 0.4883 |     - |     - |   2.01 KB |
|                                   ForLoop |   100 |  2.070 μs | 0.0408 μs | 0.0815 μs |  2.081 μs |  1.00 |    0.00 | 1.2207 |     - |     - |   4.99 KB |
|                               ForeachLoop |   100 |  2.152 μs | 0.0413 μs | 0.0835 μs |  2.166 μs |  1.04 |    0.06 | 1.2207 |     - |     - |   4.99 KB |
|                                      Linq |   100 |  3.046 μs | 0.0609 μs | 0.1423 μs |  3.060 μs |  1.48 |    0.10 | 1.2589 |     - |     - |   5.16 KB |
|                                LinqFaster |   100 |  2.976 μs | 0.0592 μs | 0.1430 μs |  2.993 μs |  1.43 |    0.08 | 1.9341 |     - |     - |   7.91 KB |
|                                    LinqAF |   100 | 12.698 μs | 0.5581 μs | 1.5183 μs | 12.300 μs |  6.26 |    0.87 |      - |     - |     - |   4.99 KB |
|                                StructLinq |   100 |  2.550 μs | 0.0509 μs | 0.1085 μs |  2.533 μs |  1.24 |    0.08 | 0.5112 |     - |     - |    2.1 KB |
|                      StructLinq_IFunction |   100 |  1.874 μs | 0.0373 μs | 0.0710 μs |  1.874 μs |  0.91 |    0.05 | 0.4902 |     - |     - |   2.01 KB |
|                                 Hyperlinq |   100 |  2.753 μs | 0.0548 μs | 0.1168 μs |  2.757 μs |  1.33 |    0.08 | 0.5074 |     - |     - |   2.08 KB |
