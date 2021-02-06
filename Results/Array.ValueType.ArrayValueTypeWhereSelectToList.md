## Array.ValueType.ArrayValueTypeWhereSelectToList

### Source
[ArrayValueTypeWhereSelectToList.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelectToList.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta32](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta32)

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
|                    ValueLinq_Standard |   100 | 1,420.5 ns | 13.23 ns | 11.73 ns |  1.77 |    0.01 | 2.4433 |     - |     - |   4.99 KB |
|                       ValueLinq_Stack |   100 | 1,109.1 ns |  4.29 ns |  3.80 ns |  1.38 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|             ValueLinq_SharedPool_Push |   100 | 1,714.2 ns | 15.36 ns | 13.62 ns |  2.14 |    0.02 | 0.9823 |     - |     - |   2.01 KB |
|             ValueLinq_SharedPool_Pull |   100 | 1,408.8 ns |  7.65 ns |  7.16 ns |  1.76 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|                ValueLinq_Ref_Standard |   100 | 1,293.7 ns |  9.42 ns |  8.35 ns |  1.61 |    0.01 | 2.4433 |     - |     - |   4.99 KB |
|                   ValueLinq_Ref_Stack |   100 | 1,102.2 ns |  6.57 ns |  5.83 ns |  1.37 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|         ValueLinq_Ref_SharedPool_Push |   100 | 1,539.0 ns |  6.59 ns |  5.84 ns |  1.92 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|         ValueLinq_Ref_SharedPool_Pull |   100 | 1,364.1 ns |  7.69 ns |  7.19 ns |  1.70 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|        ValueLinq_ValueLambda_Standard |   100 | 1,100.2 ns |  5.94 ns |  5.26 ns |  1.37 |    0.01 | 2.4433 |     - |     - |   4.99 KB |
|           ValueLinq_ValueLambda_Stack |   100 | 1,082.9 ns |  5.38 ns |  4.49 ns |  1.35 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
| ValueLinq_ValueLambda_SharedPool_Push |   100 | 1,336.1 ns |  3.37 ns |  2.81 ns |  1.67 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
| ValueLinq_ValueLambda_SharedPool_Pull |   100 | 1,305.8 ns |  4.16 ns |  3.25 ns |  1.63 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|                               ForLoop |   100 |   801.9 ns |  4.74 ns |  4.43 ns |  1.00 |    0.00 | 2.4433 |     - |     - |   4.99 KB |
|                           ForeachLoop |   100 |   877.7 ns |  5.76 ns |  5.39 ns |  1.09 |    0.01 | 2.4433 |     - |     - |   4.99 KB |
|                                  Linq |   100 | 1,260.8 ns | 13.21 ns | 11.71 ns |  1.57 |    0.02 | 2.5234 |     - |     - |   5.16 KB |
|                            LinqFaster |   100 | 1,198.1 ns |  4.37 ns |  3.87 ns |  1.49 |    0.01 | 3.8700 |     - |     - |   7.91 KB |
|                                LinqAF |   100 | 2,063.9 ns | 39.45 ns | 42.21 ns |  2.57 |    0.05 | 2.4414 |     - |     - |   4.99 KB |
|                            StructLinq |   100 | 1,228.4 ns |  5.09 ns |  4.76 ns |  1.53 |    0.01 | 1.0281 |     - |     - |    2.1 KB |
|                  StructLinq_IFunction |   100 |   863.3 ns |  5.39 ns |  5.05 ns |  1.08 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|                             Hyperlinq |   100 | 1,076.8 ns |  5.15 ns |  4.30 ns |  1.34 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|                   Hyperlinq_IFunction |   100 |   827.4 ns |  4.57 ns |  4.05 ns |  1.03 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
