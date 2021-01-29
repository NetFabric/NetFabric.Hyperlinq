## List.Int32.ListInt32WhereSelectToList

### Source
[ListInt32WhereSelectToList.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelectToList.cs)

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
|                                        Method | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------------------------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                            ValueLinq_Standard |   100 |   867.2 ns |  4.18 ns |  3.49 ns |  2.76 |    0.02 | 0.3090 |     - |     - |     648 B |
|                               ValueLinq_Stack |   100 | 1,071.8 ns |  6.18 ns |  5.48 ns |  3.41 |    0.03 | 0.1221 |     - |     - |     256 B |
|                     ValueLinq_SharedPool_Push |   100 | 1,161.3 ns |  4.58 ns |  4.28 ns |  3.69 |    0.02 | 0.1221 |     - |     - |     256 B |
|                     ValueLinq_SharedPool_Pull |   100 | 1,311.9 ns |  7.05 ns |  5.50 ns |  4.18 |    0.04 | 0.1221 |     - |     - |     256 B |
|                ValueLinq_ValueLambda_Standard |   100 |   638.3 ns |  3.03 ns |  2.53 ns |  2.03 |    0.01 | 0.3090 |     - |     - |     648 B |
|                   ValueLinq_ValueLambda_Stack |   100 |   837.7 ns |  3.53 ns |  3.13 ns |  2.67 |    0.02 | 0.1221 |     - |     - |     256 B |
|         ValueLinq_ValueLambda_SharedPool_Push |   100 |   886.9 ns |  4.79 ns |  4.25 ns |  2.82 |    0.03 | 0.1221 |     - |     - |     256 B |
|         ValueLinq_ValueLambda_SharedPool_Pull |   100 | 1,103.4 ns |  7.34 ns |  6.86 ns |  3.51 |    0.03 | 0.1221 |     - |     - |     256 B |
|                    ValueLinq_Standard_ByIndex |   100 |   669.6 ns |  2.87 ns |  2.68 ns |  2.13 |    0.01 | 0.3090 |     - |     - |     648 B |
|                       ValueLinq_Stack_ByIndex |   100 |   674.9 ns |  3.08 ns |  2.88 ns |  2.15 |    0.02 | 0.1221 |     - |     - |     256 B |
|             ValueLinq_SharedPool_Push_ByIndex |   100 |   944.9 ns |  5.11 ns |  4.26 ns |  3.00 |    0.03 | 0.1221 |     - |     - |     256 B |
|             ValueLinq_SharedPool_Pull_ByIndex |   100 |   953.4 ns | 15.14 ns | 11.82 ns |  3.03 |    0.04 | 0.1221 |     - |     - |     256 B |
|        ValueLinq_ValueLambda_Standard_ByIndex |   100 |   455.3 ns |  1.76 ns |  1.47 ns |  1.45 |    0.01 | 0.3095 |     - |     - |     648 B |
|           ValueLinq_ValueLambda_Stack_ByIndex |   100 |   435.4 ns |  2.60 ns |  2.30 ns |  1.39 |    0.01 | 0.1221 |     - |     - |     256 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |   100 |   734.9 ns |  4.72 ns |  4.18 ns |  2.34 |    0.02 | 0.1221 |     - |     - |     256 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |   100 |   743.7 ns |  3.25 ns |  2.72 ns |  2.36 |    0.02 | 0.1221 |     - |     - |     256 B |
|                                       ForLoop |   100 |   314.5 ns |  2.20 ns |  2.06 ns |  1.00 |    0.00 | 0.3095 |     - |     - |     648 B |
|                                   ForeachLoop |   100 |   483.0 ns |  2.30 ns |  2.15 ns |  1.54 |    0.01 | 0.3090 |     - |     - |     648 B |
|                                          Linq |   100 |   644.1 ns |  3.72 ns |  3.48 ns |  2.05 |    0.01 | 0.3824 |     - |     - |     800 B |
|                                    LinqFaster |   100 |   581.0 ns |  3.05 ns |  2.86 ns |  1.85 |    0.01 | 0.4320 |     - |     - |     904 B |
|                                        LinqAF |   100 | 1,163.3 ns |  7.30 ns |  6.47 ns |  3.70 |    0.03 | 0.3090 |     - |     - |     648 B |
|                                    StructLinq |   100 |   599.4 ns |  2.04 ns |  1.91 ns |  1.91 |    0.01 | 0.1678 |     - |     - |     352 B |
|                          StructLinq_IFunction |   100 |   317.2 ns |  0.95 ns |  0.84 ns |  1.01 |    0.01 | 0.1221 |     - |     - |     256 B |
|                                     Hyperlinq |   100 |   688.3 ns |  4.01 ns |  3.55 ns |  2.19 |    0.02 | 0.1564 |     - |     - |     328 B |
|                           Hyperlinq_IFunction |   100 |   435.5 ns |  2.56 ns |  2.27 ns |  1.39 |    0.01 | 0.1564 |     - |     - |     328 B |
