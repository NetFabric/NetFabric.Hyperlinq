## Range.RangeSelectToList

### Source
[RangeSelectToList.cs](../LinqBenchmarks/Range/RangeSelectToList.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta32](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta32)

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
|                    ValueLinq_Standard |     0 |   100 | 358.7 ns | 0.84 ns | 0.70 ns |  1.23 |    0.01 | 0.2179 |     - |     - |     456 B |
|                       ValueLinq_Stack |     0 |   100 | 722.4 ns | 2.95 ns | 2.61 ns |  2.48 |    0.01 | 0.3319 |     - |     - |     696 B |
|             ValueLinq_SharedPool_Push |     0 |   100 | 593.6 ns | 2.23 ns | 1.97 ns |  2.04 |    0.01 | 0.2174 |     - |     - |     456 B |
|             ValueLinq_SharedPool_Pull |     0 |   100 | 694.6 ns | 1.22 ns | 1.08 ns |  2.39 |    0.01 | 0.2174 |     - |     - |     456 B |
|        ValueLinq_ValueLambda_Standard |     0 |   100 | 298.2 ns | 1.86 ns | 1.65 ns |  1.02 |    0.01 | 0.2179 |     - |     - |     456 B |
|           ValueLinq_ValueLambda_Stack |     0 |   100 | 567.9 ns | 2.05 ns | 1.92 ns |  1.95 |    0.01 | 0.3319 |     - |     - |     696 B |
| ValueLinq_ValueLambda_SharedPool_Push |     0 |   100 | 446.7 ns | 1.07 ns | 0.94 ns |  1.53 |    0.01 | 0.2179 |     - |     - |     456 B |
| ValueLinq_ValueLambda_SharedPool_Pull |     0 |   100 | 595.7 ns | 1.75 ns | 1.36 ns |  2.05 |    0.01 | 0.2174 |     - |     - |     456 B |
|                               ForLoop |     0 |   100 | 291.3 ns | 1.39 ns | 1.16 ns |  1.00 |    0.00 | 0.5660 |     - |     - |    1184 B |
|                           ForeachLoop |     0 |   100 | 772.4 ns | 5.94 ns | 5.26 ns |  2.65 |    0.02 | 0.5922 |     - |     - |    1240 B |
|                                  Linq |     0 |   100 | 328.9 ns | 1.13 ns | 1.00 ns |  1.13 |    0.01 | 0.2599 |     - |     - |     544 B |
|                            LinqFaster |     0 |   100 | 314.6 ns | 1.37 ns | 1.28 ns |  1.08 |    0.01 | 0.6232 |     - |     - |    1304 B |
|                                LinqAF |     0 |   100 | 787.2 ns | 3.70 ns | 3.28 ns |  2.70 |    0.02 | 0.5655 |     - |     - |    1184 B |
|                            StructLinq |     0 |   100 | 212.9 ns | 0.95 ns | 0.79 ns |  0.73 |    0.00 | 0.2446 |     - |     - |     512 B |
|                  StructLinq_IFunction |     0 |   100 | 107.1 ns | 0.52 ns | 0.46 ns |  0.37 |    0.00 | 0.2180 |     - |     - |     456 B |
|                             Hyperlinq |     0 |   100 | 212.3 ns | 0.73 ns | 0.65 ns |  0.73 |    0.00 | 0.2179 |     - |     - |     456 B |
|                   Hyperlinq_IFunction |     0 |   100 | 152.6 ns | 0.56 ns | 0.50 ns |  0.52 |    0.00 | 0.2179 |     - |     - |     456 B |
