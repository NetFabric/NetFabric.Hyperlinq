## Array.Int32.ArrayInt32WhereSelectToArray

### Source
[ArrayInt32WhereSelectToArray.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelectToArray.cs)

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
|                                Method | Count |     Mean |   Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |---------:|--------:|--------:|------:|--------:|-------:|------:|------:|----------:|
|                    ValueLinq_Standard |   100 | 543.5 ns | 1.79 ns | 1.59 ns |  2.09 |    0.00 | 0.1144 |     - |     - |     240 B |
|                       ValueLinq_Stack |   100 | 491.1 ns | 2.49 ns | 2.21 ns |  1.89 |    0.01 | 0.1144 |     - |     - |     240 B |
|             ValueLinq_SharedPool_Push |   100 | 772.5 ns | 4.33 ns | 4.05 ns |  2.97 |    0.02 | 0.1144 |     - |     - |     240 B |
|             ValueLinq_SharedPool_Pull |   100 | 751.0 ns | 5.35 ns | 4.74 ns |  2.88 |    0.02 | 0.1144 |     - |     - |     240 B |
|        ValueLinq_ValueLambda_Standard |   100 | 354.8 ns | 0.75 ns | 0.66 ns |  1.36 |    0.00 | 0.1144 |     - |     - |     240 B |
|           ValueLinq_ValueLambda_Stack |   100 | 313.0 ns | 0.84 ns | 0.75 ns |  1.20 |    0.01 | 0.1144 |     - |     - |     240 B |
| ValueLinq_ValueLambda_SharedPool_Push |   100 | 496.9 ns | 2.03 ns | 1.90 ns |  1.91 |    0.01 | 0.1144 |     - |     - |     240 B |
| ValueLinq_ValueLambda_SharedPool_Pull |   100 | 526.9 ns | 1.82 ns | 1.62 ns |  2.02 |    0.01 | 0.1144 |     - |     - |     240 B |
|                               ForLoop |   100 | 260.3 ns | 0.83 ns | 0.78 ns |  1.00 |    0.00 | 0.4244 |     - |     - |     888 B |
|                           ForeachLoop |   100 | 232.7 ns | 1.22 ns | 1.08 ns |  0.89 |    0.00 | 0.4246 |     - |     - |     888 B |
|                                  Linq |   100 | 580.1 ns | 2.80 ns | 2.19 ns |  2.23 |    0.01 | 0.3786 |     - |     - |     792 B |
|                            LinqFaster |   100 | 334.9 ns | 1.25 ns | 1.11 ns |  1.29 |    0.00 | 0.3171 |     - |     - |     664 B |
|                                LinqAF |   100 | 701.4 ns | 3.38 ns | 2.99 ns |  2.69 |    0.01 | 0.4091 |     - |     - |     856 B |
|                            StructLinq |   100 | 569.1 ns | 3.03 ns | 2.69 ns |  2.19 |    0.01 | 0.1602 |     - |     - |     336 B |
|                  StructLinq_IFunction |   100 | 301.6 ns | 0.85 ns | 0.75 ns |  1.16 |    0.00 | 0.1144 |     - |     - |     240 B |
|                             Hyperlinq |   100 | 597.7 ns | 2.08 ns | 1.84 ns |  2.30 |    0.01 | 0.1144 |     - |     - |     240 B |
|                   Hyperlinq_IFunction |   100 | 328.6 ns | 1.62 ns | 1.44 ns |  1.26 |    0.01 | 0.1144 |     - |     - |     240 B |
|                        Hyperlinq_Pool |   100 | 631.1 ns | 2.49 ns | 2.21 ns |  2.42 |    0.01 | 0.0267 |     - |     - |      56 B |
|              Hyperlinq_Pool_IFunction |   100 | 641.5 ns | 1.47 ns | 1.37 ns |  2.46 |    0.01 | 0.0267 |     - |     - |      56 B |
