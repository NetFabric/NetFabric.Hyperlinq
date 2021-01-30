## Array.ValueType.ArrayValueTypeWhereSelectToList

### Source
[ArrayValueTypeWhereSelectToList.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelectToList.cs)

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
|                                Method | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                    ValueLinq_Standard |   100 | 1,391.2 ns | 14.57 ns | 12.92 ns |  1.74 |    0.02 | 2.4433 |     - |     - |   4.99 KB |
|                       ValueLinq_Stack |   100 | 1,105.1 ns |  5.47 ns |  4.85 ns |  1.38 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|             ValueLinq_SharedPool_Push |   100 | 1,687.5 ns | 12.92 ns | 11.45 ns |  2.11 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|             ValueLinq_SharedPool_Pull |   100 | 1,368.5 ns |  5.10 ns |  4.26 ns |  1.71 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|                ValueLinq_Ref_Standard |   100 | 2,083.9 ns | 12.06 ns | 11.28 ns |  2.61 |    0.02 | 2.4433 |     - |     - |   4.99 KB |
|                   ValueLinq_Ref_Stack |   100 | 1,124.8 ns |  5.30 ns |  4.95 ns |  1.41 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|         ValueLinq_Ref_SharedPool_Push |   100 | 1,571.5 ns |  7.56 ns |  6.70 ns |  1.96 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|         ValueLinq_Ref_SharedPool_Pull |   100 | 1,376.7 ns |  6.99 ns |  6.54 ns |  1.72 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|        ValueLinq_ValueLambda_Standard |   100 | 1,092.6 ns |  7.06 ns |  6.60 ns |  1.37 |    0.01 | 2.4433 |     - |     - |   4.99 KB |
|           ValueLinq_ValueLambda_Stack |   100 | 1,074.5 ns |  5.09 ns |  4.25 ns |  1.34 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
| ValueLinq_ValueLambda_SharedPool_Push |   100 | 1,325.7 ns | 11.86 ns | 10.51 ns |  1.66 |    0.02 | 0.9823 |     - |     - |   2.01 KB |
| ValueLinq_ValueLambda_SharedPool_Pull |   100 | 1,314.3 ns |  6.83 ns |  5.70 ns |  1.64 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|                               ForLoop |   100 |   800.1 ns |  3.46 ns |  3.06 ns |  1.00 |    0.00 | 2.4433 |     - |     - |   4.99 KB |
|                           ForeachLoop |   100 |   848.5 ns |  8.57 ns |  7.60 ns |  1.06 |    0.01 | 2.4433 |     - |     - |   4.99 KB |
|                                  Linq |   100 | 1,218.1 ns |  8.96 ns |  8.38 ns |  1.52 |    0.01 | 2.5234 |     - |     - |   5.16 KB |
|                            LinqFaster |   100 | 1,158.8 ns |  4.97 ns |  4.65 ns |  1.45 |    0.01 | 3.8700 |     - |     - |   7.91 KB |
|                                LinqAF |   100 | 2,014.3 ns | 22.29 ns | 20.85 ns |  2.51 |    0.03 | 2.4414 |     - |     - |   4.99 KB |
|                            StructLinq |   100 | 1,226.2 ns |  6.09 ns |  5.69 ns |  1.53 |    0.01 | 1.0281 |     - |     - |    2.1 KB |
|                  StructLinq_IFunction |   100 |   853.4 ns |  3.76 ns |  3.33 ns |  1.07 |    0.00 | 0.9823 |     - |     - |   2.01 KB |
|                             Hyperlinq |   100 | 1,122.8 ns |  6.25 ns |  5.54 ns |  1.40 |    0.01 | 1.0166 |     - |     - |   2.08 KB |
|                   Hyperlinq_IFunction |   100 |   866.7 ns |  2.83 ns |  2.36 ns |  1.08 |    0.01 | 1.0166 |     - |     - |   2.08 KB |
