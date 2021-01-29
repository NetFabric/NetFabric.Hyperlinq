## Range.RangeSelectToArray

### Source
[RangeSelectToArray.cs](../LinqBenchmarks/Range/RangeSelectToArray.cs)

### References:
- Cistern.ValueLinq: [0.0.11](https://www.nuget.org/packages/Cistern.ValueLinq/0.0.11)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta28](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta28)

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
|                    ValueLinq_Standard |     0 |   100 | 373.55 ns | 2.732 ns | 2.422 ns |  3.85 |    0.04 | 0.2027 |     - |     - |     424 B |
|                       ValueLinq_Stack |     0 |   100 | 609.26 ns | 3.133 ns | 2.778 ns |  6.28 |    0.04 | 0.3166 |     - |     - |     664 B |
|             ValueLinq_SharedPool_Push |     0 |   100 | 569.11 ns | 2.153 ns | 1.798 ns |  5.87 |    0.03 | 0.2022 |     - |     - |     424 B |
|             ValueLinq_SharedPool_Pull |     0 |   100 | 657.92 ns | 4.672 ns | 4.141 ns |  6.78 |    0.05 | 0.2022 |     - |     - |     424 B |
|        ValueLinq_ValueLambda_Standard |     0 |   100 | 292.81 ns | 1.994 ns | 1.865 ns |  3.02 |    0.02 | 0.2027 |     - |     - |     424 B |
|           ValueLinq_ValueLambda_Stack |     0 |   100 | 411.00 ns | 2.687 ns | 2.513 ns |  4.24 |    0.04 | 0.3171 |     - |     - |     664 B |
| ValueLinq_ValueLambda_SharedPool_Push |     0 |   100 | 485.31 ns | 2.055 ns | 1.922 ns |  5.00 |    0.03 | 0.2022 |     - |     - |     424 B |
| ValueLinq_ValueLambda_SharedPool_Pull |     0 |   100 | 543.43 ns | 2.790 ns | 2.473 ns |  5.60 |    0.04 | 0.2022 |     - |     - |     424 B |
|                               ForLoop |     0 |   100 |  97.04 ns | 0.484 ns | 0.452 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|                                  Linq |     0 |   100 | 274.71 ns | 1.559 ns | 1.382 ns |  2.83 |    0.02 | 0.2446 |     - |     - |     512 B |
|                            LinqFaster |     0 |   100 | 312.10 ns | 1.791 ns | 1.675 ns |  3.22 |    0.03 | 0.4053 |     - |     - |     848 B |
|                                LinqAF |     0 |   100 | 884.45 ns | 6.654 ns | 6.225 ns |  9.11 |    0.08 | 0.7534 |     - |     - |    1576 B |
|                            StructLinq |     0 |   100 | 256.18 ns | 1.554 ns | 1.378 ns |  2.64 |    0.02 | 0.2294 |     - |     - |     480 B |
|                  StructLinq_IFunction |     0 |   100 | 106.08 ns | 1.026 ns | 0.960 ns |  1.09 |    0.01 | 0.2027 |     - |     - |     424 B |
|                             Hyperlinq |     0 |   100 | 264.52 ns | 2.114 ns | 1.874 ns |  2.73 |    0.02 | 0.2027 |     - |     - |     424 B |
|                   Hyperlinq_IFunction |     0 |   100 | 114.42 ns | 0.996 ns | 0.883 ns |  1.18 |    0.01 | 0.2027 |     - |     - |     424 B |
|                        Hyperlinq_Pool |     0 |   100 | 286.82 ns | 1.464 ns | 1.369 ns |  2.96 |    0.01 | 0.0267 |     - |     - |      56 B |
|              Hyperlinq_Pool_IFunction |     0 |   100 | 165.68 ns | 0.783 ns | 0.694 ns |  1.71 |    0.01 | 0.0267 |     - |     - |      56 B |
