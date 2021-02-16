## Array.ValueType.ArrayValueTypeWhereSelectToArray

### Source
[ArrayValueTypeWhereSelectToArray.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelectToArray.cs)

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
|                    ValueLinq_Standard |   100 | 1,094.9 ns |  4.50 ns |  3.75 ns |  1.11 |    0.01 | 1.0433 |     - |     - |    2184 B |
|                       ValueLinq_Stack |   100 | 1,051.1 ns |  3.14 ns |  2.62 ns |  1.07 |    0.01 | 1.0433 |     - |     - |    2184 B |
|             ValueLinq_SharedPool_Push |   100 | 1,632.7 ns |  6.54 ns |  5.46 ns |  1.66 |    0.01 | 1.0433 |     - |     - |    2184 B |
|             ValueLinq_SharedPool_Pull |   100 | 1,315.1 ns |  4.26 ns |  3.77 ns |  1.34 |    0.01 | 1.0433 |     - |     - |    2184 B |
|                ValueLinq_Ref_Standard |   100 | 1,091.6 ns |  3.51 ns |  3.11 ns |  1.11 |    0.01 | 1.0433 |     - |     - |    2184 B |
|                   ValueLinq_Ref_Stack |   100 | 1,045.6 ns |  6.17 ns |  5.47 ns |  1.06 |    0.01 | 1.0433 |     - |     - |    2184 B |
|         ValueLinq_Ref_SharedPool_Push |   100 | 1,489.5 ns |  7.61 ns |  6.74 ns |  1.52 |    0.01 | 1.0433 |     - |     - |    2184 B |
|         ValueLinq_Ref_SharedPool_Pull |   100 | 1,341.8 ns |  3.23 ns |  3.02 ns |  1.37 |    0.01 | 1.0433 |     - |     - |    2184 B |
|        ValueLinq_ValueLambda_Standard |   100 | 1,057.4 ns |  6.81 ns |  5.32 ns |  1.08 |    0.01 | 1.0433 |     - |     - |    2184 B |
|           ValueLinq_ValueLambda_Stack |   100 | 1,023.0 ns |  3.52 ns |  3.12 ns |  1.04 |    0.01 | 1.0433 |     - |     - |    2184 B |
| ValueLinq_ValueLambda_SharedPool_Push |   100 | 1,291.8 ns |  5.41 ns |  5.06 ns |  1.31 |    0.01 | 1.0433 |     - |     - |    2184 B |
| ValueLinq_ValueLambda_SharedPool_Pull |   100 | 1,235.9 ns |  4.76 ns |  4.45 ns |  1.26 |    0.01 | 1.0433 |     - |     - |    2184 B |
|                               ForLoop |   100 |   982.7 ns |  5.03 ns |  4.20 ns |  1.00 |    0.00 | 3.4866 |     - |     - |    7296 B |
|                           ForeachLoop |   100 | 1,036.7 ns |  5.22 ns |  4.88 ns |  1.06 |    0.01 | 3.4866 |     - |     - |    7296 B |
|                                  Linq |   100 | 1,299.7 ns |  4.91 ns |  4.59 ns |  1.32 |    0.01 | 2.5082 |     - |     - |    5248 B |
|                            LinqFaster |   100 | 1,064.7 ns |  8.65 ns |  8.09 ns |  1.08 |    0.01 | 2.9659 |     - |     - |    6208 B |
|                                LinqAF |   100 | 2,200.0 ns | 16.07 ns | 15.04 ns |  2.24 |    0.02 | 3.4714 |     - |     - |    7264 B |
|                            StructLinq |   100 | 1,211.5 ns |  5.69 ns |  5.04 ns |  1.23 |    0.01 | 1.0891 |     - |     - |    2280 B |
|                  StructLinq_IFunction |   100 |   872.2 ns |  4.70 ns |  4.17 ns |  0.89 |    0.01 | 1.0433 |     - |     - |    2184 B |
|                             Hyperlinq |   100 | 1,113.1 ns |  3.27 ns |  2.73 ns |  1.13 |    0.01 | 1.0433 |     - |     - |    2184 B |
|                   Hyperlinq_IFunction |   100 |   857.7 ns |  3.99 ns |  3.54 ns |  0.87 |    0.01 | 1.0433 |     - |     - |    2184 B |
|                        Hyperlinq_Pool |   100 | 1,043.6 ns |  3.33 ns |  2.78 ns |  1.06 |    0.01 | 0.0267 |     - |     - |      56 B |
|              Hyperlinq_Pool_IFunction |   100 |   807.3 ns |  2.11 ns |  1.87 ns |  0.82 |    0.00 | 0.0267 |     - |     - |      56 B |
