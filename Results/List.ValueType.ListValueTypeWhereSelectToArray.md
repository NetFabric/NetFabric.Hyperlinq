## List.ValueType.ListValueTypeWhereSelectToArray

### Source
[ListValueTypeWhereSelectToArray.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelectToArray.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta34](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta34)

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
|                            ValueLinq_Standard |   100 | 1,383.3 ns | 10.39 ns |  9.72 ns |  1.30 |    0.01 | 1.0433 |     - |     - |    2184 B |
|                               ValueLinq_Stack |   100 | 1,451.8 ns |  9.17 ns |  8.57 ns |  1.37 |    0.01 | 1.0433 |     - |     - |    2184 B |
|                     ValueLinq_SharedPool_Push |   100 | 1,645.0 ns | 11.02 ns |  9.77 ns |  1.55 |    0.01 | 1.0433 |     - |     - |    2184 B |
|                     ValueLinq_SharedPool_Pull |   100 | 1,625.1 ns | 12.50 ns | 11.08 ns |  1.53 |    0.01 | 1.0433 |     - |     - |    2184 B |
|                        ValueLinq_Ref_Standard |   100 | 1,278.1 ns |  1.77 ns |  1.48 ns |  1.21 |    0.01 | 1.0433 |     - |     - |    2184 B |
|                           ValueLinq_Ref_Stack |   100 | 1,236.6 ns |  2.26 ns |  2.00 ns |  1.17 |    0.01 | 1.0433 |     - |     - |    2184 B |
|                 ValueLinq_Ref_SharedPool_Push |   100 | 1,517.6 ns |  5.11 ns |  4.78 ns |  1.43 |    0.01 | 1.0433 |     - |     - |    2184 B |
|                 ValueLinq_Ref_SharedPool_Pull |   100 | 1,590.1 ns |  7.97 ns |  7.45 ns |  1.50 |    0.01 | 1.0433 |     - |     - |    2184 B |
|                ValueLinq_ValueLambda_Standard |   100 | 1,289.3 ns |  8.67 ns |  7.69 ns |  1.22 |    0.01 | 1.0433 |     - |     - |    2184 B |
|                   ValueLinq_ValueLambda_Stack |   100 | 1,198.8 ns |  4.67 ns |  4.37 ns |  1.13 |    0.01 | 1.0433 |     - |     - |    2184 B |
|         ValueLinq_ValueLambda_SharedPool_Push |   100 | 1,236.1 ns |  5.86 ns |  5.20 ns |  1.17 |    0.01 | 1.0433 |     - |     - |    2184 B |
|         ValueLinq_ValueLambda_SharedPool_Pull |   100 | 1,445.3 ns | 10.64 ns |  9.95 ns |  1.36 |    0.01 | 1.0433 |     - |     - |    2184 B |
|                    ValueLinq_Standard_ByIndex |   100 | 1,184.4 ns |  4.72 ns |  4.19 ns |  1.12 |    0.01 | 1.0433 |     - |     - |    2184 B |
|                       ValueLinq_Stack_ByIndex |   100 | 1,156.0 ns |  6.52 ns |  5.45 ns |  1.09 |    0.01 | 1.0433 |     - |     - |    2184 B |
|             ValueLinq_SharedPool_Push_ByIndex |   100 | 1,662.6 ns | 10.64 ns |  9.43 ns |  1.57 |    0.01 | 1.0433 |     - |     - |    2184 B |
|             ValueLinq_SharedPool_Pull_ByIndex |   100 | 1,442.3 ns |  5.18 ns |  4.60 ns |  1.36 |    0.01 | 1.0433 |     - |     - |    2184 B |
|                ValueLinq_Ref_Standard_ByIndex |   100 | 1,081.7 ns |  2.61 ns |  2.32 ns |  1.02 |    0.01 | 1.0433 |     - |     - |    2184 B |
|                   ValueLinq_Ref_Stack_ByIndex |   100 | 1,044.3 ns |  4.18 ns |  3.71 ns |  0.98 |    0.01 | 1.0433 |     - |     - |    2184 B |
|         ValueLinq_Ref_SharedPool_Push_ByIndex |   100 | 1,498.8 ns |  3.93 ns |  3.68 ns |  1.41 |    0.01 | 1.0433 |     - |     - |    2184 B |
|         ValueLinq_Ref_SharedPool_Pull_ByIndex |   100 | 1,346.4 ns |  5.72 ns |  5.07 ns |  1.27 |    0.01 | 1.0433 |     - |     - |    2184 B |
|        ValueLinq_ValueLambda_Standard_ByIndex |   100 | 1,073.1 ns |  7.68 ns |  6.41 ns |  1.01 |    0.01 | 1.0433 |     - |     - |    2184 B |
|           ValueLinq_ValueLambda_Stack_ByIndex |   100 | 1,035.7 ns |  4.54 ns |  4.03 ns |  0.98 |    0.00 | 1.0433 |     - |     - |    2184 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |   100 | 1,280.9 ns |  3.91 ns |  3.66 ns |  1.21 |    0.01 | 1.0433 |     - |     - |    2184 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |   100 | 1,288.2 ns |  4.86 ns |  4.31 ns |  1.21 |    0.01 | 1.0433 |     - |     - |    2184 B |
|                                       ForLoop |   100 | 1,060.6 ns |  5.64 ns |  4.71 ns |  1.00 |    0.00 | 3.4866 |     - |     - |    7296 B |
|                                   ForeachLoop |   100 | 1,276.2 ns |  6.89 ns |  6.11 ns |  1.20 |    0.01 | 3.4866 |     - |     - |    7296 B |
|                                          Linq |   100 | 1,362.5 ns | 11.52 ns | 10.77 ns |  1.29 |    0.01 | 2.5616 |     - |     - |    5360 B |
|                                    LinqFaster |   100 | 1,410.1 ns |  7.45 ns |  6.97 ns |  1.33 |    0.01 | 3.4866 |     - |     - |    7296 B |
|                                        LinqAF |   100 | 2,792.3 ns | 21.47 ns | 20.08 ns |  2.63 |    0.02 | 3.4714 |     - |     - |    7264 B |
|                                    StructLinq |   100 | 1,230.9 ns |  5.43 ns |  5.08 ns |  1.16 |    0.01 | 1.0929 |     - |     - |    2288 B |
|                          StructLinq_IFunction |   100 |   871.9 ns |  3.06 ns |  2.56 ns |  0.82 |    0.00 | 1.0433 |     - |     - |    2184 B |
|                                     Hyperlinq |   100 | 1,122.9 ns |  5.28 ns |  4.41 ns |  1.06 |    0.00 | 1.0433 |     - |     - |    2184 B |
|                           Hyperlinq_IFunction |   100 |   874.0 ns |  3.92 ns |  3.48 ns |  0.82 |    0.01 | 1.0433 |     - |     - |    2184 B |
|                                Hyperlinq_Pool |   100 | 1,562.9 ns |  3.83 ns |  3.40 ns |  1.47 |    0.01 | 0.0267 |     - |     - |      56 B |
|                      Hyperlinq_Pool_IFunction |   100 |   826.2 ns |  1.10 ns |  0.97 ns |  0.78 |    0.00 | 0.0267 |     - |     - |      56 B |
