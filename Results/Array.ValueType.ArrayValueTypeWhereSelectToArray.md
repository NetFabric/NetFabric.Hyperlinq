## Array.ValueType.ArrayValueTypeWhereSelectToArray

### Source
[ArrayValueTypeWhereSelectToArray.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelectToArray.cs)

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
|                                Method | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                    ValueLinq_Standard |   100 | 1,117.2 ns |  3.12 ns |  2.77 ns |  1.14 |    0.00 | 1.0433 |     - |     - |    2184 B |
|                       ValueLinq_Stack |   100 | 1,070.8 ns | 21.22 ns | 22.71 ns |  1.09 |    0.02 | 1.0433 |     - |     - |    2184 B |
|             ValueLinq_SharedPool_Push |   100 | 1,653.4 ns | 12.68 ns | 11.24 ns |  1.68 |    0.01 | 1.0433 |     - |     - |    2184 B |
|             ValueLinq_SharedPool_Pull |   100 | 1,361.7 ns |  6.53 ns |  6.10 ns |  1.38 |    0.01 | 1.0433 |     - |     - |    2184 B |
|                ValueLinq_Ref_Standard |   100 | 1,081.8 ns |  7.26 ns |  6.79 ns |  1.10 |    0.01 | 1.0433 |     - |     - |    2184 B |
|                   ValueLinq_Ref_Stack |   100 | 1,044.4 ns |  4.80 ns |  4.25 ns |  1.06 |    0.01 | 1.0433 |     - |     - |    2184 B |
|         ValueLinq_Ref_SharedPool_Push |   100 | 1,489.0 ns |  4.99 ns |  4.67 ns |  1.51 |    0.01 | 1.0433 |     - |     - |    2184 B |
|         ValueLinq_Ref_SharedPool_Pull |   100 | 1,340.4 ns |  2.93 ns |  2.60 ns |  1.36 |    0.01 | 1.0433 |     - |     - |    2184 B |
|        ValueLinq_ValueLambda_Standard |   100 | 1,067.4 ns |  4.21 ns |  3.94 ns |  1.08 |    0.01 | 1.0433 |     - |     - |    2184 B |
|           ValueLinq_ValueLambda_Stack |   100 | 1,026.9 ns |  4.58 ns |  4.29 ns |  1.04 |    0.00 | 1.0433 |     - |     - |    2184 B |
| ValueLinq_ValueLambda_SharedPool_Push |   100 | 1,264.4 ns |  3.20 ns |  2.83 ns |  1.28 |    0.01 | 1.0433 |     - |     - |    2184 B |
| ValueLinq_ValueLambda_SharedPool_Pull |   100 | 1,258.0 ns |  3.86 ns |  3.22 ns |  1.28 |    0.00 | 1.0433 |     - |     - |    2184 B |
|                               ForLoop |   100 |   984.4 ns |  3.79 ns |  3.55 ns |  1.00 |    0.00 | 3.4866 |     - |     - |    7296 B |
|                           ForeachLoop |   100 | 1,027.4 ns |  6.90 ns |  5.76 ns |  1.04 |    0.01 | 3.4866 |     - |     - |    7296 B |
|                                  Linq |   100 | 1,307.4 ns |  6.36 ns |  5.95 ns |  1.33 |    0.01 | 2.5082 |     - |     - |    5248 B |
|                            LinqFaster |   100 | 1,050.8 ns |  3.59 ns |  3.00 ns |  1.07 |    0.01 | 2.9659 |     - |     - |    6208 B |
|                                LinqAF |   100 | 2,180.3 ns | 29.00 ns | 27.12 ns |  2.21 |    0.03 | 3.4714 |     - |     - |    7264 B |
|                            StructLinq |   100 | 1,183.1 ns |  6.41 ns |  5.68 ns |  1.20 |    0.01 | 1.0891 |     - |     - |    2280 B |
|                  StructLinq_IFunction |   100 |   894.1 ns |  3.47 ns |  3.25 ns |  0.91 |    0.00 | 1.0433 |     - |     - |    2184 B |
|                             Hyperlinq |   100 | 1,110.8 ns |  4.57 ns |  4.05 ns |  1.13 |    0.01 | 1.0433 |     - |     - |    2184 B |
|                   Hyperlinq_IFunction |   100 |   858.5 ns |  3.68 ns |  3.45 ns |  0.87 |    0.01 | 1.0433 |     - |     - |    2184 B |
|                        Hyperlinq_Pool |   100 | 1,034.3 ns |  2.21 ns |  2.07 ns |  1.05 |    0.01 | 0.0267 |     - |     - |      56 B |
|              Hyperlinq_Pool_IFunction |   100 |   824.3 ns |  1.64 ns |  1.53 ns |  0.84 |    0.00 | 0.0267 |     - |     - |      56 B |
