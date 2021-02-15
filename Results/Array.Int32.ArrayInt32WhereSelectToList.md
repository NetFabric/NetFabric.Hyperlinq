## Array.Int32.ArrayInt32WhereSelectToList

### Source
[ArrayInt32WhereSelectToList.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelectToList.cs)

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
|                                Method | Count |     Mean |   Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |---------:|--------:|--------:|------:|--------:|-------:|------:|------:|----------:|
|                    ValueLinq_Standard |   100 | 527.9 ns | 3.18 ns | 2.82 ns |  2.17 |    0.01 | 0.3090 |     - |     - |     648 B |
|                       ValueLinq_Stack |   100 | 605.3 ns | 2.64 ns | 2.47 ns |  2.48 |    0.01 | 0.1297 |     - |     - |     272 B |
|             ValueLinq_SharedPool_Push |   100 | 904.6 ns | 4.35 ns | 3.85 ns |  3.71 |    0.02 | 0.1297 |     - |     - |     272 B |
|             ValueLinq_SharedPool_Pull |   100 | 888.2 ns | 5.62 ns | 4.38 ns |  3.64 |    0.03 | 0.1297 |     - |     - |     272 B |
|        ValueLinq_ValueLambda_Standard |   100 | 378.6 ns | 2.92 ns | 2.58 ns |  1.55 |    0.01 | 0.3095 |     - |     - |     648 B |
|           ValueLinq_ValueLambda_Stack |   100 | 407.7 ns | 1.56 ns | 1.38 ns |  1.67 |    0.01 | 0.1297 |     - |     - |     272 B |
| ValueLinq_ValueLambda_SharedPool_Push |   100 | 651.3 ns | 3.99 ns | 3.33 ns |  2.67 |    0.02 | 0.1297 |     - |     - |     272 B |
| ValueLinq_ValueLambda_SharedPool_Pull |   100 | 655.4 ns | 3.94 ns | 3.29 ns |  2.69 |    0.02 | 0.1297 |     - |     - |     272 B |
|                               ForLoop |   100 | 243.8 ns | 1.28 ns | 1.07 ns |  1.00 |    0.00 | 0.3095 |     - |     - |     648 B |
|                           ForeachLoop |   100 | 256.7 ns | 0.99 ns | 0.83 ns |  1.05 |    0.01 | 0.3095 |     - |     - |     648 B |
|                                  Linq |   100 | 480.1 ns | 3.03 ns | 2.69 ns |  1.97 |    0.01 | 0.3595 |     - |     - |     752 B |
|                            LinqFaster |   100 | 456.1 ns | 1.96 ns | 1.83 ns |  1.87 |    0.01 | 0.4473 |     - |     - |     936 B |
|                                LinqAF |   100 | 709.4 ns | 4.16 ns | 3.69 ns |  2.91 |    0.02 | 0.3090 |     - |     - |     648 B |
|                            StructLinq |   100 | 598.3 ns | 4.71 ns | 3.94 ns |  2.45 |    0.02 | 0.1755 |     - |     - |     368 B |
|                  StructLinq_IFunction |   100 | 318.3 ns | 1.93 ns | 1.80 ns |  1.31 |    0.01 | 0.1297 |     - |     - |     272 B |
|                             Hyperlinq |   100 | 595.1 ns | 3.17 ns | 2.81 ns |  2.44 |    0.01 | 0.1297 |     - |     - |     272 B |
|                   Hyperlinq_IFunction |   100 | 373.9 ns | 1.03 ns | 0.86 ns |  1.53 |    0.01 | 0.1297 |     - |     - |     272 B |
