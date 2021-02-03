## Array.Int32.ArrayInt32WhereSelectToArray

### Source
[ArrayInt32WhereSelectToArray.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelectToArray.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta31](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta31)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                                Method | Count |     Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |---------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                    ValueLinq_Standard |   100 | 543.5 ns |  1.44 ns |  1.28 ns |  2.04 |    0.01 | 0.1068 |     - |     - |     224 B |
|                       ValueLinq_Stack |   100 | 505.4 ns |  1.88 ns |  1.47 ns |  1.90 |    0.01 | 0.1068 |     - |     - |     224 B |
|             ValueLinq_SharedPool_Push |   100 | 800.8 ns |  2.04 ns |  1.81 ns |  3.01 |    0.02 | 0.1068 |     - |     - |     224 B |
|             ValueLinq_SharedPool_Pull |   100 | 674.8 ns |  1.20 ns |  1.07 ns |  2.54 |    0.01 | 0.1068 |     - |     - |     224 B |
|        ValueLinq_ValueLambda_Standard |   100 | 355.5 ns |  0.63 ns |  0.53 ns |  1.34 |    0.01 | 0.1068 |     - |     - |     224 B |
|           ValueLinq_ValueLambda_Stack |   100 | 326.3 ns |  1.57 ns |  1.39 ns |  1.23 |    0.01 | 0.1068 |     - |     - |     224 B |
| ValueLinq_ValueLambda_SharedPool_Push |   100 | 506.4 ns |  4.85 ns |  3.79 ns |  1.90 |    0.02 | 0.1068 |     - |     - |     224 B |
| ValueLinq_ValueLambda_SharedPool_Pull |   100 | 576.9 ns |  7.36 ns |  6.52 ns |  2.17 |    0.03 | 0.1068 |     - |     - |     224 B |
|                               ForLoop |   100 | 266.2 ns |  1.59 ns |  1.41 ns |  1.00 |    0.00 | 0.4168 |     - |     - |     872 B |
|                           ForeachLoop |   100 | 266.7 ns |  2.07 ns |  1.83 ns |  1.00 |    0.01 | 0.4168 |     - |     - |     872 B |
|                                  Linq |   100 | 806.1 ns |  8.96 ns |  7.94 ns |  3.03 |    0.04 | 0.3710 |     - |     - |     776 B |
|                            LinqFaster |   100 | 332.9 ns |  0.67 ns |  0.59 ns |  1.25 |    0.01 | 0.3095 |     - |     - |     648 B |
|                                LinqAF |   100 | 933.3 ns | 14.08 ns | 12.48 ns |  3.51 |    0.05 | 0.4015 |     - |     - |     840 B |
|                            StructLinq |   100 | 530.0 ns |  1.35 ns |  1.20 ns |  1.99 |    0.01 | 0.1526 |     - |     - |     320 B |
|                  StructLinq_IFunction |   100 | 321.7 ns |  2.84 ns |  2.66 ns |  1.21 |    0.01 | 0.1068 |     - |     - |     224 B |
|                             Hyperlinq |   100 | 590.4 ns |  1.52 ns |  1.27 ns |  2.22 |    0.01 | 0.1068 |     - |     - |     224 B |
|                   Hyperlinq_IFunction |   100 | 425.7 ns |  3.73 ns |  3.30 ns |  1.60 |    0.01 | 0.1068 |     - |     - |     224 B |
|                        Hyperlinq_Pool |   100 | 641.9 ns |  1.53 ns |  1.35 ns |  2.41 |    0.01 | 0.0267 |     - |     - |      56 B |
|              Hyperlinq_Pool_IFunction |   100 | 636.7 ns |  1.56 ns |  1.46 ns |  2.39 |    0.02 | 0.0267 |     - |     - |      56 B |
