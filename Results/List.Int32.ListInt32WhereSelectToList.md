## List.Int32.ListInt32WhereSelectToList

### Source
[ListInt32WhereSelectToList.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelectToList.cs)

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
|                                        Method | Count |       Mean |     Error |    StdDev |     Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------------------------- |------ |-----------:|----------:|----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|                            ValueLinq_Standard |   100 | 1,294.7 ns |   6.45 ns |   5.72 ns | 1,293.6 ns |  1.97 |    0.13 | 0.1545 |     - |     - |     648 B |
|                               ValueLinq_Stack |   100 | 1,544.5 ns |   6.77 ns |   6.33 ns | 1,541.8 ns |  2.34 |    0.16 | 0.0610 |     - |     - |     256 B |
|                     ValueLinq_SharedPool_Push |   100 | 1,637.9 ns |  14.14 ns |  13.23 ns | 1,630.5 ns |  2.48 |    0.17 | 0.0610 |     - |     - |     256 B |
|                     ValueLinq_SharedPool_Pull |   100 | 1,952.1 ns |   7.32 ns |   5.71 ns | 1,954.8 ns |  3.00 |    0.20 | 0.0610 |     - |     - |     256 B |
|                ValueLinq_ValueLambda_Standard |   100 | 1,110.0 ns |   6.35 ns |   5.94 ns | 1,108.3 ns |  1.68 |    0.12 | 0.1545 |     - |     - |     648 B |
|                   ValueLinq_ValueLambda_Stack |   100 | 1,326.4 ns |  24.46 ns |  22.88 ns | 1,339.3 ns |  2.01 |    0.13 | 0.0610 |     - |     - |     256 B |
|         ValueLinq_ValueLambda_SharedPool_Push |   100 | 1,469.0 ns |  25.35 ns |  23.71 ns | 1,456.6 ns |  2.23 |    0.15 | 0.0610 |     - |     - |     256 B |
|         ValueLinq_ValueLambda_SharedPool_Pull |   100 | 1,667.6 ns |  33.40 ns |  41.02 ns | 1,689.5 ns |  2.51 |    0.18 | 0.0610 |     - |     - |     256 B |
|                    ValueLinq_Standard_ByIndex |   100 |   987.7 ns |  19.76 ns |  27.04 ns |   999.4 ns |  1.49 |    0.10 | 0.1545 |     - |     - |     648 B |
|                       ValueLinq_Stack_ByIndex |   100 | 1,076.1 ns |  21.36 ns |  40.63 ns | 1,071.9 ns |  1.62 |    0.11 | 0.0610 |     - |     - |     256 B |
|             ValueLinq_SharedPool_Push_ByIndex |   100 | 1,424.9 ns |  28.47 ns |  68.22 ns | 1,436.3 ns |  2.15 |    0.16 | 0.0610 |     - |     - |     256 B |
|             ValueLinq_SharedPool_Pull_ByIndex |   100 | 1,390.8 ns |  27.39 ns |  55.33 ns | 1,415.1 ns |  2.10 |    0.12 | 0.0610 |     - |     - |     256 B |
|        ValueLinq_ValueLambda_Standard_ByIndex |   100 |   820.5 ns |  16.23 ns |  29.67 ns |   833.8 ns |  1.24 |    0.09 | 0.1545 |     - |     - |     648 B |
|           ValueLinq_ValueLambda_Stack_ByIndex |   100 |   808.8 ns |  16.21 ns |  37.24 ns |   817.9 ns |  1.22 |    0.09 | 0.0610 |     - |     - |     256 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |   100 | 1,220.4 ns |  24.47 ns |  60.04 ns | 1,232.7 ns |  1.84 |    0.13 | 0.0610 |     - |     - |     256 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |   100 | 1,140.5 ns |  22.89 ns |  61.87 ns | 1,151.9 ns |  1.72 |    0.14 | 0.0610 |     - |     - |     256 B |
|                                       ForLoop |   100 |   665.0 ns |  13.41 ns |  34.12 ns |   674.4 ns |  1.00 |    0.00 | 0.1545 |     - |     - |     648 B |
|                                   ForeachLoop |   100 |   907.4 ns |  18.04 ns |  44.93 ns |   920.2 ns |  1.37 |    0.10 | 0.1545 |     - |     - |     648 B |
|                                          Linq |   100 | 1,092.2 ns |  21.97 ns |  59.41 ns | 1,116.6 ns |  1.65 |    0.13 | 0.1907 |     - |     - |     800 B |
|                                    LinqFaster |   100 | 1,011.9 ns |  20.01 ns |  51.66 ns | 1,019.8 ns |  1.52 |    0.10 | 0.2155 |     - |     - |     904 B |
|                                        LinqAF |   100 | 8,590.6 ns | 185.70 ns | 502.05 ns | 8,500.0 ns | 12.87 |    1.01 |      - |     - |     - |     648 B |
|                                    StructLinq |   100 | 1,109.4 ns |  21.91 ns |  57.34 ns | 1,129.8 ns |  1.68 |    0.12 | 0.0858 |     - |     - |     360 B |
|                          StructLinq_IFunction |   100 |   830.4 ns |  16.63 ns |  45.53 ns |   847.9 ns |  1.25 |    0.10 | 0.0610 |     - |     - |     256 B |
|                                     Hyperlinq |   100 | 1,125.2 ns |  22.11 ns |  44.66 ns | 1,146.2 ns |  1.70 |    0.11 | 0.0782 |     - |     - |     328 B |
