## List.ValueType.ListValueTypeWhereSelectToList

### Source
[ListValueTypeWhereSelectToList.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelectToList.cs)

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
|                            ValueLinq_Standard |   100 | 1,952.3 ns |  6.27 ns |  5.56 ns |  2.08 |    0.02 | 2.4433 |     - |     - |   4.99 KB |
|                               ValueLinq_Stack |   100 | 1,431.7 ns |  6.65 ns |  6.22 ns |  1.53 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
|                     ValueLinq_SharedPool_Push |   100 | 1,790.9 ns |  7.85 ns |  7.34 ns |  1.91 |    0.02 | 1.0586 |     - |     - |   2.16 KB |
|                     ValueLinq_SharedPool_Pull |   100 | 1,690.1 ns | 10.17 ns |  9.51 ns |  1.80 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
|                        ValueLinq_Ref_Standard |   100 | 1,380.8 ns | 12.32 ns | 10.92 ns |  1.47 |    0.02 | 2.4433 |     - |     - |   4.99 KB |
|                           ValueLinq_Ref_Stack |   100 | 1,380.6 ns |  7.09 ns |  6.64 ns |  1.47 |    0.02 | 1.0586 |     - |     - |   2.16 KB |
|                 ValueLinq_Ref_SharedPool_Push |   100 | 1,617.6 ns |  6.35 ns |  5.63 ns |  1.72 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
|                 ValueLinq_Ref_SharedPool_Pull |   100 | 1,715.9 ns |  3.17 ns |  2.65 ns |  1.83 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
|                ValueLinq_ValueLambda_Standard |   100 | 1,509.1 ns | 13.26 ns | 11.08 ns |  1.61 |    0.02 | 2.4433 |     - |     - |   4.99 KB |
|                   ValueLinq_ValueLambda_Stack |   100 | 1,366.4 ns |  9.75 ns |  9.12 ns |  1.46 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
|         ValueLinq_ValueLambda_SharedPool_Push |   100 | 1,400.1 ns |  5.80 ns |  4.85 ns |  1.49 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
|         ValueLinq_ValueLambda_SharedPool_Pull |   100 | 1,530.3 ns | 13.43 ns | 11.91 ns |  1.63 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
|                    ValueLinq_Standard_ByIndex |   100 | 1,488.0 ns | 12.34 ns | 10.94 ns |  1.59 |    0.01 | 2.4433 |     - |     - |   4.99 KB |
|                       ValueLinq_Stack_ByIndex |   100 | 1,245.3 ns |  8.38 ns |  7.00 ns |  1.33 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
|             ValueLinq_SharedPool_Push_ByIndex |   100 | 1,786.6 ns | 11.29 ns |  9.43 ns |  1.91 |    0.02 | 1.0586 |     - |     - |   2.16 KB |
|             ValueLinq_SharedPool_Pull_ByIndex |   100 | 1,626.7 ns |  8.28 ns |  7.34 ns |  1.73 |    0.02 | 1.0586 |     - |     - |   2.16 KB |
|                ValueLinq_Ref_Standard_ByIndex |   100 | 1,394.2 ns |  6.49 ns |  6.07 ns |  1.49 |    0.01 | 2.4433 |     - |     - |   4.99 KB |
|                   ValueLinq_Ref_Stack_ByIndex |   100 | 1,160.2 ns |  4.68 ns |  4.15 ns |  1.24 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
|         ValueLinq_Ref_SharedPool_Push_ByIndex |   100 | 1,628.7 ns |  9.11 ns |  8.08 ns |  1.74 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
|         ValueLinq_Ref_SharedPool_Pull_ByIndex |   100 | 1,439.6 ns |  9.13 ns |  8.09 ns |  1.53 |    0.02 | 1.0586 |     - |     - |   2.16 KB |
|        ValueLinq_ValueLambda_Standard_ByIndex |   100 | 1,194.6 ns |  4.59 ns |  3.83 ns |  1.27 |    0.01 | 2.4433 |     - |     - |   4.99 KB |
|           ValueLinq_ValueLambda_Stack_ByIndex |   100 | 1,183.2 ns |  6.62 ns |  6.19 ns |  1.26 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |   100 | 1,423.3 ns |  2.87 ns |  2.40 ns |  1.52 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |   100 | 1,396.2 ns |  3.95 ns |  3.30 ns |  1.49 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
|                                       ForLoop |   100 |   938.0 ns |  7.26 ns |  6.44 ns |  1.00 |    0.00 | 2.4433 |     - |     - |   4.99 KB |
|                                   ForeachLoop |   100 | 1,124.1 ns |  6.72 ns |  5.96 ns |  1.20 |    0.01 | 2.4433 |     - |     - |   4.99 KB |
|                                          Linq |   100 | 1,304.8 ns | 13.96 ns | 13.06 ns |  1.39 |    0.01 | 2.5768 |     - |     - |   5.27 KB |
|                                    LinqFaster |   100 | 1,403.9 ns | 12.94 ns | 11.47 ns |  1.50 |    0.02 | 3.5019 |     - |     - |   7.16 KB |
|                                        LinqAF |   100 | 2,738.0 ns | 26.60 ns | 23.58 ns |  2.92 |    0.04 | 2.4414 |     - |     - |   4.99 KB |
|                                    StructLinq |   100 | 1,251.6 ns |  7.61 ns |  6.36 ns |  1.34 |    0.01 | 1.1082 |     - |     - |   2.27 KB |
|                          StructLinq_IFunction |   100 |   880.4 ns |  3.55 ns |  3.14 ns |  0.94 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
|                                     Hyperlinq |   100 | 1,119.8 ns |  7.14 ns |  5.96 ns |  1.19 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
|                           Hyperlinq_IFunction |   100 |   907.2 ns |  3.61 ns |  3.38 ns |  0.97 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
