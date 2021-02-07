## Array.Int32.ArrayInt32WhereSelectToList

### Source
[ArrayInt32WhereSelectToList.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelectToList.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta33](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta33)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                                Method | Count |     Mean |   Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |---------:|--------:|--------:|------:|--------:|-------:|------:|------:|----------:|
|                    ValueLinq_Standard |   100 | 555.8 ns | 2.02 ns | 1.79 ns |  2.34 |    0.01 | 0.3090 |     - |     - |     648 B |
|                       ValueLinq_Stack |   100 | 580.3 ns | 1.05 ns | 0.88 ns |  2.45 |    0.01 | 0.1221 |     - |     - |     256 B |
|             ValueLinq_SharedPool_Push |   100 | 889.8 ns | 1.39 ns | 1.16 ns |  3.75 |    0.02 | 0.1221 |     - |     - |     256 B |
|             ValueLinq_SharedPool_Pull |   100 | 827.5 ns | 1.92 ns | 1.60 ns |  3.49 |    0.02 | 0.1221 |     - |     - |     256 B |
|        ValueLinq_ValueLambda_Standard |   100 | 362.5 ns | 1.53 ns | 1.43 ns |  1.53 |    0.01 | 0.3095 |     - |     - |     648 B |
|           ValueLinq_ValueLambda_Stack |   100 | 386.9 ns | 0.84 ns | 0.75 ns |  1.63 |    0.01 | 0.1221 |     - |     - |     256 B |
| ValueLinq_ValueLambda_SharedPool_Push |   100 | 632.6 ns | 2.12 ns | 1.77 ns |  2.67 |    0.01 | 0.1221 |     - |     - |     256 B |
| ValueLinq_ValueLambda_SharedPool_Pull |   100 | 670.3 ns | 2.03 ns | 1.90 ns |  2.83 |    0.01 | 0.1221 |     - |     - |     256 B |
|                               ForLoop |   100 | 237.3 ns | 1.26 ns | 1.05 ns |  1.00 |    0.00 | 0.3095 |     - |     - |     648 B |
|                           ForeachLoop |   100 | 236.6 ns | 1.21 ns | 1.01 ns |  1.00 |    0.00 | 0.3095 |     - |     - |     648 B |
|                                  Linq |   100 | 505.4 ns | 1.61 ns | 1.50 ns |  2.13 |    0.01 | 0.3595 |     - |     - |     752 B |
|                            LinqFaster |   100 | 386.7 ns | 0.57 ns | 0.47 ns |  1.63 |    0.01 | 0.4320 |     - |     - |     904 B |
|                                LinqAF |   100 | 623.5 ns | 1.87 ns | 1.56 ns |  2.63 |    0.01 | 0.3090 |     - |     - |     648 B |
|                            StructLinq |   100 | 531.9 ns | 3.45 ns | 2.69 ns |  2.24 |    0.01 | 0.1678 |     - |     - |     352 B |
|                  StructLinq_IFunction |   100 | 291.5 ns | 0.90 ns | 0.75 ns |  1.23 |    0.01 | 0.1221 |     - |     - |     256 B |
|                             Hyperlinq |   100 | 618.8 ns | 0.91 ns | 0.80 ns |  2.61 |    0.01 | 0.1221 |     - |     - |     256 B |
|                   Hyperlinq_IFunction |   100 | 343.5 ns | 0.65 ns | 0.58 ns |  1.45 |    0.01 | 0.1221 |     - |     - |     256 B |
