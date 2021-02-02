## Array.ValueType.ArrayValueTypeWhereSelectToArray

### Source
[ArrayValueTypeWhereSelectToArray.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelectToArray.cs)

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
|                    ValueLinq_Standard |   100 | 1,037.2 ns |  6.39 ns |  5.66 ns |  1.10 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                       ValueLinq_Stack |   100 |   992.8 ns |  5.83 ns |  4.55 ns |  1.05 |    0.01 | 0.9670 |     - |     - |    2024 B |
|             ValueLinq_SharedPool_Push |   100 | 1,586.8 ns | 11.25 ns |  9.97 ns |  1.68 |    0.01 | 0.9670 |     - |     - |    2024 B |
|             ValueLinq_SharedPool_Pull |   100 | 1,257.8 ns |  4.51 ns |  4.22 ns |  1.33 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                ValueLinq_Ref_Standard |   100 | 1,024.0 ns |  4.57 ns |  4.05 ns |  1.08 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                   ValueLinq_Ref_Stack |   100 |   982.9 ns |  3.65 ns |  3.42 ns |  1.04 |    0.01 | 0.9670 |     - |     - |    2024 B |
|         ValueLinq_Ref_SharedPool_Push |   100 | 1,427.5 ns |  5.30 ns |  4.70 ns |  1.51 |    0.00 | 0.9670 |     - |     - |    2024 B |
|         ValueLinq_Ref_SharedPool_Pull |   100 | 1,254.5 ns |  3.94 ns |  3.49 ns |  1.33 |    0.00 | 0.9670 |     - |     - |    2024 B |
|        ValueLinq_ValueLambda_Standard |   100 | 1,001.1 ns |  3.12 ns |  2.92 ns |  1.06 |    0.00 | 0.9670 |     - |     - |    2024 B |
|           ValueLinq_ValueLambda_Stack |   100 |   964.4 ns |  1.83 ns |  1.43 ns |  1.02 |    0.00 | 0.9670 |     - |     - |    2024 B |
| ValueLinq_ValueLambda_SharedPool_Push |   100 | 1,197.5 ns |  2.74 ns |  2.29 ns |  1.27 |    0.01 | 0.9670 |     - |     - |    2024 B |
| ValueLinq_ValueLambda_SharedPool_Pull |   100 | 1,198.9 ns |  2.96 ns |  2.47 ns |  1.27 |    0.00 | 0.9670 |     - |     - |    2024 B |
|                               ForLoop |   100 |   944.8 ns |  3.97 ns |  3.32 ns |  1.00 |    0.00 | 3.4103 |     - |     - |    7136 B |
|                           ForeachLoop |   100 | 1,003.7 ns | 13.52 ns | 10.56 ns |  1.06 |    0.01 | 3.4103 |     - |     - |    7136 B |
|                                  Linq |   100 | 1,270.9 ns |  8.55 ns |  7.58 ns |  1.35 |    0.01 | 2.4319 |     - |     - |    5088 B |
|                            LinqFaster |   100 | 1,037.8 ns |  7.30 ns |  6.10 ns |  1.10 |    0.01 | 2.8896 |     - |     - |    6048 B |
|                                LinqAF |   100 | 2,043.7 ns | 26.23 ns | 21.91 ns |  2.16 |    0.02 | 3.3951 |     - |     - |    7104 B |
|                            StructLinq |   100 | 1,204.8 ns |  6.49 ns |  5.42 ns |  1.28 |    0.01 | 1.0128 |     - |     - |    2120 B |
|                  StructLinq_IFunction |   100 |   838.2 ns |  4.45 ns |  3.95 ns |  0.89 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                             Hyperlinq |   100 | 1,069.6 ns |  6.04 ns |  5.36 ns |  1.13 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                   Hyperlinq_IFunction |   100 |   818.3 ns |  4.36 ns |  4.08 ns |  0.87 |    0.00 | 0.9670 |     - |     - |    2024 B |
|                        Hyperlinq_Pool |   100 | 1,005.5 ns |  3.22 ns |  2.85 ns |  1.06 |    0.00 | 0.0267 |     - |     - |      56 B |
|              Hyperlinq_Pool_IFunction |   100 |   761.1 ns |  1.79 ns |  1.49 ns |  0.81 |    0.00 | 0.0267 |     - |     - |      56 B |
