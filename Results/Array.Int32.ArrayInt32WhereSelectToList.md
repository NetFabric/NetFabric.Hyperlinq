## Array.Int32.ArrayInt32WhereSelectToList

### Source
[ArrayInt32WhereSelectToList.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelectToList.cs)

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
|                                Method | Count |     Mean |    Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |---------:|---------:|--------:|------:|--------:|-------:|------:|------:|----------:|
|                    ValueLinq_Standard |   100 | 565.7 ns |  2.78 ns | 2.46 ns |  2.79 |    0.02 | 0.3090 |     - |     - |     648 B |
|                       ValueLinq_Stack |   100 | 581.4 ns |  1.87 ns | 1.66 ns |  2.87 |    0.02 | 0.1297 |     - |     - |     272 B |
|             ValueLinq_SharedPool_Push |   100 | 880.7 ns |  1.65 ns | 1.46 ns |  4.34 |    0.02 | 0.1297 |     - |     - |     272 B |
|             ValueLinq_SharedPool_Pull |   100 | 879.7 ns | 10.88 ns | 9.64 ns |  4.34 |    0.05 | 0.1297 |     - |     - |     272 B |
|        ValueLinq_ValueLambda_Standard |   100 | 361.8 ns |  1.32 ns | 1.17 ns |  1.78 |    0.01 | 0.3095 |     - |     - |     648 B |
|           ValueLinq_ValueLambda_Stack |   100 | 392.8 ns |  1.14 ns | 1.07 ns |  1.94 |    0.01 | 0.1297 |     - |     - |     272 B |
| ValueLinq_ValueLambda_SharedPool_Push |   100 | 645.4 ns |  2.33 ns | 2.18 ns |  3.18 |    0.01 | 0.1297 |     - |     - |     272 B |
| ValueLinq_ValueLambda_SharedPool_Pull |   100 | 640.2 ns |  3.93 ns | 3.48 ns |  3.16 |    0.02 | 0.1297 |     - |     - |     272 B |
|                               ForLoop |   100 | 202.9 ns |  1.01 ns | 0.89 ns |  1.00 |    0.00 | 0.3097 |     - |     - |     648 B |
|                           ForeachLoop |   100 | 202.6 ns |  0.60 ns | 0.50 ns |  1.00 |    0.00 | 0.3097 |     - |     - |     648 B |
|                                  Linq |   100 | 529.4 ns |  1.84 ns | 1.63 ns |  2.61 |    0.01 | 0.3595 |     - |     - |     752 B |
|                            LinqFaster |   100 | 440.3 ns |  1.34 ns | 1.05 ns |  2.17 |    0.01 | 0.4473 |     - |     - |     936 B |
|                                LinqAF |   100 | 701.4 ns |  3.21 ns | 2.85 ns |  3.46 |    0.02 | 0.3090 |     - |     - |     648 B |
|                            StructLinq |   100 | 581.3 ns |  3.18 ns | 2.97 ns |  2.86 |    0.02 | 0.1755 |     - |     - |     368 B |
|                  StructLinq_IFunction |   100 | 308.2 ns |  2.89 ns | 2.56 ns |  1.52 |    0.02 | 0.1297 |     - |     - |     272 B |
|                             Hyperlinq |   100 | 639.0 ns |  1.48 ns | 1.32 ns |  3.15 |    0.02 | 0.1297 |     - |     - |     272 B |
|                   Hyperlinq_IFunction |   100 | 355.7 ns |  0.89 ns | 0.79 ns |  1.75 |    0.01 | 0.1297 |     - |     - |     272 B |
