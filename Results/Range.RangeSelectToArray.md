## Range.RangeSelectToArray

### Source
[RangeSelectToArray.cs](../LinqBenchmarks/Range/RangeSelectToArray.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta37](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta37)

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
|                    ValueLinq_Standard |     0 |   100 | 289.84 ns | 0.664 ns | 0.588 ns |  3.37 |    0.02 | 0.2027 |     - |     - |     424 B |
|                       ValueLinq_Stack |     0 |   100 | 516.74 ns | 3.760 ns | 3.333 ns |  6.00 |    0.05 | 0.3166 |     - |     - |     664 B |
|             ValueLinq_SharedPool_Push |     0 |   100 | 574.20 ns | 1.449 ns | 1.355 ns |  6.67 |    0.04 | 0.2022 |     - |     - |     424 B |
|             ValueLinq_SharedPool_Pull |     0 |   100 | 591.14 ns | 0.966 ns | 0.856 ns |  6.87 |    0.04 | 0.2022 |     - |     - |     424 B |
|        ValueLinq_ValueLambda_Standard |     0 |   100 | 246.81 ns | 0.762 ns | 0.713 ns |  2.87 |    0.02 | 0.2027 |     - |     - |     424 B |
|           ValueLinq_ValueLambda_Stack |     0 |   100 | 388.39 ns | 1.770 ns | 1.478 ns |  4.51 |    0.03 | 0.3171 |     - |     - |     664 B |
| ValueLinq_ValueLambda_SharedPool_Push |     0 |   100 | 432.07 ns | 1.221 ns | 1.019 ns |  5.02 |    0.02 | 0.2027 |     - |     - |     424 B |
| ValueLinq_ValueLambda_SharedPool_Pull |     0 |   100 | 464.79 ns | 1.695 ns | 1.503 ns |  5.40 |    0.03 | 0.2027 |     - |     - |     424 B |
|                               ForLoop |     0 |   100 |  86.10 ns | 0.518 ns | 0.432 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|                                  Linq |     0 |   100 | 250.90 ns | 1.203 ns | 1.066 ns |  2.92 |    0.02 | 0.2446 |     - |     - |     512 B |
|                            LinqFaster |     0 |   100 | 278.51 ns | 0.902 ns | 0.754 ns |  3.23 |    0.02 | 0.4053 |     - |     - |     848 B |
|                       LinqFaster_SIMD |     0 |   100 | 100.45 ns | 0.487 ns | 0.381 ns |  1.17 |    0.01 | 0.4054 |     - |     - |     848 B |
|                                LinqAF |     0 |   100 | 775.25 ns | 3.221 ns | 2.856 ns |  9.01 |    0.05 | 0.7534 |     - |     - |    1576 B |
|                            StructLinq |     0 |   100 | 228.21 ns | 0.767 ns | 0.680 ns |  2.65 |    0.02 | 0.2294 |     - |     - |     480 B |
|                  StructLinq_IFunction |     0 |   100 |  93.26 ns | 0.205 ns | 0.182 ns |  1.08 |    0.01 | 0.2027 |     - |     - |     424 B |
|                             Hyperlinq |     0 |   100 | 196.97 ns | 0.786 ns | 0.697 ns |  2.29 |    0.02 | 0.2027 |     - |     - |     424 B |
|                   Hyperlinq_IFunction |     0 |   100 | 144.19 ns | 0.697 ns | 0.652 ns |  1.67 |    0.01 | 0.2027 |     - |     - |     424 B |
|                        Hyperlinq_Pool |     0 |   100 | 262.31 ns | 0.944 ns | 0.788 ns |  3.05 |    0.02 | 0.0267 |     - |     - |      56 B |
|              Hyperlinq_Pool_IFunction |     0 |   100 | 184.71 ns | 0.464 ns | 0.388 ns |  2.15 |    0.01 | 0.0267 |     - |     - |      56 B |
|                        Hyperlinq_SIMD |     0 |   100 |  95.41 ns | 0.629 ns | 0.525 ns |  1.11 |    0.01 | 0.2027 |     - |     - |     424 B |
|              Hyperlinq_IFunction_SIMD |     0 |   100 |  63.19 ns | 0.238 ns | 0.211 ns |  0.73 |    0.00 | 0.2027 |     - |     - |     424 B |
|                   Hyperlinq_Pool_SIMD |     0 |   100 | 130.49 ns | 0.466 ns | 0.436 ns |  1.52 |    0.01 | 0.0267 |     - |     - |      56 B |
|         Hyperlinq_Pool_IFunction_SIMD |     0 |   100 |  92.34 ns | 0.299 ns | 0.250 ns |  1.07 |    0.01 | 0.0267 |     - |     - |      56 B |
