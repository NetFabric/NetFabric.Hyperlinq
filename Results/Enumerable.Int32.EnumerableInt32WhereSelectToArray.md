## Enumerable.Int32.EnumerableInt32WhereSelectToArray

### Source
[EnumerableInt32WhereSelectToArray.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelectToArray.cs)

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
|                    ValueLinq_Standard |   100 | 1,011.5 ns | 4.34 ns | 4.06 ns |  1.40 | 0.1240 |     - |     - |     264 B |
|                       ValueLinq_Stack |   100 |   988.7 ns | 2.59 ns | 2.30 ns |  1.37 | 0.1259 |     - |     - |     264 B |
|             ValueLinq_SharedPool_Push |   100 | 1,264.8 ns | 3.91 ns | 3.46 ns |  1.75 | 0.1259 |     - |     - |     264 B |
|             ValueLinq_SharedPool_Pull |   100 | 1,148.4 ns | 3.98 ns | 3.73 ns |  1.59 | 0.1259 |     - |     - |     264 B |
|        ValueLinq_ValueLambda_Standard |   100 |   785.3 ns | 2.12 ns | 1.88 ns |  1.08 | 0.1259 |     - |     - |     264 B |
|           ValueLinq_ValueLambda_Stack |   100 |   744.7 ns | 1.15 ns | 1.02 ns |  1.03 | 0.1259 |     - |     - |     264 B |
| ValueLinq_ValueLambda_SharedPool_Push |   100 | 1,100.4 ns | 3.36 ns | 3.14 ns |  1.52 | 0.1259 |     - |     - |     264 B |
| ValueLinq_ValueLambda_SharedPool_Pull |   100 |   922.3 ns | 2.55 ns | 2.26 ns |  1.27 | 0.1259 |     - |     - |     264 B |
|                           ForeachLoop |   100 |   724.1 ns | 2.94 ns | 2.60 ns |  1.00 | 0.4358 |     - |     - |     912 B |
|                                  Linq |   100 | 1,039.2 ns | 2.65 ns | 2.35 ns |  1.44 | 0.3967 |     - |     - |     832 B |
|                                LinqAF |   100 | 1,151.5 ns | 2.56 ns | 2.39 ns |  1.59 | 0.4196 |     - |     - |     880 B |
|                            StructLinq |   100 |   925.4 ns | 1.97 ns | 1.65 ns |  1.28 | 0.1678 |     - |     - |     352 B |
|                  StructLinq_IFunction |   100 |   722.6 ns | 5.71 ns | 5.06 ns |  1.00 | 0.1259 |     - |     - |     264 B |
|                             Hyperlinq |   100 | 1,064.3 ns | 2.52 ns | 2.24 ns |  1.47 | 0.1259 |     - |     - |     264 B |
|                   Hyperlinq_IFunction |   100 |   796.3 ns | 1.13 ns | 1.00 ns |  1.10 | 0.1259 |     - |     - |     264 B |
|                        Hyperlinq_Pool |   100 | 1,059.2 ns | 2.49 ns | 2.33 ns |  1.46 | 0.0458 |     - |     - |      96 B |
|              Hyperlinq_Pool_IFunction |   100 |   819.2 ns | 2.70 ns | 2.26 ns |  1.13 | 0.0458 |     - |     - |      96 B |
