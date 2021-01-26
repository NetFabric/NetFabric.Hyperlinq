## Array.ValueType.ArrayValueTypeWhereSelectToArray

### Source
[ArrayValueTypeWhereSelectToArray.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelectToArray.cs)

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
|                        ValueLinq_Standard |   100 |  3.010 μs | 0.0261 μs | 0.0244 μs |  3.016 μs |  1.21 |    0.07 | 1.5717 |     - |     - |    6576 B |
|                           ValueLinq_Stack |   100 |  1.988 μs | 0.0141 μs | 0.0117 μs |  1.989 μs |  0.80 |    0.05 | 0.4807 |     - |     - |    2024 B |
|                 ValueLinq_SharedPool_Push |   100 |  2.686 μs | 0.0242 μs | 0.0227 μs |  2.683 μs |  1.08 |    0.07 | 0.4807 |     - |     - |    2024 B |
|                 ValueLinq_SharedPool_Pull |   100 |  2.397 μs | 0.0326 μs | 0.0272 μs |  2.400 μs |  0.97 |    0.06 | 0.4807 |     - |     - |    2024 B |
|                    ValueLinq_Ref_Standard |   100 |  2.969 μs | 0.0259 μs | 0.0242 μs |  2.965 μs |  1.20 |    0.07 | 1.5717 |     - |     - |    6576 B |
|                       ValueLinq_Ref_Stack |   100 |  1.913 μs | 0.0365 μs | 0.0391 μs |  1.922 μs |  0.77 |    0.05 | 0.4807 |     - |     - |    2024 B |
|             ValueLinq_Ref_SharedPool_Push |   100 |  2.539 μs | 0.0506 μs | 0.0541 μs |  2.548 μs |  1.02 |    0.07 | 0.4807 |     - |     - |    2024 B |
|             ValueLinq_Ref_SharedPool_Pull |   100 |  2.317 μs | 0.0454 μs | 0.0746 μs |  2.329 μs |  0.94 |    0.06 | 0.4807 |     - |     - |    2024 B |
|            ValueLinq_ValueLambda_Standard |   100 |  2.663 μs | 0.0519 μs | 0.0867 μs |  2.664 μs |  1.07 |    0.07 | 1.5717 |     - |     - |    6576 B |
|               ValueLinq_ValueLambda_Stack |   100 |  2.139 μs | 0.0421 μs | 0.0870 μs |  2.146 μs |  0.86 |    0.07 | 0.4807 |     - |     - |    2024 B |
|     ValueLinq_ValueLambda_SharedPool_Push |   100 |  2.439 μs | 0.0486 μs | 0.1117 μs |  2.452 μs |  0.98 |    0.06 | 0.4807 |     - |     - |    2024 B |
|     ValueLinq_ValueLambda_SharedPool_Pull |   100 |  2.473 μs | 0.0493 μs | 0.1421 μs |  2.479 μs |  0.99 |    0.08 | 0.4807 |     - |     - |    2024 B |
|        ValueLinq_ValueLambda_Ref_Standard |   100 |  2.933 μs | 0.0588 μs | 0.1538 μs |  2.945 μs |  1.18 |    0.09 | 1.5717 |     - |     - |    6576 B |
|           ValueLinq_ValueLambda_Ref_Stack |   100 |  2.070 μs | 0.0422 μs | 0.1246 μs |  2.090 μs |  0.84 |    0.07 | 0.4807 |     - |     - |    2024 B |
| ValueLinq_ValueLambda_Ref_SharedPool_Push |   100 |  2.563 μs | 0.0512 μs | 0.1302 μs |  2.580 μs |  1.03 |    0.08 | 0.4807 |     - |     - |    2024 B |
| ValueLinq_ValueLambda_Ref_SharedPool_Pull |   100 |  2.388 μs | 0.0477 μs | 0.1196 μs |  2.405 μs |  0.96 |    0.07 | 0.4807 |     - |     - |    2024 B |
|                                   ForLoop |   100 |  2.493 μs | 0.0500 μs | 0.1299 μs |  2.506 μs |  1.00 |    0.00 | 1.7052 |     - |     - |    7136 B |
|                               ForeachLoop |   100 |  2.639 μs | 0.0528 μs | 0.1256 μs |  2.678 μs |  1.06 |    0.07 | 1.7052 |     - |     - |    7136 B |
|                                      Linq |   100 |  2.997 μs | 0.0595 μs | 0.1342 μs |  3.039 μs |  1.21 |    0.09 | 1.2131 |     - |     - |    5088 B |
|                                LinqFaster |   100 |  2.384 μs | 0.0474 μs | 0.1391 μs |  2.400 μs |  0.96 |    0.07 | 1.4420 |     - |     - |    6048 B |
|                                    LinqAF |   100 | 12.416 μs | 0.5270 μs | 1.4066 μs | 12.100 μs |  5.01 |    0.66 |      - |     - |     - |    7104 B |
|                                StructLinq |   100 |  2.483 μs | 0.0495 μs | 0.1338 μs |  2.469 μs |  1.00 |    0.08 | 0.5035 |     - |     - |    2120 B |
|                      StructLinq_IFunction |   100 |  1.870 μs | 0.0376 μs | 0.1072 μs |  1.901 μs |  0.75 |    0.06 | 0.4807 |     - |     - |    2024 B |
|                                 Hyperlinq |   100 |  2.502 μs | 0.0496 μs | 0.1463 μs |  2.514 μs |  1.00 |    0.08 | 0.4807 |     - |     - |    2024 B |
|                            Hyperlinq_Pool |   100 |  2.343 μs | 0.0462 μs | 0.0975 μs |  2.343 μs |  0.95 |    0.06 | 0.0114 |     - |     - |      56 B |
