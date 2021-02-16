## Array.Int32.ArrayInt32WhereSelectToList

### Source
[ArrayInt32WhereSelectToList.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelectToList.cs)

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
|                                Method | Count |     Mean |   Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |---------:|--------:|--------:|------:|--------:|-------:|------:|------:|----------:|
|                    ValueLinq_Standard |   100 | 498.3 ns | 1.82 ns | 1.52 ns |  2.10 |    0.01 | 0.3090 |     - |     - |     648 B |
|                       ValueLinq_Stack |   100 | 603.6 ns | 1.25 ns | 1.11 ns |  2.54 |    0.01 | 0.1297 |     - |     - |     272 B |
|             ValueLinq_SharedPool_Push |   100 | 886.0 ns | 3.95 ns | 3.50 ns |  3.73 |    0.02 | 0.1297 |     - |     - |     272 B |
|             ValueLinq_SharedPool_Pull |   100 | 948.4 ns | 3.52 ns | 3.29 ns |  4.00 |    0.02 | 0.1297 |     - |     - |     272 B |
|        ValueLinq_ValueLambda_Standard |   100 | 380.8 ns | 1.32 ns | 1.10 ns |  1.60 |    0.01 | 0.3095 |     - |     - |     648 B |
|           ValueLinq_ValueLambda_Stack |   100 | 393.1 ns | 0.45 ns | 0.37 ns |  1.66 |    0.00 | 0.1297 |     - |     - |     272 B |
| ValueLinq_ValueLambda_SharedPool_Push |   100 | 605.3 ns | 2.21 ns | 1.84 ns |  2.55 |    0.01 | 0.1297 |     - |     - |     272 B |
| ValueLinq_ValueLambda_SharedPool_Pull |   100 | 647.2 ns | 2.58 ns | 2.41 ns |  2.73 |    0.01 | 0.1297 |     - |     - |     272 B |
|                               ForLoop |   100 | 237.4 ns | 0.77 ns | 0.64 ns |  1.00 |    0.00 | 0.3095 |     - |     - |     648 B |
|                           ForeachLoop |   100 | 203.6 ns | 0.84 ns | 0.74 ns |  0.86 |    0.00 | 0.3097 |     - |     - |     648 B |
|                                  Linq |   100 | 463.7 ns | 1.03 ns | 0.86 ns |  1.95 |    0.00 | 0.3595 |     - |     - |     752 B |
|                            LinqFaster |   100 | 394.8 ns | 1.99 ns | 1.86 ns |  1.66 |    0.00 | 0.4473 |     - |     - |     936 B |
|                                LinqAF |   100 | 686.7 ns | 1.80 ns | 1.50 ns |  2.89 |    0.01 | 0.3090 |     - |     - |     648 B |
|                            StructLinq |   100 | 515.1 ns | 1.49 ns | 1.39 ns |  2.17 |    0.01 | 0.1755 |     - |     - |     368 B |
|                  StructLinq_IFunction |   100 | 309.3 ns | 1.04 ns | 0.98 ns |  1.30 |    0.00 | 0.1297 |     - |     - |     272 B |
|                             Hyperlinq |   100 | 569.0 ns | 1.66 ns | 1.55 ns |  2.40 |    0.01 | 0.1297 |     - |     - |     272 B |
|                   Hyperlinq_IFunction |   100 | 338.7 ns | 1.12 ns | 0.99 ns |  1.43 |    0.01 | 0.1297 |     - |     - |     272 B |
