## List.ValueType.ListValueTypeWhereSelectToArray

### Source
[ListValueTypeWhereSelectToArray.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelectToArray.cs)

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
|                                ValueLinq_Standard |   100 | 1,988.4 ns | 25.29 ns | 22.42 ns |  1.98 |    0.02 | 3.1433 |     - |     - |    6576 B |
|                                   ValueLinq_Stack |   100 | 1,463.3 ns | 14.77 ns | 13.81 ns |  1.46 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                         ValueLinq_SharedPool_Push |   100 | 1,969.5 ns |  9.56 ns |  7.99 ns |  1.96 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                         ValueLinq_SharedPool_Pull |   100 | 1,737.5 ns |  8.21 ns |  7.28 ns |  1.73 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                            ValueLinq_Ref_Standard |   100 | 1,895.1 ns | 12.45 ns | 11.65 ns |  1.89 |    0.02 | 3.1433 |     - |     - |    6576 B |
|                               ValueLinq_Ref_Stack |   100 | 1,387.8 ns |  6.13 ns |  5.73 ns |  1.38 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                     ValueLinq_Ref_SharedPool_Push |   100 | 1,764.4 ns | 15.76 ns | 14.74 ns |  1.76 |    0.02 | 0.9670 |     - |     - |    2024 B |
|                     ValueLinq_Ref_SharedPool_Pull |   100 | 1,693.9 ns |  6.42 ns |  5.36 ns |  1.68 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                    ValueLinq_ValueLambda_Standard |   100 | 1,605.5 ns |  7.38 ns |  6.54 ns |  1.60 |    0.01 | 3.1433 |     - |     - |    6576 B |
|                       ValueLinq_ValueLambda_Stack |   100 | 1,480.7 ns |  9.22 ns |  8.17 ns |  1.47 |    0.01 | 0.9670 |     - |     - |    2024 B |
|             ValueLinq_ValueLambda_SharedPool_Push |   100 | 1,483.8 ns |  8.76 ns |  7.77 ns |  1.48 |    0.01 | 0.9670 |     - |     - |    2024 B |
|             ValueLinq_ValueLambda_SharedPool_Pull |   100 | 1,642.2 ns |  7.17 ns |  6.36 ns |  1.63 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                ValueLinq_ValueLambda_Ref_Standard |   100 | 1,351.5 ns |  4.32 ns |  3.83 ns |  1.34 |    0.01 | 3.1433 |     - |     - |    6576 B |
|                   ValueLinq_ValueLambda_Ref_Stack |   100 | 1,249.6 ns |  7.01 ns |  5.85 ns |  1.24 |    0.01 | 0.9670 |     - |     - |    2024 B |
|         ValueLinq_ValueLambda_Ref_SharedPool_Push |   100 | 1,249.8 ns |  6.05 ns |  5.36 ns |  1.24 |    0.01 | 0.9670 |     - |     - |    2024 B |
|         ValueLinq_ValueLambda_Ref_SharedPool_Pull |   100 | 1,468.9 ns |  5.63 ns |  5.27 ns |  1.46 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                        ValueLinq_Standard_ByIndex |   100 | 1,730.9 ns | 24.86 ns | 23.26 ns |  1.72 |    0.02 | 3.1433 |     - |     - |    6576 B |
|                           ValueLinq_Stack_ByIndex |   100 | 1,142.6 ns |  8.45 ns |  7.06 ns |  1.14 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                 ValueLinq_SharedPool_Push_ByIndex |   100 | 1,679.9 ns | 22.43 ns | 19.89 ns |  1.67 |    0.02 | 0.9670 |     - |     - |    2024 B |
|                 ValueLinq_SharedPool_Pull_ByIndex |   100 | 1,335.4 ns | 11.61 ns | 10.29 ns |  1.33 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                    ValueLinq_Ref_Standard_ByIndex |   100 | 1,615.5 ns | 12.96 ns | 12.13 ns |  1.61 |    0.01 | 3.1433 |     - |     - |    6576 B |
|                       ValueLinq_Ref_Stack_ByIndex |   100 | 1,031.9 ns |  8.07 ns |  7.15 ns |  1.03 |    0.01 | 0.9670 |     - |     - |    2024 B |
|             ValueLinq_Ref_SharedPool_Push_ByIndex |   100 | 1,483.1 ns | 12.17 ns | 10.79 ns |  1.47 |    0.01 | 0.9670 |     - |     - |    2024 B |
|             ValueLinq_Ref_SharedPool_Pull_ByIndex |   100 | 1,271.9 ns |  3.39 ns |  3.17 ns |  1.26 |    0.01 | 0.9670 |     - |     - |    2024 B |
|            ValueLinq_ValueLambda_Standard_ByIndex |   100 | 1,336.3 ns |  9.20 ns |  8.60 ns |  1.33 |    0.01 | 3.1433 |     - |     - |    6576 B |
|               ValueLinq_ValueLambda_Stack_ByIndex |   100 | 1,116.3 ns |  5.98 ns |  5.59 ns |  1.11 |    0.01 | 0.9670 |     - |     - |    2024 B |
|     ValueLinq_ValueLambda_SharedPool_Push_ByIndex |   100 | 1,222.9 ns |  5.52 ns |  4.89 ns |  1.22 |    0.01 | 0.9670 |     - |     - |    2024 B |
|     ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |   100 | 1,176.8 ns |  6.26 ns |  5.85 ns |  1.17 |    0.01 | 0.9670 |     - |     - |    2024 B |
|        ValueLinq_ValueLambda_Ref_Standard_ByIndex |   100 | 1,315.2 ns |  7.29 ns |  6.46 ns |  1.31 |    0.01 | 3.1433 |     - |     - |    6576 B |
|           ValueLinq_ValueLambda_Ref_Stack_ByIndex |   100 |   911.8 ns |  2.36 ns |  1.97 ns |  0.91 |    0.01 | 0.9670 |     - |     - |    2024 B |
| ValueLinq_ValueLambda_Ref_SharedPool_Push_ByIndex |   100 | 1,201.3 ns |  5.37 ns |  4.76 ns |  1.19 |    0.01 | 0.9670 |     - |     - |    2024 B |
| ValueLinq_ValueLambda_Ref_SharedPool_Pull_ByIndex |   100 | 1,088.7 ns |  3.38 ns |  3.00 ns |  1.08 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                                           ForLoop |   100 | 1,005.5 ns |  6.90 ns |  6.12 ns |  1.00 |    0.00 | 3.4103 |     - |     - |    7136 B |
|                                       ForeachLoop |   100 | 1,238.8 ns | 10.26 ns |  9.59 ns |  1.23 |    0.01 | 3.4103 |     - |     - |    7136 B |
|                                              Linq |   100 | 1,303.3 ns |  7.03 ns |  6.23 ns |  1.30 |    0.01 | 2.4853 |     - |     - |    5200 B |
|                                        LinqFaster |   100 | 1,331.9 ns | 15.51 ns | 14.51 ns |  1.33 |    0.01 | 3.4103 |     - |     - |    7136 B |
|                                            LinqAF |   100 | 2,467.0 ns | 39.86 ns | 37.28 ns |  2.45 |    0.04 | 3.3951 |     - |     - |    7104 B |
|                                        StructLinq |   100 | 1,180.8 ns |  7.90 ns |  6.16 ns |  1.17 |    0.01 | 1.0128 |     - |     - |    2120 B |
|                              StructLinq_IFunction |   100 |   830.6 ns |  5.26 ns |  4.66 ns |  0.83 |    0.00 | 0.9670 |     - |     - |    2024 B |
|                                         Hyperlinq |   100 | 1,370.0 ns | 12.84 ns | 12.01 ns |  1.36 |    0.02 | 0.9670 |     - |     - |    2024 B |
|                               Hyperlinq_IFunction |   100 |   957.2 ns |  4.44 ns |  4.16 ns |  0.95 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                                    Hyperlinq_Pool |   100 | 1,308.8 ns | 15.22 ns | 13.49 ns |  1.30 |    0.02 | 0.0267 |     - |     - |      56 B |
|                          Hyperlinq_Pool_IFunction |   100 |   943.3 ns |  2.46 ns |  2.18 ns |  0.94 |    0.01 | 0.0267 |     - |     - |      56 B |
