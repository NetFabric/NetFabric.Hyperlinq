## Range.RangeSelectToList

### Source
[RangeSelectToList.cs](../LinqBenchmarks/Range/RangeSelectToList.cs)

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
|                                Method | Start | Count |     Mean |   Error |  StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |------ |---------:|--------:|--------:|------:|-------:|------:|------:|----------:|
|                    ValueLinq_Standard |     0 |   100 | 360.9 ns | 0.77 ns | 0.68 ns |  1.21 | 0.2179 |     - |     - |     456 B |
|                       ValueLinq_Stack |     0 |   100 | 715.3 ns | 1.25 ns | 1.11 ns |  2.40 | 0.3319 |     - |     - |     696 B |
|             ValueLinq_SharedPool_Push |     0 |   100 | 605.1 ns | 1.78 ns | 1.48 ns |  2.03 | 0.2174 |     - |     - |     456 B |
|             ValueLinq_SharedPool_Pull |     0 |   100 | 698.5 ns | 1.92 ns | 1.70 ns |  2.34 | 0.2174 |     - |     - |     456 B |
|        ValueLinq_ValueLambda_Standard |     0 |   100 | 305.7 ns | 1.27 ns | 1.06 ns |  1.02 | 0.2179 |     - |     - |     456 B |
|           ValueLinq_ValueLambda_Stack |     0 |   100 | 565.8 ns | 2.47 ns | 2.19 ns |  1.90 | 0.3319 |     - |     - |     696 B |
| ValueLinq_ValueLambda_SharedPool_Push |     0 |   100 | 463.4 ns | 1.40 ns | 1.17 ns |  1.55 | 0.2179 |     - |     - |     456 B |
| ValueLinq_ValueLambda_SharedPool_Pull |     0 |   100 | 571.7 ns | 1.58 ns | 1.48 ns |  1.92 | 0.2174 |     - |     - |     456 B |
|                               ForLoop |     0 |   100 | 298.4 ns | 1.49 ns | 1.32 ns |  1.00 | 0.5660 |     - |     - |    1184 B |
|                           ForeachLoop |     0 |   100 | 674.6 ns | 2.11 ns | 1.87 ns |  2.26 | 0.5922 |     - |     - |    1240 B |
|                                  Linq |     0 |   100 | 283.3 ns | 0.33 ns | 0.26 ns |  0.95 | 0.2599 |     - |     - |     544 B |
|                            LinqFaster |     0 |   100 | 328.9 ns | 1.65 ns | 1.38 ns |  1.10 | 0.6232 |     - |     - |    1304 B |
|                                LinqAF |     0 |   100 | 789.6 ns | 4.06 ns | 3.79 ns |  2.65 | 0.5655 |     - |     - |    1184 B |
|                            StructLinq |     0 |   100 | 239.1 ns | 0.85 ns | 0.79 ns |  0.80 | 0.2446 |     - |     - |     512 B |
|                  StructLinq_IFunction |     0 |   100 | 101.4 ns | 0.44 ns | 0.34 ns |  0.34 | 0.2180 |     - |     - |     456 B |
|                             Hyperlinq |     0 |   100 | 214.6 ns | 1.24 ns | 1.04 ns |  0.72 | 0.2179 |     - |     - |     456 B |
|                   Hyperlinq_IFunction |     0 |   100 | 152.4 ns | 0.47 ns | 0.42 ns |  0.51 | 0.2179 |     - |     - |     456 B |
