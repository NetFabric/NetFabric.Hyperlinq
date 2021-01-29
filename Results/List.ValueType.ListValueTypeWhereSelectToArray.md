## List.ValueType.ListValueTypeWhereSelectToArray

### Source
[ListValueTypeWhereSelectToArray.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelectToArray.cs)

### References:
- Cistern.ValueLinq: [0.0.11](https://www.nuget.org/packages/Cistern.ValueLinq/0.0.11)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta28](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta28)

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
|                                ValueLinq_Standard |   100 | 2,298.6 ns | 15.98 ns | 14.17 ns |  2.00 |    0.02 | 3.1433 |     - |     - |    6576 B |
|                                   ValueLinq_Stack |   100 | 1,688.2 ns | 22.91 ns | 20.31 ns |  1.47 |    0.02 | 0.9670 |     - |     - |    2024 B |
|                         ValueLinq_SharedPool_Push |   100 | 2,481.9 ns | 15.02 ns | 13.32 ns |  2.16 |    0.02 | 0.9651 |     - |     - |    2024 B |
|                         ValueLinq_SharedPool_Pull |   100 | 2,032.0 ns | 10.67 ns |  9.98 ns |  1.77 |    0.02 | 0.9651 |     - |     - |    2024 B |
|                            ValueLinq_Ref_Standard |   100 | 2,156.3 ns | 15.16 ns | 13.44 ns |  1.87 |    0.02 | 3.1433 |     - |     - |    6576 B |
|                               ValueLinq_Ref_Stack |   100 | 1,617.1 ns |  8.88 ns |  7.41 ns |  1.40 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                     ValueLinq_Ref_SharedPool_Push |   100 | 1,970.9 ns | 18.67 ns | 17.47 ns |  1.71 |    0.02 | 0.9651 |     - |     - |    2024 B |
|                     ValueLinq_Ref_SharedPool_Pull |   100 | 1,920.0 ns | 15.16 ns | 14.18 ns |  1.67 |    0.02 | 0.9651 |     - |     - |    2024 B |
|                    ValueLinq_ValueLambda_Standard |   100 | 1,837.0 ns | 23.35 ns | 21.84 ns |  1.59 |    0.02 | 3.1433 |     - |     - |    6576 B |
|                       ValueLinq_ValueLambda_Stack |   100 | 1,674.9 ns |  6.26 ns |  5.55 ns |  1.45 |    0.01 | 0.9670 |     - |     - |    2024 B |
|             ValueLinq_ValueLambda_SharedPool_Push |   100 | 1,704.4 ns |  9.54 ns |  7.97 ns |  1.48 |    0.01 | 0.9670 |     - |     - |    2024 B |
|             ValueLinq_ValueLambda_SharedPool_Pull |   100 | 1,857.2 ns | 12.64 ns | 11.20 ns |  1.61 |    0.02 | 0.9670 |     - |     - |    2024 B |
|                ValueLinq_ValueLambda_Ref_Standard |   100 | 1,512.4 ns | 11.27 ns |  9.99 ns |  1.31 |    0.01 | 3.1433 |     - |     - |    6576 B |
|                   ValueLinq_ValueLambda_Ref_Stack |   100 | 1,423.8 ns |  8.15 ns |  7.22 ns |  1.24 |    0.01 | 0.9670 |     - |     - |    2024 B |
|         ValueLinq_ValueLambda_Ref_SharedPool_Push |   100 | 1,409.1 ns | 10.70 ns |  9.49 ns |  1.22 |    0.01 | 0.9670 |     - |     - |    2024 B |
|         ValueLinq_ValueLambda_Ref_SharedPool_Pull |   100 | 1,673.0 ns |  6.98 ns |  5.83 ns |  1.45 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                        ValueLinq_Standard_ByIndex |   100 | 1,991.1 ns | 15.34 ns | 14.35 ns |  1.73 |    0.02 | 3.1433 |     - |     - |    6576 B |
|                           ValueLinq_Stack_ByIndex |   100 | 1,258.5 ns |  6.01 ns |  5.62 ns |  1.09 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                 ValueLinq_SharedPool_Push_ByIndex |   100 | 1,841.7 ns | 16.66 ns | 15.59 ns |  1.60 |    0.02 | 0.9651 |     - |     - |    2024 B |
|                 ValueLinq_SharedPool_Pull_ByIndex |   100 | 1,510.3 ns | 11.44 ns | 10.14 ns |  1.31 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                    ValueLinq_Ref_Standard_ByIndex |   100 | 1,821.3 ns | 10.70 ns |  9.48 ns |  1.58 |    0.01 | 3.1433 |     - |     - |    6576 B |
|                       ValueLinq_Ref_Stack_ByIndex |   100 | 1,173.8 ns |  4.36 ns |  3.87 ns |  1.02 |    0.01 | 0.9670 |     - |     - |    2024 B |
|             ValueLinq_Ref_SharedPool_Push_ByIndex |   100 | 1,747.4 ns |  6.17 ns |  5.77 ns |  1.52 |    0.01 | 0.9670 |     - |     - |    2024 B |
|             ValueLinq_Ref_SharedPool_Pull_ByIndex |   100 | 1,431.7 ns |  6.94 ns |  6.15 ns |  1.24 |    0.01 | 0.9670 |     - |     - |    2024 B |
|            ValueLinq_ValueLambda_Standard_ByIndex |   100 | 1,485.2 ns | 13.11 ns | 12.26 ns |  1.29 |    0.02 | 3.1433 |     - |     - |    6576 B |
|               ValueLinq_ValueLambda_Stack_ByIndex |   100 | 1,242.0 ns |  5.55 ns |  4.92 ns |  1.08 |    0.01 | 0.9670 |     - |     - |    2024 B |
|     ValueLinq_ValueLambda_SharedPool_Push_ByIndex |   100 | 1,361.9 ns | 12.23 ns | 11.44 ns |  1.18 |    0.01 | 0.9670 |     - |     - |    2024 B |
|     ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |   100 | 1,342.1 ns |  7.25 ns |  6.43 ns |  1.17 |    0.01 | 0.9670 |     - |     - |    2024 B |
|        ValueLinq_ValueLambda_Ref_Standard_ByIndex |   100 | 1,483.3 ns | 15.00 ns | 13.30 ns |  1.29 |    0.01 | 3.1433 |     - |     - |    6576 B |
|           ValueLinq_ValueLambda_Ref_Stack_ByIndex |   100 | 1,039.4 ns | 13.89 ns | 12.31 ns |  0.90 |    0.01 | 0.9670 |     - |     - |    2024 B |
| ValueLinq_ValueLambda_Ref_SharedPool_Push_ByIndex |   100 | 1,378.0 ns |  7.09 ns |  6.29 ns |  1.20 |    0.01 | 0.9670 |     - |     - |    2024 B |
| ValueLinq_ValueLambda_Ref_SharedPool_Pull_ByIndex |   100 | 1,224.8 ns |  6.63 ns |  5.88 ns |  1.06 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                                           ForLoop |   100 | 1,151.5 ns |  8.75 ns |  7.75 ns |  1.00 |    0.00 | 3.4103 |     - |     - |    7136 B |
|                                       ForeachLoop |   100 | 1,418.1 ns |  5.43 ns |  4.24 ns |  1.23 |    0.01 | 3.4103 |     - |     - |    7136 B |
|                                              Linq |   100 | 1,474.9 ns |  3.56 ns |  2.97 ns |  1.28 |    0.01 | 2.4853 |     - |     - |    5200 B |
|                                        LinqFaster |   100 | 1,552.2 ns | 11.18 ns | 10.46 ns |  1.35 |    0.01 | 3.4103 |     - |     - |    7136 B |
|                                            LinqAF |   100 | 2,709.0 ns | 32.06 ns | 28.42 ns |  2.35 |    0.03 | 3.3951 |     - |     - |    7104 B |
|                                        StructLinq |   100 | 1,361.5 ns | 11.89 ns | 10.54 ns |  1.18 |    0.01 | 1.0166 |     - |     - |    2128 B |
|                              StructLinq_IFunction |   100 |   982.2 ns |  6.60 ns |  5.85 ns |  0.85 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                                         Hyperlinq |   100 | 1,504.8 ns |  9.67 ns |  9.05 ns |  1.31 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                               Hyperlinq_IFunction |   100 | 1,078.2 ns |  4.62 ns |  4.32 ns |  0.94 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                                    Hyperlinq_Pool |   100 | 1,386.2 ns |  6.12 ns |  5.72 ns |  1.20 |    0.01 | 0.0267 |     - |     - |      56 B |
|                          Hyperlinq_Pool_IFunction |   100 |   983.2 ns |  3.40 ns |  3.18 ns |  0.85 |    0.01 | 0.0267 |     - |     - |      56 B |
