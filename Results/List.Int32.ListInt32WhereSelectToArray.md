## List.Int32.ListInt32WhereSelectToArray

### Source
[ListInt32WhereSelectToArray.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelectToArray.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta32](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta32)

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
|                            ValueLinq_Standard |   100 |   785.6 ns | 3.49 ns | 2.92 ns |  2.62 |    0.02 | 0.1068 |     - |     - |     224 B |
|                               ValueLinq_Stack |   100 |   700.8 ns | 4.03 ns | 3.37 ns |  2.34 |    0.01 | 0.1068 |     - |     - |     224 B |
|                     ValueLinq_SharedPool_Push |   100 |   792.4 ns | 4.89 ns | 4.09 ns |  2.64 |    0.02 | 0.1068 |     - |     - |     224 B |
|                     ValueLinq_SharedPool_Pull |   100 |   856.8 ns | 2.40 ns | 2.00 ns |  2.86 |    0.01 | 0.1068 |     - |     - |     224 B |
|                ValueLinq_ValueLambda_Standard |   100 |   504.1 ns | 1.69 ns | 1.58 ns |  1.68 |    0.01 | 0.1068 |     - |     - |     224 B |
|                   ValueLinq_ValueLambda_Stack |   100 |   472.2 ns | 4.00 ns | 3.74 ns |  1.58 |    0.02 | 0.1068 |     - |     - |     224 B |
|         ValueLinq_ValueLambda_SharedPool_Push |   100 |   532.4 ns | 2.08 ns | 1.85 ns |  1.78 |    0.01 | 0.1068 |     - |     - |     224 B |
|         ValueLinq_ValueLambda_SharedPool_Pull |   100 |   720.0 ns | 3.23 ns | 2.86 ns |  2.40 |    0.01 | 0.1068 |     - |     - |     224 B |
|                    ValueLinq_Standard_ByIndex |   100 |   592.0 ns | 2.91 ns | 2.58 ns |  1.97 |    0.01 | 0.1068 |     - |     - |     224 B |
|                       ValueLinq_Stack_ByIndex |   100 |   559.8 ns | 2.05 ns | 1.60 ns |  1.87 |    0.01 | 0.1068 |     - |     - |     224 B |
|             ValueLinq_SharedPool_Push_ByIndex |   100 |   835.8 ns | 2.98 ns | 2.49 ns |  2.79 |    0.02 | 0.1068 |     - |     - |     224 B |
|             ValueLinq_SharedPool_Pull_ByIndex |   100 |   724.4 ns | 2.76 ns | 2.45 ns |  2.41 |    0.01 | 0.1068 |     - |     - |     224 B |
|        ValueLinq_ValueLambda_Standard_ByIndex |   100 |   353.2 ns | 2.51 ns | 2.23 ns |  1.18 |    0.01 | 0.1068 |     - |     - |     224 B |
|           ValueLinq_ValueLambda_Stack_ByIndex |   100 |   311.9 ns | 1.34 ns | 1.19 ns |  1.04 |    0.01 | 0.1068 |     - |     - |     224 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |   100 |   515.9 ns | 2.35 ns | 2.08 ns |  1.72 |    0.01 | 0.1068 |     - |     - |     224 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |   100 |   544.3 ns | 3.76 ns | 3.34 ns |  1.81 |    0.01 | 0.1068 |     - |     - |     224 B |
|                                       ForLoop |   100 |   300.0 ns | 1.70 ns | 1.42 ns |  1.00 |    0.00 | 0.4168 |     - |     - |     872 B |
|                                   ForeachLoop |   100 |   397.6 ns | 1.41 ns | 1.18 ns |  1.33 |    0.01 | 0.4168 |     - |     - |     872 B |
|                                          Linq |   100 |   551.5 ns | 2.51 ns | 2.22 ns |  1.84 |    0.01 | 0.3939 |     - |     - |     824 B |
|                                    LinqFaster |   100 |   525.9 ns | 2.37 ns | 2.10 ns |  1.75 |    0.01 | 0.4168 |     - |     - |     872 B |
|                                        LinqAF |   100 | 1,070.2 ns | 3.07 ns | 2.73 ns |  3.57 |    0.02 | 0.4005 |     - |     - |     840 B |
|                                    StructLinq |   100 |   556.2 ns | 2.20 ns | 1.84 ns |  1.85 |    0.01 | 0.1526 |     - |     - |     320 B |
|                          StructLinq_IFunction |   100 |   271.4 ns | 2.36 ns | 2.21 ns |  0.90 |    0.01 | 0.1068 |     - |     - |     224 B |
|                                     Hyperlinq |   100 |   661.5 ns | 2.63 ns | 2.46 ns |  2.20 |    0.01 | 0.1068 |     - |     - |     224 B |
|                           Hyperlinq_IFunction |   100 |   344.9 ns | 1.48 ns | 1.32 ns |  1.15 |    0.01 | 0.1068 |     - |     - |     224 B |
|                                Hyperlinq_Pool |   100 |   683.6 ns | 1.95 ns | 1.82 ns |  2.28 |    0.01 | 0.0267 |     - |     - |      56 B |
|                      Hyperlinq_Pool_IFunction |   100 |   395.4 ns | 2.01 ns | 1.88 ns |  1.32 |    0.01 | 0.0267 |     - |     - |      56 B |
