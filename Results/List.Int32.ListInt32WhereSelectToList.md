## List.Int32.ListInt32WhereSelectToList

### Source
[ListInt32WhereSelectToList.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelectToList.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta37](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta37)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.21079.7
  [Host]        : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                                        Method | Count |       Mean |   Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------------------------- |------ |-----------:|--------:|--------:|------:|--------:|-------:|------:|------:|----------:|
|                            ValueLinq_Standard |   100 |   501.2 ns | 2.79 ns | 2.18 ns |  2.02 |    0.01 | 0.3090 |     - |     - |     648 B |
|                               ValueLinq_Stack |   100 |   779.2 ns | 2.55 ns | 2.26 ns |  3.14 |    0.03 | 0.1297 |     - |     - |     272 B |
|                     ValueLinq_SharedPool_Push |   100 |   903.8 ns | 3.04 ns | 2.70 ns |  3.64 |    0.03 | 0.1297 |     - |     - |     272 B |
|                     ValueLinq_SharedPool_Pull |   100 |   951.2 ns | 3.39 ns | 3.18 ns |  3.83 |    0.03 | 0.1297 |     - |     - |     272 B |
|                ValueLinq_ValueLambda_Standard |   100 |   361.4 ns | 0.90 ns | 0.80 ns |  1.45 |    0.01 | 0.3095 |     - |     - |     648 B |
|                   ValueLinq_ValueLambda_Stack |   100 |   559.3 ns | 2.34 ns | 2.19 ns |  2.25 |    0.02 | 0.1297 |     - |     - |     272 B |
|         ValueLinq_ValueLambda_SharedPool_Push |   100 |   618.0 ns | 1.74 ns | 1.54 ns |  2.49 |    0.02 | 0.1297 |     - |     - |     272 B |
|         ValueLinq_ValueLambda_SharedPool_Pull |   100 |   916.6 ns | 4.16 ns | 3.25 ns |  3.69 |    0.02 | 0.1297 |     - |     - |     272 B |
|                    ValueLinq_Standard_ByIndex |   100 |   539.0 ns | 2.04 ns | 1.80 ns |  2.17 |    0.02 | 0.3090 |     - |     - |     648 B |
|                       ValueLinq_Stack_ByIndex |   100 |   647.9 ns | 1.76 ns | 1.56 ns |  2.61 |    0.02 | 0.1297 |     - |     - |     272 B |
|             ValueLinq_SharedPool_Push_ByIndex |   100 |   909.0 ns | 1.69 ns | 1.50 ns |  3.66 |    0.03 | 0.1297 |     - |     - |     272 B |
|             ValueLinq_SharedPool_Pull_ByIndex |   100 |   851.6 ns | 5.19 ns | 4.60 ns |  3.43 |    0.04 | 0.1297 |     - |     - |     272 B |
|        ValueLinq_ValueLambda_Standard_ByIndex |   100 |   377.3 ns | 1.64 ns | 1.46 ns |  1.52 |    0.01 | 0.3095 |     - |     - |     648 B |
|           ValueLinq_ValueLambda_Stack_ByIndex |   100 |   393.8 ns | 2.08 ns | 1.84 ns |  1.59 |    0.01 | 0.1297 |     - |     - |     272 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |   100 |   633.9 ns | 1.79 ns | 1.67 ns |  2.55 |    0.02 | 0.1297 |     - |     - |     272 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |   100 |   640.4 ns | 3.19 ns | 2.82 ns |  2.58 |    0.02 | 0.1297 |     - |     - |     272 B |
|                                       ForLoop |   100 |   248.5 ns | 2.27 ns | 1.90 ns |  1.00 |    0.00 | 0.3095 |     - |     - |     648 B |
|                                   ForeachLoop |   100 |   349.8 ns | 0.83 ns | 0.74 ns |  1.41 |    0.01 | 0.3095 |     - |     - |     648 B |
|                                          Linq |   100 |   504.6 ns | 1.72 ns | 1.61 ns |  2.03 |    0.02 | 0.3824 |     - |     - |     800 B |
|                                    LinqFaster |   100 |   456.1 ns | 2.31 ns | 2.05 ns |  1.84 |    0.02 | 0.4396 |     - |     - |     920 B |
|                                        LinqAF |   100 | 1,161.8 ns | 4.99 ns | 4.43 ns |  4.68 |    0.04 | 0.3090 |     - |     - |     648 B |
|                                    StructLinq |   100 |   538.4 ns | 1.60 ns | 1.42 ns |  2.17 |    0.02 | 0.1755 |     - |     - |     368 B |
|                          StructLinq_IFunction |   100 |   298.9 ns | 1.68 ns | 1.48 ns |  1.20 |    0.01 | 0.1297 |     - |     - |     272 B |
|                                     Hyperlinq |   100 |   575.7 ns | 2.03 ns | 1.90 ns |  2.32 |    0.02 | 0.1297 |     - |     - |     272 B |
|                           Hyperlinq_IFunction |   100 |   351.9 ns | 1.20 ns | 1.06 ns |  1.42 |    0.01 | 0.1297 |     - |     - |     272 B |
