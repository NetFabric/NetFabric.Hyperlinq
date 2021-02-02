## Array.ValueType.ArrayValueTypeWhereSelectToList

### Source
[ArrayValueTypeWhereSelectToList.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelectToList.cs)

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
|                                Method | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                    ValueLinq_Standard |   100 | 2,461.7 ns |  7.85 ns |  6.96 ns |  3.04 |    0.05 | 2.4433 |     - |     - |   4.99 KB |
|                       ValueLinq_Stack |   100 | 1,235.6 ns |  7.10 ns |  6.29 ns |  1.52 |    0.03 | 0.9823 |     - |     - |   2.01 KB |
|             ValueLinq_SharedPool_Push |   100 | 1,690.9 ns | 15.89 ns | 14.86 ns |  2.09 |    0.03 | 0.9823 |     - |     - |   2.01 KB |
|             ValueLinq_SharedPool_Pull |   100 | 1,382.0 ns |  3.31 ns |  2.77 ns |  1.70 |    0.03 | 0.9823 |     - |     - |   2.01 KB |
|                ValueLinq_Ref_Standard |   100 | 1,287.5 ns |  7.14 ns |  5.96 ns |  1.59 |    0.03 | 2.4433 |     - |     - |   4.99 KB |
|                   ValueLinq_Ref_Stack |   100 | 1,104.9 ns |  9.23 ns |  8.19 ns |  1.36 |    0.03 | 0.9823 |     - |     - |   2.01 KB |
|         ValueLinq_Ref_SharedPool_Push |   100 | 1,533.9 ns |  2.40 ns |  2.13 ns |  1.89 |    0.03 | 0.9823 |     - |     - |   2.01 KB |
|         ValueLinq_Ref_SharedPool_Pull |   100 | 1,369.0 ns |  3.72 ns |  3.48 ns |  1.69 |    0.03 | 0.9823 |     - |     - |   2.01 KB |
|        ValueLinq_ValueLambda_Standard |   100 | 1,087.6 ns |  7.84 ns |  6.55 ns |  1.34 |    0.03 | 2.4433 |     - |     - |   4.99 KB |
|           ValueLinq_ValueLambda_Stack |   100 | 1,078.0 ns |  3.69 ns |  3.27 ns |  1.33 |    0.02 | 0.9823 |     - |     - |   2.01 KB |
| ValueLinq_ValueLambda_SharedPool_Push |   100 | 1,340.5 ns |  4.06 ns |  3.39 ns |  1.65 |    0.03 | 0.9823 |     - |     - |   2.01 KB |
| ValueLinq_ValueLambda_SharedPool_Pull |   100 | 1,323.6 ns |  3.90 ns |  3.46 ns |  1.63 |    0.03 | 0.9823 |     - |     - |   2.01 KB |
|                               ForLoop |   100 |   810.0 ns | 15.14 ns | 14.17 ns |  1.00 |    0.00 | 2.4433 |     - |     - |   4.99 KB |
|                           ForeachLoop |   100 |   871.3 ns |  8.11 ns |  7.59 ns |  1.08 |    0.02 | 2.4433 |     - |     - |   4.99 KB |
|                                  Linq |   100 | 1,248.2 ns |  6.76 ns |  5.64 ns |  1.54 |    0.03 | 2.5234 |     - |     - |   5.16 KB |
|                            LinqFaster |   100 | 1,168.5 ns |  4.04 ns |  3.58 ns |  1.44 |    0.02 | 3.8700 |     - |     - |   7.91 KB |
|                                LinqAF |   100 | 2,042.8 ns | 25.03 ns | 20.90 ns |  2.52 |    0.06 | 2.4414 |     - |     - |   4.99 KB |
|                            StructLinq |   100 | 1,166.0 ns |  3.90 ns |  3.26 ns |  1.44 |    0.03 | 1.0281 |     - |     - |    2.1 KB |
|                  StructLinq_IFunction |   100 |   865.4 ns |  3.37 ns |  3.15 ns |  1.07 |    0.02 | 0.9823 |     - |     - |   2.01 KB |
|                             Hyperlinq |   100 | 1,080.8 ns |  4.21 ns |  3.93 ns |  1.33 |    0.02 | 0.9823 |     - |     - |   2.01 KB |
|                   Hyperlinq_IFunction |   100 |   860.0 ns |  2.64 ns |  2.34 ns |  1.06 |    0.02 | 0.9823 |     - |     - |   2.01 KB |
