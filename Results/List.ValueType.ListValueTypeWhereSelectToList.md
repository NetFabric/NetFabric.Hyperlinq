## List.ValueType.ListValueTypeWhereSelectToList

### Source
[ListValueTypeWhereSelectToList.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelectToList.cs)

### References:
- Cistern.ValueLinq: [0.0.11](https://www.nuget.org/packages/Cistern.ValueLinq/0.0.11)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.19.2](https://www.nuget.org/packages/StructLinq.BCL/0.19.2)
- NetFabric.Hyperlinq: [3.0.0-beta27](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta27)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                                            Method | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------------------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                                ValueLinq_Standard |   100 | 1,789.3 ns | 19.71 ns | 18.44 ns |  2.05 |    0.03 | 2.4433 |     - |     - |   4.99 KB |
|                                   ValueLinq_Stack |   100 | 1,589.6 ns | 10.55 ns |  9.35 ns |  1.82 |    0.02 | 0.9823 |     - |     - |   2.01 KB |
|                         ValueLinq_SharedPool_Push |   100 | 2,051.3 ns | 22.85 ns | 20.25 ns |  2.35 |    0.03 | 0.9804 |     - |     - |   2.01 KB |
|                         ValueLinq_SharedPool_Pull |   100 | 1,909.1 ns | 10.93 ns |  9.13 ns |  2.19 |    0.01 | 0.9804 |     - |     - |   2.01 KB |
|                            ValueLinq_Ref_Standard |   100 | 1,651.6 ns | 14.84 ns | 13.15 ns |  1.89 |    0.02 | 2.4433 |     - |     - |   4.99 KB |
|                               ValueLinq_Ref_Stack |   100 | 1,534.1 ns |  8.02 ns |  7.50 ns |  1.76 |    0.02 | 0.9823 |     - |     - |   2.01 KB |
|                     ValueLinq_Ref_SharedPool_Push |   100 | 1,911.1 ns | 10.31 ns |  9.64 ns |  2.19 |    0.02 | 0.9823 |     - |     - |   2.01 KB |
|                     ValueLinq_Ref_SharedPool_Pull |   100 | 1,862.0 ns |  3.47 ns |  2.89 ns |  2.14 |    0.02 | 0.9823 |     - |     - |   2.01 KB |
|                    ValueLinq_ValueLambda_Standard |   100 | 1,338.1 ns |  7.97 ns |  7.45 ns |  1.53 |    0.01 | 2.4433 |     - |     - |   4.99 KB |
|                       ValueLinq_ValueLambda_Stack |   100 | 1,594.0 ns | 11.43 ns | 10.69 ns |  1.83 |    0.02 | 0.9823 |     - |     - |   2.01 KB |
|             ValueLinq_ValueLambda_SharedPool_Push |   100 | 1,599.1 ns |  7.64 ns |  6.78 ns |  1.83 |    0.02 | 0.9823 |     - |     - |   2.01 KB |
|             ValueLinq_ValueLambda_SharedPool_Pull |   100 | 1,732.7 ns |  7.29 ns |  6.46 ns |  1.99 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|                ValueLinq_ValueLambda_Ref_Standard |   100 | 1,080.1 ns |  6.67 ns |  5.92 ns |  1.24 |    0.01 | 2.4433 |     - |     - |   4.99 KB |
|                   ValueLinq_ValueLambda_Ref_Stack |   100 | 1,359.2 ns |  5.76 ns |  5.10 ns |  1.56 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|         ValueLinq_ValueLambda_Ref_SharedPool_Push |   100 | 1,359.8 ns |  4.94 ns |  4.38 ns |  1.56 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|         ValueLinq_ValueLambda_Ref_SharedPool_Pull |   100 | 1,609.6 ns |  7.47 ns |  6.24 ns |  1.85 |    0.02 | 0.9823 |     - |     - |   2.01 KB |
|                        ValueLinq_Standard_ByIndex |   100 | 1,522.0 ns | 17.33 ns | 15.36 ns |  1.75 |    0.02 | 2.4433 |     - |     - |   4.99 KB |
|                           ValueLinq_Stack_ByIndex |   100 | 1,208.3 ns |  8.35 ns |  7.81 ns |  1.39 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|                 ValueLinq_SharedPool_Push_ByIndex |   100 | 1,779.8 ns | 26.68 ns | 22.28 ns |  2.04 |    0.03 | 0.9823 |     - |     - |   2.01 KB |
|                 ValueLinq_SharedPool_Pull_ByIndex |   100 | 1,459.8 ns |  8.62 ns |  7.20 ns |  1.67 |    0.02 | 0.9823 |     - |     - |   2.01 KB |
|                    ValueLinq_Ref_Standard_ByIndex |   100 | 1,371.9 ns | 12.17 ns | 11.38 ns |  1.57 |    0.02 | 2.4433 |     - |     - |   4.99 KB |
|                       ValueLinq_Ref_Stack_ByIndex |   100 | 1,135.7 ns |  5.98 ns |  5.60 ns |  1.30 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|             ValueLinq_Ref_SharedPool_Push_ByIndex |   100 | 1,638.5 ns | 14.47 ns | 13.53 ns |  1.88 |    0.02 | 0.9823 |     - |     - |   2.01 KB |
|             ValueLinq_Ref_SharedPool_Pull_ByIndex |   100 | 1,391.9 ns |  4.39 ns |  3.89 ns |  1.60 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|            ValueLinq_ValueLambda_Standard_ByIndex |   100 | 1,105.3 ns |  7.01 ns |  6.56 ns |  1.27 |    0.01 | 2.4433 |     - |     - |   4.99 KB |
|               ValueLinq_ValueLambda_Stack_ByIndex |   100 | 1,228.5 ns |  8.33 ns |  7.79 ns |  1.41 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|     ValueLinq_ValueLambda_SharedPool_Push_ByIndex |   100 | 1,317.9 ns |  5.37 ns |  4.48 ns |  1.51 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|     ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |   100 | 1,311.4 ns |  5.05 ns |  4.72 ns |  1.50 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|        ValueLinq_ValueLambda_Ref_Standard_ByIndex |   100 | 1,109.5 ns |  6.02 ns |  5.34 ns |  1.27 |    0.01 | 2.4433 |     - |     - |   4.99 KB |
|           ValueLinq_ValueLambda_Ref_Stack_ByIndex |   100 | 1,026.5 ns |  4.97 ns |  4.65 ns |  1.18 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
| ValueLinq_ValueLambda_Ref_SharedPool_Push_ByIndex |   100 | 1,305.6 ns |  4.47 ns |  4.18 ns |  1.50 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
| ValueLinq_ValueLambda_Ref_SharedPool_Pull_ByIndex |   100 | 1,217.8 ns |  5.33 ns |  4.73 ns |  1.40 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|                                           ForLoop |   100 |   871.8 ns |  6.65 ns |  5.90 ns |  1.00 |    0.00 | 2.4433 |     - |     - |   4.99 KB |
|                                       ForeachLoop |   100 | 1,088.9 ns | 11.13 ns | 10.41 ns |  1.25 |    0.02 | 2.4433 |     - |     - |   4.99 KB |
|                                              Linq |   100 | 1,277.0 ns |  8.34 ns |  7.40 ns |  1.46 |    0.02 | 2.5768 |     - |     - |   5.27 KB |
|                                        LinqFaster |   100 | 1,389.4 ns | 16.30 ns | 14.45 ns |  1.59 |    0.01 | 3.4237 |     - |     - |      7 KB |
|                                            LinqAF |   100 | 2,422.4 ns | 34.18 ns | 70.58 ns |  2.84 |    0.13 | 2.4414 |     - |     - |   4.99 KB |
|                                        StructLinq |   100 | 1,171.4 ns |  5.94 ns |  5.56 ns |  1.34 |    0.01 | 1.0281 |     - |     - |    2.1 KB |
|                              StructLinq_IFunction |   100 |   853.2 ns | 16.12 ns | 13.46 ns |  0.98 |    0.02 | 0.9823 |     - |     - |   2.01 KB |
|                                         Hyperlinq |   100 | 1,396.1 ns | 18.88 ns | 16.73 ns |  1.60 |    0.02 | 1.0166 |     - |     - |   2.08 KB |
|                               Hyperlinq_IFunction |   100 |   974.7 ns |  5.05 ns |  4.47 ns |  1.12 |    0.01 | 1.0166 |     - |     - |   2.08 KB |
