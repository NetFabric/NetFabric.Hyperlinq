## List.ValueType.ListValueTypeWhereSelectToArray

### Source
[ListValueTypeWhereSelectToArray.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelectToArray.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta35](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta35)

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
|                            ValueLinq_Standard |   100 | 1,395.6 ns |  7.38 ns |  6.16 ns |  1.30 |    0.02 | 1.0433 |     - |     - |    2184 B |
|                               ValueLinq_Stack |   100 | 1,332.6 ns |  7.58 ns |  7.09 ns |  1.24 |    0.02 | 1.0433 |     - |     - |    2184 B |
|                     ValueLinq_SharedPool_Push |   100 | 1,667.5 ns |  8.54 ns |  7.99 ns |  1.56 |    0.02 | 1.0433 |     - |     - |    2184 B |
|                     ValueLinq_SharedPool_Pull |   100 | 1,576.9 ns | 19.84 ns | 15.49 ns |  1.47 |    0.02 | 1.0433 |     - |     - |    2184 B |
|                        ValueLinq_Ref_Standard |   100 | 1,308.2 ns |  3.85 ns |  3.21 ns |  1.22 |    0.01 | 1.0433 |     - |     - |    2184 B |
|                           ValueLinq_Ref_Stack |   100 | 1,234.5 ns |  5.21 ns |  4.62 ns |  1.15 |    0.01 | 1.0433 |     - |     - |    2184 B |
|                 ValueLinq_Ref_SharedPool_Push |   100 | 1,505.1 ns |  5.37 ns |  5.03 ns |  1.40 |    0.02 | 1.0433 |     - |     - |    2184 B |
|                 ValueLinq_Ref_SharedPool_Pull |   100 | 1,590.8 ns |  5.52 ns |  4.61 ns |  1.48 |    0.02 | 1.0433 |     - |     - |    2184 B |
|                ValueLinq_ValueLambda_Standard |   100 | 1,264.0 ns |  8.19 ns |  7.26 ns |  1.18 |    0.01 | 1.0433 |     - |     - |    2184 B |
|                   ValueLinq_ValueLambda_Stack |   100 | 1,214.0 ns |  7.27 ns |  6.45 ns |  1.13 |    0.01 | 1.0433 |     - |     - |    2184 B |
|         ValueLinq_ValueLambda_SharedPool_Push |   100 | 1,265.6 ns |  5.99 ns |  5.31 ns |  1.18 |    0.01 | 1.0433 |     - |     - |    2184 B |
|         ValueLinq_ValueLambda_SharedPool_Pull |   100 | 1,473.3 ns |  7.57 ns |  6.71 ns |  1.38 |    0.01 | 1.0433 |     - |     - |    2184 B |
|                    ValueLinq_Standard_ByIndex |   100 | 1,167.7 ns | 11.39 ns | 10.65 ns |  1.09 |    0.02 | 1.0433 |     - |     - |    2184 B |
|                       ValueLinq_Stack_ByIndex |   100 | 1,139.2 ns |  8.79 ns |  7.79 ns |  1.06 |    0.01 | 1.0433 |     - |     - |    2184 B |
|             ValueLinq_SharedPool_Push_ByIndex |   100 | 1,699.3 ns | 13.32 ns | 11.80 ns |  1.59 |    0.02 | 1.0433 |     - |     - |    2184 B |
|             ValueLinq_SharedPool_Pull_ByIndex |   100 | 1,461.3 ns |  5.30 ns |  4.70 ns |  1.36 |    0.02 | 1.0433 |     - |     - |    2184 B |
|                ValueLinq_Ref_Standard_ByIndex |   100 | 1,082.5 ns |  3.45 ns |  3.23 ns |  1.01 |    0.01 | 1.0433 |     - |     - |    2184 B |
|                   ValueLinq_Ref_Stack_ByIndex |   100 | 1,045.3 ns |  2.52 ns |  2.24 ns |  0.98 |    0.01 | 1.0433 |     - |     - |    2184 B |
|         ValueLinq_Ref_SharedPool_Push_ByIndex |   100 | 1,530.6 ns |  6.15 ns |  5.75 ns |  1.43 |    0.02 | 1.0433 |     - |     - |    2184 B |
|         ValueLinq_Ref_SharedPool_Pull_ByIndex |   100 | 1,314.7 ns |  7.15 ns |  6.69 ns |  1.23 |    0.02 | 1.0433 |     - |     - |    2184 B |
|        ValueLinq_ValueLambda_Standard_ByIndex |   100 | 1,080.1 ns |  4.71 ns |  4.17 ns |  1.01 |    0.01 | 1.0433 |     - |     - |    2184 B |
|           ValueLinq_ValueLambda_Stack_ByIndex |   100 | 1,029.4 ns |  5.03 ns |  4.20 ns |  0.96 |    0.01 | 1.0433 |     - |     - |    2184 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |   100 | 1,308.1 ns |  2.12 ns |  1.88 ns |  1.22 |    0.01 | 1.0433 |     - |     - |    2184 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |   100 | 1,222.1 ns |  6.72 ns |  5.96 ns |  1.14 |    0.01 | 1.0433 |     - |     - |    2184 B |
|                                       ForLoop |   100 | 1,071.5 ns | 12.99 ns | 11.52 ns |  1.00 |    0.00 | 3.4866 |     - |     - |    7296 B |
|                                   ForeachLoop |   100 | 1,280.3 ns |  3.63 ns |  3.22 ns |  1.20 |    0.01 | 3.4866 |     - |     - |    7296 B |
|                                          Linq |   100 | 1,365.0 ns | 10.34 ns |  9.67 ns |  1.27 |    0.01 | 2.5616 |     - |     - |    5360 B |
|                                    LinqFaster |   100 | 1,460.3 ns | 11.78 ns | 10.44 ns |  1.36 |    0.02 | 3.4866 |     - |     - |    7296 B |
|                                        LinqAF |   100 | 2,744.5 ns | 24.29 ns | 22.72 ns |  2.56 |    0.04 | 3.4714 |     - |     - |    7264 B |
|                                    StructLinq |   100 | 1,211.9 ns |  3.91 ns |  3.65 ns |  1.13 |    0.01 | 1.0929 |     - |     - |    2288 B |
|                          StructLinq_IFunction |   100 |   873.3 ns |  3.27 ns |  2.90 ns |  0.82 |    0.01 | 1.0433 |     - |     - |    2184 B |
|                                     Hyperlinq |   100 | 1,109.9 ns |  4.35 ns |  4.07 ns |  1.04 |    0.01 | 1.0433 |     - |     - |    2184 B |
|                           Hyperlinq_IFunction |   100 |   882.2 ns |  5.93 ns |  5.25 ns |  0.82 |    0.01 | 1.0433 |     - |     - |    2184 B |
|                                Hyperlinq_Pool |   100 | 1,054.2 ns |  2.54 ns |  2.25 ns |  0.98 |    0.01 | 0.0267 |     - |     - |      56 B |
|                      Hyperlinq_Pool_IFunction |   100 |   839.4 ns |  2.27 ns |  2.02 ns |  0.78 |    0.01 | 0.0267 |     - |     - |      56 B |
