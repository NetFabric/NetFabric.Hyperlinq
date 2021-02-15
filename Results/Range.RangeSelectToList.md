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
|                                Method | Start | Count |     Mean |   Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |------ |---------:|--------:|--------:|------:|--------:|-------:|------:|------:|----------:|
|                    ValueLinq_Standard |     0 |   100 | 387.5 ns | 1.31 ns | 1.02 ns |  1.24 |    0.01 | 0.2179 |     - |     - |     456 B |
|                       ValueLinq_Stack |     0 |   100 | 748.3 ns | 1.90 ns | 1.77 ns |  2.39 |    0.01 | 0.3319 |     - |     - |     696 B |
|             ValueLinq_SharedPool_Push |     0 |   100 | 623.3 ns | 2.28 ns | 1.78 ns |  1.99 |    0.01 | 0.2174 |     - |     - |     456 B |
|             ValueLinq_SharedPool_Pull |     0 |   100 | 741.7 ns | 5.07 ns | 4.49 ns |  2.37 |    0.02 | 0.2174 |     - |     - |     456 B |
|        ValueLinq_ValueLambda_Standard |     0 |   100 | 306.8 ns | 1.44 ns | 1.28 ns |  0.98 |    0.01 | 0.2179 |     - |     - |     456 B |
|           ValueLinq_ValueLambda_Stack |     0 |   100 | 585.2 ns | 2.35 ns | 2.08 ns |  1.87 |    0.01 | 0.3319 |     - |     - |     696 B |
| ValueLinq_ValueLambda_SharedPool_Push |     0 |   100 | 465.9 ns | 2.96 ns | 2.62 ns |  1.49 |    0.01 | 0.2179 |     - |     - |     456 B |
| ValueLinq_ValueLambda_SharedPool_Pull |     0 |   100 | 597.2 ns | 2.99 ns | 2.80 ns |  1.91 |    0.01 | 0.2174 |     - |     - |     456 B |
|                               ForLoop |     0 |   100 | 312.5 ns | 1.53 ns | 1.28 ns |  1.00 |    0.00 | 0.5660 |     - |     - |    1184 B |
|                           ForeachLoop |     0 |   100 | 813.7 ns | 3.02 ns | 2.52 ns |  2.60 |    0.01 | 0.5922 |     - |     - |    1240 B |
|                                  Linq |     0 |   100 | 357.9 ns | 2.50 ns | 2.22 ns |  1.15 |    0.01 | 0.2599 |     - |     - |     544 B |
|                            LinqFaster |     0 |   100 | 342.6 ns | 2.36 ns | 2.10 ns |  1.10 |    0.01 | 0.6232 |     - |     - |    1304 B |
|                                LinqAF |     0 |   100 | 808.5 ns | 3.34 ns | 3.12 ns |  2.59 |    0.02 | 0.5655 |     - |     - |    1184 B |
|                            StructLinq |     0 |   100 | 245.2 ns | 1.24 ns | 1.10 ns |  0.79 |    0.01 | 0.2446 |     - |     - |     512 B |
|                  StructLinq_IFunction |     0 |   100 | 105.9 ns | 0.56 ns | 0.49 ns |  0.34 |    0.00 | 0.2180 |     - |     - |     456 B |
|                             Hyperlinq |     0 |   100 | 264.3 ns | 1.24 ns | 1.16 ns |  0.85 |    0.00 | 0.2179 |     - |     - |     456 B |
|                   Hyperlinq_IFunction |     0 |   100 | 157.1 ns | 1.02 ns | 0.90 ns |  0.50 |    0.00 | 0.2179 |     - |     - |     456 B |
