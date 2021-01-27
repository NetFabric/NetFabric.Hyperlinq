## Range.RangeSelectToList

### Source
[RangeSelectToList.cs](../LinqBenchmarks/Range/RangeSelectToList.cs)

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
|                                Method | Start | Count |     Mean |   Error |  StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |------ |---------:|--------:|--------:|------:|-------:|------:|------:|----------:|
|                    ValueLinq_Standard |     0 |   100 | 372.5 ns | 1.80 ns | 1.51 ns |  1.24 | 0.2179 |     - |     - |     456 B |
|                       ValueLinq_Stack |     0 |   100 | 709.9 ns | 3.33 ns | 2.95 ns |  2.37 | 0.3319 |     - |     - |     696 B |
|             ValueLinq_SharedPool_Push |     0 |   100 | 518.1 ns | 1.32 ns | 1.10 ns |  1.73 | 0.2174 |     - |     - |     456 B |
|             ValueLinq_SharedPool_Pull |     0 |   100 | 697.2 ns | 1.81 ns | 1.51 ns |  2.33 | 0.2174 |     - |     - |     456 B |
|        ValueLinq_ValueLambda_Standard |     0 |   100 | 299.4 ns | 0.74 ns | 0.62 ns |  1.00 | 0.2179 |     - |     - |     456 B |
|           ValueLinq_ValueLambda_Stack |     0 |   100 | 560.4 ns | 2.41 ns | 2.14 ns |  1.87 | 0.3319 |     - |     - |     696 B |
| ValueLinq_ValueLambda_SharedPool_Push |     0 |   100 | 453.6 ns | 1.80 ns | 1.50 ns |  1.51 | 0.2179 |     - |     - |     456 B |
| ValueLinq_ValueLambda_SharedPool_Pull |     0 |   100 | 573.2 ns | 1.63 ns | 1.28 ns |  1.91 | 0.2174 |     - |     - |     456 B |
|                               ForLoop |     0 |   100 | 299.7 ns | 1.61 ns | 1.43 ns |  1.00 | 0.5660 |     - |     - |    1184 B |
|                           ForeachLoop |     0 |   100 | 776.9 ns | 3.29 ns | 2.92 ns |  2.59 | 0.5922 |     - |     - |    1240 B |
|                                  Linq |     0 |   100 | 347.4 ns | 1.83 ns | 1.62 ns |  1.16 | 0.2599 |     - |     - |     544 B |
|                            LinqFaster |     0 |   100 | 327.0 ns | 1.07 ns | 0.95 ns |  1.09 | 0.6232 |     - |     - |    1304 B |
|                                LinqAF |     0 |   100 | 791.5 ns | 3.44 ns | 2.69 ns |  2.64 | 0.5655 |     - |     - |    1184 B |
|                            StructLinq |     0 |   100 | 328.2 ns | 1.00 ns | 0.89 ns |  1.10 | 0.2294 |     - |     - |     480 B |
|                  StructLinq_IFunction |     0 |   100 | 297.7 ns | 0.79 ns | 0.66 ns |  0.99 | 0.2179 |     - |     - |     456 B |
|                             Hyperlinq |     0 |   100 | 267.4 ns | 0.96 ns | 0.85 ns |  0.89 | 0.2408 |     - |     - |     504 B |
|                   Hyperlinq_IFunction |     0 |   100 | 137.1 ns | 0.78 ns | 0.69 ns |  0.46 | 0.2408 |     - |     - |     504 B |
