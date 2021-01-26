## Array.Int32.ArrayInt32WhereSelectToArray

### Source
[ArrayInt32WhereSelectToArray.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelectToArray.cs)

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
|                                Method | Count |       Mean |     Error |    StdDev |     Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |-----------:|----------:|----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|                    ValueLinq_Standard |   100 | 1,203.1 ns |  10.34 ns |   9.17 ns | 1,202.0 ns |  1.93 |    0.12 | 0.1774 |     - |     - |     744 B |
|                       ValueLinq_Stack |   100 |   922.3 ns |  18.17 ns |  22.32 ns |   924.2 ns |  1.46 |    0.09 | 0.0534 |     - |     - |     224 B |
|             ValueLinq_SharedPool_Push |   100 | 1,286.1 ns |  25.22 ns |  39.27 ns | 1,293.1 ns |  2.04 |    0.14 | 0.0534 |     - |     - |     224 B |
|             ValueLinq_SharedPool_Pull |   100 | 1,283.0 ns |  25.42 ns |  46.49 ns | 1,286.2 ns |  2.03 |    0.12 | 0.0534 |     - |     - |     224 B |
|        ValueLinq_ValueLambda_Standard |   100 |   941.3 ns |  18.68 ns |  44.39 ns |   956.0 ns |  1.48 |    0.11 | 0.1774 |     - |     - |     744 B |
|           ValueLinq_ValueLambda_Stack |   100 |   598.1 ns |  12.09 ns |  31.86 ns |   600.6 ns |  0.94 |    0.06 | 0.0534 |     - |     - |     224 B |
| ValueLinq_ValueLambda_SharedPool_Push |   100 | 1,042.0 ns |  21.23 ns |  62.26 ns | 1,042.4 ns |  1.64 |    0.13 | 0.0534 |     - |     - |     224 B |
| ValueLinq_ValueLambda_SharedPool_Pull |   100 | 1,092.1 ns |  21.85 ns |  57.18 ns | 1,100.6 ns |  1.72 |    0.11 | 0.0534 |     - |     - |     224 B |
|                               ForLoop |   100 |   637.4 ns |  12.69 ns |  32.06 ns |   643.9 ns |  1.00 |    0.00 | 0.2079 |     - |     - |     872 B |
|                           ForeachLoop |   100 |   646.5 ns |  13.00 ns |  22.08 ns |   646.2 ns |  1.02 |    0.06 | 0.2079 |     - |     - |     872 B |
|                                  Linq |   100 | 1,256.0 ns |  25.23 ns |  69.91 ns | 1,264.8 ns |  1.97 |    0.15 | 0.1850 |     - |     - |     776 B |
|                            LinqFaster |   100 | 3,843.5 ns | 148.99 ns | 402.80 ns | 3,700.0 ns |  6.04 |    0.73 |      - |     - |     - |     648 B |
|                                LinqAF |   100 | 6,896.2 ns | 167.89 ns | 439.34 ns | 6,900.0 ns | 10.82 |    0.93 |      - |     - |     - |     840 B |
|                            StructLinq |   100 | 1,277.5 ns |  25.23 ns |  54.84 ns | 1,284.9 ns |  2.01 |    0.15 | 0.0763 |     - |     - |     320 B |
|                  StructLinq_IFunction |   100 |   927.4 ns |  18.71 ns |  53.67 ns |   937.0 ns |  1.46 |    0.12 | 0.0534 |     - |     - |     224 B |
|                             Hyperlinq |   100 | 1,246.8 ns |  24.71 ns |  53.20 ns | 1,242.4 ns |  1.97 |    0.15 | 0.0534 |     - |     - |     224 B |
|                        Hyperlinq_Pool |   100 | 1,308.7 ns |  26.16 ns |  55.17 ns | 1,312.4 ns |  2.07 |    0.14 | 0.0134 |     - |     - |      56 B |
