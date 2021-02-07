## Range.RangeSelectToArray

### Source
[RangeSelectToArray.cs](../LinqBenchmarks/Range/RangeSelectToArray.cs)

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
|                                Method | Start | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                    ValueLinq_Standard |     0 |   100 | 334.26 ns | 0.509 ns | 0.476 ns |  4.00 |    0.02 | 0.2027 |     - |     - |     424 B |
|                       ValueLinq_Stack |     0 |   100 | 552.81 ns | 2.140 ns | 2.002 ns |  6.62 |    0.05 | 0.3166 |     - |     - |     664 B |
|             ValueLinq_SharedPool_Push |     0 |   100 | 585.30 ns | 2.059 ns | 1.825 ns |  7.01 |    0.03 | 0.2022 |     - |     - |     424 B |
|             ValueLinq_SharedPool_Pull |     0 |   100 | 609.55 ns | 1.482 ns | 1.314 ns |  7.30 |    0.04 | 0.2022 |     - |     - |     424 B |
|        ValueLinq_ValueLambda_Standard |     0 |   100 | 243.04 ns | 0.672 ns | 0.596 ns |  2.91 |    0.02 | 0.2027 |     - |     - |     424 B |
|           ValueLinq_ValueLambda_Stack |     0 |   100 | 380.36 ns | 1.309 ns | 1.022 ns |  4.56 |    0.03 | 0.3171 |     - |     - |     664 B |
| ValueLinq_ValueLambda_SharedPool_Push |     0 |   100 | 433.32 ns | 1.253 ns | 1.110 ns |  5.19 |    0.03 | 0.2027 |     - |     - |     424 B |
| ValueLinq_ValueLambda_SharedPool_Pull |     0 |   100 | 464.99 ns | 1.449 ns | 1.355 ns |  5.57 |    0.03 | 0.2027 |     - |     - |     424 B |
|                               ForLoop |     0 |   100 |  83.47 ns | 0.469 ns | 0.416 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|                                  Linq |     0 |   100 | 247.32 ns | 0.522 ns | 0.462 ns |  2.96 |    0.02 | 0.2446 |     - |     - |     512 B |
|                            LinqFaster |     0 |   100 | 276.58 ns | 0.977 ns | 0.816 ns |  3.31 |    0.02 | 0.4053 |     - |     - |     848 B |
|                       LinqFaster_SIMD |     0 |   100 |  91.78 ns | 0.415 ns | 0.346 ns |  1.10 |    0.01 | 0.4054 |     - |     - |     848 B |
|                                LinqAF |     0 |   100 | 798.55 ns | 2.581 ns | 2.288 ns |  9.57 |    0.06 | 0.7534 |     - |     - |    1576 B |
|                            StructLinq |     0 |   100 | 205.01 ns | 0.470 ns | 0.439 ns |  2.46 |    0.01 | 0.2294 |     - |     - |     480 B |
|                  StructLinq_IFunction |     0 |   100 |  92.42 ns | 0.317 ns | 0.281 ns |  1.11 |    0.01 | 0.2027 |     - |     - |     424 B |
|                             Hyperlinq |     0 |   100 | 197.30 ns | 0.613 ns | 0.543 ns |  2.36 |    0.01 | 0.2027 |     - |     - |     424 B |
|                   Hyperlinq_IFunction |     0 |   100 | 139.27 ns | 0.617 ns | 0.577 ns |  1.67 |    0.01 | 0.2027 |     - |     - |     424 B |
|                        Hyperlinq_Pool |     0 |   100 | 231.08 ns | 0.512 ns | 0.454 ns |  2.77 |    0.01 | 0.0267 |     - |     - |      56 B |
|              Hyperlinq_Pool_IFunction |     0 |   100 | 184.40 ns | 0.688 ns | 0.643 ns |  2.21 |    0.02 | 0.0267 |     - |     - |      56 B |
