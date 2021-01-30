## List.Int32.ListInt32WhereSelectToArray

### Source
[ListInt32WhereSelectToArray.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelectToArray.cs)

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
|                                        Method | Count |       Mean |   Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------------------------- |------ |-----------:|--------:|--------:|------:|--------:|-------:|------:|------:|----------:|
|                            ValueLinq_Standard |   100 |   745.7 ns | 2.35 ns | 2.08 ns |  2.52 |    0.02 | 0.1068 |     - |     - |     224 B |
|                               ValueLinq_Stack |   100 |   724.2 ns | 1.75 ns | 1.63 ns |  2.44 |    0.02 | 0.1068 |     - |     - |     224 B |
|                     ValueLinq_SharedPool_Push |   100 |   784.9 ns | 2.90 ns | 2.42 ns |  2.65 |    0.01 | 0.1068 |     - |     - |     224 B |
|                     ValueLinq_SharedPool_Pull |   100 |   831.9 ns | 1.70 ns | 1.42 ns |  2.81 |    0.02 | 0.1068 |     - |     - |     224 B |
|                ValueLinq_ValueLambda_Standard |   100 |   494.7 ns | 2.32 ns | 2.06 ns |  1.67 |    0.01 | 0.1068 |     - |     - |     224 B |
|                   ValueLinq_ValueLambda_Stack |   100 |   470.0 ns | 1.13 ns | 1.06 ns |  1.59 |    0.01 | 0.1068 |     - |     - |     224 B |
|         ValueLinq_ValueLambda_SharedPool_Push |   100 |   513.6 ns | 1.44 ns | 1.35 ns |  1.73 |    0.01 | 0.1068 |     - |     - |     224 B |
|         ValueLinq_ValueLambda_SharedPool_Pull |   100 |   722.7 ns | 1.65 ns | 1.38 ns |  2.44 |    0.01 | 0.1068 |     - |     - |     224 B |
|                    ValueLinq_Standard_ByIndex |   100 |   588.8 ns | 2.18 ns | 2.04 ns |  1.99 |    0.01 | 0.1068 |     - |     - |     224 B |
|                       ValueLinq_Stack_ByIndex |   100 |   545.3 ns | 1.82 ns | 1.62 ns |  1.84 |    0.01 | 0.1068 |     - |     - |     224 B |
|             ValueLinq_SharedPool_Push_ByIndex |   100 |   842.4 ns | 2.76 ns | 2.45 ns |  2.84 |    0.02 | 0.1068 |     - |     - |     224 B |
|             ValueLinq_SharedPool_Pull_ByIndex |   100 |   712.9 ns | 3.06 ns | 2.71 ns |  2.41 |    0.01 | 0.1068 |     - |     - |     224 B |
|        ValueLinq_ValueLambda_Standard_ByIndex |   100 |   347.0 ns | 1.00 ns | 0.89 ns |  1.17 |    0.01 | 0.1068 |     - |     - |     224 B |
|           ValueLinq_ValueLambda_Stack_ByIndex |   100 |   303.6 ns | 0.73 ns | 0.69 ns |  1.03 |    0.01 | 0.1068 |     - |     - |     224 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |   100 |   516.9 ns | 1.58 ns | 1.48 ns |  1.75 |    0.01 | 0.1068 |     - |     - |     224 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |   100 |   550.2 ns | 1.45 ns | 1.28 ns |  1.86 |    0.01 | 0.1068 |     - |     - |     224 B |
|                                       ForLoop |   100 |   296.2 ns | 1.88 ns | 1.67 ns |  1.00 |    0.00 | 0.4163 |     - |     - |     872 B |
|                                   ForeachLoop |   100 |   435.3 ns | 1.09 ns | 0.97 ns |  1.47 |    0.01 | 0.4168 |     - |     - |     872 B |
|                                          Linq |   100 |   543.3 ns | 2.41 ns | 2.01 ns |  1.83 |    0.01 | 0.3939 |     - |     - |     824 B |
|                                    LinqFaster |   100 |   523.5 ns | 3.06 ns | 2.55 ns |  1.77 |    0.01 | 0.4168 |     - |     - |     872 B |
|                                        LinqAF |   100 | 1,059.9 ns | 3.05 ns | 2.85 ns |  3.58 |    0.02 | 0.4005 |     - |     - |     840 B |
|                                    StructLinq |   100 |   545.7 ns | 2.17 ns | 2.03 ns |  1.84 |    0.01 | 0.1526 |     - |     - |     320 B |
|                          StructLinq_IFunction |   100 |   274.6 ns | 0.71 ns | 0.63 ns |  0.93 |    0.01 | 0.1068 |     - |     - |     224 B |
|                                     Hyperlinq |   100 |   585.1 ns | 1.70 ns | 1.59 ns |  1.98 |    0.01 | 0.1068 |     - |     - |     224 B |
|                           Hyperlinq_IFunction |   100 |   341.8 ns | 0.66 ns | 0.61 ns |  1.15 |    0.01 | 0.1068 |     - |     - |     224 B |
|                                Hyperlinq_Pool |   100 |   669.8 ns | 1.76 ns | 1.56 ns |  2.26 |    0.01 | 0.0267 |     - |     - |      56 B |
|                      Hyperlinq_Pool_IFunction |   100 |   441.6 ns | 1.27 ns | 1.13 ns |  1.49 |    0.01 | 0.0267 |     - |     - |      56 B |
