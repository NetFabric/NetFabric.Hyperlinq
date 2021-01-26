## Enumerable.Int32.EnumerableInt32WhereSelectToList

### Source
[EnumerableInt32WhereSelectToList.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelectToList.cs)

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
|                                Method | Count |      Mean |     Error |    StdDev |    Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |----------:|----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                    ValueLinq_Standard |   100 |  1.726 μs | 0.0341 μs | 0.0656 μs |  1.734 μs |  1.17 |    0.07 | 0.1640 |     - |     - |     688 B |
|                       ValueLinq_Stack |   100 |  1.996 μs | 0.0400 μs | 0.0809 μs |  2.038 μs |  1.35 |    0.09 | 0.0687 |     - |     - |     296 B |
|             ValueLinq_SharedPool_Push |   100 |  2.341 μs | 0.0468 μs | 0.0756 μs |  2.373 μs |  1.57 |    0.10 | 0.0687 |     - |     - |     296 B |
|             ValueLinq_SharedPool_Pull |   100 |  2.248 μs | 0.0447 μs | 0.1104 μs |  2.237 μs |  1.51 |    0.10 | 0.0687 |     - |     - |     296 B |
|        ValueLinq_ValueLambda_Standard |   100 |  1.538 μs | 0.0307 μs | 0.0759 μs |  1.558 μs |  1.04 |    0.08 | 0.1640 |     - |     - |     688 B |
|           ValueLinq_ValueLambda_Stack |   100 |  1.710 μs | 0.0339 μs | 0.0594 μs |  1.708 μs |  1.15 |    0.06 | 0.0706 |     - |     - |     296 B |
| ValueLinq_ValueLambda_SharedPool_Push |   100 |  2.196 μs | 0.0436 μs | 0.0975 μs |  2.198 μs |  1.49 |    0.11 | 0.0687 |     - |     - |     296 B |
| ValueLinq_ValueLambda_SharedPool_Pull |   100 |  2.121 μs | 0.0425 μs | 0.1082 μs |  2.157 μs |  1.43 |    0.10 | 0.0687 |     - |     - |     296 B |
|                           ForeachLoop |   100 |  1.488 μs | 0.0299 μs | 0.0721 μs |  1.501 μs |  1.00 |    0.00 | 0.1640 |     - |     - |     688 B |
|                                  Linq |   100 |  2.192 μs | 0.0545 μs | 0.1598 μs |  2.187 μs |  1.45 |    0.12 | 0.1907 |     - |     - |     808 B |
|                                LinqAF |   100 | 13.281 μs | 1.0720 μs | 3.0060 μs | 11.900 μs |  8.89 |    2.09 |      - |     - |     - |     688 B |
|                            StructLinq |   100 |  2.364 μs | 0.0467 μs | 0.1025 μs |  2.352 μs |  1.59 |    0.10 | 0.0916 |     - |     - |     384 B |
|                  StructLinq_IFunction |   100 |  1.467 μs | 0.0294 μs | 0.0823 μs |  1.479 μs |  0.98 |    0.07 | 0.0706 |     - |     - |     296 B |
|                             Hyperlinq |   100 |  2.180 μs | 0.0433 μs | 0.1038 μs |  2.194 μs |  1.47 |    0.10 | 0.0877 |     - |     - |     368 B |
