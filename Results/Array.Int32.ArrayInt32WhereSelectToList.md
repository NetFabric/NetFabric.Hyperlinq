## Array.Int32.ArrayInt32WhereSelectToList

### Source
[ArrayInt32WhereSelectToList.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelectToList.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta31](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta31)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                                Method | Count |     Mean |   Error |  StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |---------:|--------:|--------:|------:|-------:|------:|------:|----------:|
|                    ValueLinq_Standard |   100 | 567.6 ns | 1.86 ns | 1.74 ns |  2.75 | 0.3090 |     - |     - |     648 B |
|                       ValueLinq_Stack |   100 | 592.9 ns | 1.25 ns | 1.11 ns |  2.87 | 0.1221 |     - |     - |     256 B |
|             ValueLinq_SharedPool_Push |   100 | 924.8 ns | 2.55 ns | 2.39 ns |  4.47 | 0.1221 |     - |     - |     256 B |
|             ValueLinq_SharedPool_Pull |   100 | 811.0 ns | 1.69 ns | 1.50 ns |  3.92 | 0.1221 |     - |     - |     256 B |
|        ValueLinq_ValueLambda_Standard |   100 | 354.2 ns | 1.46 ns | 1.37 ns |  1.71 | 0.3095 |     - |     - |     648 B |
|           ValueLinq_ValueLambda_Stack |   100 | 389.5 ns | 1.01 ns | 0.85 ns |  1.88 | 0.1221 |     - |     - |     256 B |
| ValueLinq_ValueLambda_SharedPool_Push |   100 | 642.2 ns | 2.19 ns | 1.94 ns |  3.11 | 0.1221 |     - |     - |     256 B |
| ValueLinq_ValueLambda_SharedPool_Pull |   100 | 651.0 ns | 2.96 ns | 2.62 ns |  3.15 | 0.1221 |     - |     - |     256 B |
|                               ForLoop |   100 | 206.7 ns | 0.57 ns | 0.48 ns |  1.00 | 0.3097 |     - |     - |     648 B |
|                           ForeachLoop |   100 | 204.8 ns | 1.01 ns | 0.84 ns |  0.99 | 0.3097 |     - |     - |     648 B |
|                                  Linq |   100 | 486.2 ns | 1.49 ns | 1.24 ns |  2.35 | 0.3595 |     - |     - |     752 B |
|                            LinqFaster |   100 | 399.4 ns | 0.93 ns | 0.83 ns |  1.93 | 0.4320 |     - |     - |     904 B |
|                                LinqAF |   100 | 663.6 ns | 2.46 ns | 2.18 ns |  3.21 | 0.3090 |     - |     - |     648 B |
|                            StructLinq |   100 | 538.0 ns | 2.11 ns | 1.76 ns |  2.60 | 0.1678 |     - |     - |     352 B |
|                  StructLinq_IFunction |   100 | 296.1 ns | 1.04 ns | 0.92 ns |  1.43 | 0.1221 |     - |     - |     256 B |
|                             Hyperlinq |   100 | 599.5 ns | 2.07 ns | 1.73 ns |  2.90 | 0.1221 |     - |     - |     256 B |
|                   Hyperlinq_IFunction |   100 | 370.1 ns | 1.30 ns | 1.02 ns |  1.79 | 0.1221 |     - |     - |     256 B |
