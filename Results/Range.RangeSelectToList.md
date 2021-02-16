## Range.RangeSelectToList

### Source
[RangeSelectToList.cs](../LinqBenchmarks/Range/RangeSelectToList.cs)

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
|                    ValueLinq_Standard |     0 |   100 | 366.87 ns | 1.262 ns | 1.053 ns |  1.32 |    0.01 | 0.2179 |     - |     - |     456 B |
|                       ValueLinq_Stack |     0 |   100 | 726.28 ns | 2.604 ns | 2.436 ns |  2.60 |    0.02 | 0.3319 |     - |     - |     696 B |
|             ValueLinq_SharedPool_Push |     0 |   100 | 614.90 ns | 2.061 ns | 1.928 ns |  2.20 |    0.02 | 0.2174 |     - |     - |     456 B |
|             ValueLinq_SharedPool_Pull |     0 |   100 | 687.98 ns | 1.046 ns | 0.817 ns |  2.47 |    0.02 | 0.2174 |     - |     - |     456 B |
|        ValueLinq_ValueLambda_Standard |     0 |   100 | 293.04 ns | 0.975 ns | 0.864 ns |  1.05 |    0.01 | 0.2179 |     - |     - |     456 B |
|           ValueLinq_ValueLambda_Stack |     0 |   100 | 562.83 ns | 0.795 ns | 0.705 ns |  2.02 |    0.01 | 0.3319 |     - |     - |     696 B |
| ValueLinq_ValueLambda_SharedPool_Push |     0 |   100 | 455.20 ns | 2.214 ns | 1.963 ns |  1.63 |    0.01 | 0.2179 |     - |     - |     456 B |
| ValueLinq_ValueLambda_SharedPool_Pull |     0 |   100 | 578.82 ns | 1.622 ns | 1.517 ns |  2.08 |    0.01 | 0.2174 |     - |     - |     456 B |
|                               ForLoop |     0 |   100 | 278.90 ns | 1.933 ns | 1.808 ns |  1.00 |    0.00 | 0.5660 |     - |     - |    1184 B |
|                           ForeachLoop |     0 |   100 | 709.75 ns | 3.566 ns | 3.161 ns |  2.54 |    0.03 | 0.5922 |     - |     - |    1240 B |
|                                  Linq |     0 |   100 | 329.04 ns | 1.556 ns | 1.380 ns |  1.18 |    0.01 | 0.2599 |     - |     - |     544 B |
|                            LinqFaster |     0 |   100 | 361.28 ns | 1.315 ns | 1.098 ns |  1.30 |    0.01 | 0.6232 |     - |     - |    1304 B |
|                                LinqAF |     0 |   100 | 805.22 ns | 2.810 ns | 2.347 ns |  2.89 |    0.02 | 0.5655 |     - |     - |    1184 B |
|                            StructLinq |     0 |   100 | 237.97 ns | 0.722 ns | 0.603 ns |  0.85 |    0.01 | 0.2446 |     - |     - |     512 B |
|                  StructLinq_IFunction |     0 |   100 | 103.12 ns | 0.722 ns | 0.640 ns |  0.37 |    0.00 | 0.2180 |     - |     - |     456 B |
|                             Hyperlinq |     0 |   100 | 234.15 ns | 0.914 ns | 0.810 ns |  0.84 |    0.01 | 0.2179 |     - |     - |     456 B |
|                   Hyperlinq_IFunction |     0 |   100 | 121.58 ns | 0.638 ns | 0.597 ns |  0.44 |    0.00 | 0.2179 |     - |     - |     456 B |
|                        Hyperlinq_SIMD |     0 |   100 | 105.38 ns | 0.630 ns | 0.559 ns |  0.38 |    0.00 | 0.2180 |     - |     - |     456 B |
|              Hyperlinq_IFunction_SIMD |     0 |   100 |  72.41 ns | 0.463 ns | 0.410 ns |  0.26 |    0.00 | 0.2180 |     - |     - |     456 B |
