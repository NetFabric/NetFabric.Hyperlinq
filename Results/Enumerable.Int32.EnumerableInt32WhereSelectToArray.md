## Enumerable.Int32.EnumerableInt32WhereSelectToArray

### Source
[EnumerableInt32WhereSelectToArray.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelectToArray.cs)

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
|                                Method | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                    ValueLinq_Standard |   100 | 1,617.9 ns | 31.17 ns | 37.11 ns |  1.99 |    0.05 | 0.1259 |     - |     - |     264 B |
|                       ValueLinq_Stack |   100 | 1,614.6 ns | 31.57 ns | 47.26 ns |  1.97 |    0.06 | 0.1259 |     - |     - |     264 B |
|             ValueLinq_SharedPool_Push |   100 | 1,842.2 ns | 35.50 ns | 54.21 ns |  2.25 |    0.09 | 0.1259 |     - |     - |     264 B |
|             ValueLinq_SharedPool_Pull |   100 | 1,654.7 ns | 32.39 ns | 50.43 ns |  2.03 |    0.07 | 0.1259 |     - |     - |     264 B |
|        ValueLinq_ValueLambda_Standard |   100 |   943.9 ns | 18.09 ns | 20.83 ns |  1.16 |    0.03 | 0.1259 |     - |     - |     264 B |
|           ValueLinq_ValueLambda_Stack |   100 |   895.6 ns | 12.94 ns | 11.47 ns |  1.10 |    0.02 | 0.1259 |     - |     - |     264 B |
| ValueLinq_ValueLambda_SharedPool_Push |   100 | 1,313.1 ns | 25.02 ns | 36.67 ns |  1.60 |    0.05 | 0.1259 |     - |     - |     264 B |
| ValueLinq_ValueLambda_SharedPool_Pull |   100 | 1,228.1 ns | 24.06 ns | 34.51 ns |  1.51 |    0.05 | 0.1259 |     - |     - |     264 B |
|                           ForeachLoop |   100 |   816.4 ns |  6.69 ns |  6.26 ns |  1.00 |    0.00 | 0.4358 |     - |     - |     912 B |
|                                  Linq |   100 | 1,335.9 ns | 25.65 ns | 23.99 ns |  1.64 |    0.03 | 0.3967 |     - |     - |     832 B |
|                                LinqAF |   100 | 1,456.9 ns | 27.93 ns | 27.43 ns |  1.78 |    0.04 | 0.4196 |     - |     - |     880 B |
|                            StructLinq |   100 | 1,541.1 ns | 30.64 ns | 45.87 ns |  1.89 |    0.05 | 0.1678 |     - |     - |     352 B |
|                  StructLinq_IFunction |   100 |   915.6 ns | 12.70 ns | 11.26 ns |  1.12 |    0.02 | 0.1259 |     - |     - |     264 B |
|                             Hyperlinq |   100 | 1,559.9 ns | 31.24 ns | 44.80 ns |  1.92 |    0.05 | 0.1259 |     - |     - |     264 B |
|                   Hyperlinq_IFunction |   100 | 1,034.9 ns | 20.31 ns | 35.57 ns |  1.26 |    0.05 | 0.1259 |     - |     - |     264 B |
|                        Hyperlinq_Pool |   100 | 1,828.2 ns | 36.37 ns | 67.41 ns |  2.23 |    0.11 | 0.0458 |     - |     - |      96 B |
|              Hyperlinq_Pool_IFunction |   100 | 1,248.7 ns | 24.31 ns | 37.12 ns |  1.54 |    0.04 | 0.0458 |     - |     - |      96 B |
