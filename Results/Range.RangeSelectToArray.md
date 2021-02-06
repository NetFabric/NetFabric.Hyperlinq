## Range.RangeSelectToArray

### Source
[RangeSelectToArray.cs](../LinqBenchmarks/Range/RangeSelectToArray.cs)

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
|                                Method | Start | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                    ValueLinq_Standard |     0 |   100 |   375.77 ns |  4.417 ns |  4.132 ns |  4.55 |    0.06 | 0.2027 |     - |     - |     424 B |
|                       ValueLinq_Stack |     0 |   100 |   654.60 ns |  5.699 ns |  5.052 ns |  7.92 |    0.06 | 0.3166 |     - |     - |     664 B |
|             ValueLinq_SharedPool_Push |     0 |   100 |   721.89 ns | 12.037 ns | 11.260 ns |  8.72 |    0.12 | 0.2022 |     - |     - |     424 B |
|             ValueLinq_SharedPool_Pull |     0 |   100 |   808.11 ns | 15.841 ns | 14.818 ns |  9.80 |    0.19 | 0.2022 |     - |     - |     424 B |
|        ValueLinq_ValueLambda_Standard |     0 |   100 |   251.39 ns |  1.063 ns |  0.942 ns |  3.04 |    0.02 | 0.2027 |     - |     - |     424 B |
|           ValueLinq_ValueLambda_Stack |     0 |   100 |   421.10 ns |  2.933 ns |  2.743 ns |  5.09 |    0.03 | 0.3171 |     - |     - |     664 B |
| ValueLinq_ValueLambda_SharedPool_Push |     0 |   100 |   425.71 ns |  1.799 ns |  1.682 ns |  5.15 |    0.03 | 0.2027 |     - |     - |     424 B |
| ValueLinq_ValueLambda_SharedPool_Pull |     0 |   100 |   495.26 ns |  2.419 ns |  2.263 ns |  5.99 |    0.03 | 0.2022 |     - |     - |     424 B |
|                               ForLoop |     0 |   100 |    82.68 ns |  0.544 ns |  0.455 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|                                  Linq |     0 |   100 |   339.43 ns |  5.545 ns |  5.187 ns |  4.10 |    0.06 | 0.2446 |     - |     - |     512 B |
|                            LinqFaster |     0 |   100 |   355.06 ns |  3.863 ns |  3.226 ns |  4.29 |    0.05 | 0.4053 |     - |     - |     848 B |
|                                LinqAF |     0 |   100 | 1,089.25 ns | 18.589 ns | 17.388 ns | 13.20 |    0.24 | 0.7534 |     - |     - |    1576 B |
|                            StructLinq |     0 |   100 |   311.05 ns |  2.685 ns |  2.380 ns |  3.76 |    0.03 | 0.2294 |     - |     - |     480 B |
|                  StructLinq_IFunction |     0 |   100 |    92.61 ns |  0.365 ns |  0.324 ns |  1.12 |    0.01 | 0.2027 |     - |     - |     424 B |
|                             Hyperlinq |     0 |   100 |   307.98 ns |  4.411 ns |  4.126 ns |  3.72 |    0.05 | 0.2027 |     - |     - |     424 B |
|                   Hyperlinq_IFunction |     0 |   100 |   111.82 ns |  0.474 ns |  0.396 ns |  1.35 |    0.01 | 0.2027 |     - |     - |     424 B |
|                        Hyperlinq_Pool |     0 |   100 |   471.05 ns |  9.454 ns | 16.308 ns |  5.69 |    0.21 | 0.0267 |     - |     - |      56 B |
|              Hyperlinq_Pool_IFunction |     0 |   100 |   191.10 ns |  0.702 ns |  0.657 ns |  2.31 |    0.02 | 0.0267 |     - |     - |      56 B |
