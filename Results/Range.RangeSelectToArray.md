## Range.RangeSelectToArray

### Source
[RangeSelectToArray.cs](../LinqBenchmarks/Range/RangeSelectToArray.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta34](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta34)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                                Method | Start | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                    ValueLinq_Standard |     0 |   100 | 291.37 ns | 1.322 ns | 1.172 ns |  3.53 |    0.02 | 0.2027 |     - |     - |     424 B |
|                       ValueLinq_Stack |     0 |   100 | 522.21 ns | 1.901 ns | 1.685 ns |  6.33 |    0.03 | 0.3166 |     - |     - |     664 B |
|             ValueLinq_SharedPool_Push |     0 |   100 | 573.30 ns | 2.205 ns | 1.841 ns |  6.95 |    0.04 | 0.2022 |     - |     - |     424 B |
|             ValueLinq_SharedPool_Pull |     0 |   100 | 595.62 ns | 1.807 ns | 1.602 ns |  7.22 |    0.04 | 0.2022 |     - |     - |     424 B |
|        ValueLinq_ValueLambda_Standard |     0 |   100 | 237.08 ns | 0.643 ns | 0.570 ns |  2.87 |    0.01 | 0.2027 |     - |     - |     424 B |
|           ValueLinq_ValueLambda_Stack |     0 |   100 | 374.84 ns | 0.862 ns | 0.720 ns |  4.55 |    0.02 | 0.3171 |     - |     - |     664 B |
| ValueLinq_ValueLambda_SharedPool_Push |     0 |   100 | 423.24 ns | 1.445 ns | 1.281 ns |  5.13 |    0.02 | 0.2027 |     - |     - |     424 B |
| ValueLinq_ValueLambda_SharedPool_Pull |     0 |   100 | 466.54 ns | 1.121 ns | 0.993 ns |  5.66 |    0.02 | 0.2027 |     - |     - |     424 B |
|                               ForLoop |     0 |   100 |  82.47 ns | 0.369 ns | 0.327 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|                                  Linq |     0 |   100 | 248.66 ns | 0.877 ns | 0.777 ns |  3.02 |    0.02 | 0.2446 |     - |     - |     512 B |
|                            LinqFaster |     0 |   100 | 279.05 ns | 0.656 ns | 0.581 ns |  3.38 |    0.01 | 0.4053 |     - |     - |     848 B |
|                       LinqFaster_SIMD |     0 |   100 |  89.39 ns | 0.325 ns | 0.272 ns |  1.08 |    0.01 | 0.4054 |     - |     - |     848 B |
|                                LinqAF |     0 |   100 | 771.96 ns | 1.809 ns | 1.511 ns |  9.36 |    0.05 | 0.7534 |     - |     - |    1576 B |
|                            StructLinq |     0 |   100 | 228.56 ns | 0.747 ns | 0.624 ns |  2.77 |    0.01 | 0.2294 |     - |     - |     480 B |
|                  StructLinq_IFunction |     0 |   100 |  93.24 ns | 0.571 ns | 0.534 ns |  1.13 |    0.01 | 0.2027 |     - |     - |     424 B |
|                             Hyperlinq |     0 |   100 | 244.57 ns | 0.907 ns | 0.804 ns |  2.97 |    0.02 | 0.2027 |     - |     - |     424 B |
|                   Hyperlinq_IFunction |     0 |   100 | 140.75 ns | 0.706 ns | 0.590 ns |  1.71 |    0.01 | 0.2027 |     - |     - |     424 B |
|                        Hyperlinq_Pool |     0 |   100 | 236.88 ns | 0.811 ns | 0.719 ns |  2.87 |    0.01 | 0.0267 |     - |     - |      56 B |
|              Hyperlinq_Pool_IFunction |     0 |   100 | 149.35 ns | 0.483 ns | 0.428 ns |  1.81 |    0.01 | 0.0267 |     - |     - |      56 B |
