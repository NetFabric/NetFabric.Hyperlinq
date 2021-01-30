## List.ValueType.ListValueTypeWhereSelectToList

### Source
[ListValueTypeWhereSelectToList.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelectToList.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta29](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta29)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                                        Method | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------------------------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                            ValueLinq_Standard |   100 | 1,406.8 ns | 11.34 ns | 10.05 ns |  1.57 |    0.01 | 2.4433 |     - |     - |   4.99 KB |
|                               ValueLinq_Stack |   100 | 1,355.0 ns |  8.43 ns |  7.88 ns |  1.51 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|                     ValueLinq_SharedPool_Push |   100 | 1,724.6 ns | 16.43 ns | 14.57 ns |  1.92 |    0.02 | 0.9823 |     - |     - |   2.01 KB |
|                     ValueLinq_SharedPool_Pull |   100 | 1,698.4 ns |  6.26 ns |  5.85 ns |  1.89 |    0.02 | 0.9823 |     - |     - |   2.01 KB |
|                        ValueLinq_Ref_Standard |   100 | 1,290.8 ns |  6.04 ns |  5.36 ns |  1.44 |    0.01 | 2.4433 |     - |     - |   4.99 KB |
|                           ValueLinq_Ref_Stack |   100 | 1,300.2 ns |  3.58 ns |  3.35 ns |  1.45 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|                 ValueLinq_Ref_SharedPool_Push |   100 | 1,546.7 ns |  5.87 ns |  5.20 ns |  1.72 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|                 ValueLinq_Ref_SharedPool_Pull |   100 | 1,541.3 ns |  4.34 ns |  3.85 ns |  1.72 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|                ValueLinq_ValueLambda_Standard |   100 | 1,096.7 ns |  5.04 ns |  4.71 ns |  1.22 |    0.01 | 2.4433 |     - |     - |   4.99 KB |
|                   ValueLinq_ValueLambda_Stack |   100 | 1,274.6 ns |  8.30 ns |  7.36 ns |  1.42 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|         ValueLinq_ValueLambda_SharedPool_Push |   100 | 1,344.3 ns |  5.71 ns |  5.06 ns |  1.50 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|         ValueLinq_ValueLambda_SharedPool_Pull |   100 | 1,507.5 ns |  3.20 ns |  2.67 ns |  1.68 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|                    ValueLinq_Standard_ByIndex |   100 | 1,421.2 ns | 11.06 ns | 10.35 ns |  1.58 |    0.01 | 2.4433 |     - |     - |   4.99 KB |
|                       ValueLinq_Stack_ByIndex |   100 | 1,194.7 ns |  7.43 ns |  6.21 ns |  1.33 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|             ValueLinq_SharedPool_Push_ByIndex |   100 | 1,757.7 ns | 13.53 ns | 11.99 ns |  1.96 |    0.02 | 0.9823 |     - |     - |   2.01 KB |
|             ValueLinq_SharedPool_Pull_ByIndex |   100 | 1,445.5 ns |  6.86 ns |  6.42 ns |  1.61 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|                ValueLinq_Ref_Standard_ByIndex |   100 | 1,317.3 ns |  7.48 ns |  6.63 ns |  1.47 |    0.01 | 2.4433 |     - |     - |   4.99 KB |
|                   ValueLinq_Ref_Stack_ByIndex |   100 | 1,095.4 ns |  6.32 ns |  5.60 ns |  1.22 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|         ValueLinq_Ref_SharedPool_Push_ByIndex |   100 | 1,564.8 ns |  6.34 ns |  5.62 ns |  1.74 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|         ValueLinq_Ref_SharedPool_Pull_ByIndex |   100 | 1,385.6 ns |  4.05 ns |  3.59 ns |  1.55 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|        ValueLinq_ValueLambda_Standard_ByIndex |   100 | 1,123.0 ns |  4.25 ns |  3.55 ns |  1.25 |    0.01 | 2.4433 |     - |     - |   4.99 KB |
|           ValueLinq_ValueLambda_Stack_ByIndex |   100 | 1,086.5 ns |  5.23 ns |  4.64 ns |  1.21 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |   100 | 1,364.0 ns |  5.28 ns |  4.94 ns |  1.52 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |   100 | 1,305.5 ns |  6.14 ns |  5.44 ns |  1.46 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|                                       ForLoop |   100 |   897.3 ns |  5.94 ns |  5.56 ns |  1.00 |    0.00 | 2.4433 |     - |     - |   4.99 KB |
|                                   ForeachLoop |   100 | 1,104.5 ns |  8.27 ns |  7.74 ns |  1.23 |    0.01 | 2.4433 |     - |     - |   4.99 KB |
|                                          Linq |   100 | 1,298.9 ns |  8.56 ns |  6.68 ns |  1.45 |    0.01 | 2.5768 |     - |     - |   5.27 KB |
|                                    LinqFaster |   100 | 1,407.1 ns | 12.79 ns | 11.96 ns |  1.57 |    0.02 | 3.4237 |     - |     - |      7 KB |
|                                        LinqAF |   100 | 2,441.2 ns | 23.26 ns | 19.42 ns |  2.72 |    0.02 | 2.4414 |     - |     - |   4.99 KB |
|                                    StructLinq |   100 | 1,196.8 ns |  5.93 ns |  5.26 ns |  1.33 |    0.01 | 1.0319 |     - |     - |   2.11 KB |
|                          StructLinq_IFunction |   100 |   868.2 ns |  2.35 ns |  2.08 ns |  0.97 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|                                     Hyperlinq |   100 | 1,355.3 ns | 17.17 ns | 16.06 ns |  1.51 |    0.02 | 1.0166 |     - |     - |   2.08 KB |
|                           Hyperlinq_IFunction |   100 |   984.7 ns |  3.98 ns |  3.72 ns |  1.10 |    0.01 | 1.0166 |     - |     - |   2.08 KB |
