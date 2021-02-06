## Enumerable.Int32.EnumerableInt32WhereSelectToList

### Source
[EnumerableInt32WhereSelectToList.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelectToList.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta32](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta32)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                                Method | Count |       Mean |   Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |-----------:|--------:|--------:|------:|--------:|-------:|------:|------:|----------:|
|                    ValueLinq_Standard |   100 | 1,054.4 ns | 5.60 ns | 4.68 ns |  1.49 |    0.01 | 0.3281 |     - |     - |     688 B |
|                       ValueLinq_Stack |   100 | 1,049.5 ns | 6.42 ns | 5.69 ns |  1.48 |    0.02 | 0.1411 |     - |     - |     296 B |
|             ValueLinq_SharedPool_Push |   100 | 1,382.2 ns | 5.52 ns | 4.89 ns |  1.95 |    0.02 | 0.1411 |     - |     - |     296 B |
|             ValueLinq_SharedPool_Pull |   100 | 1,180.4 ns | 2.92 ns | 2.44 ns |  1.66 |    0.01 | 0.1411 |     - |     - |     296 B |
|        ValueLinq_ValueLambda_Standard |   100 |   779.4 ns | 2.61 ns | 2.44 ns |  1.10 |    0.01 | 0.3281 |     - |     - |     688 B |
|           ValueLinq_ValueLambda_Stack |   100 |   778.6 ns | 2.38 ns | 1.99 ns |  1.10 |    0.01 | 0.1411 |     - |     - |     296 B |
| ValueLinq_ValueLambda_SharedPool_Push |   100 | 1,104.7 ns | 3.55 ns | 2.96 ns |  1.56 |    0.01 | 0.1411 |     - |     - |     296 B |
| ValueLinq_ValueLambda_SharedPool_Pull |   100 | 1,018.3 ns | 4.24 ns | 3.76 ns |  1.44 |    0.01 | 0.1411 |     - |     - |     296 B |
|                           ForeachLoop |   100 |   709.3 ns | 5.90 ns | 5.23 ns |  1.00 |    0.00 | 0.3281 |     - |     - |     688 B |
|                                  Linq |   100 | 1,018.8 ns | 4.59 ns | 4.07 ns |  1.44 |    0.01 | 0.3853 |     - |     - |     808 B |
|                                LinqAF |   100 | 1,153.6 ns | 2.13 ns | 1.88 ns |  1.63 |    0.01 | 0.3281 |     - |     - |     688 B |
|                            StructLinq |   100 |   998.8 ns | 3.93 ns | 3.28 ns |  1.41 |    0.01 | 0.1831 |     - |     - |     384 B |
|                  StructLinq_IFunction |   100 |   745.4 ns | 3.36 ns | 2.98 ns |  1.05 |    0.01 | 0.1411 |     - |     - |     296 B |
|                             Hyperlinq |   100 | 1,027.2 ns | 3.59 ns | 3.36 ns |  1.45 |    0.01 | 0.1411 |     - |     - |     296 B |
|                   Hyperlinq_IFunction |   100 |   814.6 ns | 2.37 ns | 1.98 ns |  1.15 |    0.01 | 0.1411 |     - |     - |     296 B |
