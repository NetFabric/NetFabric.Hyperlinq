## Array.ValueType.ArrayValueTypeWhereSelectToList

### Source
[ArrayValueTypeWhereSelectToList.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelectToList.cs)

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
|                                Method | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                    ValueLinq_Standard |   100 | 1,412.9 ns | 13.64 ns | 12.09 ns |  1.77 |    0.01 | 2.4433 |     - |     - |   4.99 KB |
|                       ValueLinq_Stack |   100 | 1,105.6 ns |  4.84 ns |  4.53 ns |  1.38 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|             ValueLinq_SharedPool_Push |   100 | 1,711.4 ns | 18.36 ns | 17.17 ns |  2.14 |    0.03 | 0.9823 |     - |     - |   2.01 KB |
|             ValueLinq_SharedPool_Pull |   100 | 1,394.6 ns |  5.90 ns |  4.92 ns |  1.75 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|                ValueLinq_Ref_Standard |   100 | 1,305.5 ns | 18.55 ns | 19.05 ns |  1.64 |    0.02 | 2.4433 |     - |     - |   4.99 KB |
|                   ValueLinq_Ref_Stack |   100 | 1,092.8 ns |  5.65 ns |  5.01 ns |  1.37 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|         ValueLinq_Ref_SharedPool_Push |   100 | 1,583.6 ns |  4.93 ns |  4.61 ns |  1.98 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|         ValueLinq_Ref_SharedPool_Pull |   100 | 1,372.1 ns |  4.81 ns |  4.26 ns |  1.72 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|        ValueLinq_ValueLambda_Standard |   100 | 1,109.6 ns |  7.29 ns |  6.09 ns |  1.39 |    0.01 | 2.4433 |     - |     - |   4.99 KB |
|           ValueLinq_ValueLambda_Stack |   100 | 1,130.9 ns |  6.48 ns |  5.75 ns |  1.42 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
| ValueLinq_ValueLambda_SharedPool_Push |   100 | 1,310.8 ns |  5.42 ns |  5.07 ns |  1.64 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
| ValueLinq_ValueLambda_SharedPool_Pull |   100 | 1,298.9 ns |  5.02 ns |  4.70 ns |  1.63 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|                               ForLoop |   100 |   798.6 ns |  4.48 ns |  3.97 ns |  1.00 |    0.00 | 2.4433 |     - |     - |   4.99 KB |
|                           ForeachLoop |   100 |   848.9 ns |  9.18 ns |  8.59 ns |  1.06 |    0.01 | 2.4433 |     - |     - |   4.99 KB |
|                                  Linq |   100 | 1,257.5 ns |  5.67 ns |  5.02 ns |  1.57 |    0.01 | 2.5234 |     - |     - |   5.16 KB |
|                            LinqFaster |   100 | 1,147.2 ns |  5.89 ns |  5.51 ns |  1.44 |    0.01 | 3.8700 |     - |     - |   7.91 KB |
|                                LinqAF |   100 | 2,055.0 ns | 22.48 ns | 21.03 ns |  2.57 |    0.03 | 2.4414 |     - |     - |   4.99 KB |
|                            StructLinq |   100 | 1,216.4 ns |  4.52 ns |  4.23 ns |  1.52 |    0.01 | 1.0281 |     - |     - |    2.1 KB |
|                  StructLinq_IFunction |   100 |   904.9 ns |  2.52 ns |  2.10 ns |  1.13 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|                             Hyperlinq |   100 | 1,088.5 ns | 15.77 ns | 13.98 ns |  1.36 |    0.02 | 0.9823 |     - |     - |   2.01 KB |
|                   Hyperlinq_IFunction |   100 |   854.2 ns |  3.01 ns |  2.67 ns |  1.07 |    0.00 | 0.9823 |     - |     - |   2.01 KB |
