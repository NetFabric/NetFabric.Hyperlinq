## Range.RangeSelectToArray

### Source
[RangeSelectToArray.cs](../LinqBenchmarks/Range/RangeSelectToArray.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
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
|                    ValueLinq_Standard |     0 |   100 |   340.21 ns |  5.006 ns |  4.683 ns |  4.11 |    0.05 | 0.2027 |     - |     - |     424 B |
|                       ValueLinq_Stack |     0 |   100 |   625.64 ns |  6.215 ns |  5.190 ns |  7.54 |    0.10 | 0.3166 |     - |     - |     664 B |
|             ValueLinq_SharedPool_Push |     0 |   100 |   673.73 ns | 10.032 ns |  9.384 ns |  8.12 |    0.14 | 0.2022 |     - |     - |     424 B |
|             ValueLinq_SharedPool_Pull |     0 |   100 |   726.20 ns | 12.032 ns | 10.048 ns |  8.75 |    0.13 | 0.2022 |     - |     - |     424 B |
|        ValueLinq_ValueLambda_Standard |     0 |   100 |   252.64 ns |  1.655 ns |  1.382 ns |  3.05 |    0.02 | 0.2027 |     - |     - |     424 B |
|           ValueLinq_ValueLambda_Stack |     0 |   100 |   415.49 ns |  1.490 ns |  1.163 ns |  5.01 |    0.03 | 0.3171 |     - |     - |     664 B |
| ValueLinq_ValueLambda_SharedPool_Push |     0 |   100 |   432.34 ns |  1.401 ns |  1.094 ns |  5.21 |    0.04 | 0.2027 |     - |     - |     424 B |
| ValueLinq_ValueLambda_SharedPool_Pull |     0 |   100 |   495.81 ns |  2.367 ns |  2.214 ns |  5.97 |    0.04 | 0.2022 |     - |     - |     424 B |
|                               ForLoop |     0 |   100 |    82.95 ns |  0.497 ns |  0.415 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|                                  Linq |     0 |   100 |   330.19 ns |  5.828 ns |  4.866 ns |  3.98 |    0.06 | 0.2446 |     - |     - |     512 B |
|                            LinqFaster |     0 |   100 |   342.70 ns |  1.731 ns |  1.619 ns |  4.13 |    0.02 | 0.4053 |     - |     - |     848 B |
|                       LinqFaster_SIMD |     0 |   100 |    97.47 ns |  0.754 ns |  0.705 ns |  1.17 |    0.01 | 0.4054 |     - |     - |     848 B |
|                                LinqAF |     0 |   100 | 1,051.50 ns | 12.604 ns | 11.790 ns | 12.68 |    0.19 | 0.7534 |     - |     - |    1576 B |
|                            StructLinq |     0 |   100 |   299.05 ns |  2.598 ns |  2.303 ns |  3.61 |    0.03 | 0.2294 |     - |     - |     480 B |
|                  StructLinq_IFunction |     0 |   100 |    93.38 ns |  0.251 ns |  0.235 ns |  1.13 |    0.01 | 0.2027 |     - |     - |     424 B |
|                             Hyperlinq |     0 |   100 |   322.55 ns |  3.424 ns |  2.859 ns |  3.89 |    0.04 | 0.2027 |     - |     - |     424 B |
|                   Hyperlinq_IFunction |     0 |   100 |   110.61 ns |  0.403 ns |  0.357 ns |  1.33 |    0.01 | 0.2027 |     - |     - |     424 B |
|                        Hyperlinq_Pool |     0 |   100 |   439.13 ns |  8.598 ns | 16.150 ns |  5.33 |    0.21 | 0.0267 |     - |     - |      56 B |
|              Hyperlinq_Pool_IFunction |     0 |   100 |   191.55 ns |  1.357 ns |  1.269 ns |  2.31 |    0.02 | 0.0267 |     - |     - |      56 B |
