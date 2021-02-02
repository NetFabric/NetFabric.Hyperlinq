## List.Int32.ListInt32WhereSelectToList

### Source
[ListInt32WhereSelectToList.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelectToList.cs)

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
|                                        Method | Count |       Mean |   Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------------------------- |------ |-----------:|--------:|--------:|------:|--------:|-------:|------:|------:|----------:|
|                            ValueLinq_Standard |   100 |   539.9 ns | 2.19 ns | 1.95 ns |  1.95 |    0.01 | 0.3090 |     - |     - |     648 B |
|                               ValueLinq_Stack |   100 |   783.8 ns | 2.07 ns | 1.84 ns |  2.83 |    0.02 | 0.1221 |     - |     - |     256 B |
|                     ValueLinq_SharedPool_Push |   100 |   897.1 ns | 2.99 ns | 2.80 ns |  3.24 |    0.02 | 0.1221 |     - |     - |     256 B |
|                     ValueLinq_SharedPool_Pull |   100 | 1,002.4 ns | 1.56 ns | 1.30 ns |  3.62 |    0.02 | 0.1221 |     - |     - |     256 B |
|                ValueLinq_ValueLambda_Standard |   100 |   357.1 ns | 0.94 ns | 0.78 ns |  1.29 |    0.01 | 0.3095 |     - |     - |     648 B |
|                   ValueLinq_ValueLambda_Stack |   100 |   549.4 ns | 1.84 ns | 1.43 ns |  1.99 |    0.01 | 0.1221 |     - |     - |     256 B |
|         ValueLinq_ValueLambda_SharedPool_Push |   100 |   618.3 ns | 1.31 ns | 1.23 ns |  2.23 |    0.02 | 0.1221 |     - |     - |     256 B |
|         ValueLinq_ValueLambda_SharedPool_Pull |   100 |   840.9 ns | 2.15 ns | 1.79 ns |  3.04 |    0.02 | 0.1221 |     - |     - |     256 B |
|                    ValueLinq_Standard_ByIndex |   100 |   595.8 ns | 1.39 ns | 1.23 ns |  2.15 |    0.01 | 0.3090 |     - |     - |     648 B |
|                       ValueLinq_Stack_ByIndex |   100 |   616.7 ns | 1.17 ns | 0.98 ns |  2.23 |    0.01 | 0.1221 |     - |     - |     256 B |
|             ValueLinq_SharedPool_Push_ByIndex |   100 |   946.0 ns | 2.84 ns | 2.52 ns |  3.42 |    0.03 | 0.1221 |     - |     - |     256 B |
|             ValueLinq_SharedPool_Pull_ByIndex |   100 |   820.0 ns | 1.71 ns | 1.51 ns |  2.96 |    0.02 | 0.1221 |     - |     - |     256 B |
|        ValueLinq_ValueLambda_Standard_ByIndex |   100 |   377.0 ns | 1.67 ns | 1.48 ns |  1.36 |    0.01 | 0.3095 |     - |     - |     648 B |
|           ValueLinq_ValueLambda_Stack_ByIndex |   100 |   388.9 ns | 1.38 ns | 1.15 ns |  1.41 |    0.01 | 0.1221 |     - |     - |     256 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |   100 |   617.8 ns | 1.41 ns | 1.18 ns |  2.23 |    0.01 | 0.1221 |     - |     - |     256 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |   100 |   644.5 ns | 1.63 ns | 1.53 ns |  2.33 |    0.02 | 0.1221 |     - |     - |     256 B |
|                                       ForLoop |   100 |   276.8 ns | 1.99 ns | 1.76 ns |  1.00 |    0.00 | 0.3095 |     - |     - |     648 B |
|                                   ForeachLoop |   100 |   430.4 ns | 0.60 ns | 0.50 ns |  1.56 |    0.01 | 0.3095 |     - |     - |     648 B |
|                                          Linq |   100 |   581.5 ns | 1.92 ns | 1.70 ns |  2.10 |    0.02 | 0.3824 |     - |     - |     800 B |
|                                    LinqFaster |   100 |   517.9 ns | 2.21 ns | 1.96 ns |  1.87 |    0.01 | 0.4320 |     - |     - |     904 B |
|                                        LinqAF |   100 | 1,047.8 ns | 2.30 ns | 2.15 ns |  3.79 |    0.02 | 0.3090 |     - |     - |     648 B |
|                                    StructLinq |   100 |   535.5 ns | 1.13 ns | 1.06 ns |  1.93 |    0.01 | 0.1678 |     - |     - |     352 B |
|                          StructLinq_IFunction |   100 |   293.3 ns | 0.98 ns | 0.87 ns |  1.06 |    0.01 | 0.1221 |     - |     - |     256 B |
|                                     Hyperlinq |   100 |   605.1 ns | 2.46 ns | 2.05 ns |  2.19 |    0.01 | 0.1221 |     - |     - |     256 B |
|                           Hyperlinq_IFunction |   100 |   380.3 ns | 1.01 ns | 0.95 ns |  1.37 |    0.01 | 0.1221 |     - |     - |     256 B |
