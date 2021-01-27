## Array.Int32.ArrayInt32WhereSelectToList

### Source
[ArrayInt32WhereSelectToList.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelectToList.cs)

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
|                                Method | Count |     Mean |   Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |---------:|--------:|--------:|------:|--------:|-------:|------:|------:|----------:|
|                    ValueLinq_Standard |   100 | 527.7 ns | 1.76 ns | 1.65 ns |  2.23 |    0.01 | 0.3090 |     - |     - |     648 B |
|                       ValueLinq_Stack |   100 | 595.2 ns | 2.40 ns | 2.25 ns |  2.52 |    0.01 | 0.1221 |     - |     - |     256 B |
|             ValueLinq_SharedPool_Push |   100 | 786.8 ns | 1.68 ns | 1.41 ns |  3.33 |    0.01 | 0.1221 |     - |     - |     256 B |
|             ValueLinq_SharedPool_Pull |   100 | 819.2 ns | 2.73 ns | 2.42 ns |  3.47 |    0.02 | 0.1221 |     - |     - |     256 B |
|        ValueLinq_ValueLambda_Standard |   100 | 341.2 ns | 1.15 ns | 0.96 ns |  1.45 |    0.01 | 0.3095 |     - |     - |     648 B |
|           ValueLinq_ValueLambda_Stack |   100 | 370.8 ns | 1.18 ns | 1.05 ns |  1.57 |    0.01 | 0.1221 |     - |     - |     256 B |
| ValueLinq_ValueLambda_SharedPool_Push |   100 | 624.7 ns | 1.68 ns | 1.57 ns |  2.65 |    0.01 | 0.1221 |     - |     - |     256 B |
| ValueLinq_ValueLambda_SharedPool_Pull |   100 | 634.1 ns | 2.71 ns | 2.26 ns |  2.69 |    0.01 | 0.1221 |     - |     - |     256 B |
|                               ForLoop |   100 | 236.1 ns | 1.04 ns | 0.92 ns |  1.00 |    0.00 | 0.3095 |     - |     - |     648 B |
|                           ForeachLoop |   100 | 236.8 ns | 0.95 ns | 0.84 ns |  1.00 |    0.00 | 0.3095 |     - |     - |     648 B |
|                                  Linq |   100 | 498.2 ns | 1.41 ns | 1.25 ns |  2.11 |    0.01 | 0.3595 |     - |     - |     752 B |
|                            LinqFaster |   100 | 385.8 ns | 1.26 ns | 1.12 ns |  1.63 |    0.01 | 0.4320 |     - |     - |     904 B |
|                                LinqAF |   100 | 625.5 ns | 1.64 ns | 1.54 ns |  2.65 |    0.01 | 0.3090 |     - |     - |     648 B |
|                            StructLinq |   100 | 543.8 ns | 1.23 ns | 1.15 ns |  2.30 |    0.01 | 0.1678 |     - |     - |     352 B |
|                  StructLinq_IFunction |   100 | 381.1 ns | 1.54 ns | 1.36 ns |  1.61 |    0.01 | 0.1221 |     - |     - |     256 B |
|                             Hyperlinq |   100 | 591.8 ns | 2.14 ns | 1.90 ns |  2.51 |    0.01 | 0.1564 |     - |     - |     328 B |
|                   Hyperlinq_IFunction |   100 | 372.4 ns | 0.99 ns | 0.83 ns |  1.58 |    0.01 | 0.1564 |     - |     - |     328 B |
