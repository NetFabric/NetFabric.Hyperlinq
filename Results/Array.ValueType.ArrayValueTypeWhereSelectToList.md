## Array.ValueType.ArrayValueTypeWhereSelectToList

### Source
[ArrayValueTypeWhereSelectToList.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelectToList.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta37](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta37)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.21079.7
  [Host]        : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                                Method | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                    ValueLinq_Standard |   100 | 1,450.9 ns | 13.36 ns | 12.50 ns |  1.72 |    0.02 | 2.4433 |     - |     - |   4.99 KB |
|                       ValueLinq_Stack |   100 | 1,190.6 ns |  4.53 ns |  4.02 ns |  1.41 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
|             ValueLinq_SharedPool_Push |   100 | 1,928.2 ns |  4.25 ns |  3.55 ns |  2.29 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
|             ValueLinq_SharedPool_Pull |   100 | 1,452.0 ns |  3.82 ns |  3.57 ns |  1.72 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
|                ValueLinq_Ref_Standard |   100 | 1,329.5 ns | 12.58 ns | 10.51 ns |  1.58 |    0.02 | 2.4433 |     - |     - |   4.99 KB |
|                   ValueLinq_Ref_Stack |   100 | 1,204.1 ns |  5.10 ns |  4.77 ns |  1.43 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
|         ValueLinq_Ref_SharedPool_Push |   100 | 1,639.2 ns |  5.48 ns |  4.86 ns |  1.95 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
|         ValueLinq_Ref_SharedPool_Pull |   100 | 1,464.8 ns |  6.34 ns |  5.62 ns |  1.74 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
|        ValueLinq_ValueLambda_Standard |   100 | 1,163.9 ns |  6.70 ns |  5.94 ns |  1.38 |    0.01 | 2.4433 |     - |     - |   4.99 KB |
|           ValueLinq_ValueLambda_Stack |   100 | 1,162.3 ns |  6.40 ns |  5.34 ns |  1.38 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
| ValueLinq_ValueLambda_SharedPool_Push |   100 | 1,374.7 ns | 10.06 ns |  8.92 ns |  1.63 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
| ValueLinq_ValueLambda_SharedPool_Pull |   100 | 1,369.3 ns |  7.55 ns |  6.31 ns |  1.63 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
|                               ForLoop |   100 |   842.3 ns |  5.95 ns |  4.64 ns |  1.00 |    0.00 | 2.4433 |     - |     - |   4.99 KB |
|                           ForeachLoop |   100 |   897.7 ns |  5.48 ns |  5.13 ns |  1.07 |    0.01 | 2.4433 |     - |     - |   4.99 KB |
|                                  Linq |   100 | 1,294.4 ns |  5.44 ns |  4.83 ns |  1.54 |    0.01 | 2.5234 |     - |     - |   5.16 KB |
|                            LinqFaster |   100 | 1,264.2 ns | 12.35 ns | 10.31 ns |  1.50 |    0.02 | 4.0264 |     - |     - |   8.23 KB |
|                                LinqAF |   100 | 2,094.3 ns | 40.79 ns | 38.16 ns |  2.49 |    0.05 | 2.4414 |     - |     - |   4.99 KB |
|                            StructLinq |   100 | 1,263.5 ns |  3.65 ns |  3.05 ns |  1.50 |    0.01 | 1.1044 |     - |     - |   2.26 KB |
|                  StructLinq_IFunction |   100 |   877.5 ns |  2.48 ns |  2.07 ns |  1.04 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
|                             Hyperlinq |   100 | 1,125.8 ns |  7.82 ns |  6.93 ns |  1.34 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
|                   Hyperlinq_IFunction |   100 |   891.6 ns |  2.12 ns |  1.77 ns |  1.06 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
