## List.ValueType.ListValueTypeWhereSelectToArray

### Source
[ListValueTypeWhereSelectToArray.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelectToArray.cs)

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
|                                        Method | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------------------------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                            ValueLinq_Standard |   100 | 1,288.4 ns |  7.11 ns |  5.93 ns |  1.26 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                               ValueLinq_Stack |   100 | 1,270.0 ns |  9.12 ns |  8.53 ns |  1.24 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                     ValueLinq_SharedPool_Push |   100 | 1,590.7 ns | 10.81 ns |  9.59 ns |  1.55 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                     ValueLinq_SharedPool_Pull |   100 | 1,498.4 ns |  6.93 ns |  6.15 ns |  1.46 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                        ValueLinq_Ref_Standard |   100 | 1,214.9 ns |  6.86 ns |  6.42 ns |  1.19 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                           ValueLinq_Ref_Stack |   100 | 1,180.9 ns |  3.61 ns |  3.01 ns |  1.15 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                 ValueLinq_Ref_SharedPool_Push |   100 | 1,434.0 ns |  3.35 ns |  3.13 ns |  1.40 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                 ValueLinq_Ref_SharedPool_Pull |   100 | 1,433.8 ns |  7.65 ns |  6.79 ns |  1.40 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                ValueLinq_ValueLambda_Standard |   100 | 1,178.8 ns |  7.48 ns |  6.63 ns |  1.15 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                   ValueLinq_ValueLambda_Stack |   100 | 1,167.9 ns |  6.93 ns |  6.14 ns |  1.14 |    0.01 | 0.9670 |     - |     - |    2024 B |
|         ValueLinq_ValueLambda_SharedPool_Push |   100 | 1,243.6 ns |  5.86 ns |  4.89 ns |  1.21 |    0.01 | 0.9670 |     - |     - |    2024 B |
|         ValueLinq_ValueLambda_SharedPool_Pull |   100 | 1,389.5 ns |  4.00 ns |  3.54 ns |  1.36 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                    ValueLinq_Standard_ByIndex |   100 | 1,148.9 ns |  5.49 ns |  4.59 ns |  1.12 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                       ValueLinq_Stack_ByIndex |   100 | 1,055.0 ns |  5.87 ns |  4.90 ns |  1.03 |    0.01 | 0.9670 |     - |     - |    2024 B |
|             ValueLinq_SharedPool_Push_ByIndex |   100 | 1,611.1 ns |  7.23 ns |  6.77 ns |  1.57 |    0.01 | 0.9670 |     - |     - |    2024 B |
|             ValueLinq_SharedPool_Pull_ByIndex |   100 | 1,337.4 ns |  5.03 ns |  4.71 ns |  1.30 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                ValueLinq_Ref_Standard_ByIndex |   100 | 1,053.2 ns |  5.85 ns |  5.47 ns |  1.03 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                   ValueLinq_Ref_Stack_ByIndex |   100 |   992.7 ns |  4.60 ns |  4.08 ns |  0.97 |    0.01 | 0.9670 |     - |     - |    2024 B |
|         ValueLinq_Ref_SharedPool_Push_ByIndex |   100 | 1,439.2 ns |  4.23 ns |  3.96 ns |  1.40 |    0.01 | 0.9670 |     - |     - |    2024 B |
|         ValueLinq_Ref_SharedPool_Pull_ByIndex |   100 | 1,267.8 ns |  5.36 ns |  4.75 ns |  1.24 |    0.01 | 0.9670 |     - |     - |    2024 B |
|        ValueLinq_ValueLambda_Standard_ByIndex |   100 | 1,012.4 ns |  3.56 ns |  3.33 ns |  0.99 |    0.01 | 0.9670 |     - |     - |    2024 B |
|           ValueLinq_ValueLambda_Stack_ByIndex |   100 |   971.5 ns |  3.16 ns |  2.80 ns |  0.95 |    0.01 | 0.9670 |     - |     - |    2024 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |   100 | 1,229.8 ns |  5.85 ns |  5.47 ns |  1.20 |    0.01 | 0.9670 |     - |     - |    2024 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |   100 | 1,200.3 ns |  4.21 ns |  3.94 ns |  1.17 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                                       ForLoop |   100 | 1,025.1 ns |  6.37 ns |  5.96 ns |  1.00 |    0.00 | 3.4103 |     - |     - |    7136 B |
|                                   ForeachLoop |   100 | 1,249.3 ns |  5.93 ns |  5.55 ns |  1.22 |    0.01 | 3.4103 |     - |     - |    7136 B |
|                                          Linq |   100 | 1,308.7 ns | 12.67 ns | 10.58 ns |  1.28 |    0.01 | 2.4853 |     - |     - |    5200 B |
|                                    LinqFaster |   100 | 1,384.7 ns | 14.88 ns | 13.92 ns |  1.35 |    0.01 | 3.4103 |     - |     - |    7136 B |
|                                        LinqAF |   100 | 2,434.0 ns | 37.45 ns | 33.20 ns |  2.38 |    0.03 | 3.3951 |     - |     - |    7104 B |
|                                    StructLinq |   100 | 1,156.1 ns |  3.22 ns |  2.52 ns |  1.13 |    0.01 | 1.0166 |     - |     - |    2128 B |
|                          StructLinq_IFunction |   100 |   857.4 ns |  4.43 ns |  4.15 ns |  0.84 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                                     Hyperlinq |   100 | 1,307.8 ns | 13.62 ns | 12.74 ns |  1.28 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                           Hyperlinq_IFunction |   100 |   952.4 ns |  5.75 ns |  5.38 ns |  0.93 |    0.01 | 0.9670 |     - |     - |    2024 B |
|                                Hyperlinq_Pool |   100 | 1,262.7 ns | 18.12 ns | 16.95 ns |  1.23 |    0.02 | 0.0267 |     - |     - |      56 B |
|                      Hyperlinq_Pool_IFunction |   100 |   905.8 ns |  2.57 ns |  2.28 ns |  0.88 |    0.01 | 0.0267 |     - |     - |      56 B |
