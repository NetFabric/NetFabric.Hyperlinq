## List.Int32.ListInt32WhereSelectToList

### Source
[ListInt32WhereSelectToList.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelectToList.cs)

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
|                            ValueLinq_Standard |   100 |   554.3 ns | 2.46 ns | 2.05 ns |  2.29 |    0.02 | 0.3090 |     - |     - |     648 B |
|                               ValueLinq_Stack |   100 |   778.9 ns | 1.43 ns | 1.19 ns |  3.22 |    0.01 | 0.1221 |     - |     - |     256 B |
|                     ValueLinq_SharedPool_Push |   100 |   894.6 ns | 2.48 ns | 2.20 ns |  3.70 |    0.02 | 0.1221 |     - |     - |     256 B |
|                     ValueLinq_SharedPool_Pull |   100 |   966.8 ns | 3.17 ns | 2.96 ns |  4.00 |    0.02 | 0.1221 |     - |     - |     256 B |
|                ValueLinq_ValueLambda_Standard |   100 |   346.5 ns | 1.15 ns | 1.02 ns |  1.43 |    0.01 | 0.3095 |     - |     - |     648 B |
|                   ValueLinq_ValueLambda_Stack |   100 |   539.0 ns | 2.24 ns | 2.10 ns |  2.23 |    0.01 | 0.1221 |     - |     - |     256 B |
|         ValueLinq_ValueLambda_SharedPool_Push |   100 |   668.1 ns | 1.78 ns | 1.49 ns |  2.76 |    0.01 | 0.1221 |     - |     - |     256 B |
|         ValueLinq_ValueLambda_SharedPool_Pull |   100 |   835.7 ns | 1.58 ns | 1.23 ns |  3.45 |    0.01 | 0.1221 |     - |     - |     256 B |
|                    ValueLinq_Standard_ByIndex |   100 |   615.6 ns | 1.78 ns | 1.67 ns |  2.55 |    0.01 | 0.3090 |     - |     - |     648 B |
|                       ValueLinq_Stack_ByIndex |   100 |   622.2 ns | 1.32 ns | 1.23 ns |  2.57 |    0.01 | 0.1221 |     - |     - |     256 B |
|             ValueLinq_SharedPool_Push_ByIndex |   100 |   889.5 ns | 2.08 ns | 1.85 ns |  3.68 |    0.01 | 0.1221 |     - |     - |     256 B |
|             ValueLinq_SharedPool_Pull_ByIndex |   100 |   867.1 ns | 1.87 ns | 1.65 ns |  3.59 |    0.02 | 0.1221 |     - |     - |     256 B |
|        ValueLinq_ValueLambda_Standard_ByIndex |   100 |   360.5 ns | 1.58 ns | 1.32 ns |  1.49 |    0.01 | 0.3095 |     - |     - |     648 B |
|           ValueLinq_ValueLambda_Stack_ByIndex |   100 |   388.1 ns | 0.93 ns | 0.78 ns |  1.60 |    0.01 | 0.1221 |     - |     - |     256 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |   100 |   673.7 ns | 0.97 ns | 0.91 ns |  2.79 |    0.01 | 0.1221 |     - |     - |     256 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |   100 |   656.8 ns | 1.04 ns | 0.87 ns |  2.72 |    0.01 | 0.1221 |     - |     - |     256 B |
|                                       ForLoop |   100 |   241.8 ns | 1.18 ns | 1.04 ns |  1.00 |    0.00 | 0.3095 |     - |     - |     648 B |
|                                   ForeachLoop |   100 |   371.5 ns | 0.97 ns | 0.86 ns |  1.54 |    0.01 | 0.3095 |     - |     - |     648 B |
|                                          Linq |   100 |   574.5 ns | 1.34 ns | 1.19 ns |  2.38 |    0.01 | 0.3824 |     - |     - |     800 B |
|                                    LinqFaster |   100 |   474.1 ns | 2.06 ns | 1.82 ns |  1.96 |    0.01 | 0.4320 |     - |     - |     904 B |
|                                        LinqAF |   100 | 1,054.1 ns | 4.92 ns | 4.60 ns |  4.36 |    0.02 | 0.3090 |     - |     - |     648 B |
|                                    StructLinq |   100 |   599.3 ns | 1.77 ns | 1.65 ns |  2.48 |    0.01 | 0.1678 |     - |     - |     352 B |
|                          StructLinq_IFunction |   100 |   289.2 ns | 0.70 ns | 0.65 ns |  1.20 |    0.01 | 0.1221 |     - |     - |     256 B |
|                                     Hyperlinq |   100 |   608.3 ns | 1.85 ns | 1.64 ns |  2.52 |    0.01 | 0.1221 |     - |     - |     256 B |
|                           Hyperlinq_IFunction |   100 |   359.7 ns | 1.78 ns | 1.39 ns |  1.49 |    0.01 | 0.1221 |     - |     - |     256 B |
