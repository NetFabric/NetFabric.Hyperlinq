## List.ValueType.ListValueTypeWhereSelectToArray

### Source
[ListValueTypeWhereSelectToArray.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelectToArray.cs)

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
|                            ValueLinq_Standard |   100 | 1,324.0 ns |  6.70 ns |  5.60 ns |  1.28 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                               ValueLinq_Stack |   100 | 2,410.4 ns |  5.76 ns |  5.10 ns |  2.34 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                     ValueLinq_SharedPool_Push |   100 | 1,584.6 ns |  8.72 ns |  7.28 ns |  1.54 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                     ValueLinq_SharedPool_Pull |   100 | 1,526.7 ns |  6.60 ns |  5.85 ns |  1.48 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                        ValueLinq_Ref_Standard |   100 | 1,228.0 ns |  8.25 ns |  6.89 ns |  1.19 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                           ValueLinq_Ref_Stack |   100 | 1,175.1 ns |  6.11 ns |  5.71 ns |  1.14 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                 ValueLinq_Ref_SharedPool_Push |   100 | 1,459.5 ns |  7.75 ns |  6.48 ns |  1.42 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                 ValueLinq_Ref_SharedPool_Pull |   100 | 1,433.2 ns |  8.00 ns |  7.09 ns |  1.39 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                ValueLinq_ValueLambda_Standard |   100 | 1,201.0 ns |  3.61 ns |  3.02 ns |  1.16 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                   ValueLinq_ValueLambda_Stack |   100 | 1,153.8 ns |  6.57 ns |  5.82 ns |  1.12 |    0.01 | 0.9670 |     - |     - |    2024 B |
|         ValueLinq_ValueLambda_SharedPool_Push |   100 | 1,231.9 ns |  4.54 ns |  4.24 ns |  1.19 |    0.01 | 0.9670 |     - |     - |    2024 B |
|         ValueLinq_ValueLambda_SharedPool_Pull |   100 | 1,426.5 ns |  5.81 ns |  5.44 ns |  1.38 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                    ValueLinq_Standard_ByIndex |   100 | 1,104.6 ns |  6.20 ns |  5.49 ns |  1.07 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                       ValueLinq_Stack_ByIndex |   100 | 1,103.8 ns |  8.06 ns |  7.14 ns |  1.07 |    0.01 | 0.9670 |     - |     - |    2024 B |
|             ValueLinq_SharedPool_Push_ByIndex |   100 | 1,628.7 ns |  7.37 ns |  6.54 ns |  1.58 |    0.01 | 0.9670 |     - |     - |    2024 B |
|             ValueLinq_SharedPool_Pull_ByIndex |   100 | 1,367.8 ns |  8.21 ns |  7.28 ns |  1.33 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                ValueLinq_Ref_Standard_ByIndex |   100 | 1,054.4 ns |  8.11 ns |  6.77 ns |  1.02 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                   ValueLinq_Ref_Stack_ByIndex |   100 | 1,000.6 ns |  5.45 ns |  4.83 ns |  0.97 |    0.01 | 0.9670 |     - |     - |    2024 B |
|         ValueLinq_Ref_SharedPool_Push_ByIndex |   100 | 1,454.5 ns |  2.79 ns |  2.33 ns |  1.41 |    0.01 | 0.9670 |     - |     - |    2024 B |
|         ValueLinq_Ref_SharedPool_Pull_ByIndex |   100 | 1,284.6 ns |  6.82 ns |  6.04 ns |  1.24 |    0.01 | 0.9670 |     - |     - |    2024 B |
|        ValueLinq_ValueLambda_Standard_ByIndex |   100 | 1,044.4 ns | 11.99 ns | 10.01 ns |  1.01 |    0.01 | 0.9670 |     - |     - |    2024 B |
|           ValueLinq_ValueLambda_Stack_ByIndex |   100 |   994.8 ns |  7.45 ns |  6.60 ns |  0.96 |    0.01 | 0.9670 |     - |     - |    2024 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |   100 | 1,231.2 ns |  4.86 ns |  4.31 ns |  1.19 |    0.01 | 0.9670 |     - |     - |    2024 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |   100 | 1,232.8 ns |  5.96 ns |  4.97 ns |  1.20 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                                       ForLoop |   100 | 1,031.9 ns |  6.81 ns |  6.04 ns |  1.00 |    0.00 | 3.4103 |     - |     - |    7136 B |
|                                   ForeachLoop |   100 | 1,253.5 ns |  8.42 ns |  7.46 ns |  1.21 |    0.01 | 3.4103 |     - |     - |    7136 B |
|                                          Linq |   100 | 1,321.8 ns | 12.57 ns | 11.14 ns |  1.28 |    0.02 | 2.4853 |     - |     - |    5200 B |
|                                    LinqFaster |   100 | 1,425.9 ns | 16.02 ns | 14.99 ns |  1.38 |    0.02 | 3.4103 |     - |     - |    7136 B |
|                                        LinqAF |   100 | 2,421.7 ns | 29.92 ns | 26.53 ns |  2.35 |    0.03 | 3.3951 |     - |     - |    7104 B |
|                                    StructLinq |   100 | 1,187.9 ns |  5.49 ns |  5.13 ns |  1.15 |    0.01 | 1.0166 |     - |     - |    2128 B |
|                          StructLinq_IFunction |   100 |   857.9 ns |  4.48 ns |  3.97 ns |  0.83 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                                     Hyperlinq |   100 | 1,085.4 ns | 10.18 ns |  8.50 ns |  1.05 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                           Hyperlinq_IFunction |   100 |   838.8 ns |  3.88 ns |  3.24 ns |  0.81 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                                Hyperlinq_Pool |   100 | 1,064.7 ns |  6.01 ns |  5.62 ns |  1.03 |    0.01 | 0.0267 |     - |     - |      56 B |
|                      Hyperlinq_Pool_IFunction |   100 |   772.2 ns |  3.31 ns |  3.10 ns |  0.75 |    0.01 | 0.0267 |     - |     - |      56 B |
