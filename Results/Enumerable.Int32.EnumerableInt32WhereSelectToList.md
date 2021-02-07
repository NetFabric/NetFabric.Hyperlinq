## Enumerable.Int32.EnumerableInt32WhereSelectToList

### Source
[EnumerableInt32WhereSelectToList.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelectToList.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta33](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta33)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                                Method | Count |       Mean |   Error |  StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |-----------:|--------:|--------:|------:|-------:|------:|------:|----------:|
|                    ValueLinq_Standard |   100 |   987.3 ns | 4.40 ns | 3.67 ns |  1.43 | 0.3281 |     - |     - |     688 B |
|                       ValueLinq_Stack |   100 | 1,074.7 ns | 1.78 ns | 1.49 ns |  1.56 | 0.1411 |     - |     - |     296 B |
|             ValueLinq_SharedPool_Push |   100 | 1,329.0 ns | 5.11 ns | 4.78 ns |  1.93 | 0.1411 |     - |     - |     296 B |
|             ValueLinq_SharedPool_Pull |   100 | 1,234.0 ns | 3.25 ns | 2.88 ns |  1.79 | 0.1411 |     - |     - |     296 B |
|        ValueLinq_ValueLambda_Standard |   100 |   843.8 ns | 3.65 ns | 3.42 ns |  1.22 | 0.3281 |     - |     - |     688 B |
|           ValueLinq_ValueLambda_Stack |   100 |   780.2 ns | 1.62 ns | 1.52 ns |  1.13 | 0.1411 |     - |     - |     296 B |
| ValueLinq_ValueLambda_SharedPool_Push |   100 | 1,067.0 ns | 4.58 ns | 4.06 ns |  1.55 | 0.1411 |     - |     - |     296 B |
| ValueLinq_ValueLambda_SharedPool_Pull |   100 | 1,017.7 ns | 3.33 ns | 2.95 ns |  1.47 | 0.1411 |     - |     - |     296 B |
|                           ForeachLoop |   100 |   690.2 ns | 2.70 ns | 2.11 ns |  1.00 | 0.3281 |     - |     - |     688 B |
|                                  Linq |   100 |   964.5 ns | 3.40 ns | 3.18 ns |  1.40 | 0.3853 |     - |     - |     808 B |
|                                LinqAF |   100 | 1,082.4 ns | 4.66 ns | 4.36 ns |  1.57 | 0.3281 |     - |     - |     688 B |
|                            StructLinq |   100 | 1,006.7 ns | 2.35 ns | 2.08 ns |  1.46 | 0.1831 |     - |     - |     384 B |
|                  StructLinq_IFunction |   100 |   818.7 ns | 2.05 ns | 1.91 ns |  1.19 | 0.1411 |     - |     - |     296 B |
|                             Hyperlinq |   100 | 1,045.2 ns | 2.20 ns | 2.06 ns |  1.51 | 0.1411 |     - |     - |     296 B |
|                   Hyperlinq_IFunction |   100 |   773.7 ns | 1.68 ns | 1.58 ns |  1.12 | 0.1411 |     - |     - |     296 B |
