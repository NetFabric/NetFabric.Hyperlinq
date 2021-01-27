## Enumerable.Int32.EnumerableInt32WhereSelectToArray

### Source
[EnumerableInt32WhereSelectToArray.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelectToArray.cs)

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
|                    ValueLinq_Standard |   100 | 1,139.4 ns | 6.69 ns | 5.93 ns |  1.69 | 0.3738 |     - |     - |     784 B |
|                       ValueLinq_Stack |   100 |   985.6 ns | 4.60 ns | 4.08 ns |  1.47 | 0.1259 |     - |     - |     264 B |
|             ValueLinq_SharedPool_Push |   100 | 1,143.0 ns | 2.75 ns | 2.15 ns |  1.70 | 0.1259 |     - |     - |     264 B |
|             ValueLinq_SharedPool_Pull |   100 | 1,138.4 ns | 3.67 ns | 3.06 ns |  1.69 | 0.1259 |     - |     - |     264 B |
|        ValueLinq_ValueLambda_Standard |   100 |   956.0 ns | 4.16 ns | 3.90 ns |  1.42 | 0.3738 |     - |     - |     784 B |
|           ValueLinq_ValueLambda_Stack |   100 |   667.8 ns | 2.87 ns | 2.40 ns |  0.99 | 0.1259 |     - |     - |     264 B |
| ValueLinq_ValueLambda_SharedPool_Push |   100 |   952.1 ns | 2.98 ns | 2.49 ns |  1.42 | 0.1259 |     - |     - |     264 B |
| ValueLinq_ValueLambda_SharedPool_Pull |   100 |   908.7 ns | 2.43 ns | 2.16 ns |  1.35 | 0.1259 |     - |     - |     264 B |
|                           ForeachLoop |   100 |   672.7 ns | 2.24 ns | 1.99 ns |  1.00 | 0.4358 |     - |     - |     912 B |
|                                  Linq |   100 | 1,008.4 ns | 2.80 ns | 2.33 ns |  1.50 | 0.3967 |     - |     - |     832 B |
|                                LinqAF |   100 | 1,090.0 ns | 3.83 ns | 3.20 ns |  1.62 | 0.4177 |     - |     - |     880 B |
|                            StructLinq |   100 |   992.6 ns | 3.67 ns | 3.26 ns |  1.48 | 0.1678 |     - |     - |     352 B |
|                  StructLinq_IFunction |   100 |   723.3 ns | 2.31 ns | 2.04 ns |  1.08 | 0.1259 |     - |     - |     264 B |
|                             Hyperlinq |   100 | 1,036.6 ns | 3.60 ns | 3.37 ns |  1.54 | 0.1259 |     - |     - |     264 B |
|                   Hyperlinq_IFunction |   100 |   794.5 ns | 4.06 ns | 3.59 ns |  1.18 | 0.1259 |     - |     - |     264 B |
|                        Hyperlinq_Pool |   100 | 1,044.3 ns | 4.38 ns | 3.89 ns |  1.55 | 0.0458 |     - |     - |      96 B |
|              Hyperlinq_Pool_IFunction |   100 |   814.7 ns | 2.37 ns | 1.98 ns |  1.21 | 0.0458 |     - |     - |      96 B |
