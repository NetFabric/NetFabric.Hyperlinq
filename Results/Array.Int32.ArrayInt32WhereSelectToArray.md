## Array.Int32.ArrayInt32WhereSelectToArray

### Source
[ArrayInt32WhereSelectToArray.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelectToArray.cs)

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
|                    ValueLinq_Standard |   100 | 549.8 ns | 1.45 ns | 1.29 ns |  2.51 |    0.01 | 0.1068 |     - |     - |     224 B |
|                       ValueLinq_Stack |   100 | 514.9 ns | 1.59 ns | 1.41 ns |  2.35 |    0.01 | 0.1068 |     - |     - |     224 B |
|             ValueLinq_SharedPool_Push |   100 | 770.1 ns | 2.63 ns | 2.46 ns |  3.52 |    0.02 | 0.1068 |     - |     - |     224 B |
|             ValueLinq_SharedPool_Pull |   100 | 668.5 ns | 2.16 ns | 1.81 ns |  3.06 |    0.02 | 0.1068 |     - |     - |     224 B |
|        ValueLinq_ValueLambda_Standard |   100 | 351.3 ns | 0.73 ns | 0.65 ns |  1.61 |    0.01 | 0.1068 |     - |     - |     224 B |
|           ValueLinq_ValueLambda_Stack |   100 | 323.7 ns | 1.10 ns | 0.92 ns |  1.48 |    0.01 | 0.1068 |     - |     - |     224 B |
| ValueLinq_ValueLambda_SharedPool_Push |   100 | 537.1 ns | 1.14 ns | 1.01 ns |  2.46 |    0.01 | 0.1068 |     - |     - |     224 B |
| ValueLinq_ValueLambda_SharedPool_Pull |   100 | 550.9 ns | 2.21 ns | 1.96 ns |  2.52 |    0.02 | 0.1068 |     - |     - |     224 B |
|                               ForLoop |   100 | 218.6 ns | 1.22 ns | 1.15 ns |  1.00 |    0.00 | 0.4170 |     - |     - |     872 B |
|                           ForeachLoop |   100 | 217.9 ns | 0.64 ns | 0.57 ns |  1.00 |    0.01 | 0.4170 |     - |     - |     872 B |
|                                  Linq |   100 | 550.8 ns | 1.87 ns | 1.56 ns |  2.52 |    0.02 | 0.3710 |     - |     - |     776 B |
|                            LinqFaster |   100 | 334.0 ns | 1.29 ns | 1.14 ns |  1.53 |    0.01 | 0.3095 |     - |     - |     648 B |
|                                LinqAF |   100 | 660.5 ns | 1.62 ns | 1.52 ns |  3.02 |    0.02 | 0.4015 |     - |     - |     840 B |
|                            StructLinq |   100 | 523.7 ns | 1.69 ns | 1.50 ns |  2.40 |    0.01 | 0.1526 |     - |     - |     320 B |
|                  StructLinq_IFunction |   100 | 286.4 ns | 1.33 ns | 1.18 ns |  1.31 |    0.01 | 0.1068 |     - |     - |     224 B |
|                             Hyperlinq |   100 | 639.4 ns | 2.35 ns | 2.08 ns |  2.92 |    0.01 | 0.1068 |     - |     - |     224 B |
|                   Hyperlinq_IFunction |   100 | 385.4 ns | 0.80 ns | 0.75 ns |  1.76 |    0.01 | 0.1068 |     - |     - |     224 B |
|                        Hyperlinq_Pool |   100 | 685.5 ns | 1.86 ns | 1.74 ns |  3.14 |    0.02 | 0.0267 |     - |     - |      56 B |
|              Hyperlinq_Pool_IFunction |   100 | 675.4 ns | 5.50 ns | 4.88 ns |  3.09 |    0.02 | 0.0267 |     - |     - |      56 B |
