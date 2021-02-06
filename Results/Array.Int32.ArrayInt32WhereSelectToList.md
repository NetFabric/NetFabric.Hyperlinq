## Array.Int32.ArrayInt32WhereSelectToList

### Source
[ArrayInt32WhereSelectToList.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelectToList.cs)

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
|                                Method | Count |     Mean |   Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |---------:|--------:|--------:|------:|--------:|-------:|------:|------:|----------:|
|                    ValueLinq_Standard |   100 | 575.3 ns | 2.29 ns | 2.03 ns |  2.77 |    0.01 | 0.3090 |     - |     - |     648 B |
|                       ValueLinq_Stack |   100 | 594.0 ns | 1.58 ns | 1.32 ns |  2.85 |    0.01 | 0.1221 |     - |     - |     256 B |
|             ValueLinq_SharedPool_Push |   100 | 933.8 ns | 5.56 ns | 4.64 ns |  4.49 |    0.02 | 0.1221 |     - |     - |     256 B |
|             ValueLinq_SharedPool_Pull |   100 | 828.5 ns | 3.35 ns | 2.80 ns |  3.98 |    0.02 | 0.1221 |     - |     - |     256 B |
|        ValueLinq_ValueLambda_Standard |   100 | 354.1 ns | 1.43 ns | 1.34 ns |  1.70 |    0.01 | 0.3095 |     - |     - |     648 B |
|           ValueLinq_ValueLambda_Stack |   100 | 391.9 ns | 1.42 ns | 1.26 ns |  1.88 |    0.01 | 0.1221 |     - |     - |     256 B |
| ValueLinq_ValueLambda_SharedPool_Push |   100 | 633.5 ns | 3.53 ns | 2.95 ns |  3.04 |    0.02 | 0.1221 |     - |     - |     256 B |
| ValueLinq_ValueLambda_SharedPool_Pull |   100 | 652.5 ns | 1.54 ns | 1.36 ns |  3.14 |    0.01 | 0.1221 |     - |     - |     256 B |
|                               ForLoop |   100 | 207.9 ns | 0.90 ns | 0.84 ns |  1.00 |    0.00 | 0.3097 |     - |     - |     648 B |
|                           ForeachLoop |   100 | 206.8 ns | 0.84 ns | 0.70 ns |  0.99 |    0.01 | 0.3097 |     - |     - |     648 B |
|                                  Linq |   100 | 485.1 ns | 2.73 ns | 2.55 ns |  2.33 |    0.01 | 0.3595 |     - |     - |     752 B |
|                            LinqFaster |   100 | 398.4 ns | 1.38 ns | 1.23 ns |  1.92 |    0.01 | 0.4320 |     - |     - |     904 B |
|                                LinqAF |   100 | 673.5 ns | 2.77 ns | 2.46 ns |  3.24 |    0.02 | 0.3090 |     - |     - |     648 B |
|                            StructLinq |   100 | 544.8 ns | 3.21 ns | 2.68 ns |  2.62 |    0.02 | 0.1678 |     - |     - |     352 B |
|                  StructLinq_IFunction |   100 | 316.7 ns | 0.88 ns | 0.78 ns |  1.52 |    0.01 | 0.1221 |     - |     - |     256 B |
|                             Hyperlinq |   100 | 587.1 ns | 3.14 ns | 2.93 ns |  2.82 |    0.02 | 0.1221 |     - |     - |     256 B |
|                   Hyperlinq_IFunction |   100 | 354.0 ns | 1.44 ns | 1.28 ns |  1.70 |    0.01 | 0.1221 |     - |     - |     256 B |
