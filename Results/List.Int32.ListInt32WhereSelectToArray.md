## List.Int32.ListInt32WhereSelectToArray

### Source
[ListInt32WhereSelectToArray.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelectToArray.cs)

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
|                                        Method | Count |       Mean |   Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------------------------- |------ |-----------:|--------:|--------:|------:|--------:|-------:|------:|------:|----------:|
|                            ValueLinq_Standard |   100 |   768.2 ns | 3.83 ns | 3.40 ns |  2.98 |    0.02 | 0.1068 |     - |     - |     224 B |
|                               ValueLinq_Stack |   100 |   731.0 ns | 2.15 ns | 1.91 ns |  2.83 |    0.02 | 0.1068 |     - |     - |     224 B |
|                     ValueLinq_SharedPool_Push |   100 |   749.3 ns | 2.62 ns | 2.19 ns |  2.90 |    0.01 | 0.1068 |     - |     - |     224 B |
|                     ValueLinq_SharedPool_Pull |   100 |   850.1 ns | 3.06 ns | 2.71 ns |  3.29 |    0.01 | 0.1068 |     - |     - |     224 B |
|                ValueLinq_ValueLambda_Standard |   100 |   482.8 ns | 1.51 ns | 1.41 ns |  1.87 |    0.01 | 0.1068 |     - |     - |     224 B |
|                   ValueLinq_ValueLambda_Stack |   100 |   480.0 ns | 1.29 ns | 1.21 ns |  1.86 |    0.01 | 0.1068 |     - |     - |     224 B |
|         ValueLinq_ValueLambda_SharedPool_Push |   100 |   516.9 ns | 1.54 ns | 1.36 ns |  2.00 |    0.01 | 0.1068 |     - |     - |     224 B |
|         ValueLinq_ValueLambda_SharedPool_Pull |   100 |   688.6 ns | 4.55 ns | 4.26 ns |  2.67 |    0.02 | 0.1068 |     - |     - |     224 B |
|                    ValueLinq_Standard_ByIndex |   100 |   592.9 ns | 2.39 ns | 1.99 ns |  2.30 |    0.01 | 0.1068 |     - |     - |     224 B |
|                       ValueLinq_Stack_ByIndex |   100 |   559.0 ns | 1.69 ns | 1.50 ns |  2.16 |    0.01 | 0.1068 |     - |     - |     224 B |
|             ValueLinq_SharedPool_Push_ByIndex |   100 |   852.5 ns | 1.55 ns | 1.30 ns |  3.30 |    0.01 | 0.1068 |     - |     - |     224 B |
|             ValueLinq_SharedPool_Pull_ByIndex |   100 |   706.2 ns | 2.87 ns | 2.54 ns |  2.74 |    0.02 | 0.1068 |     - |     - |     224 B |
|        ValueLinq_ValueLambda_Standard_ByIndex |   100 |   344.1 ns | 1.30 ns | 1.15 ns |  1.33 |    0.01 | 0.1068 |     - |     - |     224 B |
|           ValueLinq_ValueLambda_Stack_ByIndex |   100 |   317.9 ns | 1.39 ns | 1.30 ns |  1.23 |    0.01 | 0.1068 |     - |     - |     224 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |   100 |   534.5 ns | 1.30 ns | 1.22 ns |  2.07 |    0.01 | 0.1068 |     - |     - |     224 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |   100 |   544.7 ns | 1.35 ns | 1.19 ns |  2.11 |    0.01 | 0.1068 |     - |     - |     224 B |
|                                       ForLoop |   100 |   258.2 ns | 1.29 ns | 1.14 ns |  1.00 |    0.00 | 0.4168 |     - |     - |     872 B |
|                                   ForeachLoop |   100 |   400.1 ns | 1.12 ns | 0.99 ns |  1.55 |    0.01 | 0.4168 |     - |     - |     872 B |
|                                          Linq |   100 |   560.9 ns | 2.23 ns | 2.09 ns |  2.17 |    0.01 | 0.3939 |     - |     - |     824 B |
|                                    LinqFaster |   100 |   477.2 ns | 1.02 ns | 0.91 ns |  1.85 |    0.01 | 0.4168 |     - |     - |     872 B |
|                                        LinqAF |   100 | 1,074.1 ns | 6.81 ns | 6.37 ns |  4.16 |    0.03 | 0.4005 |     - |     - |     840 B |
|                                    StructLinq |   100 |   522.6 ns | 1.72 ns | 1.53 ns |  2.02 |    0.01 | 0.1526 |     - |     - |     320 B |
|                          StructLinq_IFunction |   100 |   270.4 ns | 0.94 ns | 0.73 ns |  1.05 |    0.00 | 0.1068 |     - |     - |     224 B |
|                                     Hyperlinq |   100 |   594.2 ns | 1.62 ns | 1.43 ns |  2.30 |    0.01 | 0.1068 |     - |     - |     224 B |
|                           Hyperlinq_IFunction |   100 |   333.1 ns | 1.57 ns | 1.39 ns |  1.29 |    0.01 | 0.1068 |     - |     - |     224 B |
|                                Hyperlinq_Pool |   100 |   647.6 ns | 1.86 ns | 1.65 ns |  2.51 |    0.01 | 0.0267 |     - |     - |      56 B |
|                      Hyperlinq_Pool_IFunction |   100 |   386.6 ns | 0.96 ns | 0.85 ns |  1.50 |    0.01 | 0.0267 |     - |     - |      56 B |
