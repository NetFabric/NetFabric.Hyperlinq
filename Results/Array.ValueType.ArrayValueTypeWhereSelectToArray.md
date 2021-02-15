## Array.ValueType.ArrayValueTypeWhereSelectToArray

### Source
[ArrayValueTypeWhereSelectToArray.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelectToArray.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta36](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta36)

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
|                    ValueLinq_Standard |   100 | 1,133.4 ns |  4.55 ns |  3.80 ns |  1.11 |    0.01 | 1.0433 |     - |     - |    2184 B |
|                       ValueLinq_Stack |   100 | 1,088.2 ns |  4.69 ns |  4.16 ns |  1.06 |    0.01 | 1.0433 |     - |     - |    2184 B |
|             ValueLinq_SharedPool_Push |   100 | 1,696.3 ns | 12.79 ns | 11.96 ns |  1.66 |    0.01 | 1.0433 |     - |     - |    2184 B |
|             ValueLinq_SharedPool_Pull |   100 | 1,368.0 ns |  5.63 ns |  5.26 ns |  1.34 |    0.01 | 1.0433 |     - |     - |    2184 B |
|                ValueLinq_Ref_Standard |   100 | 1,130.0 ns |  4.96 ns |  4.40 ns |  1.10 |    0.01 | 1.0433 |     - |     - |    2184 B |
|                   ValueLinq_Ref_Stack |   100 | 1,075.9 ns |  6.85 ns |  5.72 ns |  1.05 |    0.01 | 1.0433 |     - |     - |    2184 B |
|         ValueLinq_Ref_SharedPool_Push |   100 | 1,551.2 ns |  7.65 ns |  7.16 ns |  1.52 |    0.01 | 1.0433 |     - |     - |    2184 B |
|         ValueLinq_Ref_SharedPool_Pull |   100 | 1,401.1 ns |  7.96 ns |  7.06 ns |  1.37 |    0.01 | 1.0433 |     - |     - |    2184 B |
|        ValueLinq_ValueLambda_Standard |   100 | 1,103.9 ns |  5.48 ns |  4.86 ns |  1.08 |    0.01 | 1.0433 |     - |     - |    2184 B |
|           ValueLinq_ValueLambda_Stack |   100 | 1,055.3 ns |  6.52 ns |  5.44 ns |  1.03 |    0.01 | 1.0433 |     - |     - |    2184 B |
| ValueLinq_ValueLambda_SharedPool_Push |   100 | 1,291.8 ns |  6.08 ns |  5.69 ns |  1.26 |    0.01 | 1.0433 |     - |     - |    2184 B |
| ValueLinq_ValueLambda_SharedPool_Pull |   100 | 1,303.5 ns |  5.80 ns |  5.14 ns |  1.27 |    0.01 | 1.0433 |     - |     - |    2184 B |
|                               ForLoop |   100 | 1,023.5 ns |  7.32 ns |  6.49 ns |  1.00 |    0.00 | 3.4866 |     - |     - |    7296 B |
|                           ForeachLoop |   100 | 1,059.2 ns |  8.66 ns |  7.68 ns |  1.03 |    0.01 | 3.4866 |     - |     - |    7296 B |
|                                  Linq |   100 | 1,343.6 ns |  8.79 ns |  7.34 ns |  1.31 |    0.01 | 2.5082 |     - |     - |    5248 B |
|                            LinqFaster |   100 | 1,115.0 ns |  7.39 ns |  6.55 ns |  1.09 |    0.01 | 2.9659 |     - |     - |    6208 B |
|                                LinqAF |   100 | 2,206.1 ns | 27.35 ns | 24.24 ns |  2.16 |    0.03 | 3.4714 |     - |     - |    7264 B |
|                            StructLinq |   100 | 1,260.2 ns |  8.23 ns |  7.30 ns |  1.23 |    0.01 | 1.0891 |     - |     - |    2280 B |
|                  StructLinq_IFunction |   100 |   908.1 ns |  8.70 ns |  7.71 ns |  0.89 |    0.01 | 1.0433 |     - |     - |    2184 B |
|                             Hyperlinq |   100 | 1,148.7 ns |  5.87 ns |  5.20 ns |  1.12 |    0.01 | 1.0433 |     - |     - |    2184 B |
|                   Hyperlinq_IFunction |   100 |   887.1 ns |  6.46 ns |  6.04 ns |  0.87 |    0.01 | 1.0433 |     - |     - |    2184 B |
|                        Hyperlinq_Pool |   100 | 1,079.4 ns |  2.10 ns |  1.97 ns |  1.05 |    0.01 | 0.0267 |     - |     - |      56 B |
|              Hyperlinq_Pool_IFunction |   100 |   869.1 ns |  3.20 ns |  2.84 ns |  0.85 |    0.01 | 0.0267 |     - |     - |      56 B |
