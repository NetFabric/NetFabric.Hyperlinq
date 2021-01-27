## Array.ValueType.ArrayValueTypeWhereSelectToArray

### Source
[ArrayValueTypeWhereSelectToArray.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelectToArray.cs)

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
|                                    Method | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------------ |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                        ValueLinq_Standard |   100 | 1,643.5 ns | 13.76 ns | 12.87 ns |  1.76 |    0.01 | 3.1433 |     - |     - |    6576 B |
|                           ValueLinq_Stack |   100 | 1,108.5 ns | 10.51 ns |  9.84 ns |  1.18 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                 ValueLinq_SharedPool_Push |   100 | 1,520.9 ns | 14.25 ns | 13.33 ns |  1.63 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                 ValueLinq_SharedPool_Pull |   100 | 1,319.5 ns |  6.48 ns |  5.75 ns |  1.41 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                    ValueLinq_Ref_Standard |   100 | 1,507.8 ns | 11.51 ns | 10.77 ns |  1.61 |    0.01 | 3.1433 |     - |     - |    6576 B |
|                       ValueLinq_Ref_Stack |   100 | 1,031.5 ns |  3.76 ns |  3.52 ns |  1.10 |    0.01 | 0.9670 |     - |     - |    2024 B |
|             ValueLinq_Ref_SharedPool_Push |   100 | 1,428.0 ns |  4.86 ns |  4.54 ns |  1.52 |    0.01 | 0.9670 |     - |     - |    2024 B |
|             ValueLinq_Ref_SharedPool_Pull |   100 | 1,246.5 ns |  3.04 ns |  2.69 ns |  1.33 |    0.01 | 0.9670 |     - |     - |    2024 B |
|            ValueLinq_ValueLambda_Standard |   100 | 1,300.3 ns |  9.63 ns |  8.54 ns |  1.39 |    0.01 | 3.1433 |     - |     - |    6576 B |
|               ValueLinq_ValueLambda_Stack |   100 | 1,093.6 ns |  7.73 ns |  6.46 ns |  1.17 |    0.01 | 0.9670 |     - |     - |    2024 B |
|     ValueLinq_ValueLambda_SharedPool_Push |   100 | 1,195.3 ns |  6.74 ns |  5.98 ns |  1.28 |    0.01 | 0.9670 |     - |     - |    2024 B |
|     ValueLinq_ValueLambda_SharedPool_Pull |   100 | 1,221.7 ns |  5.45 ns |  4.55 ns |  1.30 |    0.01 | 0.9670 |     - |     - |    2024 B |
|        ValueLinq_ValueLambda_Ref_Standard |   100 | 1,253.7 ns | 18.22 ns | 15.21 ns |  1.34 |    0.01 | 3.1433 |     - |     - |    6576 B |
|           ValueLinq_ValueLambda_Ref_Stack |   100 |   907.0 ns |  3.21 ns |  2.85 ns |  0.97 |    0.01 | 0.9670 |     - |     - |    2024 B |
| ValueLinq_ValueLambda_Ref_SharedPool_Push |   100 | 1,122.5 ns |  2.96 ns |  2.63 ns |  1.20 |    0.01 | 0.9670 |     - |     - |    2024 B |
| ValueLinq_ValueLambda_Ref_SharedPool_Pull |   100 | 1,076.6 ns |  6.83 ns |  6.05 ns |  1.15 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                                   ForLoop |   100 |   936.7 ns |  4.90 ns |  4.34 ns |  1.00 |    0.00 | 3.4103 |     - |     - |    7136 B |
|                               ForeachLoop |   100 |   999.7 ns |  8.14 ns |  7.61 ns |  1.07 |    0.01 | 3.4103 |     - |     - |    7136 B |
|                                      Linq |   100 | 1,257.8 ns |  9.00 ns |  7.98 ns |  1.34 |    0.01 | 2.4319 |     - |     - |    5088 B |
|                                LinqFaster |   100 | 1,029.6 ns |  9.05 ns |  7.56 ns |  1.10 |    0.01 | 2.8896 |     - |     - |    6048 B |
|                                    LinqAF |   100 | 2,083.4 ns | 39.14 ns | 34.69 ns |  2.22 |    0.04 | 3.3951 |     - |     - |    7104 B |
|                                StructLinq |   100 | 1,168.2 ns |  5.80 ns |  4.84 ns |  1.25 |    0.01 | 1.0128 |     - |     - |    2120 B |
|                      StructLinq_IFunction |   100 |   851.7 ns |  3.23 ns |  2.52 ns |  0.91 |    0.00 | 0.9670 |     - |     - |    2024 B |
|                                 Hyperlinq |   100 | 1,345.0 ns | 12.88 ns | 12.04 ns |  1.44 |    0.02 | 0.9670 |     - |     - |    2024 B |
|                       Hyperlinq_IFunction |   100 |   948.4 ns |  5.70 ns |  5.33 ns |  1.01 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                            Hyperlinq_Pool |   100 | 1,294.2 ns | 13.99 ns | 13.08 ns |  1.38 |    0.02 | 0.0267 |     - |     - |      56 B |
|                  Hyperlinq_Pool_IFunction |   100 |   958.2 ns |  2.41 ns |  2.14 ns |  1.02 |    0.00 | 0.0267 |     - |     - |      56 B |
