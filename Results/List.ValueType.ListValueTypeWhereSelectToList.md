## List.ValueType.ListValueTypeWhereSelectToList

### Source
[ListValueTypeWhereSelectToList.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelectToList.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta32](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta32)

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
|                            ValueLinq_Standard |   100 | 1,430.7 ns |  8.05 ns |  6.72 ns |  1.60 |    0.01 | 2.4433 |     - |     - |   4.99 KB |
|                               ValueLinq_Stack |   100 | 1,395.4 ns |  9.96 ns |  8.32 ns |  1.56 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|                     ValueLinq_SharedPool_Push |   100 | 1,742.2 ns | 14.52 ns | 12.12 ns |  1.94 |    0.02 | 0.9823 |     - |     - |   2.01 KB |
|                     ValueLinq_SharedPool_Pull |   100 | 1,655.3 ns |  3.67 ns |  2.86 ns |  1.85 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|                        ValueLinq_Ref_Standard |   100 | 1,323.0 ns |  7.62 ns |  6.75 ns |  1.48 |    0.01 | 2.4433 |     - |     - |   4.99 KB |
|                           ValueLinq_Ref_Stack |   100 | 1,311.0 ns |  9.61 ns |  7.50 ns |  1.46 |    0.02 | 0.9823 |     - |     - |   2.01 KB |
|                 ValueLinq_Ref_SharedPool_Push |   100 | 1,562.4 ns |  5.77 ns |  5.11 ns |  1.74 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|                 ValueLinq_Ref_SharedPool_Pull |   100 | 1,577.1 ns |  7.05 ns |  6.60 ns |  1.76 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|                ValueLinq_ValueLambda_Standard |   100 | 1,119.6 ns |  9.06 ns |  7.56 ns |  1.25 |    0.01 | 2.4433 |     - |     - |   4.99 KB |
|                   ValueLinq_ValueLambda_Stack |   100 | 1,306.3 ns |  6.89 ns |  6.44 ns |  1.46 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|         ValueLinq_ValueLambda_SharedPool_Push |   100 | 1,383.0 ns |  8.65 ns |  7.22 ns |  1.54 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|         ValueLinq_ValueLambda_SharedPool_Pull |   100 | 1,514.8 ns |  9.74 ns |  8.63 ns |  1.69 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|                    ValueLinq_Standard_ByIndex |   100 | 1,428.1 ns | 11.88 ns | 10.53 ns |  1.59 |    0.02 | 2.4433 |     - |     - |   4.99 KB |
|                       ValueLinq_Stack_ByIndex |   100 | 1,188.8 ns |  7.54 ns |  7.05 ns |  1.33 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|             ValueLinq_SharedPool_Push_ByIndex |   100 | 1,740.2 ns |  9.35 ns |  7.81 ns |  1.94 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|             ValueLinq_SharedPool_Pull_ByIndex |   100 | 1,480.1 ns | 10.43 ns |  9.25 ns |  1.65 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|                ValueLinq_Ref_Standard_ByIndex |   100 | 1,337.2 ns |  9.36 ns |  7.82 ns |  1.49 |    0.01 | 2.4433 |     - |     - |   4.99 KB |
|                   ValueLinq_Ref_Stack_ByIndex |   100 | 1,094.1 ns |  5.62 ns |  4.69 ns |  1.22 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|         ValueLinq_Ref_SharedPool_Push_ByIndex |   100 | 1,571.8 ns |  3.94 ns |  3.29 ns |  1.75 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|         ValueLinq_Ref_SharedPool_Pull_ByIndex |   100 | 1,393.6 ns |  7.88 ns |  6.58 ns |  1.55 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|        ValueLinq_ValueLambda_Standard_ByIndex |   100 | 1,504.5 ns |  4.84 ns |  4.53 ns |  1.68 |    0.01 | 2.4433 |     - |     - |   4.99 KB |
|           ValueLinq_ValueLambda_Stack_ByIndex |   100 | 1,099.5 ns |  6.82 ns |  6.38 ns |  1.23 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |   100 | 1,390.5 ns |  4.99 ns |  4.67 ns |  1.55 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |   100 | 1,324.9 ns |  8.07 ns |  7.55 ns |  1.48 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|                                       ForLoop |   100 |   895.6 ns |  6.37 ns |  5.96 ns |  1.00 |    0.00 | 2.4433 |     - |     - |   4.99 KB |
|                                   ForeachLoop |   100 | 1,101.4 ns | 10.53 ns |  9.85 ns |  1.23 |    0.01 | 2.4433 |     - |     - |   4.99 KB |
|                                          Linq |   100 | 1,291.4 ns | 12.82 ns | 11.99 ns |  1.44 |    0.02 | 2.5768 |     - |     - |   5.27 KB |
|                                    LinqFaster |   100 | 1,418.6 ns | 10.52 ns |  9.84 ns |  1.58 |    0.01 | 3.4237 |     - |     - |      7 KB |
|                                        LinqAF |   100 | 2,416.3 ns | 29.74 ns | 27.82 ns |  2.70 |    0.04 | 2.4414 |     - |     - |   4.99 KB |
|                                    StructLinq |   100 | 1,235.1 ns |  8.60 ns |  7.18 ns |  1.38 |    0.01 | 1.0319 |     - |     - |   2.11 KB |
|                          StructLinq_IFunction |   100 |   874.6 ns |  9.70 ns |  9.08 ns |  0.98 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|                                     Hyperlinq |   100 | 1,104.7 ns |  5.28 ns |  4.68 ns |  1.23 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|                           Hyperlinq_IFunction |   100 |   827.0 ns |  2.95 ns |  2.61 ns |  0.92 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
