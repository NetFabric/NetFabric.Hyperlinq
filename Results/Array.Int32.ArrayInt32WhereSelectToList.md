## Array.Int32.ArrayInt32WhereSelectToList

### Source
[ArrayInt32WhereSelectToList.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelectToList.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta30](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta30)

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
|                    ValueLinq_Standard |   100 | 556.4 ns | 2.41 ns | 2.13 ns |  2.39 |    0.01 | 0.3090 |     - |     - |     648 B |
|                       ValueLinq_Stack |   100 | 583.7 ns | 1.87 ns | 1.66 ns |  2.51 |    0.01 | 0.1221 |     - |     - |     256 B |
|             ValueLinq_SharedPool_Push |   100 | 869.3 ns | 3.57 ns | 3.17 ns |  3.74 |    0.01 | 0.1221 |     - |     - |     256 B |
|             ValueLinq_SharedPool_Pull |   100 | 819.5 ns | 3.04 ns | 2.69 ns |  3.52 |    0.02 | 0.1221 |     - |     - |     256 B |
|        ValueLinq_ValueLambda_Standard |   100 | 352.8 ns | 1.03 ns | 0.86 ns |  1.52 |    0.00 | 0.3095 |     - |     - |     648 B |
|           ValueLinq_ValueLambda_Stack |   100 | 389.8 ns | 0.89 ns | 0.79 ns |  1.68 |    0.01 | 0.1221 |     - |     - |     256 B |
| ValueLinq_ValueLambda_SharedPool_Push |   100 | 619.7 ns | 2.36 ns | 2.09 ns |  2.66 |    0.01 | 0.1221 |     - |     - |     256 B |
| ValueLinq_ValueLambda_SharedPool_Pull |   100 | 656.2 ns | 3.46 ns | 3.24 ns |  2.82 |    0.02 | 0.1221 |     - |     - |     256 B |
|                               ForLoop |   100 | 232.7 ns | 0.66 ns | 0.58 ns |  1.00 |    0.00 | 0.3097 |     - |     - |     648 B |
|                           ForeachLoop |   100 | 231.9 ns | 0.65 ns | 0.54 ns |  1.00 |    0.00 | 0.3097 |     - |     - |     648 B |
|                                  Linq |   100 | 520.3 ns | 2.22 ns | 1.85 ns |  2.24 |    0.01 | 0.3595 |     - |     - |     752 B |
|                            LinqFaster |   100 | 398.9 ns | 0.90 ns | 0.75 ns |  1.71 |    0.01 | 0.4320 |     - |     - |     904 B |
|                                LinqAF |   100 | 641.6 ns | 1.60 ns | 1.42 ns |  2.76 |    0.01 | 0.3090 |     - |     - |     648 B |
|                            StructLinq |   100 | 535.7 ns | 1.38 ns | 1.15 ns |  2.30 |    0.01 | 0.1678 |     - |     - |     352 B |
|                  StructLinq_IFunction |   100 | 299.9 ns | 0.59 ns | 0.52 ns |  1.29 |    0.00 | 0.1221 |     - |     - |     256 B |
|                             Hyperlinq |   100 | 593.1 ns | 1.89 ns | 1.58 ns |  2.55 |    0.01 | 0.1221 |     - |     - |     256 B |
|                   Hyperlinq_IFunction |   100 | 361.3 ns | 1.23 ns | 1.15 ns |  1.55 |    0.01 | 0.1221 |     - |     - |     256 B |
