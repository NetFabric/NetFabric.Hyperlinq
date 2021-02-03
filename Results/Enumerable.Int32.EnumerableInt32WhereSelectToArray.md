## Enumerable.Int32.EnumerableInt32WhereSelectToArray

### Source
[EnumerableInt32WhereSelectToArray.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelectToArray.cs)

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
|                                Method | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                    ValueLinq_Standard |   100 | 1,620.8 ns | 31.95 ns | 54.26 ns |  1.99 |    0.05 | 0.1259 |     - |     - |     264 B |
|                       ValueLinq_Stack |   100 | 1,620.4 ns | 31.61 ns | 53.68 ns |  2.01 |    0.05 | 0.1259 |     - |     - |     264 B |
|             ValueLinq_SharedPool_Push |   100 | 1,839.6 ns | 36.07 ns | 51.74 ns |  2.28 |    0.07 | 0.1259 |     - |     - |     264 B |
|             ValueLinq_SharedPool_Pull |   100 | 1,704.5 ns | 32.90 ns | 48.22 ns |  2.10 |    0.07 | 0.1259 |     - |     - |     264 B |
|        ValueLinq_ValueLambda_Standard |   100 |   937.3 ns | 13.47 ns | 11.94 ns |  1.15 |    0.02 | 0.1259 |     - |     - |     264 B |
|           ValueLinq_ValueLambda_Stack |   100 |   883.1 ns | 14.41 ns | 12.04 ns |  1.09 |    0.02 | 0.1259 |     - |     - |     264 B |
| ValueLinq_ValueLambda_SharedPool_Push |   100 | 1,283.3 ns | 24.17 ns | 41.04 ns |  1.59 |    0.06 | 0.1259 |     - |     - |     264 B |
| ValueLinq_ValueLambda_SharedPool_Pull |   100 | 1,217.6 ns | 23.47 ns | 32.12 ns |  1.51 |    0.05 | 0.1259 |     - |     - |     264 B |
|                           ForeachLoop |   100 |   812.3 ns |  9.10 ns |  8.51 ns |  1.00 |    0.00 | 0.4358 |     - |     - |     912 B |
|                                  Linq |   100 | 1,311.2 ns | 26.24 ns | 31.24 ns |  1.61 |    0.05 | 0.3967 |     - |     - |     832 B |
|                                LinqAF |   100 | 1,457.4 ns | 20.73 ns | 19.39 ns |  1.79 |    0.03 | 0.4196 |     - |     - |     880 B |
|                            StructLinq |   100 | 1,534.5 ns | 30.72 ns | 50.48 ns |  1.88 |    0.07 | 0.1678 |     - |     - |     352 B |
|                  StructLinq_IFunction |   100 |   935.4 ns | 18.24 ns | 21.01 ns |  1.16 |    0.03 | 0.1259 |     - |     - |     264 B |
|                             Hyperlinq |   100 | 1,608.3 ns | 31.41 ns | 49.82 ns |  1.99 |    0.07 | 0.1259 |     - |     - |     264 B |
|                   Hyperlinq_IFunction |   100 |   998.8 ns | 19.51 ns | 26.04 ns |  1.23 |    0.04 | 0.1259 |     - |     - |     264 B |
|                        Hyperlinq_Pool |   100 | 1,792.9 ns | 35.79 ns | 67.21 ns |  2.24 |    0.08 | 0.0458 |     - |     - |      96 B |
|              Hyperlinq_Pool_IFunction |   100 | 1,190.4 ns | 22.82 ns | 35.53 ns |  1.47 |    0.05 | 0.0458 |     - |     - |      96 B |
