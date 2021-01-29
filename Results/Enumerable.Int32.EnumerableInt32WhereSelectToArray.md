## Enumerable.Int32.EnumerableInt32WhereSelectToArray

### Source
[EnumerableInt32WhereSelectToArray.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelectToArray.cs)

### References:
- Cistern.ValueLinq: [0.0.11](https://www.nuget.org/packages/Cistern.ValueLinq/0.0.11)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta28](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta28)

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
|                    ValueLinq_Standard |   100 | 1,297.8 ns |  9.19 ns |  7.67 ns |  1.68 |    0.01 | 0.3738 |     - |     - |     784 B |
|                       ValueLinq_Stack |   100 | 1,079.5 ns | 10.33 ns |  9.67 ns |  1.40 |    0.02 | 0.1259 |     - |     - |     264 B |
|             ValueLinq_SharedPool_Push |   100 | 1,312.7 ns |  5.35 ns |  4.74 ns |  1.70 |    0.01 | 0.1259 |     - |     - |     264 B |
|             ValueLinq_SharedPool_Pull |   100 | 1,255.2 ns |  7.22 ns |  6.03 ns |  1.63 |    0.01 | 0.1259 |     - |     - |     264 B |
|        ValueLinq_ValueLambda_Standard |   100 | 1,007.5 ns | 10.40 ns |  9.22 ns |  1.30 |    0.01 | 0.3719 |     - |     - |     784 B |
|           ValueLinq_ValueLambda_Stack |   100 |   774.3 ns |  3.20 ns |  2.84 ns |  1.00 |    0.01 | 0.1259 |     - |     - |     264 B |
| ValueLinq_ValueLambda_SharedPool_Push |   100 | 1,064.8 ns |  8.23 ns |  7.69 ns |  1.38 |    0.01 | 0.1259 |     - |     - |     264 B |
| ValueLinq_ValueLambda_SharedPool_Pull |   100 | 1,002.1 ns | 12.08 ns | 10.09 ns |  1.30 |    0.01 | 0.1259 |     - |     - |     264 B |
|                           ForeachLoop |   100 |   772.3 ns |  2.55 ns |  2.13 ns |  1.00 |    0.00 | 0.4358 |     - |     - |     912 B |
|                                  Linq |   100 | 1,151.0 ns |  5.12 ns |  4.79 ns |  1.49 |    0.01 | 0.3967 |     - |     - |     832 B |
|                                LinqAF |   100 | 1,259.2 ns |  4.90 ns |  4.58 ns |  1.63 |    0.01 | 0.4177 |     - |     - |     880 B |
|                            StructLinq |   100 | 1,032.2 ns |  6.16 ns |  5.14 ns |  1.34 |    0.01 | 0.1678 |     - |     - |     352 B |
|                  StructLinq_IFunction |   100 |   808.1 ns |  2.94 ns |  2.75 ns |  1.05 |    0.00 | 0.1259 |     - |     - |     264 B |
|                             Hyperlinq |   100 | 1,126.6 ns |  5.73 ns |  5.08 ns |  1.46 |    0.01 | 0.1259 |     - |     - |     264 B |
|                   Hyperlinq_IFunction |   100 |   881.7 ns |  4.26 ns |  3.78 ns |  1.14 |    0.01 | 0.1259 |     - |     - |     264 B |
|                        Hyperlinq_Pool |   100 | 1,214.6 ns |  7.98 ns |  7.07 ns |  1.57 |    0.01 | 0.0458 |     - |     - |      96 B |
|              Hyperlinq_Pool_IFunction |   100 |   944.6 ns |  3.83 ns |  3.40 ns |  1.22 |    0.01 | 0.0458 |     - |     - |      96 B |
