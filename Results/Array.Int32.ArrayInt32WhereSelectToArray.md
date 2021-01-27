## Array.Int32.ArrayInt32WhereSelectToArray

### Source
[ArrayInt32WhereSelectToArray.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelectToArray.cs)

### References:
- Cistern.ValueLinq: [0.0.11](https://www.nuget.org/packages/Cistern.ValueLinq/0.0.11)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.19.2](https://www.nuget.org/packages/StructLinq.BCL/0.19.2)
- NetFabric.Hyperlinq: [3.0.0-beta27](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta27)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                                Method | Count |     Mean |   Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |---------:|--------:|--------:|------:|--------:|-------:|------:|------:|----------:|
|                    ValueLinq_Standard |   100 | 724.1 ns | 3.31 ns | 2.93 ns |  2.85 |    0.01 | 0.3557 |     - |     - |     744 B |
|                       ValueLinq_Stack |   100 | 521.1 ns | 2.01 ns | 1.68 ns |  2.05 |    0.01 | 0.1068 |     - |     - |     224 B |
|             ValueLinq_SharedPool_Push |   100 | 701.7 ns | 0.98 ns | 0.87 ns |  2.77 |    0.01 | 0.1068 |     - |     - |     224 B |
|             ValueLinq_SharedPool_Pull |   100 | 700.1 ns | 3.39 ns | 3.01 ns |  2.76 |    0.01 | 0.1068 |     - |     - |     224 B |
|        ValueLinq_ValueLambda_Standard |   100 | 461.5 ns | 1.79 ns | 1.50 ns |  1.82 |    0.01 | 0.3557 |     - |     - |     744 B |
|           ValueLinq_ValueLambda_Stack |   100 | 303.9 ns | 0.87 ns | 0.68 ns |  1.20 |    0.00 | 0.1068 |     - |     - |     224 B |
| ValueLinq_ValueLambda_SharedPool_Push |   100 | 496.7 ns | 2.06 ns | 1.83 ns |  1.96 |    0.01 | 0.1068 |     - |     - |     224 B |
| ValueLinq_ValueLambda_SharedPool_Pull |   100 | 520.9 ns | 1.91 ns | 1.70 ns |  2.05 |    0.01 | 0.1068 |     - |     - |     224 B |
|                               ForLoop |   100 | 253.7 ns | 1.10 ns | 0.92 ns |  1.00 |    0.00 | 0.4168 |     - |     - |     872 B |
|                           ForeachLoop |   100 | 261.4 ns | 0.83 ns | 0.69 ns |  1.03 |    0.00 | 0.4168 |     - |     - |     872 B |
|                                  Linq |   100 | 546.2 ns | 1.27 ns | 1.12 ns |  2.15 |    0.01 | 0.3710 |     - |     - |     776 B |
|                            LinqFaster |   100 | 356.3 ns | 1.17 ns | 0.97 ns |  1.40 |    0.01 | 0.3095 |     - |     - |     648 B |
|                                LinqAF |   100 | 678.4 ns | 4.04 ns | 3.59 ns |  2.67 |    0.02 | 0.4015 |     - |     - |     840 B |
|                            StructLinq |   100 | 503.1 ns | 1.49 ns | 1.25 ns |  1.98 |    0.01 | 0.1526 |     - |     - |     320 B |
|                  StructLinq_IFunction |   100 | 345.2 ns | 1.50 ns | 1.33 ns |  1.36 |    0.00 | 0.1068 |     - |     - |     224 B |
|                             Hyperlinq |   100 | 602.3 ns | 1.77 ns | 1.57 ns |  2.37 |    0.01 | 0.1068 |     - |     - |     224 B |
|                   Hyperlinq_IFunction |   100 | 325.9 ns | 0.99 ns | 0.88 ns |  1.28 |    0.00 | 0.1068 |     - |     - |     224 B |
|                        Hyperlinq_Pool |   100 | 634.5 ns | 1.18 ns | 1.05 ns |  2.50 |    0.01 | 0.0267 |     - |     - |      56 B |
|              Hyperlinq_Pool_IFunction |   100 | 652.0 ns | 2.09 ns | 1.74 ns |  2.57 |    0.01 | 0.0267 |     - |     - |      56 B |
