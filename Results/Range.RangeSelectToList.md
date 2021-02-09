## Range.RangeSelectToList

### Source
[RangeSelectToList.cs](../LinqBenchmarks/Range/RangeSelectToList.cs)

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
|                                Method | Start | Count |     Mean |   Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |------ |---------:|--------:|--------:|------:|--------:|-------:|------:|------:|----------:|
|                    ValueLinq_Standard |     0 |   100 | 374.9 ns | 1.33 ns | 1.11 ns |  1.34 |    0.00 | 0.2179 |     - |     - |     456 B |
|                       ValueLinq_Stack |     0 |   100 | 728.4 ns | 2.13 ns | 1.78 ns |  2.61 |    0.01 | 0.3319 |     - |     - |     696 B |
|             ValueLinq_SharedPool_Push |     0 |   100 | 600.0 ns | 1.59 ns | 1.41 ns |  2.15 |    0.01 | 0.2174 |     - |     - |     456 B |
|             ValueLinq_SharedPool_Pull |     0 |   100 | 726.1 ns | 1.47 ns | 1.30 ns |  2.60 |    0.01 | 0.2174 |     - |     - |     456 B |
|        ValueLinq_ValueLambda_Standard |     0 |   100 | 298.8 ns | 1.05 ns | 0.88 ns |  1.07 |    0.00 | 0.2179 |     - |     - |     456 B |
|           ValueLinq_ValueLambda_Stack |     0 |   100 | 568.0 ns | 5.09 ns | 4.25 ns |  2.03 |    0.02 | 0.3319 |     - |     - |     696 B |
| ValueLinq_ValueLambda_SharedPool_Push |     0 |   100 | 450.7 ns | 3.11 ns | 2.76 ns |  1.61 |    0.01 | 0.2179 |     - |     - |     456 B |
| ValueLinq_ValueLambda_SharedPool_Pull |     0 |   100 | 582.4 ns | 3.14 ns | 2.94 ns |  2.09 |    0.01 | 0.2174 |     - |     - |     456 B |
|                               ForLoop |     0 |   100 | 279.4 ns | 0.59 ns | 0.49 ns |  1.00 |    0.00 | 0.5660 |     - |     - |    1184 B |
|                           ForeachLoop |     0 |   100 | 787.8 ns | 3.79 ns | 3.36 ns |  2.82 |    0.02 | 0.5922 |     - |     - |    1240 B |
|                                  Linq |     0 |   100 | 284.8 ns | 1.45 ns | 1.29 ns |  1.02 |    0.00 | 0.2599 |     - |     - |     544 B |
|                            LinqFaster |     0 |   100 | 329.6 ns | 0.72 ns | 0.56 ns |  1.18 |    0.00 | 0.6232 |     - |     - |    1304 B |
|                                LinqAF |     0 |   100 | 790.4 ns | 6.19 ns | 5.49 ns |  2.83 |    0.02 | 0.5655 |     - |     - |    1184 B |
|                            StructLinq |     0 |   100 | 237.8 ns | 0.80 ns | 0.63 ns |  0.85 |    0.00 | 0.2446 |     - |     - |     512 B |
|                  StructLinq_IFunction |     0 |   100 | 102.9 ns | 0.45 ns | 0.40 ns |  0.37 |    0.00 | 0.2180 |     - |     - |     456 B |
|                             Hyperlinq |     0 |   100 | 232.9 ns | 0.44 ns | 0.35 ns |  0.83 |    0.00 | 0.2179 |     - |     - |     456 B |
|                   Hyperlinq_IFunction |     0 |   100 | 121.6 ns | 0.86 ns | 0.72 ns |  0.44 |    0.00 | 0.2179 |     - |     - |     456 B |
