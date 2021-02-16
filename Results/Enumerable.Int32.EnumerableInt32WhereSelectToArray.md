## Enumerable.Int32.EnumerableInt32WhereSelectToArray

### Source
[EnumerableInt32WhereSelectToArray.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelectToArray.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta37](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta37)

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
|                    ValueLinq_Standard |   100 | 1,062.8 ns | 3.12 ns | 2.76 ns |  1.56 | 0.1259 |     - |     - |     264 B |
|                       ValueLinq_Stack |   100 |   985.5 ns | 5.30 ns | 4.96 ns |  1.44 | 0.1259 |     - |     - |     264 B |
|             ValueLinq_SharedPool_Push |   100 | 1,236.1 ns | 4.20 ns | 3.51 ns |  1.81 | 0.1259 |     - |     - |     264 B |
|             ValueLinq_SharedPool_Pull |   100 | 1,100.1 ns | 4.46 ns | 3.73 ns |  1.61 | 0.1259 |     - |     - |     264 B |
|        ValueLinq_ValueLambda_Standard |   100 |   783.9 ns | 1.94 ns | 1.52 ns |  1.15 | 0.1259 |     - |     - |     264 B |
|           ValueLinq_ValueLambda_Stack |   100 |   788.8 ns | 3.87 ns | 3.23 ns |  1.15 | 0.1259 |     - |     - |     264 B |
| ValueLinq_ValueLambda_SharedPool_Push |   100 |   975.3 ns | 5.68 ns | 5.04 ns |  1.43 | 0.1259 |     - |     - |     264 B |
| ValueLinq_ValueLambda_SharedPool_Pull |   100 |   912.5 ns | 3.52 ns | 3.12 ns |  1.34 | 0.1259 |     - |     - |     264 B |
|                           ForeachLoop |   100 |   683.3 ns | 2.91 ns | 2.72 ns |  1.00 | 0.4358 |     - |     - |     912 B |
|                                  Linq |   100 | 1,052.6 ns | 4.21 ns | 3.73 ns |  1.54 | 0.3967 |     - |     - |     832 B |
|                                LinqAF |   100 | 1,108.9 ns | 4.82 ns | 4.03 ns |  1.62 | 0.4196 |     - |     - |     880 B |
|                            StructLinq |   100 | 1,017.6 ns | 3.63 ns | 3.22 ns |  1.49 | 0.1678 |     - |     - |     352 B |
|                  StructLinq_IFunction |   100 |   715.2 ns | 3.41 ns | 3.02 ns |  1.05 | 0.1259 |     - |     - |     264 B |
|                             Hyperlinq |   100 |   992.5 ns | 2.30 ns | 1.92 ns |  1.45 | 0.1259 |     - |     - |     264 B |
|                   Hyperlinq_IFunction |   100 |   891.1 ns | 2.05 ns | 1.60 ns |  1.30 | 0.1259 |     - |     - |     264 B |
|                        Hyperlinq_Pool |   100 | 1,098.0 ns | 4.34 ns | 3.85 ns |  1.61 | 0.0458 |     - |     - |      96 B |
|              Hyperlinq_Pool_IFunction |   100 |   817.0 ns | 3.83 ns | 3.59 ns |  1.20 | 0.0458 |     - |     - |      96 B |
