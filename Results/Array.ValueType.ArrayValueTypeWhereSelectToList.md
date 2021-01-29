## Array.ValueType.ArrayValueTypeWhereSelectToList

### Source
[ArrayValueTypeWhereSelectToList.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelectToList.cs)

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
|                                    Method | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------------ |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                        ValueLinq_Standard |   100 | 1,599.4 ns |  8.64 ns |  7.66 ns |  1.75 |    0.02 | 2.4433 |     - |     - |   4.99 KB |
|                           ValueLinq_Stack |   100 | 1,358.4 ns |  5.13 ns |  4.55 ns |  1.49 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|                 ValueLinq_SharedPool_Push |   100 | 1,840.9 ns | 10.17 ns |  9.51 ns |  2.02 |    0.02 | 0.9823 |     - |     - |   2.01 KB |
|                 ValueLinq_SharedPool_Pull |   100 | 1,613.5 ns | 11.31 ns | 10.58 ns |  1.77 |    0.02 | 0.9823 |     - |     - |   2.01 KB |
|                    ValueLinq_Ref_Standard |   100 | 1,459.3 ns | 10.69 ns |  9.48 ns |  1.60 |    0.01 | 2.4433 |     - |     - |   4.99 KB |
|                       ValueLinq_Ref_Stack |   100 | 1,268.4 ns |  8.90 ns |  7.89 ns |  1.39 |    0.02 | 0.9823 |     - |     - |   2.01 KB |
|             ValueLinq_Ref_SharedPool_Push |   100 | 1,746.0 ns | 13.42 ns | 12.56 ns |  1.92 |    0.02 | 0.9823 |     - |     - |   2.01 KB |
|             ValueLinq_Ref_SharedPool_Pull |   100 | 1,599.3 ns |  8.31 ns |  7.37 ns |  1.75 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|            ValueLinq_ValueLambda_Standard |   100 | 1,276.7 ns |  8.33 ns |  7.38 ns |  1.40 |    0.01 | 2.4433 |     - |     - |   4.99 KB |
|               ValueLinq_ValueLambda_Stack |   100 | 1,368.5 ns |  8.52 ns |  7.11 ns |  1.50 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|     ValueLinq_ValueLambda_SharedPool_Push |   100 | 1,523.9 ns |  9.58 ns |  8.49 ns |  1.67 |    0.02 | 0.9823 |     - |     - |   2.01 KB |
|     ValueLinq_ValueLambda_SharedPool_Pull |   100 | 1,462.1 ns |  9.88 ns |  8.25 ns |  1.60 |    0.02 | 0.9823 |     - |     - |   2.01 KB |
|        ValueLinq_ValueLambda_Ref_Standard |   100 | 1,140.2 ns |  8.95 ns |  8.37 ns |  1.25 |    0.01 | 2.4433 |     - |     - |   4.99 KB |
|           ValueLinq_ValueLambda_Ref_Stack |   100 | 1,218.5 ns |  6.71 ns |  6.27 ns |  1.34 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
| ValueLinq_ValueLambda_Ref_SharedPool_Push |   100 | 1,444.7 ns |  9.42 ns |  8.81 ns |  1.59 |    0.02 | 0.9823 |     - |     - |   2.01 KB |
| ValueLinq_ValueLambda_Ref_SharedPool_Pull |   100 | 1,344.6 ns |  7.29 ns |  6.82 ns |  1.47 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|                                   ForLoop |   100 |   911.6 ns |  7.00 ns |  6.21 ns |  1.00 |    0.00 | 2.4433 |     - |     - |   4.99 KB |
|                               ForeachLoop |   100 |   967.3 ns |  5.27 ns |  4.67 ns |  1.06 |    0.01 | 2.4433 |     - |     - |   4.99 KB |
|                                      Linq |   100 | 1,415.2 ns |  7.44 ns |  5.81 ns |  1.55 |    0.01 | 2.5234 |     - |     - |   5.16 KB |
|                                LinqFaster |   100 | 1,307.6 ns |  9.85 ns |  8.73 ns |  1.43 |    0.01 | 3.8700 |     - |     - |   7.91 KB |
|                                    LinqAF |   100 | 2,286.8 ns | 18.29 ns | 17.11 ns |  2.51 |    0.03 | 2.4414 |     - |     - |   4.99 KB |
|                                StructLinq |   100 | 1,381.2 ns |  6.81 ns |  6.37 ns |  1.52 |    0.01 | 1.0281 |     - |     - |    2.1 KB |
|                      StructLinq_IFunction |   100 |   974.4 ns |  5.66 ns |  5.02 ns |  1.07 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|                                 Hyperlinq |   100 | 1,558.2 ns |  8.22 ns |  7.29 ns |  1.71 |    0.01 | 1.0166 |     - |     - |   2.08 KB |
|                       Hyperlinq_IFunction |   100 | 1,098.4 ns |  5.09 ns |  4.25 ns |  1.21 |    0.01 | 1.0166 |     - |     - |   2.08 KB |
