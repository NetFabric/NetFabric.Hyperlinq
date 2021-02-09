## Array.ValueType.ArrayValueTypeWhereSelectToList

### Source
[ArrayValueTypeWhereSelectToList.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelectToList.cs)

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
|                                Method | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                    ValueLinq_Standard |   100 | 1,501.3 ns | 13.54 ns | 12.66 ns |  1.79 |    0.02 | 2.4414 |     - |     - |   4.99 KB |
|                       ValueLinq_Stack |   100 | 1,183.9 ns |  7.69 ns |  6.42 ns |  1.41 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
|             ValueLinq_SharedPool_Push |   100 | 1,811.2 ns | 11.17 ns | 10.45 ns |  2.16 |    0.02 | 1.0586 |     - |     - |   2.16 KB |
|             ValueLinq_SharedPool_Pull |   100 | 1,445.7 ns |  5.27 ns |  4.67 ns |  1.72 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
|                ValueLinq_Ref_Standard |   100 | 1,370.6 ns |  6.92 ns |  6.14 ns |  1.63 |    0.01 | 2.4433 |     - |     - |   4.99 KB |
|                   ValueLinq_Ref_Stack |   100 | 1,171.3 ns |  6.64 ns |  6.21 ns |  1.40 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
|         ValueLinq_Ref_SharedPool_Push |   100 | 1,613.9 ns |  6.74 ns |  5.97 ns |  1.92 |    0.02 | 1.0586 |     - |     - |   2.16 KB |
|         ValueLinq_Ref_SharedPool_Pull |   100 | 1,448.5 ns |  5.50 ns |  4.88 ns |  1.73 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
|        ValueLinq_ValueLambda_Standard |   100 | 1,156.4 ns |  8.90 ns |  7.89 ns |  1.38 |    0.01 | 2.4433 |     - |     - |   4.99 KB |
|           ValueLinq_ValueLambda_Stack |   100 | 1,157.4 ns |  7.50 ns |  6.26 ns |  1.38 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
| ValueLinq_ValueLambda_SharedPool_Push |   100 | 1,377.3 ns |  5.52 ns |  4.61 ns |  1.64 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
| ValueLinq_ValueLambda_SharedPool_Pull |   100 | 1,383.3 ns |  5.01 ns |  4.44 ns |  1.65 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
|                               ForLoop |   100 |   839.3 ns |  6.39 ns |  5.34 ns |  1.00 |    0.00 | 2.4433 |     - |     - |   4.99 KB |
|                           ForeachLoop |   100 |   885.7 ns |  6.95 ns |  6.16 ns |  1.06 |    0.01 | 2.4433 |     - |     - |   4.99 KB |
|                                  Linq |   100 | 1,263.0 ns | 24.32 ns | 21.56 ns |  1.51 |    0.03 | 2.5234 |     - |     - |   5.16 KB |
|                            LinqFaster |   100 | 1,257.9 ns |  4.48 ns |  3.97 ns |  1.50 |    0.01 | 4.0264 |     - |     - |   8.23 KB |
|                                LinqAF |   100 | 2,101.7 ns | 24.30 ns | 22.73 ns |  2.51 |    0.03 | 2.4414 |     - |     - |   4.99 KB |
|                            StructLinq |   100 | 1,229.4 ns |  3.72 ns |  3.10 ns |  1.46 |    0.01 | 1.1044 |     - |     - |   2.26 KB |
|                  StructLinq_IFunction |   100 |   873.6 ns |  3.48 ns |  3.25 ns |  1.04 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
|                             Hyperlinq |   100 | 1,120.8 ns |  4.64 ns |  4.11 ns |  1.34 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
|                   Hyperlinq_IFunction |   100 |   875.8 ns |  3.90 ns |  3.46 ns |  1.04 |    0.01 | 1.0586 |     - |     - |   2.16 KB |
