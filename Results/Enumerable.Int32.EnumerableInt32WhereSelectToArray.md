## Enumerable.Int32.EnumerableInt32WhereSelectToArray

### Source
[EnumerableInt32WhereSelectToArray.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelectToArray.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta32](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta32)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                                Method | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                    ValueLinq_Standard |   100 | 1,634.4 ns | 32.50 ns | 46.62 ns |  2.12 |    0.05 | 0.1259 |     - |     - |     264 B |
|                       ValueLinq_Stack |   100 | 1,619.7 ns | 32.15 ns | 54.60 ns |  2.10 |    0.09 | 0.1259 |     - |     - |     264 B |
|             ValueLinq_SharedPool_Push |   100 | 1,823.6 ns | 35.26 ns | 43.31 ns |  2.35 |    0.06 | 0.1259 |     - |     - |     264 B |
|             ValueLinq_SharedPool_Pull |   100 | 1,672.7 ns | 33.38 ns | 54.84 ns |  2.16 |    0.07 | 0.1259 |     - |     - |     264 B |
|        ValueLinq_ValueLambda_Standard |   100 |   955.7 ns | 18.77 ns | 18.43 ns |  1.23 |    0.03 | 0.1259 |     - |     - |     264 B |
|           ValueLinq_ValueLambda_Stack |   100 |   907.8 ns | 12.69 ns | 11.25 ns |  1.17 |    0.02 | 0.1259 |     - |     - |     264 B |
| ValueLinq_ValueLambda_SharedPool_Push |   100 | 1,279.3 ns | 22.52 ns | 21.07 ns |  1.65 |    0.03 | 0.1259 |     - |     - |     264 B |
| ValueLinq_ValueLambda_SharedPool_Pull |   100 | 1,222.5 ns | 23.61 ns | 27.19 ns |  1.58 |    0.04 | 0.1259 |     - |     - |     264 B |
|                           ForeachLoop |   100 |   777.1 ns |  8.78 ns |  8.21 ns |  1.00 |    0.00 | 0.4358 |     - |     - |     912 B |
|                                  Linq |   100 | 1,302.2 ns | 13.39 ns | 10.46 ns |  1.68 |    0.02 | 0.3967 |     - |     - |     832 B |
|                                LinqAF |   100 | 1,118.9 ns |  6.79 ns |  6.35 ns |  1.44 |    0.02 | 0.4196 |     - |     - |     880 B |
|                            StructLinq |   100 | 1,435.4 ns | 28.22 ns | 45.57 ns |  1.83 |    0.07 | 0.1678 |     - |     - |     352 B |
|                  StructLinq_IFunction |   100 |   901.6 ns | 14.19 ns | 11.08 ns |  1.16 |    0.02 | 0.1259 |     - |     - |     264 B |
|                             Hyperlinq |   100 | 1,603.6 ns | 32.06 ns | 51.77 ns |  2.07 |    0.10 | 0.1259 |     - |     - |     264 B |
|                   Hyperlinq_IFunction |   100 |   996.3 ns | 19.64 ns | 26.22 ns |  1.29 |    0.04 | 0.1259 |     - |     - |     264 B |
|                        Hyperlinq_Pool |   100 | 1,800.0 ns | 35.73 ns | 67.99 ns |  2.31 |    0.10 | 0.0458 |     - |     - |      96 B |
|              Hyperlinq_Pool_IFunction |   100 | 1,185.3 ns | 20.72 ns | 27.66 ns |  1.53 |    0.05 | 0.0458 |     - |     - |      96 B |
