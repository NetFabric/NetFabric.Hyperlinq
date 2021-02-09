## List.Int32.ListInt32WhereSelectToArray

### Source
[ListInt32WhereSelectToArray.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelectToArray.cs)

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
|                                        Method | Count |       Mean |   Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------------------------- |------ |-----------:|--------:|--------:|------:|--------:|-------:|------:|------:|----------:|
|                            ValueLinq_Standard |   100 |   755.6 ns | 2.30 ns | 1.92 ns |  2.42 |    0.01 | 0.1144 |     - |     - |     240 B |
|                               ValueLinq_Stack |   100 |   736.1 ns | 3.96 ns | 3.51 ns |  2.36 |    0.02 | 0.1144 |     - |     - |     240 B |
|                     ValueLinq_SharedPool_Push |   100 |   773.1 ns | 2.26 ns | 2.12 ns |  2.48 |    0.01 | 0.1144 |     - |     - |     240 B |
|                     ValueLinq_SharedPool_Pull |   100 |   859.8 ns | 1.69 ns | 1.50 ns |  2.76 |    0.01 | 0.1144 |     - |     - |     240 B |
|                ValueLinq_ValueLambda_Standard |   100 |   499.9 ns | 1.61 ns | 1.50 ns |  1.60 |    0.01 | 0.1144 |     - |     - |     240 B |
|                   ValueLinq_ValueLambda_Stack |   100 |   456.7 ns | 0.82 ns | 0.72 ns |  1.47 |    0.01 | 0.1144 |     - |     - |     240 B |
|         ValueLinq_ValueLambda_SharedPool_Push |   100 |   523.6 ns | 1.83 ns | 1.62 ns |  1.68 |    0.01 | 0.1144 |     - |     - |     240 B |
|         ValueLinq_ValueLambda_SharedPool_Pull |   100 |   796.4 ns | 5.04 ns | 4.47 ns |  2.56 |    0.02 | 0.1144 |     - |     - |     240 B |
|                    ValueLinq_Standard_ByIndex |   100 |   579.8 ns | 1.49 ns | 1.25 ns |  1.86 |    0.01 | 0.1144 |     - |     - |     240 B |
|                       ValueLinq_Stack_ByIndex |   100 |   549.5 ns | 2.14 ns | 2.00 ns |  1.76 |    0.01 | 0.1144 |     - |     - |     240 B |
|             ValueLinq_SharedPool_Push_ByIndex |   100 |   796.8 ns | 3.30 ns | 2.92 ns |  2.56 |    0.01 | 0.1144 |     - |     - |     240 B |
|             ValueLinq_SharedPool_Pull_ByIndex |   100 |   745.1 ns | 3.26 ns | 2.73 ns |  2.39 |    0.02 | 0.1144 |     - |     - |     240 B |
|        ValueLinq_ValueLambda_Standard_ByIndex |   100 |   339.1 ns | 1.33 ns | 1.18 ns |  1.09 |    0.01 | 0.1144 |     - |     - |     240 B |
|           ValueLinq_ValueLambda_Stack_ByIndex |   100 |   303.4 ns | 1.12 ns | 0.94 ns |  0.97 |    0.00 | 0.1144 |     - |     - |     240 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |   100 |   523.9 ns | 1.40 ns | 1.24 ns |  1.68 |    0.01 | 0.1144 |     - |     - |     240 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |   100 |   522.7 ns | 1.93 ns | 1.71 ns |  1.68 |    0.01 | 0.1144 |     - |     - |     240 B |
|                                       ForLoop |   100 |   311.7 ns | 1.68 ns | 1.40 ns |  1.00 |    0.00 | 0.4239 |     - |     - |     888 B |
|                                   ForeachLoop |   100 |   405.0 ns | 1.71 ns | 1.42 ns |  1.30 |    0.01 | 0.4244 |     - |     - |     888 B |
|                                          Linq |   100 |   515.8 ns | 2.51 ns | 2.23 ns |  1.66 |    0.01 | 0.4015 |     - |     - |     840 B |
|                                    LinqFaster |   100 |   473.3 ns | 1.42 ns | 1.19 ns |  1.52 |    0.01 | 0.4244 |     - |     - |     888 B |
|                                        LinqAF |   100 | 1,158.3 ns | 5.22 ns | 4.36 ns |  3.72 |    0.02 | 0.4082 |     - |     - |     856 B |
|                                    StructLinq |   100 |   519.0 ns | 2.76 ns | 2.44 ns |  1.67 |    0.01 | 0.1602 |     - |     - |     336 B |
|                          StructLinq_IFunction |   100 |   292.2 ns | 1.41 ns | 1.25 ns |  0.94 |    0.01 | 0.1144 |     - |     - |     240 B |
|                                     Hyperlinq |   100 |   616.3 ns | 2.05 ns | 1.82 ns |  1.98 |    0.01 | 0.1144 |     - |     - |     240 B |
|                           Hyperlinq_IFunction |   100 |   350.1 ns | 1.75 ns | 1.36 ns |  1.12 |    0.01 | 0.1144 |     - |     - |     240 B |
|                                Hyperlinq_Pool |   100 |   632.4 ns | 2.16 ns | 2.02 ns |  2.03 |    0.01 | 0.0267 |     - |     - |      56 B |
|                      Hyperlinq_Pool_IFunction |   100 |   388.9 ns | 1.15 ns | 1.08 ns |  1.25 |    0.01 | 0.0267 |     - |     - |      56 B |
