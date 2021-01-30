## Enumerable.Int32.EnumerableInt32WhereSelectToArray

### Source
[EnumerableInt32WhereSelectToArray.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelectToArray.cs)

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
|                                Method | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                    ValueLinq_Standard |   100 | 1,581.1 ns | 30.60 ns | 53.59 ns |  1.93 |    0.06 | 0.1259 |     - |     - |     264 B |
|                       ValueLinq_Stack |   100 | 1,610.8 ns | 31.34 ns | 42.90 ns |  1.98 |    0.06 | 0.1259 |     - |     - |     264 B |
|             ValueLinq_SharedPool_Push |   100 | 1,820.3 ns | 36.05 ns | 61.21 ns |  2.23 |    0.08 | 0.1259 |     - |     - |     264 B |
|             ValueLinq_SharedPool_Pull |   100 | 1,674.8 ns | 32.85 ns | 51.14 ns |  2.07 |    0.06 | 0.1259 |     - |     - |     264 B |
|        ValueLinq_ValueLambda_Standard |   100 |   929.2 ns | 18.11 ns | 18.60 ns |  1.15 |    0.03 | 0.1259 |     - |     - |     264 B |
|           ValueLinq_ValueLambda_Stack |   100 |   892.8 ns | 16.95 ns | 16.64 ns |  1.10 |    0.02 | 0.1259 |     - |     - |     264 B |
| ValueLinq_ValueLambda_SharedPool_Push |   100 | 1,229.8 ns | 23.64 ns | 22.11 ns |  1.52 |    0.03 | 0.1259 |     - |     - |     264 B |
| ValueLinq_ValueLambda_SharedPool_Pull |   100 | 1,178.0 ns | 23.36 ns | 35.68 ns |  1.45 |    0.05 | 0.1259 |     - |     - |     264 B |
|                           ForeachLoop |   100 |   810.6 ns |  8.45 ns |  7.49 ns |  1.00 |    0.00 | 0.4358 |     - |     - |     912 B |
|                                  Linq |   100 | 1,302.0 ns | 19.73 ns | 17.49 ns |  1.61 |    0.02 | 0.3967 |     - |     - |     832 B |
|                                LinqAF |   100 | 1,111.0 ns |  4.84 ns |  4.29 ns |  1.37 |    0.02 | 0.4196 |     - |     - |     880 B |
|                            StructLinq |   100 | 1,536.9 ns | 30.74 ns | 48.75 ns |  1.87 |    0.06 | 0.1678 |     - |     - |     352 B |
|                  StructLinq_IFunction |   100 |   925.8 ns | 17.14 ns | 16.03 ns |  1.14 |    0.02 | 0.1259 |     - |     - |     264 B |
|                             Hyperlinq |   100 | 1,593.8 ns | 31.40 ns | 34.90 ns |  1.98 |    0.05 | 0.1259 |     - |     - |     264 B |
|                   Hyperlinq_IFunction |   100 |   998.5 ns | 19.95 ns | 19.59 ns |  1.23 |    0.03 | 0.1259 |     - |     - |     264 B |
|                        Hyperlinq_Pool |   100 | 1,807.2 ns | 36.04 ns | 68.57 ns |  2.22 |    0.10 | 0.0458 |     - |     - |      96 B |
|              Hyperlinq_Pool_IFunction |   100 | 1,176.9 ns | 23.15 ns | 32.46 ns |  1.46 |    0.05 | 0.0458 |     - |     - |      96 B |
