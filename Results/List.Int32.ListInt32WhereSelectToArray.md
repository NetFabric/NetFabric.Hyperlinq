## List.Int32.ListInt32WhereSelectToArray

### Source
[ListInt32WhereSelectToArray.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelectToArray.cs)

### References:
- Cistern.ValueLinq: [0.0.11](https://www.nuget.org/packages/Cistern.ValueLinq/0.0.11)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.19.2](https://www.nuget.org/packages/StructLinq.BCL/0.19.2)
- NetFabric.Hyperlinq: [3.0.0-beta27](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta27)

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
|                            ValueLinq_Standard |   100 |   883.4 ns | 3.99 ns | 3.33 ns |  3.47 |    0.02 | 0.3557 |     - |     - |     744 B |
|                               ValueLinq_Stack |   100 |   859.4 ns | 2.90 ns | 2.57 ns |  3.38 |    0.02 | 0.1068 |     - |     - |     224 B |
|                     ValueLinq_SharedPool_Push |   100 |   958.4 ns | 2.28 ns | 2.02 ns |  3.77 |    0.02 | 0.1068 |     - |     - |     224 B |
|                     ValueLinq_SharedPool_Pull |   100 | 1,125.0 ns | 3.58 ns | 3.35 ns |  4.43 |    0.04 | 0.1068 |     - |     - |     224 B |
|                ValueLinq_ValueLambda_Standard |   100 |   705.4 ns | 1.94 ns | 1.72 ns |  2.78 |    0.01 | 0.3557 |     - |     - |     744 B |
|                   ValueLinq_ValueLambda_Stack |   100 |   633.6 ns | 1.68 ns | 1.40 ns |  2.49 |    0.02 | 0.1068 |     - |     - |     224 B |
|         ValueLinq_ValueLambda_SharedPool_Push |   100 |   795.9 ns | 1.63 ns | 1.45 ns |  3.13 |    0.02 | 0.1068 |     - |     - |     224 B |
|         ValueLinq_ValueLambda_SharedPool_Pull |   100 |   956.6 ns | 4.07 ns | 3.60 ns |  3.76 |    0.03 | 0.1068 |     - |     - |     224 B |
|                    ValueLinq_Standard_ByIndex |   100 |   723.7 ns | 2.18 ns | 1.93 ns |  2.85 |    0.02 | 0.3557 |     - |     - |     744 B |
|                       ValueLinq_Stack_ByIndex |   100 |   527.1 ns | 2.59 ns | 2.16 ns |  2.07 |    0.01 | 0.1068 |     - |     - |     224 B |
|             ValueLinq_SharedPool_Push_ByIndex |   100 |   720.3 ns | 2.88 ns | 2.55 ns |  2.83 |    0.02 | 0.1068 |     - |     - |     224 B |
|             ValueLinq_SharedPool_Pull_ByIndex |   100 |   707.9 ns | 1.74 ns | 1.62 ns |  2.79 |    0.02 | 0.1068 |     - |     - |     224 B |
|        ValueLinq_ValueLambda_Standard_ByIndex |   100 |   555.1 ns | 2.81 ns | 2.49 ns |  2.18 |    0.02 | 0.3557 |     - |     - |     744 B |
|           ValueLinq_ValueLambda_Stack_ByIndex |   100 |   297.5 ns | 1.04 ns | 0.97 ns |  1.17 |    0.01 | 0.1068 |     - |     - |     224 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |   100 |   531.7 ns | 2.48 ns | 2.32 ns |  2.09 |    0.01 | 0.1068 |     - |     - |     224 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |   100 |   539.8 ns | 1.27 ns | 1.13 ns |  2.12 |    0.01 | 0.1068 |     - |     - |     224 B |
|                                       ForLoop |   100 |   254.1 ns | 1.68 ns | 1.49 ns |  1.00 |    0.00 | 0.4168 |     - |     - |     872 B |
|                                   ForeachLoop |   100 |   424.4 ns | 2.07 ns | 1.84 ns |  1.67 |    0.01 | 0.4168 |     - |     - |     872 B |
|                                          Linq |   100 |   561.0 ns | 2.92 ns | 2.44 ns |  2.21 |    0.02 | 0.3939 |     - |     - |     824 B |
|                                    LinqFaster |   100 |   526.6 ns | 1.10 ns | 0.92 ns |  2.07 |    0.01 | 0.4168 |     - |     - |     872 B |
|                                        LinqAF |   100 | 1,081.9 ns | 2.50 ns | 2.21 ns |  4.26 |    0.02 | 0.4005 |     - |     - |     840 B |
|                                    StructLinq |   100 |   559.9 ns | 2.32 ns | 2.17 ns |  2.20 |    0.02 | 0.1564 |     - |     - |     328 B |
|                          StructLinq_IFunction |   100 |   352.3 ns | 2.29 ns | 2.03 ns |  1.39 |    0.01 | 0.1068 |     - |     - |     224 B |
|                                     Hyperlinq |   100 |   582.6 ns | 2.97 ns | 2.63 ns |  2.29 |    0.02 | 0.1068 |     - |     - |     224 B |
|                           Hyperlinq_IFunction |   100 |   333.2 ns | 0.92 ns | 0.86 ns |  1.31 |    0.01 | 0.1068 |     - |     - |     224 B |
|                                Hyperlinq_Pool |   100 |   642.1 ns | 3.22 ns | 3.01 ns |  2.53 |    0.02 | 0.0267 |     - |     - |      56 B |
|                      Hyperlinq_Pool_IFunction |   100 |   386.9 ns | 1.74 ns | 1.45 ns |  1.52 |    0.01 | 0.0267 |     - |     - |      56 B |
