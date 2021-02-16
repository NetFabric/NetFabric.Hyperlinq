## List.Int32.ListInt32WhereSelectToArray

### Source
[ListInt32WhereSelectToArray.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelectToArray.cs)

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
|                            ValueLinq_Standard |   100 |   777.0 ns | 2.75 ns | 2.57 ns |  2.49 |    0.02 | 0.1144 |     - |     - |     240 B |
|                               ValueLinq_Stack |   100 |   748.8 ns | 4.40 ns | 3.68 ns |  2.40 |    0.02 | 0.1144 |     - |     - |     240 B |
|                     ValueLinq_SharedPool_Push |   100 |   803.2 ns | 4.00 ns | 3.55 ns |  2.57 |    0.02 | 0.1144 |     - |     - |     240 B |
|                     ValueLinq_SharedPool_Pull |   100 |   853.8 ns | 5.47 ns | 4.57 ns |  2.73 |    0.02 | 0.1144 |     - |     - |     240 B |
|                ValueLinq_ValueLambda_Standard |   100 |   493.4 ns | 3.48 ns | 2.91 ns |  1.58 |    0.01 | 0.1144 |     - |     - |     240 B |
|                   ValueLinq_ValueLambda_Stack |   100 |   448.1 ns | 1.68 ns | 1.49 ns |  1.43 |    0.01 | 0.1144 |     - |     - |     240 B |
|         ValueLinq_ValueLambda_SharedPool_Push |   100 |   515.2 ns | 1.38 ns | 1.29 ns |  1.65 |    0.01 | 0.1144 |     - |     - |     240 B |
|         ValueLinq_ValueLambda_SharedPool_Pull |   100 |   744.9 ns | 2.73 ns | 2.42 ns |  2.38 |    0.01 | 0.1144 |     - |     - |     240 B |
|                    ValueLinq_Standard_ByIndex |   100 |   578.4 ns | 2.27 ns | 1.90 ns |  1.85 |    0.01 | 0.1144 |     - |     - |     240 B |
|                       ValueLinq_Stack_ByIndex |   100 |   554.9 ns | 1.66 ns | 1.55 ns |  1.78 |    0.01 | 0.1144 |     - |     - |     240 B |
|             ValueLinq_SharedPool_Push_ByIndex |   100 |   803.1 ns | 2.52 ns | 2.24 ns |  2.57 |    0.01 | 0.1144 |     - |     - |     240 B |
|             ValueLinq_SharedPool_Pull_ByIndex |   100 |   713.8 ns | 2.07 ns | 1.84 ns |  2.29 |    0.01 | 0.1144 |     - |     - |     240 B |
|        ValueLinq_ValueLambda_Standard_ByIndex |   100 |   339.0 ns | 1.08 ns | 0.96 ns |  1.09 |    0.00 | 0.1144 |     - |     - |     240 B |
|           ValueLinq_ValueLambda_Stack_ByIndex |   100 |   307.2 ns | 1.48 ns | 1.31 ns |  0.98 |    0.01 | 0.1144 |     - |     - |     240 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |   100 |   525.5 ns | 2.19 ns | 1.94 ns |  1.68 |    0.01 | 0.1144 |     - |     - |     240 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |   100 |   532.5 ns | 2.68 ns | 2.38 ns |  1.70 |    0.01 | 0.1144 |     - |     - |     240 B |
|                                       ForLoop |   100 |   312.4 ns | 1.42 ns | 1.33 ns |  1.00 |    0.00 | 0.4244 |     - |     - |     888 B |
|                                   ForeachLoop |   100 |   429.7 ns | 1.46 ns | 1.22 ns |  1.38 |    0.01 | 0.4244 |     - |     - |     888 B |
|                                          Linq |   100 |   534.1 ns | 2.46 ns | 2.18 ns |  1.71 |    0.01 | 0.4015 |     - |     - |     840 B |
|                                    LinqFaster |   100 |   530.7 ns | 3.30 ns | 2.92 ns |  1.70 |    0.01 | 0.4244 |     - |     - |     888 B |
|                                        LinqAF |   100 | 1,145.9 ns | 8.58 ns | 8.02 ns |  3.67 |    0.04 | 0.4082 |     - |     - |     856 B |
|                                    StructLinq |   100 |   531.1 ns | 4.92 ns | 4.36 ns |  1.70 |    0.02 | 0.1602 |     - |     - |     336 B |
|                          StructLinq_IFunction |   100 |   273.5 ns | 1.12 ns | 0.99 ns |  0.88 |    0.01 | 0.1144 |     - |     - |     240 B |
|                                     Hyperlinq |   100 |   570.1 ns | 1.89 ns | 1.68 ns |  1.82 |    0.01 | 0.1144 |     - |     - |     240 B |
|                           Hyperlinq_IFunction |   100 |   340.3 ns | 1.15 ns | 0.96 ns |  1.09 |    0.01 | 0.1144 |     - |     - |     240 B |
|                                Hyperlinq_Pool |   100 |   605.2 ns | 1.30 ns | 1.01 ns |  1.94 |    0.01 | 0.0267 |     - |     - |      56 B |
|                      Hyperlinq_Pool_IFunction |   100 |   380.0 ns | 1.82 ns | 1.61 ns |  1.22 |    0.00 | 0.0267 |     - |     - |      56 B |
