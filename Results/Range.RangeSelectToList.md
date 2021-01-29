## Range.RangeSelectToList

### Source
[RangeSelectToList.cs](../LinqBenchmarks/Range/RangeSelectToList.cs)

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
|                                Method | Start | Count |     Mean |   Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |------ |---------:|--------:|--------:|------:|--------:|-------:|------:|------:|----------:|
|                    ValueLinq_Standard |     0 |   100 | 406.7 ns | 2.56 ns | 2.14 ns |  1.12 |    0.01 | 0.2179 |     - |     - |     456 B |
|                       ValueLinq_Stack |     0 |   100 | 825.7 ns | 4.45 ns | 3.95 ns |  2.27 |    0.02 | 0.3319 |     - |     - |     696 B |
|             ValueLinq_SharedPool_Push |     0 |   100 | 587.2 ns | 3.70 ns | 3.28 ns |  1.61 |    0.01 | 0.2174 |     - |     - |     456 B |
|             ValueLinq_SharedPool_Pull |     0 |   100 | 802.8 ns | 5.53 ns | 5.18 ns |  2.20 |    0.02 | 0.2174 |     - |     - |     456 B |
|        ValueLinq_ValueLambda_Standard |     0 |   100 | 331.2 ns | 1.54 ns | 1.44 ns |  0.91 |    0.01 | 0.2179 |     - |     - |     456 B |
|           ValueLinq_ValueLambda_Stack |     0 |   100 | 632.0 ns | 4.13 ns | 3.86 ns |  1.74 |    0.02 | 0.3319 |     - |     - |     696 B |
| ValueLinq_ValueLambda_SharedPool_Push |     0 |   100 | 498.8 ns | 2.16 ns | 2.02 ns |  1.37 |    0.01 | 0.2174 |     - |     - |     456 B |
| ValueLinq_ValueLambda_SharedPool_Pull |     0 |   100 | 648.5 ns | 3.24 ns | 2.87 ns |  1.78 |    0.02 | 0.2174 |     - |     - |     456 B |
|                               ForLoop |     0 |   100 | 364.2 ns | 2.79 ns | 2.47 ns |  1.00 |    0.00 | 0.5660 |     - |     - |    1184 B |
|                           ForeachLoop |     0 |   100 | 797.6 ns | 2.97 ns | 2.32 ns |  2.19 |    0.02 | 0.5922 |     - |     - |    1240 B |
|                                  Linq |     0 |   100 | 350.2 ns | 1.63 ns | 1.36 ns |  0.96 |    0.01 | 0.2599 |     - |     - |     544 B |
|                            LinqFaster |     0 |   100 | 397.8 ns | 3.57 ns | 3.16 ns |  1.09 |    0.01 | 0.6232 |     - |     - |    1304 B |
|                                LinqAF |     0 |   100 | 891.6 ns | 3.37 ns | 2.82 ns |  2.45 |    0.02 | 0.5655 |     - |     - |    1184 B |
|                            StructLinq |     0 |   100 | 241.5 ns | 1.73 ns | 1.62 ns |  0.66 |    0.00 | 0.2446 |     - |     - |     512 B |
|                  StructLinq_IFunction |     0 |   100 | 122.5 ns | 1.23 ns | 1.09 ns |  0.34 |    0.00 | 0.2179 |     - |     - |     456 B |
|                             Hyperlinq |     0 |   100 | 271.2 ns | 1.02 ns | 0.91 ns |  0.74 |    0.01 | 0.2408 |     - |     - |     504 B |
|                   Hyperlinq_IFunction |     0 |   100 | 130.9 ns | 0.85 ns | 0.76 ns |  0.36 |    0.00 | 0.2408 |     - |     - |     504 B |
