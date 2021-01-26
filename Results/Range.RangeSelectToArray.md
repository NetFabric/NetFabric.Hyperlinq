## Range.RangeSelectToArray

### Source
[RangeSelectToArray.cs](../LinqBenchmarks/Range/RangeSelectToArray.cs)

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
|                                Method | Start | Count |       Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |------ |-----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                    ValueLinq_Standard |     0 |   100 |   541.5 ns |  10.73 ns |  25.71 ns |  2.98 |    0.18 | 0.1011 |     - |     - |     424 B |
|                       ValueLinq_Stack |     0 |   100 | 1,027.6 ns |  20.37 ns |  44.71 ns |  5.69 |    0.28 | 0.1583 |     - |     - |     664 B |
|             ValueLinq_SharedPool_Push |     0 |   100 |   989.4 ns |  19.48 ns |  35.62 ns |  5.50 |    0.25 | 0.1011 |     - |     - |     424 B |
|             ValueLinq_SharedPool_Pull |     0 |   100 | 1,106.9 ns |  22.01 ns |  51.00 ns |  6.15 |    0.31 | 0.1011 |     - |     - |     424 B |
|        ValueLinq_ValueLambda_Standard |     0 |   100 |   417.1 ns |   8.29 ns |  15.58 ns |  2.30 |    0.13 | 0.1011 |     - |     - |     424 B |
|           ValueLinq_ValueLambda_Stack |     0 |   100 |   828.4 ns |  16.55 ns |  36.33 ns |  4.62 |    0.25 | 0.1583 |     - |     - |     664 B |
| ValueLinq_ValueLambda_SharedPool_Push |     0 |   100 |   896.0 ns |  17.97 ns |  36.31 ns |  4.96 |    0.28 | 0.1011 |     - |     - |     424 B |
| ValueLinq_ValueLambda_SharedPool_Pull |     0 |   100 |   833.2 ns |  16.48 ns |  25.66 ns |  4.61 |    0.20 | 0.1011 |     - |     - |     424 B |
|                               ForLoop |     0 |   100 |   180.9 ns |   3.68 ns |   5.73 ns |  1.00 |    0.00 | 0.1013 |     - |     - |     424 B |
|                                  Linq |     0 |   100 |   480.7 ns |   9.38 ns |  10.80 ns |  2.66 |    0.11 | 0.1221 |     - |     - |     512 B |
|                            LinqFaster |     0 |   100 |   587.9 ns |  11.70 ns |  25.43 ns |  3.25 |    0.19 | 0.2022 |     - |     - |     848 B |
|                                LinqAF |     0 |   100 | 6,932.5 ns | 138.62 ns | 246.40 ns | 38.45 |    1.91 |      - |     - |     - |    1576 B |
|                            StructLinq |     0 |   100 |   777.1 ns |  15.22 ns |  23.70 ns |  4.30 |    0.18 | 0.1068 |     - |     - |     448 B |
|                  StructLinq_IFunction |     0 |   100 |   599.0 ns |  11.82 ns |  19.42 ns |  3.31 |    0.11 | 0.1011 |     - |     - |     424 B |
|                             Hyperlinq |     0 |   100 |   473.5 ns |   9.39 ns |  14.62 ns |  2.62 |    0.11 | 0.1011 |     - |     - |     424 B |
|                        Hyperlinq_Pool |     0 |   100 |   479.2 ns |   9.63 ns |  18.78 ns |  2.65 |    0.12 | 0.0134 |     - |     - |      56 B |
