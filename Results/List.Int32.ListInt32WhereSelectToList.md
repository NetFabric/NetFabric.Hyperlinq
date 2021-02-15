## List.Int32.ListInt32WhereSelectToList

### Source
[ListInt32WhereSelectToList.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelectToList.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta36](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta36)

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
|                            ValueLinq_Standard |   100 |   542.2 ns | 7.26 ns | 6.44 ns |  1.82 |    0.02 | 0.3090 |     - |     - |     648 B |
|                               ValueLinq_Stack |   100 |   828.8 ns | 3.26 ns | 3.05 ns |  2.78 |    0.01 | 0.1297 |     - |     - |     272 B |
|                     ValueLinq_SharedPool_Push |   100 |   918.2 ns | 2.10 ns | 1.86 ns |  3.08 |    0.01 | 0.1297 |     - |     - |     272 B |
|                     ValueLinq_SharedPool_Pull |   100 |   981.2 ns | 4.67 ns | 3.90 ns |  3.29 |    0.02 | 0.1297 |     - |     - |     272 B |
|                ValueLinq_ValueLambda_Standard |   100 |   395.5 ns | 2.17 ns | 1.92 ns |  1.33 |    0.01 | 0.3095 |     - |     - |     648 B |
|                   ValueLinq_ValueLambda_Stack |   100 |   570.9 ns | 2.31 ns | 2.05 ns |  1.91 |    0.01 | 0.1297 |     - |     - |     272 B |
|         ValueLinq_ValueLambda_SharedPool_Push |   100 |   643.7 ns | 4.22 ns | 3.74 ns |  2.16 |    0.01 | 0.1297 |     - |     - |     272 B |
|         ValueLinq_ValueLambda_SharedPool_Pull |   100 |   876.4 ns | 6.93 ns | 6.14 ns |  2.94 |    0.03 | 0.1297 |     - |     - |     272 B |
|                    ValueLinq_Standard_ByIndex |   100 |   561.3 ns | 3.25 ns | 2.88 ns |  1.88 |    0.01 | 0.3090 |     - |     - |     648 B |
|                       ValueLinq_Stack_ByIndex |   100 |   680.8 ns | 2.91 ns | 2.58 ns |  2.28 |    0.01 | 0.1297 |     - |     - |     272 B |
|             ValueLinq_SharedPool_Push_ByIndex |   100 |   968.2 ns | 9.33 ns | 7.79 ns |  3.25 |    0.03 | 0.1297 |     - |     - |     272 B |
|             ValueLinq_SharedPool_Pull_ByIndex |   100 |   882.5 ns | 5.39 ns | 5.05 ns |  2.96 |    0.02 | 0.1297 |     - |     - |     272 B |
|        ValueLinq_ValueLambda_Standard_ByIndex |   100 |   401.9 ns | 1.47 ns | 1.23 ns |  1.35 |    0.01 | 0.3095 |     - |     - |     648 B |
|           ValueLinq_ValueLambda_Stack_ByIndex |   100 |   410.3 ns | 1.65 ns | 1.46 ns |  1.38 |    0.01 | 0.1297 |     - |     - |     272 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |   100 |   633.1 ns | 4.02 ns | 3.56 ns |  2.12 |    0.01 | 0.1297 |     - |     - |     272 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |   100 |   657.1 ns | 2.98 ns | 2.49 ns |  2.20 |    0.02 | 0.1297 |     - |     - |     272 B |
|                                       ForLoop |   100 |   298.3 ns | 1.50 ns | 1.33 ns |  1.00 |    0.00 | 0.3095 |     - |     - |     648 B |
|                                   ForeachLoop |   100 |   438.2 ns | 2.85 ns | 2.53 ns |  1.47 |    0.01 | 0.3095 |     - |     - |     648 B |
|                                          Linq |   100 |   551.8 ns | 3.46 ns | 2.89 ns |  1.85 |    0.01 | 0.3824 |     - |     - |     800 B |
|                                    LinqFaster |   100 |   499.9 ns | 2.60 ns | 2.30 ns |  1.68 |    0.01 | 0.4396 |     - |     - |     920 B |
|                                        LinqAF |   100 | 1,160.3 ns | 5.63 ns | 4.99 ns |  3.89 |    0.03 | 0.3090 |     - |     - |     648 B |
|                                    StructLinq |   100 |   513.5 ns | 4.65 ns | 4.12 ns |  1.72 |    0.02 | 0.1755 |     - |     - |     368 B |
|                          StructLinq_IFunction |   100 |   307.4 ns | 1.50 ns | 1.33 ns |  1.03 |    0.01 | 0.1297 |     - |     - |     272 B |
|                                     Hyperlinq |   100 |   610.5 ns | 3.95 ns | 3.69 ns |  2.05 |    0.02 | 0.1297 |     - |     - |     272 B |
|                           Hyperlinq_IFunction |   100 |   374.4 ns | 3.31 ns | 2.93 ns |  1.25 |    0.01 | 0.1297 |     - |     - |     272 B |
