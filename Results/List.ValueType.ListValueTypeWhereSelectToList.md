## List.ValueType.ListValueTypeWhereSelectToList

### Source
[ListValueTypeWhereSelectToList.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelectToList.cs)

### References:
- Cistern.ValueLinq: [0.0.11](https://www.nuget.org/packages/Cistern.ValueLinq/0.0.11)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta28](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta28)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                                            Method | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------------------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                                ValueLinq_Standard |   100 | 2,025.4 ns | 18.86 ns | 16.72 ns |  2.03 |    0.03 | 2.4414 |     - |     - |   4.99 KB |
|                                   ValueLinq_Stack |   100 | 1,822.9 ns | 16.01 ns | 14.98 ns |  1.82 |    0.02 | 0.9823 |     - |     - |   2.01 KB |
|                         ValueLinq_SharedPool_Push |   100 | 2,203.6 ns | 21.08 ns | 18.69 ns |  2.20 |    0.02 | 0.9804 |     - |     - |   2.01 KB |
|                         ValueLinq_SharedPool_Pull |   100 | 2,169.7 ns | 12.76 ns | 11.93 ns |  2.17 |    0.02 | 0.9804 |     - |     - |   2.01 KB |
|                            ValueLinq_Ref_Standard |   100 | 1,879.0 ns | 10.34 ns |  9.67 ns |  1.88 |    0.02 | 2.4414 |     - |     - |   4.99 KB |
|                               ValueLinq_Ref_Stack |   100 | 2,834.8 ns | 13.62 ns | 12.07 ns |  2.84 |    0.03 | 0.9823 |     - |     - |   2.01 KB |
|                     ValueLinq_Ref_SharedPool_Push |   100 | 2,194.4 ns |  5.58 ns |  4.66 ns |  2.20 |    0.02 | 0.9804 |     - |     - |   2.01 KB |
|                     ValueLinq_Ref_SharedPool_Pull |   100 | 2,076.2 ns |  9.36 ns |  8.76 ns |  2.08 |    0.02 | 0.9804 |     - |     - |   2.01 KB |
|                    ValueLinq_ValueLambda_Standard |   100 | 1,524.3 ns |  7.93 ns |  7.03 ns |  1.52 |    0.02 | 2.4433 |     - |     - |   4.99 KB |
|                       ValueLinq_ValueLambda_Stack |   100 | 1,800.3 ns |  9.94 ns |  8.81 ns |  1.80 |    0.02 | 0.9823 |     - |     - |   2.01 KB |
|             ValueLinq_ValueLambda_SharedPool_Push |   100 | 1,797.9 ns |  9.49 ns |  8.41 ns |  1.80 |    0.02 | 0.9823 |     - |     - |   2.01 KB |
|             ValueLinq_ValueLambda_SharedPool_Pull |   100 | 1,991.5 ns | 10.48 ns |  9.29 ns |  1.99 |    0.02 | 0.9804 |     - |     - |   2.01 KB |
|                ValueLinq_ValueLambda_Ref_Standard |   100 | 1,283.9 ns | 11.23 ns |  9.96 ns |  1.28 |    0.01 | 2.4433 |     - |     - |   4.99 KB |
|                   ValueLinq_ValueLambda_Ref_Stack |   100 | 1,544.5 ns | 10.10 ns |  8.44 ns |  1.55 |    0.02 | 0.9823 |     - |     - |   2.01 KB |
|         ValueLinq_ValueLambda_Ref_SharedPool_Push |   100 | 1,535.5 ns |  7.03 ns |  6.57 ns |  1.53 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|         ValueLinq_ValueLambda_Ref_SharedPool_Pull |   100 | 1,808.5 ns | 12.80 ns | 11.97 ns |  1.81 |    0.02 | 0.9823 |     - |     - |   2.01 KB |
|                        ValueLinq_Standard_ByIndex |   100 | 1,703.3 ns | 12.92 ns | 11.45 ns |  1.70 |    0.02 | 2.4433 |     - |     - |   4.99 KB |
|                           ValueLinq_Stack_ByIndex |   100 | 1,384.2 ns |  5.90 ns |  5.23 ns |  1.38 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|                 ValueLinq_SharedPool_Push_ByIndex |   100 | 1,975.2 ns | 10.33 ns |  9.66 ns |  1.97 |    0.02 | 0.9804 |     - |     - |   2.01 KB |
|                 ValueLinq_SharedPool_Pull_ByIndex |   100 | 1,658.5 ns |  9.13 ns |  8.10 ns |  1.66 |    0.02 | 0.9823 |     - |     - |   2.01 KB |
|                    ValueLinq_Ref_Standard_ByIndex |   100 | 1,587.9 ns | 14.82 ns | 13.86 ns |  1.59 |    0.01 | 2.4433 |     - |     - |   4.99 KB |
|                       ValueLinq_Ref_Stack_ByIndex |   100 | 1,264.0 ns |  6.20 ns |  5.49 ns |  1.26 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|             ValueLinq_Ref_SharedPool_Push_ByIndex |   100 | 1,833.4 ns |  5.35 ns |  4.75 ns |  1.83 |    0.02 | 0.9823 |     - |     - |   2.01 KB |
|             ValueLinq_Ref_SharedPool_Pull_ByIndex |   100 | 1,583.2 ns |  9.21 ns |  7.69 ns |  1.58 |    0.02 | 0.9823 |     - |     - |   2.01 KB |
|            ValueLinq_ValueLambda_Standard_ByIndex |   100 | 1,271.1 ns | 14.23 ns | 11.89 ns |  1.27 |    0.02 | 2.4433 |     - |     - |   4.99 KB |
|               ValueLinq_ValueLambda_Stack_ByIndex |   100 | 1,389.2 ns | 12.28 ns | 10.89 ns |  1.39 |    0.02 | 0.9823 |     - |     - |   2.01 KB |
|     ValueLinq_ValueLambda_SharedPool_Push_ByIndex |   100 | 1,493.5 ns |  9.20 ns |  8.16 ns |  1.49 |    0.02 | 0.9823 |     - |     - |   2.01 KB |
|     ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |   100 | 1,506.0 ns |  7.05 ns |  5.89 ns |  1.51 |    0.02 | 0.9823 |     - |     - |   2.01 KB |
|        ValueLinq_ValueLambda_Ref_Standard_ByIndex |   100 | 1,247.7 ns | 11.55 ns | 10.24 ns |  1.25 |    0.02 | 2.4433 |     - |     - |   4.99 KB |
|           ValueLinq_ValueLambda_Ref_Stack_ByIndex |   100 | 1,185.9 ns |  3.73 ns |  3.31 ns |  1.19 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
| ValueLinq_ValueLambda_Ref_SharedPool_Push_ByIndex |   100 | 1,491.8 ns | 12.95 ns | 11.48 ns |  1.49 |    0.02 | 0.9823 |     - |     - |   2.01 KB |
| ValueLinq_ValueLambda_Ref_SharedPool_Pull_ByIndex |   100 | 1,365.4 ns |  9.96 ns |  8.83 ns |  1.37 |    0.02 | 0.9823 |     - |     - |   2.01 KB |
|                                           ForLoop |   100 | 1,000.5 ns | 10.03 ns |  9.38 ns |  1.00 |    0.00 | 2.4433 |     - |     - |   4.99 KB |
|                                       ForeachLoop |   100 | 1,239.7 ns | 13.61 ns | 12.06 ns |  1.24 |    0.01 | 2.4433 |     - |     - |   4.99 KB |
|                                              Linq |   100 | 1,421.2 ns |  9.01 ns |  7.99 ns |  1.42 |    0.01 | 2.5768 |     - |     - |   5.27 KB |
|                                        LinqFaster |   100 | 1,610.5 ns |  5.43 ns |  4.81 ns |  1.61 |    0.02 | 3.4237 |     - |     - |      7 KB |
|                                            LinqAF |   100 | 2,707.7 ns | 17.35 ns | 16.23 ns |  2.71 |    0.03 | 2.4414 |     - |     - |   4.99 KB |
|                                        StructLinq |   100 | 1,346.8 ns |  7.24 ns |  6.77 ns |  1.35 |    0.02 | 1.0319 |     - |     - |   2.11 KB |
|                              StructLinq_IFunction |   100 |   981.3 ns |  9.67 ns |  9.05 ns |  0.98 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|                                         Hyperlinq |   100 | 1,528.1 ns | 11.71 ns | 10.38 ns |  1.53 |    0.02 | 1.0166 |     - |     - |   2.08 KB |
|                               Hyperlinq_IFunction |   100 | 1,106.0 ns |  5.43 ns |  4.81 ns |  1.11 |    0.01 | 1.0166 |     - |     - |   2.08 KB |
