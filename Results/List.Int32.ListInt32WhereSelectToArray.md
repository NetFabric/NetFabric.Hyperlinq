## List.Int32.ListInt32WhereSelectToArray

### Source
[ListInt32WhereSelectToArray.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelectToArray.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta35](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta35)

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
|                            ValueLinq_Standard |   100 |   755.5 ns | 1.76 ns | 1.64 ns |  2.43 |    0.01 | 0.1144 |     - |     - |     240 B |
|                               ValueLinq_Stack |   100 |   735.5 ns | 1.79 ns | 1.50 ns |  2.36 |    0.01 | 0.1144 |     - |     - |     240 B |
|                     ValueLinq_SharedPool_Push |   100 |   780.5 ns | 3.54 ns | 3.14 ns |  2.51 |    0.01 | 0.1144 |     - |     - |     240 B |
|                     ValueLinq_SharedPool_Pull |   100 |   866.0 ns | 2.14 ns | 1.89 ns |  2.78 |    0.01 | 0.1144 |     - |     - |     240 B |
|                ValueLinq_ValueLambda_Standard |   100 |   499.2 ns | 1.72 ns | 1.61 ns |  1.60 |    0.01 | 0.1144 |     - |     - |     240 B |
|                   ValueLinq_ValueLambda_Stack |   100 |   456.9 ns | 0.91 ns | 0.81 ns |  1.47 |    0.01 | 0.1144 |     - |     - |     240 B |
|         ValueLinq_ValueLambda_SharedPool_Push |   100 |   537.9 ns | 4.04 ns | 3.58 ns |  1.73 |    0.01 | 0.1144 |     - |     - |     240 B |
|         ValueLinq_ValueLambda_SharedPool_Pull |   100 |   800.9 ns | 4.45 ns | 3.95 ns |  2.57 |    0.02 | 0.1144 |     - |     - |     240 B |
|                    ValueLinq_Standard_ByIndex |   100 |   575.5 ns | 1.69 ns | 1.50 ns |  1.85 |    0.01 | 0.1144 |     - |     - |     240 B |
|                       ValueLinq_Stack_ByIndex |   100 |   547.5 ns | 1.63 ns | 1.53 ns |  1.76 |    0.01 | 0.1144 |     - |     - |     240 B |
|             ValueLinq_SharedPool_Push_ByIndex |   100 |   798.0 ns | 2.43 ns | 2.15 ns |  2.56 |    0.01 | 0.1144 |     - |     - |     240 B |
|             ValueLinq_SharedPool_Pull_ByIndex |   100 |   718.0 ns | 2.64 ns | 2.34 ns |  2.31 |    0.01 | 0.1144 |     - |     - |     240 B |
|        ValueLinq_ValueLambda_Standard_ByIndex |   100 |   350.4 ns | 0.97 ns | 0.81 ns |  1.13 |    0.01 | 0.1144 |     - |     - |     240 B |
|           ValueLinq_ValueLambda_Stack_ByIndex |   100 |   302.9 ns | 0.84 ns | 0.70 ns |  0.97 |    0.00 | 0.1144 |     - |     - |     240 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |   100 |   525.2 ns | 2.05 ns | 1.81 ns |  1.69 |    0.01 | 0.1144 |     - |     - |     240 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |   100 |   533.2 ns | 3.49 ns | 2.72 ns |  1.71 |    0.01 | 0.1144 |     - |     - |     240 B |
|                                       ForLoop |   100 |   311.3 ns | 1.08 ns | 0.96 ns |  1.00 |    0.00 | 0.4244 |     - |     - |     888 B |
|                                   ForeachLoop |   100 |   403.7 ns | 0.86 ns | 0.76 ns |  1.30 |    0.00 | 0.4244 |     - |     - |     888 B |
|                                          Linq |   100 |   515.0 ns | 1.43 ns | 1.34 ns |  1.65 |    0.01 | 0.4015 |     - |     - |     840 B |
|                                    LinqFaster |   100 |   473.8 ns | 1.19 ns | 0.99 ns |  1.52 |    0.01 | 0.4244 |     - |     - |     888 B |
|                                        LinqAF |   100 | 1,192.7 ns | 4.61 ns | 4.09 ns |  3.83 |    0.02 | 0.4082 |     - |     - |     856 B |
|                                    StructLinq |   100 |   516.1 ns | 4.01 ns | 3.76 ns |  1.66 |    0.01 | 0.1602 |     - |     - |     336 B |
|                          StructLinq_IFunction |   100 |   292.0 ns | 1.02 ns | 0.96 ns |  0.94 |    0.00 | 0.1144 |     - |     - |     240 B |
|                                     Hyperlinq |   100 |   567.6 ns | 1.78 ns | 1.58 ns |  1.82 |    0.01 | 0.1144 |     - |     - |     240 B |
|                           Hyperlinq_IFunction |   100 |   339.5 ns | 1.41 ns | 1.32 ns |  1.09 |    0.01 | 0.1144 |     - |     - |     240 B |
|                                Hyperlinq_Pool |   100 |   613.3 ns | 1.78 ns | 1.66 ns |  1.97 |    0.01 | 0.0267 |     - |     - |      56 B |
|                      Hyperlinq_Pool_IFunction |   100 |   400.9 ns | 1.26 ns | 1.05 ns |  1.29 |    0.01 | 0.0267 |     - |     - |      56 B |
