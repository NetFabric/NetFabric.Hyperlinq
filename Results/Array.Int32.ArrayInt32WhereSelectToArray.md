## Array.Int32.ArrayInt32WhereSelectToArray

### Source
[ArrayInt32WhereSelectToArray.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelectToArray.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta34](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta34)

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
|                    ValueLinq_Standard |   100 | 534.3 ns | 1.73 ns | 1.54 ns |  2.05 |    0.01 | 0.1144 |     - |     - |     240 B |
|                       ValueLinq_Stack |   100 | 487.8 ns | 1.20 ns | 1.06 ns |  1.87 |    0.01 | 0.1144 |     - |     - |     240 B |
|             ValueLinq_SharedPool_Push |   100 | 807.9 ns | 2.97 ns | 2.78 ns |  3.10 |    0.01 | 0.1144 |     - |     - |     240 B |
|             ValueLinq_SharedPool_Pull |   100 | 683.4 ns | 1.92 ns | 1.79 ns |  2.62 |    0.01 | 0.1144 |     - |     - |     240 B |
|        ValueLinq_ValueLambda_Standard |   100 | 353.6 ns | 1.67 ns | 1.40 ns |  1.35 |    0.01 | 0.1144 |     - |     - |     240 B |
|           ValueLinq_ValueLambda_Stack |   100 | 361.0 ns | 0.79 ns | 0.62 ns |  1.38 |    0.00 | 0.1144 |     - |     - |     240 B |
| ValueLinq_ValueLambda_SharedPool_Push |   100 | 503.9 ns | 1.43 ns | 1.34 ns |  1.93 |    0.01 | 0.1144 |     - |     - |     240 B |
| ValueLinq_ValueLambda_SharedPool_Pull |   100 | 532.0 ns | 2.36 ns | 2.21 ns |  2.04 |    0.01 | 0.1144 |     - |     - |     240 B |
|                               ForLoop |   100 | 260.9 ns | 0.89 ns | 0.83 ns |  1.00 |    0.00 | 0.4244 |     - |     - |     888 B |
|                           ForeachLoop |   100 | 232.9 ns | 1.13 ns | 1.00 ns |  0.89 |    0.00 | 0.4246 |     - |     - |     888 B |
|                                  Linq |   100 | 576.7 ns | 2.43 ns | 2.16 ns |  2.21 |    0.01 | 0.3786 |     - |     - |     792 B |
|                            LinqFaster |   100 | 339.8 ns | 2.05 ns | 1.82 ns |  1.30 |    0.01 | 0.3171 |     - |     - |     664 B |
|                                LinqAF |   100 | 677.8 ns | 5.14 ns | 4.56 ns |  2.60 |    0.02 | 0.4091 |     - |     - |     856 B |
|                            StructLinq |   100 | 508.8 ns | 2.50 ns | 2.22 ns |  1.95 |    0.01 | 0.1602 |     - |     - |     336 B |
|                  StructLinq_IFunction |   100 | 297.6 ns | 1.29 ns | 1.15 ns |  1.14 |    0.01 | 0.1144 |     - |     - |     240 B |
|                             Hyperlinq |   100 | 604.9 ns | 2.10 ns | 1.96 ns |  2.32 |    0.01 | 0.1144 |     - |     - |     240 B |
|                   Hyperlinq_IFunction |   100 | 345.1 ns | 1.40 ns | 1.31 ns |  1.32 |    0.01 | 0.1144 |     - |     - |     240 B |
|                        Hyperlinq_Pool |   100 | 619.1 ns | 2.32 ns | 1.94 ns |  2.37 |    0.01 | 0.0267 |     - |     - |      56 B |
|              Hyperlinq_Pool_IFunction |   100 | 620.9 ns | 1.96 ns | 1.83 ns |  2.38 |    0.01 | 0.0267 |     - |     - |      56 B |
