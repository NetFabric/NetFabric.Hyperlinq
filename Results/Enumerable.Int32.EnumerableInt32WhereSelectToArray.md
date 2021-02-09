## Enumerable.Int32.EnumerableInt32WhereSelectToArray

### Source
[EnumerableInt32WhereSelectToArray.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelectToArray.cs)

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
|                                Method | Count |       Mean |    Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |-----------:|---------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                    ValueLinq_Standard |   100 | 1,658.2 ns | 32.75 ns |  51.95 ns |  2.03 |    0.07 | 0.1259 |     - |     - |     264 B |
|                       ValueLinq_Stack |   100 | 1,655.9 ns | 33.00 ns |  49.39 ns |  2.00 |    0.06 | 0.1259 |     - |     - |     264 B |
|             ValueLinq_SharedPool_Push |   100 | 1,893.3 ns | 31.45 ns |  44.09 ns |  2.32 |    0.06 | 0.1259 |     - |     - |     264 B |
|             ValueLinq_SharedPool_Pull |   100 | 1,731.6 ns | 33.96 ns |  60.36 ns |  2.11 |    0.08 | 0.1259 |     - |     - |     264 B |
|        ValueLinq_ValueLambda_Standard |   100 |   965.9 ns | 18.96 ns |  30.07 ns |  1.17 |    0.04 | 0.1259 |     - |     - |     264 B |
|           ValueLinq_ValueLambda_Stack |   100 |   921.4 ns | 18.21 ns |  20.97 ns |  1.13 |    0.02 | 0.1259 |     - |     - |     264 B |
| ValueLinq_ValueLambda_SharedPool_Push |   100 | 1,272.8 ns | 25.24 ns |  36.20 ns |  1.56 |    0.05 | 0.1259 |     - |     - |     264 B |
| ValueLinq_ValueLambda_SharedPool_Pull |   100 | 1,226.5 ns | 23.83 ns |  32.62 ns |  1.50 |    0.05 | 0.1259 |     - |     - |     264 B |
|                           ForeachLoop |   100 |   820.2 ns |  6.49 ns |   5.76 ns |  1.00 |    0.00 | 0.4358 |     - |     - |     912 B |
|                                  Linq |   100 | 1,319.1 ns | 25.95 ns |  36.38 ns |  1.62 |    0.04 | 0.3967 |     - |     - |     832 B |
|                                LinqAF |   100 | 1,115.1 ns |  3.32 ns |   2.94 ns |  1.36 |    0.01 | 0.4196 |     - |     - |     880 B |
|                            StructLinq |   100 | 1,566.8 ns | 31.41 ns |  54.18 ns |  1.90 |    0.05 | 0.1678 |     - |     - |     352 B |
|                  StructLinq_IFunction |   100 |   920.8 ns | 17.83 ns |  17.51 ns |  1.12 |    0.02 | 0.1259 |     - |     - |     264 B |
|                             Hyperlinq |   100 | 1,569.8 ns | 31.17 ns |  52.93 ns |  1.90 |    0.06 | 0.1259 |     - |     - |     264 B |
|                   Hyperlinq_IFunction |   100 | 1,073.0 ns | 20.97 ns |  33.26 ns |  1.30 |    0.04 | 0.1259 |     - |     - |     264 B |
|                        Hyperlinq_Pool |   100 | 1,905.4 ns | 42.96 ns | 126.68 ns |  2.30 |    0.17 | 0.0458 |     - |     - |      96 B |
|              Hyperlinq_Pool_IFunction |   100 | 1,222.7 ns | 24.10 ns |  39.59 ns |  1.49 |    0.06 | 0.0458 |     - |     - |      96 B |
