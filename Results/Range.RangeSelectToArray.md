## Range.RangeSelectToArray

### Source
[RangeSelectToArray.cs](../LinqBenchmarks/Range/RangeSelectToArray.cs)

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
|                                Method | Start | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                    ValueLinq_Standard |     0 |   100 | 300.43 ns | 1.337 ns | 1.251 ns |  3.49 |    0.03 | 0.2027 |     - |     - |     424 B |
|                       ValueLinq_Stack |     0 |   100 | 546.81 ns | 1.779 ns | 1.664 ns |  6.35 |    0.03 | 0.3166 |     - |     - |     664 B |
|             ValueLinq_SharedPool_Push |     0 |   100 | 590.55 ns | 3.073 ns | 2.566 ns |  6.86 |    0.07 | 0.2022 |     - |     - |     424 B |
|             ValueLinq_SharedPool_Pull |     0 |   100 | 625.83 ns | 3.003 ns | 2.809 ns |  7.27 |    0.06 | 0.2022 |     - |     - |     424 B |
|        ValueLinq_ValueLambda_Standard |     0 |   100 | 243.97 ns | 0.881 ns | 0.824 ns |  2.83 |    0.03 | 0.2027 |     - |     - |     424 B |
|           ValueLinq_ValueLambda_Stack |     0 |   100 | 393.70 ns | 1.905 ns | 1.782 ns |  4.57 |    0.04 | 0.3171 |     - |     - |     664 B |
| ValueLinq_ValueLambda_SharedPool_Push |     0 |   100 | 438.20 ns | 1.988 ns | 1.660 ns |  5.09 |    0.03 | 0.2027 |     - |     - |     424 B |
| ValueLinq_ValueLambda_SharedPool_Pull |     0 |   100 | 471.50 ns | 3.041 ns | 2.845 ns |  5.48 |    0.06 | 0.2022 |     - |     - |     424 B |
|                               ForLoop |     0 |   100 |  86.10 ns | 0.713 ns | 0.595 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|                                  Linq |     0 |   100 | 253.36 ns | 1.573 ns | 1.314 ns |  2.94 |    0.02 | 0.2446 |     - |     - |     512 B |
|                            LinqFaster |     0 |   100 | 286.90 ns | 1.205 ns | 1.127 ns |  3.33 |    0.03 | 0.4053 |     - |     - |     848 B |
|                       LinqFaster_SIMD |     0 |   100 | 105.59 ns | 0.772 ns | 0.684 ns |  1.23 |    0.01 | 0.4054 |     - |     - |     848 B |
|                                LinqAF |     0 |   100 | 791.05 ns | 2.490 ns | 2.208 ns |  9.19 |    0.08 | 0.7534 |     - |     - |    1576 B |
|                            StructLinq |     0 |   100 | 235.10 ns | 0.741 ns | 0.693 ns |  2.73 |    0.02 | 0.2294 |     - |     - |     480 B |
|                  StructLinq_IFunction |     0 |   100 |  95.21 ns | 0.691 ns | 0.613 ns |  1.11 |    0.01 | 0.2027 |     - |     - |     424 B |
|                             Hyperlinq |     0 |   100 | 251.93 ns | 0.973 ns | 0.862 ns |  2.93 |    0.03 | 0.2027 |     - |     - |     424 B |
|                   Hyperlinq_IFunction |     0 |   100 | 115.81 ns | 0.519 ns | 0.460 ns |  1.34 |    0.01 | 0.2027 |     - |     - |     424 B |
|                        Hyperlinq_Pool |     0 |   100 | 290.55 ns | 3.281 ns | 2.740 ns |  3.37 |    0.04 | 0.0267 |     - |     - |      56 B |
|              Hyperlinq_Pool_IFunction |     0 |   100 | 186.43 ns | 0.839 ns | 0.744 ns |  2.16 |    0.01 | 0.0267 |     - |     - |      56 B |
