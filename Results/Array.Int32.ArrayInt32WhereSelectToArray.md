## Array.Int32.ArrayInt32WhereSelectToArray

### Source
[ArrayInt32WhereSelectToArray.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelectToArray.cs)

### References:
- Cistern.ValueLinq: [0.0.11](https://www.nuget.org/packages/Cistern.ValueLinq/0.0.11)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta28](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta28)

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
|                    ValueLinq_Standard |   100 | 786.2 ns | 3.06 ns | 2.71 ns |  3.09 |    0.02 | 0.3557 |     - |     - |     744 B |
|                       ValueLinq_Stack |   100 | 592.2 ns | 3.98 ns | 3.53 ns |  2.33 |    0.02 | 0.1068 |     - |     - |     224 B |
|             ValueLinq_SharedPool_Push |   100 | 819.3 ns | 5.46 ns | 4.56 ns |  3.23 |    0.03 | 0.1068 |     - |     - |     224 B |
|             ValueLinq_SharedPool_Pull |   100 | 794.5 ns | 4.41 ns | 3.91 ns |  3.13 |    0.03 | 0.1068 |     - |     - |     224 B |
|        ValueLinq_ValueLambda_Standard |   100 | 539.9 ns | 2.36 ns | 2.09 ns |  2.12 |    0.02 | 0.3557 |     - |     - |     744 B |
|           ValueLinq_ValueLambda_Stack |   100 | 341.8 ns | 0.91 ns | 0.80 ns |  1.34 |    0.01 | 0.1068 |     - |     - |     224 B |
| ValueLinq_ValueLambda_SharedPool_Push |   100 | 586.3 ns | 2.99 ns | 2.65 ns |  2.31 |    0.02 | 0.1068 |     - |     - |     224 B |
| ValueLinq_ValueLambda_SharedPool_Pull |   100 | 573.0 ns | 5.35 ns | 5.01 ns |  2.25 |    0.02 | 0.1068 |     - |     - |     224 B |
|                               ForLoop |   100 | 254.2 ns | 1.66 ns | 1.47 ns |  1.00 |    0.00 | 0.4168 |     - |     - |     872 B |
|                           ForeachLoop |   100 | 249.1 ns | 1.66 ns | 1.47 ns |  0.98 |    0.01 | 0.4168 |     - |     - |     872 B |
|                                  Linq |   100 | 621.5 ns | 2.19 ns | 1.83 ns |  2.45 |    0.01 | 0.3710 |     - |     - |     776 B |
|                            LinqFaster |   100 | 374.7 ns | 1.64 ns | 1.37 ns |  1.48 |    0.01 | 0.3095 |     - |     - |     648 B |
|                                LinqAF |   100 | 723.9 ns | 3.98 ns | 3.53 ns |  2.85 |    0.03 | 0.4015 |     - |     - |     840 B |
|                            StructLinq |   100 | 592.5 ns | 2.77 ns | 2.59 ns |  2.33 |    0.01 | 0.1526 |     - |     - |     320 B |
|                  StructLinq_IFunction |   100 | 314.5 ns | 1.80 ns | 1.68 ns |  1.24 |    0.01 | 0.1068 |     - |     - |     224 B |
|                             Hyperlinq |   100 | 718.5 ns | 2.21 ns | 1.85 ns |  2.83 |    0.02 | 0.1068 |     - |     - |     224 B |
|                   Hyperlinq_IFunction |   100 | 394.3 ns | 2.02 ns | 1.89 ns |  1.55 |    0.01 | 0.1068 |     - |     - |     224 B |
|                        Hyperlinq_Pool |   100 | 702.8 ns | 4.63 ns | 3.86 ns |  2.77 |    0.02 | 0.0267 |     - |     - |      56 B |
|              Hyperlinq_Pool_IFunction |   100 | 718.1 ns | 2.92 ns | 2.44 ns |  2.83 |    0.02 | 0.0267 |     - |     - |      56 B |
