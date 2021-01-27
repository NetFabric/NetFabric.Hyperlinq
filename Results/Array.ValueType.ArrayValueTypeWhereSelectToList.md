## Array.ValueType.ArrayValueTypeWhereSelectToList

### Source
[ArrayValueTypeWhereSelectToList.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelectToList.cs)

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
|                                    Method | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------------ |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                        ValueLinq_Standard |   100 | 1,413.6 ns | 13.49 ns | 12.62 ns |  1.76 |    0.02 | 2.4433 |     - |     - |   4.99 KB |
|                           ValueLinq_Stack |   100 | 1,235.7 ns | 12.87 ns | 12.04 ns |  1.54 |    0.02 | 0.9823 |     - |     - |   2.01 KB |
|                 ValueLinq_SharedPool_Push |   100 | 1,622.9 ns | 19.23 ns | 17.99 ns |  2.02 |    0.03 | 0.9823 |     - |     - |   2.01 KB |
|                 ValueLinq_SharedPool_Pull |   100 | 1,451.8 ns |  8.75 ns |  7.76 ns |  1.81 |    0.02 | 0.9823 |     - |     - |   2.01 KB |
|                    ValueLinq_Ref_Standard |   100 | 1,271.4 ns | 11.04 ns |  9.79 ns |  1.58 |    0.02 | 2.4433 |     - |     - |   4.99 KB |
|                       ValueLinq_Ref_Stack |   100 | 1,142.0 ns |  7.15 ns |  6.34 ns |  1.42 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|             ValueLinq_Ref_SharedPool_Push |   100 | 1,555.7 ns |  4.78 ns |  4.23 ns |  1.94 |    0.02 | 0.9823 |     - |     - |   2.01 KB |
|             ValueLinq_Ref_SharedPool_Pull |   100 | 1,375.3 ns |  6.35 ns |  5.94 ns |  1.71 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|            ValueLinq_ValueLambda_Standard |   100 | 1,103.7 ns |  6.51 ns |  5.77 ns |  1.37 |    0.01 | 2.4433 |     - |     - |   4.99 KB |
|               ValueLinq_ValueLambda_Stack |   100 | 1,215.4 ns |  6.37 ns |  5.64 ns |  1.51 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|     ValueLinq_ValueLambda_SharedPool_Push |   100 | 1,312.0 ns |  4.30 ns |  3.81 ns |  1.63 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|     ValueLinq_ValueLambda_SharedPool_Pull |   100 | 1,327.7 ns |  5.87 ns |  5.20 ns |  1.65 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|        ValueLinq_ValueLambda_Ref_Standard |   100 |   997.5 ns |  4.13 ns |  3.87 ns |  1.24 |    0.01 | 2.4433 |     - |     - |   4.99 KB |
|           ValueLinq_ValueLambda_Ref_Stack |   100 | 1,048.2 ns |  6.71 ns |  5.95 ns |  1.31 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
| ValueLinq_ValueLambda_Ref_SharedPool_Push |   100 | 1,246.7 ns |  3.49 ns |  2.73 ns |  1.55 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
| ValueLinq_ValueLambda_Ref_SharedPool_Pull |   100 | 1,181.1 ns |  8.54 ns |  7.99 ns |  1.47 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|                                   ForLoop |   100 |   803.0 ns |  5.95 ns |  5.27 ns |  1.00 |    0.00 | 2.4433 |     - |     - |   4.99 KB |
|                               ForeachLoop |   100 |   866.0 ns | 11.70 ns |  9.77 ns |  1.08 |    0.01 | 2.4433 |     - |     - |   4.99 KB |
|                                      Linq |   100 | 1,261.2 ns |  9.95 ns |  8.31 ns |  1.57 |    0.02 | 2.5234 |     - |     - |   5.16 KB |
|                                LinqFaster |   100 | 1,191.8 ns |  6.94 ns |  6.49 ns |  1.49 |    0.01 | 3.8700 |     - |     - |   7.91 KB |
|                                    LinqAF |   100 | 2,015.0 ns | 22.11 ns | 18.46 ns |  2.51 |    0.03 | 2.4414 |     - |     - |   4.99 KB |
|                                StructLinq |   100 | 1,216.4 ns |  4.44 ns |  3.46 ns |  1.51 |    0.01 | 1.0281 |     - |     - |    2.1 KB |
|                      StructLinq_IFunction |   100 |   866.4 ns |  3.59 ns |  3.19 ns |  1.08 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|                                 Hyperlinq |   100 | 1,416.2 ns | 11.08 ns |  9.82 ns |  1.76 |    0.02 | 1.0166 |     - |     - |   2.08 KB |
|                       Hyperlinq_IFunction |   100 | 1,011.7 ns |  5.54 ns |  4.63 ns |  1.26 |    0.01 | 1.0166 |     - |     - |   2.08 KB |
