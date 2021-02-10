## List.ValueType.ListValueTypeWhereSelectToList

### Source
[ListValueTypeWhereSelectToList.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelectToList.cs)

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
|                            ValueLinq_Standard |   100 | 1,481.0 ns | 19.91 ns | 17.65 ns |  1.56 |    0.02 | 2.4414 |     - |     - |   4.99 KB |
|                               ValueLinq_Stack |   100 | 1,431.5 ns |  4.34 ns |  3.84 ns |  1.51 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
|                     ValueLinq_SharedPool_Push |   100 | 1,806.9 ns |  6.54 ns |  5.79 ns |  1.91 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
|                     ValueLinq_SharedPool_Pull |   100 | 1,697.5 ns |  9.39 ns |  8.32 ns |  1.79 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
|                        ValueLinq_Ref_Standard |   100 | 1,340.3 ns | 16.82 ns | 14.04 ns |  1.41 |    0.02 | 2.4433 |     - |     - |   4.99 KB |
|                           ValueLinq_Ref_Stack |   100 | 1,361.3 ns |  6.24 ns |  5.53 ns |  1.44 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
|                 ValueLinq_Ref_SharedPool_Push |   100 | 1,596.6 ns | 13.35 ns | 11.15 ns |  1.68 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
|                 ValueLinq_Ref_SharedPool_Pull |   100 | 1,726.1 ns | 12.02 ns | 10.04 ns |  1.82 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
|                ValueLinq_ValueLambda_Standard |   100 | 1,180.6 ns |  5.09 ns |  4.76 ns |  1.24 |    0.01 | 2.4433 |     - |     - |   4.99 KB |
|                   ValueLinq_ValueLambda_Stack |   100 | 1,341.4 ns |  6.50 ns |  6.08 ns |  1.41 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
|         ValueLinq_ValueLambda_SharedPool_Push |   100 | 1,368.4 ns |  6.55 ns |  5.81 ns |  1.44 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
|         ValueLinq_ValueLambda_SharedPool_Pull |   100 | 1,573.6 ns |  9.29 ns |  8.23 ns |  1.66 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
|                    ValueLinq_Standard_ByIndex |   100 | 1,471.7 ns | 13.11 ns | 12.26 ns |  1.55 |    0.01 | 2.4433 |     - |     - |   4.99 KB |
|                       ValueLinq_Stack_ByIndex |   100 | 1,270.3 ns |  8.41 ns |  7.46 ns |  1.34 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
|             ValueLinq_SharedPool_Push_ByIndex |   100 | 1,806.6 ns |  9.88 ns |  8.25 ns |  1.90 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
|             ValueLinq_SharedPool_Pull_ByIndex |   100 | 1,544.8 ns |  3.10 ns |  2.59 ns |  1.63 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
|                ValueLinq_Ref_Standard_ByIndex |   100 | 1,368.4 ns |  6.50 ns |  5.76 ns |  1.44 |    0.01 | 2.4433 |     - |     - |   4.99 KB |
|                   ValueLinq_Ref_Stack_ByIndex |   100 | 1,207.0 ns |  5.57 ns |  5.21 ns |  1.27 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
|         ValueLinq_Ref_SharedPool_Push_ByIndex |   100 | 1,659.6 ns |  4.75 ns |  4.45 ns |  1.75 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
|         ValueLinq_Ref_SharedPool_Pull_ByIndex |   100 | 1,429.6 ns |  4.53 ns |  4.01 ns |  1.51 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
|        ValueLinq_ValueLambda_Standard_ByIndex |   100 | 1,171.5 ns | 12.69 ns | 11.25 ns |  1.24 |    0.01 | 2.4433 |     - |     - |   4.99 KB |
|           ValueLinq_ValueLambda_Stack_ByIndex |   100 | 1,181.3 ns |  7.08 ns |  6.27 ns |  1.25 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |   100 | 1,376.7 ns |  5.03 ns |  4.46 ns |  1.45 |    0.00 | 1.0586 |     - |     - |   2.16 KB |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |   100 | 1,336.8 ns |  5.51 ns |  4.88 ns |  1.41 |    0.00 | 1.0586 |     - |     - |   2.16 KB |
|                                       ForLoop |   100 |   948.3 ns |  2.28 ns |  2.13 ns |  1.00 |    0.00 | 2.4433 |     - |     - |   4.99 KB |
|                                   ForeachLoop |   100 | 1,141.1 ns |  5.96 ns |  5.58 ns |  1.20 |    0.01 | 2.4433 |     - |     - |   4.99 KB |
|                                          Linq |   100 | 1,291.6 ns | 19.69 ns | 18.42 ns |  1.36 |    0.02 | 2.5768 |     - |     - |   5.27 KB |
|                                    LinqFaster |   100 | 1,479.4 ns | 15.96 ns | 14.93 ns |  1.56 |    0.02 | 3.5019 |     - |     - |   7.16 KB |
|                                        LinqAF |   100 | 2,721.7 ns | 32.86 ns | 30.74 ns |  2.87 |    0.03 | 2.4414 |     - |     - |   4.99 KB |
|                                    StructLinq |   100 | 1,212.6 ns |  4.87 ns |  4.07 ns |  1.28 |    0.01 | 1.1082 |     - |     - |   2.27 KB |
|                          StructLinq_IFunction |   100 |   893.9 ns |  2.60 ns |  2.31 ns |  0.94 |    0.00 | 1.0586 |     - |     - |   2.16 KB |
|                                     Hyperlinq |   100 | 1,129.0 ns |  3.72 ns |  3.30 ns |  1.19 |    0.00 | 1.0586 |     - |     - |   2.16 KB |
|                           Hyperlinq_IFunction |   100 |   879.5 ns |  5.29 ns |  4.95 ns |  0.93 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
