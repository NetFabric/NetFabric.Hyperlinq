## Array.Int32.ArrayInt32WhereSelectToArray

### Source
[ArrayInt32WhereSelectToArray.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelectToArray.cs)

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
|                                Method | Count |     Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |---------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                    ValueLinq_Standard |   100 | 888.1 ns | 17.62 ns | 33.53 ns |  3.34 |    0.13 | 0.1068 |     - |     - |     224 B |
|                       ValueLinq_Stack |   100 | 509.6 ns |  2.91 ns |  2.58 ns |  1.90 |    0.01 | 0.1068 |     - |     - |     224 B |
|             ValueLinq_SharedPool_Push |   100 | 797.5 ns |  4.79 ns |  4.48 ns |  2.98 |    0.02 | 0.1068 |     - |     - |     224 B |
|             ValueLinq_SharedPool_Pull |   100 | 670.8 ns |  2.19 ns |  1.94 ns |  2.51 |    0.01 | 0.1068 |     - |     - |     224 B |
|        ValueLinq_ValueLambda_Standard |   100 | 356.7 ns |  2.11 ns |  1.77 ns |  1.33 |    0.01 | 0.1068 |     - |     - |     224 B |
|           ValueLinq_ValueLambda_Stack |   100 | 328.3 ns |  1.19 ns |  1.06 ns |  1.23 |    0.00 | 0.1068 |     - |     - |     224 B |
| ValueLinq_ValueLambda_SharedPool_Push |   100 | 505.7 ns |  4.52 ns |  3.78 ns |  1.89 |    0.01 | 0.1068 |     - |     - |     224 B |
| ValueLinq_ValueLambda_SharedPool_Pull |   100 | 577.6 ns |  2.50 ns |  2.21 ns |  2.16 |    0.01 | 0.1068 |     - |     - |     224 B |
|                               ForLoop |   100 | 267.5 ns |  1.13 ns |  0.94 ns |  1.00 |    0.00 | 0.4168 |     - |     - |     872 B |
|                           ForeachLoop |   100 | 268.3 ns |  1.67 ns |  1.39 ns |  1.00 |    0.01 | 0.4168 |     - |     - |     872 B |
|                                  Linq |   100 | 782.9 ns | 12.39 ns | 10.98 ns |  2.93 |    0.04 | 0.3710 |     - |     - |     776 B |
|                            LinqFaster |   100 | 335.4 ns |  1.38 ns |  1.22 ns |  1.25 |    0.01 | 0.3095 |     - |     - |     648 B |
|                                LinqAF |   100 | 875.3 ns | 11.74 ns | 10.40 ns |  3.27 |    0.03 | 0.4015 |     - |     - |     840 B |
|                            StructLinq |   100 | 535.7 ns |  1.93 ns |  1.71 ns |  2.00 |    0.01 | 0.1526 |     - |     - |     320 B |
|                  StructLinq_IFunction |   100 | 308.1 ns |  1.10 ns |  0.91 ns |  1.15 |    0.00 | 0.1068 |     - |     - |     224 B |
|                             Hyperlinq |   100 | 613.2 ns |  2.34 ns |  2.08 ns |  2.29 |    0.01 | 0.1068 |     - |     - |     224 B |
|                   Hyperlinq_IFunction |   100 | 348.2 ns |  1.67 ns |  1.56 ns |  1.30 |    0.01 | 0.1068 |     - |     - |     224 B |
|                        Hyperlinq_Pool |   100 | 640.5 ns |  2.70 ns |  2.39 ns |  2.40 |    0.01 | 0.0267 |     - |     - |      56 B |
|              Hyperlinq_Pool_IFunction |   100 | 632.9 ns |  3.36 ns |  2.98 ns |  2.37 |    0.02 | 0.0267 |     - |     - |      56 B |
