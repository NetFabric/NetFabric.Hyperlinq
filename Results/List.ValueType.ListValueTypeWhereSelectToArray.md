## List.ValueType.ListValueTypeWhereSelectToArray

### Source
[ListValueTypeWhereSelectToArray.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelectToArray.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta31](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta31)

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
|                            ValueLinq_Standard |   100 | 1,309.1 ns |  4.79 ns |  4.25 ns |  1.26 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                               ValueLinq_Stack |   100 | 1,258.7 ns | 14.99 ns | 14.02 ns |  1.21 |    0.02 | 0.9651 |     - |     - |    2024 B |
|                     ValueLinq_SharedPool_Push |   100 | 1,600.8 ns | 14.72 ns | 13.77 ns |  1.54 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                     ValueLinq_SharedPool_Pull |   100 | 1,535.1 ns |  6.30 ns |  5.58 ns |  1.47 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                        ValueLinq_Ref_Standard |   100 | 1,205.4 ns |  4.33 ns |  3.61 ns |  1.16 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                           ValueLinq_Ref_Stack |   100 | 1,171.4 ns |  4.51 ns |  4.22 ns |  1.12 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                 ValueLinq_Ref_SharedPool_Push |   100 | 1,423.6 ns |  3.94 ns |  3.29 ns |  1.37 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                 ValueLinq_Ref_SharedPool_Pull |   100 | 1,432.1 ns |  6.67 ns |  5.57 ns |  1.38 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                ValueLinq_ValueLambda_Standard |   100 | 1,190.2 ns | 13.98 ns | 13.08 ns |  1.14 |    0.02 | 0.9670 |     - |     - |    2024 B |
|                   ValueLinq_ValueLambda_Stack |   100 | 1,165.2 ns |  8.70 ns |  7.71 ns |  1.12 |    0.01 | 0.9670 |     - |     - |    2024 B |
|         ValueLinq_ValueLambda_SharedPool_Push |   100 | 1,244.8 ns |  3.64 ns |  3.23 ns |  1.19 |    0.01 | 0.9670 |     - |     - |    2024 B |
|         ValueLinq_ValueLambda_SharedPool_Pull |   100 | 1,389.5 ns |  7.84 ns |  7.34 ns |  1.33 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                    ValueLinq_Standard_ByIndex |   100 | 1,092.7 ns |  5.08 ns |  4.50 ns |  1.05 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                       ValueLinq_Stack_ByIndex |   100 | 1,094.9 ns |  7.02 ns |  6.22 ns |  1.05 |    0.01 | 0.9670 |     - |     - |    2024 B |
|             ValueLinq_SharedPool_Push_ByIndex |   100 | 1,619.1 ns | 13.84 ns | 12.27 ns |  1.55 |    0.01 | 0.9670 |     - |     - |    2024 B |
|             ValueLinq_SharedPool_Pull_ByIndex |   100 | 1,371.4 ns |  9.66 ns |  8.56 ns |  1.32 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                ValueLinq_Ref_Standard_ByIndex |   100 | 1,023.5 ns |  2.29 ns |  1.91 ns |  0.98 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                   ValueLinq_Ref_Stack_ByIndex |   100 |   984.8 ns |  5.64 ns |  4.71 ns |  0.95 |    0.01 | 0.9670 |     - |     - |    2024 B |
|         ValueLinq_Ref_SharedPool_Push_ByIndex |   100 | 1,465.4 ns |  4.80 ns |  4.01 ns |  1.41 |    0.01 | 0.9670 |     - |     - |    2024 B |
|         ValueLinq_Ref_SharedPool_Pull_ByIndex |   100 | 1,250.6 ns |  6.98 ns |  6.18 ns |  1.20 |    0.01 | 0.9670 |     - |     - |    2024 B |
|        ValueLinq_ValueLambda_Standard_ByIndex |   100 | 1,026.8 ns |  6.29 ns |  5.58 ns |  0.99 |    0.01 | 0.9670 |     - |     - |    2024 B |
|           ValueLinq_ValueLambda_Stack_ByIndex |   100 |   970.0 ns |  3.50 ns |  2.92 ns |  0.93 |    0.01 | 0.9670 |     - |     - |    2024 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |   100 | 1,214.1 ns |  5.41 ns |  4.52 ns |  1.17 |    0.01 | 0.9670 |     - |     - |    2024 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |   100 | 1,233.2 ns |  3.64 ns |  3.22 ns |  1.18 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                                       ForLoop |   100 | 1,042.1 ns |  8.03 ns |  7.12 ns |  1.00 |    0.00 | 3.4103 |     - |     - |    7136 B |
|                                   ForeachLoop |   100 | 1,237.4 ns |  9.84 ns |  8.72 ns |  1.19 |    0.01 | 3.4103 |     - |     - |    7136 B |
|                                          Linq |   100 | 1,323.6 ns | 16.62 ns | 13.88 ns |  1.27 |    0.02 | 2.4853 |     - |     - |    5200 B |
|                                    LinqFaster |   100 | 1,394.3 ns | 15.58 ns | 13.81 ns |  1.34 |    0.01 | 3.4103 |     - |     - |    7136 B |
|                                        LinqAF |   100 | 2,428.8 ns | 35.19 ns | 31.20 ns |  2.33 |    0.04 | 3.3951 |     - |     - |    7104 B |
|                                    StructLinq |   100 | 1,194.5 ns |  5.70 ns |  5.05 ns |  1.15 |    0.01 | 1.0166 |     - |     - |    2128 B |
|                          StructLinq_IFunction |   100 |   841.2 ns |  3.81 ns |  3.38 ns |  0.81 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                                     Hyperlinq |   100 | 1,063.4 ns |  9.14 ns |  8.10 ns |  1.02 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                           Hyperlinq_IFunction |   100 |   829.4 ns |  3.67 ns |  3.25 ns |  0.80 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                                Hyperlinq_Pool |   100 | 1,016.4 ns |  1.84 ns |  1.72 ns |  0.98 |    0.01 | 0.0267 |     - |     - |      56 B |
|                      Hyperlinq_Pool_IFunction |   100 |   780.0 ns |  1.31 ns |  1.23 ns |  0.75 |    0.00 | 0.0267 |     - |     - |      56 B |
