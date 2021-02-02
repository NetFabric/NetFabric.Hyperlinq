## List.Int32.ListInt32WhereSelectToArray

### Source
[ListInt32WhereSelectToArray.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelectToArray.cs)

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
|                                        Method | Count |       Mean |   Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------------------------- |------ |-----------:|--------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                            ValueLinq_Standard |   100 |   774.8 ns | 1.69 ns |  1.32 ns |  2.87 |    0.01 | 0.1068 |     - |     - |     224 B |
|                               ValueLinq_Stack |   100 |   724.2 ns | 1.37 ns |  1.28 ns |  2.68 |    0.01 | 0.1068 |     - |     - |     224 B |
|                     ValueLinq_SharedPool_Push |   100 |   756.1 ns | 4.27 ns |  3.79 ns |  2.80 |    0.01 | 0.1068 |     - |     - |     224 B |
|                     ValueLinq_SharedPool_Pull |   100 |   882.4 ns | 3.07 ns |  2.72 ns |  3.27 |    0.02 | 0.1068 |     - |     - |     224 B |
|                ValueLinq_ValueLambda_Standard |   100 |   484.1 ns | 1.38 ns |  1.23 ns |  1.79 |    0.01 | 0.1068 |     - |     - |     224 B |
|                   ValueLinq_ValueLambda_Stack |   100 |   486.6 ns | 8.64 ns | 11.23 ns |  1.81 |    0.05 | 0.1068 |     - |     - |     224 B |
|         ValueLinq_ValueLambda_SharedPool_Push |   100 |   532.5 ns | 1.65 ns |  1.38 ns |  1.97 |    0.01 | 0.1068 |     - |     - |     224 B |
|         ValueLinq_ValueLambda_SharedPool_Pull |   100 |   705.1 ns | 2.09 ns |  1.96 ns |  2.61 |    0.01 | 0.1068 |     - |     - |     224 B |
|                    ValueLinq_Standard_ByIndex |   100 |   596.8 ns | 0.84 ns |  0.70 ns |  2.21 |    0.01 | 0.1068 |     - |     - |     224 B |
|                       ValueLinq_Stack_ByIndex |   100 |   560.0 ns | 1.85 ns |  1.73 ns |  2.07 |    0.01 | 0.1068 |     - |     - |     224 B |
|             ValueLinq_SharedPool_Push_ByIndex |   100 |   839.6 ns | 1.55 ns |  1.30 ns |  3.11 |    0.01 | 0.1068 |     - |     - |     224 B |
|             ValueLinq_SharedPool_Pull_ByIndex |   100 |   734.9 ns | 3.14 ns |  2.78 ns |  2.72 |    0.01 | 0.1068 |     - |     - |     224 B |
|        ValueLinq_ValueLambda_Standard_ByIndex |   100 |   343.1 ns | 1.13 ns |  1.00 ns |  1.27 |    0.01 | 0.1068 |     - |     - |     224 B |
|           ValueLinq_ValueLambda_Stack_ByIndex |   100 |   312.0 ns | 0.70 ns |  0.58 ns |  1.16 |    0.00 | 0.1068 |     - |     - |     224 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |   100 |   517.6 ns | 1.68 ns |  1.49 ns |  1.92 |    0.01 | 0.1068 |     - |     - |     224 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |   100 |   540.0 ns | 1.16 ns |  0.97 ns |  2.00 |    0.01 | 0.1068 |     - |     - |     224 B |
|                                       ForLoop |   100 |   269.9 ns | 1.06 ns |  0.88 ns |  1.00 |    0.00 | 0.4168 |     - |     - |     872 B |
|                                   ForeachLoop |   100 |   450.3 ns | 2.51 ns |  2.23 ns |  1.67 |    0.01 | 0.4168 |     - |     - |     872 B |
|                                          Linq |   100 |   555.8 ns | 1.77 ns |  1.57 ns |  2.06 |    0.01 | 0.3939 |     - |     - |     824 B |
|                                    LinqFaster |   100 |   477.1 ns | 1.66 ns |  1.56 ns |  1.77 |    0.01 | 0.4168 |     - |     - |     872 B |
|                                        LinqAF |   100 | 1,057.5 ns | 2.57 ns |  2.41 ns |  3.92 |    0.01 | 0.4005 |     - |     - |     840 B |
|                                    StructLinq |   100 |   506.0 ns | 2.33 ns |  2.18 ns |  1.87 |    0.01 | 0.1526 |     - |     - |     320 B |
|                          StructLinq_IFunction |   100 |   277.9 ns | 0.60 ns |  0.56 ns |  1.03 |    0.00 | 0.1068 |     - |     - |     224 B |
|                                     Hyperlinq |   100 |   587.7 ns | 1.50 ns |  1.25 ns |  2.18 |    0.01 | 0.1068 |     - |     - |     224 B |
|                           Hyperlinq_IFunction |   100 |   357.8 ns | 1.35 ns |  1.27 ns |  1.33 |    0.01 | 0.1068 |     - |     - |     224 B |
|                                Hyperlinq_Pool |   100 |   657.2 ns | 1.44 ns |  1.28 ns |  2.43 |    0.01 | 0.0267 |     - |     - |      56 B |
|                      Hyperlinq_Pool_IFunction |   100 |   374.6 ns | 0.88 ns |  0.78 ns |  1.39 |    0.01 | 0.0267 |     - |     - |      56 B |
