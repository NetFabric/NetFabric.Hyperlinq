## Array.ValueType.ArrayValueTypeWhereSelectToArray

### Source
[ArrayValueTypeWhereSelectToArray.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelectToArray.cs)

### References:
- Cistern.ValueLinq: [0.0.11](https://www.nuget.org/packages/Cistern.ValueLinq/0.0.11)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta28](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta28)

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
|                        ValueLinq_Standard |   100 | 1,845.5 ns | 10.41 ns |  8.69 ns |  1.71 |    0.01 | 3.1433 |     - |     - |    6576 B |
|                           ValueLinq_Stack |   100 | 1,235.7 ns | 14.54 ns | 13.60 ns |  1.14 |    0.02 | 0.9670 |     - |     - |    2024 B |
|                 ValueLinq_SharedPool_Push |   100 | 1,707.4 ns | 13.65 ns | 12.10 ns |  1.58 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                 ValueLinq_SharedPool_Pull |   100 | 1,483.2 ns | 15.27 ns | 13.54 ns |  1.37 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                    ValueLinq_Ref_Standard |   100 | 1,734.1 ns | 14.54 ns | 12.89 ns |  1.60 |    0.01 | 3.1433 |     - |     - |    6576 B |
|                       ValueLinq_Ref_Stack |   100 | 1,195.8 ns |  9.31 ns |  7.77 ns |  1.11 |    0.01 | 0.9670 |     - |     - |    2024 B |
|             ValueLinq_Ref_SharedPool_Push |   100 | 1,609.5 ns |  8.84 ns |  8.27 ns |  1.49 |    0.01 | 0.9670 |     - |     - |    2024 B |
|             ValueLinq_Ref_SharedPool_Pull |   100 | 1,403.5 ns |  5.96 ns |  5.58 ns |  1.30 |    0.01 | 0.9670 |     - |     - |    2024 B |
|            ValueLinq_ValueLambda_Standard |   100 | 1,511.7 ns | 27.19 ns | 25.44 ns |  1.40 |    0.02 | 3.1433 |     - |     - |    6576 B |
|               ValueLinq_ValueLambda_Stack |   100 | 1,234.7 ns | 11.24 ns |  9.38 ns |  1.14 |    0.01 | 0.9670 |     - |     - |    2024 B |
|     ValueLinq_ValueLambda_SharedPool_Push |   100 | 1,387.5 ns |  6.81 ns |  6.03 ns |  1.28 |    0.01 | 0.9670 |     - |     - |    2024 B |
|     ValueLinq_ValueLambda_SharedPool_Pull |   100 | 1,361.0 ns |  5.76 ns |  4.81 ns |  1.26 |    0.01 | 0.9670 |     - |     - |    2024 B |
|        ValueLinq_ValueLambda_Ref_Standard |   100 | 1,433.9 ns | 11.16 ns | 10.44 ns |  1.32 |    0.01 | 3.1433 |     - |     - |    6576 B |
|           ValueLinq_ValueLambda_Ref_Stack |   100 | 1,016.4 ns |  5.37 ns |  5.02 ns |  0.94 |    0.01 | 0.9670 |     - |     - |    2024 B |
| ValueLinq_ValueLambda_Ref_SharedPool_Push |   100 | 1,282.7 ns |  7.41 ns |  6.57 ns |  1.19 |    0.01 | 0.9670 |     - |     - |    2024 B |
| ValueLinq_ValueLambda_Ref_SharedPool_Pull |   100 | 1,222.8 ns |  7.32 ns |  6.49 ns |  1.13 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                                   ForLoop |   100 | 1,082.4 ns |  6.00 ns |  5.32 ns |  1.00 |    0.00 | 3.4103 |     - |     - |    7136 B |
|                               ForeachLoop |   100 | 1,147.0 ns |  8.53 ns |  7.56 ns |  1.06 |    0.01 | 3.4103 |     - |     - |    7136 B |
|                                      Linq |   100 | 1,435.7 ns | 12.08 ns | 10.71 ns |  1.33 |    0.01 | 2.4319 |     - |     - |    5088 B |
|                                LinqFaster |   100 | 1,159.1 ns |  6.20 ns |  5.80 ns |  1.07 |    0.01 | 2.8896 |     - |     - |    6048 B |
|                                    LinqAF |   100 | 2,354.7 ns | 22.05 ns | 20.62 ns |  2.17 |    0.02 | 3.3951 |     - |     - |    7104 B |
|                                StructLinq |   100 | 1,297.2 ns | 11.09 ns | 10.38 ns |  1.20 |    0.01 | 1.0128 |     - |     - |    2120 B |
|                      StructLinq_IFunction |   100 |   943.9 ns |  4.40 ns |  3.90 ns |  0.87 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                                 Hyperlinq |   100 | 1,490.1 ns |  8.59 ns |  8.04 ns |  1.38 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                       Hyperlinq_IFunction |   100 | 1,068.3 ns | 10.32 ns |  9.65 ns |  0.99 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                            Hyperlinq_Pool |   100 | 1,373.5 ns |  4.30 ns |  3.81 ns |  1.27 |    0.01 | 0.0267 |     - |     - |      56 B |
|                  Hyperlinq_Pool_IFunction |   100 | 1,005.3 ns |  4.43 ns |  4.15 ns |  0.93 |    0.01 | 0.0267 |     - |     - |      56 B |
