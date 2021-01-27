## Enumerable.Int32.EnumerableInt32WhereSelectToList

### Source
[EnumerableInt32WhereSelectToList.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelectToList.cs)

### References:
- Cistern.ValueLinq: [0.0.11](https://www.nuget.org/packages/Cistern.ValueLinq/0.0.11)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.19.2](https://www.nuget.org/packages/StructLinq.BCL/0.19.2)
- NetFabric.Hyperlinq: [3.0.0-beta27](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta27)

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
|                    ValueLinq_Standard |   100 |   998.4 ns | 3.70 ns | 3.46 ns |  1.62 | 0.3281 |     - |     - |     688 B |
|                       ValueLinq_Stack |   100 | 1,014.2 ns | 3.18 ns | 2.97 ns |  1.64 | 0.1411 |     - |     - |     296 B |
|             ValueLinq_SharedPool_Push |   100 | 1,282.2 ns | 3.13 ns | 2.78 ns |  2.08 | 0.1411 |     - |     - |     296 B |
|             ValueLinq_SharedPool_Pull |   100 | 1,212.3 ns | 4.43 ns | 3.93 ns |  1.96 | 0.1411 |     - |     - |     296 B |
|        ValueLinq_ValueLambda_Standard |   100 |   786.0 ns | 1.39 ns | 1.16 ns |  1.27 | 0.3281 |     - |     - |     688 B |
|           ValueLinq_ValueLambda_Stack |   100 |   762.3 ns | 1.93 ns | 1.51 ns |  1.23 | 0.1411 |     - |     - |     296 B |
| ValueLinq_ValueLambda_SharedPool_Push |   100 | 1,070.6 ns | 3.57 ns | 3.34 ns |  1.73 | 0.1411 |     - |     - |     296 B |
| ValueLinq_ValueLambda_SharedPool_Pull |   100 | 1,054.1 ns | 4.71 ns | 3.93 ns |  1.71 | 0.1411 |     - |     - |     296 B |
|                           ForeachLoop |   100 |   617.5 ns | 2.73 ns | 2.13 ns |  1.00 | 0.3281 |     - |     - |     688 B |
|                                  Linq |   100 |   980.0 ns | 6.56 ns | 5.81 ns |  1.59 | 0.3853 |     - |     - |     808 B |
|                                LinqAF |   100 | 1,129.8 ns | 2.16 ns | 2.02 ns |  1.83 | 0.3281 |     - |     - |     688 B |
|                            StructLinq |   100 | 1,029.6 ns | 2.79 ns | 2.47 ns |  1.67 | 0.1831 |     - |     - |     384 B |
|                  StructLinq_IFunction |   100 |   766.7 ns | 1.86 ns | 1.56 ns |  1.24 | 0.1411 |     - |     - |     296 B |
|                             Hyperlinq |   100 | 1,059.0 ns | 3.90 ns | 3.46 ns |  1.71 | 0.1755 |     - |     - |     368 B |
|                   Hyperlinq_IFunction |   100 |   855.9 ns | 2.73 ns | 2.42 ns |  1.39 | 0.1755 |     - |     - |     368 B |
