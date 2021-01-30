## Array.ValueType.ArrayValueTypeWhereSelectToArray

### Source
[ArrayValueTypeWhereSelectToArray.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelectToArray.cs)

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
|                    ValueLinq_Standard |   100 | 1,032.9 ns |  5.40 ns |  5.05 ns |  1.10 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                       ValueLinq_Stack |   100 |   996.9 ns | 10.62 ns |  8.87 ns |  1.06 |    0.01 | 0.9670 |     - |     - |    2024 B |
|             ValueLinq_SharedPool_Push |   100 | 1,585.1 ns | 10.81 ns | 17.46 ns |  1.69 |    0.02 | 0.9670 |     - |     - |    2024 B |
|             ValueLinq_SharedPool_Pull |   100 | 1,249.8 ns |  5.07 ns |  4.50 ns |  1.33 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                ValueLinq_Ref_Standard |   100 | 1,020.3 ns |  4.76 ns |  4.45 ns |  1.08 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                   ValueLinq_Ref_Stack |   100 |   999.9 ns |  2.27 ns |  2.13 ns |  1.06 |    0.01 | 0.9670 |     - |     - |    2024 B |
|         ValueLinq_Ref_SharedPool_Push |   100 | 1,446.2 ns |  3.95 ns |  3.69 ns |  1.54 |    0.01 | 0.9670 |     - |     - |    2024 B |
|         ValueLinq_Ref_SharedPool_Pull |   100 | 1,228.5 ns |  6.04 ns |  5.36 ns |  1.31 |    0.01 | 0.9670 |     - |     - |    2024 B |
|        ValueLinq_ValueLambda_Standard |   100 | 1,015.2 ns |  3.43 ns |  3.21 ns |  1.08 |    0.01 | 0.9670 |     - |     - |    2024 B |
|           ValueLinq_ValueLambda_Stack |   100 |   975.0 ns |  4.22 ns |  3.95 ns |  1.04 |    0.01 | 0.9670 |     - |     - |    2024 B |
| ValueLinq_ValueLambda_SharedPool_Push |   100 | 1,210.9 ns |  6.14 ns |  5.12 ns |  1.29 |    0.01 | 0.9670 |     - |     - |    2024 B |
| ValueLinq_ValueLambda_SharedPool_Pull |   100 | 1,187.6 ns |  3.50 ns |  3.27 ns |  1.26 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                               ForLoop |   100 |   940.8 ns |  7.84 ns |  6.95 ns |  1.00 |    0.00 | 3.4103 |     - |     - |    7136 B |
|                           ForeachLoop |   100 | 1,011.3 ns |  6.99 ns |  5.84 ns |  1.07 |    0.01 | 3.4103 |     - |     - |    7136 B |
|                                  Linq |   100 | 1,248.4 ns |  5.42 ns |  4.81 ns |  1.33 |    0.01 | 2.4319 |     - |     - |    5088 B |
|                            LinqFaster |   100 | 1,018.2 ns | 10.23 ns |  9.57 ns |  1.08 |    0.01 | 2.8896 |     - |     - |    6048 B |
|                                LinqAF |   100 | 2,106.1 ns | 36.93 ns | 34.54 ns |  2.24 |    0.03 | 3.3951 |     - |     - |    7104 B |
|                            StructLinq |   100 | 1,227.3 ns |  7.04 ns |  6.58 ns |  1.31 |    0.01 | 1.0128 |     - |     - |    2120 B |
|                  StructLinq_IFunction |   100 |   845.3 ns |  3.76 ns |  3.33 ns |  0.90 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                             Hyperlinq |   100 | 1,336.6 ns | 24.68 ns | 23.08 ns |  1.42 |    0.03 | 0.9670 |     - |     - |    2024 B |
|                   Hyperlinq_IFunction |   100 |   958.6 ns |  5.00 ns |  4.67 ns |  1.02 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                        Hyperlinq_Pool |   100 |   991.5 ns |  2.63 ns |  2.46 ns |  1.05 |    0.01 | 0.0267 |     - |     - |      56 B |
|              Hyperlinq_Pool_IFunction |   100 |   772.2 ns |  1.70 ns |  1.51 ns |  0.82 |    0.01 | 0.0267 |     - |     - |      56 B |
