## Range.RangeSelectToArray

### Source
[RangeSelectToArray.cs](../LinqBenchmarks/Range/RangeSelectToArray.cs)

### References:
- Cistern.ValueLinq: [0.0.11](https://www.nuget.org/packages/Cistern.ValueLinq/0.0.11)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.19.2](https://www.nuget.org/packages/StructLinq.BCL/0.19.2)
- NetFabric.Hyperlinq: [3.0.0-beta27](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta27)

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
|                    ValueLinq_Standard |     0 |   100 | 270.10 ns | 1.920 ns | 1.702 ns |  3.12 |    0.03 | 0.2027 |     - |     - |     424 B |
|                       ValueLinq_Stack |     0 |   100 | 519.78 ns | 2.428 ns | 2.271 ns |  6.00 |    0.04 | 0.3166 |     - |     - |     664 B |
|             ValueLinq_SharedPool_Push |     0 |   100 | 511.38 ns | 1.511 ns | 1.261 ns |  5.90 |    0.03 | 0.2022 |     - |     - |     424 B |
|             ValueLinq_SharedPool_Pull |     0 |   100 | 621.95 ns | 1.907 ns | 1.784 ns |  7.18 |    0.03 | 0.2022 |     - |     - |     424 B |
|        ValueLinq_ValueLambda_Standard |     0 |   100 | 253.24 ns | 0.894 ns | 0.793 ns |  2.92 |    0.01 | 0.2027 |     - |     - |     424 B |
|           ValueLinq_ValueLambda_Stack |     0 |   100 | 362.40 ns | 1.592 ns | 1.412 ns |  4.18 |    0.02 | 0.3171 |     - |     - |     664 B |
| ValueLinq_ValueLambda_SharedPool_Push |     0 |   100 | 435.98 ns | 1.388 ns | 1.159 ns |  5.03 |    0.02 | 0.2027 |     - |     - |     424 B |
| ValueLinq_ValueLambda_SharedPool_Pull |     0 |   100 | 467.77 ns | 1.969 ns | 1.745 ns |  5.40 |    0.03 | 0.2022 |     - |     - |     424 B |
|                               ForLoop |     0 |   100 |  86.64 ns | 0.331 ns | 0.276 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|                                  Linq |     0 |   100 | 246.57 ns | 1.173 ns | 1.097 ns |  2.85 |    0.02 | 0.2446 |     - |     - |     512 B |
|                            LinqFaster |     0 |   100 | 276.92 ns | 1.115 ns | 1.043 ns |  3.20 |    0.02 | 0.4053 |     - |     - |     848 B |
|                                LinqAF |     0 |   100 | 818.36 ns | 4.467 ns | 3.960 ns |  9.45 |    0.06 | 0.7534 |     - |     - |    1576 B |
|                            StructLinq |     0 |   100 | 319.10 ns | 0.853 ns | 0.798 ns |  3.68 |    0.02 | 0.2141 |     - |     - |     448 B |
|                  StructLinq_IFunction |     0 |   100 | 283.42 ns | 1.298 ns | 1.214 ns |  3.27 |    0.02 | 0.2027 |     - |     - |     424 B |
|                             Hyperlinq |     0 |   100 | 219.23 ns | 0.558 ns | 0.466 ns |  2.53 |    0.01 | 0.2027 |     - |     - |     424 B |
|                   Hyperlinq_IFunction |     0 |   100 | 116.26 ns | 0.638 ns | 0.566 ns |  1.34 |    0.01 | 0.2027 |     - |     - |     424 B |
|                        Hyperlinq_Pool |     0 |   100 | 260.70 ns | 1.355 ns | 1.132 ns |  3.01 |    0.01 | 0.0267 |     - |     - |      56 B |
|              Hyperlinq_Pool_IFunction |     0 |   100 | 145.39 ns | 0.442 ns | 0.392 ns |  1.68 |    0.01 | 0.0267 |     - |     - |      56 B |
