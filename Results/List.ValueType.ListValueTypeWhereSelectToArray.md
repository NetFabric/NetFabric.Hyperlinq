## List.ValueType.ListValueTypeWhereSelectToArray

### Source
[ListValueTypeWhereSelectToArray.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelectToArray.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta30](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta30)

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
|                            ValueLinq_Standard |   100 | 1,278.7 ns |  7.89 ns |  6.99 ns |  1.25 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                               ValueLinq_Stack |   100 | 1,356.8 ns |  9.22 ns |  8.62 ns |  1.33 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                     ValueLinq_SharedPool_Push |   100 | 1,632.3 ns | 15.08 ns | 14.11 ns |  1.60 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                     ValueLinq_SharedPool_Pull |   100 | 1,484.1 ns |  8.31 ns |  7.37 ns |  1.46 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                        ValueLinq_Ref_Standard |   100 | 1,230.7 ns |  5.91 ns |  5.53 ns |  1.21 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                           ValueLinq_Ref_Stack |   100 | 1,191.3 ns |  3.12 ns |  2.77 ns |  1.17 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                 ValueLinq_Ref_SharedPool_Push |   100 | 1,435.1 ns |  3.23 ns |  2.70 ns |  1.41 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                 ValueLinq_Ref_SharedPool_Pull |   100 | 1,409.9 ns |  6.54 ns |  5.80 ns |  1.38 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                ValueLinq_ValueLambda_Standard |   100 | 1,182.1 ns |  8.22 ns |  7.29 ns |  1.16 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                   ValueLinq_ValueLambda_Stack |   100 | 1,145.3 ns |  8.66 ns |  7.23 ns |  1.12 |    0.01 | 0.9670 |     - |     - |    2024 B |
|         ValueLinq_ValueLambda_SharedPool_Push |   100 | 1,221.2 ns |  2.91 ns |  2.43 ns |  1.20 |    0.01 | 0.9670 |     - |     - |    2024 B |
|         ValueLinq_ValueLambda_SharedPool_Pull |   100 | 1,437.5 ns | 10.78 ns | 10.08 ns |  1.41 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                    ValueLinq_Standard_ByIndex |   100 | 1,089.3 ns |  4.16 ns |  3.47 ns |  1.07 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                       ValueLinq_Stack_ByIndex |   100 | 1,045.9 ns |  6.50 ns |  6.08 ns |  1.03 |    0.01 | 0.9670 |     - |     - |    2024 B |
|             ValueLinq_SharedPool_Push_ByIndex |   100 | 1,636.5 ns | 13.57 ns | 12.69 ns |  1.61 |    0.02 | 0.9670 |     - |     - |    2024 B |
|             ValueLinq_SharedPool_Pull_ByIndex |   100 | 1,364.4 ns | 12.92 ns | 12.09 ns |  1.34 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                ValueLinq_Ref_Standard_ByIndex |   100 | 1,036.8 ns |  4.28 ns |  3.79 ns |  1.02 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                   ValueLinq_Ref_Stack_ByIndex |   100 | 1,004.6 ns |  3.68 ns |  3.44 ns |  0.99 |    0.01 | 0.9670 |     - |     - |    2024 B |
|         ValueLinq_Ref_SharedPool_Push_ByIndex |   100 | 1,455.9 ns |  4.13 ns |  3.45 ns |  1.43 |    0.01 | 0.9670 |     - |     - |    2024 B |
|         ValueLinq_Ref_SharedPool_Pull_ByIndex |   100 | 1,260.7 ns |  6.11 ns |  5.41 ns |  1.24 |    0.01 | 0.9670 |     - |     - |    2024 B |
|        ValueLinq_ValueLambda_Standard_ByIndex |   100 | 1,017.6 ns |  4.19 ns |  3.72 ns |  1.00 |    0.01 | 0.9670 |     - |     - |    2024 B |
|           ValueLinq_ValueLambda_Stack_ByIndex |   100 |   978.4 ns |  6.58 ns |  5.49 ns |  0.96 |    0.01 | 0.9670 |     - |     - |    2024 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |   100 | 1,234.5 ns |  6.29 ns |  5.58 ns |  1.21 |    0.01 | 0.9670 |     - |     - |    2024 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |   100 | 1,240.8 ns |  4.34 ns |  3.85 ns |  1.22 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                                       ForLoop |   100 | 1,019.3 ns |  5.80 ns |  5.15 ns |  1.00 |    0.00 | 3.4103 |     - |     - |    7136 B |
|                                   ForeachLoop |   100 | 1,245.1 ns | 10.74 ns | 10.05 ns |  1.22 |    0.01 | 3.4103 |     - |     - |    7136 B |
|                                          Linq |   100 | 1,305.1 ns | 12.52 ns | 11.10 ns |  1.28 |    0.01 | 2.4853 |     - |     - |    5200 B |
|                                    LinqFaster |   100 | 1,358.0 ns | 11.65 ns | 10.33 ns |  1.33 |    0.01 | 3.4103 |     - |     - |    7136 B |
|                                        LinqAF |   100 | 2,520.4 ns | 17.24 ns | 16.12 ns |  2.47 |    0.02 | 3.3951 |     - |     - |    7104 B |
|                                    StructLinq |   100 | 1,160.1 ns |  4.83 ns |  4.52 ns |  1.14 |    0.01 | 1.0166 |     - |     - |    2128 B |
|                          StructLinq_IFunction |   100 |   850.2 ns |  3.78 ns |  3.35 ns |  0.83 |    0.00 | 0.9670 |     - |     - |    2024 B |
|                                     Hyperlinq |   100 | 1,374.1 ns | 15.71 ns | 13.93 ns |  1.35 |    0.02 | 0.9670 |     - |     - |    2024 B |
|                           Hyperlinq_IFunction |   100 |   974.3 ns |  2.71 ns |  2.40 ns |  0.96 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                                Hyperlinq_Pool |   100 | 1,299.1 ns | 14.45 ns | 13.52 ns |  1.27 |    0.01 | 0.0267 |     - |     - |      56 B |
|                      Hyperlinq_Pool_IFunction |   100 |   947.0 ns |  1.80 ns |  1.60 ns |  0.93 |    0.01 | 0.0267 |     - |     - |      56 B |
