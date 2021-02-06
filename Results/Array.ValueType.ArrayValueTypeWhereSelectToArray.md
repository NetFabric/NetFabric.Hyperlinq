## Array.ValueType.ArrayValueTypeWhereSelectToArray

### Source
[ArrayValueTypeWhereSelectToArray.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelectToArray.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta32](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta32)

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
|                    ValueLinq_Standard |   100 | 1,034.9 ns |  2.98 ns |  2.79 ns |  1.10 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                       ValueLinq_Stack |   100 | 1,000.3 ns |  3.69 ns |  3.46 ns |  1.06 |    0.01 | 0.9670 |     - |     - |    2024 B |
|             ValueLinq_SharedPool_Push |   100 | 1,604.6 ns | 17.88 ns | 15.85 ns |  1.70 |    0.02 | 0.9670 |     - |     - |    2024 B |
|             ValueLinq_SharedPool_Pull |   100 | 1,291.3 ns |  4.86 ns |  4.31 ns |  1.37 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                ValueLinq_Ref_Standard |   100 | 1,067.7 ns |  6.90 ns |  6.11 ns |  1.13 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                   ValueLinq_Ref_Stack |   100 | 1,015.5 ns |  2.90 ns |  2.42 ns |  1.08 |    0.01 | 0.9670 |     - |     - |    2024 B |
|         ValueLinq_Ref_SharedPool_Push |   100 | 1,427.8 ns |  5.01 ns |  4.44 ns |  1.51 |    0.02 | 0.9670 |     - |     - |    2024 B |
|         ValueLinq_Ref_SharedPool_Pull |   100 | 1,247.3 ns |  4.42 ns |  3.92 ns |  1.32 |    0.01 | 0.9670 |     - |     - |    2024 B |
|        ValueLinq_ValueLambda_Standard |   100 | 1,014.2 ns |  8.28 ns |  7.34 ns |  1.08 |    0.01 | 0.9670 |     - |     - |    2024 B |
|           ValueLinq_ValueLambda_Stack |   100 |   980.7 ns |  5.33 ns |  4.72 ns |  1.04 |    0.01 | 0.9670 |     - |     - |    2024 B |
| ValueLinq_ValueLambda_SharedPool_Push |   100 | 1,205.6 ns |  5.07 ns |  4.50 ns |  1.28 |    0.01 | 0.9670 |     - |     - |    2024 B |
| ValueLinq_ValueLambda_SharedPool_Pull |   100 | 1,194.3 ns | 16.79 ns | 14.88 ns |  1.27 |    0.02 | 0.9670 |     - |     - |    2024 B |
|                               ForLoop |   100 |   944.1 ns |  9.78 ns |  7.63 ns |  1.00 |    0.00 | 3.4103 |     - |     - |    7136 B |
|                           ForeachLoop |   100 | 1,015.6 ns | 17.01 ns | 17.47 ns |  1.08 |    0.03 | 3.4103 |     - |     - |    7136 B |
|                                  Linq |   100 | 1,271.0 ns | 10.47 ns |  9.28 ns |  1.35 |    0.02 | 2.4319 |     - |     - |    5088 B |
|                            LinqFaster |   100 | 1,001.8 ns |  5.91 ns |  4.94 ns |  1.06 |    0.01 | 2.8896 |     - |     - |    6048 B |
|                                LinqAF |   100 | 2,123.3 ns | 30.96 ns | 30.41 ns |  2.24 |    0.05 | 3.3951 |     - |     - |    7104 B |
|                            StructLinq |   100 | 1,159.5 ns |  6.83 ns |  6.06 ns |  1.23 |    0.01 | 1.0128 |     - |     - |    2120 B |
|                  StructLinq_IFunction |   100 |   847.5 ns |  5.41 ns |  4.79 ns |  0.90 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                             Hyperlinq |   100 | 1,110.7 ns |  5.05 ns |  4.48 ns |  1.18 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                   Hyperlinq_IFunction |   100 |   813.0 ns |  4.38 ns |  4.10 ns |  0.86 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                        Hyperlinq_Pool |   100 | 1,004.0 ns |  3.22 ns |  2.85 ns |  1.06 |    0.01 | 0.0267 |     - |     - |      56 B |
|              Hyperlinq_Pool_IFunction |   100 |   772.5 ns |  2.07 ns |  1.73 ns |  0.82 |    0.01 | 0.0267 |     - |     - |      56 B |
