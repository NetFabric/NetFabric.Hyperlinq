## List.ValueType.ListValueTypeWhereSelectToArray

### Source
[ListValueTypeWhereSelectToArray.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelectToArray.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta37](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta37)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.21079.7
  [Host]        : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                                        Method | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------------------------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                            ValueLinq_Standard |   100 | 1,450.9 ns |  5.56 ns |  4.92 ns |  1.36 |    0.01 | 1.0433 |     - |     - |    2184 B |
|                               ValueLinq_Stack |   100 | 1,371.8 ns | 22.76 ns | 42.75 ns |  1.32 |    0.06 | 1.0433 |     - |     - |    2184 B |
|                     ValueLinq_SharedPool_Push |   100 | 1,698.3 ns |  6.32 ns |  5.60 ns |  1.59 |    0.01 | 1.0433 |     - |     - |    2184 B |
|                     ValueLinq_SharedPool_Pull |   100 | 1,574.7 ns |  8.65 ns |  7.67 ns |  1.48 |    0.01 | 1.0433 |     - |     - |    2184 B |
|                        ValueLinq_Ref_Standard |   100 | 1,301.4 ns | 12.44 ns | 11.03 ns |  1.22 |    0.02 | 1.0433 |     - |     - |    2184 B |
|                           ValueLinq_Ref_Stack |   100 | 1,262.1 ns |  9.22 ns |  8.17 ns |  1.18 |    0.01 | 1.0433 |     - |     - |    2184 B |
|                 ValueLinq_Ref_SharedPool_Push |   100 | 1,527.9 ns |  6.45 ns |  5.39 ns |  1.43 |    0.01 | 1.0433 |     - |     - |    2184 B |
|                 ValueLinq_Ref_SharedPool_Pull |   100 | 1,595.6 ns |  5.58 ns |  4.94 ns |  1.50 |    0.01 | 1.0433 |     - |     - |    2184 B |
|                ValueLinq_ValueLambda_Standard |   100 | 1,266.2 ns |  7.07 ns |  6.61 ns |  1.19 |    0.01 | 1.0433 |     - |     - |    2184 B |
|                   ValueLinq_ValueLambda_Stack |   100 | 1,222.0 ns |  7.75 ns |  6.87 ns |  1.15 |    0.01 | 1.0433 |     - |     - |    2184 B |
|         ValueLinq_ValueLambda_SharedPool_Push |   100 | 1,293.3 ns |  5.39 ns |  4.78 ns |  1.21 |    0.01 | 1.0433 |     - |     - |    2184 B |
|         ValueLinq_ValueLambda_SharedPool_Pull |   100 | 1,483.4 ns |  8.97 ns |  7.49 ns |  1.39 |    0.01 | 1.0433 |     - |     - |    2184 B |
|                    ValueLinq_Standard_ByIndex |   100 | 1,165.9 ns |  4.28 ns |  3.34 ns |  1.09 |    0.01 | 1.0433 |     - |     - |    2184 B |
|                       ValueLinq_Stack_ByIndex |   100 | 1,181.9 ns |  7.14 ns |  6.68 ns |  1.11 |    0.01 | 1.0433 |     - |     - |    2184 B |
|             ValueLinq_SharedPool_Push_ByIndex |   100 | 1,706.8 ns |  9.31 ns |  7.77 ns |  1.60 |    0.01 | 1.0433 |     - |     - |    2184 B |
|             ValueLinq_SharedPool_Pull_ByIndex |   100 | 1,439.4 ns |  7.53 ns |  7.04 ns |  1.35 |    0.01 | 1.0433 |     - |     - |    2184 B |
|                ValueLinq_Ref_Standard_ByIndex |   100 | 1,092.4 ns |  5.36 ns |  4.75 ns |  1.02 |    0.01 | 1.0433 |     - |     - |    2184 B |
|                   ValueLinq_Ref_Stack_ByIndex |   100 | 1,051.1 ns |  5.76 ns |  5.38 ns |  0.99 |    0.01 | 1.0433 |     - |     - |    2184 B |
|         ValueLinq_Ref_SharedPool_Push_ByIndex |   100 | 1,537.0 ns |  6.58 ns |  6.16 ns |  1.44 |    0.01 | 1.0433 |     - |     - |    2184 B |
|         ValueLinq_Ref_SharedPool_Pull_ByIndex |   100 | 1,301.4 ns |  3.77 ns |  3.35 ns |  1.22 |    0.01 | 1.0433 |     - |     - |    2184 B |
|        ValueLinq_ValueLambda_Standard_ByIndex |   100 | 1,079.8 ns |  3.31 ns |  2.77 ns |  1.01 |    0.01 | 1.0433 |     - |     - |    2184 B |
|           ValueLinq_ValueLambda_Stack_ByIndex |   100 | 1,041.8 ns |  4.65 ns |  4.35 ns |  0.98 |    0.01 | 1.0433 |     - |     - |    2184 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |   100 | 1,289.2 ns |  3.04 ns |  2.54 ns |  1.21 |    0.01 | 1.0433 |     - |     - |    2184 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |   100 | 1,265.2 ns |  7.44 ns |  5.81 ns |  1.19 |    0.01 | 1.0433 |     - |     - |    2184 B |
|                                       ForLoop |   100 | 1,066.3 ns |  9.54 ns |  8.46 ns |  1.00 |    0.00 | 3.4866 |     - |     - |    7296 B |
|                                   ForeachLoop |   100 | 1,297.4 ns |  8.43 ns |  7.88 ns |  1.22 |    0.01 | 3.4866 |     - |     - |    7296 B |
|                                          Linq |   100 | 1,349.8 ns |  6.95 ns |  6.16 ns |  1.27 |    0.01 | 2.5616 |     - |     - |    5360 B |
|                                    LinqFaster |   100 | 1,421.0 ns | 14.43 ns | 12.79 ns |  1.33 |    0.02 | 3.4866 |     - |     - |    7296 B |
|                                        LinqAF |   100 | 2,731.7 ns | 17.37 ns | 15.40 ns |  2.56 |    0.02 | 3.4714 |     - |     - |    7264 B |
|                                    StructLinq |   100 | 1,271.9 ns |  5.15 ns |  4.81 ns |  1.19 |    0.01 | 1.0929 |     - |     - |    2288 B |
|                          StructLinq_IFunction |   100 |   878.5 ns |  3.81 ns |  3.56 ns |  0.82 |    0.01 | 1.0433 |     - |     - |    2184 B |
|                                     Hyperlinq |   100 | 1,115.0 ns |  3.87 ns |  3.23 ns |  1.05 |    0.01 | 1.0433 |     - |     - |    2184 B |
|                           Hyperlinq_IFunction |   100 |   886.5 ns |  7.55 ns |  6.70 ns |  0.83 |    0.01 | 1.0433 |     - |     - |    2184 B |
|                                Hyperlinq_Pool |   100 | 1,074.1 ns |  2.88 ns |  2.25 ns |  1.01 |    0.01 | 0.0267 |     - |     - |      56 B |
|                      Hyperlinq_Pool_IFunction |   100 |   826.4 ns |  2.32 ns |  2.05 ns |  0.77 |    0.01 | 0.0267 |     - |     - |      56 B |
