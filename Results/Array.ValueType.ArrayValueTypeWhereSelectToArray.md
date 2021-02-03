## Array.ValueType.ArrayValueTypeWhereSelectToArray

### Source
[ArrayValueTypeWhereSelectToArray.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelectToArray.cs)

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
|                    ValueLinq_Standard |   100 | 1,039.9 ns |  5.04 ns |  4.21 ns |  1.10 |    0.02 | 0.9670 |     - |     - |    2024 B |
|                       ValueLinq_Stack |   100 |   992.1 ns |  6.43 ns |  5.70 ns |  1.05 |    0.02 | 0.9670 |     - |     - |    2024 B |
|             ValueLinq_SharedPool_Push |   100 | 1,579.5 ns | 12.71 ns | 10.61 ns |  1.67 |    0.03 | 0.9670 |     - |     - |    2024 B |
|             ValueLinq_SharedPool_Pull |   100 | 1,266.3 ns |  7.85 ns |  6.13 ns |  1.33 |    0.02 | 0.9670 |     - |     - |    2024 B |
|                ValueLinq_Ref_Standard |   100 | 1,023.3 ns |  4.42 ns |  3.92 ns |  1.08 |    0.02 | 0.9670 |     - |     - |    2024 B |
|                   ValueLinq_Ref_Stack |   100 |   990.2 ns |  4.60 ns |  4.08 ns |  1.04 |    0.02 | 0.9670 |     - |     - |    2024 B |
|         ValueLinq_Ref_SharedPool_Push |   100 | 1,438.1 ns |  4.55 ns |  4.04 ns |  1.52 |    0.03 | 0.9670 |     - |     - |    2024 B |
|         ValueLinq_Ref_SharedPool_Pull |   100 | 1,262.4 ns |  3.23 ns |  3.02 ns |  1.33 |    0.02 | 0.9670 |     - |     - |    2024 B |
|        ValueLinq_ValueLambda_Standard |   100 | 1,021.0 ns |  5.56 ns |  4.93 ns |  1.08 |    0.02 | 0.9670 |     - |     - |    2024 B |
|           ValueLinq_ValueLambda_Stack |   100 |   956.6 ns |  4.23 ns |  3.96 ns |  1.01 |    0.02 | 0.9670 |     - |     - |    2024 B |
| ValueLinq_ValueLambda_SharedPool_Push |   100 | 1,212.9 ns |  6.74 ns |  5.98 ns |  1.28 |    0.02 | 0.9670 |     - |     - |    2024 B |
| ValueLinq_ValueLambda_SharedPool_Pull |   100 | 1,190.6 ns |  4.43 ns |  3.93 ns |  1.26 |    0.02 | 0.9670 |     - |     - |    2024 B |
|                               ForLoop |   100 |   949.5 ns | 15.93 ns | 14.90 ns |  1.00 |    0.00 | 3.4103 |     - |     - |    7136 B |
|                           ForeachLoop |   100 | 1,000.8 ns |  9.53 ns |  7.44 ns |  1.05 |    0.02 | 3.4103 |     - |     - |    7136 B |
|                                  Linq |   100 | 1,251.9 ns | 12.49 ns | 10.43 ns |  1.32 |    0.02 | 2.4319 |     - |     - |    5088 B |
|                            LinqFaster |   100 |   999.5 ns |  6.75 ns |  6.32 ns |  1.05 |    0.02 | 2.8896 |     - |     - |    6048 B |
|                                LinqAF |   100 | 2,073.0 ns | 20.83 ns | 19.49 ns |  2.18 |    0.03 | 3.3951 |     - |     - |    7104 B |
|                            StructLinq |   100 | 1,155.5 ns |  1.96 ns |  1.63 ns |  1.22 |    0.02 | 1.0128 |     - |     - |    2120 B |
|                  StructLinq_IFunction |   100 |   864.0 ns |  2.87 ns |  2.68 ns |  0.91 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                             Hyperlinq |   100 | 1,077.4 ns |  4.26 ns |  3.78 ns |  1.14 |    0.02 | 0.9670 |     - |     - |    2024 B |
|                   Hyperlinq_IFunction |   100 |   853.8 ns |  2.23 ns |  1.87 ns |  0.90 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                        Hyperlinq_Pool |   100 | 1,021.1 ns |  1.73 ns |  1.53 ns |  1.08 |    0.02 | 0.0267 |     - |     - |      56 B |
|              Hyperlinq_Pool_IFunction |   100 |   778.0 ns |  1.55 ns |  1.29 ns |  0.82 |    0.01 | 0.0267 |     - |     - |      56 B |
