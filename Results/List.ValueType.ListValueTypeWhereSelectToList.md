## List.ValueType.ListValueTypeWhereSelectToList

### Source
[ListValueTypeWhereSelectToList.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelectToList.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta34](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta34)

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
|                            ValueLinq_Standard |   100 | 1,458.1 ns |  7.54 ns |  6.68 ns |  1.56 |    0.01 | 2.4433 |     - |     - |   4.99 KB |
|                               ValueLinq_Stack |   100 | 1,451.4 ns | 12.05 ns | 10.07 ns |  1.56 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
|                     ValueLinq_SharedPool_Push |   100 | 1,809.6 ns | 12.47 ns | 11.05 ns |  1.94 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
|                     ValueLinq_SharedPool_Pull |   100 | 1,668.7 ns |  6.00 ns |  5.61 ns |  1.79 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
|                        ValueLinq_Ref_Standard |   100 | 1,367.8 ns | 10.97 ns |  9.16 ns |  1.47 |    0.01 | 2.4433 |     - |     - |   4.99 KB |
|                           ValueLinq_Ref_Stack |   100 | 1,358.3 ns |  6.95 ns |  6.17 ns |  1.46 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
|                 ValueLinq_Ref_SharedPool_Push |   100 | 1,627.1 ns |  5.60 ns |  4.37 ns |  1.74 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
|                 ValueLinq_Ref_SharedPool_Pull |   100 | 1,717.9 ns |  5.33 ns |  4.45 ns |  1.84 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
|                ValueLinq_ValueLambda_Standard |   100 | 1,153.4 ns |  7.00 ns |  6.21 ns |  1.24 |    0.01 | 2.4433 |     - |     - |   4.99 KB |
|                   ValueLinq_ValueLambda_Stack |   100 | 1,375.6 ns |  8.88 ns |  8.30 ns |  1.47 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
|         ValueLinq_ValueLambda_SharedPool_Push |   100 | 1,396.4 ns |  4.49 ns |  3.98 ns |  1.50 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
|         ValueLinq_ValueLambda_SharedPool_Pull |   100 | 1,578.3 ns |  5.73 ns |  4.78 ns |  1.69 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
|                    ValueLinq_Standard_ByIndex |   100 | 1,492.7 ns |  8.93 ns |  8.36 ns |  1.60 |    0.01 | 2.4433 |     - |     - |   4.99 KB |
|                       ValueLinq_Stack_ByIndex |   100 | 1,283.0 ns |  5.92 ns |  5.54 ns |  1.37 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
|             ValueLinq_SharedPool_Push_ByIndex |   100 | 1,857.3 ns | 12.86 ns | 12.03 ns |  1.99 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
|             ValueLinq_SharedPool_Pull_ByIndex |   100 | 1,604.6 ns |  6.62 ns |  6.19 ns |  1.72 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
|                ValueLinq_Ref_Standard_ByIndex |   100 | 1,350.3 ns |  5.49 ns |  5.14 ns |  1.45 |    0.01 | 2.4433 |     - |     - |   4.99 KB |
|                   ValueLinq_Ref_Stack_ByIndex |   100 | 1,175.4 ns |  5.78 ns |  5.12 ns |  1.26 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
|         ValueLinq_Ref_SharedPool_Push_ByIndex |   100 | 1,647.9 ns |  5.52 ns |  4.61 ns |  1.77 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
|         ValueLinq_Ref_SharedPool_Pull_ByIndex |   100 | 1,419.9 ns |  8.14 ns |  7.22 ns |  1.52 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
|        ValueLinq_ValueLambda_Standard_ByIndex |   100 | 1,168.5 ns |  8.14 ns |  7.62 ns |  1.25 |    0.01 | 2.4433 |     - |     - |   4.99 KB |
|           ValueLinq_ValueLambda_Stack_ByIndex |   100 | 1,218.9 ns |  4.28 ns |  3.79 ns |  1.31 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |   100 | 1,425.7 ns |  7.19 ns |  6.38 ns |  1.53 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |   100 | 1,352.9 ns |  4.23 ns |  3.75 ns |  1.45 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
|                                       ForLoop |   100 |   933.2 ns |  3.14 ns |  2.94 ns |  1.00 |    0.00 | 2.4433 |     - |     - |   4.99 KB |
|                                   ForeachLoop |   100 | 1,140.8 ns |  9.87 ns |  9.24 ns |  1.22 |    0.01 | 2.4433 |     - |     - |   4.99 KB |
|                                          Linq |   100 | 1,360.6 ns |  7.88 ns |  6.99 ns |  1.46 |    0.01 | 2.5768 |     - |     - |   5.27 KB |
|                                    LinqFaster |   100 | 1,419.7 ns |  6.90 ns |  6.12 ns |  1.52 |    0.01 | 3.5019 |     - |     - |   7.16 KB |
|                                        LinqAF |   100 | 2,763.4 ns | 28.87 ns | 25.59 ns |  2.96 |    0.03 | 2.4414 |     - |     - |   4.99 KB |
|                                    StructLinq |   100 | 1,256.8 ns |  5.05 ns |  4.48 ns |  1.35 |    0.01 | 1.1082 |     - |     - |   2.27 KB |
|                          StructLinq_IFunction |   100 |   890.0 ns |  3.09 ns |  2.74 ns |  0.95 |    0.00 | 1.0586 |     - |     - |   2.16 KB |
|                                     Hyperlinq |   100 | 1,142.4 ns |  4.61 ns |  4.31 ns |  1.22 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
|                           Hyperlinq_IFunction |   100 |   893.5 ns |  2.61 ns |  2.31 ns |  0.96 |    0.00 | 1.0586 |     - |     - |   2.16 KB |
