## List.ValueType.ListValueTypeWhereSelectToList

### Source
[ListValueTypeWhereSelectToList.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelectToList.cs)

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
|                            ValueLinq_Standard |   100 | 1,405.6 ns |  9.53 ns |  8.45 ns |  1.58 |    0.01 | 2.4433 |     - |     - |   4.99 KB |
|                               ValueLinq_Stack |   100 | 1,330.1 ns | 13.62 ns | 12.07 ns |  1.50 |    0.02 | 0.9823 |     - |     - |   2.01 KB |
|                     ValueLinq_SharedPool_Push |   100 | 1,726.6 ns | 16.71 ns | 15.63 ns |  1.94 |    0.02 | 0.9823 |     - |     - |   2.01 KB |
|                     ValueLinq_SharedPool_Pull |   100 | 1,627.0 ns | 11.24 ns |  9.38 ns |  1.83 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|                        ValueLinq_Ref_Standard |   100 | 1,322.2 ns |  9.15 ns |  8.11 ns |  1.49 |    0.01 | 2.4433 |     - |     - |   4.99 KB |
|                           ValueLinq_Ref_Stack |   100 | 1,272.1 ns |  4.55 ns |  4.03 ns |  1.43 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|                 ValueLinq_Ref_SharedPool_Push |   100 | 1,556.0 ns |  5.77 ns |  5.12 ns |  1.75 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|                 ValueLinq_Ref_SharedPool_Pull |   100 | 1,540.1 ns |  7.67 ns |  6.41 ns |  1.73 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|                ValueLinq_ValueLambda_Standard |   100 | 1,113.6 ns |  5.04 ns |  4.72 ns |  1.25 |    0.01 | 2.4433 |     - |     - |   4.99 KB |
|                   ValueLinq_ValueLambda_Stack |   100 | 1,252.9 ns |  6.38 ns |  5.33 ns |  1.41 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|         ValueLinq_ValueLambda_SharedPool_Push |   100 | 1,335.1 ns |  3.01 ns |  2.81 ns |  1.50 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|         ValueLinq_ValueLambda_SharedPool_Pull |   100 | 1,553.3 ns |  6.86 ns |  6.08 ns |  1.75 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|                    ValueLinq_Standard_ByIndex |   100 | 1,442.2 ns | 11.41 ns | 10.12 ns |  1.62 |    0.01 | 2.4433 |     - |     - |   4.99 KB |
|                       ValueLinq_Stack_ByIndex |   100 | 1,175.9 ns |  8.64 ns |  8.08 ns |  1.32 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|             ValueLinq_SharedPool_Push_ByIndex |   100 | 1,729.9 ns |  9.24 ns |  8.64 ns |  1.95 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|             ValueLinq_SharedPool_Pull_ByIndex |   100 | 1,453.0 ns |  7.42 ns |  6.19 ns |  1.64 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|                ValueLinq_Ref_Standard_ByIndex |   100 | 1,333.5 ns |  4.02 ns |  3.35 ns |  1.50 |    0.01 | 2.4433 |     - |     - |   4.99 KB |
|                   ValueLinq_Ref_Stack_ByIndex |   100 | 1,096.1 ns |  6.44 ns |  5.71 ns |  1.23 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|         ValueLinq_Ref_SharedPool_Push_ByIndex |   100 | 1,580.9 ns |  9.38 ns |  8.31 ns |  1.78 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|         ValueLinq_Ref_SharedPool_Pull_ByIndex |   100 | 1,366.4 ns |  3.71 ns |  3.47 ns |  1.54 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|        ValueLinq_ValueLambda_Standard_ByIndex |   100 | 1,139.0 ns |  4.72 ns |  4.19 ns |  1.28 |    0.01 | 2.4433 |     - |     - |   4.99 KB |
|           ValueLinq_ValueLambda_Stack_ByIndex |   100 | 1,134.7 ns |  3.02 ns |  2.52 ns |  1.28 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |   100 | 1,342.5 ns |  6.31 ns |  5.27 ns |  1.51 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |   100 | 1,312.3 ns |  5.16 ns |  4.83 ns |  1.48 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|                                       ForLoop |   100 |   888.8 ns |  4.99 ns |  4.42 ns |  1.00 |    0.00 | 2.4433 |     - |     - |   4.99 KB |
|                                   ForeachLoop |   100 | 1,098.4 ns |  6.74 ns |  6.31 ns |  1.24 |    0.01 | 2.4433 |     - |     - |   4.99 KB |
|                                          Linq |   100 | 1,282.9 ns | 15.53 ns | 14.53 ns |  1.44 |    0.02 | 2.5768 |     - |     - |   5.27 KB |
|                                    LinqFaster |   100 | 1,372.5 ns | 22.10 ns | 20.67 ns |  1.54 |    0.03 | 3.4237 |     - |     - |      7 KB |
|                                        LinqAF |   100 | 2,416.1 ns | 34.72 ns | 30.78 ns |  2.72 |    0.03 | 2.4414 |     - |     - |   4.99 KB |
|                                    StructLinq |   100 | 1,216.1 ns |  4.54 ns |  3.79 ns |  1.37 |    0.01 | 1.0319 |     - |     - |   2.11 KB |
|                          StructLinq_IFunction |   100 |   867.2 ns |  4.86 ns |  4.06 ns |  0.98 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|                                     Hyperlinq |   100 | 1,348.3 ns | 21.22 ns | 19.85 ns |  1.52 |    0.02 | 0.9823 |     - |     - |   2.01 KB |
|                           Hyperlinq_IFunction |   100 |   987.9 ns |  5.10 ns |  4.77 ns |  1.11 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
