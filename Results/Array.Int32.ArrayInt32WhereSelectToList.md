## Array.Int32.ArrayInt32WhereSelectToList

### Source
[ArrayInt32WhereSelectToList.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelectToList.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta35](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta35)

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
|                    ValueLinq_Standard |   100 | 566.0 ns | 1.55 ns | 1.29 ns |  2.77 |    0.03 | 0.3090 |     - |     - |     648 B |
|                       ValueLinq_Stack |   100 | 581.3 ns | 2.51 ns | 2.10 ns |  2.84 |    0.04 | 0.1297 |     - |     - |     272 B |
|             ValueLinq_SharedPool_Push |   100 | 887.8 ns | 2.33 ns | 1.82 ns |  4.35 |    0.05 | 0.1297 |     - |     - |     272 B |
|             ValueLinq_SharedPool_Pull |   100 | 817.7 ns | 1.89 ns | 1.58 ns |  4.00 |    0.05 | 0.1297 |     - |     - |     272 B |
|        ValueLinq_ValueLambda_Standard |   100 | 362.5 ns | 1.26 ns | 1.05 ns |  1.77 |    0.02 | 0.3095 |     - |     - |     648 B |
|           ValueLinq_ValueLambda_Stack |   100 | 394.0 ns | 1.32 ns | 1.17 ns |  1.92 |    0.03 | 0.1297 |     - |     - |     272 B |
| ValueLinq_ValueLambda_SharedPool_Push |   100 | 607.6 ns | 1.78 ns | 1.58 ns |  2.97 |    0.04 | 0.1297 |     - |     - |     272 B |
| ValueLinq_ValueLambda_SharedPool_Pull |   100 | 634.1 ns | 1.88 ns | 1.76 ns |  3.09 |    0.05 | 0.1297 |     - |     - |     272 B |
|                               ForLoop |   100 | 204.9 ns | 1.40 ns | 2.37 ns |  1.00 |    0.00 | 0.3097 |     - |     - |     648 B |
|                           ForeachLoop |   100 | 235.7 ns | 0.78 ns | 0.69 ns |  1.15 |    0.02 | 0.3097 |     - |     - |     648 B |
|                                  Linq |   100 | 454.3 ns | 2.08 ns | 1.85 ns |  2.22 |    0.03 | 0.3595 |     - |     - |     752 B |
|                            LinqFaster |   100 | 441.5 ns | 1.84 ns | 1.63 ns |  2.16 |    0.03 | 0.4473 |     - |     - |     936 B |
|                                LinqAF |   100 | 674.5 ns | 5.81 ns | 5.43 ns |  3.29 |    0.06 | 0.3090 |     - |     - |     648 B |
|                            StructLinq |   100 | 585.2 ns | 1.34 ns | 1.12 ns |  2.86 |    0.03 | 0.1755 |     - |     - |     368 B |
|                  StructLinq_IFunction |   100 | 307.9 ns | 1.73 ns | 1.53 ns |  1.50 |    0.02 | 0.1297 |     - |     - |     272 B |
|                             Hyperlinq |   100 | 596.1 ns | 3.14 ns | 2.63 ns |  2.92 |    0.04 | 0.1297 |     - |     - |     272 B |
|                   Hyperlinq_IFunction |   100 | 353.4 ns | 1.07 ns | 1.00 ns |  1.72 |    0.02 | 0.1297 |     - |     - |     272 B |
