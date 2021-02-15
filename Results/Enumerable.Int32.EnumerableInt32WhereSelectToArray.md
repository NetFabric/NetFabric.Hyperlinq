## Enumerable.Int32.EnumerableInt32WhereSelectToArray

### Source
[EnumerableInt32WhereSelectToArray.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelectToArray.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta36](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta36)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.21079.7
  [Host]        : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                                Method | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                    ValueLinq_Standard |   100 | 1,315.7 ns | 11.19 ns |  9.92 ns |  1.60 |    0.03 | 0.1259 |     - |     - |     264 B |
|                       ValueLinq_Stack |   100 | 1,307.9 ns | 10.68 ns |  9.46 ns |  1.59 |    0.03 | 0.1259 |     - |     - |     264 B |
|             ValueLinq_SharedPool_Push |   100 | 1,507.1 ns | 21.00 ns | 16.40 ns |  1.84 |    0.04 | 0.1259 |     - |     - |     264 B |
|             ValueLinq_SharedPool_Pull |   100 | 1,351.4 ns | 12.89 ns | 11.43 ns |  1.65 |    0.03 | 0.1259 |     - |     - |     264 B |
|        ValueLinq_ValueLambda_Standard |   100 |   847.0 ns |  5.09 ns |  4.51 ns |  1.03 |    0.02 | 0.1259 |     - |     - |     264 B |
|           ValueLinq_ValueLambda_Stack |   100 |   795.9 ns |  6.93 ns |  6.48 ns |  0.97 |    0.02 | 0.1259 |     - |     - |     264 B |
| ValueLinq_ValueLambda_SharedPool_Push |   100 | 1,141.5 ns |  8.98 ns |  8.40 ns |  1.39 |    0.02 | 0.1259 |     - |     - |     264 B |
| ValueLinq_ValueLambda_SharedPool_Pull |   100 | 1,037.2 ns |  9.74 ns |  9.11 ns |  1.26 |    0.02 | 0.1259 |     - |     - |     264 B |
|                           ForeachLoop |   100 |   821.0 ns | 14.23 ns | 11.88 ns |  1.00 |    0.00 | 0.4358 |     - |     - |     912 B |
|                                  Linq |   100 | 1,265.6 ns | 10.33 ns |  8.62 ns |  1.54 |    0.02 | 0.3967 |     - |     - |     832 B |
|                                LinqAF |   100 | 1,166.4 ns |  7.88 ns |  6.99 ns |  1.42 |    0.02 | 0.4196 |     - |     - |     880 B |
|                            StructLinq |   100 | 1,291.6 ns |  8.15 ns |  6.81 ns |  1.57 |    0.02 | 0.1678 |     - |     - |     352 B |
|                  StructLinq_IFunction |   100 |   822.3 ns |  6.05 ns |  5.36 ns |  1.00 |    0.02 | 0.1259 |     - |     - |     264 B |
|                             Hyperlinq |   100 | 1,243.3 ns |  8.33 ns |  7.80 ns |  1.52 |    0.03 | 0.1259 |     - |     - |     264 B |
|                   Hyperlinq_IFunction |   100 |   897.9 ns | 10.38 ns |  9.71 ns |  1.09 |    0.02 | 0.1259 |     - |     - |     264 B |
|                        Hyperlinq_Pool |   100 | 1,284.7 ns | 16.20 ns | 15.16 ns |  1.57 |    0.03 | 0.0458 |     - |     - |      96 B |
|              Hyperlinq_Pool_IFunction |   100 |   997.2 ns | 17.64 ns | 16.50 ns |  1.22 |    0.03 | 0.0458 |     - |     - |      96 B |
