## Range.RangeSelectToList

### Source
[RangeSelectToList.cs](../LinqBenchmarks/Range/RangeSelectToList.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.19.2](https://www.nuget.org/packages/StructLinq.BCL/0.19.2)
- NetFabric.Hyperlinq: [3.0.0-beta26](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta26)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19041.630 (2004/?/20H1)
Intel Core i7 CPU 930 2.80GHz (Nehalem), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=5.0.100
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.51904, CoreFX 5.0.20.51904), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.51904, CoreFX 5.0.20.51904), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                                Method | Start | Count |       Mean |     Error |    StdDev |     Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |------ |-----------:|----------:|----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|                    ValueLinq_Standard |     0 |   100 |   660.9 ns |  13.09 ns |  27.61 ns |   655.5 ns |  0.93 |    0.06 | 0.1087 |     - |     - |     456 B |
|                       ValueLinq_Stack |     0 |   100 | 1,506.7 ns |  29.16 ns |  32.41 ns | 1,520.3 ns |  2.10 |    0.09 | 0.1659 |     - |     - |     696 B |
|             ValueLinq_SharedPool_Push |     0 |   100 | 1,049.4 ns |  21.09 ns |  43.55 ns | 1,053.0 ns |  1.47 |    0.07 | 0.1087 |     - |     - |     456 B |
|             ValueLinq_SharedPool_Pull |     0 |   100 | 1,321.9 ns |  26.31 ns |  48.77 ns | 1,329.6 ns |  1.86 |    0.09 | 0.1087 |     - |     - |     456 B |
|        ValueLinq_ValueLambda_Standard |     0 |   100 |   474.9 ns |   9.29 ns |  11.41 ns |   479.8 ns |  0.66 |    0.03 | 0.1087 |     - |     - |     456 B |
|           ValueLinq_ValueLambda_Stack |     0 |   100 | 1,154.7 ns |  22.94 ns |  43.64 ns | 1,165.8 ns |  1.62 |    0.08 | 0.1659 |     - |     - |     696 B |
| ValueLinq_ValueLambda_SharedPool_Push |     0 |   100 |   921.9 ns |  18.17 ns |  28.28 ns |   932.1 ns |  1.30 |    0.05 | 0.1087 |     - |     - |     456 B |
| ValueLinq_ValueLambda_SharedPool_Pull |     0 |   100 |   995.1 ns |  19.99 ns |  51.24 ns |   999.7 ns |  1.40 |    0.09 | 0.1087 |     - |     - |     456 B |
|                               ForLoop |     0 |   100 |   712.4 ns |  14.36 ns |  25.89 ns |   720.4 ns |  1.00 |    0.00 | 0.2823 |     - |     - |    1184 B |
|                           ForeachLoop |     0 |   100 | 1,491.4 ns |  29.68 ns |  70.53 ns | 1,505.7 ns |  2.10 |    0.13 | 0.2956 |     - |     - |    1240 B |
|                                  Linq |     0 |   100 |   698.9 ns |  14.08 ns |  37.82 ns |   712.4 ns |  0.98 |    0.06 | 0.1297 |     - |     - |     544 B |
|                            LinqFaster |     0 |   100 |   795.6 ns |  15.75 ns |  26.74 ns |   802.8 ns |  1.12 |    0.05 | 0.3109 |     - |     - |    1304 B |
|                                LinqAF |     0 |   100 | 7,734.8 ns | 136.76 ns | 263.50 ns | 7,700.0 ns | 10.88 |    0.61 |      - |     - |     - |    1184 B |
|                            StructLinq |     0 |   100 |   814.8 ns |  16.20 ns |  25.69 ns |   825.4 ns |  1.14 |    0.06 | 0.1144 |     - |     - |     480 B |
|                  StructLinq_IFunction |     0 |   100 |   628.7 ns |  12.62 ns |  22.10 ns |   638.0 ns |  0.88 |    0.05 | 0.1087 |     - |     - |     456 B |
|                             Hyperlinq |     0 |   100 |   566.2 ns |  11.24 ns |  30.39 ns |   573.3 ns |  0.80 |    0.05 | 0.1202 |     - |     - |     504 B |
