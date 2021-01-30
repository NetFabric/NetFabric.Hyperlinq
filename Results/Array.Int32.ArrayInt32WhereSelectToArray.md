## Array.Int32.ArrayInt32WhereSelectToArray

### Source
[ArrayInt32WhereSelectToArray.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelectToArray.cs)

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
|                                Method | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                    ValueLinq_Standard |   100 |   868.8 ns | 17.12 ns | 24.55 ns |  3.31 |    0.11 | 0.1068 |     - |     - |     224 B |
|                       ValueLinq_Stack |   100 |   505.8 ns |  3.61 ns |  3.01 ns |  1.93 |    0.01 | 0.1068 |     - |     - |     224 B |
|             ValueLinq_SharedPool_Push |   100 | 1,027.0 ns | 20.12 ns | 29.50 ns |  3.93 |    0.12 | 0.1068 |     - |     - |     224 B |
|             ValueLinq_SharedPool_Pull |   100 |   678.5 ns |  2.92 ns |  2.59 ns |  2.59 |    0.01 | 0.1068 |     - |     - |     224 B |
|        ValueLinq_ValueLambda_Standard |   100 |   352.8 ns |  1.05 ns |  0.87 ns |  1.34 |    0.00 | 0.1068 |     - |     - |     224 B |
|           ValueLinq_ValueLambda_Stack |   100 |   323.9 ns |  0.76 ns |  0.67 ns |  1.23 |    0.00 | 0.1068 |     - |     - |     224 B |
| ValueLinq_ValueLambda_SharedPool_Push |   100 |   512.4 ns |  1.76 ns |  1.64 ns |  1.95 |    0.01 | 0.1068 |     - |     - |     224 B |
| ValueLinq_ValueLambda_SharedPool_Pull |   100 |   568.9 ns |  2.88 ns |  2.40 ns |  2.17 |    0.01 | 0.1068 |     - |     - |     224 B |
|                               ForLoop |   100 |   262.4 ns |  1.01 ns |  0.89 ns |  1.00 |    0.00 | 0.4168 |     - |     - |     872 B |
|                           ForeachLoop |   100 |   267.3 ns |  1.15 ns |  1.07 ns |  1.02 |    0.01 | 0.4168 |     - |     - |     872 B |
|                                  Linq |   100 |   789.6 ns | 12.53 ns | 11.11 ns |  3.01 |    0.04 | 0.3710 |     - |     - |     776 B |
|                            LinqFaster |   100 |   332.3 ns |  0.67 ns |  0.60 ns |  1.27 |    0.00 | 0.3095 |     - |     - |     648 B |
|                                LinqAF |   100 |   642.4 ns |  1.92 ns |  1.70 ns |  2.45 |    0.01 | 0.4015 |     - |     - |     840 B |
|                            StructLinq |   100 |   527.5 ns |  2.77 ns |  2.45 ns |  2.01 |    0.01 | 0.1526 |     - |     - |     320 B |
|                  StructLinq_IFunction |   100 |   318.6 ns |  1.43 ns |  1.19 ns |  1.21 |    0.00 | 0.1068 |     - |     - |     224 B |
|                             Hyperlinq |   100 |   622.9 ns |  2.08 ns |  1.85 ns |  2.37 |    0.01 | 0.1068 |     - |     - |     224 B |
|                   Hyperlinq_IFunction |   100 |   354.5 ns |  0.76 ns |  0.64 ns |  1.35 |    0.01 | 0.1068 |     - |     - |     224 B |
|                        Hyperlinq_Pool |   100 |   646.4 ns |  1.75 ns |  1.64 ns |  2.46 |    0.01 | 0.0267 |     - |     - |      56 B |
|              Hyperlinq_Pool_IFunction |   100 |   683.7 ns |  2.38 ns |  2.22 ns |  2.61 |    0.01 | 0.0267 |     - |     - |      56 B |
