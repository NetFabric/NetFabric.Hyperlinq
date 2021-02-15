## Enumerable.Int32.EnumerableInt32WhereSelectToList

### Source
[EnumerableInt32WhereSelectToList.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelectToList.cs)

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
|                                Method | Count |       Mean |   Error |  StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |-----------:|--------:|--------:|------:|-------:|------:|------:|----------:|
|                    ValueLinq_Standard |   100 | 1,090.2 ns | 6.33 ns | 4.94 ns |  1.52 | 0.3281 |     - |     - |     688 B |
|                       ValueLinq_Stack |   100 | 1,078.8 ns | 5.78 ns | 5.13 ns |  1.51 | 0.1411 |     - |     - |     296 B |
|             ValueLinq_SharedPool_Push |   100 | 1,391.7 ns | 7.82 ns | 6.53 ns |  1.94 | 0.1411 |     - |     - |     296 B |
|             ValueLinq_SharedPool_Pull |   100 | 1,219.5 ns | 6.81 ns | 6.04 ns |  1.70 | 0.1411 |     - |     - |     296 B |
|        ValueLinq_ValueLambda_Standard |   100 |   834.1 ns | 4.45 ns | 3.94 ns |  1.17 | 0.3281 |     - |     - |     688 B |
|           ValueLinq_ValueLambda_Stack |   100 |   781.7 ns | 3.85 ns | 3.41 ns |  1.09 | 0.1411 |     - |     - |     296 B |
| ValueLinq_ValueLambda_SharedPool_Push |   100 | 1,132.4 ns | 5.32 ns | 4.72 ns |  1.58 | 0.1411 |     - |     - |     296 B |
| ValueLinq_ValueLambda_SharedPool_Pull |   100 | 1,065.5 ns | 6.47 ns | 5.40 ns |  1.49 | 0.1411 |     - |     - |     296 B |
|                           ForeachLoop |   100 |   716.1 ns | 2.63 ns | 2.46 ns |  1.00 | 0.3281 |     - |     - |     688 B |
|                                  Linq |   100 |   997.4 ns | 3.64 ns | 3.23 ns |  1.39 | 0.3853 |     - |     - |     808 B |
|                                LinqAF |   100 | 1,095.3 ns | 3.75 ns | 3.13 ns |  1.53 | 0.3281 |     - |     - |     688 B |
|                            StructLinq |   100 | 1,042.2 ns | 2.64 ns | 2.34 ns |  1.46 | 0.1831 |     - |     - |     384 B |
|                  StructLinq_IFunction |   100 |   763.7 ns | 2.65 ns | 2.48 ns |  1.07 | 0.1411 |     - |     - |     296 B |
|                             Hyperlinq |   100 | 1,128.2 ns | 3.98 ns | 3.72 ns |  1.58 | 0.1411 |     - |     - |     296 B |
|                   Hyperlinq_IFunction |   100 |   809.6 ns | 4.63 ns | 3.87 ns |  1.13 | 0.1411 |     - |     - |     296 B |
