## Range.RangeSelectToArray

### Source
[RangeSelectToArray.cs](../LinqBenchmarks/Range/RangeSelectToArray.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta29](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta29)

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
|                    ValueLinq_Standard |     0 |   100 |   374.62 ns |  6.014 ns |  5.331 ns |  4.42 |    0.08 | 0.2027 |     - |     - |     424 B |
|                       ValueLinq_Stack |     0 |   100 |   656.75 ns |  9.917 ns |  8.791 ns |  7.76 |    0.11 | 0.3166 |     - |     - |     664 B |
|             ValueLinq_SharedPool_Push |     0 |   100 |   749.02 ns | 10.103 ns |  9.450 ns |  8.85 |    0.14 | 0.2022 |     - |     - |     424 B |
|             ValueLinq_SharedPool_Pull |     0 |   100 |   787.62 ns | 15.376 ns | 15.101 ns |  9.30 |    0.20 | 0.2022 |     - |     - |     424 B |
|        ValueLinq_ValueLambda_Standard |     0 |   100 |   251.06 ns |  0.925 ns |  0.866 ns |  2.97 |    0.02 | 0.2027 |     - |     - |     424 B |
|           ValueLinq_ValueLambda_Stack |     0 |   100 |   422.81 ns |  2.036 ns |  1.590 ns |  4.99 |    0.03 | 0.3171 |     - |     - |     664 B |
| ValueLinq_ValueLambda_SharedPool_Push |     0 |   100 |   423.06 ns |  1.358 ns |  1.204 ns |  5.00 |    0.03 | 0.2027 |     - |     - |     424 B |
| ValueLinq_ValueLambda_SharedPool_Pull |     0 |   100 |   504.90 ns |  5.997 ns |  5.316 ns |  5.96 |    0.08 | 0.2022 |     - |     - |     424 B |
|                               ForLoop |     0 |   100 |    84.64 ns |  0.550 ns |  0.515 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|                                  Linq |     0 |   100 |   345.27 ns |  5.118 ns |  4.788 ns |  4.08 |    0.06 | 0.2446 |     - |     - |     512 B |
|                            LinqFaster |     0 |   100 |   350.83 ns |  2.515 ns |  2.353 ns |  4.15 |    0.04 | 0.4053 |     - |     - |     848 B |
|                                LinqAF |     0 |   100 | 1,081.54 ns | 11.425 ns | 10.128 ns | 12.77 |    0.11 | 0.7534 |     - |     - |    1576 B |
|                            StructLinq |     0 |   100 |   314.73 ns |  2.817 ns |  2.635 ns |  3.72 |    0.04 | 0.2294 |     - |     - |     480 B |
|                  StructLinq_IFunction |     0 |   100 |    90.55 ns |  0.639 ns |  0.567 ns |  1.07 |    0.01 | 0.2027 |     - |     - |     424 B |
|                             Hyperlinq |     0 |   100 |   309.57 ns |  5.639 ns |  5.275 ns |  3.66 |    0.06 | 0.2027 |     - |     - |     424 B |
|                   Hyperlinq_IFunction |     0 |   100 |   107.64 ns |  0.378 ns |  0.353 ns |  1.27 |    0.01 | 0.2027 |     - |     - |     424 B |
|                        Hyperlinq_Pool |     0 |   100 |   460.87 ns |  9.216 ns | 24.759 ns |  5.49 |    0.22 | 0.0267 |     - |     - |      56 B |
|              Hyperlinq_Pool_IFunction |     0 |   100 |   158.02 ns |  1.471 ns |  1.376 ns |  1.87 |    0.02 | 0.0267 |     - |     - |      56 B |
