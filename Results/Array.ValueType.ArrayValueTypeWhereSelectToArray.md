## Array.ValueType.ArrayValueTypeWhereSelectToArray

### Source
[ArrayValueTypeWhereSelectToArray.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelectToArray.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta35](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta35)

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
|                    ValueLinq_Standard |   100 | 1,099.3 ns |  3.10 ns |  2.75 ns |  1.11 |    0.01 | 1.0433 |     - |     - |    2184 B |
|                       ValueLinq_Stack |   100 | 1,048.3 ns |  4.91 ns |  4.10 ns |  1.06 |    0.01 | 1.0433 |     - |     - |    2184 B |
|             ValueLinq_SharedPool_Push |   100 | 1,651.6 ns | 10.07 ns |  8.93 ns |  1.67 |    0.02 | 1.0433 |     - |     - |    2184 B |
|             ValueLinq_SharedPool_Pull |   100 | 1,316.1 ns |  3.76 ns |  3.33 ns |  1.33 |    0.01 | 1.0433 |     - |     - |    2184 B |
|                ValueLinq_Ref_Standard |   100 | 1,113.0 ns |  7.55 ns |  7.06 ns |  1.13 |    0.02 | 1.0433 |     - |     - |    2184 B |
|                   ValueLinq_Ref_Stack |   100 | 1,049.5 ns |  7.13 ns |  6.67 ns |  1.06 |    0.01 | 1.0433 |     - |     - |    2184 B |
|         ValueLinq_Ref_SharedPool_Push |   100 | 1,497.9 ns |  6.02 ns |  5.34 ns |  1.52 |    0.02 | 1.0433 |     - |     - |    2184 B |
|         ValueLinq_Ref_SharedPool_Pull |   100 | 1,300.9 ns |  8.39 ns |  7.44 ns |  1.32 |    0.01 | 1.0433 |     - |     - |    2184 B |
|        ValueLinq_ValueLambda_Standard |   100 | 1,071.1 ns |  5.08 ns |  4.50 ns |  1.08 |    0.01 | 1.0433 |     - |     - |    2184 B |
|           ValueLinq_ValueLambda_Stack |   100 | 1,015.8 ns |  3.03 ns |  2.37 ns |  1.03 |    0.01 | 1.0433 |     - |     - |    2184 B |
| ValueLinq_ValueLambda_SharedPool_Push |   100 | 1,294.2 ns |  3.06 ns |  2.87 ns |  1.31 |    0.01 | 1.0433 |     - |     - |    2184 B |
| ValueLinq_ValueLambda_SharedPool_Pull |   100 | 1,272.8 ns |  6.16 ns |  5.76 ns |  1.29 |    0.01 | 1.0433 |     - |     - |    2184 B |
|                               ForLoop |   100 |   988.1 ns | 10.74 ns |  9.53 ns |  1.00 |    0.00 | 3.4866 |     - |     - |    7296 B |
|                           ForeachLoop |   100 | 1,029.8 ns |  6.50 ns |  5.76 ns |  1.04 |    0.01 | 3.4866 |     - |     - |    7296 B |
|                                  Linq |   100 | 1,300.6 ns |  6.75 ns |  6.32 ns |  1.32 |    0.01 | 2.5082 |     - |     - |    5248 B |
|                            LinqFaster |   100 | 1,087.8 ns |  8.19 ns |  7.67 ns |  1.10 |    0.01 | 2.9659 |     - |     - |    6208 B |
|                                LinqAF |   100 | 2,139.6 ns | 25.32 ns | 23.69 ns |  2.17 |    0.03 | 3.4714 |     - |     - |    7264 B |
|                            StructLinq |   100 | 1,220.7 ns |  9.84 ns |  8.72 ns |  1.24 |    0.01 | 1.0891 |     - |     - |    2280 B |
|                  StructLinq_IFunction |   100 |   877.6 ns |  3.43 ns |  3.04 ns |  0.89 |    0.01 | 1.0433 |     - |     - |    2184 B |
|                             Hyperlinq |   100 | 1,111.3 ns |  4.06 ns |  3.59 ns |  1.12 |    0.01 | 1.0433 |     - |     - |    2184 B |
|                   Hyperlinq_IFunction |   100 |   858.0 ns |  3.50 ns |  3.28 ns |  0.87 |    0.01 | 1.0433 |     - |     - |    2184 B |
|                        Hyperlinq_Pool |   100 | 1,050.1 ns |  1.61 ns |  1.34 ns |  1.06 |    0.01 | 0.0267 |     - |     - |      56 B |
|              Hyperlinq_Pool_IFunction |   100 |   798.6 ns |  2.52 ns |  2.10 ns |  0.81 |    0.01 | 0.0267 |     - |     - |      56 B |
