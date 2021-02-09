## List.Int32.ListInt32WhereSelectToList

### Source
[ListInt32WhereSelectToList.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelectToList.cs)

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
|                                        Method | Count |       Mean |    Error |   StdDev |     Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------------------------- |------ |-----------:|---------:|---------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|                            ValueLinq_Standard |   100 |   518.7 ns |  2.64 ns |  2.47 ns |   518.0 ns |  1.79 |    0.01 | 0.3090 |     - |     - |     648 B |
|                               ValueLinq_Stack |   100 |   808.6 ns |  1.79 ns |  1.59 ns |   808.6 ns |  2.79 |    0.01 | 0.1297 |     - |     - |     272 B |
|                     ValueLinq_SharedPool_Push |   100 |   917.7 ns | 17.85 ns | 45.10 ns |   893.8 ns |  3.37 |    0.16 | 0.1297 |     - |     - |     272 B |
|                     ValueLinq_SharedPool_Pull |   100 |   950.9 ns |  3.16 ns |  2.80 ns |   951.0 ns |  3.28 |    0.02 | 0.1297 |     - |     - |     272 B |
|                ValueLinq_ValueLambda_Standard |   100 |   368.9 ns |  1.44 ns |  1.34 ns |   368.6 ns |  1.27 |    0.01 | 0.3095 |     - |     - |     648 B |
|                   ValueLinq_ValueLambda_Stack |   100 |   557.5 ns |  2.04 ns |  1.81 ns |   556.9 ns |  1.92 |    0.01 | 0.1297 |     - |     - |     272 B |
|         ValueLinq_ValueLambda_SharedPool_Push |   100 |   631.1 ns |  1.97 ns |  1.84 ns |   630.9 ns |  2.18 |    0.01 | 0.1297 |     - |     - |     272 B |
|         ValueLinq_ValueLambda_SharedPool_Pull |   100 |   868.8 ns |  4.25 ns |  3.77 ns |   867.3 ns |  3.00 |    0.02 | 0.1297 |     - |     - |     272 B |
|                    ValueLinq_Standard_ByIndex |   100 |   541.2 ns |  2.72 ns |  2.27 ns |   541.0 ns |  1.87 |    0.01 | 0.3090 |     - |     - |     648 B |
|                       ValueLinq_Stack_ByIndex |   100 |   662.5 ns |  2.19 ns |  1.94 ns |   663.1 ns |  2.29 |    0.01 | 0.1297 |     - |     - |     272 B |
|             ValueLinq_SharedPool_Push_ByIndex |   100 |   949.0 ns |  2.82 ns |  2.50 ns |   949.1 ns |  3.27 |    0.02 | 0.1297 |     - |     - |     272 B |
|             ValueLinq_SharedPool_Pull_ByIndex |   100 |   857.5 ns |  3.48 ns |  3.09 ns |   857.8 ns |  2.96 |    0.02 | 0.1297 |     - |     - |     272 B |
|        ValueLinq_ValueLambda_Standard_ByIndex |   100 |   381.8 ns |  1.70 ns |  1.51 ns |   381.3 ns |  1.32 |    0.01 | 0.3095 |     - |     - |     648 B |
|           ValueLinq_ValueLambda_Stack_ByIndex |   100 |   393.7 ns |  0.81 ns |  0.72 ns |   393.6 ns |  1.36 |    0.01 | 0.1297 |     - |     - |     272 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |   100 |   612.2 ns |  2.57 ns |  2.27 ns |   611.7 ns |  2.11 |    0.01 | 0.1297 |     - |     - |     272 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |   100 |   649.2 ns |  6.35 ns |  5.30 ns |   647.6 ns |  2.24 |    0.03 | 0.1297 |     - |     - |     272 B |
|                                       ForLoop |   100 |   289.9 ns |  1.66 ns |  1.48 ns |   290.2 ns |  1.00 |    0.00 | 0.3095 |     - |     - |     648 B |
|                                   ForeachLoop |   100 |   406.1 ns |  1.45 ns |  1.21 ns |   405.9 ns |  1.40 |    0.01 | 0.3095 |     - |     - |     648 B |
|                                          Linq |   100 |   536.8 ns |  2.13 ns |  1.99 ns |   535.8 ns |  1.85 |    0.01 | 0.3824 |     - |     - |     800 B |
|                                    LinqFaster |   100 |   488.8 ns |  2.33 ns |  2.07 ns |   489.0 ns |  1.69 |    0.01 | 0.4396 |     - |     - |     920 B |
|                                        LinqAF |   100 | 1,177.4 ns |  7.60 ns |  5.93 ns | 1,176.3 ns |  4.06 |    0.03 | 0.3090 |     - |     - |     648 B |
|                                    StructLinq |   100 |   504.0 ns |  2.17 ns |  1.70 ns |   504.0 ns |  1.74 |    0.01 | 0.1755 |     - |     - |     368 B |
|                          StructLinq_IFunction |   100 |   286.9 ns |  1.77 ns |  1.66 ns |   286.7 ns |  0.99 |    0.01 | 0.1297 |     - |     - |     272 B |
|                                     Hyperlinq |   100 |   586.5 ns |  3.63 ns |  3.22 ns |   586.9 ns |  2.02 |    0.01 | 0.1297 |     - |     - |     272 B |
|                           Hyperlinq_IFunction |   100 |   363.4 ns |  1.58 ns |  1.40 ns |   363.0 ns |  1.25 |    0.01 | 0.1297 |     - |     - |     272 B |
