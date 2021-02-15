## Range.RangeSelectToList

### Source
[RangeSelectToList.cs](../LinqBenchmarks/Range/RangeSelectToList.cs)

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
|                                Method | Start | Count |      Mean |     Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |------ |----------:|----------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                    ValueLinq_Standard |     0 |   100 | 375.38 ns |  2.374 ns | 2.220 ns |  1.31 |    0.02 | 0.2179 |     - |     - |     456 B |
|                       ValueLinq_Stack |     0 |   100 | 716.52 ns | 10.417 ns | 9.235 ns |  2.49 |    0.04 | 0.3319 |     - |     - |     696 B |
|             ValueLinq_SharedPool_Push |     0 |   100 | 603.50 ns |  3.368 ns | 2.986 ns |  2.10 |    0.03 | 0.2174 |     - |     - |     456 B |
|             ValueLinq_SharedPool_Pull |     0 |   100 | 727.50 ns |  2.718 ns | 2.410 ns |  2.53 |    0.02 | 0.2174 |     - |     - |     456 B |
|        ValueLinq_ValueLambda_Standard |     0 |   100 | 307.42 ns |  2.183 ns | 2.042 ns |  1.07 |    0.02 | 0.2179 |     - |     - |     456 B |
|           ValueLinq_ValueLambda_Stack |     0 |   100 | 577.08 ns |  3.127 ns | 2.772 ns |  2.01 |    0.02 | 0.3319 |     - |     - |     696 B |
| ValueLinq_ValueLambda_SharedPool_Push |     0 |   100 | 458.30 ns |  2.777 ns | 2.319 ns |  1.60 |    0.02 | 0.2179 |     - |     - |     456 B |
| ValueLinq_ValueLambda_SharedPool_Pull |     0 |   100 | 592.05 ns |  1.990 ns | 1.662 ns |  2.06 |    0.02 | 0.2174 |     - |     - |     456 B |
|                               ForLoop |     0 |   100 | 287.61 ns |  3.084 ns | 2.885 ns |  1.00 |    0.00 | 0.5660 |     - |     - |    1184 B |
|                           ForeachLoop |     0 |   100 | 780.82 ns |  2.270 ns | 1.772 ns |  2.72 |    0.03 | 0.5922 |     - |     - |    1240 B |
|                                  Linq |     0 |   100 | 363.05 ns |  1.884 ns | 1.670 ns |  1.26 |    0.01 | 0.2599 |     - |     - |     544 B |
|                            LinqFaster |     0 |   100 | 317.10 ns |  5.550 ns | 4.635 ns |  1.10 |    0.02 | 0.6232 |     - |     - |    1304 B |
|                                LinqAF |     0 |   100 | 787.53 ns |  3.633 ns | 3.033 ns |  2.74 |    0.03 | 0.5655 |     - |     - |    1184 B |
|                            StructLinq |     0 |   100 | 220.56 ns |  2.018 ns | 1.685 ns |  0.77 |    0.01 | 0.2446 |     - |     - |     512 B |
|                  StructLinq_IFunction |     0 |   100 | 111.17 ns |  0.711 ns | 0.630 ns |  0.39 |    0.00 | 0.2180 |     - |     - |     456 B |
|                             Hyperlinq |     0 |   100 | 219.13 ns |  0.904 ns | 0.846 ns |  0.76 |    0.01 | 0.2179 |     - |     - |     456 B |
|                   Hyperlinq_IFunction |     0 |   100 | 155.75 ns |  1.138 ns | 0.950 ns |  0.54 |    0.01 | 0.2179 |     - |     - |     456 B |
|                        Hyperlinq_SIMD |     0 |   100 | 105.71 ns |  0.309 ns | 0.274 ns |  0.37 |    0.00 | 0.2180 |     - |     - |     456 B |
|              Hyperlinq_IFunction_SIMD |     0 |   100 |  72.54 ns |  0.319 ns | 0.299 ns |  0.25 |    0.00 | 0.2180 |     - |     - |     456 B |
