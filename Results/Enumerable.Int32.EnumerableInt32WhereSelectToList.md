## Enumerable.Int32.EnumerableInt32WhereSelectToList

### Source
[EnumerableInt32WhereSelectToList.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelectToList.cs)

### References:
- Cistern.ValueLinq: [0.0.11](https://www.nuget.org/packages/Cistern.ValueLinq/0.0.11)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta28](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta28)

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
|                    ValueLinq_Standard |   100 | 1,148.8 ns | 6.50 ns | 5.76 ns |  1.47 | 0.3281 |     - |     - |     688 B |
|                       ValueLinq_Stack |   100 | 1,134.5 ns | 6.90 ns | 6.11 ns |  1.45 | 0.1411 |     - |     - |     296 B |
|             ValueLinq_SharedPool_Push |   100 | 1,465.6 ns | 3.96 ns | 3.71 ns |  1.87 | 0.1411 |     - |     - |     296 B |
|             ValueLinq_SharedPool_Pull |   100 | 1,353.6 ns | 6.32 ns | 5.60 ns |  1.73 | 0.1411 |     - |     - |     296 B |
|        ValueLinq_ValueLambda_Standard |   100 |   858.7 ns | 6.37 ns | 5.64 ns |  1.10 | 0.3281 |     - |     - |     688 B |
|           ValueLinq_ValueLambda_Stack |   100 |   857.5 ns | 4.21 ns | 3.94 ns |  1.10 | 0.1411 |     - |     - |     296 B |
| ValueLinq_ValueLambda_SharedPool_Push |   100 | 1,138.3 ns | 7.79 ns | 7.28 ns |  1.45 | 0.1411 |     - |     - |     296 B |
| ValueLinq_ValueLambda_SharedPool_Pull |   100 | 1,124.4 ns | 5.58 ns | 4.94 ns |  1.44 | 0.1411 |     - |     - |     296 B |
|                           ForeachLoop |   100 |   782.8 ns | 2.36 ns | 2.09 ns |  1.00 | 0.3281 |     - |     - |     688 B |
|                                  Linq |   100 | 1,055.3 ns | 4.69 ns | 3.67 ns |  1.35 | 0.3853 |     - |     - |     808 B |
|                                LinqAF |   100 | 1,298.2 ns | 4.22 ns | 3.52 ns |  1.66 | 0.3281 |     - |     - |     688 B |
|                            StructLinq |   100 | 1,080.2 ns | 6.84 ns | 5.71 ns |  1.38 | 0.1831 |     - |     - |     384 B |
|                  StructLinq_IFunction |   100 |   863.9 ns | 4.37 ns | 3.88 ns |  1.10 | 0.1411 |     - |     - |     296 B |
|                             Hyperlinq |   100 | 1,168.9 ns | 7.42 ns | 6.94 ns |  1.49 | 0.1755 |     - |     - |     368 B |
|                   Hyperlinq_IFunction |   100 |   949.9 ns | 7.15 ns | 6.34 ns |  1.21 | 0.1755 |     - |     - |     368 B |
