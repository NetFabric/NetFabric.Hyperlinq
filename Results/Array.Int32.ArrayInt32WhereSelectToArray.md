## Array.Int32.ArrayInt32WhereSelectToArray

### Source
[ArrayInt32WhereSelectToArray.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelectToArray.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta33](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta33)

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
|                    ValueLinq_Standard |   100 | 531.3 ns | 10.05 ns | 15.04 ns |  2.10 |    0.08 | 0.1068 |     - |     - |     224 B |
|                       ValueLinq_Stack |   100 | 530.2 ns |  1.72 ns |  1.53 ns |  2.08 |    0.01 | 0.1068 |     - |     - |     224 B |
|             ValueLinq_SharedPool_Push |   100 | 802.8 ns |  1.76 ns |  1.65 ns |  3.15 |    0.01 | 0.1068 |     - |     - |     224 B |
|             ValueLinq_SharedPool_Pull |   100 | 666.0 ns |  2.00 ns |  1.78 ns |  2.61 |    0.01 | 0.1068 |     - |     - |     224 B |
|        ValueLinq_ValueLambda_Standard |   100 | 351.4 ns |  1.09 ns |  0.91 ns |  1.38 |    0.01 | 0.1068 |     - |     - |     224 B |
|           ValueLinq_ValueLambda_Stack |   100 | 329.8 ns |  1.51 ns |  1.34 ns |  1.29 |    0.01 | 0.1068 |     - |     - |     224 B |
| ValueLinq_ValueLambda_SharedPool_Push |   100 | 495.2 ns |  1.23 ns |  1.03 ns |  1.94 |    0.01 | 0.1068 |     - |     - |     224 B |
| ValueLinq_ValueLambda_SharedPool_Pull |   100 | 540.0 ns |  1.85 ns |  1.55 ns |  2.12 |    0.01 | 0.1068 |     - |     - |     224 B |
|                               ForLoop |   100 | 254.8 ns |  0.91 ns |  0.76 ns |  1.00 |    0.00 | 0.4168 |     - |     - |     872 B |
|                           ForeachLoop |   100 | 253.8 ns |  1.51 ns |  1.41 ns |  1.00 |    0.01 | 0.4168 |     - |     - |     872 B |
|                                  Linq |   100 | 542.4 ns |  2.23 ns |  2.08 ns |  2.13 |    0.01 | 0.3710 |     - |     - |     776 B |
|                            LinqFaster |   100 | 357.1 ns |  1.04 ns |  0.92 ns |  1.40 |    0.01 | 0.3095 |     - |     - |     648 B |
|                                LinqAF |   100 | 670.5 ns |  2.23 ns |  1.86 ns |  2.63 |    0.01 | 0.4015 |     - |     - |     840 B |
|                            StructLinq |   100 | 523.1 ns |  1.57 ns |  1.39 ns |  2.05 |    0.01 | 0.1526 |     - |     - |     320 B |
|                  StructLinq_IFunction |   100 | 283.5 ns |  1.33 ns |  1.18 ns |  1.11 |    0.01 | 0.1068 |     - |     - |     224 B |
|                             Hyperlinq |   100 | 581.4 ns |  3.29 ns |  2.91 ns |  2.28 |    0.01 | 0.1068 |     - |     - |     224 B |
|                   Hyperlinq_IFunction |   100 | 346.7 ns |  1.07 ns |  0.89 ns |  1.36 |    0.01 | 0.1068 |     - |     - |     224 B |
|                        Hyperlinq_Pool |   100 | 634.6 ns |  1.85 ns |  1.74 ns |  2.49 |    0.01 | 0.0267 |     - |     - |      56 B |
|              Hyperlinq_Pool_IFunction |   100 | 620.3 ns |  1.69 ns |  1.41 ns |  2.43 |    0.01 | 0.0267 |     - |     - |      56 B |
