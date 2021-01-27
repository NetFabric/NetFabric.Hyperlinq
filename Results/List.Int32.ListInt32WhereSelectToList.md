## List.Int32.ListInt32WhereSelectToList

### Source
[ListInt32WhereSelectToList.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelectToList.cs)

### References:
- Cistern.ValueLinq: [0.0.11](https://www.nuget.org/packages/Cistern.ValueLinq/0.0.11)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.19.2](https://www.nuget.org/packages/StructLinq.BCL/0.19.2)
- NetFabric.Hyperlinq: [3.0.0-beta27](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta27)

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
|                            ValueLinq_Standard |   100 |   763.4 ns | 2.31 ns | 2.16 ns |  2.78 |    0.01 | 0.3090 |     - |     - |     648 B |
|                               ValueLinq_Stack |   100 |   943.4 ns | 2.93 ns | 2.74 ns |  3.43 |    0.02 | 0.1221 |     - |     - |     256 B |
|                     ValueLinq_SharedPool_Push |   100 | 1,047.4 ns | 3.24 ns | 3.03 ns |  3.81 |    0.02 | 0.1221 |     - |     - |     256 B |
|                     ValueLinq_SharedPool_Pull |   100 | 1,165.0 ns | 3.11 ns | 2.76 ns |  4.24 |    0.02 | 0.1221 |     - |     - |     256 B |
|                ValueLinq_ValueLambda_Standard |   100 |   556.3 ns | 1.74 ns | 1.54 ns |  2.02 |    0.01 | 0.3090 |     - |     - |     648 B |
|                   ValueLinq_ValueLambda_Stack |   100 |   769.1 ns | 1.51 ns | 1.34 ns |  2.80 |    0.01 | 0.1221 |     - |     - |     256 B |
|         ValueLinq_ValueLambda_SharedPool_Push |   100 |   843.6 ns | 2.36 ns | 1.97 ns |  3.07 |    0.01 | 0.1221 |     - |     - |     256 B |
|         ValueLinq_ValueLambda_SharedPool_Pull |   100 | 1,021.7 ns | 5.05 ns | 4.21 ns |  3.72 |    0.02 | 0.1221 |     - |     - |     256 B |
|                    ValueLinq_Standard_ByIndex |   100 |   567.0 ns | 2.73 ns | 2.28 ns |  2.06 |    0.01 | 0.3090 |     - |     - |     648 B |
|                       ValueLinq_Stack_ByIndex |   100 |   619.4 ns | 1.91 ns | 1.69 ns |  2.25 |    0.01 | 0.1221 |     - |     - |     256 B |
|             ValueLinq_SharedPool_Push_ByIndex |   100 |   842.1 ns | 1.52 ns | 1.42 ns |  3.06 |    0.01 | 0.1221 |     - |     - |     256 B |
|             ValueLinq_SharedPool_Pull_ByIndex |   100 |   846.2 ns | 1.66 ns | 1.39 ns |  3.08 |    0.01 | 0.1221 |     - |     - |     256 B |
|        ValueLinq_ValueLambda_Standard_ByIndex |   100 |   405.2 ns | 1.73 ns | 1.62 ns |  1.48 |    0.01 | 0.3095 |     - |     - |     648 B |
|           ValueLinq_ValueLambda_Stack_ByIndex |   100 |   384.1 ns | 1.66 ns | 1.47 ns |  1.40 |    0.01 | 0.1221 |     - |     - |     256 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |   100 |   675.0 ns | 2.14 ns | 1.90 ns |  2.46 |    0.01 | 0.1221 |     - |     - |     256 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |   100 |   655.8 ns | 2.22 ns | 1.73 ns |  2.39 |    0.01 | 0.1221 |     - |     - |     256 B |
|                                       ForLoop |   100 |   274.7 ns | 1.02 ns | 0.90 ns |  1.00 |    0.00 | 0.3095 |     - |     - |     648 B |
|                                   ForeachLoop |   100 |   404.6 ns | 0.92 ns | 0.86 ns |  1.47 |    0.01 | 0.3095 |     - |     - |     648 B |
|                                          Linq |   100 |   575.1 ns | 1.62 ns | 1.36 ns |  2.09 |    0.01 | 0.3824 |     - |     - |     800 B |
|                                    LinqFaster |   100 |   573.0 ns | 1.88 ns | 1.57 ns |  2.09 |    0.01 | 0.4320 |     - |     - |     904 B |
|                                        LinqAF |   100 | 1,048.5 ns | 4.06 ns | 3.60 ns |  3.82 |    0.02 | 0.3090 |     - |     - |     648 B |
|                                    StructLinq |   100 |   553.5 ns | 1.87 ns | 1.75 ns |  2.01 |    0.01 | 0.1717 |     - |     - |     360 B |
|                          StructLinq_IFunction |   100 |   357.4 ns | 1.05 ns | 0.98 ns |  1.30 |    0.00 | 0.1221 |     - |     - |     256 B |
|                                     Hyperlinq |   100 |   610.9 ns | 1.68 ns | 1.31 ns |  2.22 |    0.01 | 0.1564 |     - |     - |     328 B |
|                           Hyperlinq_IFunction |   100 |   386.2 ns | 1.53 ns | 1.28 ns |  1.41 |    0.01 | 0.1564 |     - |     - |     328 B |
