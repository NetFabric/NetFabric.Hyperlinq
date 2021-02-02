## Enumerable.Int32.EnumerableInt32WhereSelectToList

### Source
[EnumerableInt32WhereSelectToList.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelectToList.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta30](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta30)

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
|                    ValueLinq_Standard |   100 | 1,055.6 ns | 3.52 ns | 3.29 ns |  1.61 | 0.3281 |     - |     - |     688 B |
|                       ValueLinq_Stack |   100 | 1,041.3 ns | 2.35 ns | 2.09 ns |  1.59 | 0.1411 |     - |     - |     296 B |
|             ValueLinq_SharedPool_Push |   100 | 1,366.1 ns | 2.40 ns | 1.87 ns |  2.08 | 0.1411 |     - |     - |     296 B |
|             ValueLinq_SharedPool_Pull |   100 | 1,185.1 ns | 1.91 ns | 1.70 ns |  1.80 | 0.1411 |     - |     - |     296 B |
|        ValueLinq_ValueLambda_Standard |   100 |   764.9 ns | 3.93 ns | 3.49 ns |  1.16 | 0.3281 |     - |     - |     688 B |
|           ValueLinq_ValueLambda_Stack |   100 |   781.7 ns | 1.63 ns | 1.36 ns |  1.19 | 0.1411 |     - |     - |     296 B |
| ValueLinq_ValueLambda_SharedPool_Push |   100 | 1,096.2 ns | 2.71 ns | 2.53 ns |  1.67 | 0.1411 |     - |     - |     296 B |
| ValueLinq_ValueLambda_SharedPool_Pull |   100 | 1,080.9 ns | 2.94 ns | 2.75 ns |  1.65 | 0.1411 |     - |     - |     296 B |
|                           ForeachLoop |   100 |   656.8 ns | 2.46 ns | 2.18 ns |  1.00 | 0.3281 |     - |     - |     688 B |
|                                  Linq |   100 |   991.0 ns | 2.86 ns | 2.39 ns |  1.51 | 0.3853 |     - |     - |     808 B |
|                                LinqAF |   100 | 1,082.2 ns | 2.65 ns | 2.48 ns |  1.65 | 0.3281 |     - |     - |     688 B |
|                            StructLinq |   100 |   978.9 ns | 3.30 ns | 2.93 ns |  1.49 | 0.1831 |     - |     - |     384 B |
|                  StructLinq_IFunction |   100 |   717.5 ns | 1.53 ns | 1.36 ns |  1.09 | 0.1411 |     - |     - |     296 B |
|                             Hyperlinq |   100 | 1,052.5 ns | 3.52 ns | 3.12 ns |  1.60 | 0.1411 |     - |     - |     296 B |
|                   Hyperlinq_IFunction |   100 |   819.3 ns | 2.31 ns | 1.93 ns |  1.25 | 0.1411 |     - |     - |     296 B |
