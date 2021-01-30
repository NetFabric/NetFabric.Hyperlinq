## Enumerable.Int32.EnumerableInt32WhereSelectToList

### Source
[EnumerableInt32WhereSelectToList.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelectToList.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta29](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta29)

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
|                    ValueLinq_Standard |   100 | 1,048.8 ns | 4.74 ns | 4.20 ns |  1.54 | 0.3281 |     - |     - |     688 B |
|                       ValueLinq_Stack |   100 | 1,051.7 ns | 4.73 ns | 4.19 ns |  1.55 | 0.1392 |     - |     - |     296 B |
|             ValueLinq_SharedPool_Push |   100 | 1,339.2 ns | 6.31 ns | 5.27 ns |  1.97 | 0.1411 |     - |     - |     296 B |
|             ValueLinq_SharedPool_Pull |   100 | 1,210.2 ns | 4.51 ns | 3.77 ns |  1.78 | 0.1411 |     - |     - |     296 B |
|        ValueLinq_ValueLambda_Standard |   100 |   775.3 ns | 3.68 ns | 3.26 ns |  1.14 | 0.3281 |     - |     - |     688 B |
|           ValueLinq_ValueLambda_Stack |   100 |   757.2 ns | 0.96 ns | 0.75 ns |  1.11 | 0.1411 |     - |     - |     296 B |
| ValueLinq_ValueLambda_SharedPool_Push |   100 | 1,055.7 ns | 4.78 ns | 3.99 ns |  1.55 | 0.1411 |     - |     - |     296 B |
| ValueLinq_ValueLambda_SharedPool_Pull |   100 | 1,042.1 ns | 3.95 ns | 3.30 ns |  1.53 | 0.1411 |     - |     - |     296 B |
|                           ForeachLoop |   100 |   679.9 ns | 2.55 ns | 2.26 ns |  1.00 | 0.3281 |     - |     - |     688 B |
|                                  Linq |   100 |   969.4 ns | 2.71 ns | 2.41 ns |  1.43 | 0.3853 |     - |     - |     808 B |
|                                LinqAF |   100 | 1,153.8 ns | 4.53 ns | 4.01 ns |  1.70 | 0.3281 |     - |     - |     688 B |
|                            StructLinq |   100 | 1,013.6 ns | 5.93 ns | 5.25 ns |  1.49 | 0.1831 |     - |     - |     384 B |
|                  StructLinq_IFunction |   100 |   741.8 ns | 1.82 ns | 1.61 ns |  1.09 | 0.1411 |     - |     - |     296 B |
|                             Hyperlinq |   100 | 1,075.5 ns | 2.16 ns | 1.92 ns |  1.58 | 0.1755 |     - |     - |     368 B |
|                   Hyperlinq_IFunction |   100 |   851.1 ns | 2.95 ns | 2.46 ns |  1.25 | 0.1755 |     - |     - |     368 B |
