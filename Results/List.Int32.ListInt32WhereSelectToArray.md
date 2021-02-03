## List.Int32.ListInt32WhereSelectToArray

### Source
[ListInt32WhereSelectToArray.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelectToArray.cs)

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
|                                        Method | Count |       Mean |   Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------------------------- |------ |-----------:|--------:|--------:|------:|--------:|-------:|------:|------:|----------:|
|                            ValueLinq_Standard |   100 |   745.6 ns | 1.65 ns | 1.46 ns |  2.91 |    0.02 | 0.1068 |     - |     - |     224 B |
|                               ValueLinq_Stack |   100 |   721.4 ns | 1.40 ns | 1.17 ns |  2.81 |    0.01 | 0.1068 |     - |     - |     224 B |
|                     ValueLinq_SharedPool_Push |   100 |   820.9 ns | 2.37 ns | 2.10 ns |  3.20 |    0.02 | 0.1068 |     - |     - |     224 B |
|                     ValueLinq_SharedPool_Pull |   100 |   847.5 ns | 2.12 ns | 1.77 ns |  3.30 |    0.01 | 0.1068 |     - |     - |     224 B |
|                ValueLinq_ValueLambda_Standard |   100 |   494.3 ns | 1.83 ns | 1.71 ns |  1.93 |    0.01 | 0.1068 |     - |     - |     224 B |
|                   ValueLinq_ValueLambda_Stack |   100 |   470.2 ns | 1.78 ns | 1.39 ns |  1.83 |    0.01 | 0.1068 |     - |     - |     224 B |
|         ValueLinq_ValueLambda_SharedPool_Push |   100 |   528.1 ns | 2.17 ns | 1.93 ns |  2.06 |    0.01 | 0.1068 |     - |     - |     224 B |
|         ValueLinq_ValueLambda_SharedPool_Pull |   100 |   711.8 ns | 3.82 ns | 3.39 ns |  2.77 |    0.02 | 0.1068 |     - |     - |     224 B |
|                    ValueLinq_Standard_ByIndex |   100 |   591.5 ns | 2.55 ns | 2.13 ns |  2.31 |    0.01 | 0.1068 |     - |     - |     224 B |
|                       ValueLinq_Stack_ByIndex |   100 |   546.6 ns | 3.17 ns | 2.81 ns |  2.13 |    0.02 | 0.1068 |     - |     - |     224 B |
|             ValueLinq_SharedPool_Push_ByIndex |   100 |   835.5 ns | 1.71 ns | 1.60 ns |  3.26 |    0.02 | 0.1068 |     - |     - |     224 B |
|             ValueLinq_SharedPool_Pull_ByIndex |   100 |   715.5 ns | 2.57 ns | 2.28 ns |  2.79 |    0.02 | 0.1068 |     - |     - |     224 B |
|        ValueLinq_ValueLambda_Standard_ByIndex |   100 |   343.0 ns | 1.35 ns | 1.20 ns |  1.34 |    0.01 | 0.1068 |     - |     - |     224 B |
|           ValueLinq_ValueLambda_Stack_ByIndex |   100 |   304.2 ns | 1.43 ns | 1.27 ns |  1.19 |    0.01 | 0.1068 |     - |     - |     224 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |   100 |   513.9 ns | 1.89 ns | 1.58 ns |  2.00 |    0.01 | 0.1068 |     - |     - |     224 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |   100 |   543.6 ns | 3.25 ns | 2.88 ns |  2.12 |    0.01 | 0.1068 |     - |     - |     224 B |
|                                       ForLoop |   100 |   256.6 ns | 1.29 ns | 1.21 ns |  1.00 |    0.00 | 0.4168 |     - |     - |     872 B |
|                                   ForeachLoop |   100 |   433.8 ns | 1.21 ns | 1.13 ns |  1.69 |    0.01 | 0.4168 |     - |     - |     872 B |
|                                          Linq |   100 |   562.6 ns | 2.36 ns | 2.09 ns |  2.19 |    0.01 | 0.3939 |     - |     - |     824 B |
|                                    LinqFaster |   100 |   463.7 ns | 1.62 ns | 1.52 ns |  1.81 |    0.01 | 0.4168 |     - |     - |     872 B |
|                                        LinqAF |   100 | 1,065.6 ns | 2.57 ns | 2.14 ns |  4.15 |    0.02 | 0.4005 |     - |     - |     840 B |
|                                    StructLinq |   100 |   520.7 ns | 1.43 ns | 1.19 ns |  2.03 |    0.01 | 0.1526 |     - |     - |     320 B |
|                          StructLinq_IFunction |   100 |   271.8 ns | 0.45 ns | 0.38 ns |  1.06 |    0.00 | 0.1068 |     - |     - |     224 B |
|                                     Hyperlinq |   100 |   572.9 ns | 2.00 ns | 1.77 ns |  2.23 |    0.01 | 0.1068 |     - |     - |     224 B |
|                           Hyperlinq_IFunction |   100 |   372.3 ns | 0.61 ns | 0.51 ns |  1.45 |    0.01 | 0.1068 |     - |     - |     224 B |
|                                Hyperlinq_Pool |   100 |   653.1 ns | 2.48 ns | 2.20 ns |  2.55 |    0.01 | 0.0267 |     - |     - |      56 B |
|                      Hyperlinq_Pool_IFunction |   100 |   382.5 ns | 1.22 ns | 1.08 ns |  1.49 |    0.01 | 0.0267 |     - |     - |      56 B |
