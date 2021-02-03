## List.ValueType.ListValueTypeWhereSelectToList

### Source
[ListValueTypeWhereSelectToList.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelectToList.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta31](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta31)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                                        Method | Count |       Mean |    Error |    StdDev |     Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------------------------- |------ |-----------:|---------:|----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|                            ValueLinq_Standard |   100 | 1,422.7 ns | 14.36 ns |  11.99 ns | 1,421.4 ns |  1.57 |    0.02 | 2.4433 |     - |     - |   4.99 KB |
|                               ValueLinq_Stack |   100 | 1,364.6 ns |  8.58 ns |   7.16 ns | 1,364.6 ns |  1.51 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|                     ValueLinq_SharedPool_Push |   100 | 1,703.2 ns | 12.34 ns |  10.94 ns | 1,700.1 ns |  1.88 |    0.02 | 0.9823 |     - |     - |   2.01 KB |
|                     ValueLinq_SharedPool_Pull |   100 | 1,647.2 ns | 10.54 ns |   9.86 ns | 1,645.3 ns |  1.82 |    0.02 | 0.9823 |     - |     - |   2.01 KB |
|                        ValueLinq_Ref_Standard |   100 | 1,631.0 ns |  8.00 ns |   7.09 ns | 1,630.2 ns |  1.80 |    0.02 | 2.4433 |     - |     - |   4.99 KB |
|                           ValueLinq_Ref_Stack |   100 | 1,372.2 ns | 49.21 ns | 133.05 ns | 1,315.0 ns |  1.64 |    0.26 | 0.9804 |     - |     - |   2.01 KB |
|                 ValueLinq_Ref_SharedPool_Push |   100 | 1,540.1 ns |  6.76 ns |   5.64 ns | 1,539.0 ns |  1.70 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|                 ValueLinq_Ref_SharedPool_Pull |   100 | 1,540.6 ns |  8.16 ns |   6.81 ns | 1,539.6 ns |  1.70 |    0.02 | 0.9823 |     - |     - |   2.01 KB |
|                ValueLinq_ValueLambda_Standard |   100 | 1,113.1 ns |  8.14 ns |   6.80 ns | 1,114.2 ns |  1.23 |    0.01 | 2.4433 |     - |     - |   4.99 KB |
|                   ValueLinq_ValueLambda_Stack |   100 | 1,268.2 ns |  9.40 ns |   8.33 ns | 1,268.6 ns |  1.40 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|         ValueLinq_ValueLambda_SharedPool_Push |   100 | 1,332.2 ns |  3.89 ns |   3.45 ns | 1,333.0 ns |  1.47 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|         ValueLinq_ValueLambda_SharedPool_Pull |   100 | 1,514.5 ns |  5.92 ns |   5.54 ns | 1,515.3 ns |  1.67 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|                    ValueLinq_Standard_ByIndex |   100 | 1,824.0 ns | 10.79 ns |  10.09 ns | 1,820.7 ns |  2.02 |    0.02 | 2.4433 |     - |     - |   4.99 KB |
|                       ValueLinq_Stack_ByIndex |   100 | 1,155.3 ns |  8.44 ns |   7.89 ns | 1,156.7 ns |  1.28 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|             ValueLinq_SharedPool_Push_ByIndex |   100 | 1,720.5 ns | 13.08 ns |  12.24 ns | 1,723.5 ns |  1.90 |    0.02 | 0.9823 |     - |     - |   2.01 KB |
|             ValueLinq_SharedPool_Pull_ByIndex |   100 | 1,446.1 ns |  7.92 ns |   6.61 ns | 1,443.3 ns |  1.60 |    0.02 | 0.9823 |     - |     - |   2.01 KB |
|                ValueLinq_Ref_Standard_ByIndex |   100 | 1,326.7 ns |  9.44 ns |   8.83 ns | 1,325.7 ns |  1.47 |    0.02 | 2.4433 |     - |     - |   4.99 KB |
|                   ValueLinq_Ref_Stack_ByIndex |   100 | 1,119.0 ns |  6.04 ns |   5.35 ns | 1,118.3 ns |  1.24 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|         ValueLinq_Ref_SharedPool_Push_ByIndex |   100 | 1,561.9 ns |  6.07 ns |   5.38 ns | 1,561.8 ns |  1.73 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|         ValueLinq_Ref_SharedPool_Pull_ByIndex |   100 | 1,398.0 ns | 12.52 ns |  11.71 ns | 1,392.6 ns |  1.55 |    0.02 | 0.9823 |     - |     - |   2.01 KB |
|        ValueLinq_ValueLambda_Standard_ByIndex |   100 | 1,133.2 ns | 10.75 ns |   9.53 ns | 1,134.9 ns |  1.25 |    0.01 | 2.4433 |     - |     - |   4.99 KB |
|           ValueLinq_ValueLambda_Stack_ByIndex |   100 | 1,113.4 ns |  3.90 ns |   3.25 ns | 1,112.8 ns |  1.23 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |   100 | 1,346.6 ns |  5.58 ns |   4.66 ns | 1,347.1 ns |  1.49 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |   100 | 1,303.3 ns |  9.86 ns |   8.23 ns | 1,298.7 ns |  1.44 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|                                       ForLoop |   100 |   904.6 ns |  6.79 ns |   6.35 ns |   903.4 ns |  1.00 |    0.00 | 2.4433 |     - |     - |   4.99 KB |
|                                   ForeachLoop |   100 | 1,091.5 ns |  7.07 ns |   6.61 ns | 1,094.0 ns |  1.21 |    0.01 | 2.4433 |     - |     - |   4.99 KB |
|                                          Linq |   100 | 1,284.8 ns | 11.22 ns |   9.94 ns | 1,285.5 ns |  1.42 |    0.02 | 2.5768 |     - |     - |   5.27 KB |
|                                    LinqFaster |   100 | 1,407.7 ns |  8.07 ns |   7.16 ns | 1,407.4 ns |  1.56 |    0.01 | 3.4237 |     - |     - |      7 KB |
|                                        LinqAF |   100 | 2,490.4 ns | 32.51 ns |  30.41 ns | 2,493.7 ns |  2.75 |    0.04 | 2.4414 |     - |     - |   4.99 KB |
|                                    StructLinq |   100 | 1,162.6 ns |  3.81 ns |   3.38 ns | 1,161.6 ns |  1.29 |    0.01 | 1.0319 |     - |     - |   2.11 KB |
|                          StructLinq_IFunction |   100 |   867.2 ns |  2.64 ns |   2.47 ns |   866.8 ns |  0.96 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|                                     Hyperlinq |   100 | 1,084.6 ns |  3.98 ns |   3.72 ns | 1,084.2 ns |  1.20 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|                           Hyperlinq_IFunction |   100 |   818.1 ns |  2.07 ns |   1.73 ns |   817.9 ns |  0.90 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
