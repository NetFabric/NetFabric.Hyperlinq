## Enumerable.Int32.EnumerableInt32WhereSelectToList

### Source
[EnumerableInt32WhereSelectToList.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelectToList.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta31](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta31)

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
|                    ValueLinq_Standard |   100 | 1,045.9 ns | 3.01 ns | 2.51 ns |  1.54 | 0.3281 |     - |     - |     688 B |
|                       ValueLinq_Stack |   100 | 1,046.4 ns | 2.58 ns | 2.28 ns |  1.54 | 0.1411 |     - |     - |     296 B |
|             ValueLinq_SharedPool_Push |   100 | 1,339.1 ns | 4.76 ns | 3.97 ns |  1.97 | 0.1411 |     - |     - |     296 B |
|             ValueLinq_SharedPool_Pull |   100 | 1,221.7 ns | 4.61 ns | 4.31 ns |  1.79 | 0.1411 |     - |     - |     296 B |
|        ValueLinq_ValueLambda_Standard |   100 |   766.4 ns | 1.77 ns | 1.57 ns |  1.13 | 0.3281 |     - |     - |     688 B |
|           ValueLinq_ValueLambda_Stack |   100 |   774.8 ns | 2.42 ns | 2.14 ns |  1.14 | 0.1411 |     - |     - |     296 B |
| ValueLinq_ValueLambda_SharedPool_Push |   100 | 1,095.7 ns | 4.14 ns | 3.88 ns |  1.61 | 0.1411 |     - |     - |     296 B |
| ValueLinq_ValueLambda_SharedPool_Pull |   100 | 1,022.4 ns | 3.51 ns | 3.29 ns |  1.50 | 0.1411 |     - |     - |     296 B |
|                           ForeachLoop |   100 |   681.1 ns | 2.32 ns | 1.94 ns |  1.00 | 0.3281 |     - |     - |     688 B |
|                                  Linq |   100 |   977.1 ns | 3.38 ns | 2.99 ns |  1.43 | 0.3853 |     - |     - |     808 B |
|                                LinqAF |   100 | 1,148.9 ns | 5.05 ns | 4.48 ns |  1.69 | 0.3281 |     - |     - |     688 B |
|                            StructLinq |   100 | 1,012.2 ns | 3.74 ns | 3.12 ns |  1.49 | 0.1831 |     - |     - |     384 B |
|                  StructLinq_IFunction |   100 |   826.4 ns | 2.14 ns | 1.79 ns |  1.21 | 0.1411 |     - |     - |     296 B |
|                             Hyperlinq |   100 | 1,027.8 ns | 2.06 ns | 1.82 ns |  1.51 | 0.1411 |     - |     - |     296 B |
|                   Hyperlinq_IFunction |   100 |   787.5 ns | 2.36 ns | 2.09 ns |  1.16 | 0.1411 |     - |     - |     296 B |
