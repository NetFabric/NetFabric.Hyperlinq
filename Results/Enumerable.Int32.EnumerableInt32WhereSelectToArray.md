## Enumerable.Int32.EnumerableInt32WhereSelectToArray

### Source
[EnumerableInt32WhereSelectToArray.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelectToArray.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.19.2](https://www.nuget.org/packages/StructLinq.BCL/0.19.2)
- NetFabric.Hyperlinq: [3.0.0-beta27](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta27)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19041.630 (2004/?/20H1)
Intel Core i7 CPU 930 2.80GHz (Nehalem), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=5.0.100
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.51904, CoreFX 5.0.20.51904), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.51904, CoreFX 5.0.20.51904), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                                Method | Count |     Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |---------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                    ValueLinq_Standard |   100 | 2.262 μs | 0.0449 μs | 0.1040 μs |  1.73 |    0.11 | 0.1869 |     - |     - |     784 B |
|                       ValueLinq_Stack |   100 | 1.846 μs | 0.0387 μs | 0.1142 μs |  1.41 |    0.11 | 0.0610 |     - |     - |     264 B |
|             ValueLinq_SharedPool_Push |   100 | 2.320 μs | 0.0465 μs | 0.1088 μs |  1.79 |    0.12 | 0.0610 |     - |     - |     264 B |
|             ValueLinq_SharedPool_Pull |   100 | 2.200 μs | 0.0441 μs | 0.1170 μs |  1.69 |    0.12 | 0.0610 |     - |     - |     264 B |
|        ValueLinq_ValueLambda_Standard |   100 | 1.977 μs | 0.0394 μs | 0.1143 μs |  1.50 |    0.11 | 0.1869 |     - |     - |     784 B |
|           ValueLinq_ValueLambda_Stack |   100 | 1.334 μs | 0.0264 μs | 0.0527 μs |  1.02 |    0.06 | 0.0629 |     - |     - |     264 B |
| ValueLinq_ValueLambda_SharedPool_Push |   100 | 1.786 μs | 0.0352 μs | 0.0671 μs |  1.37 |    0.08 | 0.0629 |     - |     - |     264 B |
| ValueLinq_ValueLambda_SharedPool_Pull |   100 | 1.686 μs | 0.0333 μs | 0.0724 μs |  1.30 |    0.07 | 0.0629 |     - |     - |     264 B |
|                           ForeachLoop |   100 | 1.304 μs | 0.0257 μs | 0.0508 μs |  1.00 |    0.00 | 0.2174 |     - |     - |     912 B |
|                                  Linq |   100 | 2.022 μs | 0.0438 μs | 0.1277 μs |  1.49 |    0.10 | 0.1984 |     - |     - |     832 B |
|                                LinqAF |   100 | 9.207 μs | 0.4012 μs | 1.0914 μs |  7.24 |    0.85 |      - |     - |     - |     880 B |
|                            StructLinq |   100 | 2.054 μs | 0.0385 μs | 0.0643 μs |  1.58 |    0.09 | 0.0839 |     - |     - |     352 B |
|                  StructLinq_IFunction |   100 | 1.533 μs | 0.0301 μs | 0.0551 μs |  1.18 |    0.06 | 0.0629 |     - |     - |     264 B |
|                             Hyperlinq |   100 | 2.103 μs | 0.0420 μs | 0.1022 μs |  1.62 |    0.10 | 0.0610 |     - |     - |     264 B |
|                        Hyperlinq_Pool |   100 | 2.127 μs | 0.0423 μs | 0.0845 μs |  1.63 |    0.10 | 0.0229 |     - |     - |      96 B |
