## List.Int32.ListInt32WhereSelectToArray

### Source
[ListInt32WhereSelectToArray.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelectToArray.cs)

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
|                            ValueLinq_Standard |   100 |   776.3 ns | 4.25 ns | 3.55 ns |  2.41 |    0.02 | 0.1144 |     - |     - |     240 B |
|                               ValueLinq_Stack |   100 |   758.8 ns | 3.45 ns | 3.22 ns |  2.36 |    0.01 | 0.1144 |     - |     - |     240 B |
|                     ValueLinq_SharedPool_Push |   100 |   801.2 ns | 2.30 ns | 1.92 ns |  2.49 |    0.02 | 0.1144 |     - |     - |     240 B |
|                     ValueLinq_SharedPool_Pull |   100 |   888.3 ns | 3.17 ns | 2.64 ns |  2.76 |    0.02 | 0.1144 |     - |     - |     240 B |
|                ValueLinq_ValueLambda_Standard |   100 |   517.4 ns | 3.58 ns | 2.99 ns |  1.61 |    0.01 | 0.1144 |     - |     - |     240 B |
|                   ValueLinq_ValueLambda_Stack |   100 |   472.4 ns | 4.19 ns | 3.71 ns |  1.47 |    0.02 | 0.1144 |     - |     - |     240 B |
|         ValueLinq_ValueLambda_SharedPool_Push |   100 |   532.2 ns | 4.62 ns | 4.09 ns |  1.65 |    0.02 | 0.1144 |     - |     - |     240 B |
|         ValueLinq_ValueLambda_SharedPool_Pull |   100 |   826.0 ns | 5.53 ns | 4.90 ns |  2.57 |    0.02 | 0.1144 |     - |     - |     240 B |
|                    ValueLinq_Standard_ByIndex |   100 |   598.2 ns | 1.91 ns | 1.60 ns |  1.86 |    0.01 | 0.1144 |     - |     - |     240 B |
|                       ValueLinq_Stack_ByIndex |   100 |   567.2 ns | 3.93 ns | 3.49 ns |  1.76 |    0.02 | 0.1144 |     - |     - |     240 B |
|             ValueLinq_SharedPool_Push_ByIndex |   100 |   838.7 ns | 3.38 ns | 3.16 ns |  2.60 |    0.02 | 0.1144 |     - |     - |     240 B |
|             ValueLinq_SharedPool_Pull_ByIndex |   100 |   736.0 ns | 3.48 ns | 3.09 ns |  2.29 |    0.01 | 0.1144 |     - |     - |     240 B |
|        ValueLinq_ValueLambda_Standard_ByIndex |   100 |   352.2 ns | 2.01 ns | 1.68 ns |  1.09 |    0.01 | 0.1144 |     - |     - |     240 B |
|           ValueLinq_ValueLambda_Stack_ByIndex |   100 |   313.5 ns | 1.11 ns | 0.93 ns |  0.97 |    0.01 | 0.1144 |     - |     - |     240 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |   100 |   539.7 ns | 1.95 ns | 1.73 ns |  1.68 |    0.01 | 0.1144 |     - |     - |     240 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |   100 |   541.4 ns | 2.65 ns | 2.21 ns |  1.68 |    0.01 | 0.1144 |     - |     - |     240 B |
|                                       ForLoop |   100 |   321.9 ns | 1.70 ns | 1.51 ns |  1.00 |    0.00 | 0.4244 |     - |     - |     888 B |
|                                   ForeachLoop |   100 |   419.6 ns | 2.10 ns | 1.97 ns |  1.30 |    0.01 | 0.4244 |     - |     - |     888 B |
|                                          Linq |   100 |   538.5 ns | 3.92 ns | 3.47 ns |  1.67 |    0.01 | 0.4015 |     - |     - |     840 B |
|                                    LinqFaster |   100 |   491.4 ns | 3.69 ns | 3.45 ns |  1.53 |    0.01 | 0.4244 |     - |     - |     888 B |
|                                        LinqAF |   100 | 1,179.6 ns | 4.11 ns | 3.85 ns |  3.67 |    0.02 | 0.4082 |     - |     - |     856 B |
|                                    StructLinq |   100 |   543.5 ns | 6.05 ns | 5.66 ns |  1.69 |    0.02 | 0.1602 |     - |     - |     336 B |
|                          StructLinq_IFunction |   100 |   302.5 ns | 1.08 ns | 1.01 ns |  0.94 |    0.01 | 0.1144 |     - |     - |     240 B |
|                                     Hyperlinq |   100 |   623.5 ns | 3.65 ns | 3.24 ns |  1.94 |    0.01 | 0.1144 |     - |     - |     240 B |
|                           Hyperlinq_IFunction |   100 |   355.4 ns | 1.29 ns | 1.08 ns |  1.10 |    0.00 | 0.1144 |     - |     - |     240 B |
|                                Hyperlinq_Pool |   100 |   637.1 ns | 4.25 ns | 3.97 ns |  1.98 |    0.01 | 0.0267 |     - |     - |      56 B |
|                      Hyperlinq_Pool_IFunction |   100 |   393.6 ns | 1.24 ns | 1.03 ns |  1.22 |    0.01 | 0.0267 |     - |     - |      56 B |
