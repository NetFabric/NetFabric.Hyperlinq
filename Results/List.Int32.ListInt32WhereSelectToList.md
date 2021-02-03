## List.Int32.ListInt32WhereSelectToList

### Source
[ListInt32WhereSelectToList.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelectToList.cs)

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
|                            ValueLinq_Standard |   100 |   601.5 ns | 2.01 ns | 1.68 ns |  2.53 |    0.02 | 0.3090 |     - |     - |     648 B |
|                               ValueLinq_Stack |   100 |   790.1 ns | 2.65 ns | 2.35 ns |  3.32 |    0.02 | 0.1221 |     - |     - |     256 B |
|                     ValueLinq_SharedPool_Push |   100 |   902.5 ns | 4.45 ns | 3.71 ns |  3.80 |    0.04 | 0.1221 |     - |     - |     256 B |
|                     ValueLinq_SharedPool_Pull |   100 |   972.4 ns | 2.64 ns | 2.21 ns |  4.09 |    0.03 | 0.1221 |     - |     - |     256 B |
|                ValueLinq_ValueLambda_Standard |   100 |   349.9 ns | 1.62 ns | 1.44 ns |  1.47 |    0.01 | 0.3095 |     - |     - |     648 B |
|                   ValueLinq_ValueLambda_Stack |   100 |   548.6 ns | 2.98 ns | 2.64 ns |  2.31 |    0.02 | 0.1221 |     - |     - |     256 B |
|         ValueLinq_ValueLambda_SharedPool_Push |   100 |   634.9 ns | 1.82 ns | 1.61 ns |  2.67 |    0.02 | 0.1221 |     - |     - |     256 B |
|         ValueLinq_ValueLambda_SharedPool_Pull |   100 |   829.2 ns | 1.61 ns | 1.34 ns |  3.49 |    0.02 | 0.1221 |     - |     - |     256 B |
|                    ValueLinq_Standard_ByIndex |   100 |   574.3 ns | 2.08 ns | 1.85 ns |  2.42 |    0.01 | 0.3090 |     - |     - |     648 B |
|                       ValueLinq_Stack_ByIndex |   100 |   628.0 ns | 1.93 ns | 1.50 ns |  2.64 |    0.02 | 0.1221 |     - |     - |     256 B |
|             ValueLinq_SharedPool_Push_ByIndex |   100 |   927.1 ns | 2.61 ns | 2.31 ns |  3.90 |    0.03 | 0.1221 |     - |     - |     256 B |
|             ValueLinq_SharedPool_Pull_ByIndex |   100 |   861.3 ns | 3.57 ns | 3.16 ns |  3.62 |    0.03 | 0.1221 |     - |     - |     256 B |
|        ValueLinq_ValueLambda_Standard_ByIndex |   100 |   364.3 ns | 1.53 ns | 1.35 ns |  1.53 |    0.01 | 0.3095 |     - |     - |     648 B |
|           ValueLinq_ValueLambda_Stack_ByIndex |   100 |   387.5 ns | 0.83 ns | 0.73 ns |  1.63 |    0.01 | 0.1221 |     - |     - |     256 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |   100 |   635.9 ns | 1.66 ns | 1.55 ns |  2.68 |    0.02 | 0.1221 |     - |     - |     256 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |   100 |   669.0 ns | 1.25 ns | 1.17 ns |  2.82 |    0.02 | 0.1221 |     - |     - |     256 B |
|                                       ForLoop |   100 |   237.7 ns | 1.86 ns | 1.65 ns |  1.00 |    0.00 | 0.3095 |     - |     - |     648 B |
|                                   ForeachLoop |   100 |   372.7 ns | 1.36 ns | 1.20 ns |  1.57 |    0.01 | 0.3095 |     - |     - |     648 B |
|                                          Linq |   100 |   543.5 ns | 1.23 ns | 1.09 ns |  2.29 |    0.02 | 0.3824 |     - |     - |     800 B |
|                                    LinqFaster |   100 |   518.7 ns | 1.35 ns | 1.20 ns |  2.18 |    0.01 | 0.4320 |     - |     - |     904 B |
|                                        LinqAF |   100 | 1,044.8 ns | 2.34 ns | 2.19 ns |  4.40 |    0.03 | 0.3090 |     - |     - |     648 B |
|                                    StructLinq |   100 |   555.9 ns | 1.66 ns | 1.39 ns |  2.34 |    0.01 | 0.1678 |     - |     - |     352 B |
|                          StructLinq_IFunction |   100 |   289.8 ns | 1.01 ns | 0.90 ns |  1.22 |    0.01 | 0.1221 |     - |     - |     256 B |
|                                     Hyperlinq |   100 |   600.8 ns | 1.70 ns | 1.50 ns |  2.53 |    0.02 | 0.1221 |     - |     - |     256 B |
|                           Hyperlinq_IFunction |   100 |   360.5 ns | 1.85 ns | 1.54 ns |  1.52 |    0.01 | 0.1221 |     - |     - |     256 B |
