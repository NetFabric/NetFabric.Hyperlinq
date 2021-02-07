## List.ValueType.ListValueTypeWhereSelectToArray

### Source
[ListValueTypeWhereSelectToArray.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelectToArray.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta33](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta33)

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
|                            ValueLinq_Standard |   100 | 1,300.9 ns |  6.57 ns |  5.83 ns |  1.27 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                               ValueLinq_Stack |   100 | 1,263.7 ns | 10.33 ns |  9.66 ns |  1.23 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                     ValueLinq_SharedPool_Push |   100 | 1,581.7 ns | 11.44 ns |  9.55 ns |  1.54 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                     ValueLinq_SharedPool_Pull |   100 | 1,498.8 ns |  9.31 ns |  8.71 ns |  1.46 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                        ValueLinq_Ref_Standard |   100 | 1,207.5 ns |  5.92 ns |  4.94 ns |  1.18 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                           ValueLinq_Ref_Stack |   100 | 1,160.4 ns |  3.52 ns |  3.29 ns |  1.13 |    0.00 | 0.9670 |     - |     - |    2024 B |
|                 ValueLinq_Ref_SharedPool_Push |   100 | 1,426.1 ns |  5.82 ns |  4.86 ns |  1.39 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                 ValueLinq_Ref_SharedPool_Pull |   100 | 1,419.9 ns |  5.61 ns |  5.25 ns |  1.39 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                ValueLinq_ValueLambda_Standard |   100 | 1,189.0 ns |  7.03 ns |  6.58 ns |  1.16 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                   ValueLinq_ValueLambda_Stack |   100 | 1,150.6 ns | 12.74 ns | 11.92 ns |  1.12 |    0.01 | 0.9670 |     - |     - |    2024 B |
|         ValueLinq_ValueLambda_SharedPool_Push |   100 | 1,238.9 ns |  2.96 ns |  2.47 ns |  1.21 |    0.00 | 0.9670 |     - |     - |    2024 B |
|         ValueLinq_ValueLambda_SharedPool_Pull |   100 | 1,385.6 ns |  7.08 ns |  6.27 ns |  1.35 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                    ValueLinq_Standard_ByIndex |   100 | 1,083.5 ns |  6.50 ns |  5.76 ns |  1.06 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                       ValueLinq_Stack_ByIndex |   100 | 1,058.9 ns |  5.32 ns |  4.72 ns |  1.03 |    0.01 | 0.9670 |     - |     - |    2024 B |
|             ValueLinq_SharedPool_Push_ByIndex |   100 | 1,603.2 ns | 12.12 ns | 10.74 ns |  1.56 |    0.01 | 0.9670 |     - |     - |    2024 B |
|             ValueLinq_SharedPool_Pull_ByIndex |   100 | 1,325.1 ns |  5.81 ns |  5.15 ns |  1.29 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                ValueLinq_Ref_Standard_ByIndex |   100 | 1,026.4 ns |  3.24 ns |  2.87 ns |  1.00 |    0.00 | 0.9670 |     - |     - |    2024 B |
|                   ValueLinq_Ref_Stack_ByIndex |   100 |   988.6 ns |  3.90 ns |  3.46 ns |  0.96 |    0.00 | 0.9670 |     - |     - |    2024 B |
|         ValueLinq_Ref_SharedPool_Push_ByIndex |   100 | 1,433.0 ns |  2.89 ns |  2.57 ns |  1.40 |    0.01 | 0.9670 |     - |     - |    2024 B |
|         ValueLinq_Ref_SharedPool_Pull_ByIndex |   100 | 1,254.2 ns |  3.78 ns |  3.54 ns |  1.22 |    0.00 | 0.9670 |     - |     - |    2024 B |
|        ValueLinq_ValueLambda_Standard_ByIndex |   100 | 1,029.9 ns |  3.79 ns |  3.55 ns |  1.00 |    0.01 | 0.9670 |     - |     - |    2024 B |
|           ValueLinq_ValueLambda_Stack_ByIndex |   100 |   976.0 ns |  2.88 ns |  2.69 ns |  0.95 |    0.00 | 0.9670 |     - |     - |    2024 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |   100 | 1,222.4 ns |  4.76 ns |  4.22 ns |  1.19 |    0.01 | 0.9670 |     - |     - |    2024 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |   100 | 1,187.1 ns |  3.39 ns |  3.17 ns |  1.16 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                                       ForLoop |   100 | 1,025.2 ns |  4.07 ns |  3.61 ns |  1.00 |    0.00 | 3.4103 |     - |     - |    7136 B |
|                                   ForeachLoop |   100 | 1,236.7 ns |  7.04 ns |  6.58 ns |  1.21 |    0.01 | 3.4103 |     - |     - |    7136 B |
|                                          Linq |   100 | 1,303.2 ns |  9.77 ns |  8.66 ns |  1.27 |    0.01 | 2.4853 |     - |     - |    5200 B |
|                                    LinqFaster |   100 | 1,345.9 ns | 25.85 ns | 26.55 ns |  1.31 |    0.02 | 3.4103 |     - |     - |    7136 B |
|                                        LinqAF |   100 | 3,570.4 ns |  9.76 ns |  8.15 ns |  3.48 |    0.02 | 3.3951 |     - |     - |    7104 B |
|                                    StructLinq |   100 | 1,229.9 ns |  3.94 ns |  3.69 ns |  1.20 |    0.01 | 1.0166 |     - |     - |    2128 B |
|                          StructLinq_IFunction |   100 |   863.9 ns |  3.08 ns |  2.57 ns |  0.84 |    0.00 | 0.9670 |     - |     - |    2024 B |
|                                     Hyperlinq |   100 | 1,077.3 ns |  3.15 ns |  2.80 ns |  1.05 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                           Hyperlinq_IFunction |   100 |   815.4 ns |  2.30 ns |  2.04 ns |  0.80 |    0.00 | 0.9670 |     - |     - |    2024 B |
|                                Hyperlinq_Pool |   100 | 1,022.0 ns |  7.38 ns |  6.90 ns |  1.00 |    0.01 | 0.0267 |     - |     - |      56 B |
|                      Hyperlinq_Pool_IFunction |   100 | 1,061.9 ns |  1.31 ns |  1.09 ns |  1.04 |    0.00 | 0.0267 |     - |     - |      56 B |
