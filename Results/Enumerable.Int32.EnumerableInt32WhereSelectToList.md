## Enumerable.Int32.EnumerableInt32WhereSelectToList

### Source
[EnumerableInt32WhereSelectToList.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelectToList.cs)

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
|                                Method | Count |       Mean |   Error |  StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |-----------:|--------:|--------:|------:|-------:|------:|------:|----------:|
|                    ValueLinq_Standard |   100 | 1,052.2 ns | 3.17 ns | 2.81 ns |  1.54 | 0.3281 |     - |     - |     688 B |
|                       ValueLinq_Stack |   100 | 1,040.5 ns | 2.48 ns | 2.32 ns |  1.53 | 0.1411 |     - |     - |     296 B |
|             ValueLinq_SharedPool_Push |   100 | 1,349.6 ns | 4.19 ns | 3.92 ns |  1.98 | 0.1411 |     - |     - |     296 B |
|             ValueLinq_SharedPool_Pull |   100 | 1,183.0 ns | 7.52 ns | 7.04 ns |  1.74 | 0.1411 |     - |     - |     296 B |
|        ValueLinq_ValueLambda_Standard |   100 |   769.8 ns | 2.31 ns | 2.05 ns |  1.13 | 0.3281 |     - |     - |     688 B |
|           ValueLinq_ValueLambda_Stack |   100 |   774.7 ns | 2.30 ns | 2.04 ns |  1.14 | 0.1411 |     - |     - |     296 B |
| ValueLinq_ValueLambda_SharedPool_Push |   100 | 1,053.5 ns | 6.22 ns | 5.20 ns |  1.55 | 0.1411 |     - |     - |     296 B |
| ValueLinq_ValueLambda_SharedPool_Pull |   100 | 1,018.9 ns | 3.87 ns | 3.43 ns |  1.50 | 0.1411 |     - |     - |     296 B |
|                           ForeachLoop |   100 |   681.4 ns | 1.34 ns | 1.19 ns |  1.00 | 0.3281 |     - |     - |     688 B |
|                                  Linq |   100 |   959.2 ns | 3.63 ns | 3.22 ns |  1.41 | 0.3853 |     - |     - |     808 B |
|                                LinqAF |   100 | 1,066.6 ns | 4.35 ns | 3.63 ns |  1.57 | 0.3281 |     - |     - |     688 B |
|                            StructLinq |   100 | 1,001.2 ns | 4.42 ns | 3.45 ns |  1.47 | 0.1831 |     - |     - |     384 B |
|                  StructLinq_IFunction |   100 |   727.2 ns | 1.87 ns | 1.56 ns |  1.07 | 0.1411 |     - |     - |     296 B |
|                             Hyperlinq |   100 | 1,031.8 ns | 3.85 ns | 3.22 ns |  1.51 | 0.1411 |     - |     - |     296 B |
|                   Hyperlinq_IFunction |   100 |   820.2 ns | 3.59 ns | 3.36 ns |  1.20 | 0.1411 |     - |     - |     296 B |
