## Array.Int32.ArrayInt32WhereSelectToArray

### Source
[ArrayInt32WhereSelectToArray.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelectToArray.cs)

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
|                    ValueLinq_Standard |   100 | 536.9 ns | 3.22 ns | 2.85 ns |  2.29 |    0.01 | 0.1144 |     - |     - |     240 B |
|                       ValueLinq_Stack |   100 | 511.5 ns | 1.45 ns | 1.21 ns |  2.18 |    0.02 | 0.1144 |     - |     - |     240 B |
|             ValueLinq_SharedPool_Push |   100 | 765.0 ns | 2.57 ns | 2.15 ns |  3.26 |    0.02 | 0.1144 |     - |     - |     240 B |
|             ValueLinq_SharedPool_Pull |   100 | 730.7 ns | 2.92 ns | 2.73 ns |  3.12 |    0.03 | 0.1144 |     - |     - |     240 B |
|        ValueLinq_ValueLambda_Standard |   100 | 348.2 ns | 0.98 ns | 0.82 ns |  1.49 |    0.01 | 0.1144 |     - |     - |     240 B |
|           ValueLinq_ValueLambda_Stack |   100 | 353.4 ns | 1.12 ns | 0.88 ns |  1.51 |    0.01 | 0.1144 |     - |     - |     240 B |
| ValueLinq_ValueLambda_SharedPool_Push |   100 | 510.5 ns | 2.42 ns | 1.89 ns |  2.18 |    0.02 | 0.1144 |     - |     - |     240 B |
| ValueLinq_ValueLambda_SharedPool_Pull |   100 | 524.5 ns | 2.41 ns | 2.26 ns |  2.24 |    0.01 | 0.1144 |     - |     - |     240 B |
|                               ForLoop |   100 | 234.2 ns | 1.78 ns | 1.58 ns |  1.00 |    0.00 | 0.4244 |     - |     - |     888 B |
|                           ForeachLoop |   100 | 233.3 ns | 0.67 ns | 0.56 ns |  1.00 |    0.01 | 0.4244 |     - |     - |     888 B |
|                                  Linq |   100 | 523.1 ns | 2.99 ns | 2.80 ns |  2.23 |    0.02 | 0.3786 |     - |     - |     792 B |
|                            LinqFaster |   100 | 339.8 ns | 1.26 ns | 1.05 ns |  1.45 |    0.01 | 0.3171 |     - |     - |     664 B |
|                                LinqAF |   100 | 720.4 ns | 3.14 ns | 2.78 ns |  3.08 |    0.03 | 0.4091 |     - |     - |     856 B |
|                            StructLinq |   100 | 529.7 ns | 1.72 ns | 1.61 ns |  2.26 |    0.02 | 0.1602 |     - |     - |     336 B |
|                  StructLinq_IFunction |   100 | 297.1 ns | 1.05 ns | 0.82 ns |  1.27 |    0.01 | 0.1144 |     - |     - |     240 B |
|                             Hyperlinq |   100 | 568.0 ns | 1.90 ns | 1.78 ns |  2.42 |    0.01 | 0.1144 |     - |     - |     240 B |
|                   Hyperlinq_IFunction |   100 | 343.3 ns | 1.45 ns | 1.28 ns |  1.47 |    0.01 | 0.1144 |     - |     - |     240 B |
|                        Hyperlinq_Pool |   100 | 605.0 ns | 1.68 ns | 1.49 ns |  2.58 |    0.02 | 0.0267 |     - |     - |      56 B |
|              Hyperlinq_Pool_IFunction |   100 | 629.8 ns | 2.99 ns | 2.50 ns |  2.69 |    0.02 | 0.0267 |     - |     - |      56 B |
