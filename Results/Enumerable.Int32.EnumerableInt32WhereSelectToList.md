## Enumerable.Int32.EnumerableInt32WhereSelectToList

### Source
[EnumerableInt32WhereSelectToList.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelectToList.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta34](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta34)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                                Method | Count |       Mean |    Error |  StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |-----------:|---------:|--------:|------:|-------:|------:|------:|----------:|
|                    ValueLinq_Standard |   100 | 1,047.6 ns |  3.76 ns | 3.51 ns |  1.53 | 0.3281 |     - |     - |     688 B |
|                       ValueLinq_Stack |   100 | 1,046.2 ns |  2.70 ns | 2.39 ns |  1.53 | 0.1411 |     - |     - |     296 B |
|             ValueLinq_SharedPool_Push |   100 | 1,335.8 ns |  4.01 ns | 3.55 ns |  1.95 | 0.1411 |     - |     - |     296 B |
|             ValueLinq_SharedPool_Pull |   100 | 1,213.5 ns |  4.93 ns | 4.37 ns |  1.78 | 0.1411 |     - |     - |     296 B |
|        ValueLinq_ValueLambda_Standard |   100 |   796.3 ns |  2.09 ns | 1.95 ns |  1.17 | 0.3281 |     - |     - |     688 B |
|           ValueLinq_ValueLambda_Stack |   100 |   777.2 ns |  1.37 ns | 1.21 ns |  1.14 | 0.1411 |     - |     - |     296 B |
| ValueLinq_ValueLambda_SharedPool_Push |   100 | 1,077.2 ns |  4.90 ns | 4.58 ns |  1.58 | 0.1411 |     - |     - |     296 B |
| ValueLinq_ValueLambda_SharedPool_Pull |   100 | 1,022.3 ns | 10.35 ns | 8.64 ns |  1.50 | 0.1411 |     - |     - |     296 B |
|                           ForeachLoop |   100 |   683.2 ns |  2.60 ns | 2.43 ns |  1.00 | 0.3281 |     - |     - |     688 B |
|                                  Linq |   100 |   960.9 ns |  3.67 ns | 3.25 ns |  1.41 | 0.3853 |     - |     - |     808 B |
|                                LinqAF |   100 | 1,071.9 ns |  2.81 ns | 2.63 ns |  1.57 | 0.3281 |     - |     - |     688 B |
|                            StructLinq |   100 | 1,008.4 ns |  2.86 ns | 2.68 ns |  1.48 | 0.1831 |     - |     - |     384 B |
|                  StructLinq_IFunction |   100 |   777.2 ns |  1.13 ns | 0.88 ns |  1.14 | 0.1411 |     - |     - |     296 B |
|                             Hyperlinq |   100 | 1,033.8 ns |  3.96 ns | 3.70 ns |  1.51 | 0.1411 |     - |     - |     296 B |
|                   Hyperlinq_IFunction |   100 |   825.7 ns |  3.26 ns | 2.55 ns |  1.21 | 0.1411 |     - |     - |     296 B |
