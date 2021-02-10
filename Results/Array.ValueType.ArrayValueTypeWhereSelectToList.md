## Array.ValueType.ArrayValueTypeWhereSelectToList

### Source
[ArrayValueTypeWhereSelectToList.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelectToList.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta35](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta35)

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
|                    ValueLinq_Standard |   100 | 1,451.7 ns | 15.46 ns | 14.46 ns |  1.72 |    0.02 | 2.4433 |     - |     - |   4.99 KB |
|                       ValueLinq_Stack |   100 | 1,178.1 ns |  5.96 ns |  4.98 ns |  1.40 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
|             ValueLinq_SharedPool_Push |   100 | 1,816.4 ns |  7.93 ns |  7.03 ns |  2.16 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
|             ValueLinq_SharedPool_Pull |   100 | 1,472.9 ns |  3.72 ns |  3.30 ns |  1.75 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
|                ValueLinq_Ref_Standard |   100 | 1,365.1 ns |  9.09 ns |  8.51 ns |  1.62 |    0.01 | 2.4433 |     - |     - |   4.99 KB |
|                   ValueLinq_Ref_Stack |   100 | 1,176.6 ns |  3.54 ns |  3.13 ns |  1.40 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
|         ValueLinq_Ref_SharedPool_Push |   100 | 1,621.4 ns |  7.28 ns |  6.08 ns |  1.92 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
|         ValueLinq_Ref_SharedPool_Pull |   100 | 1,464.6 ns |  5.30 ns |  4.69 ns |  1.74 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
|        ValueLinq_ValueLambda_Standard |   100 | 1,184.0 ns |  7.70 ns |  6.43 ns |  1.41 |    0.01 | 2.4433 |     - |     - |   4.99 KB |
|           ValueLinq_ValueLambda_Stack |   100 | 1,162.7 ns |  7.95 ns |  7.43 ns |  1.38 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
| ValueLinq_ValueLambda_SharedPool_Push |   100 | 1,369.1 ns |  3.27 ns |  2.90 ns |  1.63 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
| ValueLinq_ValueLambda_SharedPool_Pull |   100 | 1,381.9 ns |  6.26 ns |  5.55 ns |  1.64 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
|                               ForLoop |   100 |   842.0 ns |  4.56 ns |  4.26 ns |  1.00 |    0.00 | 2.4433 |     - |     - |   4.99 KB |
|                           ForeachLoop |   100 |   911.4 ns |  5.84 ns |  5.47 ns |  1.08 |    0.01 | 2.4433 |     - |     - |   4.99 KB |
|                                  Linq |   100 | 1,295.0 ns |  7.00 ns |  6.54 ns |  1.54 |    0.01 | 2.5234 |     - |     - |   5.16 KB |
|                            LinqFaster |   100 | 1,209.7 ns |  4.44 ns |  3.71 ns |  1.44 |    0.01 | 4.0264 |     - |     - |   8.23 KB |
|                                LinqAF |   100 | 2,124.1 ns | 42.14 ns | 37.35 ns |  2.52 |    0.05 | 2.4414 |     - |     - |   4.99 KB |
|                            StructLinq |   100 | 1,243.1 ns |  5.82 ns |  5.15 ns |  1.48 |    0.01 | 1.1044 |     - |     - |   2.26 KB |
|                  StructLinq_IFunction |   100 |   876.6 ns |  4.08 ns |  3.62 ns |  1.04 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
|                             Hyperlinq |   100 | 1,114.4 ns |  6.43 ns |  6.02 ns |  1.32 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
|                   Hyperlinq_IFunction |   100 |   911.6 ns |  2.35 ns |  2.20 ns |  1.08 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
