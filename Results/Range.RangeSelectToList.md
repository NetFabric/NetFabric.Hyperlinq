## Range.RangeSelectToList

### Source
[RangeSelectToList.cs](../LinqBenchmarks/Range/RangeSelectToList.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta30](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta30)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                                Method | Start | Count |     Mean |   Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |------ |---------:|--------:|--------:|------:|--------:|-------:|------:|------:|----------:|
|                    ValueLinq_Standard |     0 |   100 | 365.0 ns | 1.83 ns | 1.53 ns |  1.09 |    0.01 | 0.2179 |     - |     - |     456 B |
|                       ValueLinq_Stack |     0 |   100 | 710.6 ns | 2.43 ns | 2.15 ns |  2.12 |    0.02 | 0.3319 |     - |     - |     696 B |
|             ValueLinq_SharedPool_Push |     0 |   100 | 605.5 ns | 1.92 ns | 1.70 ns |  1.81 |    0.01 | 0.2174 |     - |     - |     456 B |
|             ValueLinq_SharedPool_Pull |     0 |   100 | 707.9 ns | 1.18 ns | 0.99 ns |  2.11 |    0.01 | 0.2174 |     - |     - |     456 B |
|        ValueLinq_ValueLambda_Standard |     0 |   100 | 295.2 ns | 0.80 ns | 0.67 ns |  0.88 |    0.01 | 0.2179 |     - |     - |     456 B |
|           ValueLinq_ValueLambda_Stack |     0 |   100 | 561.2 ns | 2.64 ns | 2.34 ns |  1.68 |    0.01 | 0.3319 |     - |     - |     696 B |
| ValueLinq_ValueLambda_SharedPool_Push |     0 |   100 | 447.8 ns | 1.17 ns | 1.04 ns |  1.34 |    0.01 | 0.2179 |     - |     - |     456 B |
| ValueLinq_ValueLambda_SharedPool_Pull |     0 |   100 | 592.1 ns | 2.37 ns | 2.21 ns |  1.77 |    0.02 | 0.2174 |     - |     - |     456 B |
|                               ForLoop |     0 |   100 | 334.9 ns | 2.40 ns | 2.25 ns |  1.00 |    0.00 | 0.5660 |     - |     - |    1184 B |
|                           ForeachLoop |     0 |   100 | 782.8 ns | 3.41 ns | 3.03 ns |  2.34 |    0.02 | 0.5922 |     - |     - |    1240 B |
|                                  Linq |     0 |   100 | 311.9 ns | 1.28 ns | 1.07 ns |  0.93 |    0.01 | 0.2599 |     - |     - |     544 B |
|                            LinqFaster |     0 |   100 | 330.8 ns | 2.06 ns | 1.61 ns |  0.99 |    0.01 | 0.6232 |     - |     - |    1304 B |
|                                LinqAF |     0 |   100 | 843.5 ns | 3.08 ns | 2.73 ns |  2.52 |    0.02 | 0.5655 |     - |     - |    1184 B |
|                            StructLinq |     0 |   100 | 213.1 ns | 0.44 ns | 0.39 ns |  0.64 |    0.00 | 0.2446 |     - |     - |     512 B |
|                  StructLinq_IFunction |     0 |   100 | 103.0 ns | 0.40 ns | 0.38 ns |  0.31 |    0.00 | 0.2180 |     - |     - |     456 B |
|                             Hyperlinq |     0 |   100 | 228.0 ns | 0.67 ns | 0.62 ns |  0.68 |    0.00 | 0.2179 |     - |     - |     456 B |
|                   Hyperlinq_IFunction |     0 |   100 | 126.5 ns | 0.22 ns | 0.18 ns |  0.38 |    0.00 | 0.2179 |     - |     - |     456 B |
