## List.Int32.ListInt32WhereSelectToList

### Source
[ListInt32WhereSelectToList.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelectToList.cs)

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
|                                        Method | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------------------------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                            ValueLinq_Standard |   100 |   604.0 ns |  3.65 ns |  3.24 ns |  2.51 |    0.02 | 0.3090 |     - |     - |     648 B |
|                               ValueLinq_Stack |   100 |   794.5 ns |  2.65 ns |  2.48 ns |  3.30 |    0.02 | 0.1221 |     - |     - |     256 B |
|                     ValueLinq_SharedPool_Push |   100 |   910.5 ns |  2.89 ns |  2.71 ns |  3.78 |    0.02 | 0.1221 |     - |     - |     256 B |
|                     ValueLinq_SharedPool_Pull |   100 |   992.1 ns |  7.96 ns |  7.45 ns |  4.12 |    0.04 | 0.1221 |     - |     - |     256 B |
|                ValueLinq_ValueLambda_Standard |   100 |   354.7 ns |  1.91 ns |  1.70 ns |  1.47 |    0.01 | 0.3095 |     - |     - |     648 B |
|                   ValueLinq_ValueLambda_Stack |   100 |   556.7 ns |  4.89 ns |  4.08 ns |  2.31 |    0.02 | 0.1221 |     - |     - |     256 B |
|         ValueLinq_ValueLambda_SharedPool_Push |   100 |   637.9 ns |  1.71 ns |  1.60 ns |  2.65 |    0.01 | 0.1221 |     - |     - |     256 B |
|         ValueLinq_ValueLambda_SharedPool_Pull |   100 |   837.3 ns |  3.05 ns |  2.70 ns |  3.48 |    0.02 | 0.1221 |     - |     - |     256 B |
|                    ValueLinq_Standard_ByIndex |   100 |   593.7 ns |  3.01 ns |  2.51 ns |  2.46 |    0.01 | 0.3090 |     - |     - |     648 B |
|                       ValueLinq_Stack_ByIndex |   100 |   634.1 ns |  2.32 ns |  1.94 ns |  2.63 |    0.02 | 0.1221 |     - |     - |     256 B |
|             ValueLinq_SharedPool_Push_ByIndex |   100 |   931.7 ns |  3.59 ns |  2.81 ns |  3.87 |    0.02 | 0.1221 |     - |     - |     256 B |
|             ValueLinq_SharedPool_Pull_ByIndex |   100 |   865.9 ns |  3.26 ns |  2.89 ns |  3.59 |    0.02 | 0.1221 |     - |     - |     256 B |
|        ValueLinq_ValueLambda_Standard_ByIndex |   100 |   365.0 ns |  1.76 ns |  1.65 ns |  1.51 |    0.01 | 0.3095 |     - |     - |     648 B |
|           ValueLinq_ValueLambda_Stack_ByIndex |   100 |   392.4 ns |  1.57 ns |  1.47 ns |  1.63 |    0.01 | 0.1221 |     - |     - |     256 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |   100 |   646.1 ns |  2.54 ns |  2.25 ns |  2.68 |    0.02 | 0.1221 |     - |     - |     256 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |   100 |   681.7 ns |  2.54 ns |  2.37 ns |  2.83 |    0.02 | 0.1221 |     - |     - |     256 B |
|                                       ForLoop |   100 |   240.9 ns |  1.04 ns |  0.97 ns |  1.00 |    0.00 | 0.3095 |     - |     - |     648 B |
|                                   ForeachLoop |   100 |   378.2 ns |  1.93 ns |  1.71 ns |  1.57 |    0.01 | 0.3095 |     - |     - |     648 B |
|                                          Linq |   100 |   547.5 ns |  2.72 ns |  2.13 ns |  2.27 |    0.01 | 0.3824 |     - |     - |     800 B |
|                                    LinqFaster |   100 |   526.9 ns | 10.58 ns | 10.40 ns |  2.19 |    0.05 | 0.4320 |     - |     - |     904 B |
|                                        LinqAF |   100 | 1,064.0 ns |  8.05 ns |  7.14 ns |  4.42 |    0.04 | 0.3090 |     - |     - |     648 B |
|                                    StructLinq |   100 |   564.5 ns |  3.11 ns |  2.42 ns |  2.34 |    0.01 | 0.1678 |     - |     - |     352 B |
|                          StructLinq_IFunction |   100 |   296.9 ns |  1.60 ns |  1.50 ns |  1.23 |    0.01 | 0.1221 |     - |     - |     256 B |
|                                     Hyperlinq |   100 |   665.7 ns |  2.72 ns |  2.41 ns |  2.76 |    0.01 | 0.1221 |     - |     - |     256 B |
|                           Hyperlinq_IFunction |   100 |   351.9 ns |  2.19 ns |  1.94 ns |  1.46 |    0.01 | 0.1221 |     - |     - |     256 B |
