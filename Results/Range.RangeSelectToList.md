## Range.RangeSelectToList

### Source
[RangeSelectToList.cs](../LinqBenchmarks/Range/RangeSelectToList.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta35](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta35)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                                Method | Start | Count |     Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |------ |---------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                    ValueLinq_Standard |     0 |   100 | 366.6 ns |  1.69 ns |  1.50 ns |  1.22 |    0.01 | 0.2179 |     - |     - |     456 B |
|                       ValueLinq_Stack |     0 |   100 | 718.1 ns |  1.78 ns |  1.39 ns |  2.38 |    0.01 | 0.3319 |     - |     - |     696 B |
|             ValueLinq_SharedPool_Push |     0 |   100 | 611.9 ns |  2.71 ns |  2.53 ns |  2.03 |    0.01 | 0.2174 |     - |     - |     456 B |
|             ValueLinq_SharedPool_Pull |     0 |   100 | 725.9 ns |  1.57 ns |  1.31 ns |  2.41 |    0.01 | 0.2174 |     - |     - |     456 B |
|        ValueLinq_ValueLambda_Standard |     0 |   100 | 299.6 ns |  1.43 ns |  1.20 ns |  0.99 |    0.00 | 0.2179 |     - |     - |     456 B |
|           ValueLinq_ValueLambda_Stack |     0 |   100 | 568.9 ns |  2.93 ns |  2.44 ns |  1.89 |    0.01 | 0.3319 |     - |     - |     696 B |
| ValueLinq_ValueLambda_SharedPool_Push |     0 |   100 | 451.9 ns |  1.14 ns |  1.01 ns |  1.50 |    0.01 | 0.2179 |     - |     - |     456 B |
| ValueLinq_ValueLambda_SharedPool_Pull |     0 |   100 | 576.5 ns |  1.43 ns |  1.34 ns |  1.91 |    0.01 | 0.2174 |     - |     - |     456 B |
|                               ForLoop |     0 |   100 | 301.4 ns |  1.59 ns |  1.41 ns |  1.00 |    0.00 | 0.5660 |     - |     - |    1184 B |
|                           ForeachLoop |     0 |   100 | 788.3 ns |  2.81 ns |  2.35 ns |  2.61 |    0.01 | 0.5922 |     - |     - |    1240 B |
|                                  Linq |     0 |   100 | 349.1 ns |  1.34 ns |  1.18 ns |  1.16 |    0.01 | 0.2599 |     - |     - |     544 B |
|                            LinqFaster |     0 |   100 | 331.6 ns |  3.23 ns |  2.86 ns |  1.10 |    0.01 | 0.6232 |     - |     - |    1304 B |
|                                LinqAF |     0 |   100 | 805.2 ns | 15.45 ns | 12.90 ns |  2.67 |    0.05 | 0.5655 |     - |     - |    1184 B |
|                            StructLinq |     0 |   100 | 238.3 ns |  0.89 ns |  0.83 ns |  0.79 |    0.00 | 0.2446 |     - |     - |     512 B |
|                  StructLinq_IFunction |     0 |   100 | 102.8 ns |  0.44 ns |  0.41 ns |  0.34 |    0.00 | 0.2180 |     - |     - |     456 B |
|                             Hyperlinq |     0 |   100 | 236.0 ns |  0.78 ns |  0.69 ns |  0.78 |    0.00 | 0.2179 |     - |     - |     456 B |
|                   Hyperlinq_IFunction |     0 |   100 | 122.8 ns |  1.19 ns |  1.12 ns |  0.41 |    0.00 | 0.2179 |     - |     - |     456 B |
