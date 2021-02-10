## Range.RangeSelectToArray

### Source
[RangeSelectToArray.cs](../LinqBenchmarks/Range/RangeSelectToArray.cs)

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
|                                Method | Start | Count |      Mean |    Error |    StdDev |    Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |------ |----------:|---------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                    ValueLinq_Standard |     0 |   100 | 269.91 ns | 1.235 ns |  1.095 ns | 270.04 ns |  3.20 |    0.03 | 0.2027 |     - |     - |     424 B |
|                       ValueLinq_Stack |     0 |   100 | 520.76 ns | 1.656 ns |  1.468 ns | 520.61 ns |  6.16 |    0.04 | 0.3166 |     - |     - |     664 B |
|             ValueLinq_SharedPool_Push |     0 |   100 | 575.04 ns | 2.818 ns |  2.353 ns | 574.10 ns |  6.80 |    0.05 | 0.2022 |     - |     - |     424 B |
|             ValueLinq_SharedPool_Pull |     0 |   100 | 592.36 ns | 2.204 ns |  2.062 ns | 591.93 ns |  7.01 |    0.05 | 0.2022 |     - |     - |     424 B |
|        ValueLinq_ValueLambda_Standard |     0 |   100 | 236.56 ns | 0.828 ns |  0.774 ns | 236.48 ns |  2.80 |    0.02 | 0.2027 |     - |     - |     424 B |
|           ValueLinq_ValueLambda_Stack |     0 |   100 | 375.52 ns | 1.292 ns |  1.079 ns | 375.60 ns |  4.44 |    0.03 | 0.3171 |     - |     - |     664 B |
| ValueLinq_ValueLambda_SharedPool_Push |     0 |   100 | 427.54 ns | 1.242 ns |  1.101 ns | 427.61 ns |  5.06 |    0.04 | 0.2027 |     - |     - |     424 B |
| ValueLinq_ValueLambda_SharedPool_Pull |     0 |   100 | 463.39 ns | 3.996 ns |  3.542 ns | 462.13 ns |  5.49 |    0.04 | 0.2027 |     - |     - |     424 B |
|                               ForLoop |     0 |   100 |  84.48 ns | 0.579 ns |  0.513 ns |  84.48 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|                                  Linq |     0 |   100 | 245.98 ns | 1.217 ns |  1.079 ns | 245.79 ns |  2.91 |    0.02 | 0.2446 |     - |     - |     512 B |
|                            LinqFaster |     0 |   100 | 279.74 ns | 1.385 ns |  1.228 ns | 279.98 ns |  3.31 |    0.03 | 0.4053 |     - |     - |     848 B |
|                       LinqFaster_SIMD |     0 |   100 | 103.90 ns | 0.488 ns |  0.432 ns | 103.83 ns |  1.23 |    0.01 | 0.4054 |     - |     - |     848 B |
|                                LinqAF |     0 |   100 | 779.30 ns | 5.757 ns |  5.103 ns | 779.18 ns |  9.23 |    0.09 | 0.7534 |     - |     - |    1576 B |
|                            StructLinq |     0 |   100 | 288.03 ns | 7.651 ns | 21.952 ns | 282.86 ns |  3.21 |    0.15 | 0.2294 |     - |     - |     480 B |
|                  StructLinq_IFunction |     0 |   100 | 118.28 ns | 5.009 ns | 14.770 ns | 112.51 ns |  1.66 |    0.12 | 0.2027 |     - |     - |     424 B |
|                             Hyperlinq |     0 |   100 | 253.17 ns | 4.062 ns |  3.601 ns | 253.62 ns |  3.00 |    0.05 | 0.2027 |     - |     - |     424 B |
|                   Hyperlinq_IFunction |     0 |   100 | 153.28 ns | 2.051 ns |  1.713 ns | 152.87 ns |  1.81 |    0.02 | 0.2027 |     - |     - |     424 B |
|                        Hyperlinq_Pool |     0 |   100 | 264.62 ns | 4.812 ns | 10.662 ns | 259.25 ns |  3.33 |    0.11 | 0.0267 |     - |     - |      56 B |
|              Hyperlinq_Pool_IFunction |     0 |   100 | 154.32 ns | 0.419 ns |  0.372 ns | 154.32 ns |  1.83 |    0.01 | 0.0267 |     - |     - |      56 B |
