## List.ValueType.ListValueTypeWhereSelectToList

### Source
[ListValueTypeWhereSelectToList.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelectToList.cs)

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
|                            ValueLinq_Standard |   100 | 1,507.6 ns | 14.41 ns | 13.48 ns |  1.56 |    0.02 | 2.4433 |     - |     - |   4.99 KB |
|                               ValueLinq_Stack |   100 | 1,517.6 ns |  8.31 ns |  7.37 ns |  1.57 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
|                     ValueLinq_SharedPool_Push |   100 | 1,817.2 ns |  9.80 ns |  8.18 ns |  1.88 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
|                     ValueLinq_SharedPool_Pull |   100 | 1,794.2 ns |  6.61 ns |  6.18 ns |  1.86 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
|                        ValueLinq_Ref_Standard |   100 | 1,414.8 ns |  6.98 ns |  6.53 ns |  1.47 |    0.01 | 2.4433 |     - |     - |   4.99 KB |
|                           ValueLinq_Ref_Stack |   100 | 1,422.8 ns |  6.80 ns |  6.02 ns |  1.47 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
|                 ValueLinq_Ref_SharedPool_Push |   100 | 1,647.1 ns |  4.83 ns |  4.03 ns |  1.71 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
|                 ValueLinq_Ref_SharedPool_Pull |   100 | 1,767.9 ns |  8.69 ns |  7.26 ns |  1.83 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
|                ValueLinq_ValueLambda_Standard |   100 | 1,199.9 ns |  9.20 ns |  8.60 ns |  1.24 |    0.01 | 2.4433 |     - |     - |   4.99 KB |
|                   ValueLinq_ValueLambda_Stack |   100 | 1,435.1 ns |  7.72 ns |  7.22 ns |  1.49 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
|         ValueLinq_ValueLambda_SharedPool_Push |   100 | 1,448.9 ns |  7.67 ns |  6.40 ns |  1.50 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
|         ValueLinq_ValueLambda_SharedPool_Pull |   100 | 1,625.2 ns |  6.73 ns |  5.62 ns |  1.68 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
|                    ValueLinq_Standard_ByIndex |   100 | 1,556.5 ns | 12.87 ns | 11.41 ns |  1.61 |    0.02 | 2.4433 |     - |     - |   4.99 KB |
|                       ValueLinq_Stack_ByIndex |   100 | 1,291.5 ns |  4.67 ns |  4.37 ns |  1.34 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
|             ValueLinq_SharedPool_Push_ByIndex |   100 | 1,871.0 ns | 17.97 ns | 16.81 ns |  1.94 |    0.02 | 1.0567 |     - |     - |   2.16 KB |
|             ValueLinq_SharedPool_Pull_ByIndex |   100 | 1,640.9 ns |  4.37 ns |  3.65 ns |  1.70 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
|                ValueLinq_Ref_Standard_ByIndex |   100 | 1,439.1 ns |  6.63 ns |  5.53 ns |  1.49 |    0.01 | 2.4433 |     - |     - |   4.99 KB |
|                   ValueLinq_Ref_Stack_ByIndex |   100 | 1,224.0 ns |  7.74 ns |  6.47 ns |  1.27 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
|         ValueLinq_Ref_SharedPool_Push_ByIndex |   100 | 1,728.2 ns |  5.60 ns |  5.24 ns |  1.79 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
|         ValueLinq_Ref_SharedPool_Pull_ByIndex |   100 | 1,481.6 ns | 10.85 ns |  9.06 ns |  1.54 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
|        ValueLinq_ValueLambda_Standard_ByIndex |   100 | 1,251.6 ns |  9.67 ns |  8.58 ns |  1.30 |    0.01 | 2.4433 |     - |     - |   4.99 KB |
|           ValueLinq_ValueLambda_Stack_ByIndex |   100 | 1,198.5 ns |  5.15 ns |  4.30 ns |  1.24 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |   100 | 1,472.0 ns |  5.65 ns |  4.72 ns |  1.53 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |   100 | 1,435.6 ns |  6.12 ns |  5.42 ns |  1.49 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
|                                       ForLoop |   100 |   964.8 ns |  7.07 ns |  6.26 ns |  1.00 |    0.00 | 2.4433 |     - |     - |   4.99 KB |
|                                   ForeachLoop |   100 | 1,173.6 ns |  8.70 ns |  8.14 ns |  1.22 |    0.01 | 2.4433 |     - |     - |   4.99 KB |
|                                          Linq |   100 | 1,364.1 ns | 14.84 ns | 13.88 ns |  1.41 |    0.02 | 2.5768 |     - |     - |   5.27 KB |
|                                    LinqFaster |   100 | 1,440.4 ns | 11.14 ns | 10.42 ns |  1.49 |    0.02 | 3.5019 |     - |     - |   7.16 KB |
|                                        LinqAF |   100 | 2,785.7 ns | 47.63 ns | 42.23 ns |  2.89 |    0.05 | 2.4414 |     - |     - |   4.99 KB |
|                                    StructLinq |   100 | 1,319.7 ns | 12.99 ns | 10.85 ns |  1.37 |    0.02 | 1.1082 |     - |     - |   2.27 KB |
|                          StructLinq_IFunction |   100 |   922.0 ns |  3.41 ns |  3.02 ns |  0.96 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
|                                     Hyperlinq |   100 | 1,148.5 ns |  4.34 ns |  4.06 ns |  1.19 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
|                           Hyperlinq_IFunction |   100 |   905.4 ns |  5.84 ns |  5.18 ns |  0.94 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
