## Array.ValueType.ArrayValueTypeWhereSelectToArray

### Source
[ArrayValueTypeWhereSelectToArray.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelectToArray.cs)

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
|                                Method | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                    ValueLinq_Standard |   100 | 1,034.4 ns |  4.71 ns |  4.40 ns |  1.11 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                       ValueLinq_Stack |   100 |   989.0 ns |  5.75 ns |  4.80 ns |  1.06 |    0.01 | 0.9670 |     - |     - |    2024 B |
|             ValueLinq_SharedPool_Push |   100 | 1,588.0 ns | 12.41 ns | 11.61 ns |  1.70 |    0.01 | 0.9670 |     - |     - |    2024 B |
|             ValueLinq_SharedPool_Pull |   100 | 1,287.2 ns |  5.24 ns |  4.91 ns |  1.38 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                ValueLinq_Ref_Standard |   100 | 1,018.0 ns |  2.53 ns |  2.24 ns |  1.09 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                   ValueLinq_Ref_Stack |   100 |   980.6 ns |  4.63 ns |  4.33 ns |  1.05 |    0.01 | 0.9670 |     - |     - |    2024 B |
|         ValueLinq_Ref_SharedPool_Push |   100 | 1,431.0 ns |  5.68 ns |  5.04 ns |  1.53 |    0.01 | 0.9670 |     - |     - |    2024 B |
|         ValueLinq_Ref_SharedPool_Pull |   100 | 1,241.4 ns |  4.34 ns |  3.39 ns |  1.33 |    0.01 | 0.9670 |     - |     - |    2024 B |
|        ValueLinq_ValueLambda_Standard |   100 |   996.1 ns |  3.79 ns |  3.36 ns |  1.07 |    0.01 | 0.9670 |     - |     - |    2024 B |
|           ValueLinq_ValueLambda_Stack |   100 |   950.8 ns |  5.20 ns |  4.34 ns |  1.02 |    0.01 | 0.9670 |     - |     - |    2024 B |
| ValueLinq_ValueLambda_SharedPool_Push |   100 | 1,233.8 ns |  3.13 ns |  2.93 ns |  1.32 |    0.01 | 0.9670 |     - |     - |    2024 B |
| ValueLinq_ValueLambda_SharedPool_Pull |   100 | 1,216.2 ns |  4.83 ns |  4.52 ns |  1.30 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                               ForLoop |   100 |   934.9 ns |  4.01 ns |  3.35 ns |  1.00 |    0.00 | 3.4103 |     - |     - |    7136 B |
|                           ForeachLoop |   100 |   994.5 ns |  8.08 ns |  7.16 ns |  1.06 |    0.01 | 3.4103 |     - |     - |    7136 B |
|                                  Linq |   100 | 1,260.1 ns | 13.88 ns | 12.98 ns |  1.35 |    0.01 | 2.4319 |     - |     - |    5088 B |
|                            LinqFaster |   100 |   997.8 ns | 10.64 ns |  9.95 ns |  1.07 |    0.01 | 2.8896 |     - |     - |    6048 B |
|                                LinqAF |   100 | 2,105.5 ns | 31.80 ns | 29.75 ns |  2.25 |    0.04 | 3.3951 |     - |     - |    7104 B |
|                            StructLinq |   100 | 1,190.9 ns |  5.09 ns |  4.51 ns |  1.27 |    0.01 | 1.0128 |     - |     - |    2120 B |
|                  StructLinq_IFunction |   100 |   844.7 ns |  1.52 ns |  1.27 ns |  0.90 |    0.00 | 0.9670 |     - |     - |    2024 B |
|                             Hyperlinq |   100 | 1,058.7 ns |  3.55 ns |  2.96 ns |  1.13 |    0.00 | 0.9670 |     - |     - |    2024 B |
|                   Hyperlinq_IFunction |   100 |   825.4 ns |  3.52 ns |  3.29 ns |  0.88 |    0.00 | 0.9670 |     - |     - |    2024 B |
|                        Hyperlinq_Pool |   100 | 1,026.2 ns |  2.88 ns |  2.41 ns |  1.10 |    0.00 | 0.0267 |     - |     - |      56 B |
|              Hyperlinq_Pool_IFunction |   100 |   766.9 ns |  1.13 ns |  0.95 ns |  0.82 |    0.00 | 0.0267 |     - |     - |      56 B |
