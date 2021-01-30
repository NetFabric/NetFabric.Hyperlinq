## List.Int32.ListInt32WhereSelectToList

### Source
[ListInt32WhereSelectToList.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelectToList.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta29](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta29)

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
|                            ValueLinq_Standard |   100 |   601.1 ns | 1.96 ns | 1.74 ns |  2.53 |    0.01 | 0.3090 |     - |     - |     648 B |
|                               ValueLinq_Stack |   100 |   778.3 ns | 1.79 ns | 1.59 ns |  3.27 |    0.01 | 0.1221 |     - |     - |     256 B |
|                     ValueLinq_SharedPool_Push |   100 |   899.3 ns | 1.28 ns | 1.14 ns |  3.78 |    0.02 | 0.1221 |     - |     - |     256 B |
|                     ValueLinq_SharedPool_Pull |   100 |   973.5 ns | 2.40 ns | 2.24 ns |  4.09 |    0.02 | 0.1221 |     - |     - |     256 B |
|                ValueLinq_ValueLambda_Standard |   100 |   352.1 ns | 1.84 ns | 1.72 ns |  1.48 |    0.01 | 0.3095 |     - |     - |     648 B |
|                   ValueLinq_ValueLambda_Stack |   100 |   548.4 ns | 2.18 ns | 1.93 ns |  2.30 |    0.01 | 0.1221 |     - |     - |     256 B |
|         ValueLinq_ValueLambda_SharedPool_Push |   100 |   636.0 ns | 1.52 ns | 1.34 ns |  2.67 |    0.01 | 0.1221 |     - |     - |     256 B |
|         ValueLinq_ValueLambda_SharedPool_Pull |   100 |   828.9 ns | 2.99 ns | 2.80 ns |  3.48 |    0.02 | 0.1221 |     - |     - |     256 B |
|                    ValueLinq_Standard_ByIndex |   100 |   579.9 ns | 1.57 ns | 1.39 ns |  2.44 |    0.01 | 0.3090 |     - |     - |     648 B |
|                       ValueLinq_Stack_ByIndex |   100 |   627.8 ns | 2.03 ns | 1.70 ns |  2.64 |    0.01 | 0.1221 |     - |     - |     256 B |
|             ValueLinq_SharedPool_Push_ByIndex |   100 |   926.8 ns | 3.16 ns | 2.80 ns |  3.89 |    0.03 | 0.1221 |     - |     - |     256 B |
|             ValueLinq_SharedPool_Pull_ByIndex |   100 |   852.5 ns | 2.31 ns | 2.04 ns |  3.58 |    0.02 | 0.1221 |     - |     - |     256 B |
|        ValueLinq_ValueLambda_Standard_ByIndex |   100 |   374.7 ns | 1.73 ns | 1.53 ns |  1.57 |    0.01 | 0.3095 |     - |     - |     648 B |
|           ValueLinq_ValueLambda_Stack_ByIndex |   100 |   388.0 ns | 0.58 ns | 0.51 ns |  1.63 |    0.01 | 0.1221 |     - |     - |     256 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |   100 |   641.2 ns | 1.89 ns | 1.68 ns |  2.69 |    0.01 | 0.1221 |     - |     - |     256 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |   100 |   669.2 ns | 2.92 ns | 2.43 ns |  2.81 |    0.01 | 0.1221 |     - |     - |     256 B |
|                                       ForLoop |   100 |   238.0 ns | 1.05 ns | 0.93 ns |  1.00 |    0.00 | 0.3095 |     - |     - |     648 B |
|                                   ForeachLoop |   100 |   374.1 ns | 0.90 ns | 0.80 ns |  1.57 |    0.01 | 0.3095 |     - |     - |     648 B |
|                                          Linq |   100 |   547.8 ns | 2.37 ns | 1.98 ns |  2.30 |    0.01 | 0.3824 |     - |     - |     800 B |
|                                    LinqFaster |   100 |   523.2 ns | 3.17 ns | 2.81 ns |  2.20 |    0.02 | 0.4320 |     - |     - |     904 B |
|                                        LinqAF |   100 | 1,080.3 ns | 2.97 ns | 2.63 ns |  4.54 |    0.02 | 0.3090 |     - |     - |     648 B |
|                                    StructLinq |   100 |   540.5 ns | 1.75 ns | 1.55 ns |  2.27 |    0.01 | 0.1678 |     - |     - |     352 B |
|                          StructLinq_IFunction |   100 |   282.1 ns | 2.00 ns | 1.77 ns |  1.19 |    0.01 | 0.1221 |     - |     - |     256 B |
|                                     Hyperlinq |   100 |   631.8 ns | 2.63 ns | 2.46 ns |  2.65 |    0.02 | 0.1564 |     - |     - |     328 B |
|                           Hyperlinq_IFunction |   100 |   410.1 ns | 1.23 ns | 1.09 ns |  1.72 |    0.01 | 0.1564 |     - |     - |     328 B |
