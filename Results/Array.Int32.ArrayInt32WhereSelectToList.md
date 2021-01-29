## Array.Int32.ArrayInt32WhereSelectToList

### Source
[ArrayInt32WhereSelectToList.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelectToList.cs)

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
|                                Method | Count |     Mean |   Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |---------:|--------:|--------:|------:|--------:|-------:|------:|------:|----------:|
|                    ValueLinq_Standard |   100 | 638.7 ns | 3.34 ns | 2.79 ns |  2.40 |    0.02 | 0.3090 |     - |     - |     648 B |
|                       ValueLinq_Stack |   100 | 686.9 ns | 6.12 ns | 5.42 ns |  2.58 |    0.02 | 0.1221 |     - |     - |     256 B |
|             ValueLinq_SharedPool_Push |   100 | 915.9 ns | 3.70 ns | 3.09 ns |  3.44 |    0.01 | 0.1221 |     - |     - |     256 B |
|             ValueLinq_SharedPool_Pull |   100 | 923.8 ns | 4.65 ns | 4.35 ns |  3.47 |    0.02 | 0.1221 |     - |     - |     256 B |
|        ValueLinq_ValueLambda_Standard |   100 | 405.5 ns | 1.83 ns | 1.71 ns |  1.52 |    0.01 | 0.3095 |     - |     - |     648 B |
|           ValueLinq_ValueLambda_Stack |   100 | 426.8 ns | 2.19 ns | 1.83 ns |  1.60 |    0.01 | 0.1221 |     - |     - |     256 B |
| ValueLinq_ValueLambda_SharedPool_Push |   100 | 711.0 ns | 5.06 ns | 4.73 ns |  2.67 |    0.02 | 0.1221 |     - |     - |     256 B |
| ValueLinq_ValueLambda_SharedPool_Pull |   100 | 713.5 ns | 3.45 ns | 3.22 ns |  2.68 |    0.01 | 0.1221 |     - |     - |     256 B |
|                               ForLoop |   100 | 266.2 ns | 1.34 ns | 1.19 ns |  1.00 |    0.00 | 0.3095 |     - |     - |     648 B |
|                           ForeachLoop |   100 | 264.5 ns | 2.60 ns | 2.30 ns |  0.99 |    0.01 | 0.3095 |     - |     - |     648 B |
|                                  Linq |   100 | 581.7 ns | 4.51 ns | 4.00 ns |  2.19 |    0.02 | 0.3595 |     - |     - |     752 B |
|                            LinqFaster |   100 | 451.3 ns | 1.44 ns | 1.27 ns |  1.70 |    0.01 | 0.4320 |     - |     - |     904 B |
|                                LinqAF |   100 | 677.4 ns | 3.87 ns | 3.43 ns |  2.54 |    0.02 | 0.3090 |     - |     - |     648 B |
|                            StructLinq |   100 | 601.8 ns | 5.50 ns | 4.88 ns |  2.26 |    0.02 | 0.1678 |     - |     - |     352 B |
|                  StructLinq_IFunction |   100 | 334.4 ns | 1.70 ns | 1.59 ns |  1.26 |    0.01 | 0.1221 |     - |     - |     256 B |
|                             Hyperlinq |   100 | 704.4 ns | 2.93 ns | 2.75 ns |  2.65 |    0.01 | 0.1564 |     - |     - |     328 B |
|                   Hyperlinq_IFunction |   100 | 412.4 ns | 2.85 ns | 2.53 ns |  1.55 |    0.01 | 0.1564 |     - |     - |     328 B |
