## List.ValueType.ListValueTypeWhereSelectToArray

### Source
[ListValueTypeWhereSelectToArray.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelectToArray.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta36](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta36)

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
|                            ValueLinq_Standard |   100 | 1,435.4 ns | 11.68 ns | 10.36 ns |  1.31 |    0.01 | 1.0433 |     - |     - |    2184 B |
|                               ValueLinq_Stack |   100 | 1,405.6 ns |  8.77 ns |  7.77 ns |  1.28 |    0.01 | 1.0433 |     - |     - |    2184 B |
|                     ValueLinq_SharedPool_Push |   100 | 1,738.7 ns |  6.34 ns |  5.62 ns |  1.58 |    0.01 | 1.0433 |     - |     - |    2184 B |
|                     ValueLinq_SharedPool_Pull |   100 | 1,626.7 ns |  8.93 ns |  6.97 ns |  1.48 |    0.01 | 1.0433 |     - |     - |    2184 B |
|                        ValueLinq_Ref_Standard |   100 | 1,328.8 ns |  5.33 ns |  4.73 ns |  1.21 |    0.01 | 1.0433 |     - |     - |    2184 B |
|                           ValueLinq_Ref_Stack |   100 | 1,297.0 ns |  5.94 ns |  5.26 ns |  1.18 |    0.00 | 1.0433 |     - |     - |    2184 B |
|                 ValueLinq_Ref_SharedPool_Push |   100 | 1,531.4 ns |  5.58 ns |  4.95 ns |  1.39 |    0.01 | 1.0433 |     - |     - |    2184 B |
|                 ValueLinq_Ref_SharedPool_Pull |   100 | 1,634.7 ns |  7.59 ns |  6.73 ns |  1.49 |    0.01 | 1.0433 |     - |     - |    2184 B |
|                ValueLinq_ValueLambda_Standard |   100 | 1,284.5 ns |  7.31 ns |  6.48 ns |  1.17 |    0.01 | 1.0433 |     - |     - |    2184 B |
|                   ValueLinq_ValueLambda_Stack |   100 | 1,269.2 ns |  5.99 ns |  5.31 ns |  1.16 |    0.01 | 1.0433 |     - |     - |    2184 B |
|         ValueLinq_ValueLambda_SharedPool_Push |   100 | 1,293.0 ns |  3.59 ns |  3.18 ns |  1.18 |    0.00 | 1.0433 |     - |     - |    2184 B |
|         ValueLinq_ValueLambda_SharedPool_Pull |   100 | 1,473.6 ns |  8.85 ns |  7.85 ns |  1.34 |    0.01 | 1.0433 |     - |     - |    2184 B |
|                    ValueLinq_Standard_ByIndex |   100 | 1,193.2 ns |  9.92 ns |  8.29 ns |  1.09 |    0.01 | 1.0433 |     - |     - |    2184 B |
|                       ValueLinq_Stack_ByIndex |   100 | 1,183.3 ns |  7.78 ns |  6.90 ns |  1.08 |    0.01 | 1.0433 |     - |     - |    2184 B |
|             ValueLinq_SharedPool_Push_ByIndex |   100 | 1,746.0 ns |  8.64 ns |  8.09 ns |  1.59 |    0.01 | 1.0433 |     - |     - |    2184 B |
|             ValueLinq_SharedPool_Pull_ByIndex |   100 | 1,519.9 ns |  5.92 ns |  5.24 ns |  1.38 |    0.01 | 1.0433 |     - |     - |    2184 B |
|                ValueLinq_Ref_Standard_ByIndex |   100 | 1,123.1 ns |  4.71 ns |  4.40 ns |  1.02 |    0.01 | 1.0433 |     - |     - |    2184 B |
|                   ValueLinq_Ref_Stack_ByIndex |   100 | 1,078.3 ns |  5.01 ns |  4.68 ns |  0.98 |    0.01 | 1.0433 |     - |     - |    2184 B |
|         ValueLinq_Ref_SharedPool_Push_ByIndex |   100 | 1,590.1 ns |  6.52 ns |  5.44 ns |  1.45 |    0.01 | 1.0433 |     - |     - |    2184 B |
|         ValueLinq_Ref_SharedPool_Pull_ByIndex |   100 | 1,396.0 ns |  4.95 ns |  4.39 ns |  1.27 |    0.01 | 1.0433 |     - |     - |    2184 B |
|        ValueLinq_ValueLambda_Standard_ByIndex |   100 | 1,137.3 ns |  7.60 ns |  6.34 ns |  1.04 |    0.01 | 1.0433 |     - |     - |    2184 B |
|           ValueLinq_ValueLambda_Stack_ByIndex |   100 | 1,067.2 ns |  6.67 ns |  5.91 ns |  0.97 |    0.01 | 1.0433 |     - |     - |    2184 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |   100 | 1,285.6 ns |  6.19 ns |  5.48 ns |  1.17 |    0.01 | 1.0433 |     - |     - |    2184 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |   100 | 1,259.0 ns |  7.16 ns |  6.70 ns |  1.15 |    0.01 | 1.0433 |     - |     - |    2184 B |
|                                       ForLoop |   100 | 1,097.9 ns |  6.36 ns |  5.64 ns |  1.00 |    0.00 | 3.4866 |     - |     - |    7296 B |
|                                   ForeachLoop |   100 | 1,343.4 ns |  4.93 ns |  4.61 ns |  1.22 |    0.01 | 3.4866 |     - |     - |    7296 B |
|                                          Linq |   100 | 1,410.0 ns |  8.56 ns |  8.01 ns |  1.28 |    0.01 | 2.5616 |     - |     - |    5360 B |
|                                    LinqFaster |   100 | 1,506.8 ns | 17.37 ns | 14.51 ns |  1.37 |    0.01 | 3.4866 |     - |     - |    7296 B |
|                                        LinqAF |   100 | 2,879.4 ns | 29.95 ns | 26.55 ns |  2.62 |    0.03 | 3.4714 |     - |     - |    7264 B |
|                                    StructLinq |   100 | 1,244.5 ns |  7.08 ns |  6.62 ns |  1.13 |    0.01 | 1.0929 |     - |     - |    2288 B |
|                          StructLinq_IFunction |   100 |   910.6 ns |  4.58 ns |  4.29 ns |  0.83 |    0.01 | 1.0433 |     - |     - |    2184 B |
|                                     Hyperlinq |   100 | 1,144.4 ns |  4.56 ns |  4.04 ns |  1.04 |    0.01 | 1.0433 |     - |     - |    2184 B |
|                           Hyperlinq_IFunction |   100 |   905.3 ns |  5.11 ns |  4.78 ns |  0.82 |    0.01 | 1.0433 |     - |     - |    2184 B |
|                                Hyperlinq_Pool |   100 | 1,089.5 ns |  3.38 ns |  3.17 ns |  0.99 |    0.01 | 0.0267 |     - |     - |      56 B |
|                      Hyperlinq_Pool_IFunction |   100 |   845.0 ns |  4.48 ns |  3.97 ns |  0.77 |    0.01 | 0.0267 |     - |     - |      56 B |
