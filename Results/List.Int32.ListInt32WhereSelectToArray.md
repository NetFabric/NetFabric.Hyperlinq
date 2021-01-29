## List.Int32.ListInt32WhereSelectToArray

### Source
[ListInt32WhereSelectToArray.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelectToArray.cs)

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
|                                        Method | Count |       Mean |   Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------------------------- |------ |-----------:|--------:|--------:|------:|--------:|-------:|------:|------:|----------:|
|                            ValueLinq_Standard |   100 |   986.8 ns | 6.85 ns | 6.07 ns |  3.32 |    0.04 | 0.3548 |     - |     - |     744 B |
|                               ValueLinq_Stack |   100 |   963.4 ns | 3.90 ns | 3.45 ns |  3.24 |    0.02 | 0.1068 |     - |     - |     224 B |
|                     ValueLinq_SharedPool_Push |   100 | 1,012.1 ns | 6.27 ns | 5.86 ns |  3.40 |    0.04 | 0.1068 |     - |     - |     224 B |
|                     ValueLinq_SharedPool_Pull |   100 | 1,232.5 ns | 6.84 ns | 6.06 ns |  4.14 |    0.03 | 0.1068 |     - |     - |     224 B |
|                ValueLinq_ValueLambda_Standard |   100 |   870.8 ns | 2.93 ns | 2.60 ns |  2.93 |    0.03 | 0.3557 |     - |     - |     744 B |
|                   ValueLinq_ValueLambda_Stack |   100 |   704.5 ns | 3.45 ns | 3.06 ns |  2.37 |    0.02 | 0.1068 |     - |     - |     224 B |
|         ValueLinq_ValueLambda_SharedPool_Push |   100 |   818.3 ns | 3.89 ns | 3.45 ns |  2.75 |    0.03 | 0.1068 |     - |     - |     224 B |
|         ValueLinq_ValueLambda_SharedPool_Pull |   100 |   998.1 ns | 5.46 ns | 4.84 ns |  3.35 |    0.04 | 0.1068 |     - |     - |     224 B |
|                    ValueLinq_Standard_ByIndex |   100 |   809.2 ns | 1.88 ns | 1.67 ns |  2.72 |    0.02 | 0.3557 |     - |     - |     744 B |
|                       ValueLinq_Stack_ByIndex |   100 |   625.5 ns | 3.33 ns | 2.95 ns |  2.10 |    0.02 | 0.1068 |     - |     - |     224 B |
|             ValueLinq_SharedPool_Push_ByIndex |   100 |   827.3 ns | 3.33 ns | 2.78 ns |  2.78 |    0.02 | 0.1068 |     - |     - |     224 B |
|             ValueLinq_SharedPool_Pull_ByIndex |   100 |   802.3 ns | 3.22 ns | 3.01 ns |  2.70 |    0.03 | 0.1068 |     - |     - |     224 B |
|        ValueLinq_ValueLambda_Standard_ByIndex |   100 |   619.1 ns | 3.36 ns | 3.14 ns |  2.08 |    0.02 | 0.3557 |     - |     - |     744 B |
|           ValueLinq_ValueLambda_Stack_ByIndex |   100 |   378.7 ns | 1.40 ns | 1.17 ns |  1.27 |    0.01 | 0.1068 |     - |     - |     224 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |   100 |   638.4 ns | 2.28 ns | 2.02 ns |  2.15 |    0.02 | 0.1068 |     - |     - |     224 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |   100 |   582.1 ns | 4.12 ns | 3.65 ns |  1.96 |    0.02 | 0.1068 |     - |     - |     224 B |
|                                       ForLoop |   100 |   297.5 ns | 2.69 ns | 2.52 ns |  1.00 |    0.00 | 0.4168 |     - |     - |     872 B |
|                                   ForeachLoop |   100 |   513.1 ns | 2.37 ns | 2.22 ns |  1.72 |    0.02 | 0.4168 |     - |     - |     872 B |
|                                          Linq |   100 |   630.0 ns | 3.25 ns | 2.88 ns |  2.12 |    0.02 | 0.3939 |     - |     - |     824 B |
|                                    LinqFaster |   100 |   532.8 ns | 4.09 ns | 3.83 ns |  1.79 |    0.02 | 0.4168 |     - |     - |     872 B |
|                                        LinqAF |   100 | 1,199.3 ns | 8.17 ns | 7.64 ns |  4.03 |    0.04 | 0.4005 |     - |     - |     840 B |
|                                    StructLinq |   100 |   593.5 ns | 2.77 ns | 2.31 ns |  1.99 |    0.02 | 0.1526 |     - |     - |     320 B |
|                          StructLinq_IFunction |   100 |   328.2 ns | 1.53 ns | 1.44 ns |  1.10 |    0.01 | 0.1068 |     - |     - |     224 B |
|                                     Hyperlinq |   100 |   676.0 ns | 2.10 ns | 1.97 ns |  2.27 |    0.02 | 0.1068 |     - |     - |     224 B |
|                           Hyperlinq_IFunction |   100 |   384.8 ns | 3.98 ns | 3.72 ns |  1.29 |    0.02 | 0.1068 |     - |     - |     224 B |
|                                Hyperlinq_Pool |   100 |   721.7 ns | 3.22 ns | 2.86 ns |  2.43 |    0.02 | 0.0267 |     - |     - |      56 B |
|                      Hyperlinq_Pool_IFunction |   100 |   510.6 ns | 2.93 ns | 2.59 ns |  1.72 |    0.02 | 0.0267 |     - |     - |      56 B |
