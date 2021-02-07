## List.ValueType.ListValueTypeWhereSelectToList

### Source
[ListValueTypeWhereSelectToList.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelectToList.cs)

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
|                            ValueLinq_Standard |   100 | 1,397.3 ns | 15.49 ns | 13.73 ns |  1.60 |    0.02 | 2.4433 |     - |     - |   4.99 KB |
|                               ValueLinq_Stack |   100 | 1,330.7 ns |  5.35 ns |  4.74 ns |  1.53 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|                     ValueLinq_SharedPool_Push |   100 | 1,711.0 ns | 14.66 ns | 12.99 ns |  1.96 |    0.02 | 0.9823 |     - |     - |   2.01 KB |
|                     ValueLinq_SharedPool_Pull |   100 | 1,636.5 ns | 10.34 ns |  8.63 ns |  1.88 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|                        ValueLinq_Ref_Standard |   100 | 1,304.4 ns |  6.94 ns |  6.16 ns |  1.50 |    0.01 | 2.4433 |     - |     - |   4.99 KB |
|                           ValueLinq_Ref_Stack |   100 | 1,275.0 ns |  2.48 ns |  1.94 ns |  1.46 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|                 ValueLinq_Ref_SharedPool_Push |   100 | 1,536.7 ns |  5.39 ns |  4.50 ns |  1.76 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|                 ValueLinq_Ref_SharedPool_Pull |   100 | 1,558.5 ns |  7.03 ns |  6.23 ns |  1.79 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|                ValueLinq_ValueLambda_Standard |   100 | 1,094.3 ns | 11.91 ns |  9.95 ns |  1.26 |    0.01 | 2.4433 |     - |     - |   4.99 KB |
|                   ValueLinq_ValueLambda_Stack |   100 | 1,254.2 ns |  9.80 ns |  8.69 ns |  1.44 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|         ValueLinq_ValueLambda_SharedPool_Push |   100 | 1,333.7 ns |  5.37 ns |  4.76 ns |  1.53 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|         ValueLinq_ValueLambda_SharedPool_Pull |   100 | 1,494.8 ns |  7.47 ns |  6.99 ns |  1.72 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|                    ValueLinq_Standard_ByIndex |   100 | 1,425.1 ns | 16.43 ns | 14.57 ns |  1.64 |    0.02 | 2.4433 |     - |     - |   4.99 KB |
|                       ValueLinq_Stack_ByIndex |   100 | 1,153.8 ns |  6.82 ns |  5.70 ns |  1.33 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|             ValueLinq_SharedPool_Push_ByIndex |   100 | 1,739.1 ns | 13.74 ns | 12.18 ns |  2.00 |    0.02 | 0.9823 |     - |     - |   2.01 KB |
|             ValueLinq_SharedPool_Pull_ByIndex |   100 | 1,458.0 ns | 10.55 ns |  9.35 ns |  1.67 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|                ValueLinq_Ref_Standard_ByIndex |   100 | 1,310.8 ns |  9.28 ns |  8.68 ns |  1.50 |    0.01 | 2.4433 |     - |     - |   4.99 KB |
|                   ValueLinq_Ref_Stack_ByIndex |   100 | 1,135.0 ns |  4.55 ns |  3.80 ns |  1.30 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|         ValueLinq_Ref_SharedPool_Push_ByIndex |   100 | 1,570.9 ns |  2.33 ns |  2.06 ns |  1.80 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|         ValueLinq_Ref_SharedPool_Pull_ByIndex |   100 | 1,377.5 ns |  3.44 ns |  2.87 ns |  1.58 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|        ValueLinq_ValueLambda_Standard_ByIndex |   100 | 1,107.7 ns |  9.12 ns |  8.53 ns |  1.27 |    0.01 | 2.4433 |     - |     - |   4.99 KB |
|           ValueLinq_ValueLambda_Stack_ByIndex |   100 | 1,077.8 ns |  7.11 ns |  6.65 ns |  1.24 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |   100 | 1,337.5 ns |  4.81 ns |  4.50 ns |  1.54 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |   100 | 1,326.6 ns |  3.27 ns |  3.06 ns |  1.52 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|                                       ForLoop |   100 |   870.9 ns |  3.96 ns |  3.51 ns |  1.00 |    0.00 | 2.4433 |     - |     - |   4.99 KB |
|                                   ForeachLoop |   100 | 1,098.4 ns |  5.42 ns |  5.07 ns |  1.26 |    0.01 | 2.4433 |     - |     - |   4.99 KB |
|                                          Linq |   100 | 1,240.7 ns |  9.79 ns |  8.67 ns |  1.42 |    0.01 | 2.5768 |     - |     - |   5.27 KB |
|                                    LinqFaster |   100 | 1,345.1 ns | 14.66 ns | 13.00 ns |  1.54 |    0.01 | 3.4237 |     - |     - |      7 KB |
|                                        LinqAF |   100 | 2,479.1 ns | 22.16 ns | 19.65 ns |  2.85 |    0.02 | 2.4414 |     - |     - |   4.99 KB |
|                                    StructLinq |   100 | 1,171.5 ns |  3.14 ns |  2.62 ns |  1.35 |    0.01 | 1.0319 |     - |     - |   2.11 KB |
|                          StructLinq_IFunction |   100 |   864.4 ns |  2.15 ns |  1.91 ns |  0.99 |    0.00 | 0.9823 |     - |     - |   2.01 KB |
|                                     Hyperlinq |   100 | 1,074.8 ns |  4.84 ns |  4.53 ns |  1.23 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|                           Hyperlinq_IFunction |   100 |   843.3 ns |  2.88 ns |  2.55 ns |  0.97 |    0.00 | 0.9823 |     - |     - |   2.01 KB |
