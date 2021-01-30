## Array.Int32.ArrayInt32WhereSelectToList

### Source
[ArrayInt32WhereSelectToList.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelectToList.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta29](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta29)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                                Method | Count |     Mean |   Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |---------:|--------:|--------:|------:|--------:|-------:|------:|------:|----------:|
|                    ValueLinq_Standard |   100 | 567.2 ns | 0.97 ns | 0.81 ns |  2.76 |    0.02 | 0.3090 |     - |     - |     648 B |
|                       ValueLinq_Stack |   100 | 594.1 ns | 1.38 ns | 1.23 ns |  2.89 |    0.02 | 0.1221 |     - |     - |     256 B |
|             ValueLinq_SharedPool_Push |   100 | 931.0 ns | 2.56 ns | 2.27 ns |  4.53 |    0.03 | 0.1221 |     - |     - |     256 B |
|             ValueLinq_SharedPool_Pull |   100 | 830.8 ns | 1.62 ns | 1.44 ns |  4.04 |    0.03 | 0.1221 |     - |     - |     256 B |
|        ValueLinq_ValueLambda_Standard |   100 | 350.3 ns | 1.86 ns | 1.55 ns |  1.71 |    0.02 | 0.3095 |     - |     - |     648 B |
|           ValueLinq_ValueLambda_Stack |   100 | 390.0 ns | 1.09 ns | 0.91 ns |  1.90 |    0.01 | 0.1221 |     - |     - |     256 B |
| ValueLinq_ValueLambda_SharedPool_Push |   100 | 647.5 ns | 2.21 ns | 1.96 ns |  3.15 |    0.02 | 0.1221 |     - |     - |     256 B |
| ValueLinq_ValueLambda_SharedPool_Pull |   100 | 661.5 ns | 2.14 ns | 2.00 ns |  3.22 |    0.03 | 0.1221 |     - |     - |     256 B |
|                               ForLoop |   100 | 205.5 ns | 1.49 ns | 1.39 ns |  1.00 |    0.00 | 0.3097 |     - |     - |     648 B |
|                           ForeachLoop |   100 | 206.8 ns | 1.19 ns | 1.12 ns |  1.01 |    0.01 | 0.3097 |     - |     - |     648 B |
|                                  Linq |   100 | 488.6 ns | 1.62 ns | 1.52 ns |  2.38 |    0.02 | 0.3595 |     - |     - |     752 B |
|                            LinqFaster |   100 | 396.3 ns | 1.50 ns | 1.40 ns |  1.93 |    0.01 | 0.4320 |     - |     - |     904 B |
|                                LinqAF |   100 | 646.9 ns | 2.46 ns | 2.18 ns |  3.15 |    0.02 | 0.3090 |     - |     - |     648 B |
|                            StructLinq |   100 | 550.5 ns | 2.41 ns | 2.14 ns |  2.68 |    0.03 | 0.1678 |     - |     - |     352 B |
|                  StructLinq_IFunction |   100 | 293.1 ns | 1.18 ns | 1.04 ns |  1.43 |    0.01 | 0.1221 |     - |     - |     256 B |
|                             Hyperlinq |   100 | 679.4 ns | 1.83 ns | 1.62 ns |  3.31 |    0.03 | 0.1564 |     - |     - |     328 B |
|                   Hyperlinq_IFunction |   100 | 394.9 ns | 4.25 ns | 3.77 ns |  1.92 |    0.02 | 0.1564 |     - |     - |     328 B |
